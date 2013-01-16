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
using FT.Web.Bll.Terminal;

public partial class YuanTuo_ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.Params["id"];
            Session["seeproductid"] = id;
           // this.hidId.Value = id;
            DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select a.*,b.*,CASE WHEN discount IS NULL THEN a.price ELSE a.price*b.discount/10 end  as disacountprice from yuantuo_product_info a left join yuantuo_product_discount b on a.id=b.productid and getdate() between startdate and enddate where a.id=" + id + "", "temp");
            if (dt != null)
            {
                string sql = "update yuantuo_product_info set seetimes=seetimes+1 where id=" + id;
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
                this.repeater1.DataSource = dt;
                this.repeater1.DataBind();
                string imgs = dt.Rows[0]["imgs"].ToString();
                ViewState["imgs"] = imgs.Split(';') ;
                ViewState["production"] = Server.HtmlDecode(dt.Rows[0]["production"].ToString());

                ViewState["imgmain"] = dt.Rows[0]["imgmain"].ToString();
                
            }
        }
    }

    public string ImgMain
    {
        get
        {
            
            if (ViewState["imgmain"] != null)
            {
                string result = ViewState["imgmain"].ToString();
                return result;
            }
            else
            {
                return string.Empty;
            }

        }
    }

    public string SendInfo
    {
        get
        {
            string result = string.Empty;
            string id=Session["seeproductid"].ToString();
            string sendSql = "select top 1 productid,(select name from yuantuo_product_info where id=productid) as mainname,b.name as productname,b.no,sendproductid,num from yuantuo_product_send  a left join yuantuo_product_info b on b.id=a.sendproductid where getdate() between startdate and enddate and productid=" + id + " order by enddate desc";
            DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sendSql, "tmp");
           
            if (dt != null && dt.Rows.Count == 1)
            {
                string mainproductname = dt.Rows[0]["mainname"].ToString();
                int sendnumpre = Convert.ToInt32(dt.Rows[0]["num"].ToString());
                string sendno = dt.Rows[0]["no"].ToString();
                string sendname = dt.Rows[0]["productname"].ToString();
                result = string.Format("购买{0}件{1}将赠送1件{2}！！！",sendnumpre,mainproductname,sendname);
            }
            //result= "购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx购买xxxx产品10件将赠送一件xxxxx！！";
            return result;
        }
    }

   

    public string Description
    {
        get
        {
            if (ViewState["production"] != null)
            {
                string result = ViewState["production"].ToString();
                return result;
            }
            else
            {
                return string.Empty;
            }
          
        }
    }

   

    public string[] CycleImages
    {
        get
        {
            if (ViewState["imgs"] == null)
            {
                return new string[] { };
            }
            else
            {
                return ViewState["imgs"] as string[];
            }
           // return new string[]{"1.jpg","2.jpg","3.jpg"};
        }
    }

    

    public string GetPrintHeaders()
    {
        TerminalStatus terminal = GobalTools.GetTerminal();
        string result = string.Empty;
        result += GobalTools.GetTerminalOrderId(terminal.StorePrefix);
        result += ";" + terminal.StoreNo + ";" + terminal.StoreName + ";" + terminal.StorePhone;
        return result;
    }
    protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "buyAndPrint")
        {

        }
        else if (e.CommandName == "addToStore")
        {
            DataTable dt = GobalTools.Select("select * from yuantuo_product_info where id=" + Request.Params["id"] + "");
            
            object obj=Session["Store"];
            if (obj == null)
            {
                Session["Store"] = dt;
            }
            else
            {
                DataTable dt2 = Session["Store"] as DataTable;
                dt.Merge(dt2);
                Session["Store"] = dt;
            }
            Label lb=e.Item.FindControl("lbMsg") as Label;
           // lb.Text = "加入购物车成功，共"+dt.Rows.Count+"件商品";
        }
    }
}
