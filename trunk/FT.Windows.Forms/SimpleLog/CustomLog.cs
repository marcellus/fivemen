using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.Forms.SimpleLog
{
    [SimpleTable("table_custom_log")]
    [Alias("系统日志表")]
    public class CustomLog
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_opt_user")]
        [Alias("操作人")]
        public string OptUser;

        public string 操作人
        {
            get { return OptUser; }
            set { OptUser = value; }
        }

        [SimpleColumn(Column = "c_opt_date")]
        [Alias("操作时间")]
        public string OptDate;

        public string 操作时间
        {
            get { return OptDate; }
            set { OptDate = value; }
        }

        [SimpleColumn(Column = "c_opt_detail")]
        [Alias("详情")]
        public string OptDetail;

        public string 详情
        {
            get { return OptDetail; }
            set { OptDetail = value; }
        }
    }
}
