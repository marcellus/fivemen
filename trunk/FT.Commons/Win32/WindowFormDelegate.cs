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

        public delegate void StringHandler(string info);

        public delegate void ByteHandler(byte info);

        public static object GetControlProperty(Control ctr, string property)
        {
            if (ctr.InvokeRequired)
            {
                GetControlPropertyDelegate msgCallback = new GetControlPropertyDelegate(WindowFormDelegate.GetControlProperty);
                return ctr.Invoke(msgCallback, new object[] { ctr, property });
            }
            else
            {
                return FT.Commons.Tools.ReflectHelper.GetObjectPropertyObject(ctr, property);
            }
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

        public static void AddMainThreadHintText(TextBox txt, string msg)
        {
            if (txt.InvokeRequired)
            {
                AddMainThreadHintTextDelegate msgCallback = new AddMainThreadHintTextDelegate(WindowFormDelegate.AddMainThreadHintText);
                txt.Invoke(msgCallback, new object[] { txt, msg });
            }
            else
            {
                txt.Text += msg;
            }
        }
    }

    /// <summary>
    /// 获取控件属性
    /// </summary>
    /// <param name="str"></param>
    public delegate object GetControlPropertyDelegate(Control ctr, string property);

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

    /// <summary>
    /// 设置主线程输入框内容
    /// </summary>
    /// <param name="str"></param>
    public delegate void AddMainThreadHintTextDelegate(TextBox txt, string msg); 

     

}
