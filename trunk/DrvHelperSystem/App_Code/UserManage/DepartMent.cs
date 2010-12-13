using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;

/// <summary>
///DepartMent 的摘要说明
/// </summary>
[SimpleTable("table_departments")]
[Alias("部门登记表")]
public class DepartMent
{
    public DepartMent()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName="seq_department")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_connector")]
    [Alias("联系人")]
    public String Connector;

    public String 联系人
    {
        get { return Connector; }
        set { Connector = value; }
    }


    [SimpleColumn(Column = "c_deptype")]
    [Alias("部门类别")]
    public String DepType;

    public String 部门类别
    {
        get { return DepType; }
        set { DepType = value; }
    }

    [SimpleColumn(Column = "c_mobile")]
    [Alias("联系电话")]
    public String Mobile;

    public String 联系电话
    {
        get { return Mobile; }
        set { Mobile = value; }
    }
    [SimpleColumn(Column = "c_phone")]
    [Alias("固定电话")]
    public String Phone;

    public String 固定电话
    {
        get { return Phone; }
        set { Phone = value; }
    }
    [SimpleColumn(Column = "c_companycode")]
    [Alias("机构证书代码")]
    public String CompanyCode;

    public String 机构证书代码
    {
        get { return CompanyCode; }
        set { CompanyCode = value; }
    }
    [SimpleColumn(Column = "c_depfullname")]
    [Alias("部门全名")]
    public String DepFullName;

    public String 部门全名
    {
        get { return DepFullName; }
        set { DepFullName = value; }
    }

    [SimpleColumn(Column = "c_depnickname")]
    [Alias("部门简称")]
    public String DepNickName;

    public String 部门简称
    {
        get { return DepNickName; }
        set { DepNickName = value; }
    }
    [SimpleColumn(Column = "c_depcode")]
    [Alias("部门代码")]
    public String DepCode;

    public String 部门代码
    {
        get { return DepCode; }
        set { DepCode = value; }
    }
    [SimpleColumn(Column = "c_parentcode")]
    [Alias("管理单位代码")]
    public String ParentCode;

    public String 管理单位代码
    {
        get { return ParentCode; }
        set { ParentCode = value; }
    }
}
