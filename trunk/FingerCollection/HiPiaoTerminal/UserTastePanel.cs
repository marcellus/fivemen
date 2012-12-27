using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;
using System.Threading;

namespace HiPiaoTerminal
{
    public partial class UserTastePanel : UserControl
    {
        public UserTastePanel()
        {
            InitializeComponent();
            this.VScroll = false;
            
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           this.webBrowser1.Refresh();
           // ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
          //  this.webBrowser1.Navigate(config.TastUrl);
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnQuickRegister_Click(object sender, EventArgs e)
        {
            GlobalTools.QuickRegister();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.webBrowser1.GoBack();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoForward();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            GlobalTools.ResetUnOperationTime();
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
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //设置不用浏览器打开新窗体
            e.Cancel = true;
        }
        public void LoadHtml()
        {
            //GlobalTools.RegistUpdateUnOperationTime(UpdateUnOperationTime);
            this.webBrowser1.ScriptErrorsSuppressed = true;
            //this.webBrowser1.
            //this.webBrowser1.sc
            ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            this.webBrowser1.Navigate(config.TastUrl);
        }

        public void ToIndex()
        {

        }
        

        private void UserTastePanel_Load(object sender, EventArgs e)
        {
           
            try{
             Thread thread = new Thread(new ThreadStart(LoadHtml));
                thread.IsBackground = true;
                thread.Start();
                Form frm = this.FindForm();
                if (frm != null)
                {
                    frm.AutoScroll = false;
                }
            }
            catch
            {
            }
            
        }

        private void UpdateUnOperationTime()
        {
            //this.lbLeaveTime.Text = GlobalTools.UnOperationLeaveSecond.ToString();
        }

        private void lbLeaveTime_Click(object sender, EventArgs e)
        {

        }

        private void btnQuickBuyTicket_Click(object sender, EventArgs e)
        {
            if (GlobalTools.loginUser == null)
            {
                GlobalTools.GoPanel(new UserLoginPanel(1));
            }
            else
            GlobalTools.QuickBuyTicket();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
