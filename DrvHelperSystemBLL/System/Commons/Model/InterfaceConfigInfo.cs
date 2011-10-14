using System;
using System.Collections.Generic;

using System.Text;
using FT.DAL.Orm;
using DrvHelperSystemBLL.System.Model;

namespace DrvHelperSystemBLL.System.Commons.Model
{
    [SimpleTable("table_interface_config_info")]
    [Alias("接口配置表")]
    public class InterfaceConfigInfo:BaseModel
    {
        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_interface_config_info")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

    }
}
