using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDA.DbManager;
using PDA.DataInit;


namespace PDA
{
    public partial class PickScan : Form
    {
        private bool hadTray;
        public PickScan(bool hadTray)
        {
            InitializeComponent();
            init(hadTray);
        }

        public PickScan(DataSet ds)
        {
            InitializeComponent();
        }

        private void init(bool hadTray)
        {
            this.hadTray = hadTray;
        }

        void pd_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        public void init(DataSet ds)
        {
           
        }

        private void txt_SO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_MoreSO.Enabled)
                {
                    txt_MoreSO.Focus();
                }
                else
                {
                    txt_CarNo.Focus();
                }
            }
        }

        private void txt_CarNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_Different.Enabled)
            {
                txt_Different.Focus();
            }
            else
            {

            }
        }

        private SendRecord current;
        private void btn_OK_Click(object sender, EventArgs e)
        {
            Form pd;
            this.SaveData();
            if (hadTray)
            {
                pd = new PickDetailHadTray(this.current);
            }
            else
            {
                pd = new PickDetail(this.current);
            }
            pd.Show();
            pd.Closed += new EventHandler(pd_Closed);
            this.Hide();
        }

        private void ck_MoreSO_CheckStateChanged(object sender, EventArgs e)
        {
            txt_MoreSO.Enabled = ck_MoreSO.Checked;
            if (txt_MoreSO.Enabled) txt_MoreSO.Focus();
            else txt_MoreSO.Text = string.Empty;
        }

        private void ck_Different_CheckStateChanged(object sender, EventArgs e)
        {
            txt_Different.Enabled = ck_Different.Checked;
            if (txt_Different.Enabled) txt_Different.Focus();
            else txt_Different.Text = string.Empty;
        }


        private SendRecord ComputeData()
        {

            SendRecord entity = new SendRecord();
            entity.So = this.txt_SO.Text.Trim();
            entity.OtherSo = this.txt_MoreSO.Text.Trim();
            entity.CarNo = this.txt_CarNo.Text.Trim();
            entity.QuFen = this.txt_Different.Text.Trim();
            entity.Status = 0;
            entity.CpQuFen = string.Empty;
            entity.PnNo = string.Empty;
            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }


        private void SaveData()
        {
            SendRecord entity = this.ComputeData();
            this.current = entity;
            /*if (SendRecordManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该产品！");
            }
            else
            {
                SendRecordManager.Save(entity);
                DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql("select max(id) from sendrecord");
                entity.Id = int.Parse(dt.Rows[0][0].ToString());
                this.current = entity;
            }
           */

        }



        
    }
}