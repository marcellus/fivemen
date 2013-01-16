using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Terminal
{
    [SimpleTable("yuantuo_terminals")]
    public class TerminalEntity
    {
        [SimplePK]
        public int Id;

        [SimpleColumn(Column = "name")]
        [Alias("终端计算机名称")]
        public string MachineName;

        [SimpleColumn(Column = "ip")]
        [Alias("终端IP")]
        public string MachineIp;

        [SimpleColumn(Column = "mac")]
        [Alias("终端MAC地址")]
        public string MachineMac;


        [SimpleColumn(Column = "address")]
        [Alias("终端位置地址")]
        public string MachineAddress;


        [SimpleColumn(Column = "groupid")]
        [Alias("终端分组ID")]
        public int MachineGroupId;


        [SimpleColumn(Column = "onlineseconds", AllowInsert = false, AllowUpdate = true)]
        [Alias("在线累积时间")]
        public int OnlineSeconds;

        [SimpleColumn(Column = "date_machine_last_online_time", AllowInsert = false, AllowUpdate = true)]
        [Alias("最近一次上线时间")]
        public DateTime LastOnlineTime;

        [SimpleColumn(Column = "date_machine_last_outline_time", AllowInsert = false, AllowUpdate = true)]
        [Alias("最近一次下线时间")]
        public DateTime LastOutlineTime;


        [SimpleColumn(Column = "citycode")]
        [Alias("城市代码")]
        public string CityCode;


        [SimpleColumn(Column = "phone")]
        [Alias("联系电话")]
        public string Phone;

        [SimpleColumn(Column = "storeno")]
        [Alias("门店编号")]
        public string StoreNo;

        [SimpleColumn(Column = "storephone")]
        [Alias("门店电话")]
        public string StorePhone;

        [SimpleColumn(Column = "storeprefix")]
        [Alias("门店编号前缀")]
        public string StorePrefix;


        [SimpleColumn(Column = "storename")]
        [Alias("门店名称")]
        public string StoreName;


        
    }
}
