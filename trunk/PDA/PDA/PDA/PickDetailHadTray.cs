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
    public partial class PickDetailHadTray : Form
    {
        private SendRecord record;
        public PickDetailHadTray()
        {
            InitializeComponent();
           
        }
        public PickDetailHadTray(SendRecord record)
        {
            this.record = record;
            InitializeComponent();

        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            txt_TrayNo.Text = string.Empty;
            txt_TrayNo.Focus();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                //TODO:逻辑处理
                this.ShowDiskDetail();
                    if (!this.cb_Rollback.Checked)
                    {
                        this.SaveData();
                        this.RebindData();
                    }
                    else
                    {
                        this.RemoveData();
                        this.RebindData();
                    }

            }
        }

        private void ShowDiskDetail()
        {
            this.txt_DiskDetail.Text = "发货单：" + record.So + "\r\n";
            this.txt_DiskDetail.Text += "其他发货单：" + record.OtherSo + "\r\n";
            this.txt_DiskDetail.Text += "车牌：" + record.CarNo + "\r\n";
            this.txt_DiskDetail.Text += "区分：" + record.QuFen + "\r\n";
            this.txt_DiskDetail.Text += "托盘号：" + this.txt_TrayNo.Text.Trim();

        }

        private void RebindData()
        {
            this.dg_Resume.DataSource = SendDetailManager.GetUserData(record.Id, Program.UserID);
        }

        private SendDetail ComputeData()
        {

            SendDetail entity = new SendDetail();
            entity.Sn = string.Empty;
            entity.Tph = this.txt_TrayNo.Text.Trim();
            entity.Xxjh = string.Empty;
            entity.FahuoType = 1;
            entity.Pid = record.Id;
            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }

        private void RemoveData()
        {
            SendDetailManager.Delete(this.ComputeData());
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
                SendDetailManager.Save(entity);
            }

        }


    }
}