using System;

using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace PDA
{
    public class Pro2Col
    {
        /// <summary>
        /// 获取属性对应的数据库字段名称
        /// </summary>
        /// <param name="type">属性所在类的类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public static string GetColName4Pro(Type type, string propertyName)
        {
            PropertyInfo pi = type.GetProperty(propertyName);
            object[] o;
            if ((o = pi.GetCustomAttributes(typeof(ColumnNameAttribute), true)).Length == 0)
            {
                return string.Empty;
            }

            return o[0].ToString();
        }
        /// <summary>
        /// 获取属性对应的数据库字段名称
        /// </summary>
        /// <param name="type">属性所在的类的类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="actionType">当前操作</param>
        /// <returns></returns>
        public static string GetColName4Pro(Type type, string propertyName, Types.ActionType actionType)
        {
            PropertyInfo pi = type.GetProperty(propertyName);
            ColumnNameAttribute[] cns = null;
            if ((cns = (ColumnNameAttribute[])pi.GetCustomAttributes(typeof(ColumnNameAttribute), false)).Length == 0)
            {
                return string.Empty;
            }
            foreach (ColumnNameAttribute cn in cns)
            {
                if (actionType == (cn.Action & actionType))
                {
                    return cn.ToString();
                }
            }
            return string.Empty;
            
        }
        /// <summary>
        /// 获取属性对应的数据库字段名称
        /// </summary>
        /// <param name="o">属性所在的对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public static string GetColName4Pro(object o, string propertyName)
        {
            return GetColName4Pro(o.GetType(), propertyName);
        }
        /// <summary>
        /// 获取属性对应的数据库字段名称
        /// </summary>
        /// <param name="o">对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="actionType">当前操作</param>
        /// <returns></returns>
        public static string GetColName4Pro(object o, string propertyName, Types.ActionType actionType)
        {
            return GetColName4Pro(o.GetType(), propertyName, actionType);
        }
        /// <summary>
        /// 对象值更新到DataRow中
        /// </summary>
        /// <param name="o">对象</param>
        /// <param name="dr">DataRow</param>
        /// <param name="actionType">当前操作</param>
        public static void Obj2DataRow(object o, DataRow dr, Types.ActionType actionType)
        {
            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
                ColumnNameAttribute[] cns = null;
                if ((cns = (ColumnNameAttribute[])pi.GetCustomAttributes(typeof(ColumnNameAttribute), false)).Length > 0)
                {
                    foreach (ColumnNameAttribute cn in cns)
                    {
                        if (actionType == (actionType & cn.Action))
                        {
                            dr[cn.ToString()] = pi.GetValue(o, null);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 按对象属性为DataTable创建列
        /// </summary>
        /// <param name="o">对象</param>
        /// <param name="dt">DataTable</param>
        /// <param name="actionType">当前操作</param>
        public static void AddColumns4Obj(object o, DataTable dt, Types.ActionType actionType)
        {
            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
                ColumnNameAttribute[] cns = null;
                if ((cns = (ColumnNameAttribute[])pi.GetCustomAttributes(typeof(ColumnNameAttribute), false)).Length > 0)
                {
                    foreach (ColumnNameAttribute cn in cns)
                    {
                        if (actionType == (actionType & cn.Action) && !dt.Columns.Contains(cn.ToString()))
                        {
                            dt.Columns.Add(cn.ToString(), pi.PropertyType == typeof(bool) ? typeof(int) : pi.PropertyType);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 将DataRow的值赋给对象
        /// </summary>
        /// <param name="o">对象</param>
        /// <param name="dr">DataRow</param>
        public static void DataRow2Obj(object o, DataRow dr)
        {
            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
                ColumnNameAttribute[] cns = null;
                if ((cns = (ColumnNameAttribute[])pi.GetCustomAttributes(typeof(ColumnNameAttribute), false)).Length == 0)
                {
                    continue;
                }
                foreach (ColumnNameAttribute cn in cns)
                {
                    if (!dr.Table.Columns.Contains(cn.ToString()))
                    {
                        continue;
                    }
                    if (Convert.IsDBNull(dr[cn.ToString()]))
                    {
                        break;
                    }
                    pi.SetValue(o, Convert.ChangeType(dr[cns[0].ToString()], pi.PropertyType, System.Globalization.CultureInfo.CurrentCulture), null);
                    break;
                }
            }
        }
    }
}
