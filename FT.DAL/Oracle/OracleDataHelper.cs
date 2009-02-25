/********************************************************************************
* File:AccessDataHelper.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Data.Common;
using FT.DAL;

namespace FT.DAL.Oracle
{

    /// <summary>
    /// AccessDataHelper 的摘要说明
    /// </summary>
    public class OracleDataHelper : DataAccessHelper
    {
        private const string ConnStringFormatter = "Data Source={0};user={1};password={2};";
        public OracleDataHelper(String str)
            : base(str)
        {
        }

        public OracleDataHelper()
            : base()
        {
        }

        public OracleDataHelper(string tnsname, string uid, string pwd)
            : base(string.Format(ConnStringFormatter, new string[] { tnsname, uid, pwd }))
        {
        }

        /// <summary>
        /// 根据连接字符串connString 创建一个DbConnection
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns>创建一个DbConnection</returns>
        public override DbConnection CreateConn(string connString)
        {
            return new OracleConnection(connString);
        }

        /// <summary>
        /// 根据链接创建一个DbDataAdapter
        /// </summary>
        /// <returns>创建一个DbDataAdapter</returns>
        public override DbDataAdapter CreateAdapter()
        {
            return new OracleDataAdapter();
        }

        /// <summary>
        /// 创建命令Builder
        /// </summary>
        /// <returns>命令Builder</returns>
        public override DbCommandBuilder CreateCommandBuilder(DbDataAdapter adapter)
        {
            return new System.Data.OracleClient.OracleCommandBuilder((OracleDataAdapter)adapter);
        }


        public override DBDialect GetDialectType()
        {
            return DBDialect.Oracle;
        }

        public override string GetPageSql(string sql, Pager pager, string order, bool isDesc)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

}
