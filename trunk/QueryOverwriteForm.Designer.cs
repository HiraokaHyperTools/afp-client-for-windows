namespace AFPClient4Windows {
    partial class QueryOverwriteForm {
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
            this.lfp = new System.Windows.Forms.Label();
            this.bYes = new System.Windows.Forms.Button();
            this.bNo = new System.Windows.Forms.Button();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lfp
            // 
            this.lfp.AutoSize = true;
            this.lfp.Location = new System.Drawing.Point(12, 9);
            this.lfp.Name = "lfp";
            this.lfp.Size = new System.Drawing.Size(11, 12);
            this.lfp.TabIndex = 0;
            this.lfp.Text = "...";
            // 
            // bYes
            // 
            this.bYes.Location = new System.Drawing.Point(12, 40);
            this.bYes.Name = "bYes";
            this.bYes.Size = new System.Drawing.Size(150, 23);
            this.bYes.TabIndex = 1;
            this.bYes.Text = "上書きする";
            this.bYes.UseVisualStyleBackColor = true;
            this.bYes.Click += new System.EventHandler(this.bYes_Click);
            // 
            // bNo
            // 
            this.bNo.Location = new System.Drawing.Point(168, 40);
            this.bNo.Name = "bNo";
            this.bNo.Size = new System.Drawing.Size(150, 23);
            this.bNo.TabIndex = 2;
            this.bNo.Text = "上書きしない";
            this.bNo.UseVisualStyleBackColor = true;
            this.bNo.Click += new System.EventHandler(this.bNo_Click);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(324, 44);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(77, 16);
            this.cbAll.TabIndex = 3;
            this.cbAll.Text = "以降すべて";
            this.cbAll.UseVisualStyleBackColor = true;
            // 
            // QueryOverwriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 75);
            this.Controls.Add(this.cbAll);
            this.Controls.Add(this.bNo);
            this.Controls.Add(this.bYes);
            this.Controls.Add(this.lfp);
            this.Name = "QueryOverwriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "上書きしますか？";
            this.Load += new System.EventHandler(this.QueryOverwriteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bYes;
        private System.Windows.Forms.Button bNo;
        internal System.Windows.Forms.CheckBox cbAll;
        internal System.Windows.Forms.Label lfp;
    }
}