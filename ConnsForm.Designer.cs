namespace AFPClient4Windows {
    partial class ConnsForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnsForm));
            this.tsc = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tvC = new System.Windows.Forms.TreeView();
            this.il16 = new System.Windows.Forms.ImageList(this.components);
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bExplorer = new System.Windows.Forms.ToolStripButton();
            this.bRefreshTree = new System.Windows.Forms.ToolStripButton();
            this.bConn = new System.Windows.Forms.ToolStripButton();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.tvC);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(579, 240);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(579, 265);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNew,
            this.bEdit,
            this.bConn,
            this.bExplorer,
            this.bRefreshTree});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(480, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tvC
            // 
            this.tvC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvC.ImageIndex = 0;
            this.tvC.ImageList = this.il16;
            this.tvC.Location = new System.Drawing.Point(0, 0);
            this.tvC.Name = "tvC";
            this.tvC.SelectedImageIndex = 0;
            this.tvC.ShowRootLines = false;
            this.tvC.Size = new System.Drawing.Size(579, 240);
            this.tvC.TabIndex = 0;
            this.tvC.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvC_NodeMouseDoubleClick);
            this.tvC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvC_KeyDown);
            // 
            // il16
            // 
            this.il16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il16.ImageStream")));
            this.il16.TransparentColor = System.Drawing.Color.Transparent;
            this.il16.Images.SetKeyName(0, "D");
            // 
            // bNew
            // 
            this.bNew.Image = ((System.Drawing.Image)(resources.GetObject("bNew.Image")));
            this.bNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(125, 22);
            this.bNew.Text = "新しい接続先(&N)...";
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bEdit
            // 
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(80, 22);
            this.bEdit.Text = "編集(&E)...";
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bExplorer
            // 
            this.bExplorer.Image = ((System.Drawing.Image)(resources.GetObject("bExplorer.Image")));
            this.bExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExplorer.Name = "bExplorer";
            this.bExplorer.Size = new System.Drawing.Size(106, 22);
            this.bExplorer.Text = "エクスプローラ(&L)";
            this.bExplorer.Click += new System.EventHandler(this.bExplorer_Click);
            // 
            // bRefreshTree
            // 
            this.bRefreshTree.Image = global::AFPClient4Windows.Properties.Resources.RefreshDocViewHS;
            this.bRefreshTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefreshTree.Name = "bRefreshTree";
            this.bRefreshTree.Size = new System.Drawing.Size(69, 22);
            this.bRefreshTree.Text = "更新(&R)";
            this.bRefreshTree.Click += new System.EventHandler(this.bRefreshTree_Click);
            // 
            // bConn
            // 
            this.bConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            this.bConn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bConn.Name = "bConn";
            this.bConn.Size = new System.Drawing.Size(88, 22);
            this.bConn.Text = "接続する(&C)";
            this.bConn.Click += new System.EventHandler(this.bConn_Click);
            // 
            // ConnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 265);
            this.Controls.Add(this.tsc);
            this.Name = "ConnsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "接続する";
            this.Load += new System.EventHandler(this.ConnsForm_Load);
            this.tsc.ContentPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.PerformLayout();
            this.tsc.ResumeLayout(false);
            this.tsc.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bNew;
        private System.Windows.Forms.ToolStripButton bExplorer;
        private System.Windows.Forms.TreeView tvC;
        private System.Windows.Forms.ImageList il16;
        private System.Windows.Forms.ToolStripButton bRefreshTree;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bConn;
    }
}