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
///FpTrainObject 的摘要说明
/// </summary>
/// 
[SimpleTable("FP_TRAIN")]
[Alias("学员入场训练表")]
public class FpTrainObject
{
    public FpTrainObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


    [SimpleColumn(Column = "ID")]
    private int id;

    [SimpleColumn(Column = "IDCARD")]
    private string idcard;

    [SimpleColumn(Column = "ENTER_TIME_1")]
    private DateTime enter_time_1;

    [SimpleColumn(Column = "LEAVE_TIME_1")]
    private DateTime leave_time_1;

    [SimpleColumn(Column = "ENTER_TIME_2")]
    private DateTime enter_time_2;

    [SimpleColumn(Column = "LEAVE_TIME_2")]
    private DateTime leave_time_2;
}
