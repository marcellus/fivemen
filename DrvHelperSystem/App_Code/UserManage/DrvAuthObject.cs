using System;
using System.Collections.Generic;
using System.Web;
using FT.DAL.Orm;

/// <summary>
///AuthObject 的摘要说明
/// </summary>

[SimpleTable("table_drv_auth")]
[Alias("权限分配表")]
[Serializable]
public class DrvAuthObject
{

    public DrvAuthObject()
    {
      
    }


    [SimplePK]
    [OracleSeqAttribute(SeqName = "depcode")]
    private string depcode;

    [SimpleColumn(Column="yy_ind",ColumnType=SimpleColumnType.Int)]
    private int yy_ind;

    [SimpleColumn(Column = "ylr_ind", ColumnType = SimpleColumnType.Int)]
    private int ylr_ind;

    public string DEPCODE
    {
        get;
        set;
    }

    public int YY_IND
    {
        get;
        set;
    }

    public int YLR_IND
    {
        get;
        set;
    }

}
