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
            this.EntityType = typeof(CarInfo);
            this.DetailFormType = typeof(CarBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarInfo);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("车主姓名", 80);
            this.CreateColumn("车辆品牌", 80);
            this.CreateColumn("号码号牌", 80);
            this.CreateColumn("车辆类型", 80);
            this.CreateColumn("车辆状态", 80);
            this.CreateColumn("车保险日期", 100);
            this.CreateColumn("年检时间", 100);
            this.CreateColumn("转入时间", 100);
            this.CreateColumn("路费购买日期", 130);
            this.CreateColumn("合同签订时间", 130);
            this.CreateColumn("是否教练车");
            this.CreateColumn("是否考试车");

        }
    }
}

