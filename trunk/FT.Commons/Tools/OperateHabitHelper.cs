using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FT.Commons.Tools
{
    /// <summary>
    /// Window的一些操作习惯
    /// </summary>
    public class OperateHabitHelper : BaseHelper
    {
        /// <summary>
        /// 初始化所有控件的系统操作方式,按回车就焦点跳动
        /// </summary>
        /// <param name="frm">窗体</param>
        public static void InitHabitToForm(Form frm)
        {
            InitHabitToControl(frm);
        }
        /// <summary>
        /// 初始化所有控件的系统操作方式,按回车就焦点跳动
        /// </summary>
        /// <param name="ctr">控件</param>
        public static void InitHabitToControl(Control ctr)
        {
            if (ctr.Controls.Count == 0)
            {
                ctr.KeyDown += new KeyEventHandler(EnterToTab);
            }
            foreach (Control tmp in ctr.Controls)
            {
                InitHabitToControl(tmp);
            }
        }
        /// <summary>
        /// 控件按回车焦点跳动的操作习惯
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e"></param>
        public static void EnterToTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
        }
    }
}
