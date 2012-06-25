using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.WindowsService
{
    public class ProcessModuleNumberMonitorService:BaseWindowService
    {
        public ProcessModuleNumberMonitorService(int interval)
            : base(interval)
        {

        }

        public override bool DoTask()
        {
            throw new NotImplementedException();
        }

        protected override void SetServiceName()
        {
            throw new NotImplementedException();
        }
    }
}
