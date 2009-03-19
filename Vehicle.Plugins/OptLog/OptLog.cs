using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace Vehicle.Plugins
{
    /// <summary>
    /// ������־
    /// </summary>
    [SimpleTable("table_optlog")]
    [Alias("������־��")]
    public class OptLog
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
            
        }
        /// <summary>
        /// ����ʶ����,��������
        /// </summary>
        [SimpleColumn(Column="c_clsbm")]
        [Alias("����ʶ����")]
        public string Clsbm;

        public string ����ʶ����
        {
            get { return Clsbm; }
            set { Clsbm = value; }
        }

        [SimpleColumn(Column = "c_operator")]
        [Alias("������")]
        public string Operator;

        /// <summary>
        /// ������
        /// </summary>
        public string ������
        {
            get { return Operator; }
            set { Operator = value; }
        }

        [SimpleColumn(Column = "date_optdate")]
        [Alias("����ʱ��")]
        public string OpDate;


        public string ����ʱ��
        {
            get { return OpDate; }
            set { OpDate = value; }
        }

        [SimpleColumn(Column = "c_opdetail")]
        [Alias("�������")]
        public string OpDetail;

        public string �������
        {
            get { return OpDetail; }
            set { OpDetail = value; }
        }
    }
}
