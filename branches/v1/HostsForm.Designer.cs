namespace AFPClient4Windows {
    partial class HostsForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostsForm));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.bAdd = new System.Windows.Forms.Button();
            this.bEd = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.bConnect = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lH = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "C");
            this.il.Images.SetKeyName(1, "F");
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(323, 12);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(100, 23);
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = "新規ホスト(&N)...";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bEd
            // 
            this.bEd.Location = new System.Drawing.Point(323, 70);
            this.bEd.Name = "bEd";
            this.bEd.Size = new System.Drawing.Size(100, 23);
            this.bEd.TabIndex = 3;
            this.bEd.Text = "設定変更(&M)...";
            this.bEd.UseVisualStyleBackColor = true;
            this.bEd.Click += new System.EventHandler(this.bEd_Click);
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(323, 99);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(100, 23);
            this.bCopy.TabIndex = 4;
            this.bCopy.Text = "コピー(&C)";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(323, 128);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(100, 23);
            this.bRemove.TabIndex = 5;
            this.bRemove.Text = "削除(&D)...";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(323, 157);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(25, 23);
            this.bUp.TabIndex = 6;
            this.bUp.Text = "↑";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(365, 157);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(25, 23);
            this.bDown.TabIndex = 7;
            this.bDown.Text = "↓";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bConnect
            // 
            this.bConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bConnect.Location = new System.Drawing.Point(50, 215);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(100, 23);
            this.bConnect.TabIndex = 8;
            this.bConnect.Text = "接続(&S)";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(185, 215);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 23);
            this.bClose.TabIndex = 9;
            this.bClose.Text = "閉じる(&O)";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "新規&Group...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lH
            // 
            this.lH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lH.FormattingEnabled = true;
            this.lH.ItemHeight = 20;
            this.lH.Location = new System.Drawing.Point(12, 12);
            this.lH.Name = "lH";
            this.lH.Size = new System.Drawing.Size(305, 164);
            this.lH.TabIndex = 0;
            this.lH.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lH_MouseDoubleClick);
            this.lH.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lH_DrawItem);
            // 
            // HostsForm
            // 
            this.AcceptButton = this.bConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(435, 250);
            this.Controls.Add(this.lH);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bEd);
            this.Controls.Add(this.bAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ホスト一覧";
            this.Load += new System.EventHandler(this.HostsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bEd;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lH;
    }
}