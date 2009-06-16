using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CarSearch : FT.Windows.Forms.DataSearchControl
    {
        public CarSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(CarInfo);
            this.DetailFormType = typeof(CarBrowser);
        }

        private void AddSearch()
        {
            this.toolStrip1.Items.Add("号码号牌");
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();
            
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "输入号码号牌按回车查询";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_hmhp like '" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarInfo);
            this.pager.OrderField = "id";
        }
/*
        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("车主姓名", 80);
            this.CreateColumn("车辆品牌", 80);
            this.CreateColumn("号码号牌", 80);
            this.CreateColumn("车辆类型", 80);
            this.CreateColumn("车辆状态", 80);
            this.CreateColumn("车保险日期", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("年检时间", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("转入时间", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("路费购买日期", 130).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("合同签订时间", 130).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("是否教练车");
            this.CreateColumn("是否考试车");
        }*/
    }
}

