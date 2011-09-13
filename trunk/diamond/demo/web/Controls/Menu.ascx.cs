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
using System.Text;

public partial class Controls_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string InitHtml()
    {
        StringBuilder Html = new StringBuilder();
        string rooturl = ResolveUrl("~");
        Html.Append("<div><li  style=\"width:20px;\"></div></li>");

        Html.Append("<li  style=\"width:100px;\"><a name=\"mu_1\" href=\"../Diamond/Product_List.aspx\">产品管理</a>");
        Html.Append("<div class=\"imsc\"><div class=\"imsubc\" style=\"width:100px;top:0px;left:0px;\"><ul style=\"\">");
        Html.Append("<li><a  name=\"mu_1$1\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Storage/StorageListMange.aspx\">入库单管理</a></li>");
        Html.Append("<li><a  name=\"mu_1$2\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Storage/BulkStorage.aspx\">产品批量入库</a></li>");
        Html.Append("<li><a  name=\"mu_1$2\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Storage/SingleStorage.aspx\">产品单件入库</a></li>");
        Html.Append("<li><a  name=\"mu_1$2\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Storage/ComfirmStorage.aspx\">产品入库确认</a></li>");
        Html.Append("</ul></div></div></li>");

       Html.Append("<li style=\"width:60px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">&nbsp;<span class=\"UserTip\"> </span></a></li>");

        Html.Append("<li  style=\"width:100px;\"><a name=\"mu_2\" href=\"#\"><span class=\"imea imeam\"><span></span></span>产品调拨</a>");
        Html.Append("<div class=\"imsc\"><div class=\"imsubc\" style=\"width:100px;top:0px;left:0px;\"><ul style=\"\">");
        Html.Append("<li><a  name=\"mu_2$1\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Assignment/ProductAssignmentList.aspx\">调拨单查询</a></li>");
        Html.Append("<li><a  name=\"mu_2$1\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Assignment/ProductAssignmentPlan.aspx\">新增调拨单</a></li>");
        Html.Append("<li><a  name=\"mu_2$1\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Assignment/ProductAssignmentPlanOutStoreScanner.aspx\">调拨出库扫描</a></li>");
        Html.Append("<li><a  name=\"mu_2$2\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Assignment/ProductAssignmentInShopScanner.aspx\">门店签收扫描</a></li>");
        Html.Append("</ul></div></div></li>");

        Html.Append("<li style=\"width:60px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">&nbsp;<span class=\"UserTip\"> </span></a></li>");

        Html.Append("<li  style=\"width:100px;\"><a name=\"mu_3\" href=\"#\"><span class=\"imea imeam\"><span></span></span>产品销售</a>");
        Html.Append("<div class=\"imsc\"><div class=\"imsubc\" style=\"width:100px;top:0px;left:0px;\"><ul style=\"\">");
        Html.Append("<li><a  name=\"mu_1$1\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Sales/SaleRecordList.aspx\">产品销售查询</a></li>");
        Html.Append("<li><a  name=\"mu_1$2\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Sales/SaleRecordAdd.aspx\">产品销售</a></li>");
        Html.Append("<li><a  name=\"mu_1$3\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Sales/SaleProductConfirm.aspx\">销售确认</a></li>");
        Html.Append("</ul></div></div></li>");

        //Report
        if (HttpContext.Current.Session["empRole"] != null && (HttpContext.Current.Session["empRole"].ToString() == "Admin" || HttpContext.Current.Session["empRole"].ToString() == "Report user"))
        {
            Html.Append("<li style=\"width:60px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">&nbsp;<span class=\"UserTip\"> </span></a></li>");

            Html.Append("<li  style=\"width:100px;\"><a name=\"mu_4\" href=\"#\"><span class=\"imea imeam\"><span></span></span>查询报表</a>");
            Html.Append("<div class=\"imsc\"><div class=\"imsubc\" style=\"width:100px;top:0px;left:0px;\"><ul style=\"\">");
            if (HttpContext.Current.Session["empRole"].ToString() == "Admin")
            {
                Html.Append("<li><a  name=\"mu_4$1\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "Product_List.aspx\">产品查询</a></li>");
            }
            
            if (HttpContext.Current.Session["empRole"].ToString() == "Admin" || HttpContext.Current.Session["empRole"].ToString() == "Report user")
            {
                Html.Append("<li><a  name=\"mu_4$2\" onclick=\"BuildUrl(this)\" href=\"" + rooturl + "report/StoreSalesReport.aspx\">门店销售报告</a></li>");
                //Html.Append("<li><a  name=\"mu_4$3\" onclick=\"BuildUrl(this)\" href=\"../Export_by_Size.aspx\">Export by size</a></li>");
            }
            if (HttpContext.Current.Session["empRole"].ToString() == "Admin")
            {
                //Html.Append("<li><a  name=\"mu_4$4\" onclick=\"BuildUrl(this)\" href=\"../Export_Xml.aspx\">Export Xml</a></li>");
            }

            Html.Append("</ul></div></div></li>");
        }
        Html.Append("<li style=\"width:100px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">&nbsp;<span class=\"UserTip\"> </span></a></li>");

        //Utility   

        //Html.Append("<li  style=\"width:90px;\"><a name=\"mu_6\" href=\"#\"><span class=\"imea imeam\"><span></span></span>Admin</a>");

        //Html.Append("<div class=\"imsc\"><div class=\"imsubc\" style=\"width:90px;top:0px;left:0px;\"><ul style=\"\">");
        
        //Html.Append("<li><a name=\"mu_6$1\" onclick=\"BuildUrl(this)\" href=\"../MyProfile.aspx\">My profile</a></li>");
        //if (HttpContext.Current.Session["empRole"] != null && HttpContext.Current.Session["empRole"].ToString() == "Admin")
        //{
        //    Html.Append("<li><a name=\"mu_6$2\" onclick=\"BuildUrl(this)\" href=\"../Product_SType.aspx\">Category</a></li>");

        //    Html.Append("<li><a name=\"mu_6$3\" onclick=\"BuildUrl(this)\" href=\"../Product_Color.aspx\">Color</a></li>");

        //    Html.Append("<li><a name=\"mu_6$4\" onclick=\"BuildUrl(this)\" href=\"../Order_management.aspx\">Collection</a></li>");

        //    Html.Append("<li nowrap=\"nowrap\"><a name=\"mu_6$5\" onclick=\"BuildUrl(this)\" href=\"../User_Setup.aspx\">User setup</a></li>");

        //    Html.Append("<li nowrap=\"nowrap\"><a name=\"mu_6$6\" onclick=\"BuildUrl(this)\" href=\"../InputXml.aspx\">Upload Xml</a></li>");
        //}

        //Html.Append("</ul></div></div></li>");

        //Html.Append("<li style=\"width:100px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">&nbsp;<span class=\"UserTip\"> </span></a></li>");

        Html.Append("<li  style=\"width:60px;\"><a href=\"../web/Login.aspx?logout=true\">登出</a></li>");

        Html.Append("<li style=\"width:60px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">&nbsp;<span class=\"UserTip\"> </span></a></li>");

        if (HttpContext.Current.Session["empName"] != null)
        {
            Html.Append("<li style=\"width:150px;\" nowrap=\"nowrap\"><a><span class=\"UserTipTitle\">当前用户:&nbsp;<span class=\"UserTip\">" + HttpContext.Current.Session["empName"].ToString() + "</span></a></li>");
        }
     
        return Html.ToString();
        
    }
}

