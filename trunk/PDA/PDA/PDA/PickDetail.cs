using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using PDA.DbManager;

namespace PDA
{
    public partial class PickDetail : Form
    {
        private SendRecord record;
        public PickDetail()
        {
            InitializeComponent();

        }
        public PickDetail(SendRecord record)
        {
            this.record = record;
            InitializeComponent();

        }

        private void txt_XiaXiangJi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //clearInput();
                txt_SN.Focus();
            }
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            clearInput();
            txt_SN.Focus();
        }

        private void cb_XiaXiangJi_CheckStateChanged(object sender, EventArgs e)
        {
            txt_XiaXiangJi.Enabled = cb_XiaXiangJi.Checked;
            if (txt_XiaXiangJi.Enabled) txt_XiaXiangJi.Focus();
            else txt_XiaXiangJi.Text = string.Empty;
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txt_SN.Text.Length < 12)
                {
                    MessageBox.Show("SN长度太小！");
                    return;
                }
                this.tabControl1.SelectedIndex = 0;
                this.ShowDiskDetail();

                if (!this.cb_Rollback.Checked)
                {
                    this.SaveData();
                    //this.RebindData();
                }
                else
                {
                    this.RemoveData();
                    //this.RebindData();
                }
                clearInput();

            }

        }
        private void clearInput()
        {
            txt_XiaXiangJi.Text = string.Empty;
            txt_SN.Text = string.Empty;
        }

        private void ShowDiskDetail()
        {
            this.txt_DiskDetail.Text = "发货单：" + record.So + "\r\n";
            this.txt_DiskDetail.Text += "其他发货单：" + record.OtherSo + "\r\n";
            this.txt_DiskDetail.Text += "车牌：" + record.CarNo + "\r\n";
            this.txt_DiskDetail.Text += "区分：" + record.QuFen + "\r\n";
            if (this.cb_XiaXiangJi.Checked)
            {
                this.txt_DiskDetail.Text += "下乡机：" + this.txt_XiaXiangJi.Text.Trim() + "\r\n";
            }
            this.txt_DiskDetail.Text += "SN：" + this.txt_SN.Text.Trim();

        }

        private void RebindData()
        {


        }

        private SendDetail ComputeData()
        {

            SendDetail entity = new SendDetail();
            entity.Sn = this.txt_SN.Text.Trim();
            entity.Tph = string.Empty;
            entity.Xxjh = this.txt_XiaXiangJi.Text.Trim();
            entity.FahuoType = 0;
            entity.So = record.So;
            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }

        private void RemoveData()
        {
            SendDetailManager.Delete(this.ComputeData(), this.record);
        }

        private void SaveData()
        {
            SendDetail entity = this.ComputeData();
            if (SendDetailManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该产品！");
            }
            else
            {
                SendDetailManager.Save(entity, this.record);
            }


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {

                this.dg_Resume.DataSource = SendDetailManager.GetUserData(record.So, Program.UserID);
                new DB().SetDataGridCloumnWidth(this.dg_Resume);
            }
            else if (this.tabControl1.SelectedIndex == 2)
            {

                this.dg_Summarizing.DataSource = SendRecordManager.Count(record.So);
                new DB().SetDataGridCloumnWidth(this.dg_Summarizing);
            }

        }
    }
}