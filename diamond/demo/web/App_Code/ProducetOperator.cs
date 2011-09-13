using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

//using Microsoft.Web.Script.Services; 


/// <summary>
///ProducetOperator 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
//[System.Web.Script.Services.ScriptService]
public class ProducetOperator : System.Web.Services.WebService {

    public ProducetOperator () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    //[ScriptService]
    [WebMethod]
    public string GetProductInfoByBarCode(string barcode)
    {
       // ProductInfo product = new ProductInfo();
        //product.Ghs = "金至尊";
       // product.Pm = "品名1";
       // StringBuilder sb = new StringBuilder();
        ProductInfo product = FT.DAL.Orm.SimpleOrmOperator.Query<ProductInfo>(3);
        string json = JsonConvert.SerializeObject(product, Formatting.Indented);
        Console.Write(json);
        //json.Replace("\r\n", "\\r\\n");
        return json;
    }

    [WebMethod]
    public string GetProductInfoByName(string name)
    {
        List<ProductInfo> lists = this.SearchProductInfoByName(name);

        string json = JsonConvert.SerializeObject(lists, Formatting.Indented);
        json.Replace("\\r\\n", "");
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        sb.Append("\"lists\":" + json + ",");
        sb.Append("\"len\":" + lists.Count.ToString());
        sb.Append("}");

        Console.WriteLine("Json格式化列表：" + sb.ToString());
        return sb.ToString();
    }

    [WebMethod]
    public string GetPlanProductList(string planName)
    {
        string sql="SELECT AssignmentPlan.Name, Product.Barcode, Product.Product_Name, "
            +"Plan_Product.InShopScanner, Plan_Product.InShopTime, Plan_Product.State "
            +"FROM AssignmentPlan INNER JOIN  Plan_Product ON AssignmentPlan.Id = Plan_Product.PlanId INNER JOIN"
            +"  Product ON Plan_Product.ProductId = Product.Product_ID where AssignmentPlan.Name='" + FT.DAL.DALSecurityTool.TransferInsertField(planName) + "'";
        DataTable lists = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");

        string json = JsonConvert.SerializeObject(lists, Formatting.Indented);
        json.Replace("\\r\\n", "");
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        sb.Append("\"lists\":" + json + ",");
        sb.Append("\"len\":" + lists.Rows.Count.ToString());
        sb.Append("}");

        Console.WriteLine("Json格式化列表：" + sb.ToString());
        return sb.ToString();
        //Response.Write(sb.ToString());
        //Response.End();
    }

    private List<ProductInfo> SearchProductInfoByPlanId(string planName)
    {
        List<ProductInfo> lists = new List<ProductInfo>();
        ProductInfo product;
        for (int i = 0; i < 10; i++)
        {
            product = new ProductInfo();
            product.Ghs = "金至尊";
            product.Pm = "品名1";
            lists.Add(product);
        }
        return lists;
    }

    private List<ProductInfo> SearchProductInfoByName(string name)
    {
        List<ProductInfo> lists = new List<ProductInfo>();
        ProductInfo product;
        for (int i = 0; i < 10; i++)
        {
            product = new ProductInfo();
            product.Ghs = "金至尊";
            product.Pm = "品名1";
            lists.Add(product);
        }
        return lists;
    }



    /// <summary> 

        /// LINQ返回DataTable类型

        /// </summary> 

        /// <typeparam name="T"> </typeparam> 

        /// <param name="varlist"> </param> 

        /// <returns> </returns> 

        public static DataTable ToDataTable<T>(IEnumerable<T> varlist)

        {

            DataTable dtReturn = new DataTable("data");

 

            // column names 

            PropertyInfo[] oProps = null;

 

            if (varlist == null)

                return dtReturn;

 

            foreach (T rec in varlist)

            {

                if (oProps == null)

                {

                    oProps = ((Type)rec.GetType()).GetProperties();

                    foreach (PropertyInfo pi in oProps)

                    {

                        Type colType = pi.PropertyType;

 

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()

                             == typeof(Nullable<>)))

                        {

                            colType = colType.GetGenericArguments()[0];

                        }

 

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));

                    }

                }

 

                DataRow dr = dtReturn.NewRow();

 

                foreach (PropertyInfo pi in oProps)

                {

                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue

                    (rec, null);

                }

 

                dtReturn.Rows.Add(dr);

            }

            return dtReturn;

        }



    /*
     
     protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int total = 56;
            string json = JsonConvert.SerializeObject(this.mockUser(total), Formatting.Indented);
            int index = 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"total\":" + total + ",");
            sb.Append("\"rows\":" + json+",");
            sb.Append("\"index\":" + index.ToString());
            sb.Append("}");

            Console.WriteLine("Json格式化列表：" + sb.ToString());
            Response.Write(sb.ToString());
            Response.End();
        }
    }

    private List<TestUser> mockUser(int len)
    {
        List<TestUser> users = new List<TestUser>();
        TestUser user;
        for (int i = 0; i < len; i++)
        {
            user = new TestUser();
            user.Name = "姓名" + i.ToString();
            user.Nation = "中国" + i.ToString();
            user.Dept = "软件开发部" + i.ToString();
            users.Add(user);
        }
        return users;
    }
     
     */

}

