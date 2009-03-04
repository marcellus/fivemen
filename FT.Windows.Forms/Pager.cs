using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using FT.DAL.Orm;
using System.Windows.Forms;

namespace FT.Windows.Forms
{
    public class Pager
    {

        private Type entityType;

        /// <summary>
        /// ʵ������
        /// </summary>
        public Type EntityType
        {
            get { return entityType; }
            set { entityType = value;
            }
        }

        

        /// <summary>
        /// Ĭ�ϵķ�ҳ��С
        /// </summary>
        private const int Page_Default_Size = 20;

        private int pageSize = Page_Default_Size;

        /// <summary>
        /// ��ҳ��С
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
        }

        private int currentPage;

        public int CurrentPage
        {
            get { return currentPage; }
        }

        private int recordCount;

        public int RecordCount
        {
            get { return recordCount; }
        }

        /// <summary>
        /// ��һҳ
        /// </summary>
        public void NextPage()
        {
            if (this.currentPage < this.pageCount)
            {
                this.currentPage += 1;
                this.QueryPageList();
            }
        }
        /// <summary>
        /// ��һҳ
        /// </summary>
        public void PrePage()
        {
            if (this.currentPage > 1)
            {
                this.currentPage -= 1;
                this.QueryPageList();
            }
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        public void FirstPage()
        {
            this.currentPage = 1;
            this.QueryPageList();
        }
        /// <summary>
        /// βҳ
        /// </summary>
        public void LastPage()
        {
            this.currentPage = this.pageCount;
            this.QueryPageList();
        }
        /// <summary>
        /// ��ת���ڼ�ҳ
        /// </summary>
        /// <param name="page"></param>
        public void GoPage(int page)
        {
            if (page <= this.pageCount)
            {
                this.currentPage = page;
                this.QueryPageList();
            }
        }

        private ArrayList lists = new ArrayList();

        /// <summary>
        /// ��ѯ����б�
        /// </summary>
        public ArrayList Lists
        {
            get { return lists; }
            set { lists = value; }
        }

        /// <summary>
        /// ����ִ�в�ѯ
        /// </summary>
        public void Search()
        {
            this.currentPage = 1;
            //this.Lists.Clear();
            this.Count();
            this.QueryPageList();
            
        }

        /// <summary>
        /// ����currentpage��ѯ��ҳ��List
        /// </summary>
        private void QueryPageList()
        {
            this.lists = SimpleOrmOperator.QueryList(this.entityType, this.GetPageSql());
        }

        private string GetPageSql()
        {
            string sql = string.Empty;
            string tableName = SimpleOrmCache.GetTableName(this.entityType);
            if (this.currentPage <= 1)
            {
                #region ��һҳ����
                sql = "select top " + this.pageSize + " * from " + tableName + " " + (condition) + " order by " + this.orderField + " " + ((isAsc) ? "asc" : "desc") + "";
                #endregion
            }
            else if (this.currentPage > 1 && this.currentPage < this.pageCount)
            {

                //if (primary == order)
                    //sql = "select top " + pageSize + " * from " + tableName + " where " + primary + "" + ((isDesc) ? "<" : ">") + "(select " + ((isDesc) ? "min" : "max") + "(" + primary + ") from(select top " + pageSize * (currentPage - 1) + " " + primary + " from " + tableName + " " + ((condition != "") ? "where " + condition + "" : "") + " order by " + order + " " + ((isDesc) ? "desc" : "asc") + " )) " + ((condition != "") ? "and " + condition + "" : "") + " order by " + order + " " + ((isDesc) ? "desc" : "asc") + "";
                //else

                sql = "select top " + pageSize + " * from (select top " + (this.recordCount - (this.currentPage - 1) * pageSize) + " * from " + tableName + " " + (condition) + " order by " + this.orderField + " " + ((isAsc) ? "desc" : "asc") + ") order by " + this.orderField + " " + ((isAsc) ? "asc" : "desc") + "";

            }
            else if (this.currentPage >= this.pageCount)
            {
                #region ���ҳ
                // sql = "select " + this.field + " from (select top " + (this.totalCount - (this.TotalPages() - 1) * this.pageSize) + " " + this.field + " from " + tableName + " " + ((condition != "") ? "where " + condition + "" : "") + " order by " + order + " " + ((isDesc) ? "asc" : "desc") + ") order by " + order + " " + ((isDesc) ? "desc" : "asc") + "";
                sql = "select * from (select top " + (this.recordCount - (this.pageCount - 1) * this.pageSize) + " * " + " from " + tableName + " " + (condition) + " order by " + this.orderField + " " + ((isAsc) ? "desc" : "asc") + ") order by " + this.orderField + " " + ((isAsc) ? "asc" : "desc") + "";
                #endregion



            }
            return sql;
        }

        //private string 

        /// <summary>
        /// �����ṩ�����ݽӿڣ������ӡ�͵���,������excel���ݲ�һ���������ѯ���ֶ�һ�£��÷�������
        /// </summary>
        /// <returns>����Դ</returns>
        public ArrayList GetAllData()
        {
            string sql = "select * from " + SimpleOrmCache.GetTableName(this.entityType) + " " + condition + " order by " + this.orderField + " " + ((IsAsc) ? "asc" : "desc") + "";
           // IDataAccess access = DataAccessFactory.GetDataAccess();
            //DataTable dt = access.SelectDataTable(sql, this.tableName);
            return SimpleOrmOperator.QueryList(this.entityType,sql);
        }

        /// <summary>
        /// �����ܼ�¼������ҳ��
        /// </summary>
        private void Count()
        {
            this.recordCount = SimpleOrmOperator.QueryCounts(this.entityType, this.condition);
            this.pageCount = this.GetPageCount();
        }

        /// <summary>
        /// Totals the pages.
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (recordCount == 0)
            {
                return 1;
            }
            if (recordCount % pageSize > 0)
                return (int)(recordCount / pageSize) + 1;
            else
                return recordCount / pageSize;

        }

        private string condition = string.Empty;

        /// <summary>
        /// ��ѯ����,�����ѯ���������仯����������²�ѯ
        /// </summary>
        public string Condition
        {
            get { return condition; }
            set {
                if (value == condition)
                {
                }
                else
                {

                    condition = value;
                    this.Search();
                }
            
            }
        }

        private string orderField = string.Empty;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string OrderField
        {
            get { return orderField; }
            set { orderField = value; }
        }

        private bool isAsc = false;
        /// <summary>
        /// �Ƿ���������ֶ�����
        /// </summary>
        public bool IsAsc
        {
            get { return isAsc; }
            set { isAsc = value; }
        }
    }
}
