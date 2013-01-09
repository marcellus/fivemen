using System;
using System.Collections.Generic;
using System.Text;
using Finisar.SQLite;
using System.Data;

namespace FT.DAL.Sqlite
{
    public class SqliteDataHelper : DataAccessHelper
    {

        private const string ConnStringFormatter = "{0}";


         public SqliteDataHelper(String str)
            : base(str)
        {
        }

        public SqliteDataHelper()
            : base()
        {
        }

        public SqliteDataHelper(string path, string uid, string pwd)
            : base(string.Format(ConnStringFormatter, new string[] { path, uid, pwd }))
        {
        }

        public override string LargerEqualDateString(string stringcolumn, DateTime before)
        {
            throw new NotImplementedException();
        }

        public override string LowerEqualDateString(string stringcolumn, DateTime before)
        {
            throw new NotImplementedException();
        }

        public override string LargerDateString(string stringcolumn, DateTime before)
        {
            throw new NotImplementedException();
        }

        public override string LowerDateString(string stringcolumn, DateTime before)
        {
            throw new NotImplementedException();
        }

        public override string BetweenDateString(string stringcolumn, DateTime before, DateTime end)
        {
            throw new NotImplementedException();
        }

        public override string BetweenDate(string column, DateTime before, DateTime end)
        {
            throw new NotImplementedException();
        }

        public override IDbConnection CreateConn(string connString)
        {
            SQLiteConnection conn= new SQLiteConnection(connString);
           // SQLiteConnection conn = new SQLiteConnection();
           // SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
           // connsb.DataSource = dbName;
           // connsb.Password = "";
           // conn.ConnectionString = connsb.ToString();
 
            return conn;
        }

        public override IDbDataAdapter CreateAdapter()
        {
            return new Finisar.SQLite.SQLiteDataAdapter();
        }

        public override DBDialect GetDialectType()
        {
            return DBDialect.Sqlite;
        }

        public override System.Data.Common.DbCommandBuilder CreateCommandBuilder(System.Data.Common.DbDataAdapter adapter)
        {
           // return new SQLiteCommandBuilder((SQLiteDataAdapter)adapter);
            return null;
        }

        public override string GetPageSql(string sql, Pager pager, string order, bool isDesc)
        {
            return this.GetPageSqlByTop(sql, pager, order, isDesc);
        }
    }
}
