using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;


namespace Jxc.Plugin
{
    [SimpleTable("table_jxc_basedata")]
    [Alias("��Ʒ��������")]
    public class BaseData
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }

        }

        /// <summary>
        /// ��������
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        [Alias("��������")]
        public string TypeName;

        public string ��������
        {
            get { return TypeName; }
            set { TypeName = value; }
        }

        /// <summary>
        /// ÿ֧����
        /// </summary>
        [SimpleColumn(Column = "i_weight")]
        [Alias("ÿ֧����")]
        public decimal Weight;

        public decimal ÿ֧����
        {
            get { return Weight; }
            set { Weight = value; }
        }

        /// <summary>
        /// ÿ�ֵ���
        /// </summary>
        [SimpleColumn(Column = "i_price")]
        [Alias("ÿ�ֵ���")]
        public decimal Price;

        public decimal ÿ�ֵ���
        {
            get { return Price; }
            set { Price = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        [SimpleColumn(Column = "i_store_num")]
        [Alias("�������")]
        public decimal StoreNum;

        public decimal �������
        {
            get { return StoreNum; }
            set { StoreNum = value; }
        }
    }
}
