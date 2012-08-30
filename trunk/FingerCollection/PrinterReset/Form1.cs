using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
//using System.Printing;
using FT.Commons.Tools;

namespace PrinterReset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            LocalPrintServer server = new LocalPrintServer();
            this.txtLog.Text = server.DefaultSpoolDirectory+"\r\n";
            PrintQueueCollection myPrintQueues = server.GetPrintQueues();
            //server.
            
            String printQueueNames = "My Print Queues:\r\n";
            foreach (PrintQueue pq in myPrintQueues)
            {
                printQueueNames += "\r\n" + pq.Name ;
                try
                {
                    Console.WriteLine("pq is "+pq.FullName);
                   // pq.AddJob("test");
                    ReflectHelper.WriteObjectProperty(pq);
                    PrintJobInfoCollection allPrintJobs = pq.GetPrintJobInfoCollection();
                    
                    foreach (PrintSystemJobInfo printJob in allPrintJobs)
                    {
                        printQueueNames += "\r\n job-name:" + printJob.Name;
                        if (printJob.TimeJobSubmitted < System.DateTime.Now.AddSeconds(10))
                        {
                            printJob.Cancel();
                        }
                        ReflectHelper.WriteObjectProperty(printJob);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this.txtLog.Text += printQueueNames;
             * */

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
           PrinterStatus status= WindowsPrinterHelper.GetPrinterStat();
           this.txtLog.AppendText("\r\n获取打印机状态结果为："+status.ToString());
           if (status == PrinterStatus.其他状态)
           {
               this.txtLog.AppendText("\r\n开始停止所有打印作业");
               WindowsPrinterHelper.CancelAllPrintJob();
               this.txtLog.AppendText("\r\n成功停止所有打印作业");
               this.txtLog.AppendText("\r\n成功复位打印机，请检查是否可用！");
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrinterStatus status = WindowsPrinterHelper.GetPrinterStat();
            this.txtLog.AppendText("\r\n获取打印机状态结果为：" + status.ToString());
            if (status == PrinterStatus.其他状态)
            {
                string service = "Spooler";
                //spool\PRINTERS
                this.txtLog.AppendText("\r\n开始停止打印服务");
                WindowServicesHelper.ForceStop(service);
                this.txtLog.AppendText("\r\n成功停止打印服务，请等待4-5秒");
                System.Threading.Thread.Sleep(3000);
                this.txtLog.AppendText("\r\n开始删除打印缓存");
                WindowsPrinterHelper.DeleteAllSpooler();
                this.txtLog.AppendText("\r\n开始启动打印服务");
                WindowServicesHelper.ForceStart(service);
                this.txtLog.AppendText("\r\n成功启动打印服务");
                this.txtLog.AppendText("\r\n成功复位打印机，请检查是否可用！");
            }
            
        }
    }
}
