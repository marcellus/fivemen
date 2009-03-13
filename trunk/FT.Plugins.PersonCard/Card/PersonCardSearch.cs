using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    public partial class PersonCardSearch : FT.Windows.Forms.DataSearchControl
    {
        public PersonCardSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Card);
            this.DetailFormType=typeof(PersonCardBrowser);
        }
        #region 子类必须继承
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType=typeof(Card);
            this.pager.OrderField = "id";
            //this.pager.PageSize = 3;
           // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "姓名";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
           // this.dataGridView1.Columns.Add(col1);
            
        }

        //protected override string GetExportField()
        //{
        //    return "id as 编号,c_name as 姓名,c_nickname as 昵称,c_sex as 性别,c_name as 姓名,c_nickname as 昵称,id as 编号,c_name as 姓名,c_nickname as 昵称,id as 编号,c_name as 姓名,c_nickname as 昵称";
        //}

        //protected override string GetExportTitle()
        //{
        //    return "名片详细情况";
        //}



        protected override void SettingGridStyle()
        {
            
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("姓名",80);
            this.CreateColumn("昵称", 80);
            this.CreateColumn("性别", 80);
            this.CreateColumn("出生年月", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("固话", 80);
            this.CreateColumn("手机", 80);
            this.CreateColumn("联系邮箱", 160);
            this.CreateColumn("分组名称");



        }
        #endregion

        protected override string GetPrintField()
        {
            return @"c_name as 姓名,c_nickname as 昵称,c_sex as 性别,
            c_birthday as  出生年月,c_phone as 固话,
c_mobile as 手机,c_email as 联系邮箱,c_group as 分组名称";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 100,100,60,120,120,120,100 };
            //return base.GetPrintWidths();
        }

    }
}

