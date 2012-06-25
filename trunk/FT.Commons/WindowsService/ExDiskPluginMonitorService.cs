using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.WindowsService
{
    /// <summary>
    /// U盘插入监听服务
    /// </summary>
    public class ExDiskPluginMonitorService:BaseWindowService
    {

        private string allowDisks = "C";

        public ExDiskPluginMonitorService(string allowDisks, int interval)
            : base(interval)
        {
            
            this.allowDisks = allowDisks;
        }


        public  override bool DoTask()
        {
            //throw new NotImplementedException();
            bool result = true;
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            for(int i=0;i<drives.Length;i++)
            {
                if (allowDisks.IndexOf(drives[i].Name.Replace(":\\", "")) == -1)
                {
                    if (drives[i].DriveType == System.IO.DriveType.CDRom)
                    {
                        
                        if (drives[i].IsReady&&drives[i].RootDirectory.GetDirectories().Length > 0)
                        {
                            result = false;
                            this.Beep();
                            string log = "插入可移动的光盘盘驱动器盘符为->" + drives[i].Name;
                            this.Log(MonitorLogType.ExDiskWatch, log);
                            this.Sms(log);
                        }
                    }
                    else if (drives[i].DriveType == System.IO.DriveType.Removable)
                    {
                        result = false;
                        this.Beep();
                        string log = "插入可移动的磁盘驱动器盘符为->" + drives[i].Name;
                        this.Log(MonitorLogType.ExDiskWatch, log);
                        this.Sms(log);
                    }
                    else if (drives[i].DriveType == System.IO.DriveType.Unknown)
                    {
                        result = false;
                        this.Beep();
                        string log = "插入未知的驱动器盘符为->" + drives[i].Name;
                        this.Log(MonitorLogType.ExDiskWatch, log);
                        this.Sms(log);
                    }
                    else if (drives[i].DriveType == System.IO.DriveType.Network)
                    {
                        result = false;
                        this.Beep();
                        string log = "插入未知的网络驱动器盘符为->" + drives[i].Name;
                        this.Log(MonitorLogType.ExDiskWatch, log);
                        this.Sms(log);
                    }
                    else if (drives[i].DriveType == System.IO.DriveType.Fixed)
                    {
                        result = false;
                        this.Beep();
                        string log = "插入未知的硬盘驱动器盘符为->" + drives[i].Name;
                        this.Log(MonitorLogType.ExDiskWatch, log);
                        this.Sms(log);

                    }
                }

            }
            return result;
            
        }

        protected override void SetServiceName()
        {
            //throw new NotImplementedException();
            this.SetServiceName(MonitorLogType.ExDiskWatch);
            //this.ServiceName = "外设存储器插入监控服务";
        }
    }
}
