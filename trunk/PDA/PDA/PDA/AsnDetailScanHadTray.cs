using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDA.DataInit;

namespace PDA
{
    public partial class AsnDetailScanHadTray : Form
    {
        ASNMain asnMain = new ASNMain();
         ASNDetail asnDetail = new ASNDetail();
        public AsnDetailScanHadTray(string receiveno, string factory, string factoryid, string storage, string storageid, string carno, string receivetype, string qufen)
        {
            InitializeComponent();
            asnMain.Receiveno = receiveno;
            asnMain.Factory = factory;
            asnMain.Factoryid = factoryid;
            asnMain.Storage = storage;
            asnMain.Storageid = storageid;
            asnMain.Carno = carno;
            asnMain.Receivetype = receivetype;
            asnMain.Qufen = qufen;
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedIndex = 0;
                asnDetail.Tno = this.txt_TrayNo.Text;
                if (this.ck_HOLD.Checked)
                {
                    asnDetail.Hold = 1;
                }
                else
                {
                    asnDetail.Hold = 0;
                }
               
                asnDetail.Status = 1;
                asnDetail.Scanner = Program.UserID;
                asnDetail.Scantime = System.DateTime.Now;
                asnDetail.Pnno = this.txt_TrayNo.Text.Substring(2, 10);

                //asnMain.Pnno = this.txt_SN.Text.Substring(2, 10);
                asnMain.Scanner = Program.UserID;
                asnMain.Scantime = System.DateTime.Now;
                asnMain.Sl = 1;//这个地方需要加数量提取处理

                if (!this.ck_Rollback.Checked)
                {
                    //asnMain.SaveAsnMain(string.Empty);
                    string msg = asnDetail.SaveAsnDetail(string.Empty, "Tray", asnMain, asnDetail);
                    if (msg != string.Empty)
                    {
                        MessageBox.Show(msg);
                    }
                    else
                    {
                        //asnMain.SaveAsnMain(string.Empty);
                        this.txt_DiskDetail.Text += "收货单：" + asnMain.Receiveno + "\r\n";
                        this.txt_DiskDetail.Text += "工厂：" + asnMain.Factory + "\r\n";
                        this.txt_DiskDetail.Text += "仓库：" + asnMain.Storage + "\r\n";
                        this.txt_DiskDetail.Text += "车牌：" + asnMain.Carno + "\r\n";
                        this.txt_DiskDetail.Text += "托盘号：" + this.txt_TrayNo.Text + "\r\n";
                    }
                }
            }
        }

        
        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_TrayNo.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                string sql = string.Format(@"select pnno,sl,receiveno,factory,storage from receiverecord where receiveno='{0}' and scaner='{1}'", asnMain.Receiveno, asnMain.Scanner);
                this.dg_Resume.DataSource = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
            }
            else
            {
                string sql = string.Format(@"select pnno,tno,cuno from receivedetail where receiveno='{0}' and scaner='{1}'", asnMain.Receiveno, asnMain.Scanner);
                this.dg_Summarizing.DataSource = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
            }
        }
    }
}