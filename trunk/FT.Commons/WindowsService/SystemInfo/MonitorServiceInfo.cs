﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace FT.Commons.WindowsService.SystemInfo
{
    public class MonitorServiceInfo
    {
        public string System;
        public string SystemVersion;
        public string ServiceName;
        public string ServicePath;
        public string StartType;
        public string State;

        private static string TransServiceState(int state)
        {
            string result = string.Empty;
            switch (state)
            {
                case 1:
                    result = "已停止";
                    break;
                case 4:
                    result = "正在运行";
                    break;
                case 7:
                    result = "已暂停";
                    break;
                default:
                    result = "中间状态";
                    break;


            }
            return result;
            //services[i].Status
        }

        public MonitorServiceInfo(string system,string systemVersion,ServiceController control)
        {
            this.System = system;
            this.SystemVersion = systemVersion;
            this.ServiceName = control.DisplayName;
            this.ServicePath = control.ServiceName;
            this.StartType = control.ServiceType.ToString();
            this.State = TransServiceState((int)control.Status);
        }

        public override string ToString()
        {
            return string.Format("系统{4}{5},服务名{0},路径{1},的启动类型{2},运行状态{3}", ServiceName, ServicePath, StartType,
                State,System,SystemVersion);
        }
    }
}
