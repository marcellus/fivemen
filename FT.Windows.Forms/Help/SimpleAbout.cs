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

        #region �������Է�����

       

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
                // ��ȡ�˳��򼯵����� Description ����
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // ��� Description ���Բ����ڣ��򷵻�һ�����ַ���
                if (attributes.Length == 0)
                    return "";
                // ����� Description ���ԣ��򷵻ظ����Ե�ֵ
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
                // ��ȡ�˳����ϵ����� Copyright ����
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // ��� Copyright ���Բ����ڣ��򷵻�һ�����ַ���
                if (attributes.Length == 0)
                    return "";
                // ����� Copyright ���ԣ��򷵻ظ����Ե�ֵ
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