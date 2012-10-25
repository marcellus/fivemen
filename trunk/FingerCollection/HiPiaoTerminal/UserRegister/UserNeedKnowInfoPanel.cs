using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.UserRegister
{
    public partial class UserNeedKnowInfoPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public UserNeedKnowInfoPanel()
        {
            InitializeComponent();
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.btnMemberProtocol_Click(null, null);
            WinFormHelper.CenterHor(this.btnSure);
        }

        private void btnWebSiteProtocol_Click(object sender, EventArgs e)
        {
            this.btnWebSiteProtocol.IsActive = true;
            this.btnMemberProtocol.IsActive = this.btnPrivatePolicy.IsActive
                = this.btnRemark.IsActive = false;
            this.webBrowser1.ScrollBarsEnabled = true;
            this.LoadHtml("UserNeedKnow-WebSiteProtocol.htm");
        }

        private void btnMemberProtocol_Click(object sender, EventArgs e)
        {
            this.btnMemberProtocol.IsActive = true;
            this.btnWebSiteProtocol.IsActive = this.btnPrivatePolicy.IsActive
                = this.btnRemark.IsActive =false;
            this.webBrowser1.ScrollBarsEnabled = true;
            this.LoadHtml("UserNeedKnow-MemberProtocol.htm");
        }

        private void btnPrivatePolicy_Click(object sender, EventArgs e)
        {
            this.btnPrivatePolicy.IsActive = true;
            this.btnWebSiteProtocol.IsActive = this.btnMemberProtocol.IsActive
               = this.btnRemark.IsActive = false;
            this.webBrowser1.ScrollBarsEnabled = true;
            this.LoadHtml("UserNeedKnow-PrivatePolicy.htm");
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            this.btnRemark.IsActive = true;
            this.btnWebSiteProtocol.IsActive = this.btnPrivatePolicy.IsActive
                           = this.btnMemberProtocol.IsActive = false;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.LoadHtml("UserNeedKnow-Remark.htm");
        }

        private void UserNeedKnowInfoPanel_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadHtml(string html)
        {
            string helpdoc = Application.StartupPath + "\\HelpDoc\\"+html;
            this.webBrowser1.Navigate(helpdoc);
            
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //设置不用浏览器打开新窗体
            e.Cancel = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
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

        private void btnRemark_Load(object sender, EventArgs e)
        {

        }
    }
}
