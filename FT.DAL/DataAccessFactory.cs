using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace FT.DAL
{
    public class DataAccessFactory
    {
        /// <summary>
        /// 获取数据库连接，默认sqlserver
        /// </summary>
        /// <returns></returns>
        public static IDataAccess GetDataAccess()
        {
            if (ConfigurationManager.AppSettings["DefaultDbTpe"].ToLower() == "access")
                 return new Access.AccessDataHelper();
             if (ConfigurationManager.AppSettings["DefaultDbTpe"].ToLower() == "sqlserver")
                 return new SqlServer.SqlServerDataHelper();
             if (ConfigurationManager.AppSettings["DefaultDbTpe"].ToLower() == "oracle")
                 return new Oracle.OracleDataHelper();
             if (ConfigurationManager.AppSettings["DefaultDbTpe"].ToLower() == "sqlite")
                 return new Sqlite.SqliteDataHelper(ConfigurationManager.AppSettings["DefaultConnString"]);

             return null;
             //return new SqlServer.SqlServerDataHelper();
        }
    }
}
