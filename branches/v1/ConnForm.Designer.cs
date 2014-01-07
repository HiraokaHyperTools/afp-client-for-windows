namespace AFPClient4Windows {
    partial class ConnForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbDHX2 = new System.Windows.Forms.CheckBox();
            this.cbDHCAST128 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb2WayRandnumExchange = new System.Windows.Forms.CheckBox();
            this.cbNoUserAuthent = new System.Windows.Forms.CheckBox();
            this.cbCleartxtPasswrd = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbHostAdrs = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbRemoteDir = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bConfirm = new System.Windows.Forms.Button();
            this.tbHostVol = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bPutRem = new System.Windows.Forms.Button();
            this.bRefLoc = new System.Windows.Forms.Button();
            this.cbLast = new System.Windows.Forms.CheckBox();
            this.tbLocalDir = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbHostName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.bVolRem = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ホスト名(アドレス)(&N)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "ユーザ名(&U)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "パスワード/パスフレーズ(&P)";
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(219, 440);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 1;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(306, 440);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "キャンセル";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbDHX2
            // 
            this.cbDHX2.AutoSize = true;
            this.cbDHX2.Enabled = false;
            this.cbDHX2.Location = new System.Drawing.Point(6, 364);
            this.cbDHX2.Name = "cbDHX2";
            this.cbDHX2.Size = new System.Drawing.Size(53, 16);
            this.cbDHX2.TabIndex = 24;
            this.cbDHX2.Text = "DHX2";
            this.cbDHX2.UseVisualStyleBackColor = true;
            // 
            // cbDHCAST128
            // 
            this.cbDHCAST128.AutoSize = true;
            this.cbDHCAST128.Enabled = false;
            this.cbDHCAST128.Location = new System.Drawing.Point(6, 342);
            this.cbDHCAST128.Name = "cbDHCAST128";
            this.cbDHCAST128.Size = new System.Drawing.Size(88, 16);
            this.cbDHCAST128.TabIndex = 23;
            this.cbDHCAST128.Text = "DHCAST128";
            this.cbDHCAST128.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(6, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "許可する認証方式をOn/Off";
            // 
            // cb2WayRandnumExchange
            // 
            this.cb2WayRandnumExchange.AutoSize = true;
            this.cb2WayRandnumExchange.Location = new System.Drawing.Point(6, 320);
            this.cb2WayRandnumExchange.Name = "cb2WayRandnumExchange";
            this.cb2WayRandnumExchange.Size = new System.Drawing.Size(161, 16);
            this.cb2WayRandnumExchange.TabIndex = 22;
            this.cb2WayRandnumExchange.Text = "2-Way Randnum Exchange";
            this.cb2WayRandnumExchange.UseVisualStyleBackColor = true;
            // 
            // cbNoUserAuthent
            // 
            this.cbNoUserAuthent.AutoSize = true;
            this.cbNoUserAuthent.Location = new System.Drawing.Point(6, 276);
            this.cbNoUserAuthent.Name = "cbNoUserAuthent";
            this.cbNoUserAuthent.Size = new System.Drawing.Size(110, 16);
            this.cbNoUserAuthent.TabIndex = 20;
            this.cbNoUserAuthent.Text = "No User Authent";
            this.cbNoUserAuthent.UseVisualStyleBackColor = true;
            // 
            // cbCleartxtPasswrd
            // 
            this.cbCleartxtPasswrd.AutoSize = true;
            this.cbCleartxtPasswrd.Location = new System.Drawing.Point(6, 298);
            this.cbCleartxtPasswrd.Name = "cbCleartxtPasswrd";
            this.cbCleartxtPasswrd.Size = new System.Drawing.Size(112, 16);
            this.cbCleartxtPasswrd.TabIndex = 21;
            this.cbCleartxtPasswrd.Text = "Cleartxt Passwrd";
            this.cbCleartxtPasswrd.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(139, 92);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(199, 19);
            this.tbPassword.TabIndex = 8;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(6, 92);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(121, 19);
            this.tbUserName.TabIndex = 6;
            // 
            // tbHostAdrs
            // 
            this.tbHostAdrs.Location = new System.Drawing.Point(176, 18);
            this.tbHostAdrs.Name = "tbHostAdrs";
            this.tbHostAdrs.Size = new System.Drawing.Size(183, 19);
            this.tbHostAdrs.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(219, 12);
            this.label17.TabIndex = 15;
            this.label17.Text = "ホストの初期フォルダ(&R) … 半角コロン区切り";
            // 
            // tbRemoteDir
            // 
            this.tbRemoteDir.Location = new System.Drawing.Point(6, 203);
            this.tbRemoteDir.Name = "tbRemoteDir";
            this.tbRemoteDir.Size = new System.Drawing.Size(231, 19);
            this.tbRemoteDir.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bVolRem);
            this.tabPage1.Controls.Add(this.bConfirm);
            this.tabPage1.Controls.Add(this.tbHostVol);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.bPutRem);
            this.tabPage1.Controls.Add(this.bRefLoc);
            this.tabPage1.Controls.Add(this.cbDHX2);
            this.tabPage1.Controls.Add(this.cbLast);
            this.tabPage1.Controls.Add(this.cbDHCAST128);
            this.tabPage1.Controls.Add(this.tbLocalDir);
            this.tabPage1.Controls.Add(this.tbRemoteDir);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.cb2WayRandnumExchange);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbCleartxtPasswrd);
            this.tabPage1.Controls.Add(this.cbNoUserAuthent);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.tbHostName);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbHostAdrs);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbUserName);
            this.tabPage1.Controls.Add(this.tbPassword);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(175, 43);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(118, 23);
            this.bConfirm.TabIndex = 4;
            this.bConfirm.Text = "GetSrvrInfoで確認";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // tbHostVol
            // 
            this.tbHostVol.Location = new System.Drawing.Point(6, 166);
            this.tbHostVol.Name = "tbHostVol";
            this.tbHostVol.Size = new System.Drawing.Size(121, 19);
            this.tbHostVol.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "ホストのボリューム(&V)";
            // 
            // bPutRem
            // 
            this.bPutRem.Location = new System.Drawing.Point(243, 201);
            this.bPutRem.Name = "bPutRem";
            this.bPutRem.Size = new System.Drawing.Size(91, 23);
            this.bPutRem.TabIndex = 17;
            this.bPutRem.Text = "現在のﾌｫﾙﾀﾞ";
            this.bPutRem.UseVisualStyleBackColor = true;
            this.bPutRem.Click += new System.EventHandler(this.bPutRem_Click);
            // 
            // bRefLoc
            // 
            this.bRefLoc.Location = new System.Drawing.Point(243, 127);
            this.bRefLoc.Name = "bRefLoc";
            this.bRefLoc.Size = new System.Drawing.Size(50, 23);
            this.bRefLoc.TabIndex = 11;
            this.bRefLoc.Text = "...";
            this.bRefLoc.UseVisualStyleBackColor = true;
            // 
            // cbLast
            // 
            this.cbLast.AutoSize = true;
            this.cbLast.Location = new System.Drawing.Point(6, 228);
            this.cbLast.Name = "cbLast";
            this.cbLast.Size = new System.Drawing.Size(299, 16);
            this.cbLast.TabIndex = 18;
            this.cbLast.Text = "最後にアクセスしたフォルダを次回の初期フォルダをとする(&F)";
            this.cbLast.UseVisualStyleBackColor = true;
            // 
            // tbLocalDir
            // 
            this.tbLocalDir.Location = new System.Drawing.Point(6, 129);
            this.tbLocalDir.Name = "tbLocalDir";
            this.tbLocalDir.Size = new System.Drawing.Size(231, 19);
            this.tbLocalDir.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 114);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 12);
            this.label21.TabIndex = 9;
            this.label21.Text = "ローカルの初期フォルダ(&L)";
            // 
            // tbHostName
            // 
            this.tbHostName.Location = new System.Drawing.Point(6, 18);
            this.tbHostName.Name = "tbHostName";
            this.tbHostName.Size = new System.Drawing.Size(160, 19);
            this.tbHostName.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "ホストの設定名(&T)";
            // 
            // bVolRem
            // 
            this.bVolRem.Image = global::AFPClient4Windows.Properties.Resources.DRIVENET;
            this.bVolRem.Location = new System.Drawing.Point(133, 164);
            this.bVolRem.Name = "bVolRem";
            this.bVolRem.Size = new System.Drawing.Size(50, 23);
            this.bVolRem.TabIndex = 14;
            this.bVolRem.UseVisualStyleBackColor = true;
            this.bVolRem.Click += new System.EventHandler(this.bRefHostVol_Click);
            // 
            // ConnForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(402, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ホストの設定";
            this.Load += new System.EventHandler(this.ConnForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        internal System.Windows.Forms.TextBox tbHostAdrs;
        internal System.Windows.Forms.TextBox tbUserName;
        internal System.Windows.Forms.TextBox tbPassword;
        internal System.Windows.Forms.CheckBox cb2WayRandnumExchange;
        internal System.Windows.Forms.CheckBox cbCleartxtPasswrd;
        internal System.Windows.Forms.CheckBox cbNoUserAuthent;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox cbDHCAST128;
        internal System.Windows.Forms.CheckBox cbDHX2;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox tbRemoteDir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbHostName;
        private System.Windows.Forms.TextBox tbLocalDir;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbLast;
        private System.Windows.Forms.Button bRefLoc;
        private System.Windows.Forms.Button bPutRem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbHostVol;
        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.Button bVolRem;
    }
}