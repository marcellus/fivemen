using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
///ProductOperator 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[System.Web.Script.Services.ScriptService]
public class ProductOperator : System.Web.Services.WebService
{

    public ProductOperator()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


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
        string sql = "SELECT AssignmentPlan.Name, Product.Barcode, Product.Product_Name, "
            + "Plan_Product.InShopScanner, Plan_Product.InShopTime, Plan_Product.State "
            + "FROM AssignmentPlan INNER JOIN  Plan_Product ON AssignmentPlan.Id = Plan_Product.PlanId INNER JOIN"
            + "  Product ON Plan_Product.ProductId = Product.Product_ID where AssignmentPlan.Name='" + FT.DAL.DALSecurityTool.TransferInsertField(planName) + "'";
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

}

