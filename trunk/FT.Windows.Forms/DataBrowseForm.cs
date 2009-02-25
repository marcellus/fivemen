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
        /// 清理控件的值
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
        /// 数据实体
        /// </summary>
        private object entity;
    }
}