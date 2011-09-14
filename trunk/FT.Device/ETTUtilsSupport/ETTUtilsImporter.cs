using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.ETTUtilsSupport
{
    public class ETTUtilsImporter
    {
        #region dll导入
        /// <returns>1正确0错误</returns>
        [DllImport("ETTUtils.dll")]
        public static extern bool ValidateReg(string key);

        [DllImport("ETTUtils.dll")]
        public static extern void Encrypt(string regKey,string encrpytKey,StringBuilder result);


        [DllImport("ETTUtils.dll")]
        public static extern int GetMachineKey(StringBuilder result);

        [DllImport("ETTUtils.dll")]
        public static extern void Reg(string key, string regkey);

        
        #endregion
    }
}
