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
using FT.Web.Bll.Terminal;

public partial class YuanTuo_ProductList : System.Web.UI.Page
{
    protected int i = 0;

    private void BindCurrentPage()
    {
        int currentpage = Convert.ToInt32(this.hidPages.Value);



        string countsql = "select count(*) from yuantuo_product_info where status=1 and producttypeid=" + Session["producttypeid"].ToString();
        int count = Convert.ToInt32(FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar(countsql));
        int pages = count / 5 == 0 ? count / 5 : count / 5 + 1;
        if (count == 0)
        {
            pages = 0;
            string sql = "select top 5 a.*,CASE WHEN discount IS NULL THEN a.price ELSE a.price*b.discount/10 end as disacountprice from yuantuo_product_info a left join yuantuo_product_discount b on a.id=b.productid and getdate() between startdate and enddate where status=1 and producttypeid=" + Session["producttypeid"].ToString() + " order by ordernum desc,a.id desc";
            tmpDt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "temp");
            this.btnPrePage.Visible=this.btnNextPage.Visible = false;
        }
        else
        {
            if (currentpage == 1)
            {
                this.btnPrePage.Visible = false;
                // this.btnNextPage.Visible = false;
            }
            else
            {
                this.btnPrePage.Visible = true;
            }
            if (currentpage < pages)
            {
                this.btnNextPage.Visible = true;
            }
            else
            {
                this.btnNextPage.Visible = false;
            }

            string sql = "select top 5 d.* from (select top 5 c.* from  (select top " + 5 * currentpage + " a.*,CASE WHEN discount IS NULL THEN a.price ELSE a.price*b.discount/10 end as disacountprice from yuantuo_product_info a left join yuantuo_product_discount b on a.id=b.productid and getdate() between startdate and enddate where status=1 and producttypeid=" + Session["producttypeid"].ToString() + " order by ordernum desc,a.id desc)  c  order by ordernum asc,id asc) d order by ordernum desc,id desc";
//#if DEBUG
            Console.WriteLine(sql);
//#endif
            tmpDt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "temp");
        }



      
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if(Request.Params["type"]!=null)
            {
                Session["producttypeid"] = Request.Params["type"].ToString();
            }

            this.BindCurrentPage();
            /*
            if (tmpDt != null)
            {
                this.repeater1.DataSource = tmpDt;
                this.repeater1.DataBind();
            }
             * */
        }

    }

    private DataTable tmpDt=null;

    private static string InnerTd = @"<table border='0'  cellpadding='0' cellspacing='0' style='width:360px'><tr>

<td style='width:{10}px;height:{10}px;vertical-align:top;'>
<div style='width:{10}px;height:{10}px; text-align:center; vertical-align:middle;border:solid 1px gray; '>
<img width='{8}' height='{8}' style='display:block;margin-left:15px;margin-top:15px'  alt='' onclick='javascript:location.href={0};'  src='ProductPic/{1}' />
</div>
</td>

<td style='margin-top:0px; padding-top:0px;vertical-align:top'>


<div style='height:150px;margin-left:10px ; font-size:12pt'>
<span>产品名称：{2}</span>
<br />
<span>品   牌： {3}</span>
<br />
<span>规   格： {4}</span>
<br />
<span>产   地： {5}</span>
<br />
<span>浏览次数： {9}次</span>
</div>
<div style='margin-left:10px ; '>
<span style='color:Red;font-size:15pt'> ￥{6}</span>
<span style=' color:Gray;text-decoration:line-through;font-size:15pt'>￥{7}</span>
</div>
</td>
</tr></table>";

    private static string InnerTdLeft = @"<table border='0' cellpadding='0' cellspacing='0' style='width:320px'><tr>

<td style='width:{10}px;height:{10}px;vertical-align:top; '>
<div style='width:{10}px;height:{10}px; text-align:center; vertical-align:middle;border:solid 1px gray;'>
<img width='{8}' height='{8}' alt='' style='display:block;margin-left:15px;margin-top:15px' onclick='javascript:location.href={0};'  src='ProductPic/{1}' />
</div>
<div style='height:130px;margin-top:15px ;   font-size:13pt'>
<span>产品名称：{2}</span>
<br />
<span>品   牌： {3}</span>
<br />
<span>规   格： {4}</span>
<br />
<span>产   地： {5}</span>
<br />
<span>浏览次数：{9}次</span>
</div>
<div style='margin-left:0px ; '>
<span style='color:Red;font-size:20pt'>￥{6}</span>
<span style=' color:Gray;text-decoration:line-through;font-size:20pt'>￥{7}</span>
</div>
</td>
</tr></table>";

    private string ConvertPrice(object obj)
    {
        if (obj == null||obj is DBNull)
        {
            return "0.00";
        }
        else
        {
            return Convert.ToDouble(obj).ToString("N2");
        }

    }
    public string AdContent
    {
        get
        {
            string result = string.Empty;
            TerminalStatus terminal=GobalTools.GetTerminal();
            string sql = "select adcontent from yuantuo_terminal_group where id="+terminal.MachineGroupId.ToString();
            object adContent = FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar(sql);
            if (adContent != null)
            {
                result = adContent.ToString();
            }
            return result;
        }
    }

    public string GeneratorHtml
    {
        get
        {
            StringBuilder sb = new StringBuilder("");
            if (tmpDt != null)
            {
               DataRow dr;
                for (int i = 1; i <= 5; i++)
                {
                    if (i == 1)
                    {
                        sb.Append("<tr><td rowspan='3' style='vertical-align:top'>");
                    }
                    else if(i==2||i==4)
                    {
                        sb.Append("<tr><td style='vertical-align:top'>");
                    }
                    else if (i == 3||i==5)
                    {
                        sb.Append("<td style='vertical-align:top'>");
                    }
                    if (i <= tmpDt.Rows.Count)
                    {
                        dr = tmpDt.Rows[i - 1];
                    }
                    else
                    {
                        dr = null;
                    }
                    if(dr!=null)
                    {

                        if (i == 1)
                        {
                            sb.AppendFormat(InnerTdLeft, "\"ProductDetail.aspx?id=" + dr["id"].ToString() + "\""
                              , dr["imgmain"].ToString()
                               , dr["name"].ToString()
                                , dr["pinpai"].ToString()
                                 , dr["guige"].ToString()
                                  , dr["chandi"].ToString()
                                  
                                  
                                   , ConvertPrice(dr["disacountprice"])
                                    , ConvertPrice(dr["price"])
                                   ,250
                                   , dr["seetimes"].ToString()
                                   ,250+30
                              );
                        }
                        else
                        {
                            sb.AppendFormat(InnerTd, "\"ProductDetail.aspx?id=" + dr["id"].ToString() + "\""
                                , dr["imgmain"].ToString()
                                 , dr["name"].ToString()
                                  , dr["pinpai"].ToString()
                                   , dr["guige"].ToString()
                                    , dr["chandi"].ToString()
                                   
                                    
                                     
                                     , ConvertPrice(dr["disacountprice"])
                                      , ConvertPrice(dr["price"])
                                     , 145
                                     , dr["seetimes"].ToString()
                                     ,145+30
                                );
                        }
                    }
                    else{
                        sb.Append("&nbsp;");
                    }


                    if (i == 1)
                    {
                        sb.Append("</td></tr>");
                    }
                    else if (i == 2 || i == 4)
                    {
                        sb.Append("</td>");
                    }
                    else if (i == 3 || i == 5)
                    {
                        sb.Append("</td></tr>");
                    }
                }
            }
            return sb.ToString();
        }
    }
    /*
    protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemIndex == 0)
        {
            HtmlTableCell oCell = this.repeater1.Items[0].FindControl("td") as HtmlTableCell;
            oCell.RowSpan = 2;
        }
        
        if(i%2==0)
{ 
e.Item.Controls.Add(new LiteralControl("</tr><tr>")); //动态添加<tr> 使其换行。看清楚了，这里是</tr><tr> 我并没有糊涂
} 
i++;
    }
     * */
    protected void btnPrePage_Click(object sender, ImageClickEventArgs e)
    {
        int page = Convert.ToInt32(this.hidPages.Value);
        page--;
        this.hidPages.Value = page.ToString();
        this.BindCurrentPage();
    }
    protected void btnNextPage_Click(object sender, ImageClickEventArgs e)
    {
        int page = Convert.ToInt32(this.hidPages.Value);
        page++;
        this.hidPages.Value = page.ToString();
        this.BindCurrentPage();
    }
}
