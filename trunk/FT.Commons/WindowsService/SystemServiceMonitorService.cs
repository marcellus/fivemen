using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace FT.Commons.WindowsService
{
    public class SystemServiceMonitorService:BaseWindowService
    {
        public SystemServiceMonitorService(int interval)
            : base(interval)
        {

        }

        public override bool DoTask()
        {
            //throw new NotImplementedException();
            bool result = true;
            ServiceController[] services=ServiceController.GetServices();
            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].Status == ServiceControllerStatus.Running)
                {
                    //如果服务不在白名单内
                    this.Beep();
                    string logStr = string.Empty;
                    logStr = "发现启动的服务->"+services[i].ServiceName;
                    this.Log(MonitorLogType.ServiceWatch,logStr);
                    this.Sms(logStr);
                }
            }
            return true;

        }

        protected override void SetServiceName()
        {
           // throw new NotImplementedException();
           // this.ServiceName =
            this.SetServiceName( MonitorLogType.ServiceWatch);
        }
    }
}
