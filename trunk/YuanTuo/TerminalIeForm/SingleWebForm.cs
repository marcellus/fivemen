using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TerminalIeForm
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class SingleWebForm : Form
    {
        public SingleWebForm()
        {
            InitializeComponent();
        }

        private void SingleWebForm_Load(object sender, EventArgs e)
        {
            //string url="http://www.bjoil.com/index.html";
           // this.webBrowser1.ScriptErrorsSuppressed = false;
            //this.webBrowser1.Navigate(url);

            string locationPrefix = System.Configuration.ConfigurationSettings.AppSettings["locationPrefix"];
            string type = "易捷微刊";
            this.webBrowser1.Navigate(string.Format("{1}\\终端本地文件\\{0}\\{0}.htm", type, locationPrefix));
           // string str = FT.Commons.Tools.HttpMockRequestHelper.GetMockRequestResult(url);
           // this.webBrowser1.DocumentText = str.Replace("/app", "http://bjoil.com/app").Replace("/bjoil","http://bjoil.com/bjoil");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // this.webBrowser1.DocumentText=this.webBrowser1.DocumentText.Replace("/app","http://bjoil.com/app");
           // http://bjoil.com/app
        }
    }
}
