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
///CarOwnerInfoChange 的摘要说明
/// </summary>
[SimpleTable("table_car_owner_change_info")]
[Alias("字典表")]
public class CarOwnerInfoChange
{
    public CarOwnerInfoChange()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_car_owner_change_info")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_cjh")]
    [Alias("车驾号")]
    public String Cjh;

    public String 车驾号
    {
        get { return Cjh; }
        set { Cjh = value; }
    }



    [SimpleColumn(Column = "c_fdjh")]
    [Alias("发动机号")]
    public String Fdjh;

    public String 发动机号
    {
        get { return Fdjh; }
        set { Fdjh = value; }
    }


    [SimpleColumn(Column = "c_djzs")]
    [Alias("登记证书")]
    public String Djzs;

    public String 登记证书
    {
        get { return Djzs; }
        set { Djzs = value; }
    }


    [SimpleColumn(Column = "c_hmhp")]
    [Alias("号码号牌")]
    public String Hmhp;

    public String 号码号牌
    {
        get { return Hmhp; }
        set { Hmhp = value; }
    }

    [SimpleColumn(Column = "c_hpzl")]
    [Alias("号牌种类")]
    public String Hpzl;

    public String 号牌种类
    {
        get { return Hpzl; }
        set { Hpzl = value; }
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
