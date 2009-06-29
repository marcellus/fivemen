using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.Forms.SimpleLog
{
    [SimpleTable("table_custom_log")]
    [Alias("ϵͳ��־��")]
    public class CustomLog
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_opt_user")]
        [Alias("������")]
        public string OptUser;

        public string ������
        {
            get { return OptUser; }
            set { OptUser = value; }
        }

        [SimpleColumn(Column = "c_opt_date")]
        [Alias("����ʱ��")]
        public string OptDate;

        public string ����ʱ��
        {
            get { return OptDate; }
            set { OptDate = value; }
        }

        [SimpleColumn(Column = "c_opt_detail")]
        [Alias("����")]
        public string OptDetail;

        public string ����
        {
            get { return OptDetail; }
            set { OptDetail = value; }
        }
    }
}
