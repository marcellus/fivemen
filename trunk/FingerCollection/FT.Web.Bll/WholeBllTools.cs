using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Web.Bll
{
    public class WholeBllTools
    {
        private WholeBllTools()
        {
        }

        public static void CloseComputer(string ip)
        {
            terminalservice.TerminalStatusService service = new FT.Web.Bll.terminalservice.TerminalStatusService();
            service.Url = string.Format("http://{0}:8888/TerminalStatusService.asmx", ip);
            service.CloseComputer();
        }

        public static string GetComputerMac(string ip)
        {
            terminalservice.TerminalStatusService service = new FT.Web.Bll.terminalservice.TerminalStatusService();
            service.Url = string.Format("http://{0}:8888/TerminalStatusService.asmx", ip);
            string result = service.GetMachineMac();
            return result;
        }
    }
}
