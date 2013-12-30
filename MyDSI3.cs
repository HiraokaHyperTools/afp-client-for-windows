using System;
using System.Collections.Generic;
using System.Text;
using AFPt;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

// AFPt2 0.1@11:08 2012/01/17

namespace AFPt2 {
    public class TransmitRes {
        public DSIPack pack;
        public BER br;

        public TransmitRes(DSIPack pack) {
            this.pack = pack;
            this.br = new BER(new MemoryStream(pack.Payload, false));
        }
    }

    public class MyDSI3 : IDisposable {
        Socket Sock;
        NetworkStream st;
        ushort RId = 0;
        BER br;
        Thread t;
        Object SyncSendSock = new Object();
        Object SyncServs = new Object();
        ManualResetEvent evExit = new ManualResetEvent(false);
        int MaxSim = 10;

        public MyDSI3(IPEndPoint afp) {
            Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Sock.Connect(afp);
            st = new NetworkStream(Sock, false);
            br = new BER(st);
            t = new Thread(this.Receiver);
            t.Start();
        }

        class ServerDS { // server to client DS
            public EventWaitHandle evRecv = new ManualResetEvent(false);

            public ushort RId;

            public DSIPack dsiRes = null; // err if null

            public Exception err = null;

            public IDSI dsiReq = null;
        }

        List<ServerDS> servs = new List<ServerDS>();

        ServerDS GetServerDS(ushort RId) {
            lock (SyncServs) {
                foreach (ServerDS serv in servs) {
                    if (serv.RId == RId)
                        return serv;
                }
                return null;
            }
        }

        ServerDS NewServerDS(IDSI dsiReq) {
            while (true) {
                if (evExit.WaitOne(0, false))
                    throw new ExitShotException();
                lock (SyncServs) {
                    if (servs.Count >= MaxSim) {
                        Thread.Sleep(25);
                        continue;
                    }
                    else {
                        ushort RId = this.RId++;
                        ServerDS serv = new ServerDS();
                        serv.dsiReq = dsiReq;
                        serv.RId = RId;
                        servs.Add(serv);
                        return serv;
                    }
                }
            }
        }

        void DisconnecthServerDS(ServerDS serv) {
            lock (SyncServs) {
                servs.Remove(serv);
            }
        }

        void Receiver() {
            try {
                while (true) {
                    DSIPack res = new DSIPack(st);
                    if (res.Command == 5) // DSITickle
                        continue;
                    ServerDS sv = GetServerDS(res.RequestID);
                    if (sv == null)
                        continue;
                    sv.dsiRes = res;
                    sv.evRecv.Set();
                }
            }
            catch (Exception err) {
                if (!evExit.WaitOne(0, false)) {
                    //Console.Error.WriteLine("# Receiverが故障しました: " + err.Message);
                }

                lock (SyncServs) {
                    foreach (ServerDS serv in servs) {
                        serv.evRecv.Set();
                        serv.err = err;
                    }
                }

                if (Sock.Connected)
                    Sock.Shutdown(SocketShutdown.Both);
            }
        }

        public TransmitRes Transmit(IDSI dsiReq) {
            ServerDS sv;
            try {
                sv = NewServerDS(dsiReq);
            }
            catch (ExitShotException err) {
                throw new TransmitFailureException(err);
            }

            try {
                try {
                    lock (SyncSendSock) {
                        Sock.Send(dsiReq.ToArray(sv.RId));
                    }
                }
                catch (SocketException err) {
                    throw new TransmitFailureException(err);
                }

                sv.evRecv.WaitOne();

                if (sv.err != null) throw new TransmitFailureException(sv.err);

                return new TransmitRes(sv.dsiRes);
            }
            finally {
                DisconnecthServerDS(sv);
            }
        }

        public ushort NewRID() {
            lock (this) {
                return ++RId;
            }
        }

        #region IDisposable メンバ

        public void Dispose() {
            evExit.Set();
            Sock.Shutdown(SocketShutdown.Both);
            Sock.Disconnect(false);
            Sock.Close();
        }

        #endregion

        public class ExitShotException : ApplicationException {
            public ExitShotException()
                : base("evExitがショットされました") {

            }
        }

        public bool Alive {
            get {
                if (t.Join(0))
                    return false;
                return true;
            }
        }
    }

    public class TransmitFailureException : ApplicationException {
        public TransmitFailureException(Exception innerException)
            : base("通信に失敗しました", innerException) {

        }
    }
}
