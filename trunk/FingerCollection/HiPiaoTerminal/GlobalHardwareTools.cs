using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FT.Commons.Tools;
using HiPiaoInterface;

namespace HiPiaoTerminal
{
    public class GlobalHardwareTools
    {
        private static FT.Device.HotPrinter.HotPrinterImporter hotprinter;

        private static FT.Commons.Tools.LPTHelper lptHelper = new FT.Commons.Tools.LPTHelper();

        public static void OpenHotPrinter()
        {
            lptHelper.Open("lpt1");
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
            PrintTemplate(ticket, "TicketTemplate.txt");
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
                        lptHelper.Write(ConvertPrintTemplate(obj, rows[i]));
                }
            }


        }

        public static void PrintGloabalSetting()
        {
            PrintTemplate(null, "GlobalHotPrinterSettings.txt");
        }

        public static void CloseHotPrinter()
        {
            lptHelper.Close();
        }
    }
}
