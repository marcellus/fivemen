using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;

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
                        //JobCountSinceLastReset
                        //Status : Error Status : Unknown
                        //PrinterState : 1026 PrinterStatus : 1
                        //PrinterState : 0 PrinterStatus : 3
                        printerNames.Add(pde.Current.Value.ToString());
                    }

                    //MessageBox.Show(pde.Current.Name + " : " + pde.Current.Value);
                    //显示的是 属性名 : 属性值 的形式
                }
            }
            return printerNames;
        }

        public static void DeleteAllSpooler()
        {
            //spool\PRINTERS
          //  System.Environment.SpecialFolder folder=System.Environment.SpecialFolder.System;
          // folder.
            string path = System.Environment.SystemDirectory;
            string spoolPath=System.IO.Path.Combine(path,"spool\\PRINTERS");
            Console.WriteLine("system-path:" + spoolPath);
            DirectoryInfo dir = new DirectoryInfo(spoolPath);
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
        }

        public static void CancelAllPrintJob()
        {
            // Variable declarations.            
           
            string searchQuery;
            ManagementObjectSearcher searchPrintJobs;
            ManagementObjectCollection prntJobCollection;
            try
            {
                // Query to get all the queued printer jobs.                
                searchQuery = "SELECT * FROM Win32_PrintJob";
                // Create an object using the above query.                
                searchPrintJobs = new ManagementObjectSearcher(searchQuery);
                // Fire the query to get the collection of the printer jobs.                
                prntJobCollection = searchPrintJobs.Get();
                // Look for the job you want to delete/cancel.                
                foreach (ManagementObject prntJob in prntJobCollection)
                {
                    prntJob.Delete();
                   
                }
                
            }
            catch (Exception sysException)
            {
                // Log the exception.    
                Console.WriteLine(sysException);
               
            }
        }

        public bool CancelPrintJob(int printJobID)
        {
            // Variable declarations.            
            bool isActionPerformed = false;
            string searchQuery;
            String jobName;
            char[] splitArr;
            int prntJobID;
            ManagementObjectSearcher searchPrintJobs;
            ManagementObjectCollection prntJobCollection;
            try
            {
                // Query to get all the queued printer jobs.                
                searchQuery = "SELECT * FROM Win32_PrintJob";
                // Create an object using the above query.                
                searchPrintJobs = new ManagementObjectSearcher(searchQuery);
                // Fire the query to get the collection of the printer jobs.                
                prntJobCollection = searchPrintJobs.Get();
                // Look for the job you want to delete/cancel.                
                foreach (ManagementObject prntJob in prntJobCollection)
                {
                    jobName = prntJob.Properties["Name"].Value.ToString();
                    // Job name would be of the format [Printer name], [Job ID]                    
                    splitArr = new char[1];
                    splitArr[0] = Convert.ToChar(",");
                    // Get the job ID.                    
                    prntJobID = Convert.ToInt32(jobName.Split(splitArr)[1]);
                    // If the Job Id equals the input job Id, then cancel the job.                    
                    if (prntJobID == printJobID)
                    {
                        // Performs a action similar to the cancel                        
                        // operation of windows print console                        
                        prntJob.Delete();
                        isActionPerformed = true;
                        break;
                    }
                }
                return isActionPerformed;
            }
            catch (Exception sysException)
            {
                // Log the exception.    
                Console.WriteLine(sysException);
                return false;
            }
        }

        public static PrinterStatus GetPrinterStat()
        {
            List<string> printers = WindowsPrinterHelper.LoopPrinter();

            return GetPrinterStat(printers[0]);
        }


        public static PrinterStatus GetPrinterStat(string PrinterDevice)
        {
            PrinterStatus ret = 0;
            string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
            ManagementObject printer = new ManagementObject(path);
            
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
