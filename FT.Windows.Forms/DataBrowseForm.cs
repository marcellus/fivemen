using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Forms
{
    public partial class DataBrowseForm : Form
    {
        public DataBrowseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����ؼ���ֵ
        /// </summary>
        /// <param name="ctr">The CTR.</param>
        protected void ClearControl(Control ctr)
        {
            int count = ctr.Controls.Count;

            if (count == 0)
            {
                if (ctr is TextBox)
                {
                    ((TextBox)ctr).Text = string.Empty;
                }
            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    ClearControl(tmp);
                }
            }
        }

        /// <summary>
        /// ����ʵ��
        /// </summary>
        private object entity;
    }
}