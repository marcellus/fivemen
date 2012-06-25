using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace ServerTrojanMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				//new Service1() 
                new FT.Commons.WindowsService.ExDiskPluginMonitorService("CDEF",1000)
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
