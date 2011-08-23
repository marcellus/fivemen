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
    private int id;

    [SimpleColumn(Column="NAME",ColumnType=SimpleColumnType.String)]
    private string name;

    [SimpleColumn(Column = "DESCP", ColumnType = SimpleColumnType.String)]
    private string descp;

    [SimpleColumn(Column = "TRAIN_TIMES", ColumnType = SimpleColumnType.Int)]
    private int trainTimes;


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
}
