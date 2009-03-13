/********************************************************************************
* File:IDataAccess.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace FT.DAL
{
    /// <summary>
    /// 数据访问的接口类
    /// </summary>
    public interface IDataAccess
    {

        string LargerEqualDateString(string stringcolumn, DateTime before);

        string LowerEqualDateString(string stringcolumn, DateTime before);

        string LargerDateString(string stringcolumn, DateTime before);

        string LowerDateString(string stringcolumn, DateTime before);

        /// <summary>
        /// 字符串时间列得出对比的sql语句
        /// </summary>
        /// <param name="stringcolumn"></param>
        /// <param name="before"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        string BetweenDateString(string stringcolumn, DateTime before, DateTime end);
        /// <summary>
        /// date的时间列对比出的sql语句
        /// </summary>
        /// <param name="column"></param>
        /// <param name="before"></param>
        /// <param name="end"></param>
        /// <returns></returns>
         string BetweenDate(string column, DateTime before, DateTime end);

        /// <summary>
        /// 创建命令Builder
        /// </summary>
        /// <returns>命令Builder</returns>
        DbCommandBuilder CreateCommandBuilder(DbDataAdapter adapter);
        /// <summary>
        /// 创建DataAdapter
        /// </summary>
        /// <returns>返回的DataAdapter</returns>
        DbDataAdapter CreateAdapter();
        /// <summary>
        /// 创建一个数据命令
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DbCommand</returns>
        DbCommand CreateCommand(string sql);
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>是否成功打开</returns>
        bool Open();
        /// <summary>
        /// 根据连接字符串打开数据库连接
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns>是否成功打开</returns>
        bool Open(string connString);
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns>是否成功关闭</returns>
        bool Close();
        /// <summary>
        /// 返回一个未关闭的DbDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>未关闭的DbDataReader</returns>
        DbDataReader SelectDR(string sql);
        /// <summary>
        /// 返回一个已关闭的DbDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>关闭的DbDataReader</returns>
        DbDataReader SelectDRClosing(string sql);
        /// <summary>
        /// 根据sql语句返回一个DataSet
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="tableName">表名</param>
        /// <returns>一个DataSet</returns>
        DataSet SelectDS(string sql, string tableName);

        /// <summary>
        /// 功能描述：执行命令带上参数
        /// </summary>
        /// <param name="cmdText">命名</param>
        /// <param name="cmdParms">命令参数列表</param>
        /// <returns>是否执行成功</returns>
        bool ExecuteSqlByParam(string cmdText, params System.Data.Common.DbParameter[] cmdParms);
        /// <summary>
        /// 根据sql语句返回一个DataTable
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="tableName">表名</param>
        /// <returns>一个DataTable</returns>
        DataTable SelectDataTable(string sql, string tableName);
        /// <summary>
        /// 执行一个存储过程
        /// </summary>
        /// <param name="cmdText">存储过程的名称</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>返回的结果</returns>
        int ExecuteProcedure(string cmdText, params System.Data.Common.DbParameter[] cmdParms);
        /// <summary>
        /// 根据存储过程返回一个DataSet，一般供分页使用
        /// </summary>
        /// <param name="cmdText">存储过程的名称</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>一个DataSet</returns>
        DataSet SelectDSByProcedure(string cmdText, params DbParameter[] cmdParms);
        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>是否成功执行sql语句</returns>
        bool ExecuteSql(string sql);
        /// <summary>
        /// 把多条语句当一个事务执行
        /// </summary>
        /// <param name="sqlArray">多条sql语句</param>
        /// <returns>是否成功执行</returns>
        bool ExecuteTransaction(string[] sqlArray);
        /// <summary>
        /// 返回sql语句执行后返回的单值对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>单值对象</returns>
        object SelectScalar(string sql);

        /// <summary>
        /// 获取数据库方言
        /// </summary>
        /// <returns>方言</returns>
        DBDialect GetDialectType();


        string GetPageSql(string sql, Pager pager, string order, bool isDesc);
    }
}
