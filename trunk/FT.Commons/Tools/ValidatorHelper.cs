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