using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// �򵥵���������,����ѯʹ��
    /// ʹ�÷�����
    /// Alias("")
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class AliasAttribute:Attribute
    {
         private string name;

        /// <summary>
        /// ���ݿ��Ӧ�ı���
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        public AliasAttribute(string name)
        {
            if (name == null || name.Length == 0)
            {
                throw new ArgumentException("��������Ϊ�գ�");
            }
            this.name = name;
        }
    }
}
