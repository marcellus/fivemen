/********************************************************************************
* File:ComboBoxHelper.cs
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
    ///Class <c>ComboBoxHelper</c>
    ///Description:下拉列表的选定
    ///</summary>
    public class ComboBoxHelper : BaseHelper
    {
        ///<summary>
        ///Initializes a new instance of the <see cref="FileDialogHelper"/> class.
        ///</summary>
        private ComboBoxHelper()
        {
        }

        /// <summary>
        /// 根据配置初始化ComboBox
        /// </summary>
        /// <param name="cb">The cb.</param>
        /// <param name="config">配置key，以;号分隔</param>
        public static void InitByConfiguration(ComboBox cb,string config)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.AddRange(System.Configuration.ConfigurationManager.AppSettings[config].Split(';'));
            cb.Items.Insert(0, "请选择");
            cb.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化ComboBox的基础数据类型
        /// </summary>
        /// <param name="cb">The cb.</param>
        public static void InitBaseDataType(ComboBox cb)
        {
            InitByConfiguration(cb, "BaseDataType");
        }

        /// <summary>
        /// 对Combox根据text进行选定如果没有找到就添加一个
        /// </summary>
        /// <param name="cb">The cb.</param>
        /// <param name="text">The text.</param>
        public static void SelectByText(ComboBox cb,string text)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                
                if (cb.Items[i].ToString() == text)
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
           cb.Items.Add(text);
           cb.SelectedIndex = cb.Items.Count - 1;
           //cb.SelectedItem = text;
        }
    }
}