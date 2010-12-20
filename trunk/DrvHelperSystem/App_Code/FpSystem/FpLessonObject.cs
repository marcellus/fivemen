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
///FpLessonObject 的摘要说明
/// </summary>
/// 
[SimpleTable("FP_LESSON")]
[Alias("上课记录表")]
public class FpLessonObject
{
    public FpLessonObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimpleColumn(Column="ID")]
    private int id;

    [SimpleColumn(Column="IDCARD")]
    private string idcard;

    [SimpleColumn(Column="ENTER_TIME_1")]
    private DateTime enter_time_1;

    [SimpleColumn(Column="LEAVE_TIME_1")]
    private DateTime leave_time_1;

    [SimpleColumn(Column = "ENTER_TIME_2")]
    private DateTime enter_time_2;

    [SimpleColumn(Column = "LEAVE_TIME_2")]
    private DateTime leave_time_2;


    public string IDCARD
    {
        get { return this.idcard; }
        set { this.idcard = value; }
    }

    public DateTime ENTER_TIME_1
    {
        get { return this.enter_time_1; }
        set { this.enter_time_1 = value; }
    }

    public DateTime LEAVE_TIME_1
    {
        get { return this.leave_time_1; }
        set { this.leave_time_1 = value; }
    }

    public DateTime ENTER_TIME_2
    {
        get { return this.enter_time_2; }
        set { this.enter_time_2 = value; }
    }

    public DateTime LEAVE_TIME_2
    {
        get { return this.leave_time_2; }
        set { this.leave_time_2 = value; }
    }


}
