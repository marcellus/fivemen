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
        /// 实体类型
        /// </summary>
        public Type EntityType
        {
            get { return entityType; }
            set { entityType = value;
            }
        }

        

        /// <summary>
        /// 默认的分页大小
        /// </summary>
        private const int Page_Default_Size = 20;

        private int pageSize = Page_Default_Size;

        /// <summary>
        /// 分页大小
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
        /// 下一页
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
        /// 上一页
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
        /// 首页
        /// </summary>
        public void FirstPage()
        {
            this.currentPage = 1;
            this.QueryPageList();
        }
        /// <summary>
        /// 尾页
        /// </summary>
        public void LastPage()
        {
            this.currentPage = this.pageCount;
            this.QueryPageList();
        }
        /// <summary>
        /// 跳转到第几页
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
        /// 查询结果列表
        /// </summary>
        public ArrayList Lists
        {
            get { return lists; }
            set { lists = value; }
        }

        /// <summary>
        /// 重新执行查询
        /// </summary>
        public void Search()
        {
            this.currentPage = 1;
            //this.Lists.Clear();
            this.Count();
            this.QueryPageList();
            
        }

        /// <summary>
        /// 根据currentpage查询分页的List
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
                #region 第一页代码
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
                #region 最后页
                // sql = "select " + this.field + " from (select top " + (this.totalCount - (this.TotalPages() - 1) * this.pageSize) + " " + this.field + " from " + tableName + " " + ((condition != "") ? "where " + condition + "" : "") + " order by " + order + " " + ((isDesc) ? "asc" : "desc") + ") order by " + order + " " + ((isDesc) ? "desc" : "asc") + "";
                sql = "select * from (select top " + (this.recordCount - (this.pageCount - 1) * this.pageSize) + " * " + " from " + tableName + " " + (condition) + " order by " + this.orderField + " " + ((isAsc) ? "desc" : "asc") + ") order by " + this.orderField + " " + ((isAsc) ? "asc" : "desc") + "";
                #endregion



            }
            return sql;
        }

        //private string 

        /// <summary>
        /// 向外提供的数据接口，方便打印和导出,导出的excel数据不一定与这里查询的字段一致，该方法备用
        /// </summary>
        /// <returns>数据源</returns>
        public ArrayList GetAllData()
        {
            string sql = "select * from " + SimpleOrmCache.GetTableName(this.entityType) + " " + condition + " order by " + this.orderField + " " + ((IsAsc) ? "asc" : "desc") + "";
           // IDataAccess access = DataAccessFactory.GetDataAccess();
            //DataTable dt = access.SelectDataTable(sql, this.tableName);
            return SimpleOrmOperator.QueryList(this.entityType,sql);
        }

        /// <summary>
        /// 计算总记录数和总页数
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
        /// 查询条件,如果查询条件发生变化，会造成重新查询
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
        /// 排序字段
        /// </summary>
        public string OrderField
        {
            get { return orderField; }
            set { orderField = value; }
        }

        private bool isAsc = false;
        /// <summary>
        /// 是否根据排序字段升序
        /// </summary>
        public bool IsAsc
        {
            get { return isAsc; }
            set { isAsc = value; }
        }
    }
}
