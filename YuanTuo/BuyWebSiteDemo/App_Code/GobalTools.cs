using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL;
using System.Data.SqlClient;
using FT.Web.Bll.Terminal;
using System.Net;
using System.IO;
using System.Xml;
using System.Text;
using log4net;

/// <summary>
///GobalDalTools 的摘要说明
/// </summary>
public class GobalTools
{
    protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
    public GobalTools()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool CheckValidationResult(object sender,
                               System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                               System.Security.Cryptography.X509Certificates.X509Chain chain,
                               System.Net.Security.SslPolicyErrors errors)
    {
        //直接确认，不然打不开   
        return true;
    }

    private static void Log(string str)
    {
        log.Debug(str);
    }

    public static bool SendSmsByWebService(string mobile, string smsContent)
    {

        Service1 service = new Service1();
        // service.
        string url = System.Configuration.ConfigurationManager.AppSettings["Interface_Sms_Url"];
        service.Url = url;
        string timeout = System.Configuration.ConfigurationManager.AppSettings["Interface_Sms_Interface_Sms_Timeout"];
        if (timeout.Length > 0 && timeout != "-1")
        {
            service.Timeout = Convert.ToInt32(timeout);
        }

        string query = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SMS type=\"send\"><Message><MessageID>" + "UE000" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + "</MessageID><UserID>84469997</UserID><SendNum>84469997</SendNum><RecvNum>" + mobile + "</RecvNum><Report>false</Report><Content>" + smsContent + "</Content><Level>0</Level></Message></SMS>";

        Log("调用发送短信接口发送内容为：" + query);
        try
        {
            service.addShortMessageUC("ATECH-SMS", query);
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            return false;
        }
        return true;

    }


    public static bool IsRight(string code)
    {
        if (System.Web.HttpContext.Current.Session["smsvalidcode"] == null)
        {
            return false;
        }
        if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Interface_Sms_Mock"]))
        {
            return code == "1234";
        }
        else
        {
            return code.Equals(System.Web.HttpContext.Current.Session["smsvalidcode"].ToString());
        }

        
        
    }

    public static string GenerateNumberCode(int len)
    {
        Random r = new Random();
        // long tick = DateTime.Now.Ticks;
        //  Random r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

        string str = string.Empty;
        for (int i = 0; i < len; i++)
        {

            str += r.Next(10).ToString();
        }
       
        return str;
    }

    public static bool SendValidSms(string mobile,string orderid)
    {
        string code = GenerateNumberCode(4);
        bool result = true;
        if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Interface_Sms_Mock"]))
        {
            System.Web.HttpContext.Current.Session["smsvalidcode"] = code;
        }
        else
        {

            result = SendSmsByWebService(mobile, string.Format("中石化北京石油易捷便利店订单号{1}验证码为：{0}", code, orderid));//易捷提醒您，您本次订单号{1}购物的验证码为：{0}！
            if (result)
                System.Web.HttpContext.Current.Session["smsvalidcode"] = code;
           
        }
        return result;
    }


    public static bool SendSms(string mobile, string smsContent)
    {
        string url = System.Configuration.ConfigurationManager.AppSettings["Interface_Sms_Url"];
        Uri uri = new Uri(url);
        string query = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SMS type=\"send\"><Message><MessageID>" + "UE000" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + "</MessageID><UserID>84469997</UserID><SendNum>84469997</SendNum><RecvNum>" + mobile + "</RecvNum><Report>false</Report><Content>" + smsContent + "</Content><Level>0</Level></Message></SMS>";
#if DEBUG
            Console.WriteLine("调用发送短信接口发送内容为：" + query);
#endif
        if (url.StartsWith("https"))
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                                    new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);


        }
        WebRequest webRequest = WebRequest.Create(uri);

        webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        // webRequest.ContentLength = query.Length;
        webRequest.Method = "POST";

       //webRequest.Timeout = GetInterfaceTimeout();

        using (Stream requestStream = webRequest.GetRequestStream())
        {

            byte[] paramBytes = Encoding.UTF8.GetBytes(query.ToString());

            requestStream.Write(paramBytes, 0, paramBytes.Length);

        }

        //响应

        WebResponse webResponse = webRequest.GetResponse();
        string result = "";
        using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
        {

           
            result = myStreamReader.ReadToEnd();
#if DEBUG
            
            Console.WriteLine("调用发送短信接口返回结果为：" + result);
#endif
          //  return result;


        }

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(result);
        XmlNode node = doc.SelectSingleNode("//state");
        if (node != null)
        {
            return node.Attributes["state"].Value.ToString() == "0";
        }
        return false;
    }

    public static void BindProductType(DropDownList ddl)
    {
        BindDDL("select id as value,name as text from yuantuo_product_types", ddl);
    }


    public static void BindProduct(DropDownList ddl)
    {
        BindDDL("select id as value,name as text from yuantuo_product_info", ddl);
    }

    public static void BindTerminalGroup(DropDownList ddl)
    {
        BindDDL("select id as value,name as text from yuantuo_terminal_group", ddl);
    }

    public static void BindTerminalByGroup(DropDownList ddl,string groupid)
    {
        BindDDL("select storeno+'-'+storename as text,id as value from [yuantuo_terminals] where groupid="+groupid, ddl);
    }

    public static void BindCity(DropDownList ddl)
    {
        BindDDL("select code as value,name as text from common_weather_city", ddl);
    }

    public static void InitDDl(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Insert(0, new ListItem("--请选择--", "-1"));
    }
    public static void BindDDL(string sql, DropDownList ddl)
    {
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            
            ddl.DataTextField = "text";
            ddl.DataValueField = "value";
            ddl.DataSource = dt;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--请选择--", "-1"));
        }
        else
        {
            ddl.Items.Insert(0,new ListItem("--请选择--","-1"));
        }
    }
    public static TerminalStatus GetTerminal()
    {
        return GetTerminal(System.Web.HttpContext.Current.Request.UserHostAddress);
    }

    public static TerminalStatus GetTerminal(string ip)
    {
       return  TerminalOnlineMonitorThread.GetTerminal(ip);
    }

    public static string GetTerminalOrderId()
    {
        return GetTerminalOrderId(GetTerminal().StorePrefix);
    }

    /// <summary>
    /// 根据终端前缀获取订单最大的ID号
    /// </summary>
    /// <param name="terminalPrefix"></param>
    /// <returns></returns>
    public static string GetTerminalOrderId(string terminalPrefix)
    {
        FT.DAL.IDataAccess dataAccess = FT.DAL.DataAccessFactory.GetDataAccess();
        SqlParameter TerminalPrefix = new SqlParameter();
        
        TerminalPrefix.ParameterName = "@TerminalPrefix";
        TerminalPrefix.SqlDbType = SqlDbType.Char;
        TerminalPrefix.Value = terminalPrefix;
        TerminalPrefix.Size = 10;
        SqlParameter maxid = new SqlParameter();
        maxid.ParameterName = "@reOrderId";
        maxid.SqlDbType = SqlDbType.VarChar;
        maxid.Direction = ParameterDirection.Output;
        maxid.Size = 50;
        SqlParameter[] cmdParams = new SqlParameter[2] { TerminalPrefix, maxid };
        dataAccess.ExecuteProcedure("P_Yuantuo_CreateOrderId", cmdParams);
        string id = maxid.SqlValue.ToString();
        //string id=maxid.Value.ToString();
        return terminalPrefix+System.DateTime.Now.ToString("yyyyMMdd")+id.PadLeft(5,'0');;

        //P_Yuantuo_CreateOrderId
    }

    public static DataTable Select(string sql)
    {
        return GetAccess().SelectDataTable(sql,"temp");
    }

    public static DataAccessHelper GetAccess()
    {

        FT.DAL.Access.AccessDataHelper access = new FT.DAL.Access.AccessDataHelper(System.Web.HttpContext.Current.Server.MapPath("~/db/db.mdb"), "admin", "");
        return access;
    }


    public static void ExeSql(string sql)
    {
       // string sql = "insert into Access_Record(computer_name,computer_ip,access_url,access_time) values('{0}','{1}','{2}','{3}')";
        GetAccess().ExecuteSql(sql);
    }
}
