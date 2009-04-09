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
using System.Collections;
using FT.Commons.Cache;

namespace FT.Windows.Forms
{
    /// <summary>
    /// 查询数据实体控件
    /// </summary>
    public partial class DataSearchControl : UserControl, IRefreshParent
    {
        public event ProcessObjectDelegate InitBeforeAdd;
        protected Pager pager = new Pager();

        private bool allowCustomeSearch = true;

        BindingSource bindingSource = new BindingSource();


        /// <summary>
        /// 是否允许自定义查询
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
        /// 是否自我绑定
        /// </summary>
        protected bool isSelfBinding = false;
        /// <summary>
        /// 如果子类需要自我绑定需要实现该方法
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void BindEntity(object entity)
        {

        }

        /// <summary>
        /// 重新进行数据绑定
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

        #region IRefreshParent 成员

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
        /// conditions不带where关键字，可由ConditionBuildForm来生成
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
        /// 子类必须设置关联的窗体
        /// </summary>
        protected Type DetailFormType
        {
            get { return detailFormType; }
            set { detailFormType = value; }
        }

        private Type entityType = null;

        /// <summary>
        /// 关联的实体类型，构造查询条件用
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
            //throw new Exception("子类必须实现添加的方法");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.ShowDetail();
        }

        protected void ShowDetail()
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBoxHelper.Show("请选择需要修改的记录行！");

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
        /// 创建对应实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>对应实例</returns>
        protected Form CreateDataBrowserForm(object entity)
        {
            ConstructorInfo info = this.detailFormType.GetConstructor(new Type[] { typeof(object), typeof(IRefreshParent) });
            Form form = info.Invoke(new object[] { entity, this }) as Form;
            return form;
            //return CreateInstance(type.FullName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        protected virtual void Delete()
        {
            int count = this.dataGridView1.SelectedRows.Count;
            if (count == 0)
            {
                MessageBoxHelper.Show("请选择需要删除的记录行！");

            }
            else
            {
                bool result = MessageBoxHelper.Confirm("确定删除这些记录吗？");
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
                    recordCount -= count;
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
                ConditionBuildForm form = new ConditionBuildForm(this.entityType, this,pager.Condition);
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
            else
            {
                MessageBoxHelper.Show("查询控件实体类型为空，无法进行条件查询！");
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
                    MessageBoxHelper.Show("跳转页不能超出总页数！");
                }
                else
                {
                    pager.GoPage(goes);
                    this.ReBinding();
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("跳转页必须是整数！");
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
        /// 设置Grid的样式
        /// </summary>
        protected  virtual void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            string key=this.entityType.FullName+"-detail-columndefine";
            ArrayList lists;
            if (StaticCacheManager.Get(key) != null)
            {
                lists=StaticCacheManager.Get(key) as ArrayList;
            }
            else
            {
                 
                lists= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FT.Windows.Forms.EntityColumnDefine>
                    (" where bool_showindetail='True' and c_class_full_name='" +
                this.entityType.FullName + "' order by i_order_num");
                StaticCacheManager.Add(key,lists);
            }
           
            EntityColumnDefine column = null;
            for (int i = 0; i < lists.Count-1; i++)
            {
                column = lists[i] as EntityColumnDefine;
                if (column.ShowInDetail)
                {
                    this.CreateColumn(column.PropertyName, column.HeaderName, column.HeaderWidth);
                }
            }
            column = lists[lists.Count-1] as EntityColumnDefine;
            if (column.ShowInDetail)
            {
                this.CreateColumn(column.PropertyName, column.HeaderName);
            }
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
        ///  子类如需导出excel，如果要定义别名需要实现的
        /// </summary>
        /// <returns></returns>
        protected virtual string GetExportField()
        {
            return SimpleOrmCache.GetExportSql(this.entityType);
        }

        protected virtual string GetExportTitle()
        {
            return SimpleOrmCache.GetExportTitle(this.entityType);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select " + this.GetExportField() + " from " + SimpleOrmCache.GetTableName(this.entityType) + pager.Condition, "tmptable");
            this.ExportExcel(dt);
        }

        private void ExportExcel(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string title = this.GetExportTitle(); 
                string path = FileDialogHelper.SaveExcel(title+".xls");
                if (path != null && path != string.Empty)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    ListExcel ls = new ListExcel(path, dt);
                    ls.Title = title;
                    ls.GetExcelReport();
                    this.Cursor = Cursors.WaitCursor;
                    MessageBoxHelper.Show("导出成功！");
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBoxHelper.Show("没有找到可导出的数据！");
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
            //        MessageBoxHelper.Show("未知错误");
            //    }
            //}
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ShowDetail(e.RowIndex);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ExportExcel(this.GetTableFromGrid());
            //FT.Commons.Com.Excels.ExcelHelper.ExportExcel(this.dataGridView1, this.GetExportTitle());
        }

        private DataTable GetTableFromGrid()
        {
            int rows=this.dataGridView1.Rows.Count;
            int cols=this.dataGridView1.Columns.Count;
            if(rows==0)
            {
                return null;
            }
            DataTable dt = new DataTable();

            for (int i = 0; i < cols; i++)
            {
                dt.Columns.Add(this.dataGridView1.Columns[i].HeaderText);
            }
            DataRow dr = null;
            object tmp=null;
            for (int i = 0; i < rows; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                     tmp=dataGridView1.Rows[i].Cells[j].Value;
                     dr[j] = tmp == null ? "" : tmp.ToString();
                    
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ShowDetail();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.Delete();
            }
        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            try
            {
                if (pager.Lists.Count == 0)
                {
                    MessageBoxHelper.Show("没有可打印的数据！");
                }
                else
                {
                    string printfield = this.GetPrintField();
                    int[] widths = this.GetPrintWidths();
                    if (printfield == string.Empty)
                    {
                        MessageBoxHelper.Show("还没有实现打印该列表功能！");
                        return;
                    }
                    else if (widths == null)
                    {
                        MessageBoxHelper.Show("请设定要打印的列宽！");
                        return;
                    }
                    else
                    {
                        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(
                            "select " + this.GetPrintField() + " from " + FT.DAL.Orm.SimpleOrmCache.GetTableName(this.entityType) + " " + pager.Condition, "test");
                        if (dt.Columns.Count >= widths.Length + 1)
                        {
                            DataTablePrinterContent.Print(dt, widths, this.GetExportTitle());
                        }
                        else
                        {
                            MessageBoxHelper.Show("设定打印的列宽+1超出了待打印的列数！");
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowPrinter("错误信息："+ex.Message);
            }
            
            
        }

        /// <summary>
        /// 待打印的列
        /// </summary>
        /// <returns></returns>
        protected virtual string GetPrintField()
        {
            return SimpleOrmCache.GetPrintSql(this.entityType);
        }

        /// <summary>
        /// 待打印的列宽度
        /// </summary>
        /// <returns></returns>
        protected virtual int[] GetPrintWidths()
        {
            return SimpleOrmCache.GetPrintWidths(this.entityType);
        }

        private int[] GetDataGridViewWidth()
        {
            int[] tmp=new int[this.dataGridView1.Columns.Count-1];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = this.dataGridView1.Columns[i].Width;
            }
            return tmp;
        }

        //打印当前页
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count == 0)
                {
                    MessageBoxHelper.Show("没有可打印的数据！");
                }
                else
                {
                    DataTable dt = this.GetTableFromGrid();
                    DataTablePrinterContent.Print(dt, this.GetDataGridViewWidth(), this.GetExportTitle());
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowPrinter("错误信息："+ex.Message);
            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pager.Search();
            this.ReBinding();
            //this.SetConditions(pager.Condition);
        }

        

    }
}
