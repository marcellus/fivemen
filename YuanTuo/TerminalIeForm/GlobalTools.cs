using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalIeForm
{
    public class GlobalTools
    {
        public  static SkypeForm skypeForm;

        public static YuanTuoForm yuantuoForm;

        public static void ShowCallingHint()
        {
#if DEBUG
            Console.WriteLine("开始显示拨号提示！");
#endif
            if (yuantuoForm != null)
            {
                yuantuoForm.SetHint("拨号中……");
            }
        }

        public static void ShowProcessingHint()
        {
#if DEBUG
            Console.WriteLine("开始显示通话中！");
#endif
            if (yuantuoForm != null)
            {
                yuantuoForm.SetHint("通话中……");
            }
        }

        public static void HandOffHint()
        {
#if DEBUG
            Console.WriteLine("开始隐藏拨号提示！");
#endif
            if (yuantuoForm != null)
            {
                yuantuoForm.HideHint();
            }
        }

        public static void CloseSkypeForm()
        {
            if (skypeForm != null)
            {
                skypeForm.Close();
            }
        }

        public static void CallSkype()
        {
            if (skypeForm != null)
            {
                skypeForm.Close();
                skypeForm = new SkypeForm();
            }
            else
            {
                skypeForm = new SkypeForm();
            }
            skypeForm.ShowDialog();
           // skypeForm.ShowDialog();
            skypeForm.BringToFront();
        }
    }
}
