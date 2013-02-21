using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class YuanTuo_Tools_Sms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string mobile = this.txtMobile.Text.Trim();
        string content = this.txtContent.Text.Trim();
        if (mobile.Length != 11)
        {
            this.lbSend.Text = "手机号码长度不为11位，无法发送，请重新输入！";
            
            return;
        }
        if (content.Length == 0)
        {
            this.lbSend.Text = "发送内容不能为空，无法发送，请重新输入！";

            return;
        }
       bool result= GobalTools.SendSmsByWebService(mobile,content);
       if (result)
       {
           this.lbSend.Text = "发送成功！";

           return;
       }
       else
       {
           this.lbSend.Text = "发送失败，请检查网络和短信服务器是否能联通！";

           return;
       }
    }
}
