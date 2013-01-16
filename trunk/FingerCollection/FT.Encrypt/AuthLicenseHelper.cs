using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FT.AuthLicense
{
    public class AuthLicenseHelper
    {
        private static readonly string LicenseFileNameFormatter = "c:\\ft-{0}-licenses.lic";

        private static string GetLicenseRightCode(string app)
        {
            return "license"+app;
        }

        public static string CheckLicense(string app,int terminalNum, int userNum)
        {
            string result = string.Empty;
            string filename = string.Format(LicenseFileNameFormatter, app);
            if (!File.Exists(filename))
            {
                result = "未找到授权文件" + filename + "，请联系软件开发商！！";
            }
            else
            {
                AuthLicenseObject license = GetLicense(app);
                if (GetLicenseRightCode(app) != license.RightCode)
                {
                    result = app+"的授权码错误！！";
                }
                else if (license.TerminalNum != -1)
                {
                    if (license.TerminalNum < terminalNum)
                    {
                        result = app + "的终端授权数量超出范围！！";
                    }
                }
                else if (license.UserNum != -1)
                {
                    if (license.UserNum < userNum)
                    {
                        result = app + "的用户授权数量超出范围！！";
                    }
                }
            }
            return result;
        }
        public static AuthLicenseObject GetLicense(string app)
        {
            string filename = string.Format(LicenseFileNameFormatter, app);
            Debug("开始从文件->" + filename + "-反序列化");
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            AuthLicenseObject obj = null;
            try
            {
                stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                obj = (AuthLicenseObject)formatter.Deserialize(stream);
                stream.Close();
                Debug("从文件反序列化成功！");
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
                Debug(ex.ToString());
                //throw ex;
            }
            return obj;
        }

        private static void Debug(string str)
        {
#if DEBUG
            Console.WriteLine(str);
#endif
        }

       

        public static void CreateLicenseFile(AuthLicenseObject license)
        {
            string filename = string.Format(LicenseFileNameFormatter, license.AppName);
            Debug("开始序列化到文件->" + filename);
            Stream stream = null;
            try
            {

                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, license);
                stream.Close();
                Debug("序列化到文件完毕！");
                
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
                Debug(ex.ToString());
               
            }
        }
    }
}
