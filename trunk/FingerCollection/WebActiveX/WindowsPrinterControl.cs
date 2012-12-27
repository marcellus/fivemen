using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using FT.Commons.Print;

namespace WebActiveX
{
    // {8047878A-E370-4987-85CA-9CCADB83126E}

    [Guid("8047878A-E370-4987-85CA-9CCADB83126E")]
    public partial class WindowsPrinterControl : UserControl,IObjectSafety
    {
        public WindowsPrinterControl()
        {
            InitializeComponent();
        }

        private TemplateTextConfig config = new TemplateTextConfig();

        public void InitPrinter(int pageWidth, int pageHeight)
        {
            config.PageWidth = pageWidth;
            config.PageHeight = pageHeight;
            this.ClearContent();
        }

        public void AddContent(string content,string fontname, int size,int left,int top)
        {
            TemplateTextObject text=new TemplateTextObject();
            text.Content = content;
            text.FontName = fontname;
            text.FontSize = size;
            text.Top = top;
            text.Left = left;
            config.Lists.Add(text);
        }
        public void ClearContent()
        {
            config.Lists.Clear();
        }
        public void Print()
        {
            IPrinter printer = new TemplatePrintObject(config);

            CommonPrinter common = new CommonPrinter(printer);
            common.Print();
        }

        public void PrintView()
        {
            IPrinter printer = new TemplatePrintObject(config);

            CommonPrinter common = new CommonPrinter(printer);
            common.Preview();
        }



        #region IObjectSafety 成员

        public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
        {
            pdwSupportedOptions = 1;
            pdwEnabledOptions = 2;

        }

        public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
        {
            
        }

        #endregion
    }
}
