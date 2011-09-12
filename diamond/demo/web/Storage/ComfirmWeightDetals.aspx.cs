using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Storage_ComfirmWeightDetals : System.Web.UI.Page
{
    private string pro_Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        pro_Id = HttpContext.Current.Request.Params["PROID"] == null ? "" : HttpContext.Current.Request.Params["PROID"].ToString();
        if (!IsPostBack)
        {
            BindDetails(pro_Id);
        }
    }
    /// <summary>
    /// 绑定值
    /// </summary>
    /// <param name="storageID"></param>
    private void BindDetails(string proid)
    {
        if (!string.IsNullOrEmpty(proid))
        {
            Product o = new Product();
            this.txt_CoWeight.Text = o.GetComfirmWeight(proid).ToString();

        }



    }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        Product o = new Product();

        string sql = string.Format(@"update Product set ComfirmWeight={1} where Product_ID={0}", pro_Id, this.txt_CoWeight.Text);
            o.DatabaseAccess.ExecuteNonQuery(sql);
            Response.Write("<script>alert('复秤成功！');opener.location = opener.location;</script>");

        
    }
}
