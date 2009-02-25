using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL
{
    /// <summary>
    /// 分页对象
    /// </summary>
    public class Pager
    {
        #region 基本属性
        public const int DefaultPageSize=20;
        private int pageSize = DefaultPageSize;

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int currentPage=1;

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }
      
        private int totalPages = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get { return totalPages; }
            set { totalPages = value; }
        }
        private int totalRecord = 0;

        /// <summary>
        /// 总记录数，分页时候用
        /// </summary>
        public int TotalRecord
        {
            get { return totalRecord; }
            set { totalRecord = value; }
        }
        #endregion

        #region 构造函数
        public Pager(int totalrecord)
        {
            this.InitPager(totalrecord);
        }
        public Pager(int totalrecord,int pagesize)
        {
            this.pageSize = pagesize;
            this.InitPager(totalrecord);
        }

        private void InitPager(int totalrecord)
        {
            this.totalRecord = totalrecord;
            if (totalrecord == 0)
            {
                this.totalPages= 1;
            }
            if (totalrecord % pageSize > 0)
                this.totalPages= (int)(totalrecord / pageSize) + 1;
            else
                this.totalPages = totalrecord / pageSize;
        }
        #endregion

        #region 附加属性
        public bool HasNext
        {
            get
            {
               return this.currentPage  < this.totalPages;
            }
        }

        public bool HasPreview
        {
            get
            {
                return this.currentPage >1;
            }
        }

        public bool IsFirst
        {
            get
            {
                return this.currentPage == 1;
            }
        }

        public bool IsLast
        {
            get
            {
                return this.currentPage == this.totalPages;
            }
        }
        #endregion

    }
}
