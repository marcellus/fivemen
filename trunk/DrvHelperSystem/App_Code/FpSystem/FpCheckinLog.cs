using System;
using System.Collections.Generic;
using System.Web;
using FT.Commons.Tools;
using FT.DAL.Orm;

/// <summary>
///FpCheckinLog 的摘要说明
/// </summary>
/// 
[SimpleTable("FP_CHECKIN_LOG")]
[Alias("考勤记录表")]
public class FpCheckinLog
{
    public FpCheckinLog()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [SimpleColumn(Column="ID")]
    [OracleSeqAttribute(SeqName = "SEQ_FP_CHECKIN_LOG")]
    private int id;

    [SimpleColumn(Column = "CHECKIN_IDCARD")]
    private string checkinIdcard;

    [SimpleColumn(Column = "CHECKIN_NAME")]
    private string checkinName;

    [SimpleColumn(Column="CHECKIN_DATE",ColumnType=SimpleColumnType.Date)]
    private DateTime checkinDate;

    [SimpleColumn(Column="SITE_ID",ColumnType=SimpleColumnType.Int) ]
    private int siteId;

    [SimpleColumn(Column="BUSTYPE")]
    private string bustype;

    [SimpleColumn(Column="REMARK")]
    private string remark;

    [SimpleColumn(Column="CREATER_ID")]
    private string createrId;

    [SimpleColumn(Column = "CHECKIN_STATUE", ColumnType = SimpleColumnType.Int)]
    private int checkinStatue;

    public int ID {
        get { return this.id; }
        set { this.id = value; }
    }

    public string CHECKIN_IDCARD
    {
        get { return this.checkinIdcard; }
        set { this.checkinIdcard = value; }
    }

    public string CHECKIN_NAME
    {
        get { return this.checkinName; }
        set { this.checkinName = value; }
    }

    public DateTime CHECKIN_DATE {
        get { return this.checkinDate; }
        set { this.checkinDate = value; }
    }

    public int SITE_ID
    {
        get { return this.siteId; }
        set { this.siteId = value; }
    }

    public string BUSTYPE
    {
        get { return this.bustype; }
        set { this.bustype = value; }
    }

    public string REMARK
    {
        get { return this.remark; }
        set { this.remark = value; }
    }

    public string CREATER_ID
    {
        get { return this.createrId; }
        set { this.createrId = value; }
    }

    public int CHECKIN_STATUE
    {
        get { return this.checkinStatue; }
        set { this.checkinStatue = value; }
    }

}
