namespace AFPClient4Windows {
    partial class GetSrvrInfoForm {
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
            this.bwConfirm = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAFPVersionsList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUAMsList = new System.Windows.Forms.TextBox();
            this.cbServerName = new System.Windows.Forms.CheckBox();
            this.cbUAMsList = new System.Windows.Forms.CheckBox();
            this.bOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bwConfirm
            // 
            this.bwConfirm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConfirm_DoWork);
            this.bwConfirm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwConfirm_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerName";
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(12, 24);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.ReadOnly = true;
            this.tbServerName.Size = new System.Drawing.Size(233, 19);
            this.tbServerName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "AFPVersionsList";
            // 
            // tbAFPVersionsList
            // 
            this.tbAFPVersionsList.Location = new System.Drawing.Point(12, 61);
            this.tbAFPVersionsList.Multiline = true;
            this.tbAFPVersionsList.Name = "tbAFPVersionsList";
            this.tbAFPVersionsList.ReadOnly = true;
            this.tbAFPVersionsList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAFPVersionsList.Size = new System.Drawing.Size(233, 86);
            this.tbAFPVersionsList.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "UAMsList";
            // 
            // tbUAMsList
            // 
            this.tbUAMsList.Location = new System.Drawing.Point(12, 165);
            this.tbUAMsList.Multiline = true;
            this.tbUAMsList.Name = "tbUAMsList";
            this.tbUAMsList.ReadOnly = true;
            this.tbUAMsList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbUAMsList.Size = new System.Drawing.Size(233, 86);
            this.tbUAMsList.TabIndex = 7;
            // 
            // cbServerName
            // 
            this.cbServerName.AutoSize = true;
            this.cbServerName.Checked = true;
            this.cbServerName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbServerName.Location = new System.Drawing.Point(197, 8);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Size = new System.Drawing.Size(48, 16);
            this.cbServerName.TabIndex = 1;
            this.cbServerName.Text = "採用";
            this.cbServerName.UseVisualStyleBackColor = true;
            // 
            // cbUAMsList
            // 
            this.cbUAMsList.AutoSize = true;
            this.cbUAMsList.Checked = true;
            this.cbUAMsList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUAMsList.Location = new System.Drawing.Point(197, 149);
            this.cbUAMsList.Name = "cbUAMsList";
            this.cbUAMsList.Size = new System.Drawing.Size(48, 16);
            this.cbUAMsList.TabIndex = 6;
            this.cbUAMsList.Text = "採用";
            this.cbUAMsList.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(12, 257);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 8;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            // 
            // GetSrvrInfoForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 297);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.cbUAMsList);
            this.Controls.Add(this.cbServerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUAMsList);
            this.Controls.Add(this.tbAFPVersionsList);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetSrvrInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GetSrvrInfoForm";
            this.Load += new System.EventHandler(this.GetSrvrInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.CheckBox cbServerName;
        internal System.Windows.Forms.CheckBox cbUAMsList;
        internal System.Windows.Forms.TextBox tbServerName;
        internal System.Windows.Forms.TextBox tbAFPVersionsList;
        internal System.Windows.Forms.TextBox tbUAMsList;
        private System.Windows.Forms.Button bOk;
    }
}