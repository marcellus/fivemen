﻿using System;
using System.Collections.Generic;
using System.Web;
using FT.DAL.Orm;

/// <summary>
///FpSite 的摘要说明
/// </summary>
/// 

[SimpleTable("FP_SITE")]
[Alias("场地表")]
public class FpSite
{
    public FpSite()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [SimpleColumn(Column="ID")]
    private int id;

    [SimpleColumn(Column="NAME")]
    private string name;

    [SimpleColumn(Column = "LIMIT")]
    private int limit;

    [SimpleColumn(Column="BUSTYPE")]
    private string bustype;

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
}