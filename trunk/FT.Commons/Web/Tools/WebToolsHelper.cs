using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FT.Commons.Web.Tools
{
    public class WebToolsHelper
    {

        private WebToolsHelper()
        {
        }

        /// <summary>
        /// 获取终端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            return System.Web.HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// 根据IP获取客户端MAC地址
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static string GetMac(string IP)   //para IP is the client's IP
        {
            try
            {
                string dirResults = "";
                ProcessStartInfo psi = new ProcessStartInfo();
                Process proc = new Process();
                psi.FileName = "nbtstat";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = "-A " + IP;
                psi.UseShellExecute = false;
                //psi.
                proc = Process.Start(psi);
                dirResults = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                dirResults = dirResults.Replace("\r", "").Replace("\n", "").Replace("\t", "");

                Regex reg = new Regex("Mac[ ]{0,}Address[ ]{0,}=[ ]{0,}(?<key>((.)*?))__MAC", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                Match mc = reg.Match(dirResults + "__MAC");

                if (mc.Success)
                {
                    return mc.Groups["key"].Value;
                }
                else
                {
                    reg = new Regex("Host not found", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    mc = reg.Match(dirResults);
                    if (mc.Success)
                    {
                        return "Host not found!";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                    return string.Empty;
            }

        }
    }
}
