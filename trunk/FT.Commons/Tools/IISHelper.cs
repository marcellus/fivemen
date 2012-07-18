using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices; // 添加引用 System.DirectoryServices

namespace FT.Commons.Tools
{
    public class IISHelper:BaseHelper
    {
        public static bool StartAppPools(string poolName)
        {
            return SendCommandToAppPools("Start", poolName);
        }

        public static bool StopAppPools(string poolName)
        {
            return SendCommandToAppPools("Stop", poolName);
        }

        public static bool RecycleAppPools(string poolName)
        {
            return SendCommandToAppPools("Recycle", poolName);
        }

        public static bool SendCommandToAppPools(string cmd,string poolName)
        {
            bool result = false;
            try
            {
                //DefaultAppPool
                DirectoryEntry appPool = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
                DirectoryEntry findPool = appPool.Children.Find(poolName, "IIsApplicationPool");
                findPool.Invoke(cmd, null);     // Start|Stop|Recycle [Recycle:应用程序池回收，如果状态为Stop会报错]
                appPool.CommitChanges();
                appPool.Close();
                result = true;
                //Response.Write("DefaultAppPool 操作成功！");
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                result = false;
                //Response.Write("DefaultAppPool 未找到！");
            }
            return result;

        }
    }
}




 
