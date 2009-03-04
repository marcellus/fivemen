using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Reflection;
using FT.DAL.Orm;
using FT.Commons.Com.Excels;
using FT.DAL;
using System.IO;

namespace FT.Windows.Forms
{
    /// <summary>
    /// ��ѯ����ʵ��ؼ�
    /// </summary>
    public partial class DataSearchControl : UserControl,IRefreshParent
    {
        protected Pager pager = new Pager();
        //private 
        public DataSearchControl()
        {
            InitializeComponent();
            this.InitPager();
        }

        /// <summary>
        /// �Ƿ����Ұ�
        /// </summary>
        protected bool isSelfBinding = false;
        /// <summary>
        /// ���������Ҫ���Ұ���Ҫʵ�ָ÷���
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void BindEntity(object entity)
        {

        }

        /// <summary>
        /// ���½������ݰ�
        /// </summary>
        private void ReBinding()
        {
            if (this.isSelfBinding)
            {
                this.dataGridView1.Rows.Clear();
                for (int i = 0; i < pager.Lists.Count; i++)
                {
                    this.BindEntity(pager.Lists[i]);
                }
            }
            else
            {
               // BindingSource bindingSource1 = new BindingSource();
                this.dataGridView1.DataSource = pager.Lists;
            }
            this.lbCurrentPage.Text = pager.CurrentPage.ToString();
            this.lbPages.Text = pager.PageCount.ToString();
            this.lbRecordCount.Text = pager.RecordCount.ToString();
        }

        protected virtual void InitPager()
        {
        }

        #region IRefreshParent ��Ա

        public void Update(object entity)
        {
            Console.WriteLine("success update");
            this.dataGridView1.DataSource = null;
            for (int i = 0; i < pager.Lists.Count; i++)
            {
                if(SimpleOrmOperator.EntityIsEqual(entity,pager.Lists[i]))
                {
                    pager.Lists.RemoveAt(i);
                    pager.Lists.Insert(i,entity);
                    break;
                }
            }
            this.dataGridView1.DataSource = pager.Lists;

            //
           // throw new Exception("The method or operation is not implemented.");
        }

        public void Add(object entity)
        {
            Console.WriteLine("success add");
            this.dataGridView1.DataSource = null;
            pager.Lists.Insert(0, entity);
            this.dataGridView1.DataSource = pager.Lists;

            //
            //throw new Exception("The method or operation is not implemented.");
        }

        public void SetConditions(string conditions)
        {
            pager.Condition = conditions==string.Empty?conditions:" where "+conditions;
            this.ReBinding();
            //pager.Search();
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();

        }

        private Type detailFormType = null;
        /// <summary>
        /// ����������ù����Ĵ���
        /// </summary>
        protected Type DetailFormType
        {
            get { return detailFormType; }
            set { detailFormType = value; }
        }

        private Type entityType = null;

        /// <summary>
        /// ������ʵ�����ͣ������ѯ������
        /// </summary>
        public Type EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        protected virtual void Add()
        {
            if (this.detailFormType != null)
            {
                Form form = CreateDataBrowserForm(null) as Form;
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
            //throw new Exception("�������ʵ����ӵķ���");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBoxHelper.Show("��ѡ����Ҫ�޸ĵļ�¼�У�");

            }
            else
            {
                this.ShowDetail(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        protected virtual void ShowDetail(int index)
        {
            if (this.detailFormType != null&&this.pager!=null)
            {
                Form form = this.CreateDataBrowserForm(pager.Lists[index]);
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
        }

        /// <summary>
        /// ������Ӧʵ��
        /// </summary>
        /// <param name="type">����</param>
        /// <returns>��Ӧʵ��</returns>
        protected Form CreateDataBrowserForm(object entity)
        {
            ConstructorInfo info = this.detailFormType.GetConstructor(new Type[] { typeof(object), typeof(IRefreshParent) });
            Form form=info.Invoke(new object[] {entity,this }) as Form;
            return form;
            //return CreateInstance(type.FullName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count=this.dataGridView1.SelectedRows.Count;
            if (count == 0)
            {
                MessageBoxHelper.Show("��ѡ����Ҫɾ���ļ�¼�У�");

            }
            else
            {
                bool result = MessageBoxHelper.Confirm("ȷ��ɾ����");
                if (result)
                {
                    int tmp = 0;
                    for (int i = count-1; i >=0; i--)
                    {
                        tmp = this.dataGridView1.SelectedRows[i].Index;
                        FT.DAL.Orm.SimpleOrmOperator.Delete(pager.Lists[tmp]);
                        this.dataGridView1.DataSource = null;
                        pager.Lists.RemoveAt(tmp) ;
                        this.dataGridView1.DataSource = pager.Lists;
                    }
                    //this.ReBinding();
                }
                //this.ShowDetail(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.entityType != null)
            {
                ConditionBuildForm form = new ConditionBuildForm(this.entityType, this);
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
            else
            {
                MessageBoxHelper.Show("��ѯ�ؼ�ʵ������Ϊ�գ��޷�����������ѯ��");
            }
            //pager.Search();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            pager.FirstPage();
            this.ReBinding();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            pager.PrePage();
            this.ReBinding();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            pager.NextPage();
            this.ReBinding();

        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            pager.LastPage();
            this.ReBinding();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int goes = 1;
            try
            {
                goes = Convert.ToInt32(this.txtGoPages.Text.Trim());
                if (goes > pager.PageCount)
                {
                    MessageBoxHelper.Show("��תҳ���ܳ�����ҳ����");
                }
                else
                {
                    pager.GoPage(goes);
                    this.ReBinding();
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("��תҳ������������");
                this.txtGoPages.Text = "1";
            }
           
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ShowDetail(e.RowIndex);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string text = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Clipboard.SetText(text);
            }
            catch
            {
            }
        }

        private void DataSearchControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                pager.Search();
                //if()
                this.ReBinding();
            }
        }

        /// <summary>
        ///  �������赼��excel�����Ҫ���������Ҫʵ�ֵ�
        /// </summary>
        /// <returns></returns>
        protected virtual string GetExportField()
        {
            return "*";
        }

        protected virtual string GetExportTitle()
        {
            return "Ĭ�ϵ�Excel����";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select " + this.GetExportField() + " from " +SimpleOrmCache.GetTableName(this.entityType)+pager.Condition,"tmptable");
            if (dt != null && dt.Rows.Count > 0)
            {
                string path = FileDialogHelper.SaveExcel();
                if (path != null && path != string.Empty)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    ListExcel ls = new ListExcel(path, dt);
                    ls.Title=this.GetExportTitle();
                    ls.GetExcelReport();
                    this.Cursor = Cursors.WaitCursor;
                    MessageBoxHelper.Show("�����ɹ���");
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBoxHelper.Show("û���ҵ��ɵ��������ݣ�");
            }
        }
    }
}
