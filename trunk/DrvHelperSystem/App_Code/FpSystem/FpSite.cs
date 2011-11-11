using System;
using System.Collections.Generic;
using System.Web;
using FT.DAL.Orm;

/// <summary>
///FpSite 的摘要说明
/// </summary>
/// 

[Serializable]
[SimpleTable("FP_SITE")]
[Alias("场地表")]
public class FpSite
{

    private static Dictionary<string, string> DICT_BUSTYPE;

    public static Dictionary<string, string> GetDictBusType() {
          
        if (DICT_BUSTYPE == null) {
            DICT_BUSTYPE=new Dictionary<string,string>();
            DICT_BUSTYPE.Add("lesson","上课");
            
            DICT_BUSTYPE.Add("km1","科目1考试");
            DICT_BUSTYPE.Add("km2","科目2考试");
            DICT_BUSTYPE.Add("3in9", "9选3考试");
            DICT_BUSTYPE.Add("train", "入场训练");
            DICT_BUSTYPE.Add("km3","科目3考试");
           
           //DICT_BUSTYPE.Add("collect","指纹采集");
           
        }
        return DICT_BUSTYPE;
    
    }

    public FpSite()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [SimpleColumn(Column="ID",ColumnType=SimpleColumnType.Int)]
    [OracleSeqAttribute(SeqName = "SEQ_FP_SITE")]
    private int id;

    [SimpleColumn(Column="NAME")]
    private string name;

    [SimpleColumn(Column = "LIMIT",ColumnType=SimpleColumnType.Int)]
    private int limit;

    [SimpleColumn(Column="BUSTYPE")]
    private string bustype;

    [SimpleColumn(Column="host")]
    private string host;


    public int ID {
        get { return this.id; }
        set { this.id = value; }
    }

    public string NAME {
        get { return this.name; }
        set { this.name = value; }
    }

    public int LIMIT {
        get { return this.limit; }
        set { this.limit = value; }
    }

    public string BUSTYPE {
        get { return this.bustype; }
        set { this.bustype = value; }
    }

    public string HOST {
        get { return this.host; }
        set { this.host = value; }
    }
}
