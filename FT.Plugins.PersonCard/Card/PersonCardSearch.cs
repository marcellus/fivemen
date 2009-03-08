using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType=typeof(Card);
            this.pager.OrderField = "id";
            //this.pager.PageSize = 3;
           // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "����";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
           // this.dataGridView1.Columns.Add(col1);
            
        }

        //protected override string GetExportField()
        //{
        //    return "id as ���,c_name as ����,c_nickname as �ǳ�,c_sex as �Ա�,c_name as ����,c_nickname as �ǳ�,id as ���,c_name as ����,c_nickname as �ǳ�,id as ���,c_name as ����,c_nickname as �ǳ�";
        //}

        //protected override string GetExportTitle()
        //{
        //    return "��Ƭ��ϸ���";
        //}



        protected override void SettingGridStyle()
        {
            
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����",80);
            this.CreateColumn("�ǳ�", 80);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("��������", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("��ϵ����", 160);
            this.CreateColumn("��������");


            
        }
    }
}

