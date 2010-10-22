using System;

using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Reflection;

namespace PDA.DataInit
{
    public class SqliteDbOperator
    {
        SQLiteConnection con;
        SQLiteCommand command;

        private string path;
        public SqliteDbOperator(string path)
        {

            this.path=Path.GetDirectoryName(Assembly.Load(Assembly.GetExecutingAssembly().GetName()).GetName().CodeBase)+"\\"+path;
            //this.CreateDb();
            //轻量级数据库SQLite的连接字符串写法："Data Source=D:\database\db.db3"
            //轻量级数据库SQLite的加密后的连接字符串写法："Data Source=D:"database\db.db3;Version=3;Password=你的SQLite数据库密码;"
            con = new SQLiteConnection("data source="+this.path);
            command = con.CreateCommand();
        }

        public int BatchExecute(string[] sqls)
        {
            int n;
            con.Open();
            using (SQLiteTransaction mytransaction = con.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(con))
                {
                   
                   
                    for (n = 0; n < sqls.Length; n++)
                    {
                        mycommand.CommandText = sqls[n];
                        mycommand.ExecuteNonQuery();
                    }
                    
                }
                mytransaction.Commit();
            }
            con.Close();
            return n;
        }

        public bool CheckDbExists()
        {

            return File.Exists(this.path);
        }

        public void CreateDb()
        {
            if(!File.Exists(path))
                File.Create(path);

        }

        public bool CreateTable(string ddl)
        {
            this.ExecuteNonQuery(ddl);
            return true;

        }
        public DataTable SelectFromTableName(string tableName)
        {
            return SelectFromSql( "SELECT * FROM " + tableName);
            
        }
         public DataTable SelectFromSql(string sql)
         {
             command.CommandText = sql;
             SQLiteDataAdapter da = new SQLiteDataAdapter(command);
             DataTable dt = new DataTable();
             da.Fill(dt);
             return dt;
         }

        public int ExecuteNonQuery(string sql)
        {
            int result = 0;
            con.Open();
            using (SQLiteCommand command = new SQLiteCommand(con))
            { 
                command.CommandText = sql;
                result = command.ExecuteNonQuery();

            }
            con.Close();
            return result;

        }

        public bool DropTable(String tablename)
        {
            return 1 == ExecuteNonQuery("drop table "+tablename);
        }


    }
}
