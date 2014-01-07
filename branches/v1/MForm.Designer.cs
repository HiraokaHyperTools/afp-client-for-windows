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
            this.scf = new System.Windows.Forms.SplitContainer();
            this.lvLoc = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.il16 = new System.Windows.Forms.ImageList(this.components);
            this.tlpLoc = new System.Windows.Forms.TableLayoutPanel();
            this.bUpLoc = new System.Windows.Forms.Button();
            this.bGoLoc = new System.Windows.Forms.Button();
            this.cbDirLoc = new System.Windows.Forms.ComboBox();
            this.lvRem = new System.Windows.Forms.ListView();
            this.chfn = new System.Windows.Forms.ColumnHeader();
            this.chcbData = new System.Windows.Forms.ColumnHeader();
            this.chcbRes = new System.Windows.Forms.ColumnHeader();
            this.chmt = new System.Windows.Forms.ColumnHeader();
            this.tlpRem = new System.Windows.Forms.TableLayoutPanel();
            this.bVolRem = new System.Windows.Forms.Button();
            this.bPCRem = new System.Windows.Forms.Button();
            this.bUpRem = new System.Windows.Forms.Button();
            this.cbDirRem = new System.Windows.Forms.ComboBox();
            this.bGoRem = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mConn = new System.Windows.Forms.ToolStripMenuItem();
            this.mDiscon = new System.Windows.Forms.ToolStripMenuItem();
            this.mDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ils = new System.Windows.Forms.ImageList(this.components);
            this.cmsVols = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timerTickle = new System.Windows.Forms.Timer(this.components);
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.scf.Panel1.SuspendLayout();
            this.scf.Panel2.SuspendLayout();
            this.scf.SuspendLayout();
            this.tlpLoc.SuspendLayout();
            this.tlpRem.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.scf);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(809, 493);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(809, 519);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // scf
            // 
            this.scf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scf.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scf.Location = new System.Drawing.Point(0, 0);
            this.scf.Name = "scf";
            // 
            // scf.Panel1
            // 
            this.scf.Panel1.Controls.Add(this.lvLoc);
            this.scf.Panel1.Controls.Add(this.tlpLoc);
            // 
            // scf.Panel2
            // 
            this.scf.Panel2.Controls.Add(this.lvRem);
            this.scf.Panel2.Controls.Add(this.tlpRem);
            this.scf.Size = new System.Drawing.Size(809, 493);
            this.scf.SplitterDistance = 425;
            this.scf.SplitterWidth = 6;
            this.scf.TabIndex = 1;
            // 
            // lvLoc
            // 
            this.lvLoc.AllowDrop = true;
            this.lvLoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLoc.FullRowSelect = true;
            this.lvLoc.GridLines = true;
            this.lvLoc.Location = new System.Drawing.Point(0, 28);
            this.lvLoc.Name = "lvLoc";
            this.lvLoc.Size = new System.Drawing.Size(425, 465);
            this.lvLoc.SmallImageList = this.il16;
            this.lvLoc.TabIndex = 3;
            this.lvLoc.UseCompatibleStateImageBehavior = false;
            this.lvLoc.View = System.Windows.Forms.View.Details;
            this.lvLoc.ItemActivate += new System.EventHandler(this.lvLoc_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ファイル名";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DataFork";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ResFork";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "更新日時";
            this.columnHeader4.Width = 120;
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
            // tlpLoc
            // 
            this.tlpLoc.AutoSize = true;
            this.tlpLoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpLoc.ColumnCount = 3;
            this.tlpLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLoc.Controls.Add(this.bUpLoc, 0, 0);
            this.tlpLoc.Controls.Add(this.bGoLoc, 1, 0);
            this.tlpLoc.Controls.Add(this.cbDirLoc, 2, 0);
            this.tlpLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpLoc.Location = new System.Drawing.Point(0, 0);
            this.tlpLoc.Name = "tlpLoc";
            this.tlpLoc.RowCount = 1;
            this.tlpLoc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLoc.Size = new System.Drawing.Size(425, 28);
            this.tlpLoc.TabIndex = 1;
            // 
            // bUpLoc
            // 
            this.bUpLoc.AutoSize = true;
            this.bUpLoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bUpLoc.Location = new System.Drawing.Point(3, 3);
            this.bUpLoc.Name = "bUpLoc";
            this.bUpLoc.Size = new System.Drawing.Size(37, 22);
            this.bUpLoc.TabIndex = 0;
            this.bUpLoc.Text = "上へ";
            this.bUpLoc.UseVisualStyleBackColor = true;
            this.bUpLoc.Click += new System.EventHandler(this.bUpLoc_Click);
            // 
            // bGoLoc
            // 
            this.bGoLoc.AutoSize = true;
            this.bGoLoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bGoLoc.Location = new System.Drawing.Point(46, 3);
            this.bGoLoc.Name = "bGoLoc";
            this.bGoLoc.Size = new System.Drawing.Size(39, 22);
            this.bGoLoc.TabIndex = 1;
            this.bGoLoc.Text = "移動";
            this.bGoLoc.UseVisualStyleBackColor = true;
            this.bGoLoc.Click += new System.EventHandler(this.bGoLoc_Click);
            // 
            // cbDirLoc
            // 
            this.cbDirLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDirLoc.FormattingEnabled = true;
            this.cbDirLoc.Location = new System.Drawing.Point(91, 3);
            this.cbDirLoc.Name = "cbDirLoc";
            this.cbDirLoc.Size = new System.Drawing.Size(331, 20);
            this.cbDirLoc.TabIndex = 2;
            // 
            // lvRem
            // 
            this.lvRem.AllowDrop = true;
            this.lvRem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfn,
            this.chcbData,
            this.chcbRes,
            this.chmt});
            this.lvRem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRem.FullRowSelect = true;
            this.lvRem.GridLines = true;
            this.lvRem.Location = new System.Drawing.Point(0, 28);
            this.lvRem.Name = "lvRem";
            this.lvRem.Size = new System.Drawing.Size(378, 465);
            this.lvRem.SmallImageList = this.il16;
            this.lvRem.TabIndex = 2;
            this.lvRem.UseCompatibleStateImageBehavior = false;
            this.lvRem.View = System.Windows.Forms.View.Details;
            this.lvRem.ItemActivate += new System.EventHandler(this.lvRem_ItemActivate);
            this.lvRem.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvRem_ColumnClick);
            // 
            // chfn
            // 
            this.chfn.Text = "ファイル名";
            this.chfn.Width = 200;
            // 
            // chcbData
            // 
            this.chcbData.Text = "DataFork";
            this.chcbData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chcbData.Width = 80;
            // 
            // chcbRes
            // 
            this.chcbRes.Text = "ResFork";
            this.chcbRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chmt
            // 
            this.chmt.Text = "更新日時";
            this.chmt.Width = 120;
            // 
            // tlpRem
            // 
            this.tlpRem.AutoSize = true;
            this.tlpRem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRem.ColumnCount = 5;
            this.tlpRem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRem.Controls.Add(this.bVolRem, 1, 0);
            this.tlpRem.Controls.Add(this.bPCRem, 0, 0);
            this.tlpRem.Controls.Add(this.bUpRem, 2, 0);
            this.tlpRem.Controls.Add(this.cbDirRem, 4, 0);
            this.tlpRem.Controls.Add(this.bGoRem, 3, 0);
            this.tlpRem.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpRem.Location = new System.Drawing.Point(0, 0);
            this.tlpRem.Name = "tlpRem";
            this.tlpRem.RowCount = 1;
            this.tlpRem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRem.Size = new System.Drawing.Size(378, 28);
            this.tlpRem.TabIndex = 0;
            // 
            // bVolRem
            // 
            this.bVolRem.AutoSize = true;
            this.bVolRem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bVolRem.Image = global::AFPClient4Windows.Properties.Resources.DRIVENET;
            this.bVolRem.Location = new System.Drawing.Point(58, 3);
            this.bVolRem.Name = "bVolRem";
            this.bVolRem.Size = new System.Drawing.Size(49, 22);
            this.bVolRem.TabIndex = 5;
            this.bVolRem.Text = "---";
            this.bVolRem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bVolRem.UseVisualStyleBackColor = true;
            this.bVolRem.Click += new System.EventHandler(this.bVolRem_Click);
            // 
            // bPCRem
            // 
            this.bPCRem.AutoSize = true;
            this.bPCRem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bPCRem.Image = global::AFPClient4Windows.Properties.Resources.Computer;
            this.bPCRem.Location = new System.Drawing.Point(3, 3);
            this.bPCRem.Name = "bPCRem";
            this.bPCRem.Size = new System.Drawing.Size(49, 22);
            this.bPCRem.TabIndex = 4;
            this.bPCRem.Text = "---";
            this.bPCRem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bPCRem.UseVisualStyleBackColor = true;
            this.bPCRem.Click += new System.EventHandler(this.bPCRem_Click);
            // 
            // bUpRem
            // 
            this.bUpRem.AutoSize = true;
            this.bUpRem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bUpRem.Location = new System.Drawing.Point(113, 3);
            this.bUpRem.Name = "bUpRem";
            this.bUpRem.Size = new System.Drawing.Size(37, 22);
            this.bUpRem.TabIndex = 0;
            this.bUpRem.Text = "上へ";
            this.bUpRem.UseVisualStyleBackColor = true;
            this.bUpRem.Click += new System.EventHandler(this.bUpRem_Click);
            // 
            // cbDirRem
            // 
            this.cbDirRem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDirRem.FormattingEnabled = true;
            this.cbDirRem.Location = new System.Drawing.Point(201, 3);
            this.cbDirRem.Name = "cbDirRem";
            this.cbDirRem.Size = new System.Drawing.Size(174, 20);
            this.cbDirRem.TabIndex = 2;
            // 
            // bGoRem
            // 
            this.bGoRem.AutoSize = true;
            this.bGoRem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bGoRem.Location = new System.Drawing.Point(156, 3);
            this.bGoRem.Name = "bGoRem";
            this.bGoRem.Size = new System.Drawing.Size(39, 22);
            this.bGoRem.TabIndex = 1;
            this.bGoRem.Text = "移動";
            this.bGoRem.UseVisualStyleBackColor = true;
            this.bGoRem.Click += new System.EventHandler(this.bGoRem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mConn,
            this.mDiscon,
            this.mDown,
            this.mUp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 26);
            this.menuStrip1.TabIndex = 2;
            // 
            // mConn
            // 
            this.mConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            this.mConn.Name = "mConn";
            this.mConn.Size = new System.Drawing.Size(102, 22);
            this.mConn.Text = "接続する(&C)";
            this.mConn.Click += new System.EventHandler(this.mConn_Click);
            // 
            // mDiscon
            // 
            this.mDiscon.Image = global::AFPClient4Windows.Properties.Resources.disconnect2;
            this.mDiscon.Name = "mDiscon";
            this.mDiscon.Size = new System.Drawing.Size(84, 22);
            this.mDiscon.Text = "切断する";
            this.mDiscon.Click += new System.EventHandler(this.mDiscon_Click);
            // 
            // mDown
            // 
            this.mDown.Image = global::AFPClient4Windows.Properties.Resources.DoubleLeftArrowHS;
            this.mDown.Name = "mDown";
            this.mDown.Size = new System.Drawing.Size(108, 22);
            this.mDown.Text = "ダウンロード";
            this.mDown.Click += new System.EventHandler(this.mDown_Click);
            // 
            // mUp
            // 
            this.mUp.Image = global::AFPClient4Windows.Properties.Resources.DoubleRightArrowHS;
            this.mUp.Name = "mUp";
            this.mUp.Size = new System.Drawing.Size(108, 22);
            this.mUp.Text = "アップロード";
            this.mUp.Click += new System.EventHandler(this.mUp_Click);
            // 
            // ils
            // 
            this.ils.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ils.ImageStream")));
            this.ils.TransparentColor = System.Drawing.Color.Transparent;
            this.ils.Images.SetKeyName(0, "OK");
            this.ils.Images.SetKeyName(1, "E");
            // 
            // cmsVols
            // 
            this.cmsVols.Name = "cmsVols";
            this.cmsVols.Size = new System.Drawing.Size(61, 4);
            // 
            // timerTickle
            // 
            this.timerTickle.Enabled = true;
            this.timerTickle.Interval = 30000;
            this.timerTickle.Tick += new System.EventHandler(this.timerTickle_Tick);
            // 
            // MForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 519);
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
            this.scf.Panel1.ResumeLayout(false);
            this.scf.Panel1.PerformLayout();
            this.scf.Panel2.ResumeLayout(false);
            this.scf.Panel2.PerformLayout();
            this.scf.ResumeLayout(false);
            this.tlpLoc.ResumeLayout(false);
            this.tlpLoc.PerformLayout();
            this.tlpRem.ResumeLayout(false);
            this.tlpRem.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.ListView lvRem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mConn;
        private System.Windows.Forms.ImageList il16;
        private System.Windows.Forms.ColumnHeader chfn;
        private System.Windows.Forms.ColumnHeader chcbData;
        private System.Windows.Forms.ColumnHeader chmt;
        private System.Windows.Forms.ImageList ils;
        private System.Windows.Forms.ColumnHeader chcbRes;
        private System.Windows.Forms.SplitContainer scf;
        private System.Windows.Forms.TableLayoutPanel tlpRem;
        private System.Windows.Forms.Button bUpRem;
        private System.Windows.Forms.Button bGoRem;
        private System.Windows.Forms.ComboBox cbDirRem;
        private System.Windows.Forms.TableLayoutPanel tlpLoc;
        private System.Windows.Forms.Button bUpLoc;
        private System.Windows.Forms.Button bGoLoc;
        private System.Windows.Forms.ComboBox cbDirLoc;
        private System.Windows.Forms.ListView lvLoc;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button bVolRem;
        private System.Windows.Forms.Button bPCRem;
        private System.Windows.Forms.ContextMenuStrip cmsVols;
        private System.Windows.Forms.ToolStripMenuItem mDiscon;
        private System.Windows.Forms.ToolStripMenuItem mUp;
        private System.Windows.Forms.ToolStripMenuItem mDown;
        private System.Windows.Forms.Timer timerTickle;
    }
}

