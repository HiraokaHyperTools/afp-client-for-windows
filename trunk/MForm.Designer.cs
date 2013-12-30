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
            this.label2 = new System.Windows.Forms.Label();
            this.tbLOG = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bConn = new System.Windows.Forms.ToolStripButton();
            this.bRefreshSel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddForks = new System.Windows.Forms.ToolStripDropDownButton();
            this.bTypData = new System.Windows.Forms.ToolStripMenuItem();
            this.bTypNews = new System.Windows.Forms.ToolStripMenuItem();
            this.bTypMacOSX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.hsc.Panel1.SuspendLayout();
            this.hsc.Panel2.SuspendLayout();
            this.hsc.SuspendLayout();
            this.vsc.Panel1.SuspendLayout();
            this.vsc.Panel2.SuspendLayout();
            this.vsc.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.hsc);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(796, 433);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(796, 458);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // hsc
            // 
            this.hsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.hsc.Location = new System.Drawing.Point(0, 0);
            this.hsc.Name = "hsc";
            this.hsc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // hsc.Panel1
            // 
            this.hsc.Panel1.Controls.Add(this.vsc);
            // 
            // hsc.Panel2
            // 
            this.hsc.Panel2.Controls.Add(this.tbLOG);
            this.hsc.Size = new System.Drawing.Size(796, 433);
            this.hsc.SplitterDistance = 313;
            this.hsc.SplitterWidth = 6;
            this.hsc.TabIndex = 1;
            // 
            // vsc
            // 
            this.vsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.vsc.Location = new System.Drawing.Point(0, 0);
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
            this.vsc.Size = new System.Drawing.Size(796, 313);
            this.vsc.SplitterDistance = 251;
            this.vsc.SplitterWidth = 6;
            this.vsc.TabIndex = 0;
            // 
            // tvF
            // 
            this.tvF.AllowDrop = true;
            this.tvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvF.ImageIndex = 0;
            this.tvF.ImageList = this.il16;
            this.tvF.Location = new System.Drawing.Point(0, 12);
            this.tvF.Name = "tvF";
            this.tvF.SelectedImageIndex = 0;
            this.tvF.Size = new System.Drawing.Size(251, 301);
            this.tvF.TabIndex = 1;
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "フォルダ一覧：";
            // 
            // lvF
            // 
            this.lvF.AllowDrop = true;
            this.lvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfn,
            this.chcb,
            this.chmt});
            this.lvF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvF.FullRowSelect = true;
            this.lvF.GridLines = true;
            this.lvF.Location = new System.Drawing.Point(0, 12);
            this.lvF.Name = "lvF";
            this.lvF.Size = new System.Drawing.Size(539, 301);
            this.lvF.SmallImageList = this.il16;
            this.lvF.TabIndex = 2;
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
            this.chfn.Text = "ファイル名";
            this.chfn.Width = 200;
            // 
            // chcb
            // 
            this.chcb.Text = "サイズ";
            this.chcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chcb.Width = 80;
            // 
            // chmt
            // 
            this.chmt.Text = "更新日時";
            this.chmt.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "オブジェクト一覧：";
            // 
            // tbLOG
            // 
            this.tbLOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLOG.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbLOG.Location = new System.Drawing.Point(0, 0);
            this.tbLOG.Multiline = true;
            this.tbLOG.Name = "tbLOG";
            this.tbLOG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLOG.Size = new System.Drawing.Size(796, 114);
            this.tbLOG.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bConn,
            this.bRefreshSel,
            this.toolStripSeparator1,
            this.tsddForks});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(294, 25);
            this.toolStrip1.TabIndex = 3;
            // 
            // bConn
            // 
            this.bConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            this.bConn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bConn.Name = "bConn";
            this.bConn.Size = new System.Drawing.Size(93, 22);
            this.bConn.Text = "接続先(&C)...";
            this.bConn.Click += new System.EventHandler(this.bConn_Click);
            // 
            // bRefreshSel
            // 
            this.bRefreshSel.Image = global::AFPClient4Windows.Properties.Resources.RefreshDocViewHS;
            this.bRefreshSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefreshSel.Name = "bRefreshSel";
            this.bRefreshSel.Size = new System.Drawing.Size(69, 22);
            this.bRefreshSel.Text = "更新(&R)";
            this.bRefreshSel.Click += new System.EventHandler(this.bRefreshSel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsddForks
            // 
            this.tsddForks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bTypData,
            this.bTypNews,
            this.bTypMacOSX});
            this.tsddForks.Image = ((System.Drawing.Image)(resources.GetObject("tsddForks.Image")));
            this.tsddForks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddForks.Name = "tsddForks";
            this.tsddForks.Size = new System.Drawing.Size(114, 22);
            this.tsddForks.Text = "フォークの見せ方";
            // 
            // bTypData
            // 
            this.bTypData.Name = "bTypData";
            this.bTypData.Size = new System.Drawing.Size(493, 22);
            this.bTypData.Text = "データフォークのみ";
            this.bTypData.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // bTypNews
            // 
            this.bTypNews.Name = "bTypNews";
            this.bTypNews.Size = new System.Drawing.Size(493, 22);
            this.bTypNews.Text = "(独自方式) FILE に対して FILE.AFP_Resource と FILE.AFP_FinderInfo で表現";
            this.bTypNews.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // bTypMacOSX
            // 
            this.bTypMacOSX.Name = "bTypMacOSX";
            this.bTypMacOSX.Size = new System.Drawing.Size(493, 22);
            this.bTypMacOSX.Text = "(Mac OS X方式) FILE に対して ._FILE で表現";
            this.bTypMacOSX.Click += new System.EventHandler(this.bTypData_Click);
            // 
            // MForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 458);
            this.Controls.Add(this.tsc);
            this.Name = "MForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFPClient4Windows";
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
            this.hsc.Panel2.PerformLayout();
            this.hsc.ResumeLayout(false);
            this.vsc.Panel1.ResumeLayout(false);
            this.vsc.Panel1.PerformLayout();
            this.vsc.Panel2.ResumeLayout(false);
            this.vsc.Panel2.PerformLayout();
            this.vsc.ResumeLayout(false);
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
    }
}

