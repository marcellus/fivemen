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



        [SimpleColumn(Column = "c_interface_url")]
        [Alias("接口地址")]
        public String InterfaceUrl;

    }
}
