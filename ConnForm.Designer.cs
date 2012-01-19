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
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbDHX2 = new System.Windows.Forms.CheckBox();
            this.cbDHX = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb2w = new System.Windows.Forms.CheckBox();
            this.cb0 = new System.Windows.Forms.CheckBox();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbP = new System.Windows.Forms.TextBox();
            this.tbU = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tbHostDir = new System.Windows.Forms.TextBox();
            this.tlp.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "接続先のIPアドレス又はホスト名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pass";
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(12, 342);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(150, 23);
            this.bOk.TabIndex = 9;
            this.bOk.Text = "接続する";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(168, 342);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "閉じる";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // tlp
            // 
            this.tlp.AutoSize = true;
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.Controls.Add(this.flowLayoutPanel2, 2, 5);
            this.tlp.Controls.Add(this.flowLayoutPanel1, 2, 4);
            this.tlp.Controls.Add(this.cbDHX2, 0, 5);
            this.tlp.Controls.Add(this.cbDHX, 0, 4);
            this.tlp.Controls.Add(this.label8, 1, 3);
            this.tlp.Controls.Add(this.label7, 1, 2);
            this.tlp.Controls.Add(this.label4, 0, 0);
            this.tlp.Controls.Add(this.cb2w, 0, 3);
            this.tlp.Controls.Add(this.cb0, 0, 1);
            this.tlp.Controls.Add(this.cb1, 0, 2);
            this.tlp.Controls.Add(this.label5, 1, 0);
            this.tlp.Controls.Add(this.label6, 1, 1);
            this.tlp.Controls.Add(this.label9, 1, 4);
            this.tlp.Controls.Add(this.label10, 2, 0);
            this.tlp.Controls.Add(this.label11, 2, 1);
            this.tlp.Controls.Add(this.label12, 2, 2);
            this.tlp.Controls.Add(this.label13, 2, 3);
            this.tlp.Controls.Add(this.label15, 1, 5);
            this.tlp.Location = new System.Drawing.Point(12, 173);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 6;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.Size = new System.Drawing.Size(383, 129);
            this.tlp.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label16);
            this.flowLayoutPanel2.Controls.Add(this.label19);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(259, 111);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(123, 12);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "できる";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(42, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 12);
            this.label19.TabIndex = 5;
            this.label19.Text = "(但し、非対応)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label14);
            this.flowLayoutPanel1.Controls.Add(this.label18);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(259, 88);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(123, 12);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "できる";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(42, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 12);
            this.label18.TabIndex = 5;
            this.label18.Text = "(但し、非対応)";
            // 
            // cbDHX2
            // 
            this.cbDHX2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDHX2.AutoSize = true;
            this.cbDHX2.Checked = global::AFPClient4Windows.Properties.Settings.Default.DHX2;
            this.cbDHX2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AFPClient4Windows.Properties.Settings.Default, "DHX2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbDHX2.Enabled = false;
            this.cbDHX2.Location = new System.Drawing.Point(4, 109);
            this.cbDHX2.Name = "cbDHX2";
            this.cbDHX2.Size = new System.Drawing.Size(53, 16);
            this.cbDHX2.TabIndex = 10;
            this.cbDHX2.Text = "DHX2";
            this.cbDHX2.UseVisualStyleBackColor = true;
            // 
            // cbDHX
            // 
            this.cbDHX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDHX.AutoSize = true;
            this.cbDHX.Checked = global::AFPClient4Windows.Properties.Settings.Default.DHCAST128;
            this.cbDHX.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AFPClient4Windows.Properties.Settings.Default, "DHCAST128", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbDHX.Enabled = false;
            this.cbDHX.Location = new System.Drawing.Point(4, 86);
            this.cbDHX.Name = "cbDHX";
            this.cbDHX.Size = new System.Drawing.Size(88, 16);
            this.cbDHX.TabIndex = 7;
            this.cbDHX.Text = "DHCAST128";
            this.cbDHX.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "とても低い";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "非常に低い";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(19, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "許可する方式をOn/Off";
            // 
            // cb2w
            // 
            this.cb2w.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb2w.AutoSize = true;
            this.cb2w.Checked = global::AFPClient4Windows.Properties.Settings.Default.TwoWayRandnumExchange;
            this.cb2w.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AFPClient4Windows.Properties.Settings.Default, "TwoWayRandnumExchange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb2w.Location = new System.Drawing.Point(4, 63);
            this.cb2w.Name = "cb2w";
            this.cb2w.Size = new System.Drawing.Size(161, 16);
            this.cb2w.TabIndex = 2;
            this.cb2w.Text = "2-Way Randnum Exchange";
            this.cb2w.UseVisualStyleBackColor = true;
            // 
            // cb0
            // 
            this.cb0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb0.AutoSize = true;
            this.cb0.Checked = global::AFPClient4Windows.Properties.Settings.Default.NoUserAuthent;
            this.cb0.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AFPClient4Windows.Properties.Settings.Default, "NoUserAuthent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb0.Location = new System.Drawing.Point(4, 17);
            this.cb0.Name = "cb0";
            this.cb0.Size = new System.Drawing.Size(110, 16);
            this.cb0.TabIndex = 0;
            this.cb0.Text = "No User Authent";
            this.cb0.UseVisualStyleBackColor = true;
            // 
            // cb1
            // 
            this.cb1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb1.AutoSize = true;
            this.cb1.Checked = global::AFPClient4Windows.Properties.Settings.Default.CleartxtPasswrd;
            this.cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AFPClient4Windows.Properties.Settings.Default, "CleartxtPasswrd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb1.Location = new System.Drawing.Point(4, 40);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(112, 16);
            this.cb1.TabIndex = 1;
            this.cb1.Text = "Cleartxt Passwrd";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(172, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "パスワード保護";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "無い";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "普通";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(305, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "推奨";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "できない";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(262, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "できない";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(262, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "できない";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(172, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "普通";
            // 
            // tbP
            // 
            this.tbP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AFPClient4Windows.Properties.Settings.Default, "P", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbP.Location = new System.Drawing.Point(12, 98);
            this.tbP.Name = "tbP";
            this.tbP.PasswordChar = '*';
            this.tbP.Size = new System.Drawing.Size(100, 19);
            this.tbP.TabIndex = 5;
            this.tbP.Text = global::AFPClient4Windows.Properties.Settings.Default.P;
            // 
            // tbU
            // 
            this.tbU.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AFPClient4Windows.Properties.Settings.Default, "U", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbU.Location = new System.Drawing.Point(12, 61);
            this.tbU.Name = "tbU";
            this.tbU.Size = new System.Drawing.Size(100, 19);
            this.tbU.TabIndex = 3;
            this.tbU.Text = global::AFPClient4Windows.Properties.Settings.Default.U;
            // 
            // tbHost
            // 
            this.tbHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AFPClient4Windows.Properties.Settings.Default, "Host", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHost.Location = new System.Drawing.Point(12, 24);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(100, 19);
            this.tbHost.TabIndex = 1;
            this.tbHost.Text = global::AFPClient4Windows.Properties.Settings.Default.Host;
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSave.Location = new System.Drawing.Point(264, 342);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(118, 23);
            this.bSave.TabIndex = 11;
            this.bSave.Text = "既定値として保存";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 120);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "ホストの初期フォルダ(\\区切り)";
            // 
            // tbHostDir
            // 
            this.tbHostDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AFPClient4Windows.Properties.Settings.Default, "Hostdir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHostDir.Location = new System.Drawing.Point(12, 135);
            this.tbHostDir.Name = "tbHostDir";
            this.tbHostDir.Size = new System.Drawing.Size(231, 19);
            this.tbHostDir.TabIndex = 7;
            this.tbHostDir.Text = global::AFPClient4Windows.Properties.Settings.Default.HostDir;
            // 
            // ConnForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(425, 377);
            this.Controls.Add(this.tbHostDir);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tlp);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tbP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnForm";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        internal System.Windows.Forms.TextBox tbHost;
        internal System.Windows.Forms.TextBox tbU;
        internal System.Windows.Forms.TextBox tbP;
        internal System.Windows.Forms.CheckBox cb2w;
        internal System.Windows.Forms.CheckBox cb1;
        internal System.Windows.Forms.CheckBox cb0;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox cbDHX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.CheckBox cbDHX2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox tbHostDir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label18;
    }
}