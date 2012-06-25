using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace FT.Commons.WindowsService
{
    public class NetworkMonitorService:BaseWindowService
    {
        public NetworkMonitorService(int interval)
            : base(interval)
        {

        }
        public override bool DoTask()
        {
            bool result = true;
            //ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");
            
            ManagementObjectCollection moc = mc.GetInstances();
            log.Debug("查找到的连接数量为->"+moc.Count);
            int i = 0;
            foreach (ManagementObject mo in moc)  
            {
               
                object val = mo["NetConnectionStatus"];

                if (val == null) //断开的。
                {
                }
                else
                {
                    string name = (string)mo["Name"];
                    Console.WriteLine(   "{0}\n\tConnection   Status:{1} ", name,(ushort)val);
                    ushort state = (ushort)val;
                    if (state == 2)
                    {
                        i++;
                    }
                }
               
              
            }
            if (i>1)
            {
                result = false;
                this.Beep();
                string logStr = "发现可用网络连接的个数为>" + i;
                this.Log(MonitorLogType.NetworkWatch, logStr);
                this.Sms(logStr);
            }
            return result;
        }

        protected override void SetServiceName()
        {
            this.SetServiceName(MonitorLogType.NetworkWatch);
        }
    }
}
