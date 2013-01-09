/********************************************************************************
* File:AccessDataHelper.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using FT.DAL;

namespace FT.DAL.Access
{

    /// <summary>
    /// AccessDataHelper 的摘要说明
    /// </summary>
    public class AccessDataHelper:DataAccessHelper
    {
        private const string ConnStringFormatter = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id={1};Password={2};";
        public AccessDataHelper(String str)
            : base(str)
        {
        }

        public AccessDataHelper()
            : base()
        {
        }
        
        public AccessDataHelper(string path, string uid, string pwd)
            : base(string.Format(ConnStringFormatter, new string[] { path, uid, pwd }))
        {
        }


        /// <summary>
        /// 根据连接字符串connString 创建一个DbConnection
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns>创建一个DbConnection</returns>
        public override IDbConnection CreateConn(string connString)
        {
            return new OleDbConnection(connString);
        }

        /// <summary>
        /// 根据链接创建一个DbDataAdapter
        /// </summary>
        /// <returns>创建一个DbDataAdapter</returns>
        public override IDbDataAdapter CreateAdapter()
        {
            return new System.Data.OleDb.OleDbDataAdapter();
        }

        /// <summary>
        /// 创建命令Builder
        /// </summary>
        /// <returns>命令Builder</returns>
        public override DbCommandBuilder CreateCommandBuilder(DbDataAdapter adapter)
        {
            return new System.Data.OleDb.OleDbCommandBuilder((OleDbDataAdapter)adapter);
        }


        public override DBDialect GetDialectType()
        {
            return DBDialect.Access;
        }

        public override string GetPageSql(string sql, Pager pager, string order, bool isDesc)
        {
            return this.GetPageSqlByTop(sql,pager, order, isDesc);
        }

        public override string BetweenDateString(string stringcolumn, DateTime before, DateTime end)
        {
            return "cdate(" + stringcolumn + ") between #"+before.ToString("yyyy-MM-dd") + " 00:00:00# and #" + end.ToString("yyyy-MM-dd") + " 23:59:59#";
            //throw new Exception("The method or operation is not implemented.");
        }

        public override string BetweenDate(string column, DateTime before, DateTime end)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string LargerDateString(string stringcolumn, DateTime before)
        {
            return "cdate("+stringcolumn + ")>#" + before.ToString("yyyy-MM-dd") + " 00:00:00#";
        }

        public override string LowerDateString(string stringcolumn, DateTime before)
        {
            return "cdate(" + stringcolumn + ")<#" + before.ToString("yyyy-MM-dd") + " 23:59:59#";
        }

        public override string LargerEqualDateString(string stringcolumn, DateTime before)
        {
            return "cdate(" + stringcolumn + ")>=#" + before.ToString("yyyy-MM-dd") + " 00:00:00#";
        }

        public override string LowerEqualDateString(string stringcolumn, DateTime before)
        {
            return "cdate(" + stringcolumn + ")<=#" + before.ToString("yyyy-MM-dd") + " 23:59:59#";
        }
    }

}
