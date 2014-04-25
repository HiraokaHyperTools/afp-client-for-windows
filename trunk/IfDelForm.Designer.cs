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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IfDelForm));
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
            this.tbF.AccessibleDescription = null;
            this.tbF.AccessibleName = null;
            resources.ApplyResources(this.tbF, "tbF");
            this.tbF.BackgroundImage = null;
            this.tbF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbF.Font = null;
            this.tbF.Name = "tbF";
            this.tbF.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // bY
            // 
            this.bY.AccessibleDescription = null;
            this.bY.AccessibleName = null;
            resources.ApplyResources(this.bY, "bY");
            this.bY.BackgroundImage = null;
            this.bY.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bY.Font = null;
            this.bY.Name = "bY";
            this.bY.UseVisualStyleBackColor = true;
            // 
            // bN
            // 
            this.bN.AccessibleDescription = null;
            this.bN.AccessibleName = null;
            resources.ApplyResources(this.bN, "bN");
            this.bN.BackgroundImage = null;
            this.bN.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bN.Font = null;
            this.bN.Name = "bN";
            this.bN.UseVisualStyleBackColor = true;
            // 
            // bAll
            // 
            this.bAll.AccessibleDescription = null;
            this.bAll.AccessibleName = null;
            resources.ApplyResources(this.bAll, "bAll");
            this.bAll.BackgroundImage = null;
            this.bAll.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.bAll.Font = null;
            this.bAll.Name = "bAll";
            this.bAll.UseVisualStyleBackColor = true;
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
            // 
            // IfDelForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bStop;
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bAll);
            this.Controls.Add(this.bN);
            this.Controls.Add(this.bY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbF);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IfDelForm";
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