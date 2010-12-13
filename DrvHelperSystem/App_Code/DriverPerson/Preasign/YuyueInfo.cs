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
///YuyueInfo 的摘要说明
/// </summary>
[SimpleTable("table_yuyue_info")]
[Alias("详细的预约信息")]
public class YuyueInfo
{
    public YuyueInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_yuyue_info")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_hmhp")]
    [Alias("号码号牌")]
    public String Hmhp;

    public String 号码号牌
    {
        get { return Hmhp; }
        set { Hmhp = value; }
    }

    [SimpleColumn(Column = "c_kscc_code")]
    [Alias("考试场次代码")]
    public String KsccCode;

    public String 考试场次代码
    {
        get { return KsccCode; }
        set { KsccCode = value; }
    }

    [SimpleColumn(Column = "c_kscc")]
    [Alias("考试场次")]
    public String Kscc;

    public String 考试场次
    {
        get { return Kscc; }
        set { Kscc = value; }
    }

    [SimpleColumn(Column = "c_ksdd_code")]
    [Alias("考试地点代码")]
    public String KsddCode;

    public String 考试地点代码
    {
        get { return KsddCode; }
        set { KsddCode = value; }
    }

    [SimpleColumn(Column = "c_ksdd")]
    [Alias("考试地点")]
    public String Ksdd;

    public String 考试地点
    {
        get { return Ksdd; }
        set { Ksdd = value; }
    }

    [SimpleColumn(Column = "i_km")]
    [Alias("科目")]
    public int Km;

    public int 科目
    {
        get { return Km; }
        set { Km = value; }
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

    [SimpleColumn(Column = "date_ksrq")]
    [Alias("考试日期")]
    public String Ksrq;

    public String 考试日期
    {
        get { return Ksrq; }
        set { Ksrq = value; }
    }

    [SimpleColumn(Column = "date_pxshrq")]
    [Alias("培训审核日期")]
    public String Pxshrq;

    public String 培训审核日期
    {
        get { return Pxshrq; }
        set { Pxshrq = value; }
    }

    [SimpleColumn(Column = "c_zjcx")]
    [Alias("准驾车型")]
    public String Zjcx;

    public String 准驾车型
    {
        get { return Zjcx; }
        set { Zjcx = value; }
    }

    [SimpleColumn(Column = "i_paibanid")]
    [Alias("排班ID")]
    public int PaibanId;

    public int 排班ID
    {
        get { return PaibanId; }
        set { PaibanId = value; }
    }

    [SimpleColumn(Column = "c_jbr")]
    [Alias("经办人")]
    public String Jbr;

    public String 经办人
    {
        get { return Jbr; }
        set { Jbr = value; }
    }


    [SimpleColumn(Column = "c_dlr_code")]
    [Alias("代理人代码")]
    public String DlrCode;

    public String 代理人代码
    {
        get { return DlrCode; }
        set { DlrCode = value; }
    }

    [SimpleColumn(Column = "c_dlr")]
    [Alias("代理人")]
    public String Dlr;

    public String 代理人
    {
        get { return Dlr; }
        set { Dlr = value; }
    }

    [SimpleColumn(Column = "c_jly_idcard")]
    [Alias("教练员身份证明号码")]
    public String JlyIdCard;

    public String 教练员身份证明号码
    {
        get { return JlyIdCard; }
        set { JlyIdCard = value; }
    }

    [SimpleColumn(Column = "c_jly_xm")]
    [Alias("教练员姓名")]
    public String JlyXm;

    public String 教练员姓名
    {
        get { return JlyXm; }
        set { JlyXm = value; }
    }

    [SimpleColumn(Column = "c_kssj")]
    [Alias("考试时间")]
    public String Kssj;

    public String 考试时间
    {
        get { return Kssj; }
        set { Kssj = value; }
    }

    [SimpleColumn(Column = "c_lsh")]
    [Alias("流水号")]
    public String Lsh;

    public String 流水号
    {
        get { return Lsh; }
        set { Lsh = value; }
    }

    [SimpleColumn(Column = "c_idcard")]
    [Alias("身份证明号码")]
    public String IdCard;

    public String 身份证明号码
    {
        get { return IdCard; }
        set { IdCard = value; }
    }

    [SimpleColumn(Column = "c_xm")]
    [Alias("姓名")]
    public String Xm;

    public String 姓名
    {
        get { return Xm; }
        set { Xm = value; }
    }

    [SimpleColumn(Column = "c_check_result")]
    [Alias("审核结果")]
    public String CheckResult;

    public String 审核结果
    {
        get { return CheckResult; }
        set { CheckResult = value; }
    }
}


