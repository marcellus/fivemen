using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PDA
{
    public partial class PickSelect : Form
    {
        public PickSelect()
        {
            InitializeComponent();
        }

        private void btn_ScanNewPick_Click(object sender, EventArgs e)
        {
            PickScan ps = new PickScan();
            ps.Show();
            ps.Closed += new EventHandler(ps_Closed);
            this.Hide();
        }

        void ps_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ReadTempFile_Click(object sender, EventArgs e)
        {
            string TempFileUrl = Pick.TempFileUrl;
            if (File.Exists(TempFileUrl))
            {
                DataSet ds = MySerialization.DeSerialize(Pick.TempFileUrl);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("数据为空，请选择扫描新拣货单功能！");
                }
                else
                {
                    PickScan ps = new PickScan(ds);
                    ps.Show();
                    ps.Closed += new EventHandler(ps_Closed);
                    this.Hide();
                }
            }
        }        
    }
}