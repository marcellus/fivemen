using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using FT.Commons.PrinterEx.SupportObject;
using FT.Commons.Tools;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// 对象打印类，打印某一个对象继承该类
    /// </summary>
    public abstract class ObjectPrinter:IPrinter
    {
        




        #region IPrinter 成员

        public void Preview()
        {
            PrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Preview();
            }
        }


        public void Print()
        {
            PrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Print();
            }
        }

        protected virtual PrinterContent GetPrinterContent()
        {
            MessageBoxHelper.Show("对不起，还没有实现打印该对象！");
            return null;
            //throw new Exception("");
        }

        #endregion

        #region IPrinter 成员



        public Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
