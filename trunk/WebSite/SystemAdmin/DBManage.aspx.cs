using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using FT.Web;
using FT.Web.Tools;
//using CqGuotong;

public partial class SystemAdmin_DBManage : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["help"] = "DBManageHelp.html";
            if (this.Operator.Right.IndexOf(FT.Web.ConstString.DBManage.ToString()) == -1)
            {
                this.RedirectNotRight();
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (DBOperation.BackUp(System.Configuration.ConfigurationSettings.AppSettings["dbname"].ToString(), Server.MapPath("backup") + "\\" + "dbback.dat"))
        //{
           // WebTools.Open("backup/dbback.dat", 50, 50);
       // }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.File1.PostedFile.FileName.EndsWith(".dat"))
        {
            this.File1.PostedFile.SaveAs(Server.MapPath("backup") + "\\" + "uploaddbback.dat");
           /* if (DBOperation.Restore(Server.MapPath("backup") + "\\" + "uploaddbback.dat", System.Configuration.ConfigurationSettings.AppSettings["dbname"].ToString()))
            {
                WebTools.Alert(this, "还原成功！");
            }
            else
            {
                WebTools.Alert(this, "还原失败！");

            }*/
        }
        else
        {
            WebTools.Alert(this, "请选择备份的dat文件!");
        }
    }
}
