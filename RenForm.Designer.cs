namespace AFPClient4Windows {
    partial class RenForm {
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.bY = new System.Windows.Forms.Button();
            this.bN = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb1.Location = new System.Drawing.Point(12, 12);
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.Size = new System.Drawing.Size(380, 12);
            this.tb1.TabIndex = 4;
            this.tb1.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "の、新しい名前を入力してください。\\ 区切り。親フォルダは ..\\ で指定。";
            // 
            // tb2
            // 
            this.tb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb2.Location = new System.Drawing.Point(12, 65);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(380, 19);
            this.tb2.TabIndex = 0;
            // 
            // bY
            // 
            this.bY.Location = new System.Drawing.Point(12, 102);
            this.bY.Name = "bY";
            this.bY.Size = new System.Drawing.Size(100, 29);
            this.bY.TabIndex = 1;
            this.bY.Text = "OK";
            this.bY.UseVisualStyleBackColor = true;
            this.bY.Click += new System.EventHandler(this.bY_Click);
            // 
            // bN
            // 
            this.bN.Location = new System.Drawing.Point(118, 102);
            this.bN.Name = "bN";
            this.bN.Size = new System.Drawing.Size(100, 29);
            this.bN.TabIndex = 2;
            this.bN.Text = "キャンセル";
            this.bN.UseVisualStyleBackColor = true;
            this.bN.Click += new System.EventHandler(this.bN_Click);
            // 
            // bStop
            // 
            this.bStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bStop.Location = new System.Drawing.Point(224, 102);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(100, 29);
            this.bStop.TabIndex = 3;
            this.bStop.Text = "中止(&S)";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // RenForm
            // 
            this.AcceptButton = this.bY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bStop;
            this.ClientSize = new System.Drawing.Size(404, 151);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bN);
            this.Controls.Add(this.bY);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "名前変更（ホスト）";
            this.Load += new System.EventHandler(this.RenForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bY;
        private System.Windows.Forms.Button bN;
        private System.Windows.Forms.Button bStop;
        internal System.Windows.Forms.TextBox tb1;
        internal System.Windows.Forms.TextBox tb2;
    }
}