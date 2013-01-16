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
using System.Text;

public partial class YuanTuo_SendSmsInterface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        object mobile=Request.Params["mobile"];
        //object valid=Request.Params["valid"];
        Response.Expires = -1;
        Response.Clear();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "application/json";
       
      
        if (mobile != null )
        {
           // Session["orderid"]
            //System.Threading.Thread.Sleep(1000);
            //GobalTools.SendValidSms(mobile.ToString());
            
            if (GobalTools.SendValidSms(mobile.ToString(), Session["orderid"].ToString()))
            {
                Response.Write("{\"result\":\"Success\"}");
            }
            else
            {
               // Response.Write("{\"result\":\"Success\"}");
                Response.Write("{\"result\":\"Fail\"}");
            }
            /* 
            Response.Write("{\"result\":\"Success\"}");
             * * */
        }
        else
        {
            Response.Write("{\"result\":\"Fail\"}");
        }
        Response.Flush();
        Response.End();  
    }
}
