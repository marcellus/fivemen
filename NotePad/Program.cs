using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotePad
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
              
            FT.Windows.Forms.AppicationHelper.StartLimitTimes("keywords"
                , NotePad.Properties.Resources.bg
            , 8, "15814584509", false,typeof(FT.NotePad.ThingEditor),"我的记事本");
            //FT.Windows.Forms.AppicationHelper.StartLimitTimes("keywords"
            //   , NotePad.Properties.Resources.bg
          //, 8, "15814584509", false);
        }
    }
}