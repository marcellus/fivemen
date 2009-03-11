using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FT.Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new BaseForm());
            //Form form = new FT.Windows.CommonsPlugin.LoginForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    FT.Windows.Forms.BaseMainForm main = new FT.Windows.Forms.BaseMainForm();
            //    TabPage tb=new TabPage("欢迎您   ");
            //    tb.BackgroundImage=FT.Test.Properties.Resources.bg;
            //    tb.BackgroundImageLayout = ImageLayout.Stretch;
            //    main.GetSimpleTabControl().TabPages.Add(tb);
            //    Application.Run(main);
            //}

            //FT.Windows.Forms.AppicationHelper.StartLimitTimes("keywords", FT.Test.Properties.Resources.bg
            //, 8, "15814584509", true);
            FT.Windows.Forms.AppicationHelper.StartLimitDays("keywords", FT.Test.Properties.Resources.bg
            , 8, "15814584509", true);

          //  FT.Windows.Forms.AppicationHelper.Start("keywords", FT.Test.Properties.Resources.bg);

            
        }

       
    }
}