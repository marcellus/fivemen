using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExamAppSys
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FT.Windows.Forms.AppicationHelper.BeforeStart();
            
             Form form= new FT.Exam.UserLoginFirstForm();
             DialogResult result = form.ShowDialog();
            if(result==DialogResult.OK)
            {
                FT.Windows.Forms.AppicationHelper.StartLimitDays("ExamAppSys", ExamAppSys.Properties.Resources.bg
          , 10, "15814584509", true);
            }
            else
            {

            }
           
        }
    }
}