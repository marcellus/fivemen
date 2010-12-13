using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace FT.Web.Tools
{
   public  class MyDataBinder
    {
        public static void Bind(DataTable dt, DataGrid dg)
        {
            if (dt != null)
            {
                dg.DataSource = dt;
                dg.DataBind();
            }
        }
    }
}
