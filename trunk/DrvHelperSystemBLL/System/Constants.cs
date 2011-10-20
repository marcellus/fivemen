using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace DrvHelperSystemBLL.System
{
   public  class Constants
    {

       public static string DecodeDepType = "decode(i_dep_type,-1,'系统',0,'车管部门',1,'驾校',2,'医院',3,'车行','未知部门') i_dep_type";

       public static void BindDepType(DropDownList ddl)
       {
           DataTable dt = new DataTable();
           dt.Columns.Add("id");
           dt.Columns.Add("name");
          
           dt.Rows.Add(new string[] { "0", "车管部门" });
           dt.Rows.Add(new string[] { "1", "驾校" });
           dt.Rows.Add(new string[] { "2", "医院" });
           dt.Rows.Add(new string[] { "3", "车行" });
           dt.Rows.Add(new string[] { "-1", "系统" });
           ddl.DataSource = dt;
           ddl.DataTextField = "name";
           ddl.DataValueField = "id";
           ddl.DataBind();
       }
    }
}
