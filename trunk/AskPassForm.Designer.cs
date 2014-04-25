namespace AFPClient4Windows {
    partial class AskPassForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AskPassForm));
            this.tbP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbP
            // 
            this.tbP.AccessibleDescription = null;
            this.tbP.AccessibleName = null;
            resources.ApplyResources(this.tbP, "tbP");
            this.tbP.BackgroundImage = null;
            this.tbP.Font = null;
            this.tbP.Name = "tbP";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AccessibleDescription = null;
            this.button2.AccessibleName = null;
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackgroundImage = null;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = null;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AskPassForm
            // 
            this.AcceptButton = this.button1;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.button2;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbP);
            this.Font = null;
            this.Icon = null;
            this.Name = "AskPassForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}