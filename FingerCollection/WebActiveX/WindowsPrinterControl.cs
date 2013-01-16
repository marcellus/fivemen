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

        //private int left;
       // private int right;
       // private int top;
       // private int bottom;

        public void InitPrinter(int pageWidth, int pageHeight)
        {
            config.PageWidth = pageWidth;
            config.PageHeight = pageHeight;
            
            this.ClearContent();
        }


        public void AddImage(string path, int left, int top)
        {
            TemplateTextObject text = new TemplateTextObject();
            text.ImgPath = path;
            text.Top = top;
            text.Left = left;
            config.Lists.Add(text);
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

        public void PrintMargin(int left,int top,int right,int bottom)
        {
            IPrinter printer = new TemplatePrintObject(config);

            CommonPrinter common = new CommonPrinter(printer);
            common.SetPageSize(left, top, right, bottom);
            common.Print();
        }


        public void PrintView()
        {
            IPrinter printer = new TemplatePrintObject(config);

            CommonPrinter common = new CommonPrinter(printer);
            common.Preview();
        }


/*
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
 * */
        #region IObjectSafety 成员

        private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";
        private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";
        private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";
        private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";
        private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

        private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001;
        private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002;
        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);
        private const int E_NOINTERFACE = unchecked((int)0x80004002);

        private bool _fSafeForScripting = true;
        private bool _fSafeForInitializing = true;

        public int GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
        {
            int Rslt = E_FAIL;

            string strGUID = riid.ToString("B");
            pdwSupportedOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA;
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForScripting == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForInitializing == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_DATA;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }

            return Rslt;
        }

        public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
        {
            int Rslt = E_FAIL;
            string strGUID = riid.ToString("B");
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_CALLER) && (_fSafeForScripting == true))
                        Rslt = S_OK;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_DATA) && (_fSafeForInitializing == true))
                        Rslt = S_OK;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }

            return Rslt;
        }

        #endregion

    }
}
