using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx.SupportObject
{
    public class RecetangleDraw : BaseDraw
    {
        protected override void DrawContent(System.Drawing.Graphics graphics)
        {

            //graphics.DrawString("rec", PrintCommonSetting.Default_Footer_Font, this.Rectangle, this.Formater);
            //throw new Exception("The method or operation is not implemented.");
        }

        public override bool IsFinish()
        {
            return true;
           // throw new Exception("The method or operation is not implemented.");
        }
    }
}
