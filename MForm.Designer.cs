using System.Globalization;
namespace AFPClient4Windows {
    partial class MForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MForm));
            this.tsc = new System.Windows.Forms.ToolStripContainer();
            this.hsc = new System.Windows.Forms.SplitContainer();
            this.vsc = new System.Windows.Forms.SplitContainer();
            this.tvF = new System.Windows.Forms.TreeView();
            this.il16 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lvF = new System.Windows.Forms.ListView();
            this.chfn = new System.Windows.Forms.ColumnHeader();
            this.chcb = new System.Windows.Forms.ColumnHeader();
            this.chmt = new System.Windows.Forms.ColumnHeader();
            this.chi = new System.Windows.Forms.ColumnHeader();
            this.cmsLvF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mDelf = new System.Windows.Forms.ToolStripMenuItem();
            this.mRenf = new System.Windows.Forms.ToolStripMenuItem();
            this.mNewDir = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbELog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbLOG = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bConn = new System.Windows.Forms.ToolStripButton();
            this.bRefreshSel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddForks = new System.Windows.Forms.ToolStripDropDownButton();
            this.bTypData = new System.Windows.Forms.ToolStripMenuItem();
            this.bTypNews = new System.Windows.Forms.ToolStripMenuItem();
            this.bTypMacOSX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbOpts = new System.Windows.Forms.ToolStripDropDownButton();
            this.bNoTimeout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bAbout = new System.Windows.Forms.ToolStripButton();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.hsc.Panel1.SuspendLayout();
            this.hsc.Panel2.SuspendLayout();
            this.hsc.SuspendLayout();
            this.vsc.Panel1.SuspendLayout();
            this.vsc.Panel2.SuspendLayout();
            this.vsc.SuspendLayout();
            this.cmsLvF.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.hsc);
            resources.ApplyResources(this.tsc.ContentPanel, "tsc.ContentPanel");
            resources.ApplyResources(this.tsc, "tsc");
            this.tsc.Name = "tsc";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // hsc
            // 
            resources.ApplyResources(this.hsc, "hsc");
            this.hsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.hsc.Name = "hsc";
            // 
            // hsc.Panel1
            // 
            this.hsc.Panel1.Controls.Add(this.vsc);
            // 
            // hsc.Panel2
            // 
            this.hsc.Panel2.Controls.Add(this.tabControl1);
            // 
            // vsc
            // 
            resources.ApplyResources(this.vsc, "vsc");
            this.vsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.vsc.Name = "vsc";
            // 
            // vsc.Panel1
            // 
            this.vsc.Panel1.Controls.Add(this.tvF);
            this.vsc.Panel1.Controls.Add(this.label1);
            // 
            // vsc.Panel2
            // 
            this.vsc.Panel2.Controls.Add(this.lvF);
            this.vsc.Panel2.Controls.Add(this.label2);
            // 
            // tvF
            // 
            this.tvF.AllowDrop = true;
            this.tvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tvF, "tvF");
            this.tvF.ImageList = this.il16;
            this.tvF.Name = "tvF";
            this.tvF.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvF_DragDrop);
            this.tvF.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvF_AfterSelect);
            this.tvF.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvF_DragEnter);
            this.tvF.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvF_ItemDrag);
            this.tvF.DragOver += new System.Windows.Forms.DragEventHandler(this.tvF_DragOver);
            // 
            // il16
            // 
            this.il16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il16.ImageStream")));
            this.il16.TransparentColor = System.Drawing.Color.Transparent;
            this.il16.Images.SetKeyName(0, "0");
            this.il16.Images.SetKeyName(1, "PC");
            this.il16.Images.SetKeyName(2, "Vol");
            this.il16.Images.SetKeyName(3, "Dir");
            this.il16.Images.SetKeyName(4, "File");
            this.il16.Images.SetKeyName(5, "VolOpen");
            this.il16.Images.SetKeyName(6, "DirOpen");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lvF
            // 
            this.lvF.AllowDrop = true;
            this.lvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfn,
            this.chcb,
            this.chmt,
            this.chi});
            this.lvF.ContextMenuStrip = this.cmsLvF;
            resources.ApplyResources(this.lvF, "lvF");
            this.lvF.FullRowSelect = true;
            this.lvF.GridLines = true;
            this.lvF.Name = "lvF";
            this.lvF.SmallImageList = this.il16;
            this.lvF.UseCompatibleStateImageBehavior = false;
            this.lvF.View = System.Windows.Forms.View.Details;
            this.lvF.ItemActivate += new System.EventHandler(this.lvF_ItemActivate);
            this.lvF.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvF_DragDrop);
            this.lvF.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvF_ColumnClick);
            this.lvF.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvF_DragEnter);
            this.lvF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvF_KeyDown);
            this.lvF.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvF_ItemDrag);
            this.lvF.DragOver += new System.Windows.Forms.DragEventHandler(this.lvF_DragOver);
            // 
            // chfn
            // 
            resources.ApplyResources(this.chfn, "chfn");
            // 
            // chcb
            // 
            resources.ApplyResources(this.chcb, "chcb");
            // 
            // chmt
            // 
            resources.ApplyResources(this.chmt, "chmt");
            // 
            // chi
            // 
            resources.ApplyResources(this.chi, "chi");
            // 
            // cmsLvF
            // 
            this.cmsLvF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDelf,
            this.mRenf,
            this.mNewDir});
            this.cmsLvF.Name = "cmsLvF";
            resources.ApplyResources(this.cmsLvF, "cmsLvF");
            // 
            // mDelf
            // 
            this.mDelf.Image = global::AFPClient4Windows.Properties.Resources.DeleteHS;
            this.mDelf.Name = "mDelf";
            resources.ApplyResources(this.mDelf, "mDelf");
            this.mDelf.Click += new System.EventHandler(this.mDelf_Click);
            // 
            // mRenf
            // 
            this.mRenf.Name = "mRenf";
            resources.ApplyResources(this.mRenf, "mRenf");
            this.mRenf.Click += new System.EventHandler(this.mRenf_Click);
            // 
            // mNewDir
            // 
            this.mNewDir.Name = "mNewDir";
            resources.ApplyResources(this.mNewDir, "mNewDir");
            this.mNewDir.Click += new System.EventHandler(this.mNewDir_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbELog);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbELog
            // 
            resources.ApplyResources(this.tbELog, "tbELog");
            this.tbELog.Name = "tbELog";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbLOG);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbLOG
            // 
            resources.ApplyResources(this.tbLOG, "tbLOG");
            this.tbLOG.Name = "tbLOG";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bConn,
            this.bRefreshSel,
            this.toolStripSeparator1,
            this.tsddForks,
            this.tsddbOpts,
            this.toolStripSeparator2,
            this.bAbout});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // bConn
            // 
            this.bConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            resources.ApplyResources(this.bConn, "bConn");
            this.bConn.Name = "bConn";
            this.bConn.Click += new System.EventHandler(this.bConn_Click);
            // 
            // bRefreshSel
            // 
            this.bRefreshSel.Image = global::AFPClient4Windows.Properties.Resources.RefreshDocViewHS;
            resources.ApplyResources(this.bRefreshSel, "bRefreshSel");
            this.bRefreshSel.Name = "bRefreshSel";
            this.bRefreshSel.Click += new System.EventHandler(this.bRefreshSel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsddForks
            // 
            this.tsddForks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bTypData,
            this.bTypNews,
            this.bTypMacOSX});
            resources.ApplyResources(this.tsddForks, "tsddForks");
            this.tsddForks.Name = "tsddForks";
            // 
            // bTypData
            // 
            this.bTypData.Name = "bTypData";
            resources.ApplyResources(this.bTypData, "bTypData");
            this.bTypData.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // bTypNews
            // 
            this.bTypNews.Name = "bTypNews";
            resources.ApplyResources(this.bTypNews, "bTypNews");
            this.bTypNews.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // bTypMacOSX
            // 
            this.bTypMacOSX.Name = "bTypMacOSX";
            resources.ApplyResources(this.bTypMacOSX, "bTypMacOSX");
            this.bTypMacOSX.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // tsddbOpts
            // 
            this.tsddbOpts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNoTimeout});
            resources.ApplyResources(this.tsddbOpts, "tsddbOpts");
            this.tsddbOpts.Name = "tsddbOpts";
            // 
            // bNoTimeout
            // 
            this.bNoTimeout.Name = "bNoTimeout";
            resources.ApplyResources(this.bNoTimeout, "bNoTimeout");
            this.bNoTimeout.Click += new System.EventHandler(this.bNoTimeout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // bAbout
            // 
            this.bAbout.Image = global::AFPClient4Windows.Properties.Resources.Help;
            resources.ApplyResources(this.bAbout, "bAbout");
            this.bAbout.Name = "bAbout";
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // MForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsc);
            this.Name = "MForm";
            this.Load += new System.EventHandler(this.MForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MForm_FormClosing);
            this.tsc.ContentPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.PerformLayout();
            this.tsc.ResumeLayout(false);
            this.tsc.PerformLayout();
            this.hsc.Panel1.ResumeLayout(false);
            this.hsc.Panel2.ResumeLayout(false);
            this.hsc.ResumeLayout(false);
            this.vsc.Panel1.ResumeLayout(false);
            this.vsc.Panel1.PerformLayout();
            this.vsc.Panel2.ResumeLayout(false);
            this.vsc.Panel2.PerformLayout();
            this.vsc.ResumeLayout(false);
            this.cmsLvF.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.SplitContainer vsc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvF;
        private System.Windows.Forms.ListView lvF;
        private System.Windows.Forms.ImageList il16;
        private System.Windows.Forms.ColumnHeader chfn;
        private System.Windows.Forms.ColumnHeader chcb;
        private System.Windows.Forms.ColumnHeader chmt;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bConn;
        private System.Windows.Forms.ToolStripButton bRefreshSel;
        private System.Windows.Forms.SplitContainer hsc;
        private System.Windows.Forms.TextBox tbLOG;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsddForks;
        private System.Windows.Forms.ToolStripMenuItem bTypData;
        private System.Windows.Forms.ToolStripMenuItem bTypNews;
        private System.Windows.Forms.ToolStripMenuItem bTypMacOSX;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bAbout;
        private System.Windows.Forms.ColumnHeader chi;
        private System.Windows.Forms.ContextMenuStrip cmsLvF;
        private System.Windows.Forms.ToolStripMenuItem mDelf;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbELog;
        private System.Windows.Forms.ToolStripDropDownButton tsddbOpts;
        private System.Windows.Forms.ToolStripMenuItem mRenf;
        private System.Windows.Forms.ToolStripMenuItem mNewDir;
        private System.Windows.Forms.ToolStripMenuItem bNoTimeout;
    }
}

