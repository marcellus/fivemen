using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// 简单的列特性
    /// 使用方法：
    /// SimpleColumn(Column="alias",AllowInsert=false)
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SimpleColumnAttribute:Attribute
    {
        private bool allowInsert = true;

        public bool AllowInsert
        {
            get { return allowInsert; }
            set { allowInsert = value; }
        }

        private bool allowUpdate = true;

        public bool AllowUpdate
        {
            get { return allowUpdate; }
            set { allowUpdate = value; }
        }

        private bool alllowSelect = true;

        public bool AllowSelect
        {
            get { return alllowSelect; }
            set { alllowSelect = value; }
        }
        private string column;

        public string Column
        {
            get { return column; }
            set { column = value; }
        }

        public SimpleColumnAttribute()
        {
        }

        private string sqlStr;

        /// <summary>
        /// 列的sql定义,优先级为一
        /// </summary>
        public string SqlStr
        {
            get { return sqlStr; }
            set { sqlStr = value; }
        }

        private SimpleColumnType columnType;

        /// <summary>
        /// 简单的列类型，默认为空，根据c#基础类型进行转换,优先级为一
        /// </summary>
        public SimpleColumnType ColumnType
        {
            get { return columnType; }
            set { columnType = value; }
        }

        private int length;

        /// <summary>
        /// 列长度,如果没有定义sqlstr，根据这个长度来定义
        /// </summary>
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
    }

    /// <summary>
    /// 简单的列类型
    /// </summary>
    public enum SimpleColumnType
    {
        String,
        Time,
        Date,
        Int,
        Binary,
        Money

    }
}
