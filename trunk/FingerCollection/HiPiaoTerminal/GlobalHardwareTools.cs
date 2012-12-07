using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FT.Commons.Tools;
using HiPiaoInterface;
using HiPiaoTerminal.ConfigModel;
using FT.Commons.Printer;
using FT.Commons.Print;

namespace HiPiaoTerminal
{
    public class GlobalHardwareTools
    {
        private static FT.Device.HotPrinter.HotPrinterImporter hotprinter;

        private static FT.Commons.Tools.ITerminalPrinter lptHelper ;

        public static ITerminalPrinter GetTerminalPrinter()
        {

            if (lptHelper == null)
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                if(config.PrinterType=="并口")
                {
                    lptHelper = new FT.Commons.Tools.LPTHelper();
                }
                else if (config.PrinterType == "串口")
                {
                    lptHelper = new FT.Commons.Tools.SerialPortHelper();
                }
            }
            return lptHelper;
            
            
        }

        public static void OpenHotPrinter()
        {
            if (GetTerminalPrinter()!=null)
            GetTerminalPrinter().Open();
        }

        public static string ConvertPrintTemplate(object obj, string row)
        {
            string result = string.Empty;
            string[] tmpArray = null;
            if (row.ToLower().StartsWith("cmd"))
            {
                result = row;
                if (result.IndexOf("|") != -1)
                {
                    tmpArray = result.Substring(4).Trim().Split('|');
                    if (tmpArray.Length > 0)
                    {
                        result = string.Empty;
                        for (int j = 0; j < tmpArray.Length; j++)
                        {
                            result += (char)Convert.ToInt32(tmpArray[j]);
                        }
                    }
                }
            }
            else if (row.ToLower().StartsWith("property"))
            {
                result = row;
                if (result.IndexOf("#") != -1)
                {
                    result = result.Substring(9);
                    tmpArray = result.Trim().Split('#');
                    if (tmpArray.Length > 0)
                    {
                        result = string.Empty;
                        for (int j = 0; j < tmpArray.Length; j++)
                        {
                            if (j % 2 == 1)
                            {
                                result = result.Replace("#" + tmpArray[j] + "#", ReflectHelper.GetObjectProperty(obj, tmpArray[j]));
                            }
                        }
                    }
                }
            }
            else if (row.ToLower().StartsWith("field"))
            {
                result = row;
                if (result.IndexOf("#") != -1)
                {
                    result = result.Substring(6);
                    tmpArray = result.Trim().Split('#');

                    if (tmpArray.Length > 0)
                    {
                        //result = string.Empty;
                        for (int j = 0; j < tmpArray.Length; j++)
                        {
                            if (j % 2 == 1)
                            {
                                result = result.Replace("#" + tmpArray[j] + "#", ReflectHelper.GetObjectField(obj, tmpArray[j]));
                            }
                        }
                    }
                }
            }
            else
            {
                result = row;
            }
            return result;
        }

        public static TicketPrintObject ticket;

        public static void PrintTicket()
        {
            PrintTicket(ticket);
        }

        public static void PrintSellProduct(SellProductPrinter ticketTmp)
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.PrinterType == "Windows")
            {
                PrintWindowsTemplate(ticketTmp, "SellProductTemplate-Windows.txt");
            }
            else
            {

                PrintTemplate(ticketTmp, "SellProduct.txt");
            }
        }

        public static void PrintTicket(TicketPrintObject ticketTmp)
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.PrinterType == "Windows")
            {
                PrintWindowsTemplate(ticketTmp, "TicketTemplate-Windows.txt");
            }
            else
            {

                PrintTemplate(ticketTmp, "TicketTemplate.txt");
            }
        }

        public static void PrintWindowsTemplate(object obj, string templateFile)
        {
            string path = Application.StartupPath + "\\Template\\" + templateFile;
            using (StreamReader fileStream = new StreamReader(path, Encoding.Default))
            {
                string content = fileStream.ReadToEnd();
                string[] rows = content.Replace("\r\n", "?").Split("?".ToCharArray());
                List<string> lists=new List<string>(rows.Length);
                for (int i = 0; i < rows.Length; i++)
                {
                   // if (rows[i].Length > 0)
                       lists.Add(ConvertPrintTemplate(obj, rows[i]));
                }


                ListStringPrintObject printer = new ListStringPrintObject(lists,new System.Drawing.Font("宋体",9),10);
                CommonPrinter commonPrinter = new CommonPrinter(printer);
                //commonPrinter.SetPaperSize(config.PageWidth, config.PageHeight);
                commonPrinter.Print();
            }


        }

        public static void PrintTemplate(object obj, string templateFile)
        {
            string path = Application.StartupPath + "\\Template\\" + templateFile;
            using (StreamReader fileStream = new StreamReader(path, Encoding.Default))
            {
                string content = fileStream.ReadToEnd();
                string[] rows = content.Replace("\r\n", "?").Split("?".ToCharArray());
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].Length > 0)
                        GetTerminalPrinter().Write(ConvertPrintTemplate(obj, rows[i]));
                }
            }


        }

        public static void PrintGloabalSetting()
        {
            PrintTemplate(null, "GlobalHotPrinterSettings.txt");
        }

        public static void CloseHotPrinter()
        {
            if (GetTerminalPrinter() != null)
            GetTerminalPrinter().Close();
        }
    }
}
