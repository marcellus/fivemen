using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Terminal
{
    [SimpleTable("table_terminal")]
    public class TerminalEntity
    {
        [SimplePK]
        public int Id;

        [SimpleColumn(Column = "c_machine_name")]
        [Alias("终端计算机名称")]
        public string MachineName;

        [SimpleColumn(Column = "c_machine_ip")]
        [Alias("终端IP")]
        public string MachineIp;

        [SimpleColumn(Column = "c_machine_mac")]
        [Alias("终端MAC地址")]
        public string MachineMac;


        [SimpleColumn(Column = "c_machine_address")]
        [Alias("终端位置地址")]
        public string MachineAddress;


        [SimpleColumn(Column = "i_machine_group_id")]
        [Alias("终端分组ID")]
        public int MachineGroupId;


        [SimpleColumn(Column = "c_machine_online_seconds")]
        [Alias("在线累积时间")]
        public int OnlineSeconds;

        [SimpleColumn(Column = "c_machine_last_online_time")]
        [Alias("最近一次上线时间")]
        public DateTime LastOnlineTime;

        [SimpleColumn(Column = "c_machine_last_outline_time")]
        [Alias("最近一次下线时间")]
        public DateTime LastOutlineTime;

    }
}
