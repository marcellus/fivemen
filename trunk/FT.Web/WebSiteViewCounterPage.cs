using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace FT.Web
{
    public class WebSiteViewCounterPage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "insert into Access_Record(computer_name,computer_ip,access_url,access_time) values('{0}','{1}','{2}','{3}')";
                FT.DAL.Access.AccessDataHelper access = new FT.DAL.Access.AccessDataHelper(Server.MapPath("~/db/db.mdb"), "admin", "");
                IPHostEntry hostInfo = Dns.GetHostByAddress(Request.UserHostAddress);
               access.ExecuteSql(string.Format(sql, hostInfo.HostName, Request.UserHostAddress.ToString(), Request.Url, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            }
        }  
    }
}
