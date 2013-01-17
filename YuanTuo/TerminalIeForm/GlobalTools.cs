using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalIeForm
{
    public class GlobalTools
    {
        private static SkypeForm skypeForm;

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
            skypeForm.Show();
           // skypeForm.ShowDialog();
            skypeForm.BringToFront();
        }
    }
}
