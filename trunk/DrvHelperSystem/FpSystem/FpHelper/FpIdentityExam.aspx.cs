﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;
using FT.Commons.Tools;

public partial class FpSystem_FpHelper_FpIdentityExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["site_id"] = Request.Params["site_id"];
        Session["bustype"] = Request.Params["bustype"];
        int site_id=StringHelper.fnFormatNullOrBlankInt(Session["site_Id"].ToString(),-1);
        FpSite site = SimpleOrmOperator.Query<FpSite>(site_id);
        Session["host"] = site.HOST;
    }


}
