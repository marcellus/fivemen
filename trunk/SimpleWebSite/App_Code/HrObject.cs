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
[SimpleTable("table_hr")]
[Alias("招聘信息表")]
public class HrObject
{

    public HrObject()
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

    [SimpleColumn(Column = "job")]
    [Alias("职位名称")]
    public String Job;

    public String 职位名称
    {
        get { return Job; }
        set { Job = value; }
    }

    [SimpleColumn(Column = "num")]
    [Alias("招聘人数")]
    public String Num;

    public String 招聘人数
    {
        get { return Num; }
        set { Num = value; }
    }


    [SimpleColumn(Column = "requirement")]
    [Alias("职位描述")]
    public String Requirement;

    public String 职位描述
    {
        get { return Requirement; }
        set { Requirement = value; }
    }

    [SimpleColumn(Column = "enddate")]
    [Alias("截止日期")]
    public String EndDate;

    public String 截止日期
    {
        get { return EndDate; }
        set { EndDate = value; }
    }
}
