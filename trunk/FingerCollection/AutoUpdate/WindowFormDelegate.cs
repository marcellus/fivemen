using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{
    public class WindowFormDelegate
    {
        private WindowFormDelegate()
        {
        }

        public static string GetListViewText(ListView lv, int i)
        {
            if (lv.InvokeRequired)
            {
                GetListViewTextDelegate msgCallback = new GetListViewTextDelegate(WindowFormDelegate.GetListViewText);
                object result=lv.Invoke(msgCallback, new object[] {lv, i });
                return result.ToString();
            }
            else
            {
                return lv.Items[i].Text.Trim();
            }
        }

        public static void SetMainThreadHint(Label label, string msg)
        {
            if (label.InvokeRequired)
            {
                SetMainThreadHintLabelDelegate msgCallback = new SetMainThreadHintLabelDelegate(WindowFormDelegate.SetMainThreadHint);
                label.Invoke(msgCallback, new object[] { label, msg });
            }
            else
            {
                label.Text = msg;
            }
        }
    }

    /// <summary>
    /// 设置主线程界面提示
    /// </summary>
    /// <param name="str"></param>
    public delegate string GetListViewTextDelegate(ListView lv,int i);

    /// <summary>
    /// 设置主线程界面提示
    /// </summary>
    /// <param name="str"></param>
    public delegate void SetMainThreadHintLabelDelegate(Label label, string msg); 

     
}
