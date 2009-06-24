using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace Jxc.Plugin
{
    [SimpleTable("table_jxc_in_record")]
    [Alias("����¼")]
    public class InRecord
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }

        }

        [SimpleColumn(Column = "date_in")]
        [Alias("�������")]
        public string InDate;

        public string �������
        {
            get { return InDate; }
            set { InDate = value; }
        }

        /// <summary>
        /// ��Ʒ��Դ
        /// </summary>
        [SimpleColumn(Column = "c_from")]
        [Alias("��Ʒ��Դ")]
        public string From;

        public string ��Ʒ��Դ
        {
            get { return From; }
            set { From = value; }
        }


        /// <summary>
        /// ��Ʒ����
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        [Alias("��Ʒ����")]
        public string TypeName;

        public string ��Ʒ����
        {
            get { return TypeName; }
            set { TypeName = value; }
        }

        /// <summary>
        /// ֧��
        /// </summary>
        [SimpleColumn(Column = "i_zhi_shu")]
        [Alias("֧��")]
        public int ZhiShu;

        public int ֧��
        {
            get { return ZhiShu; }
            set { ZhiShu = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [SimpleColumn(Column = "m_dun_shu")]
        [Alias("����")]
        public decimal DunShu;

        public decimal ����
        {
            get { return DunShu; }
            set { DunShu = value; }
        }



        /// <summary>
        /// �ܼ�
        /// </summary>
        [SimpleColumn(Column = "m_price")]
        [Alias("�ܼ�")]
        public decimal Price;

        public decimal �ܼ�
        {
            get { return Price; }
            set { Price = value; }
        }
    }
}
