using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class SimpleAbout : DevExpress.XtraEditors.XtraForm
    {
        public SimpleAbout()
        {
            InitializeComponent();
            //FormHelper.InitHabitToForm(this);
            this.lbCopyRight.Text = this.AssemblyCopyright;
            this.lbDescription.Text = this.AssemblyDescription;
            this.lbProduct.Text=this.AssemblyProduct;
            this.lbVersion.Text = this.AssemblyVersion;
        }

        #region 程序集属性访问器

       

        public string AssemblyVersion
        {
            get
            {
                return Application.ProductVersion;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // 获取此程序集的所有 Description 属性
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // 如果 Description 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Description 属性，则返回该属性的值
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                return Application.ProductName;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // 获取此程序集上的所有 Copyright 属性
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // 如果 Copyright 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Copyright 属性，则返回该属性的值
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                return Application.CompanyName;
            }
        }
        #endregion

        private void SimpleAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}