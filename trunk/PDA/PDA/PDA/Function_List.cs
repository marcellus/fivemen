using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace PDA
{
    public partial class Function_List : Form
    {
        public Function_List(ArrayList al)
        {
            InitializeComponent();
        }

        void this_Closed(object sender, EventArgs e)
        {
            //this.Close();
            this.Show();
        }

        private void btn_PingtuoHadTray_Click(object sender, EventArgs e)
        {
            PinTuoDetailHadTray ptdh = new PinTuoDetailHadTray();
            OpenForm(ptdh);
        }

        private void btn_Pingtuo_Click(object sender, EventArgs e)
        {
            PinTuoDetail ptd = new PinTuoDetail();
            OpenForm(ptd);
        }

        private void btn_JieTuo_Click(object sender, EventArgs e)
        {
            JieTuoDetail jt = new JieTuoDetail();
            OpenForm(jt);
        }

        private void btn_ZuTuo_Click(object sender, EventArgs e)
        {
            ZuTuoDetail zt = new ZuTuoDetail();
            OpenForm(zt);
        }

        private void btn_CheckHadTray_Click(object sender, EventArgs e)
        {
            CheckDetailHadTray cdh = new CheckDetailHadTray();
            OpenForm(cdh);
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            CheckDetail cd = new CheckDetail();
            OpenForm(cd);
        }

        private void btn_MoveLocHadTray_Click(object sender, EventArgs e)
        {
            MoveLocDetailHadTray mldh = new MoveLocDetailHadTray();
            OpenForm(mldh);
        }

        private void btn_MoveLoc_Click(object sender, EventArgs e)
        {
            MoveLocDetail mld = new MoveLocDetail();
            OpenForm(mld);
        }

        private void btn_PickHadTray_Click(object sender, EventArgs e)
        {
            PickScan ps = new PickScan(true);
            OpenForm(ps);
        }
        private void btn_Pick_Click(object sender, EventArgs e)
        {
            PickScan ps = new PickScan(false);
            OpenForm(ps);
        }

        private void btn_ASNHadTray_Click(object sender, EventArgs e)
        {
            ASNScan asns = new ASNScan(true);
            OpenForm(asns);
        }

        private void btn_ASN_Click(object sender, EventArgs e)
        {
            ASNScan asns = new ASNScan(false);
            OpenForm(asns);
        }

        private void OpenForm(Form f)
        {
            f.Show();
            f.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

    }
}