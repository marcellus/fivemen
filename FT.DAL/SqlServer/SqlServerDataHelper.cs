/********************************************************************************
* File:SqlserverDataHelper.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using FT.DAL;

namespace FT.DAL.SqlServer
{
    public class SqlServerDataHelper:DataAccessHelper
    {

        private const string ConnStringFormatter = "server={0};database={1};uid={2};pwd={3}";

        public SqlServerDataHelper(String str):base(str)
        {
        }
        public SqlServerDataHelper()
            : base()
        {
        }
        public SqlServerDataHelper(string server,string database,string uid,string pwd)
            : base(string.Format(ConnStringFormatter, new string[] { server, database, uid, pwd }))
        {
        }
        /// <summary>
        /// 根据连接字符串connString 创建一个DbConnection
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns>创建一个DbConnection</returns>
        public override DbConnection CreateConn(string connString)
        {
            return new SqlConnection(connString);
        }

        /// <summary>
        /// 根据链接创建一个DbDataAdapter
        /// </summary>
        /// <returns>创建一个DbDataAdapter</returns>
        public override DbDataAdapter CreateAdapter()
        {
            return new SqlDataAdapter();
        }

        /// <summary>
        /// 创建命令Builder
        /// </summary>
        /// <returns>命令Builder</returns>
        public override DbCommandBuilder CreateCommandBuilder(DbDataAdapter adapter)
        {
            return new System.Data.SqlClient.SqlCommandBuilder((SqlDataAdapter)adapter);
        }



        public override DBDialect GetDialectType()
        {
            return DBDialect.SqlServer;
        }

        public override string GetPageSql(string sql, Pager pager,string order,bool isDesc)
        {
            return this.GetPageSqlByTop(sql, pager, order, isDesc);
        }

        public override string BetweenDateString(string stringcolumn, DateTime before, DateTime end)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string BetweenDate(string column, DateTime before, DateTime end)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string LargerDateString(string stringcolumn, DateTime before)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string LowerDateString(string stringcolumn, DateTime before)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string LargerEqualDateString(string stringcolumn, DateTime before)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string LowerEqualDateString(string stringcolumn, DateTime before)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
