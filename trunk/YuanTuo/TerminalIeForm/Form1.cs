using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace TerminalIeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            string configUrl =System.Configuration.ConfigurationSettings.AppSettings["configUrl"];
            this.webBrowser1.Navigate(configUrl);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoForward();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            this.webBrowser1.Refresh();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // GlobalTools.ResetUnOperationTime();
            //将所有的链接的目标，指向本窗体
            foreach (HtmlElement archor in this.webBrowser1.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }
            //将所有的FORM的提交目标，指向本窗体
            foreach (HtmlElement form in this.webBrowser1.Document.Forms)
            {
                form.SetAttribute("target", "_self");
                
            }
            string urlTmp = this.webBrowser1.Document.Url.AbsoluteUri;
            if (urlTmp == urlBaidu)
            {
                HtmlElement lg=this.webBrowser1.Document.GetElementById("lg");
                lg.Style = "display:none";
            }
            if (urlTmp == urlRealRoadCondition)
            {
                HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                tables[0].Children[0].Children[0].Children[2].Children[0].Style = "display:none";
                tables[1].Style = "display:none";
/*
                for (int i = 0; i < tables.Count; i++)
                {
                    string str = tables[i].InnerHtml;
                    string mmm=tables[0].Children[0].Children[0].Children[2].InnerHtml;
                    Console.WriteLine(string.Format("获取的表格的内容为：{0},{1}",i,str));
                    string ttt = "";

                   // tables[0].Style = "display:none";
                   // tables[1].Style = "display:none";
                }
 * */
            }

            
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //设置不用浏览器打开新窗体
            e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string width = System.Configuration.ConfigurationSettings.AppSettings["width"];
            string height = System.Configuration.ConfigurationSettings.AppSettings["height"];
            this.Size = new Size(Int32.Parse(width), Int32.Parse(height));
            this.Location = new Point(0, 0);
            string configUrl = System.Configuration.ConfigurationSettings.AppSettings["configUrl"];
            this.webBrowser1.Navigate(configUrl);
        }

        private string urlBaidu="http://www.baidu.com/";

        private string urlRealRoadCondition = "http://sslk.bjjtgl.gov.cn/roadpublish/Map/trafficOutNew1.jsp";

        private string urlBeijingMember = "http://www.bjoil.com/";

        private string urlCtrip = "http://www.ctrip.com";

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(urlBaidu);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(urlRealRoadCondition);
        }
    }
}
