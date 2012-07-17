using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.WindowsService.SystemInfo
{
    public class MonitorProcessInfo
    {

        public string System;
        public string SystemVersion;
        public string Name;
        public int VirtualMemory;
        public int RealMemory;
        public List<MonitorModuleInfo> modules;
        
    }
}
