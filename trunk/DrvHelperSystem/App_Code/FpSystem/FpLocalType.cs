using System;
using System.Collections.Generic;
using System.Web;
using FT.DAL.Orm;

/// <summary>
///FpLocalType 的摘要说明
/// </summary>
/// 
[SimpleTable("FP_LOCALTYPE")]
[Alias("学员表")]
[Serializable]
public class FpLocalType
{
    public FpLocalType()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


    [SimplePK]
    [SimpleColumn(Column="ID",ColumnType=SimpleColumnType.Int)]
    [OracleSeqAttribute(SeqName = "SEQ_FP_LOCALTYPE")]
    private int id;

    [SimpleColumn(Column="NAME",ColumnType=SimpleColumnType.String)]
    private string name;

    [SimpleColumn(Column = "DESCP", ColumnType = SimpleColumnType.String)]
    private string descp;

    [SimpleColumn(Column = "TRAIN_TIMES", ColumnType = SimpleColumnType.Int)]
    private int trainTimes;

    [SimpleColumn(Column="KM3_VERIFY_IND")]
    private string km3VerifyInd;

    [SimpleColumn(Column = "LESSON_IND")]
    private string lessonInd;

    [SimpleColumn(Column = "KM1_IND")]
    private string km1Ind;

    [SimpleColumn(Column = "KM2_IND")]
    private string km2Ind;

    [SimpleColumn(Column = "KM2_9IN3_IND")]
    private string km2_3in9Ind;


    [SimpleColumn(Column = "KM3_IND")]
    private string km3Ind;

    public int ID {
        get { return this.id; }
        set { this.id = value; }
    }

    public string NAME {
        get { return this.name; }
        set { this.name = value; }
    }

    public string DESCP {
        get { return this.descp; }
        set { this.descp = value; }
    }

    public int TRAIN_TIMES
    {
        get { return this.trainTimes; }
        set { this.trainTimes=value; }
    }


    public string KM3_VERIFY_IND {

        get { return this.km3VerifyInd; }
        set { this.km3VerifyInd = value; }
    }

    public string LESSON_IND {
        get { return this.lessonInd; }
        set { this.lessonInd = value; }
    }

    public string KM1_IND
    {
        get { return this.km1Ind; }
        set { this.km1Ind = value; }
    }

    public string KM2_IND
    {
        get { return this.km2Ind; }
        set { this.km2Ind = value; }
    }

    public string KM2_3IN9_IND
    {
        get { return this.km2_3in9Ind; }
        set { this.km2_3in9Ind = value; }
    }

    public string KM3_IND
    {
        get { return this.km3Ind; }
        set { this.km3Ind = value; }
    }

 

}
