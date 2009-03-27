using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms;
using System.Collections;

namespace FT.Windows.Forms
{
    public partial class EntityBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public EntityBrowser()
        {
            InitializeComponent();
             this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public EntityBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public EntityBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                //ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                //if (lists.Count > 0)
                //{
                //    //this.cbGroup
                //    this.cbHmhp.DataSource = lists;
                //    this.cbHmhp.DisplayMember = "�������";
                //    this.cbHmhp.ValueMember = "�������";
                //    this.cbHmhp.SelectedIndex = 0;
                //}
                //FT.Windows.CommonsPlugin.Entity.DictManager.BindToCombox(this.cbCarType, "׼�ݳ���");
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new EntityDefine();
            //   return null;
        }
        #endregion

        private void btnGenerateColumnDefine_Click(object sender, EventArgs e)
        {
            string fullname = this.txtClassFullName.Text.Trim();
            object obj=ReflectHelper.CreateInstance(fullname);
            if (obj == null)
            {
                MessageBoxHelper.Show("�����ڸ����ͣ�");
                return;
            }
            Type type = obj.GetType();
            if (type == null)
            {
               
            }
            else
            {
                DataTable dt = FT.DAL.Orm.SimpleOrmCache.GetConditionDT(type);
                if (dt != null)
                {
                    string cn = this.txtClassCnName.Text.Trim();
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_entity_column_define where c_class_full_name='" +
                        FT.DAL.DALSecurityTool.TransferInsertField(fullname)+"'");
                    EntityColumnDefine column = new EntityColumnDefine();
                    int i = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        column.ClassCnName = cn;
                        column.ExportWidth = 50;
                        column.HeaderName = dr["text"].ToString();
                        column.HeaderWidth = 50;
                        column.IsExportExcel = true;
                        column.IsPrinted = true;
                        column.OrderNum=i;
                        column.PrintedWidth = 50;
                        column.PropertyName = column.HeaderName;
                        column.ShowInDetail = true;
                        column.DetailWidth = 50;
                        column.ClassFullName = fullname;
                        FT.DAL.Orm.SimpleOrmOperator.Create(column);
                        //column.s
                        i++;
                    }
                    MessageBox.Show("�����ɹ�,��"+i+"���У�");
                }
            }
        }
    }
}

