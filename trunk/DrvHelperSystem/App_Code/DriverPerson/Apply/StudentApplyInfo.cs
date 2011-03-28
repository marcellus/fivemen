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
///StudentApplyInfo 的摘要说明
/// </summary>
[SimpleTable("table_student_apply_info")]
[Alias("预录入详细信息")]
public class StudentApplyInfo
{
    public StudentApplyInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_student_apply_info")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

   

    [SimpleColumn(Column = "sfzmhm")]
    [Alias("身份证明号码")]
    public String Sfzmhm;

    [SimpleColumn(Column = "sfzmmc")]
    [Alias("身份证明名称")]
    public String Sfzmmc;

    [SimpleColumn(Column = "i_hmcd")]
    [Alias("身份证明号码长度")]
    public String Hmcd;

    [SimpleColumn(Column = "i_xb")]
    [Alias("性别")]
    public String Xb;


    [SimpleColumn(Column = "c_csrq")]
    [Alias("出生日期")]
    public String Csrq;


    [SimpleColumn(Column = "c_gj")]
    [Alias("国籍")]
    public String Gj;



    [SimpleColumn(Column = "c_djzsxzqh")]
    [Alias("登记住所详细区划")]
    public String Djzsxzqh;


    [SimpleColumn(Column = "c_djzsxxdz")]
    [Alias("登记住所详细地址")]
    public String Djzsxxdz;


    [SimpleColumn(Column = "c_lxzsxzqh")]
    [Alias("联系住所行政区划")]
    public String Lxzsxzqh;


    [SimpleColumn(Column = "c_lxzsxxdz")]
    [Alias("联系住所详细地址")]
    public String Lxzsxxdz;

    [SimpleColumn(Column = "c_lxzsyzbm")]
    [Alias("联系住所邮政编码")]
    public String Lxzsyzbm;

    [SimpleColumn(Column = "c_ly")]
    [Alias("来源")]
    public String Ly;

    [SimpleColumn(Column = "c_xzqh")]
    [Alias("行政区划")]
    public String Xzqh;


    [SimpleColumn(Column = "c_lxdh")]
    [Alias("联系电话")]
    public String Lxdh;


    [SimpleColumn(Column = "c_zzzm")]
    [Alias("暂住证明")]
    public String Zzzm;



    [SimpleColumn(Column = "c_zkzmbh")]
    [Alias("准考证明编号")]
    public String Zkzmbh;


    [SimpleColumn(Column = "c_dabh")]
    [Alias("档案编号")]
    public String Dabh;



    [SimpleColumn(Column = "c_zkcx")]
    [Alias("准考车型")]
    public String Zkcx;

  




    


    [SimpleColumn(Column = "c_dzyx")]
    [Alias("电子邮箱")]
    public String Dzyx;

    [SimpleColumn(Column = "c_sjhm")]
    [Alias("手机号码")]
    public String Sjhm;


    [SimpleColumn(Column = "c_sg")]
    [Alias("身高")]
    public String Sg;


    [SimpleColumn(Column = "i_zsl")]
    [Alias("左视力")]
    public String Zsl;

    [SimpleColumn(Column = "i_ysl")]
    [Alias("右视力")]
    public String Ysl;

    [SimpleColumn(Column = "i_bsl")]
    [Alias("辨色力")]
    public int Bsl;

    [SimpleColumn(Column = "i_tl")]
    [Alias("听力")]
    public int Tl;


    [SimpleColumn(Column = "i_sz")]
    [Alias("上肢")]
    public int Sz;

    [SimpleColumn(Column = "i_zxz")]
    [Alias("左下肢")]
    public int Zxz;

    [SimpleColumn(Column = "i_yxz")]
    [Alias("右下肢")]
    public int Yxz;


    [SimpleColumn(Column = "i_qgjb")]
    [Alias("躯干颈部")]
    public int Qgjb;


    [SimpleColumn(Column = "c_tjrq")]
    [Alias("体检日期")]
    public String Tjrq;


    [SimpleColumn(Column = "c_tjyymc")]
    [Alias("体检医院名称")]
    public String Tjyymc;

    [SimpleColumn(Column = "c_photo_src")]
    [Alias("图片路径")]
    public String PhotoSrc;

    [SimpleColumn(Column = "i_photo_syn")]
    [Alias("图片是否同步")]
    public int PhotoSyn;

    [SimpleColumn(Column = "c_jxmc",AllowUpdate=false)]
    [Alias("驾校名称")]
    public String Jxmc;

    [SimpleColumn(Column = "c_jxdm",AllowUpdate=false)]
    [Alias("驾校代码")]
    public String Jxdm;

    




    [SimpleColumn(Column = "c_lsh")]
    [Alias("流水号")]
    public String Lsh;

    public String 流水号
    {
        get { return Lsh; }
        set { Lsh = value; }
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
