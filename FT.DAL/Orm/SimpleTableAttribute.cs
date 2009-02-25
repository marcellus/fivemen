using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// ����ָ�����ݿ����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SimpleTableAttribute:Attribute
    {
        private string table;

        /// <summary>
        /// ���ݿ��Ӧ�ı���
        /// </summary>
        public string Table
        {
            get { return table; }
        }
        public SimpleTableAttribute(string table)
        {
            if (table == null || table.Length == 0)
            {
                throw new ArgumentException("��������Ϊ�գ�");
            }
            this.table = table;
        }
    }
}
