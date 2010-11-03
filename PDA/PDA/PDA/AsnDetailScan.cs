using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDA.DataInit;
using PDA.DbManager;

namespace PDA
{
    public partial class AsnDetailScan : Form
    {
        ASNMain asnMain = new ASNMain();
        ASNDetail asnDetail = new ASNDetail();
        public AsnDetailScan(string receiveno, string factory, string factoryid, string storage, string storageid, string carno, string receivetype, string qufen)
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

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_SN.Text.Length < 20)
                {
                    MessageBox.Show("扫描SN非法，请扫描正确SN！");
                    txt_SN.Text = string.Empty;
                    return;
                }
                this.txt_DiskDetail.Text = string.Empty;
                tabControl1.SelectedIndex = 0;
                asnDetail.Cuno = this.txt_SN.Text;
                if (this.ck_HOLD.Checked)
                {
                    asnDetail.Hold = 1;
                }
                else
                {
                    asnDetail.Hold = 0;
                }
                asnDetail.Xxjh = this.txt_Optional.Text;
                asnDetail.Status = 1;
                
                asnDetail.Scantime = System.DateTime.Now;
                asnDetail.Pnno = this.txt_SN.Text.Substring(2, 10);

                asnMain.Pnno = this.txt_SN.Text.Substring(2, 10);
                
                asnMain.Scantime = System.DateTime.Now;
                asnMain.Sl = 1;

                if (!this.ck_Rollback.Checked)
                {
                    //asnMain.SaveAsnMain(string.Empty);
                    string msg = asnDetail.SaveAsnDetail(string.Empty, "SN", asnMain, asnDetail);
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
                        this.txt_DiskDetail.Text += "SN：" + this.txt_SN.Text + "\r\n";
                        if (this.txt_Optional.Text != string.Empty)
                        {
                            this.txt_DiskDetail.Text += "下乡机号：" + this.txt_Optional.Text;
                        }
                    }
                }
                else
                {
                    try
                    {
                        string msg = asnDetail.SaveAsnDetail("RollBack", "SN", asnMain, asnDetail);
                        if (msg != string.Empty)
                        {
                            MessageBox.Show(msg);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                ClearInput();
                ck_Rollback.Checked = false;
            }
        }

        private void txt_Optional_KeyUp(object sender, KeyEventArgs e)
        {
            txt_SN.Focus();
        }

        
        private void ck_Optional_CheckStateChanged(object sender, EventArgs e)
        {
            txt_Optional.Enabled = ck_Optional.Checked;
            this.txt_Optional.Focus();
            if (txt_Optional.Enabled) txt_Optional.Focus();
            else txt_Optional.Text = string.Empty;
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            this.txt_SN.Focus();
        }
        private void ClearInput()
        {
            this.txt_SN.Text = string.Empty;
            this.txt_Optional.Text = string.Empty;
            this.txt_TrayNo.Text = string.Empty;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                string sql = string.Format(@"select pnno as 产品号,cuno as SN,tno as 托盘号 from receivedetail where receiveno='{0}' and scaner='{1}'", asnMain.Receiveno, Program.UserID);
                this.dg_Resume.DataSource = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
                new DB().SetDataGridCloumnWidth(dg_Resume);
            }
            if (this.tabControl1.SelectedIndex == 2)
            {
                string sql = string.Format(@"select receiveno as 收货单号,pnno as 产品,sl as 数量 from receiverecord where receiveno='{0}'", asnMain.Receiveno);

                this.dg_Summarizing.DataSource = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
                new DB().SetDataGridCloumnWidth(dg_Summarizing);
            }
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_DiskDetail.Text = string.Empty;
                tabControl1.SelectedIndex = 0;
                asnDetail.Tno = this.txt_TrayNo.Text;
                if (this.cK_HOLDTray.Checked)
                {
                    asnDetail.Hold = 1;
                }
                else
                {
                    asnDetail.Hold = 0;
                }

                asnDetail.Status = 1;
                //asnDetail.Scanner = Program.UserID;
                asnDetail.Scantime = System.DateTime.Now;
                asnDetail.Pnno = string.Empty;// this.txt_TrayNo.Text.Substring(2, 10);

                //asnMain.Pnno = this.txt_SN.Text.Substring(2, 10);
                //asnMain.Scanner = Program.UserID;
                asnMain.Scantime = System.DateTime.Now;
                asnMain.Sl = 1;//这个地方需要加数量提取处理

                if (!this.ck_RollbackTray.Checked)
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
                else
                {
                    string msg = asnDetail.SaveAsnDetail("RollBack", "Tray", asnMain, asnDetail);
                    if (msg != string.Empty)
                    {
                        MessageBox.Show(msg);
                    }
                }
                ClearInput();
                ck_RollbackTray.Checked = false;
            }
        }

        private void ck_RollbackTray_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            txt_TrayNo.Focus();
        }

        private void cK_HOLDTray_KeyUp(object sender, KeyEventArgs e)
        {
            txt_TrayNo.Focus();
        }
    }
}