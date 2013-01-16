using System;
using System.Collections.Generic;
using System.Text;

namespace FT.AuthLicense
{
    /// <summary>
    /// 授权文件对象
    /// </summary>
    [Serializable]
    public class AuthLicenseObject
    {
        public string AppName;
        public string MachineCode;
        public string RightCode;
        public string Company;
        public int TerminalNum=10;//-1代表无限
        public int UserNum = 10;//-1代表无限
    }
}
