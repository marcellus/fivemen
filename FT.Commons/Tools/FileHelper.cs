using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using log4net;
using FT.Commons.Security;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 文件操作辅助类
    /// </summary>
    public class FileHelper : BaseHelper
    {
       

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)] 
        internal static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        /// <summary>
        /// 获取所有用户的路径，类似C:\Documents and Settings\All Users
        /// </summary>
        /// <returns></returns>
        public static string GetAllUserPath()
        {
            StringBuilder lpszPath = new StringBuilder(260);
            SHGetFolderPath(IntPtr.Zero, (int)0x23, IntPtr.Zero, 0, lpszPath);
            string path = lpszPath.ToString();
            
            return path;
        }

        /// <summary>
        /// 清空所有摄像头捕获的照片
        /// </summary>
        public static void ClearCapturePhotoes()
        {
            DirectoryInfo inf = new DirectoryInfo(GetAllUserPath() + "\\Microsoft\\WIA");
            
            if (!inf.Exists)
                inf.Create();
            else
            {
                inf.Delete(true);
            }
        }

        public FileHelper()
        {
        }

        /// <summary>
        /// 删除隐藏的使用时间信息
        /// </summary>
        /// <param name="program">程序名</param>
        public static void ClearLastLog(string program)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + program + ".log";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 创建文件路径
        /// </summary>
        /// <param name="program">程序名</param>
        public static void CreateLastFile(string program)
        {
            string path=System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\"+program+".log";
            log.Debug("创建文件路径："+path);
            if (!File.Exists(path))
            {
                FileStream fs=File.Create(path);
                fs.Close();
            }
        }

        /// <summary>
        /// 读取系统返回的时间
        /// </summary>
        /// <param name="program">程序名</param>
        /// <returns>返回时间</returns>
        public static string ReadLastLog(string program)
        {
            string result = string.Empty;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + program + ".log";
            CreateLastFile(program);
            StreamReader reader=null;
            System.IO.FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                reader = new StreamReader(fs);

                result = SecurityFactory.GetSecurity().Decrypt(reader.ReadLine());
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {

                if (reader != null)
                    reader.Close();

                fs.Close();
            }
            return result;
        }

        /// <summary>
        /// 写最后登陆的日期到隐藏目录下
        /// </summary>
        /// <param name="program">程序名</param>
        public static void WriteLastLog(string program)
        {
            string path=System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\"+program+".log";
            CreateLastFile(program);
            StreamWriter streamWriter=null;
            try
            {
                streamWriter = new StreamWriter(path,false);
                streamWriter.WriteLine(SecurityFactory.GetSecurity().Encrypt(System.DateTime.Now.ToShortDateString()));
                streamWriter.Flush();
                
            }
            catch(Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }
    }
}
