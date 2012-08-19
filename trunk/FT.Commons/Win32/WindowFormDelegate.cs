using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FT.Commons.Win32
{
    public class WindowFormDelegate
    {
        private WindowFormDelegate()
        {
        }

        public static void SetMainThreadHint(Label label, string msg)
        {
            if (label.InvokeRequired)
            {
                SetMainThreadHintLabelDelegate msgCallback = new SetMainThreadHintLabelDelegate(WindowFormDelegate.SetMainThreadHint);
                label.Invoke(msgCallback, new object[] {label, msg });
            }
            else
            {
                label.Text = msg;
            }
        }

        public static void AddControlTo(Control parent, Control child)
        {
            if (parent.InvokeRequired)
            {
                AddControlToDelegate msgCallback = new AddControlToDelegate(WindowFormDelegate.AddControlTo);
                parent.Invoke(msgCallback, new object[] { parent, child });
            }
            else
            {
                parent.Controls.Add(child);
            }
        }

        public static void RemoveControlFrom(Control parent, Control child)
        {
            if (parent.InvokeRequired)
            {
                RemoveControlToDelegate msgCallback = new RemoveControlToDelegate(WindowFormDelegate.RemoveControlFrom);
                parent.Invoke(msgCallback, new object[] { parent, child });
            }
            else
            {
                parent.Controls.Remove(child);
            }
        }
    }

    /// <summary>
    /// 移除控件委托
    /// </summary>
    /// <param name="str"></param>
    public delegate void RemoveControlToDelegate(Control parent, Control child);


    /// <summary>
    /// 添加控件委托
    /// </summary>
    /// <param name="str"></param>
    public delegate void AddControlToDelegate(Control parent, Control child);

    /// <summary>
    /// 设置主线程界面提示
    /// </summary>
    /// <param name="str"></param>
    public delegate void SetMainThreadHintDelegate(string msg);

    /// <summary>
    /// 设置主线程界面提示
    /// </summary>
    /// <param name="str"></param>
    public delegate void SetMainThreadHintLabelDelegate(Label label,string msg); 

}
