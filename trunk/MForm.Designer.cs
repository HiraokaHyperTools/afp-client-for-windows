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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFree = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.statusStrip1.SuspendLayout();
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
            this.tsc.ContentPanel.Controls.Add(this.hsc);
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
            // hsc
            // 
            this.hsc.AccessibleDescription = null;
            this.hsc.AccessibleName = null;
            resources.ApplyResources(this.hsc, "hsc");
            this.hsc.BackgroundImage = null;
            this.hsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.hsc.Font = null;
            this.hsc.Name = "hsc";
            // 
            // hsc.Panel1
            // 
            this.hsc.Panel1.AccessibleDescription = null;
            this.hsc.Panel1.AccessibleName = null;
            resources.ApplyResources(this.hsc.Panel1, "hsc.Panel1");
            this.hsc.Panel1.BackgroundImage = null;
            this.hsc.Panel1.Controls.Add(this.vsc);
            this.hsc.Panel1.Font = null;
            // 
            // hsc.Panel2
            // 
            this.hsc.Panel2.AccessibleDescription = null;
            this.hsc.Panel2.AccessibleName = null;
            resources.ApplyResources(this.hsc.Panel2, "hsc.Panel2");
            this.hsc.Panel2.BackgroundImage = null;
            this.hsc.Panel2.Controls.Add(this.tabControl1);
            this.hsc.Panel2.Font = null;
            // 
            // vsc
            // 
            this.vsc.AccessibleDescription = null;
            this.vsc.AccessibleName = null;
            resources.ApplyResources(this.vsc, "vsc");
            this.vsc.BackgroundImage = null;
            this.vsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.vsc.Font = null;
            this.vsc.Name = "vsc";
            // 
            // vsc.Panel1
            // 
            this.vsc.Panel1.AccessibleDescription = null;
            this.vsc.Panel1.AccessibleName = null;
            resources.ApplyResources(this.vsc.Panel1, "vsc.Panel1");
            this.vsc.Panel1.BackgroundImage = null;
            this.vsc.Panel1.Controls.Add(this.tvF);
            this.vsc.Panel1.Controls.Add(this.label1);
            this.vsc.Panel1.Font = null;
            // 
            // vsc.Panel2
            // 
            this.vsc.Panel2.AccessibleDescription = null;
            this.vsc.Panel2.AccessibleName = null;
            resources.ApplyResources(this.vsc.Panel2, "vsc.Panel2");
            this.vsc.Panel2.BackgroundImage = null;
            this.vsc.Panel2.Controls.Add(this.lvF);
            this.vsc.Panel2.Controls.Add(this.label2);
            this.vsc.Panel2.Font = null;
            // 
            // tvF
            // 
            this.tvF.AccessibleDescription = null;
            this.tvF.AccessibleName = null;
            this.tvF.AllowDrop = true;
            resources.ApplyResources(this.tvF, "tvF");
            this.tvF.BackgroundImage = null;
            this.tvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvF.Font = null;
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
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // lvF
            // 
            this.lvF.AccessibleDescription = null;
            this.lvF.AccessibleName = null;
            resources.ApplyResources(this.lvF, "lvF");
            this.lvF.AllowDrop = true;
            this.lvF.BackgroundImage = null;
            this.lvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfn,
            this.chcb,
            this.chmt,
            this.chi});
            this.lvF.ContextMenuStrip = this.cmsLvF;
            this.lvF.Font = null;
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
            this.cmsLvF.AccessibleDescription = null;
            this.cmsLvF.AccessibleName = null;
            resources.ApplyResources(this.cmsLvF, "cmsLvF");
            this.cmsLvF.BackgroundImage = null;
            this.cmsLvF.Font = null;
            this.cmsLvF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDelf,
            this.mRenf,
            this.mNewDir});
            this.cmsLvF.Name = "cmsLvF";
            // 
            // mDelf
            // 
            this.mDelf.AccessibleDescription = null;
            this.mDelf.AccessibleName = null;
            resources.ApplyResources(this.mDelf, "mDelf");
            this.mDelf.BackgroundImage = null;
            this.mDelf.Image = global::AFPClient4Windows.Properties.Resources.DeleteHS;
            this.mDelf.Name = "mDelf";
            this.mDelf.Click += new System.EventHandler(this.mDelf_Click);
            // 
            // mRenf
            // 
            this.mRenf.AccessibleDescription = null;
            this.mRenf.AccessibleName = null;
            resources.ApplyResources(this.mRenf, "mRenf");
            this.mRenf.BackgroundImage = null;
            this.mRenf.Name = "mRenf";
            this.mRenf.Click += new System.EventHandler(this.mRenf_Click);
            // 
            // mNewDir
            // 
            this.mNewDir.AccessibleDescription = null;
            this.mNewDir.AccessibleName = null;
            resources.ApplyResources(this.mNewDir, "mNewDir");
            this.mNewDir.BackgroundImage = null;
            this.mNewDir.Name = "mNewDir";
            this.mNewDir.Click += new System.EventHandler(this.mNewDir_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleDescription = null;
            this.tabControl1.AccessibleName = null;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.BackgroundImage = null;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleDescription = null;
            this.tabPage1.AccessibleName = null;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackgroundImage = null;
            this.tabPage1.Controls.Add(this.tbELog);
            this.tabPage1.Font = null;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbELog
            // 
            this.tbELog.AccessibleDescription = null;
            this.tbELog.AccessibleName = null;
            resources.ApplyResources(this.tbELog, "tbELog");
            this.tbELog.BackgroundImage = null;
            this.tbELog.Font = null;
            this.tbELog.Name = "tbELog";
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleDescription = null;
            this.tabPage2.AccessibleName = null;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackgroundImage = null;
            this.tabPage2.Controls.Add(this.tbLOG);
            this.tabPage2.Font = null;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbLOG
            // 
            this.tbLOG.AccessibleDescription = null;
            this.tbLOG.AccessibleName = null;
            resources.ApplyResources(this.tbLOG, "tbLOG");
            this.tbLOG.BackgroundImage = null;
            this.tbLOG.Name = "tbLOG";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleDescription = null;
            this.toolStrip1.AccessibleName = null;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.Font = null;
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
            this.bConn.AccessibleDescription = null;
            this.bConn.AccessibleName = null;
            resources.ApplyResources(this.bConn, "bConn");
            this.bConn.BackgroundImage = null;
            this.bConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            this.bConn.Name = "bConn";
            this.bConn.Click += new System.EventHandler(this.bConn_Click);
            // 
            // bRefreshSel
            // 
            this.bRefreshSel.AccessibleDescription = null;
            this.bRefreshSel.AccessibleName = null;
            resources.ApplyResources(this.bRefreshSel, "bRefreshSel");
            this.bRefreshSel.BackgroundImage = null;
            this.bRefreshSel.Image = global::AFPClient4Windows.Properties.Resources.RefreshDocViewHS;
            this.bRefreshSel.Name = "bRefreshSel";
            this.bRefreshSel.Click += new System.EventHandler(this.bRefreshSel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // tsddForks
            // 
            this.tsddForks.AccessibleDescription = null;
            this.tsddForks.AccessibleName = null;
            resources.ApplyResources(this.tsddForks, "tsddForks");
            this.tsddForks.BackgroundImage = null;
            this.tsddForks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bTypData,
            this.bTypNews,
            this.bTypMacOSX});
            this.tsddForks.Name = "tsddForks";
            // 
            // bTypData
            // 
            this.bTypData.AccessibleDescription = null;
            this.bTypData.AccessibleName = null;
            resources.ApplyResources(this.bTypData, "bTypData");
            this.bTypData.BackgroundImage = null;
            this.bTypData.Name = "bTypData";
            this.bTypData.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // bTypNews
            // 
            this.bTypNews.AccessibleDescription = null;
            this.bTypNews.AccessibleName = null;
            resources.ApplyResources(this.bTypNews, "bTypNews");
            this.bTypNews.BackgroundImage = null;
            this.bTypNews.Name = "bTypNews";
            this.bTypNews.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // bTypMacOSX
            // 
            this.bTypMacOSX.AccessibleDescription = null;
            this.bTypMacOSX.AccessibleName = null;
            resources.ApplyResources(this.bTypMacOSX, "bTypMacOSX");
            this.bTypMacOSX.BackgroundImage = null;
            this.bTypMacOSX.Name = "bTypMacOSX";
            this.bTypMacOSX.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // tsddbOpts
            // 
            this.tsddbOpts.AccessibleDescription = null;
            this.tsddbOpts.AccessibleName = null;
            resources.ApplyResources(this.tsddbOpts, "tsddbOpts");
            this.tsddbOpts.BackgroundImage = null;
            this.tsddbOpts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNoTimeout});
            this.tsddbOpts.Name = "tsddbOpts";
            // 
            // bNoTimeout
            // 
            this.bNoTimeout.AccessibleDescription = null;
            this.bNoTimeout.AccessibleName = null;
            resources.ApplyResources(this.bNoTimeout, "bNoTimeout");
            this.bNoTimeout.BackgroundImage = null;
            this.bNoTimeout.Name = "bNoTimeout";
            this.bNoTimeout.ShortcutKeyDisplayString = null;
            this.bNoTimeout.Click += new System.EventHandler(this.bNoTimeout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // bAbout
            // 
            this.bAbout.AccessibleDescription = null;
            this.bAbout.AccessibleName = null;
            resources.ApplyResources(this.bAbout, "bAbout");
            this.bAbout.BackgroundImage = null;
            this.bAbout.Image = global::AFPClient4Windows.Properties.Resources.Help;
            this.bAbout.Name = "bAbout";
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.Font = null;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslFree,
            this.toolStripStatusLabel2,
            this.tsslTotal});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleDescription = null;
            this.toolStripStatusLabel1.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.BackgroundImage = null;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // tsslFree
            // 
            this.tsslFree.AccessibleDescription = null;
            this.tsslFree.AccessibleName = null;
            resources.ApplyResources(this.tsslFree, "tsslFree");
            this.tsslFree.BackgroundImage = null;
            this.tsslFree.Name = "tsslFree";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AccessibleDescription = null;
            this.toolStripStatusLabel2.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.BackgroundImage = null;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // tsslTotal
            // 
            this.tsslTotal.AccessibleDescription = null;
            this.tsslTotal.AccessibleName = null;
            resources.ApplyResources(this.tsslTotal, "tsslTotal");
            this.tsslTotal.BackgroundImage = null;
            this.tsslTotal.Name = "tsslTotal";
            // 
            // MForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tsc);
            this.Controls.Add(this.statusStrip1);
            this.Font = null;
            this.Icon = null;
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslFree;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
    }
}

