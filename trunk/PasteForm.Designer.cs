namespace AFPClient4Windows {
    partial class PasteForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasteForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lStat = new System.Windows.Forms.Label();
            this.lfp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleDescription = null;
            this.progressBar1.AccessibleName = null;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.BackgroundImage = null;
            this.progressBar1.Font = null;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // bCancel
            // 
            this.bCancel.AccessibleDescription = null;
            this.bCancel.AccessibleName = null;
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.BackgroundImage = null;
            this.bCancel.Font = null;
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // progressBar2
            // 
            this.progressBar2.AccessibleDescription = null;
            this.progressBar2.AccessibleName = null;
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.BackgroundImage = null;
            this.progressBar2.Font = null;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // lStat
            // 
            this.lStat.AccessibleDescription = null;
            this.lStat.AccessibleName = null;
            resources.ApplyResources(this.lStat, "lStat");
            this.lStat.Font = null;
            this.lStat.Name = "lStat";
            // 
            // lfp
            // 
            this.lfp.AccessibleDescription = null;
            this.lfp.AccessibleName = null;
            resources.ApplyResources(this.lfp, "lfp");
            this.lfp.BackgroundImage = null;
            this.lfp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lfp.Font = null;
            this.lfp.Name = "lfp";
            this.lfp.ReadOnly = true;
            // 
            // PasteForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.lfp);
            this.Controls.Add(this.lStat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.progressBar1);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasteForm";
            this.Load += new System.EventHandler(this.PasteForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasteForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lStat;
        private System.Windows.Forms.TextBox lfp;
    }
}