using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using SKYPE4COMLib;

namespace FT.Commons.Tools
{
    public class SkypeHelper:BaseHelper
    {
        public static SkypeClass SkypeObj = null;

        private static bool IsSkypeRunning
        {
            get
            {
                const string processName = "Skype";
                foreach (Process process in Process.GetProcesses())
                    if (process.ProcessName == processName)
                        return true;

                return false;
            }
        }

        public static void HandOff()
        {
            CreateSkypeObject();
            //SkypeClass skype = new SkypeClass();
            CommandClass cmd = new CommandClass();
            cmd.Command = "SEARCH ACTIVECALLS";//搜尋ID
            SkypeObj.SendCommand(cmd);
            
            int id = SkypeObj.ActiveCalls[1].Id;
            cmd.Command = "SET CALL " + id + " STATUS FINISHED";//根據ID掛斷電話
            SkypeObj.SendCommand(cmd);
        }

        public static void Call(string mobile)
        {
            CreateSkypeObject();
            CallTimeLimitSeconds = -1;
            CommandClass cmd = new CommandClass();
           
            cmd.Command = "OPEN IM " + "拨号";//打開Skype視窗;
            SkypeObj.SendCommand(cmd);

            cmd.Command = "CALL " + mobile;//撥號
            SkypeObj.SendCommand(cmd);
        }

        private static TCallStatus[] failedStatus = new[] { TCallStatus.clsUnplaced, TCallStatus.clsFailed, TCallStatus.clsRefused, TCallStatus.clsCancelled, TCallStatus.clsFinished, TCallStatus.clsBusy };

        static void SkypeObj__ISkypeEvents_Event_CallStatus(Call pCall, TCallStatus Status)
        {
#if DEBUG
            Console.WriteLine("通话时长为："+pCall.Duration);
            Console.WriteLine("SkypeObj__ISkypeEvents_Event_CallStatus" + System.DateTime.Now.ToShortTimeString() + "当前状态为：" + Status.ToString());
#endif
            foreach (TCallStatus status in failedStatus)
            {
                if (Status == status)
                {
                    HandOff();
                }
            }
         
          //  pCall.
           
        }

        private static System.Timers.Timer timer;

        private static int CallTimeLimitSeconds = -1;

        public static void CallTimeLimit(string mobile, int senconds)
        {
            if (timer != null)
            {
                //timer.Stop();
            }
            else
            {
           
                timer = new System.Timers.Timer();
                timer.Interval =  1000;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
            CreateSkypeObject();
            CallTimeLimitSeconds = senconds;
            CommandClass cmd = new CommandClass();
            //cmd.Command = "OPEN IM " + "拨号";//打開Skype視窗;
            //SkypeObj.SendCommand(cmd);

            cmd.Command = "CALL " + mobile;//撥號
            SkypeObj.SendCommand(cmd);
           
           // timer.Start();
        }

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           // timer.Stop();
#if DEBUG
            if(SkypeObj.ActiveCalls.Count>0)
            {
                Console.WriteLine("timer_Elapsed" + System.DateTime.Now.ToShortTimeString() + "当前状态为：" + SkypeObj.ActiveCalls[1].Status.ToString());
            }
#endif
            if (CallTimeLimitSeconds != -1&&SkypeObj.ActiveCalls.Count>0 && SkypeObj.ActiveCalls[1].Duration == CallTimeLimitSeconds
                )
            {
                
                HandOff();
            }
           
        }

        static void skype__ISkypeEvents_Event_Command(Command pCommand)
        {
           
        }

        static void skype__ISkypeEvents_Event_Command2(Command pCommand)
        {
           
        }


        private static bool StartSkype()
        {
            if (!IsSkypeRunning)
            {
                try
                {
                    SkypeObj.Client.Start(true, true);
                    System.Threading.Thread.Sleep(7000);
                    return true;
                }
                catch (Exception ex)
                {
                    log.Info("启动Skype客户端出错！"+ex);
                    return false;
                }
            }
            return true;
        }

        private static bool CreateSkypeObject()
        {
            if (SkypeObj != null)
            {
                return true;
            }
           
            try
            {
                SkypeObj = new SkypeClass();
                SkypeObj._ISkypeEvents_Event_CallStatus += new _ISkypeEvents_CallStatusEventHandler(SkypeObj__ISkypeEvents_Event_CallStatus);
                SkypeObj._ISkypeEvents_Event_Command += new _ISkypeEvents_CommandEventHandler(skype__ISkypeEvents_Event_Command);
                StartSkype();
                return true;
            }
            catch (Exception ex)
            {

                log.Info("创建Skype对象出错！" + ex.ToString());
                
            }

            if (SkypeObj == null)
            {
                try
                {
                    RegisterComObject(System.Windows.Forms.Application.StartupPath + "\\Skype4COM");
                    SkypeObj = new SkypeClass();
                    SkypeObj._ISkypeEvents_Event_CallStatus += new _ISkypeEvents_CallStatusEventHandler(SkypeObj__ISkypeEvents_Event_CallStatus);
                    SkypeObj._ISkypeEvents_Event_Command += new _ISkypeEvents_CommandEventHandler(skype__ISkypeEvents_Event_Command);
                    StartSkype();
                    return true;
                }
                catch (Exception ex)
                {
                    string msg = "Skype4COM.dll is not registered as COM DLL.\n" + ex.ToString();
                    log.Info(msg);
                    return false;
                    // MessageBox.Show(msg, WF.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }


        static SkypeHelper()
        {
            CreateSkypeObject();
        }

        private static void RegisterComObject(string comDllName)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo("regsvr32.exe", string.Format("/s {0}.dll", comDllName));
            process.Start();
            process.WaitForExit();
        }
    }
}
