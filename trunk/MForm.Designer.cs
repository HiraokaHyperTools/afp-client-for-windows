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
            this.vsc = new System.Windows.Forms.SplitContainer();
            this.tvF = new System.Windows.Forms.TreeView();
            this.il16 = new System.Windows.Forms.ImageList(this.components);
            this.ils = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lvF = new System.Windows.Forms.ListView();
            this.chfn = new System.Windows.Forms.ColumnHeader();
            this.chcbData = new System.Windows.Forms.ColumnHeader();
            this.chcbRes = new System.Windows.Forms.ColumnHeader();
            this.chmt = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpErr = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lErr1 = new System.Windows.Forms.Label();
            this.lErrDetail = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mConn = new System.Windows.Forms.ToolStripMenuItem();
            this.mRefreshSel = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpts = new System.Windows.Forms.ToolStripMenuItem();
            this.mGetResFork = new System.Windows.Forms.ToolStripMenuItem();
            this.mPutResFork = new System.Windows.Forms.ToolStripMenuItem();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.vsc.Panel1.SuspendLayout();
            this.vsc.Panel2.SuspendLayout();
            this.vsc.SuspendLayout();
            this.tlpErr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.vsc);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(796, 434);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(796, 458);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.menuStrip1);
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
            this.vsc.Panel2.Controls.Add(this.tlpErr);
            this.vsc.Size = new System.Drawing.Size(796, 434);
            this.vsc.SplitterDistance = 251;
            this.vsc.SplitterWidth = 6;
            this.vsc.TabIndex = 0;
            // 
            // tvF
            // 
            this.tvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvF.ImageIndex = 0;
            this.tvF.ImageList = this.il16;
            this.tvF.Location = new System.Drawing.Point(0, 12);
            this.tvF.Name = "tvF";
            this.tvF.SelectedImageIndex = 0;
            this.tvF.Size = new System.Drawing.Size(251, 422);
            this.tvF.StateImageList = this.ils;
            this.tvF.TabIndex = 1;
            this.tvF.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvF_AfterSelect);
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
            // ils
            // 
            this.ils.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ils.ImageStream")));
            this.ils.TransparentColor = System.Drawing.Color.Transparent;
            this.ils.Images.SetKeyName(0, "OK");
            this.ils.Images.SetKeyName(1, "E");
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
            this.lvF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfn,
            this.chcbData,
            this.chcbRes,
            this.chmt});
            this.lvF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvF.FullRowSelect = true;
            this.lvF.GridLines = true;
            this.lvF.Location = new System.Drawing.Point(0, 90);
            this.lvF.Name = "lvF";
            this.lvF.Size = new System.Drawing.Size(539, 344);
            this.lvF.SmallImageList = this.il16;
            this.lvF.TabIndex = 2;
            this.lvF.UseCompatibleStateImageBehavior = false;
            this.lvF.View = System.Windows.Forms.View.Details;
            this.lvF.ItemActivate += new System.EventHandler(this.lvF_ItemActivate);
            this.lvF.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvF_ColumnClick);
            this.lvF.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvF_ItemDrag);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "オブジェクト一覧：";
            // 
            // tlpErr
            // 
            this.tlpErr.AutoSize = true;
            this.tlpErr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpErr.ColumnCount = 2;
            this.tlpErr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpErr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpErr.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpErr.Controls.Add(this.label3, 1, 0);
            this.tlpErr.Controls.Add(this.lErr1, 0, 1);
            this.tlpErr.Controls.Add(this.lErrDetail, 0, 2);
            this.tlpErr.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpErr.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tlpErr.Location = new System.Drawing.Point(0, 0);
            this.tlpErr.Name = "tlpErr";
            this.tlpErr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.tlpErr.RowCount = 3;
            this.tlpErr.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpErr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpErr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpErr.Size = new System.Drawing.Size(539, 78);
            this.tlpErr.TabIndex = 3;
            this.tlpErr.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::AFPClient4Windows.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "失敗しました：";
            // 
            // lErr1
            // 
            this.lErr1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lErr1.AutoSize = true;
            this.tlpErr.SetColumnSpan(this.lErr1, 2);
            this.lErr1.Location = new System.Drawing.Point(3, 42);
            this.lErr1.Name = "lErr1";
            this.lErr1.Size = new System.Drawing.Size(26, 12);
            this.lErr1.TabIndex = 3;
            this.lErr1.Text = "...";
            // 
            // lErrDetail
            // 
            this.lErrDetail.AutoSize = true;
            this.tlpErr.SetColumnSpan(this.lErrDetail, 2);
            this.lErrDetail.Location = new System.Drawing.Point(3, 58);
            this.lErrDetail.Name = "lErrDetail";
            this.lErrDetail.Size = new System.Drawing.Size(66, 12);
            this.lErrDetail.TabIndex = 4;
            this.lErrDetail.TabStop = true;
            this.lErrDetail.Text = "(詳細...)";
            this.lErrDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lErrDetail_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mConn,
            this.mRefreshSel,
            this.mOpts});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
            this.menuStrip1.TabIndex = 2;
            // 
            // mConn
            // 
            this.mConn.Image = global::AFPClient4Windows.Properties.Resources.DialHS;
            this.mConn.Name = "mConn";
            this.mConn.Size = new System.Drawing.Size(92, 20);
            this.mConn.Text = "接続する(&C)";
            this.mConn.Click += new System.EventHandler(this.mConn_Click);
            // 
            // mRefreshSel
            // 
            this.mRefreshSel.Image = global::AFPClient4Windows.Properties.Resources.RefreshDocViewHS;
            this.mRefreshSel.Name = "mRefreshSel";
            this.mRefreshSel.Size = new System.Drawing.Size(141, 20);
            this.mRefreshSel.Text = "選択フォルダを更新(&R)";
            this.mRefreshSel.Click += new System.EventHandler(this.mRefreshSel_Click);
            // 
            // mOpts
            // 
            this.mOpts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mGetResFork,
            this.mPutResFork});
            this.mOpts.Image = global::AFPClient4Windows.Properties.Resources.PlayHS;
            this.mOpts.Name = "mOpts";
            this.mOpts.Size = new System.Drawing.Size(76, 20);
            this.mOpts.Text = "オプション";
            // 
            // mGetResFork
            // 
            this.mGetResFork.Checked = true;
            this.mGetResFork.CheckOnClick = true;
            this.mGetResFork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mGetResFork.Name = "mGetResFork";
            this.mGetResFork.Size = new System.Drawing.Size(464, 22);
            this.mGetResFork.Text = "リソースフォークDL：拡張子resource-forkを付けてリソースフォークをダウンロードする";
            // 
            // mPutResFork
            // 
            this.mPutResFork.Checked = true;
            this.mPutResFork.CheckOnClick = true;
            this.mPutResFork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mPutResFork.Name = "mPutResFork";
            this.mPutResFork.Size = new System.Drawing.Size(464, 22);
            this.mPutResFork.Text = "リソースフォークUP：拡張子resource-forkをリソースフォークと見なしてアップロードする";
            this.mPutResFork.Visible = false;
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
            this.vsc.Panel1.ResumeLayout(false);
            this.vsc.Panel1.PerformLayout();
            this.vsc.Panel2.ResumeLayout(false);
            this.vsc.Panel2.PerformLayout();
            this.vsc.ResumeLayout(false);
            this.tlpErr.ResumeLayout(false);
            this.tlpErr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.SplitContainer vsc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvF;
        private System.Windows.Forms.ListView lvF;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mConn;
        private System.Windows.Forms.ImageList il16;
        private System.Windows.Forms.ColumnHeader chfn;
        private System.Windows.Forms.ColumnHeader chcbData;
        private System.Windows.Forms.ColumnHeader chmt;
        private System.Windows.Forms.ImageList ils;
        private System.Windows.Forms.TableLayoutPanel tlpErr;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lErr1;
        private System.Windows.Forms.LinkLabel lErrDetail;
        private System.Windows.Forms.ToolStripMenuItem mRefreshSel;
        private System.Windows.Forms.ColumnHeader chcbRes;
        private System.Windows.Forms.ToolStripMenuItem mOpts;
        private System.Windows.Forms.ToolStripMenuItem mGetResFork;
        private System.Windows.Forms.ToolStripMenuItem mPutResFork;
    }
}

