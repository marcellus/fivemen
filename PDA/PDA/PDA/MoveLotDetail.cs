using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PDA
{
    public partial class MoveLotDetail : Form
    {
        private MoveLot ml;
        public MoveLotDetail(DataSet ds)
        {
            InitializeComponent();
            try
            {
                ml = new MoveLot(ds);
                ml.onScanFinish += new MoveLot.ScanFinish(ml_onScanFinish);
                this.txt_NewLot.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ml_onScanFinish(object sender, EventArgs e)
        {
            MessageBox.Show(ml.CurrentDisk.BillNo + "已完成扫描！");
        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ml.ScanedDiskCount >= 100)
                {
                    MessageBox.Show("已扫料盘数达到100个，请及时保存数据！");
                    return;
                }
                this.txt_Detail.Text = string.Empty;
                this.txt_Detail.ForeColor = Color.Black;
                Types.ScanInfo i = ml.DiskScan(this.txt_Disk.Text.ToUpper().Trim(), this.cb_RollBack.Checked);
                string msg = Types.ScanInfoMessage(i, cb_RollBack.Checked);
                if (msg != string.Empty)
                {
                    this.txt_Detail.Text = msg;
                    this.txt_Detail.ForeColor = Color.Red;
                    this.txt_Disk.Text = string.Empty;
                }
                else
                {
                    Types.ScanInfo i_lot = ml.LotScan(this.txt_NewLot.Text.ToUpper().Trim());
                    string msg_lot = Types.ScanInfoMessage(i_lot);
                    if (msg_lot != string.Empty)
                    {
                        this.txt_Detail.Text = msg_lot;
                        this.txt_Detail.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.txt_Detail.Text = "移储单：" + ml.CurrentDisk.BillNo + "\r\n";
                        this.txt_Detail.Text += "物料：" + ml.CurrentDisk.Sku.Id + "\r\n";
                        this.txt_Detail.Text += "供应商：" + ml.CurrentDisk.Sku.Company + "\r\n";
                        this.txt_Detail.Text += "新批次号：" + ml.CurrentDisk.Sku.NewLot + "\r\n";
                        txt_Detail.Text += "实际扫描批次号：" + this.txt_NewLot.Text.ToUpper() + "\r\n";
                        txt_Detail.Text += "此物料需扫描数量：" + ml.CurrentDisk.Sku.Count.ToString() + "\r\n";
                        txt_Detail.Text += "此物料已扫描数量：" + ml.CurrentDisk.Sku.ScanCount.ToString() + "\r\n";
                    }
                    this.txt_Disk.Text = string.Empty;
                    this.txt_Disk.Focus();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDisk = ml.UpdateDiskDataTable();
                DataTable dtSKU = ml.UpdateSKUDataTable();
                if (new DB().SaveMoveLotData(dtDisk))
                {
                    MessageBox.Show("保存成功");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.txt_NewLot.Text = string.Empty;
            this.txt_NewLot.Focus();
        }

        private void txt_NewLot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Disk.Focus();
            }
        }
    }
}