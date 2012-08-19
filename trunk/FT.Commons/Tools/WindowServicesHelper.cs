using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Net;

namespace FT.Commons.Tools
{
    public class WindowServicesHelper:BaseHelper
    {
        public static ServiceController GetService(string service)
        {
            ServiceController[] sers;
            sers = ServiceController.GetServices(Dns.GetHostName());
            ServiceController ser;
            for (int i = 0; i < sers.Length; i++)
            {
                ser = sers[i];
                if (sers[i].ServiceName.ToString() == service)
                {
                    log.Debug("匹配到服务名："+service);
                    return ser;
                }
            }
            return null;
        }

        public static void Stop(ServiceController ser)
        {
            if (ser != null && (ser.Status != ServiceControllerStatus.Stopped || ser.Status != ServiceControllerStatus.StopPending))
                ser.Stop();//ser.Pause();暂停         ser.Start();启动 
        }

        public static void ForceStart(string service)
        {
            ServiceController ser = GetService(service);
            ForceStart(ser);
        }

        public static void ForceStart(ServiceController ser)
        {
            try
            {
                log.Debug("开始强制启动服务：" + ser.ServiceName);
                ser.Start();//ser.Pause();暂停         ser.Start();启动 
                log.Debug("强制启动服务：" + ser.ServiceName+"，成功！");
            }
            catch (Exception ex)
            {
                log.Info(ex);
            }
        }



        public static void ForceStop(ServiceController ser)
        {
            try
            {
                log.Debug("开始强制停止服务：" + ser.ServiceName);
                ser.Stop();//ser.Pause();暂停         ser.Start();启动 
                log.Debug("强制停止服务：" + ser.ServiceName + "，成功！");
            }
            catch (Exception ex)
            {
                log.Info(ex);
            }
        }

        public static void ForceStop(string service)
        {
            ServiceController ser = GetService(service);
            ForceStop(ser);
        }



        public static void Stop(string service)
        {
            ServiceController ser = GetService(service);
            Stop(ser);
        }

        public static string GetServiceState(string service)
        {
            ServiceController ser = GetService(service);
            return TransServiceState(ser);
         
        }

        public static string TransServiceState(ServiceController control)
        {
            int state = (int)control.Status;
            string result = string.Empty;
            switch (state)
            {
                case 1:
                    result = "已停止";
                    break;
                case 4:
                    result = "正在运行";
                    break;
                case 7:
                    result = "已暂停";
                    break;
                default:
                    result = "中间状态";
                    break;


            }
            return result;
            //services[i].Status
        }

        public static void Pause(ServiceController ser)
        {
            if (ser != null && ser.Status == ServiceControllerStatus.Running)
                ser.Pause();//ser.Pause();暂停   
        }


        public static void Pause(string service)
        {
            ServiceController ser = GetService(service);
            Pause(ser);

        }

        public static void Start(ServiceController ser)
        {
            if (ser != null && (ser.Status != ServiceControllerStatus.Running || ser.Status != ServiceControllerStatus.StartPending))
                ser.Start();//ser.Pause();暂停         ser.Start();启动 
        }


        public static void Start(string service)
        { 
            ServiceController ser = GetService(service);
            Start(ser);
           

        }
    }
}
