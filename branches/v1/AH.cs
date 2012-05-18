using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AFPClient4Windows {
    public class AH : IDisposable {
        Cursor Prev;

        public AH() {
            Prev = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        #region IDisposable ƒƒ“ƒo

        public void Dispose() {
            Cursor.Current = Prev;
        }

        #endregion
    }
}
