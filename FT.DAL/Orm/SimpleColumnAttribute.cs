using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// �򵥵�������
    /// ʹ�÷�����
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
        /// �е�sql����,���ȼ�Ϊһ
        /// </summary>
        public string SqlStr
        {
            get { return sqlStr; }
            set { sqlStr = value; }
        }

        private SimpleColumnType columnType;

        /// <summary>
        /// �򵥵������ͣ�Ĭ��Ϊ�գ�����c#�������ͽ���ת��,���ȼ�Ϊһ
        /// </summary>
        public SimpleColumnType ColumnType
        {
            get { return columnType; }
            set { columnType = value; }
        }

        private int length;

        /// <summary>
        /// �г���,���û�ж���sqlstr�������������������
        /// </summary>
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
    }

    /// <summary>
    /// �򵥵�������
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
