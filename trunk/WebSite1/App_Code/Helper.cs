using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Helper 的摘要说明
/// </summary>
public class Helper
{
	
		//
		// TODO: 在此处添加构造函数逻辑
		//
        public static string Convert(object id)
        {
            return " <a id='btn' href='#' onclick='javascript:return compareRetID('" + id.ToString() + "');' >选择</a>"
            ;
        }

}


