using System;
using System.Collections.Generic;

using System.Text;
using FT.DAL.Orm;
using DrvHelperSystemBLL.System.Model;

namespace DrvHelperSystemBLL.System.Commons.Model
{
    [SimpleTable("table_log_info")]
    [Alias("业务日志")]
    public class LogInfo : BaseModel
    {
        public LogInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_log_info")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_operator")]
        [Alias("操作者")]
        public String Operator;

        public String 操作者
        {
            get { return Operator; }
            set { Operator = value; }
        }

        [SimpleColumn(Column = "c_bustype")]
        [Alias("业务类别")]
        public String BusType;

        public String 业务类别
        {
            get { return BusType; }
            set { BusType = value; }
        }

        [SimpleColumn(Column = "regdate",AllowInsert=false,AllowUpdate=false)]
        [Alias("操作时间")]
        public String RegDate;

        public String 操作时间
        {
            get { return RegDate; }
            set { 操作时间 = value; }
        }

        [SimpleColumn(Column = "c_content")]
        [Alias("具体内容")]
        public String Content;

        public String 具体内容
        {
            get { return Content; }
            set { Content = value; }
        }


        [SimpleColumn(Column = "c_des1")]
        [Alias("预留字段1")]
        public String Des1;

        public String 预留字段1
        {
            get { return Des1; }
            set { Des1 = value; }
        }

        [SimpleColumn(Column = "c_des2")]
        [Alias("预留字段2")]
        public String Des2;

        public String 预留字段2
        {
            get { return Des2; }
            set { Des2 = value; }
        }

        [SimpleColumn(Column = "c_des3")]
        [Alias("预留字段3")]
        public String Des3;

        public String 预留字段3
        {
            get { return Des3; }
            set { Des3 = value; }
        }

        
    }
}
