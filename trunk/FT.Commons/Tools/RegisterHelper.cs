/********************************************************************************
* File:RegisterHelper.cs
* Author:austin chen
* Date:2008-4-22
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Design;
using System.ComponentModel;
using Microsoft.Win32;
using FT.Commons.Security;


namespace FT.Commons.Tools
{
    ///<summary>
    ///Class <c>RegisterHelper</c>
    ///Description:注册表操作帮助类
    ///</summary>
    public class RegisterHelper : BaseHelper
    {
        private static ISecurity md5 = new MD5Security();
        ///<summary>
        ///Initializes a new instance of the <see cref="RegisterHelper"/> class.
        ///</summary>
        private RegisterHelper()
        {
        }
        /// <summary>
        /// 重新设置使用开始日期
        /// </summary>
        /// <param name="program">程序名</param>
        /// <param name="regdate">日期</param>
        public static void ResetRegDate(string program, DateTime regdate)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey rkSub = rk.OpenSubKey(program, true);
            if (rkSub == null)
            {
                rk.CreateSubKey(program);
                rkSub = rk.OpenSubKey(program, true);

                // return false;
            }
            Object obj = rkSub.GetValue("regdate");
            rkSub.SetValue("regdate", SecurityFactory.GetSecurity().Encrypt(regdate.ToShortDateString()));
            rkSub.Close();
            rk.Close();
        }

        /// <summary>
        /// 返回一个注册系统的剩余试用天数
        /// </summary>
        /// <param name="program">程序名</param>
        /// <param name="total">总试用天数</param>
        /// <returns>剩余试用天数</returns>
        public static int GetLeaveDays(string program,int total)
        {
            string regdate = GetRegDate(program);
            DateTime reg = Convert.ToDateTime(regdate);
            DateTime now = System.DateTime.Now;
            TimeSpan ts = now - reg;
            return total-ts.Days;
        }

        /// <summary>
        /// 判断时间是否有效
        /// </summary>
        /// <param name="program">程序名</param>
        /// <returns>有效返回true，否则false</returns>
        public static bool ValidateDate(string program,double days)
        {
           
            string lastdate = GetLastDate(program);
            string filelastdate = FileHelper.ReadLastLog(program);
            if (lastdate != filelastdate)
            {
                MessageBoxHelper.Show("时间被篡改！");
                return false;
            }
            string regdate = GetRegDate(program);
            DateTime reg = Convert.ToDateTime(regdate);
            DateTime last = Convert.ToDateTime(lastdate);
            DateTime now = System.DateTime.Now;
            if (reg > now||last>now||reg>last)
            {
                MessageBoxHelper.Show("时间被篡改！");
                return false;
            }
            if (now > reg.AddDays(days))
            {
                MessageBoxHelper.Show("超出试用时间" + days + "天，请联系产品销售商！");
                return false;
            }
            return true;
          
        }

        /// <summary>
        /// 判断是否过期
        /// </summary>
        /// <param name="program">系统名称</param>
        /// <param name="days">有效天数</param>
        /// <returns>如果有效就返回真，否则为假</returns>
        private static bool ValidateExpire(string program,double days)
        {
            String regdate = GetRegDate(program);
            if (regdate != string.Empty)
            {
                DateTime reg = Convert.ToDateTime(regdate);
                if (System.DateTime.Now < reg.AddDays(days))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="program">系统名称</param>
        /// <returns>如果存在就读取时间，否则就返回空字符串</returns>
        public static String GetDateTime(string program,string key)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey rkSub = rk.OpenSubKey(program);
            if (rkSub == null)
            {
                //rk.CreateSubKey(program);
                //rkSub = rk.OpenSubKey(program);
                //return System.DateTime.Now;
                return string.Empty;
            }
            Object obj = rkSub.GetValue(key);
            if (obj != null)
            {

                rkSub.Close();
                rk.Close();
                return SecurityFactory.GetSecurity().Decrypt(obj.ToString());
                //rkSub.SetValue("regdate", System.DateTime.Now.ToShortDateString());
            }
            rkSub.Close();
            rk.Close();
            return string.Empty;
        }


        /// <summary>
        /// 创建时间
        /// </summary>
        /// <param name="program">程序名称.</param>
        /// <param name="key">键值</param>
        /// <param name="cover">是否覆盖原键值</param>
        public static void CreateDateTime(string program,string key,bool cover)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey rkSub = rk.OpenSubKey(program, true);
            if (rkSub == null)
            {
                rk.CreateSubKey(program);
                rkSub = rk.OpenSubKey(program, true);

                // return false;
            }
            Object obj = rkSub.GetValue(key);
            if(cover)
            {
                rkSub.SetValue(key, SecurityFactory.GetSecurity().Encrypt(System.DateTime.Now.ToShortDateString()));
            }
            else if (obj == null)
            {
                rkSub.SetValue(key, SecurityFactory.GetSecurity().Encrypt(System.DateTime.Now.ToShortDateString()));
            }
           
            rkSub.Close();
            rk.Close();
            //return false;
        }

        /// <summary>
        /// 获取最后一次使用时间
        /// </summary>
        /// <param name="program">系统名称</param>
        /// <returns>如果存在就读取时间，否则就返回空字符串</returns>
        public static String GetLastDate(string program)
        {
            return GetDateTime(program, "lastdate");
        }


        /// <summary>
        /// 创建最后一次使用时间
        /// </summary>
        /// <param name="programe">程序时间</param>
        /// <param name="key">键值</param>
        public static void CreateLastDate(string program)
        {
            CreateDateTime(program, "lastdate",true);
        }

        /// <summary>
        /// 获取注册时间
        /// </summary>
        /// <param name="program">系统名称</param>
        /// <returns>如果存在就读取时间，否则就返回空字符串</returns>
        public static String GetRegDate(string program)
        {
            return GetDateTime(program, "regdate");
        }


        /// <summary>
        /// 创建注册时间
        /// </summary>
        /// <param name="programe">程序时间</param>
        /// <param name="key">键值</param>
        public static void CreateRegDate(string program)
        {
            CreateDateTime(program, "regdate",false);
        }

        /// <summary>
        /// 根据程序名进行创立键值
        /// </summary>
        /// <param name="program">程序名</param>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public static void CreateProgramKey(string program,string key,string value)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software", RegistryKeyPermissionCheck.ReadWriteSubTree);
            
            //rk.DeleteSubKey(program, false);
           
                //rk.Close();
            RegistryKey rkSub = rk.OpenSubKey(program, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (rkSub == null)
            {
                rk.CreateSubKey(program);
                rkSub = rk.OpenSubKey(program, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            rkSub.SetValue(key, value);
            rkSub.Close();
            rk.Close();
        }

        /// <summary>
        /// 根据程序名进行注册
        /// </summary>
        /// <param name="program">程序名</param>
        /// <param name="keycode">注册码.</param>
        public static void CreateKeyCode(string program, string keycode)
        {
            CreateProgramKey(program, "keycode", keycode);
        }

        /// <summary>
        /// 根据程序名进行授权
        /// </summary>
        /// <param name="program">程序名</param>
        /// <param name="rightcode">授权码</param>
        public static void CreateRightCode(string program, string rightcode)
        {
            CreateProgramKey(program, "rightcode", rightcode);
        }


        /// <summary>
        /// 判断是否有效注册码
        /// </summary>
        /// <param name="keycode">注册码</param>
        /// <returns>如果有效返回true</returns>
        public static bool ValidateKeyCode(string keycode)
        {
            string need = md5.Encrypt(SecurityFactory.GetSecurity().Encrypt(HardwareManager.GetMachineCode()));
            return need == keycode;
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="encode">需要加密的字符串</param>
        /// <returns>加密后的结果</returns>
        private static string Encrypt(string encode)
        {
            return md5.Encrypt(encode);
        }

        /// <summary>
        /// 判断程序是否已注册
        /// </summary>
        /// <param name="program">程序名称</param>
        /// <returns>如果已注册返回true，未注册返回false</returns>
        public static  ProgramState ValidateProgram(string program)
        {
            string keycode = GetKeyCode(program);
            string rightcode = GetRightCode(program);
            if (rightcode == string.Empty)
            {
                return ProgramState.None;
            }
            if (keycode == string.Empty)
            {
                return ProgramState.Trial;
            }
            else
            {
                return ProgramState.Registed;
            }
        }

        /// <summary>
        /// 获取程序的key的值
        /// </summary>
        /// <param name="program">程序名</param>
        /// <param name="key">key</param>
        /// <returns>key具体的值</returns>
        public static string GetProgramKey(string program, string key)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey rkSub = rk.OpenSubKey(program);
            if (rkSub == null)
            {
                return string.Empty;
            }
            Object obj = rkSub.GetValue(key);
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty ;
        }

        /// <summary>
        /// 获取程序的授权码
        /// </summary>
        /// <param name="program">程序名</param>
        /// <returns>授权码</returns>
        public static string GetRightCode(string program)
        {
            return GetProgramKey(program, "rightcode");
        }


        /// <summary>
        /// 获取程序的注册码
        /// </summary>
        /// <param name="program">程序名</param>
        /// <returns>注册码</returns>
        public static string GetKeyCode(string program)
        {
            return GetProgramKey(program, "keycode");
        }

        /// <summary>
        /// 设置是否让程序自动启动
        /// </summary>
        /// <param name="program">程序名</param>
        public static void SetAutoStart(string program)
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue(program, Application.ExecutablePath);
            reg.Close();   
        }

        /// <summary>
        /// 删除程序自动启动
        /// </summary>
        /// <param name="program">程序名</param>
        public static void ClearAutoStart(string program)
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.DeleteValue(program);
            reg.Close();
        }
    }
}