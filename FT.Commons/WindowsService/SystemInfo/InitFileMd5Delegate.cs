using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;


namespace FT.Commons.WindowsService.SystemInfo
{
    public delegate void InitFileMd5Delegate(string system,string systemVersion,string dirPath,FileInfo file);
    public delegate void InitServicesDelegate(string system, string systemVersion, ServiceController control);

    public delegate void InitComputerInfoDelegate(ComputerInfo computerInfo);

    public delegate void InitProcessDelegate(string system, string systemVersion, Process control);
    public delegate void SetTextCallBack(TextBox txt,string str);
    public delegate void AppendTextCallBack(TextBox txt,string str);
}
