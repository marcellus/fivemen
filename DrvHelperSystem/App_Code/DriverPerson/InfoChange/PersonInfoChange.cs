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
///PersonInfoChange 的摘要说明
/// </summary>
[SimpleTable("table_person_change_info")]
[Alias("字典表")]
public class PersonInfoChange
{
    public PersonInfoChange()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_table_person_change_info")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_name")]
    [Alias("姓名")]
    public String Name;

    public String 姓名
    {
        get { return Name; }
        set { Name = value; }
    }



    [SimpleColumn(Column = "c_idcard_type")]
    [Alias("身份证明名称")]
    public String IdCardType;

    public String 身份证明名称
    {
        get { return IdCardType; }
        set { IdCardType = value; }
    }


    [SimpleColumn(Column = "c_idcard")]
    [Alias("身份证明号码")]
    public String IdCard;

    public String 身份证明号码
    {
        get { return IdCard; }
        set { IdCard = value; }
    }


    [SimpleColumn(Column = "c_dabh")]
    [Alias("档案编号")]
    public String Dabh;

    public String 档案编号
    {
        get { return Dabh; }
        set { Dabh = value; }
    }




    [SimpleColumn(Column = "c_old_phone")]
    [Alias("手机号码")]
    public String OldPhone;

    public String 手机号码
    {
        get { return OldPhone; }
        set { OldPhone = value; }
    }

    [SimpleColumn(Column = "c_new_phone")]
    [Alias("新的联系号码")]
    public String NewPhone;

    public String 新的联系号码
    {
        get { return NewPhone; }
        set { NewPhone = value; }
    }


    [SimpleColumn(Column = "c_new_address")]
    [Alias("新的联系地址")]
    public String NewAddress;

    public String 新的联系地址
    {
        get { return NewAddress; }
        set { NewAddress = value; }
    }

    [SimpleColumn(Column = "c_new_postcode")]
    [Alias("新的邮政编码")]
    public String NewPostCode;

    public String 新的邮政编码
    {
        get { return NewPostCode; }
        set { NewPostCode = value; }
    }

    [SimpleColumn(Column = "c_email")]
    [Alias("电子邮箱")]
    public String Email;

    public String 电子邮箱
    {
        get { return Email; }
        set { Email = value; }
    }


    [SimpleColumn(Column = "c_check_result")]
    [Alias("审核结果")]
    public String CheckResult;

    public String 审核结果
    {
        get { return CheckResult; }
        set { CheckResult = value; }
    }

    [SimpleColumn(Column = "c_check_operator")]
    [Alias("审核人")]
    public String CheckOperator;

    public String 审核人
    {
        get { return CheckOperator; }
        set { CheckOperator = value; }
    }

    [SimpleColumn(Column = "c_check_date")]
    [Alias("审核时间")]
    public String CheckDate;

    public String 审核时间
    {
        get { return CheckDate; }
        set { CheckDate = value; }
    }


    [SimpleColumn(Column = "i_checked")]
    [Alias("是否审核")]
    public int Checked;

    public int 是否审核
    {
        get { return Checked; }
        set { Checked = value; }
    }
}
