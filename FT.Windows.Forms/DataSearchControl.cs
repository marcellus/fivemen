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
    public partial class DataSearchControl : UserControl, IRefreshParent
    {
        public event ProcessObjectDelegate InitBeforeAdd;
        protected Pager pager = new Pager();

        private bool allowCustomeSearch = true;

        BindingSource bindingSource = new BindingSource();


        /// <summary>
        /// �Ƿ������Զ����ѯ
        /// </summary>
        public bool AllowCustomeSearch
        {
            get { return allowCustomeSearch; }
            set { allowCustomeSearch = value; }
        }
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
                bindingSource.DataSource = pager.Lists;
                bindingSource.ResetBindings(false);
                //this.dataGridView1.DataSource = pager.Lists;
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
            //Console.WriteLine("success update");
            //this.dataGridView1.DataSource = null;
            for (int i = 0; i < pager.Lists.Count; i++)
            {
                if (SimpleOrmOperator.EntityIsEqual(entity, pager.Lists[i]))
                {
                    pager.Lists.RemoveAt(i);
                    pager.Lists.Insert(i, entity);
                    break;
                }
            }
            bindingSource.ResetBindings(false);            
            //this.dataGridView1.DataSource = pager.Lists;

            //
            // throw new Exception("The method or operation is not implemented.");
        }

        public void Add(object entity)
        {
            //Console.WriteLine("success add");
            //this.dataGridView1.DataSource = null;
            pager.Lists.Insert(0, entity);
            if (pager.Lists.Count > 1)
            {
                bindingSource.ResetBindings(false);
            }
            else
            {
                bindingSource.ResetBindings(true);
            }
            
            //this.dataGridView1.DataSource = pager.Lists;
            //this.dataGridView1.Rows[0].Selected=true;
            int count = Convert.ToInt32(this.lbRecordCount.Text);
            count++;
            this.lbRecordCount.Text = count.ToString();

            //
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// conditions����where�ؼ��֣�����ConditionBuildForm������
        /// </summary>
        /// <param name="conditions"></param>
        public void SetConditions(string conditions)
        {
            pager.Condition = conditions == string.Empty ? conditions : " where " + conditions;
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
                object entity = null;
                if (this.InitBeforeAdd != null)
                {
                    this.InitBeforeAdd(ref entity);
                }
                Form form = CreateDataBrowserForm(entity) as Form;
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
            if (this.detailFormType != null && this.pager != null&&index<pager.Lists.Count)
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
            Form form = info.Invoke(new object[] { entity, this }) as Form;
            return form;
            //return CreateInstance(type.FullName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = this.dataGridView1.SelectedRows.Count;
            if (count == 0)
            {
                MessageBoxHelper.Show("��ѡ����Ҫɾ���ļ�¼�У�");

            }
            else
            {
                bool result = MessageBoxHelper.Confirm("ȷ��ɾ����Щ��¼��");
                if (result)
                {
                    int tmp = 0;
                    //this.dataGridView1.DataSource = null;
                    int[] deletes = new int[count];
                    
                    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                    {
                        if (this.dataGridView1.Rows[i].Selected)
                        {
                            deletes[tmp++] = i;
                        }
                    }
                    for (int i = count - 1; i >= 0; i--)
                    {
                            tmp = deletes[i];
                            if (FT.DAL.Orm.SimpleOrmOperator.Delete(pager.Lists[tmp]))
                            {
                                pager.Lists.RemoveAt(tmp);
                            }

                     }
                    bindingSource.ResetBindings(false);
                    //this.dataGridView1.DataSource = null;
                    //this.dataGridView1.DataSource = pager.Lists;
                    int recordCount = Convert.ToInt32(this.lbRecordCount.Text);
                    recordCount-=count;
                    this.lbRecordCount.Text = recordCount.ToString();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Console.WriteLine("col:" + e.ColumnIndex + "|rows:" + e.RowIndex);
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {


                    object obj = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null)
                    {
                        Clipboard.SetText(obj.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ����Grid����ʽ
        /// </summary>
        protected  virtual void SettingGridStyle()
        {
        }

        public void ClearColumns()
        {
            this.dataGridView1.Columns.Clear();
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop)
        {
            return CreateColumn(prop, prop);
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop, string header)
        {
            DataGridViewTextBoxColumn tmp = new DataGridViewTextBoxColumn();
            tmp.DataPropertyName = prop;
            tmp.HeaderText = header;
            tmp.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(tmp);
            return tmp;
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop, int width)
        {
           return  this.CreateColumn(prop, prop, width);
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop, string header, int width)
        {
            DataGridViewTextBoxColumn tmp = new DataGridViewTextBoxColumn();
            tmp.DataPropertyName = prop;
            tmp.HeaderText = header;
            tmp.Width = width;
            this.dataGridView1.Columns.Add(tmp);
            return tmp;
        }

        private void DataSearchControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SettingGridStyle();
                this.btnSearch.Visible = this.allowCustomeSearch;
                this.dataGridView1.DataSource = bindingSource;
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
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select " + this.GetExportField() + " from " + SimpleOrmCache.GetTableName(this.entityType) + pager.Condition, "tmptable");
            if (dt != null && dt.Rows.Count > 0)
            {
                string path = FileDialogHelper.SaveExcel();
                if (path != null && path != string.Empty)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    ListExcel ls = new ListExcel(path, dt);
                    ls.Title = this.GetExportTitle();
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
       e.RowBounds.Location.Y,
        dataGridView1.RowHeadersWidth - 4,
        e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void txtGoPages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(null, null);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.dataGridView1.Rows.Count > 0)
            //{
            //    try
            //    {
            //        //Console.WriteLine("col:" + e.ColumnIndex + "|rows:" + e.RowIndex);
            //        //if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            //        //{


            //        //    object obj = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //        //    if (obj != null)
            //        //    {
            //        //        Clipboard.SetText(obj.ToString());
            //        //    }
            //        //}
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBoxHelper.Show(ex.Message);
            //    }
            //    catch
            //    {
            //        MessageBoxHelper.Show("δ֪����");
            //    }
            //}
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ShowDetail(e.RowIndex);
        }

    }
}
