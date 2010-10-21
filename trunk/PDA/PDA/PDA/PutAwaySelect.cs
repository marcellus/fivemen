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
    public partial class PutAwaySelect : Form
    {
        public PutAwaySelect()
        {
            InitializeComponent();
        }

        private void btn_ReadTempFile_Click(object sender, EventArgs e)
        {
            string TempFileUrl = PutAway.TempFileUrl;
            if (File.Exists(TempFileUrl))
            {
                DataSet ds = MySerialization.DeSerialize(TempFileUrl);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("数据为空，请扫描新入库单！");
                }
                else
                {
                    PutAwayScan pas = new PutAwayScan(ds);
                    pas.Show();
                    pas.Closed += new EventHandler(pas_Closed);
                    this.Hide();
                }
            }
        }

        void pas_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ScanNewPutAway_Click(object sender, EventArgs e)
        {
            PutAwayScan pas = new PutAwayScan();
            pas.Show();
            pas.Closed += new EventHandler(pas_Closed);
            this.Hide();
        }
    }
}