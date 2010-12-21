using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class DriverPerson_SystemCounter_SchoolCounter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Server.ScriptTimeout = 420;
        if (!IsPostBack)
        {
            this.txtBeginDate.Value = this.txtEndDate.Value = System.DateTime.Now.ToShortDateString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        begin = this.txtBeginDate.Value;
        end = this.txtEndDate.Value;
        if (begin.Length == 0 || end.Length == 0)
        {
            WebTools.Alert(this, "必须选择待统计的时间范围！");
            return;
        }
        this.BindData();

    }

    private void BindData()
    {

        this.FirstQuery();
        
        if (dt != null)
        {
            this.SecondQuery();
            this.OnStudyQuery();
            this.Km1DkQuery();
            this.ZkDkQuery();
            this.CdDkQuery();
            this.Km3DkQuery();
            this.AllCount();
            this.Compute();
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

    }

    private DataTable dt;
    private string begin;
    private string end;

    private void FirstQuery()
    {
        string sql="select dmmc1 jxmc," +
            " '' countDate, 0 onStudy,'' km1hgl,'' zkhgl,'' cdhgl,'' km3hgl,'' zhgl,0 km1c1dk,0 km1nc1dk,0 zkc1dk,0 zknc1dk,0 cdc1dk,0 cdnc1dk,0 km3c1dk,0 km3nc1dk, sum(decode(kskm, 1, 1, 0)) km1," +
            "sum(decode(kskm, 1, 1, 0) * decode(zt, 1, 1, 0)) km1hg," +
            "sum(decode(kskm, 1, 1, 0) * decode(zt, 2, 1, 0)) km1bhg," +
            "sum(decode(kskm, 2, 1, 0) * decode(ckyy, 1, 0, 1)) zk," +
            " sum(decode(kskm, 2, 1, 0) * decode(ckyy, 1, 1, 0)) cd," +
            "sum(decode(kskm, 3, 1, 0)) km3,sum(decode(zksfhg, 1, 1, 0) * decode(kskm, 2, 1, 0) *decode(ckyy, 1, 0, 1)) zkhg," +
            "sum(decode(zksfhg, 1, 0, 1) * decode(kskm, 2, 1, 0) *decode(ckyy, 1, 0, 1)) zkbhg," +
            "sum(decode(zksfhg, 1, 1, 0) * decode(kskm, 2, 1, 0) *decode(ckyy, 1, 1, 0)) cdhg," +
            "sum(decode(zksfhg, 1, 0, 1) * decode(kskm, 2, 1, 0) *decode(ckyy, 1, 1, 0)) cdbhg," +
            "sum(decode(zt, 2, 1, 0) * decode(kskm, 3, 1, 0)) km3bhg," +
            "sum(decode(zt, 1, 1, 0) * decode(kskm, 3, 1, 0)) km3hg" +
                    " from (select distinct b.dmmc1,a.sfzmhm,a.zt,a.kskm,a.kscx,a.ksrq,a.zksfhg,a.ckyy" +
                    " from drv_admin.drv_preasign a left join drv_admin.drv_code b on a.dlr = b.dmz and b.dmlb = '42'" +
                    " where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx <> 'E' and a.ksrq between to_date('"+begin+"'," +
                    "'yyyy-MM-dd') and to_date('"+end+" 23:59:59', 'yyyy-MM-dd HH24:mi:ss')) g " +
                    "group by g.dmmc1";
        this.dt = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
    }
    private void SecondQuery()
    {
        string  sql = "select dmmc1  jxmc,sum(decode(kskm,1,1,0)) km1hg,sum(decode(kskm,2,1,0)) zkhg,sum(decode(kskm,3,1,0)) km3hg "+
            " from (select distinct d.lsh, b.dmmc1, d.sfzmhm,d.kskm,d.ksrq from drv_admin.drv_grade_log d left join " +
            "drv_admin.drv_code b on d.jxdm = b.dmz  and b.dmlb = '42' where d.glbm like '"+WholeWebConfig.Glbm+"%'  and d.zjcx <> 'E'  and d.ksrq between to_date('"+begin+"'," +
                    "'yyyy-MM-dd') and to_date('"+end+" 23:59:59', 'yyyy-MM-dd HH24:mi:ss') and d.zt = 1" +
            " and not exists(select 1 from drv_admin.drv_preasign m where m.lsh=d.lsh)) g group by dmmc1";
        DataTable dttmp= WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
        if(dttmp!=null)
        {
            DataRow drsrc;
            DataRow drdest;
            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                drsrc = dttmp.Rows[i];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    drdest = dt.Rows[j];
                    if (drsrc["jxmc"] == null && drdest["jxmc"]!= null)
                    {
                        continue;
                    }
                    else if ((drsrc["jxmc"] == null && drdest["jxmc"] == null)||drsrc["jxmc"].ToString()==drdest["jxmc"].ToString())
                    {
                        drdest["km1hg"]=Convert.ToInt32(drdest["km1hg"].ToString())+Convert.ToInt32(drsrc["km1hg"].ToString());
                        drdest["zkhg"] = Convert.ToInt32(drdest["zkhg"].ToString()) + Convert.ToInt32(drsrc["zkhg"].ToString());
                        //drdest["cdhg"] = Convert.ToInt32(drdest["cdhg"].ToString()) + Convert.ToInt32(drsrc["cdhg"].ToString());
                        drdest["km3hg"] = Convert.ToInt32(drdest["km3hg"].ToString()) + Convert.ToInt32(drsrc["km3hg"].ToString());
                        break;
                    }
                }

            }
        }
    }
    private void OnStudyQuery()
    {
        String sql = "select dmmc1 jxmc,count(1) onStudy from(select distinct q.lsh," +
           " c.dmmc1 as dmmc1, q.sfzmhm, q.zjcx  from ( select distinct a.lsh, b.jxmc, a.sfzmhm, a.zjcx" +
           " from drv_admin.drv_flow a " +
           "   left join drv_admin.drv_examcard b on a.lsh = b.lsh" +
           "  where a.glbm like '"+WholeWebConfig.Glbm+"%'" +
           " and a.zjcx <> 'E' and a.KSSJ between to_date('"+begin.Substring(0,4)+"-1-1','yyyy-MM-dd') and sysdate" +
           "   and a.ywlx in ('A', 'B')   ) q" +
           " left join drv_admin.drv_code c on q.jxmc = c.dmz" +
           "   and c.dmlb = '42') m group by dmmc1";
        DataTable dttmp = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
        if (dttmp != null)
        {
            DataRow drsrc;
            DataRow drdest;
            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                drsrc = dttmp.Rows[i];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    drdest = dt.Rows[j];
                    if (drsrc["jxmc"] == null && drdest["jxmc"] != null)
                    {
                        continue;
                    }
                    else if ((drsrc["jxmc"] == null && drdest["jxmc"] == null) || drsrc["jxmc"].ToString() == drdest["jxmc"].ToString())
                    {
                        drdest["onStudy"] = drsrc["onStudy"];
                        break;
                    }
                }

            }
        }
    }
    private void Km1DkQuery()
    {
        string sql = "select dmmc1 jxmc,0 zkc1dk,0 zknc1dk,0 cdc1dk,0 cdnc1dk,0 km3c1dk,0" +
           " km3nc1dk,sum(decode(zjcx,'C1',1,0)) km1c1dk,sum(decode(zjcx,'C1',0,1)) km1nc1dk from "+
           " ((select distinct q.lsh,c.dmmc1 " +
           " as dmmc1,q.sfzmhm,q.zjcx from " +
   "(select distinct  a.lsh,b.jxmc,a.sfzmhm,a.zjcx from drv_admin.drv_flow a left join  drv_admin.drv_examcard b on a.sfzmhm=b.sfzmhm" +
   " where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.zjcx<>'E' and a.ywlx in ('A','B')) q left join " +
   "drv_admin.drv_code c on q.jxmc=c.dmz and c.dmlb='42'  ) minus ( select distinct d.lsh,b.dmmc1,d.sfzmhm,d.zjcx" +
   " from drv_admin.drv_grade_log d left join  drv_admin.drv_code b on d.jxdm=b.dmz and b.dmlb='42' where d.glbm like '"+WholeWebConfig.Glbm+"%'" +
   " and d.zjcx<>'E' and d.kskm=1 and d.zt=1))  e" +
   " where exists  ( select 1 from drv_admin.drv_examcard c where c.sfzmhm=e.sfzmhm and c.yxqz>sysdate-1)" +
   " group by dmmc1";
        DataTable dttmp = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
        if (dttmp != null)
        {
            DataRow drsrc;
            DataRow drdest;
            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                drsrc = dttmp.Rows[i];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    drdest = dt.Rows[j];
                    if (drsrc["jxmc"] == null && drdest["jxmc"] != null)
                    {
                        continue;
                    }
                    else if ((drsrc["jxmc"] == null && drdest["jxmc"] == null) || drsrc["jxmc"].ToString() == drdest["jxmc"].ToString())
                    {
                        drdest["km1c1dk"] = drsrc["km1c1dk"];
                        drdest["km1nc1dk"] = drsrc["km1nc1dk"];
                        break;
                    }
                }

            }
        }
    }
    private void ZkDkQuery()
    {
        string sql = "select dmmc1 jxmc,0 km1c1dk,0 km1nc1dk,0 cdc1dk,0 cdnc1dk,0 km3c1dk," +
            "0 km3nc1dk,sum(decode(kscx,'C1',1,0)) zkc1dk,sum(decode(kscx,'C1',0,1)) zknc1dk from ((select" +
            " distinct  a.lsh,b.dmmc1,a.sfzmhm,a.kscx from drv_admin.drv_preasign a left join " +
            "drv_admin.drv_code b on a.dlr=b.dmz and b.dmlb='42' where exists ( select 1 from drv_admin.drv_flow f where f.sfzmhm=a.sfzmhm" +
            " and f.ywlx in ('A','B') ) and a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx<>'E' and a.kskm=1 and a.zt=1 ) minus (" +
            " select distinct a.lsh,b.dmmc1,a.sfzmhm,a.kscx from drv_admin.drv_preasign a left join " +
            "drv_admin.drv_code b on a.dlr=b.dmz and b.dmlb='42' where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx<>'E' and a.kskm=2 and ((a.ckyy<>1" +
            " and a.zksfhg=1) or a.zt=1) )) " +
            " e where exists (select 1 from drv_admin.drv_examcard c where c.sfzmhm=e.sfzmhm and c.yxqz>sysdate-1)" +
            " group by dmmc1";
        DataTable dttmp = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
        if (dttmp != null)
        {
            DataRow drsrc;
            DataRow drdest;
            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                drsrc = dttmp.Rows[i];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    drdest = dt.Rows[j];
                    if (drsrc["jxmc"] == null && drdest["jxmc"] != null)
                    {
                        continue;
                    }
                    else if ((drsrc["jxmc"] == null && drdest["jxmc"] == null) || drsrc["jxmc"].ToString() == drdest["jxmc"].ToString())
                    {
                        drdest["zkc1dk"] = drsrc["zkc1dk"];
                        drdest["zknc1dk"] = drsrc["zknc1dk"];
                        break;
                    }
                }

            }
        }
    }
    private void CdDkQuery()
    {
        string sql = "select dmmc1 jxmc,0 zkc1dk,0 zknc1dk,0 km1c1dk,0 km1nc1dk,0 km3c1dk," +
            "0 km3nc1dk,sum(decode(kscx,'C1',1,0)) cdc1dk,sum(decode(kscx,'C1',0,1)) cdnc1dk from" +
            " ((select distinct  a.lsh,b.dmmc1,a.sfzmhm,a.kscx from drv_admin.drv_preasign a left join drv_admin.drv_code b" +
            " on a.dlr=b.dmz and b.dmlb='42' where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx<>'E' and a.kskm=2 and ((a.ckyy<>1 and a.zksfhg=1)) )" +
            " minus(select distinct a.lsh,b.dmmc1,a.sfzmhm,a.kscx from drv_admin.drv_preasign a" +
            " left join drv_admin.drv_code b on a.dlr=b.dmz and b.dmlb='42'" +
            " where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx<>'E' and a.kskm=2 and ((a.ckyy=1 and a.zksfhg=1)))) " +
            " e where exists ( select 1 from drv_admin.drv_examcard c where c.sfzmhm=e.sfzmhm and c.yxqz>sysdate-1)" +
            " group by dmmc1";
        DataTable dttmp = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
        if (dttmp != null)
        {
            DataRow drsrc;
            DataRow drdest;
            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                drsrc = dttmp.Rows[i];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    drdest = dt.Rows[j];
                    if (drsrc["jxmc"] == null && drdest["jxmc"] != null)
                    {
                        continue;
                    }
                    else if ((drsrc["jxmc"] == null && drdest["jxmc"] == null) || drsrc["jxmc"].ToString() == drdest["jxmc"].ToString())
                    {
                        drdest["cdc1dk"] = drsrc["cdc1dk"];
                        drdest["cdnc1dk"] = drsrc["cdnc1dk"];
                        break;
                    }
                }

            }
        }
    }
    private void Km3DkQuery()
    {
        string sql = "select dmmc1 jxmc,0 zkc1dk,0 zknc1dk,0 cdc1dk,0 cdnc1dk,0 km1c1dk," +
            "0 km1nc1dk,sum(decode(kscx,'C1',1,0)) km3c1dk,sum(decode(kscx,'C1',0,1)) km3nc1dk from ((select distinct" +
            "  a.lsh,b.dmmc1,a.sfzmhm,a.kscx from drv_admin.drv_preasign a left join  drv_admin.drv_code b on a.dlr=b.dmz and" +
            " b.dmlb='42' where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx<>'E' and a.kskm=2 and ((a.ckyy=1 and a.zksfhg=1)  or a.zt=1)  )" +
            " minus (  select distinct a.lsh,b.dmmc1,a.sfzmhm,a.kscx from drv_admin.drv_preasign a" +
            " left join drv_admin.drv_code b on a.dlr=b.dmz and b.dmlb='42' where a.glbm like '"+WholeWebConfig.Glbm+"%' and a.kscx<>'E' and a.kskm=3 and a.zt=1)" +
            " )  e where exists (select 1 from drv_admin.drv_examcard c where c.sfzmhm=e.sfzmhm and c.yxqz>sysdate-1)" +
            " group by dmmc1";
        DataTable dttmp = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmpdb");
        if (dttmp != null)
        {
            DataRow drsrc;
            DataRow drdest;
            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                drsrc = dttmp.Rows[i];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    drdest = dt.Rows[j];
                    if (drsrc["jxmc"] == null && drdest["jxmc"] != null)
                    {
                        continue;
                    }
                    else if ((drsrc["jxmc"] == null && drdest["jxmc"] == null) || drsrc["jxmc"].ToString() == drdest["jxmc"].ToString())
                    {
                        drdest["km3c1dk"] = drsrc["km3c1dk"];
                        drdest["km3nc1dk"] = drsrc["km3nc1dk"];
                        break;
                    }
                }

            }
        }
    }
    private void AllCount()
    {
        DataRow dr = dt.NewRow();
        dr["jxmc"] = "总计";
        dr["onStudy"] = 0;
        dr["km1hg"] = 0;
        dr["km1bhg"] = 0;
        dr["km1c1dk"] = 0;
        dr["km1nc1dk"] = 0;

        dr["zkhg"] = 0;
        dr["zkbhg"] = 0;
        dr["zkc1dk"] = 0;
        dr["zknc1dk"] = 0;

        dr["cdhg"] = 0;
        dr["cdbhg"] = 0;
        dr["cdc1dk"] = 0;
        dr["cdnc1dk"] = 0;

        dr["km3hg"] = 0;
        dr["km3bhg"] = 0;
        dr["km3c1dk"] = 0;
        dr["km3nc1dk"] = 0;
        DataRow drtmp = null;
        for (int i = 0; i <dt.Rows.Count; i++)
        {
            drtmp = dt.Rows[i];
            this.AddDrCount(drtmp, dr, "onStudy");
            this.AddDrCount(drtmp, dr, "km1hg");
            this.AddDrCount(drtmp, dr, "km1bhg");
            this.AddDrCount(drtmp, dr, "km1c1dk");
            this.AddDrCount(drtmp, dr, "km1nc1dk");

            this.AddDrCount(drtmp, dr, "zkhg");
            this.AddDrCount(drtmp, dr, "zkbhg");
            this.AddDrCount(drtmp, dr, "zkc1dk");
            this.AddDrCount(drtmp, dr, "zknc1dk");

            this.AddDrCount(drtmp, dr, "cdhg");
            this.AddDrCount(drtmp, dr, "cdbhg");
            this.AddDrCount(drtmp, dr, "cdc1dk");
            this.AddDrCount(drtmp, dr, "cdnc1dk");

            this.AddDrCount(drtmp, dr, "km3hg");
            this.AddDrCount(drtmp, dr, "km3bhg");
            this.AddDrCount(drtmp, dr, "km3c1dk");
            this.AddDrCount(drtmp, dr, "km3nc1dk");
        }
        this.dt.Rows.Add(dr);
    }

    private void AddDrCount(DataRow drsrc,DataRow drdest,string col)
    {
        drdest[col] = Convert.ToInt32(drdest[col].ToString()) + Convert.ToInt32(drsrc[col].ToString());
    }

    private string ComputeHgl(DataRow dr,string hgcol, string bhgcol)
    {
        int a = int.Parse(dr[hgcol].ToString());
        int b = int.Parse(dr[bhgcol].ToString());
        return MathHelper.Percent(a, b);

    }
    private string ComputeZHgl(DataRow dr)
    {
        int a=int.Parse(dr["km1hg"].ToString())+int.Parse(dr["cdhg"].ToString())
            +int.Parse(dr["zkhg"].ToString())+int.Parse(dr["km3hg"].ToString());
          int b=int.Parse(dr["km1bhg"].ToString())+int.Parse(dr["cdbhg"].ToString())
            +int.Parse(dr["zkbhg"].ToString())+int.Parse(dr["km3bhg"].ToString());
        b=a+b;
        return MathHelper.Percent(a, b);

    }
    private void Compute()
    {
        String hgl = "0.00%";
        DataRow dr = null;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dr = dt.Rows[i];
            hgl = this.ComputeHgl(dr, "km1hg", "km1bhg");
            // log.debug("计算出的科目一合格率为：" + hgl);
            dr["km1hgl"] = (hgl);
            hgl = this.ComputeHgl(dr, "zkhg", "zkbhg");
            // log.debug("计算出的科目一合格率为：" + hgl);
            dr["zkhgl"] = (hgl);

            hgl = this.ComputeHgl(dr, "cdhg", "cdbhg");
            // log.debug("计算出的科目一合格率为：" + hgl);
            dr["cdhgl"] = (hgl);


            hgl = this.ComputeHgl(dr, "km3hg", "km3bhg");
            // log.debug("计算出的科目一合格率为：" + hgl);
            dr["km3hgl"] = (hgl);
            hgl = this.ComputeZHgl(dr);
            // log.debug("计算出的科目一合格率为：" + hgl);
            dr["zhgl"] = (hgl);
        }

         
    }
}
