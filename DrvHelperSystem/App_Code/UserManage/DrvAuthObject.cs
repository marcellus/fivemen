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
        get { return this.depcode; }
        set { this.depcode = value; }
    }

    public int YY_IND
    {
        get { return this.yy_ind; }
        set { this.yy_ind = value; }
    }

    public int YLR_IND
    {
        get { return this.ylr_ind; }
        set { this.ylr_ind = value; }
    }

}
