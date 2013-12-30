namespace AFPClient4Windows {
    partial class IfDelForm {
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
            this.tbF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bY = new System.Windows.Forms.Button();
            this.bN = new System.Windows.Forms.Button();
            this.bAll = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbF
            // 
            this.tbF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbF.Location = new System.Drawing.Point(12, 12);
            this.tbF.Name = "tbF";
            this.tbF.ReadOnly = true;
            this.tbF.Size = new System.Drawing.Size(454, 12);
            this.tbF.TabIndex = 0;
            this.tbF.Text = "xxx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "を、削除しますか？";
            // 
            // bY
            // 
            this.bY.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bY.Location = new System.Drawing.Point(12, 69);
            this.bY.Name = "bY";
            this.bY.Size = new System.Drawing.Size(100, 27);
            this.bY.TabIndex = 2;
            this.bY.Text = "はい(&Y)";
            this.bY.UseVisualStyleBackColor = true;
            // 
            // bN
            // 
            this.bN.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bN.Location = new System.Drawing.Point(118, 69);
            this.bN.Name = "bN";
            this.bN.Size = new System.Drawing.Size(100, 27);
            this.bN.TabIndex = 3;
            this.bN.Text = "いいえ(&N)";
            this.bN.UseVisualStyleBackColor = true;
            // 
            // bAll
            // 
            this.bAll.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.bAll.Location = new System.Drawing.Point(224, 69);
            this.bAll.Name = "bAll";
            this.bAll.Size = new System.Drawing.Size(100, 27);
            this.bAll.TabIndex = 4;
            this.bAll.Text = "すべて削除(&A)";
            this.bAll.UseVisualStyleBackColor = true;
            // 
            // bStop
            // 
            this.bStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bStop.Location = new System.Drawing.Point(330, 69);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(100, 27);
            this.bStop.TabIndex = 5;
            this.bStop.Text = "中止(&S)";
            this.bStop.UseVisualStyleBackColor = true;
            // 
            // IfDelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 104);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bAll);
            this.Controls.Add(this.bN);
            this.Controls.Add(this.bY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbF);
            this.Name = "IfDelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "削除（ホスト）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bY;
        private System.Windows.Forms.Button bN;
        private System.Windows.Forms.Button bAll;
        private System.Windows.Forms.Button bStop;
    }
}