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
using FT.WebServiceInterface.DrvQuery;
using FT.Commons.Tools;
using FT.Commons.Cache;
using System.Collections.Generic;

/// <summary>
///FpStudentCleared 的摘要说明
/// </summary>
[SimpleTable("FP_STUDENT_CLEARED")]
[Alias("学员表完成考勤清理记录")]
[Serializable]
public class FpStudentCleared
{

    public FpStudentCleared(FpStudentObject fso) {
        this.idcard = fso.IDCARD;
        this.carType = fso.CAR_TYPE;
        this.localtype = fso.LOCALTYPE;
        this.schoolCode = fso.SCHOOL_CODE;
    }

    [SimplePK]
    [SimpleColumn(Column = "IDCARD", AllowInsert = true, ColumnType = SimpleColumnType.String)]
    private string idcard;

    [SimpleColumn(Column = "SCHOOL_CODE")]
    private string schoolCode;

    [SimpleColumn(Column = "CAR_TYPE")]
    private string carType;

    [SimpleColumn(Column = "LOCALTYPE", ColumnType = SimpleColumnType.Int)]
    private int localtype;

    public string IDCARD {
        get { return this.idcard; }
        set { this.idcard = value; }
    }

    public string SCHOOL_CODE
    {
        get { return this.schoolCode; }
        set { this.schoolCode = value; }
    }

    public string CAR_TYPE
    {
        get { return this.carType; }
        set { this.carType = value; }
    }

    public int LOCALTYPE
    {
        get { return this.localtype; }
        set { this.localtype = value; }
    }
}
