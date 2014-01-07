using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AFPClient4Windows {
    public partial class WForm : Form {
        public WForm() {
            InitializeComponent();
        }

        internal void SetPos(long pos, long cbIn) {
            lpos.Text = String.Format("{2:0.0}% {0}/{1}", pos, cbIn, (float)pos / cbIn * 100);
            Update();
        }
    }
}