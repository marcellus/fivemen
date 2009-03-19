/********************************************************************************
* File:ValidatorHelper.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace FT.Commons.Tools
{
    ///<summary>
    ///Class <c>ValidatorHelper</c>
    ///Description:window下的数据验证
    ///</summary>
    public class ValidatorHelper : BaseHelper
    {
        ///<summary>
        ///Initializes a new instance of the <see cref="ValidatorHelper"/> class.
        ///</summary>
        private ValidatorHelper()
        {
        }
        #region 一些常用的验证工具
        public static bool ValidateMobile(string text,bool allowBlank)
        {
            return ValidateRegex(text, allowBlank, @"^0?[1][35][0-9]{9}$");
        }
        public static bool ValidatePhone(string text, bool allowBlank)
        {
            //^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$
            //^((0[1-9]{3})?(0[12][0-9])?[-])?\d{6,8}$
            return ValidateRegex(text, allowBlank, @"^(\d{3,4}-)?\d{7,8}$");
            
        }

        public static bool ValidatePhoneOrMobile(string text, bool allowBlank)
        {
            //^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$
            //^((0[1-9]{3})?(0[12][0-9])?[-])?\d{6,8}$
            return ValidatePhone(text, allowBlank) || ValidateMobile(text,allowBlank);

        }

        public static bool ValidatePostCode(string text, bool allowBlank)
        {
            return ValidateRegex(text, allowBlank, @"^\d{6}$");
        }

        

        public static bool ValidateEmail(string text, bool allowBlank)
        {
            return ValidateRegex(text, allowBlank, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public static bool ValidateUrl(string text, bool allowBlank)
        {
            //
            //^(http|https|ftp):\/\/(([A-Z0-9][A-Z0-9_-]*)(\.[A-Z0-9][A-Z0-9_-]*)+)(:(\d+))?\/?/i
            return ValidateRegex(text, allowBlank, @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$");
        }
        public static bool ValidateNumber(string text, bool allowBlank)
        {
            return ValidateRegex(text, allowBlank, @"^[\d\.]+$");
        }
        public static bool ValidateChinese(string text, bool allowBlank)
        {
            return ValidateRegex(text, allowBlank, @"^[\u4e00-\u9fa5]+$");
        }
        public static bool ValidateAlapha(string text, bool allowBlank)
        {
            return ValidateRegex(text, allowBlank, @"^[a-zA-Z]+$");
        }
        public static bool ValidateIp(string text, bool allowBlank)
        {
            //@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"
            return ValidateRegex(text, allowBlank, @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        }
        /// <summary>
        /// 验证成功返回true
        /// </summary>
        /// <param name="text"></param>
        /// <param name="allowBlank"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool ValidateRegex(string text, bool allowBlank, string pattern)
        {
            text = text.Trim();
            if (allowBlank && text.Length == 0)
            {
                return true;

            }
            else if (text.Length == 0)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(text, pattern);

            }
        }
        #endregion

        /// <summary>
        ///验证TextBox非空
        /// </summary>
        /// <param name="tb">TextBox</param>
        /// <returns>非空返回true</returns>
        private static bool ValidateTextBox(TextBox tb)
        {
            return tb.Text.Trim() != string.Empty;
        }

        /// <summary>
        ///验证ComboxBox选择文本不是“请选择”
        /// </summary>
        /// <param name="tb">ComboxBox</param>
        /// <returns>如果选择文本不是“请选择”返回true</returns>
        private static bool ValidateComboBox(ComboBox cb)
        {
            return cb.Text.ToString()!="请选择";
            //cb.SelectedIndex!=-1&&
        }

        /// <summary>
        /// 验证所有的控件
        /// </summary>
        /// <param name="ctr">被验证控件</param>
        /// <returns>失败返回false，成功返回true</returns>
        public static bool Validate(Control ctr)
        {
            if (ctr is TextBox)
            {
                return ValidateTextBox((TextBox)ctr);
               
            }
            if (ctr is ComboBox)
            {
                return ValidateComboBox((ComboBox)ctr);
            }

            return false;
        }

        /// <summary>
        /// 验证所有的控件,如果失败弹出信息并重定位焦点
        /// </summary>
        /// <param name="ctr">被验证控件</param>
        /// <param name="message">验证失败弹出的消息</param>
        /// <returns>失败返回false，成功返回true</returns>
        public static bool Validate(Control ctr, string message)
        {
            bool result = Validate(ctr);
            if (!result)
            {
                MessageBoxHelper.Show(message);
                ctr.Focus();
            }
            return result;
        }


        /// <summary>
        /// 验证Text是否是数字,如果失败弹出信息并重定位焦点
        /// </summary>
        /// <param name="ctr">被验证控件</param>
        /// <param name="message">验证失败弹出的消息</param>
        /// <returns>失败返回false，成功返回true</returns>
        public static bool ValidateNum(TextBox ctr, string message)
        {
            bool result=false;
            string val = ctr.Text.Trim();
            if (val.Length > 0)
            {
                try
                {
                    decimal d = Convert.ToDecimal(val);
                    result=true;
                }
                catch
                {
                    ctr.Text = string.Empty;
                    result=false;
                }
            }
            if (!result)
            {
                MessageBoxHelper.Show(message);
                ctr.Focus();
            }
            return result;
        }
    }
}