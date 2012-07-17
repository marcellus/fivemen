using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace FT.Commons.WindowsService.SystemInfo
{
    public class ComputerInfo
    {
        public string Name;
        public string Ip;
        public string Mac;
        public string Location;
        public string Company;
        public string System;
        public string SystemVersion;
        //公司，IP，计算机所在地未读取

        public override string ToString()
        {
            return string.Format("系统:{0},版本:{1},MAC:{2},IP:{3},公司{4},计算机名称{5},计算机所在地{6}",
                System, SystemVersion, Mac,Ip,
                Company, Name, Location);
        }

    }
}
