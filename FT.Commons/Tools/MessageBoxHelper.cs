/********************************************************************************
* File:MessageBoxHelper.cs
* Author:austin chen
* Date:2008-4-14
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
    ///Class <c>MessageBoxHelper</c>
    ///Description:弹出消息框辅助类
    ///</summary>
    public class MessageBoxHelper : BaseHelper
    {
        ///<summary>
        ///Initializes a new instance of the <see cref="MessageBoxHelper"/> class.
        ///</summary>
        private MessageBoxHelper()
        {
        }

        public static Color PickColor()
        {
            Color result = SystemColors.Control;
            ColorDialog form = new ColorDialog();
            if (DialogResult.OK == form.ShowDialog())
            {
                result = form.Color;
            }
            return result;
        }

        public static Color PickColor(Color color)
        {
            Color result = SystemColors.Control;
            ColorDialog form=new ColorDialog();
            form.Color=color;
            if(DialogResult.OK==form.ShowDialog())
            {
                result = form.Color;
            }
            return result;
        }

        /// <summary>
        /// 判断是否正确响应
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <returns>如果点击了是返回true</returns>
        public static bool Confirm(string text)
        {
          // DialogResult result= MessageBox.Show(text, "窗体消息提示", MessageBoxButtons.YesNo);
            CustomConfirmBox form = new CustomConfirmBox(text);
            DialogResult result = form.ShowDialog();
            return DialogResult.Yes == result;
        }

        /// <summary>
        /// 提示文本
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="caption">提示窗口的标题</param>
        private static void ShowMessage(string text,string caption)
        {
            CustomMessageBox form = new CustomMessageBox(text, caption);
            form.ShowDialog();
           // MessageBox.Show(text,caption);
        }

        /// <summary>
        /// 数据库提示窗口
        /// </summary>
        /// <param name="text">提示文本</param>
        public static void ShowDb(string text)
        {
            ShowMessage(text, "数据库消息提示");
        }

        /// <summary>
        /// 打印时候的提示窗口
        /// </summary>
        /// <param name="text">提示文本</param>
        public static void ShowPrinter(string text)
        {
            ShowMessage(text, "打印消息提示");
        }


        /// <summary>
        /// 普通的窗口提示
        /// </summary>
        /// <param name="text">提示文本</param>
        public static void Show(string text)
        {
            ShowMessage(text,"窗口消息提示");
        }
    }
}