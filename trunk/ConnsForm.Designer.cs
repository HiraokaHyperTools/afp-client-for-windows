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
            this.lvC = new System.Windows.Forms.ListView();
            this.chfn = new System.Windows.Forms.ColumnHeader();
            this.chhost = new System.Windows.Forms.ColumnHeader();
            this.chu = new System.Windows.Forms.ColumnHeader();
            this.il16 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bConn = new System.Windows.Forms.ToolStripButton();
            this.bExplorer = new System.Windows.Forms.ToolStripButton();
            this.bRefreshTree = new System.Windows.Forms.ToolStripButton();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            this.tsc.AccessibleDescription = null;
            this.tsc.AccessibleName = null;
            resources.ApplyResources(this.tsc, "tsc");
            // 
            // tsc.BottomToolStripPanel
            // 
            this.tsc.BottomToolStripPanel.AccessibleDescription = null;
            this.tsc.BottomToolStripPanel.AccessibleName = null;
            this.tsc.BottomToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.tsc.BottomToolStripPanel, "tsc.BottomToolStripPanel");
            this.tsc.BottomToolStripPanel.Font = null;
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.AccessibleDescription = null;
            this.tsc.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.tsc.ContentPanel, "tsc.ContentPanel");
            this.tsc.ContentPanel.BackgroundImage = null;
            this.tsc.ContentPanel.Controls.Add(this.lvC);
            this.tsc.ContentPanel.Font = null;
            this.tsc.Font = null;
            // 
            // tsc.LeftToolStripPanel
            // 
            this.tsc.LeftToolStripPanel.AccessibleDescription = null;
            this.tsc.LeftToolStripPanel.AccessibleName = null;
            this.tsc.LeftToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.tsc.LeftToolStripPanel, "tsc.LeftToolStripPanel");
            this.tsc.LeftToolStripPanel.Font = null;
            this.tsc.Name = "tsc";
            // 
            // tsc.RightToolStripPanel
            // 
            this.tsc.RightToolStripPanel.AccessibleDescription = null;
            this.tsc.RightToolStripPanel.AccessibleName = null;
            this.tsc.RightToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.tsc.RightToolStripPanel, "tsc.RightToolStripPanel");
            this.tsc.RightToolStripPanel.Font = null;
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.AccessibleDescription = null;
            this.tsc.TopToolStripPanel.AccessibleName = null;
            this.tsc.TopToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.tsc.TopToolStripPanel, "tsc.TopToolStripPanel");
            this.tsc.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.tsc.TopToolStripPanel.Font = null;
            // 
            // lvC
            // 
            this.lvC.AccessibleDescription = null;
            this.lvC.AccessibleName = null;
            resources.ApplyResources(this.lvC, "lvC");
            this.lvC.BackgroundImage = null;
            this.lvC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfn,
            this.chhost,
            this.chu});
            this.lvC.Font = null;
            this.lvC.FullRowSelect = true;
            this.lvC.GridLines = true;
            this.lvC.MultiSelect = false;
            this.lvC.Name = "lvC";
            this.lvC.SmallImageList = this.il16;
            this.lvC.UseCompatibleStateImageBehavior = false;
            this.lvC.View = System.Windows.Forms.View.Details;
            this.lvC.ItemActivate += new System.EventHandler(this.lvC_ItemActivate);
            this.lvC.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvC_ColumnClick);
            // 
            // chfn
            // 
            resources.ApplyResources(this.chfn, "chfn");
            // 
            // chhost
            // 
            resources.ApplyResources(this.chhost, "chhost");
            // 
            // chu
            // 
            resources.ApplyResources(this.chu, "chu");
            // 
            // il16
            // 
            this.il16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il16.ImageStream")));
            this.il16.TransparentColor = System.Drawing.Color.Transparent;
            this.il16.Images.SetKeyName(0, "E");
            this.il16.Images.SetKeyName(1, "X");
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleDescription = null;
            this.toolStrip1.AccessibleName = null;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.Font = null;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNew,
            this.bEdit,
            this.bConn,
            this.bExplorer,
            this.bRefreshTree});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // bNew
            // 
            this.bNew.AccessibleDescription = null;
            this.bNew.AccessibleName = null;
            resources.ApplyResources(this.bNew, "bNew");
            this.bNew.BackgroundImage = null;
            this.bNew.Image = global::AFPClient4Windows.Properties.Resources.NewCardHS;
            this.bNew.Name = "bNew";
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bEdit
            // 
            this.bEdit.AccessibleDescription = null;
            this.bEdit.AccessibleName = null;
            resources.ApplyResources(this.bEdit, "bEdit");
            this.bEdit.BackgroundImage = null;
            this.bEdit.Image = global::AFPClient4Windows.Properties.Resources.EditInformationHS;
            this.bEdit.Name = "bEdit";
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bConn
            // 
            this.bConn.AccessibleDescription = null;
            this.bConn.AccessibleName = null;
            resources.ApplyResources(this.bConn, "bConn");
            this.bConn.BackgroundImage = null;
            this.bConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            this.bConn.Name = "bConn";
            this.bConn.Click += new System.EventHandler(this.bConn_Click);
            // 
            // bExplorer
            // 
            this.bExplorer.AccessibleDescription = null;
            this.bExplorer.AccessibleName = null;
            resources.ApplyResources(this.bExplorer, "bExplorer");
            this.bExplorer.BackgroundImage = null;
            this.bExplorer.Image = global::AFPClient4Windows.Properties.Resources.SearchFolderHS;
            this.bExplorer.Name = "bExplorer";
            this.bExplorer.Click += new System.EventHandler(this.bExplorer_Click);
            // 
            // bRefreshTree
            // 
            this.bRefreshTree.AccessibleDescription = null;
            this.bRefreshTree.AccessibleName = null;
            resources.ApplyResources(this.bRefreshTree, "bRefreshTree");
            this.bRefreshTree.BackgroundImage = null;
            this.bRefreshTree.Image = global::AFPClient4Windows.Properties.Resources.RefreshDocViewHS;
            this.bRefreshTree.Name = "bRefreshTree";
            this.bRefreshTree.Click += new System.EventHandler(this.bRefreshTree_Click);
            // 
            // ConnsForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tsc);
            this.Font = null;
            this.Icon = null;
            this.Name = "ConnsForm";
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
        private System.Windows.Forms.ImageList il16;
        private System.Windows.Forms.ToolStripButton bRefreshTree;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bConn;
        private System.Windows.Forms.ListView lvC;
        private System.Windows.Forms.ColumnHeader chfn;
        private System.Windows.Forms.ColumnHeader chhost;
        private System.Windows.Forms.ColumnHeader chu;
    }
}