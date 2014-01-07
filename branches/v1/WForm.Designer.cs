namespace AFPClient4Windows {
    partial class WForm {
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
            this.lfp = new System.Windows.Forms.Label();
            this.lpos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ファイル：";
            // 
            // lfp
            // 
            this.lfp.AutoSize = true;
            this.lfp.Location = new System.Drawing.Point(63, 9);
            this.lfp.Name = "lfp";
            this.lfp.Size = new System.Drawing.Size(11, 12);
            this.lfp.TabIndex = 1;
            this.lfp.Text = "...";
            // 
            // lrate
            // 
            this.lpos.AutoSize = true;
            this.lpos.Location = new System.Drawing.Point(63, 30);
            this.lpos.Name = "lrate";
            this.lpos.Size = new System.Drawing.Size(10, 12);
            this.lpos.TabIndex = 2;
            this.lpos.Text = "?";
            // 
            // WForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 62);
            this.Controls.Add(this.lpos);
            this.Controls.Add(this.lfp);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ファイルを転送しています";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lfp;
        internal System.Windows.Forms.Label lpos;
    }
}