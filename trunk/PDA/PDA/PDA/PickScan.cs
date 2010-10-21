using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class PickScan : Form
    {
        public PickScan()
        {
            InitializeComponent();
        }

        public PickScan(DataSet ds)
        {
            InitializeComponent();
        }


        void pd_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        public void init(DataSet ds)
        {
           
        }

        private void txt_PickBill_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            PickDetail pd = new PickDetail();
            pd.Show();
            pd.Closed += new EventHandler(pd_Closed);
            this.Hide();
        }
    }
}