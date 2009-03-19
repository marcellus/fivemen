using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace Vehicle.Plugins
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [SimpleTable("table_optlog")]
    [Alias("操作日志表")]
    public class OptLog
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
            
        }
        /// <summary>
        /// 车辆识别码,操作对象
        /// </summary>
        [SimpleColumn(Column="c_clsbm")]
        [Alias("车辆识别码")]
        public string Clsbm;

        public string 车辆识别码
        {
            get { return Clsbm; }
            set { Clsbm = value; }
        }

        [SimpleColumn(Column = "c_operator")]
        [Alias("操作人")]
        public string Operator;

        /// <summary>
        /// 操作人
        /// </summary>
        public string 操作人
        {
            get { return Operator; }
            set { Operator = value; }
        }

        [SimpleColumn(Column = "date_optdate")]
        [Alias("操作时间")]
        public string OpDate;


        public string 操作时间
        {
            get { return OpDate; }
            set { OpDate = value; }
        }

        [SimpleColumn(Column = "c_opdetail")]
        [Alias("具体操作")]
        public string OpDetail;

        public string 具体操作
        {
            get { return OpDetail; }
            set { OpDetail = value; }
        }
    }
}
