using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using FT.DAL;
using FT.DAL.Orm;

/// <summary>
///Hr 的摘要说明
/// </summary>
[SimpleTable("table_product")]
[Alias("招聘信息表")]
public class ProductObject
{

    public ProductObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "title")]
    [Alias("产品名称")]
    public String Title;

    public String 产品名称
    {
        get { return Title; }
        set { Title = value; }
    }

    [SimpleColumn(Column = "content")]
    [Alias("详细信息")]
    public String Content;

    public String 详细信息
    {
        get { return Content; }
        set { Content = value; }
    }


    [SimpleColumn(Column = "picurl")]
    [Alias("图片地址")]
    public String PicUrl;

    public String 图片地址
    {
        get { return PicUrl; }
        set { PicUrl = value; }
    }

    [SimpleColumn(Column = "typeid")]
    [Alias("类别ID")]
    public String TypeId;

    public String 类别ID
    {
        get { return TypeId; }
        set { TypeId = value; }
    }


}