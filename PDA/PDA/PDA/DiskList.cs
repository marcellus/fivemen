using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class DiskList : Form
    {
        public DiskList(DataSet ds)
        {
            InitializeComponent();
            this.dg_Disk.DataSource = ds.Tables[0];
        }

        public DiskList()
        {
            InitializeComponent();
        }
    }
}