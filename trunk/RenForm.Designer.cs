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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenForm));
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
            this.tb1.AccessibleDescription = null;
            this.tb1.AccessibleName = null;
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.BackgroundImage = null;
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb1.Font = null;
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // tb2
            // 
            this.tb2.AccessibleDescription = null;
            this.tb2.AccessibleName = null;
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.BackgroundImage = null;
            this.tb2.Font = null;
            this.tb2.Name = "tb2";
            // 
            // bY
            // 
            this.bY.AccessibleDescription = null;
            this.bY.AccessibleName = null;
            resources.ApplyResources(this.bY, "bY");
            this.bY.BackgroundImage = null;
            this.bY.Font = null;
            this.bY.Name = "bY";
            this.bY.UseVisualStyleBackColor = true;
            this.bY.Click += new System.EventHandler(this.bY_Click);
            // 
            // bN
            // 
            this.bN.AccessibleDescription = null;
            this.bN.AccessibleName = null;
            resources.ApplyResources(this.bN, "bN");
            this.bN.BackgroundImage = null;
            this.bN.Font = null;
            this.bN.Name = "bN";
            this.bN.UseVisualStyleBackColor = true;
            this.bN.Click += new System.EventHandler(this.bN_Click);
            // 
            // bStop
            // 
            this.bStop.AccessibleDescription = null;
            this.bStop.AccessibleName = null;
            resources.ApplyResources(this.bStop, "bStop");
            this.bStop.BackgroundImage = null;
            this.bStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bStop.Font = null;
            this.bStop.Name = "bStop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // RenForm
            // 
            this.AcceptButton = this.bY;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bStop;
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bN);
            this.Controls.Add(this.bY);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb1);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenForm";
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