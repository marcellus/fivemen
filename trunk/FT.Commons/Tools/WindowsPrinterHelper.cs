using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace FT.Commons.Tools
{
    public class WindowsPrinterHelper:BaseHelper
    {
        private WindowsPrinterHelper()
        {
        }

        public static List<string> LoopPrinter()
        {
            List<string> printerNames = new List<string>();
            string wmiSQL = "SELECT * FROM Win32_Printer";
            ManagementObjectCollection printers = new ManagementObjectSearcher(wmiSQL).Get();

            foreach (ManagementObject printer in printers)
            {
                PropertyDataCollection.PropertyDataEnumerator pde = printer.Properties.GetEnumerator();

                while (pde.MoveNext())
                {
                    Console.WriteLine(pde.Current.Name + " : " + pde.Current.Value);
                    if (pde.Current.Name == "DeviceID")
                    {
                        Console.WriteLine("打印机设备ID为："+pde.Current.Value);
                        printerNames.Add(pde.Current.Value.ToString());
                    }

                    //MessageBox.Show(pde.Current.Name + " : " + pde.Current.Value);
                    //显示的是 属性名 : 属性值 的形式
                }
            }
            return printerNames;


        }

        public static PrinterStatus GetPrinterStat(string PrinterDevice)
        {
            PrinterStatus ret = 0;
            string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
            ManagementObject printer = new ManagementObject(path);
            printer.Get();
            ret = (PrinterStatus)Convert.ToInt32(printer.Properties["PrinterStatus"].Value);
            return ret;
        }
        
    }
    //1 Other ,2 Unknown,3 Idle,4 Printing,5 Warming Up,6 Stopped printing,7 Offline
    public enum PrinterStatus 
    {
     其他状态= 1,
     未知,
     空闲,
     正在打印,
     预热,
     停止打印,
     打印中,
     离线
    }


     

}
