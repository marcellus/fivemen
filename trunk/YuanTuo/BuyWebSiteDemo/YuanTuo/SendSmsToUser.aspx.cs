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
using FT.DAL.Orm;
using FT.Web.Bll.Product;
using System.Text;
using FT.Commons.Tools;

public partial class YuanTuo_SendSmsToUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.txtMobile.Attributes["onclick"] = "javascript:showKeyboard(this);";
            this.txtValidCode.Attributes["onclick"] = "javascript:showKeyboard(this);";
            this.txtValidCode.Style.Add("line-height", "73px");
            string productid = Session["seeproductid"].ToString();
            Session["orderid"] = GobalTools.GetTerminalOrderId();
            string num=Request.Params["ordernum"].ToString();
        }
    }
    /*
      height+=lineHeight;
    obj.AddContent('汽车台座专用香氛50（ml）','宋体',10,left,height);
     height+=lineHeight;
    obj.AddContent('04011              856          78','宋体',10,left,height);
     height+=lineHeight;
    obj.AddContent('金额合计：66,768.00','宋体',10,left,height);
     */

    private const string printScriptFormatter58 = @"<script type='text/javascript'>
    function PrintContent()
    {{
    
    
    var lineHeight={12};//行距
    var height=80;//第一行距离顶端的距离，页上距
    var left={11};//左边距
    var font={10};//字体大小
    
    //设置服务电话字体和边距   95105577
    var servicephoneleft=110;//服务电话    左边距
    var servicephonefont={13};//服务电话字体大小
    
    ///logo打印配置
    var serverip='192.168.1.149:8089';//服务器地址
    var logoleft=50;//logo左边距
    var logtop=5;//logo上边距
    
    
    var obj=document.getElementById('printer');
   // alert(obj);
   
   
    
    
    
     //var headers = '<%=GetPrintHeaders()%>';
      //alert(obj.AddContent);
    // alert(obj.InitPrinter);
     obj.InitPrinter(600,400);
      
 
    obj.AddImage('{0}',logoleft,logtop);
    //alert(obj.AddContent);
     obj.AddContent('单号：    {1}','宋体',font,left,height);
    height+=lineHeight;
    obj.AddContent('门店编号：{2}','宋体',font,left,height);
      height+=lineHeight;
    obj.AddContent('门店名称：{3}','宋体',font,left,height);
      height+=lineHeight;
    obj.AddContent('门店号码：{4}','宋体',font,left,height);
      height+=lineHeight;
    obj.AddContent('客户电话：{5}','宋体',font,left,height);
       height+=lineHeight;
    obj.AddContent('','宋体',font,left,height);
    
      height+=lineHeight;
    obj.AddContent('商品名称      数量      单价','黑体',font,left,height);

     {6}
     
        height+=lineHeight;
    obj.AddContent(' ','宋体',font,left,height);
     
     height+=lineHeight;
    obj.AddContent('1.商品售出，非质量问题，恕不退换。','宋体',8,left,height);
     height+=lineHeight;
    obj.AddContent('2.商品预计约{9}个工作日后到货。','宋体',8,left,height);
     height+=lineHeight;
    obj.AddContent('3.如{14}个工作日内未取货，则取消订单。','宋体',8,left,height);
     height+=lineHeight;
    obj.AddContent('4.此单据为顾客在易捷便利店订购商品','宋体',8,left,height);
     height+=lineHeight;
    obj.AddContent('  唯一凭证，顾客在门店交易订购商品','宋体',8,left,height);
      height+=lineHeight;
    obj.AddContent('  需凭此票，请妥善保管。','宋体',8,left,height);
    
   
     height+=lineHeight;
    obj.AddContent('5.目录销售终端交易业务最终解释权归','宋体',8,left,height);
     height+=lineHeight;
    obj.AddContent('  中石化北京石油公司。','宋体',8,left,height);
    
    height+=lineHeight;
    obj.AddContent(' ','宋体',font,left,height);

     height+=lineHeight;
    obj.AddContent('  产品咨询热线：','宋体',font,left,height);
    obj.AddContent('95105577','黑体',servicephonefont,servicephoneleft,height);

height+=lineHeight;
    obj.AddContent(' ','宋体',font,left,height);

     height+=lineHeight;
    obj.AddContent('打印时间：{7}','宋体',font,left,height);
     height+=lineHeight;
    obj.AddContent('  谢谢您的惠顾，欢迎再次光临！','黑体',font,left,height);
    //alert('complete add content!');
    obj.Print();
window.location.href='{8}';
    }}
PrintContent();
                                            </script>
";
    //14
    private  const string printScriptFormatter = @"
<script type='text/javascript'>
    function PrintContent()
    {{
    var obj=document.getElementById('printer');
   // alert(obj);
    var lineHeight={12};
    var height=80;
    var left={11};
     //var headers = '<%=GetPrintHeaders()%>';
      //alert(obj.AddContent);
    // alert(obj.InitPrinter);
     obj.InitPrinter(600,400);
      

    obj.AddImage('{0}',60,10);
    //alert(obj.AddContent);
    obj.AddContent('单号：    {1}','宋体',{10},left,height);
    height+=lineHeight;
    obj.AddContent('门店编号：{2}','宋体',{10},left,height);
      height+=lineHeight;
    obj.AddContent('门店名称：{3}','宋体',{10},left,height);
      height+=lineHeight;
    obj.AddContent('门店号码：{4}','宋体',{10},left,height);
      height+=lineHeight;
    obj.AddContent('客户电话：{5}','宋体',{10},left,height);
  height+=lineHeight;
    obj.AddContent(' ','宋体',{10},left,height);
      height+=lineHeight;
    obj.AddContent('商品名称           数量         单价','宋体',{10},left,height);
     {6}
  height+=lineHeight;
    obj.AddContent(' ','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('1.商品售出，非质量问题，恕不退换。','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('2.商品预计约{9}个工作日后到货。','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('3.如{14}个工作日内未取货，则取消订单。','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('4.此单据为顾客在易捷便利店订购商品','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('  唯一凭证，顾客在门店交易订购商品','宋体',{10},left,height);
      height+=lineHeight;
    obj.AddContent('  需凭此票，请妥善保管。','宋体',{10},left,height);
    
   
     height+=lineHeight;
    obj.AddContent('5.目录销售终端交易业务最终解释权归','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('  中石化北京石油公司。','宋体',{10},left,height);
    
    
     height+=lineHeight;
    obj.AddContent('  产品咨询热线：','宋体',{10},left,height);
    obj.AddContent('95105577','黑体',{13},130,height);
     height+=lineHeight;
    obj.AddContent('打印时间：{7}','宋体',{10},left,height);
     height+=lineHeight;
    obj.AddContent('  谢谢您的惠顾，欢迎再次光临！','宋体',{10},left,height);
    //alert('complete add content!');
    obj.Print();
 //obj.PrintMargin(0,0,0,0);
window.location.href='{8}';
    }}
PrintContent();
                                            </script>
";

    private void LogOrderRecord(TerminalStatus terminal,ProductInfo product,string orderid,double orderPrice,int orderNum,string mobile)
    {

        

    }

    
    protected void btnSure_Click(object sender, EventArgs e)
    {
        if (this.txtValidCode.Text.Trim().Length == 4)
        {
           bool result= GobalTools.IsRight(this.txtValidCode.Text.Trim());
           if (result)
           {
               string ordersqlFormat = @"
INSERT INTO yuantuo_terminal_orders
           (orderid
           ,productid
           ,product
           ,num
           ,singleprice
           ,terminalid
           ,totalprice
           ,isadd
           ,mobile,orderdate)
     VALUES ('{0}',{1},'{2}',{3},{4},{5},{6},{7},'{8}','{9}')
";
               FT.DAL.IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();

               int fontsize = 9;
               int lineheight = 15;
              // int left = 15;
               int left = 1;
               string script = string.Empty;
               string domain = Request.Url.ToString();
              // nowUrl.in
              // domain = domain.Substring(domain.IndexOf(":") + 3);//http://之后的
               domain=domain.Substring(0,domain.IndexOf("/YuanTuo"));
               //string urlPrefix = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf('/', 0, 3));
              // string logo = Page.ResolveUrl("~/YuanTuo/images/yijielogo.bmp");
               string logo =  domain + "/YuanTuo/images/yijielogo.bmp";
              // string logo="http://127.0.0.1:12345/BuyWebSiteDemo/YuanTuo/images/yijielogo.bmp";
               string orderid = Session["orderid"].ToString();
               TerminalStatus terminal = GobalTools.GetTerminal();

               string mobile = this.txtMobile.Value;
               StringBuilder productcontent=new StringBuilder();
               string productid = Session["seeproductid"].ToString();
               ProductInfo entity = SimpleOrmOperator.Query<ProductInfo>(Convert.ToInt32(productid));
               int num = Convert.ToInt32(Request.Params["ordernum"].ToString());



               double price = Convert.ToDouble(Request.Params["price"].ToString());

               string sendSql = "select top 1 productid,b.name as productname,b.no,sendproductid,num from yuantuo_product_send  a left join yuantuo_product_info b on b.id=a.sendproductid where getdate() between startdate and enddate and productid=" + entity.Id.ToString() + " order by enddate desc";
               DataTable dt = access.SelectDataTable(sendSql, "tmp");
               string sendPrintContent = string.Empty;
               string orderdate = DateTimeHelper.DtToLongString(System.DateTime.Now);
               if (dt != null&&dt.Rows.Count==1)
               {
                   int sendproductid = Convert.ToInt32(dt.Rows[0]["sendproductid"].ToString());
                   int sendnumpre = Convert.ToInt32(dt.Rows[0]["num"].ToString());
                   string sendno = dt.Rows[0]["no"].ToString();
                   string sendname = dt.Rows[0]["productname"].ToString();
                   if (num > sendnumpre)
                   {
                       int sendnum = num / sendnumpre;
                       access.ExecuteSql(string.Format(ordersqlFormat
                           , orderid, sendproductid, sendname, sendnum, 0, terminal.Id, 0, 1, mobile, orderdate
                           ).Replace("\r\n", ""));
                      // " obj.AddContent('04012          78        77','宋体',font,left,height);";
                       sendPrintContent = "height+=lineHeight;obj.AddContent('" + sendname + "(赠品)','宋体'," + fontsize.ToString() + ",left,height);height+=lineHeight;obj.AddContent('" + sendno + "          " + sendnum + "        " + "0" + "','宋体',"+fontsize.ToString()+",left,height);";
                   }
               }
               access.ExecuteSql(string.Format(ordersqlFormat
                          , orderid, entity.Id, entity.Name, num, price, terminal.Id, price * num, 0, mobile, orderdate
                          ).Replace("\r\n", ""));


               /*
                     height+=lineHeight;
                   obj.AddContent('汽车台座专用香氛50（ml）','宋体',10,left,height);
                    height+=lineHeight;
                   obj.AddContent('04011              856          78','宋体',10,left,height);
                    height+=lineHeight;
                   obj.AddContent('金额合计：66,768.00','宋体',10,left,height);
                    */

               productcontent.Append("height+=lineHeight;");
               productcontent.Append("obj.AddContent('" + entity.Name + "','宋体',"+fontsize.ToString()+",left,height);");
               productcontent.Append("height+=lineHeight;");
               productcontent.Append("obj.AddContent('" + entity.No + "          " + num + "        " + price + "','宋体'," + fontsize.ToString() + ",left,height);");
               productcontent.Append(sendPrintContent);
               productcontent.Append("height+=lineHeight;");
               productcontent.Append("obj.AddContent('金额合计：" + string.Format("{0:N2}", price * num) + "','黑体'," + 10.ToString() + ",left,height);");
               //80mm
              /* script = string.Format(printScriptFormatter
                   ,logo,orderid,terminal.StoreNo,terminal.StoreName,terminal.StorePhone
                   , mobile, productcontent.ToString(), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                  ,Page.ResolveUrl("~/YuanTuo/Index.aspx")
                  ,entity.GetProductDays.ToString()
                  , fontsize, left,lineheight,fontsize+2,entity.GetProductDays+4
                   );
               * */
               script = string.Format(printScriptFormatter58
                   , logo, orderid, terminal.StoreNo, terminal.StoreName, terminal.StorePhone
                   , mobile, productcontent.ToString(), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                  , Page.ResolveUrl("~/YuanTuo/Index.aspx")
                  , entity.GetProductDays.ToString()
                  , fontsize, left, lineheight, fontsize + 2, entity.GetProductDays + 4
                   );
               ClientScript.RegisterStartupScript(this.GetType(),"tmp", script);
           }
           else
           {
               ClientScript.RegisterStartupScript(this.GetType(), "tmp", "<script type='text/javascript'>setValidError();</script>");
           }
        }
    }
}
