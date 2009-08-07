using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.ExternalTool
{
    
    [SimpleTable("table_trains")]
    [Alias("火车车次信息")]
    public class Train
    {
        [SimpleColumn(Column = "cc")]
        [SimplePK]
        [Alias("车次")]
        public string Cc;

        public string 车次
        {
            get { return Cc; }
            set { Cc = value; }
        }

        [SimpleColumn(Column = "sf")]
        [Alias("始发站")]
        public string Sf;

        public string 始发站
        {
            get { return Sf; }
            set { Sf = value; }
        }

        [SimpleColumn(Column = "zd")]
        [Alias("终点站")]
        public string Zd;

        public string 终点站
        {
            get { return Zd; }
            set { Zd = value; }
        }


        [SimpleColumn(Column = "fs")]
        [Alias("发时")]
        public string Fs;

        public string 发时
        {
            get { return Fs; }
            set { Fs = value; }
        }


        [SimpleColumn(Column = "ds")]
        [Alias("到时")]
        public string Ds;

        public string 到时
        {
            get { return Ds; }
            set { Ds = value; }
        }


        [SimpleColumn(Column = "lc")]
        [Alias("里程")]
        public string Lc;

        public string 里程
        {
            get { return Lc; }
            set { Lc = value; }
        }


        [SimpleColumn(Column = "ls")]
        [Alias("历时")]
        public string Ls;

        public string 历时
        {
            get { return Ls; }
            set { Ls = value; }
        }

        [SimpleColumn(Column = "zs")]
        [Alias("总站数")]
        public string Zs;

        public string 总站数
        {
            get { return Zs; }
            set { Zs = value; }
        }


        
    }
}
