using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.GridView1.DataSource = this.mock();
        this.GridView1.DataBind();
    }

   

    private DataTable mock()
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("name");
        DataRow dr = null;
        for (int i=0;i<10;i++)
        {
            dr=dt.NewRow();
            dr[0]=i.ToString();
            dr[1]="name"+i.ToString();
            dt.Rows.Add(dr);
        }
        return dt;
    }
}
