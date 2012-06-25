using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace FT.Commons.WindowsService
{
    public class ProcessMonitorService:BaseWindowService
    {
        public ProcessMonitorService(int interval)
            : base(interval)
        {

        }

        public override bool DoTask()
        {
            bool result = true;
            Process[] processes = System.Diagnostics.Process.GetProcesses();

            for (int i = 0; i < processes.Length; i++)
            {
                 //如果进程不在白名单内。检查是否文件大小未变更，加载模块是否数量正确
                    this.Beep();
                    string logStr = string.Empty;
                    logStr = "发现运行的进程->" + processes[i].ProcessName;
                    //processes[i].Modules[i].
                    this.Log(MonitorLogType.ServiceWatch, logStr);
                    this.Sms(logStr);
               
            }
            return true;
        }

        protected override void SetServiceName()
        {
            this.SetServiceName(MonitorLogType.ProcessWatch);
        }
    }
}
