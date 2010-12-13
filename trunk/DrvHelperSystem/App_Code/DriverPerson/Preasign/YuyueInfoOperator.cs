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
using FT.DAL;
using System.Collections;
using FT.WebServiceInterface.WebService;
using FT.WebServiceInterface.DrvQuery;

/// <summary>
///YuyueInfoOperator 的摘要说明
/// </summary>
public class YuyueInfoOperator
{
    public YuyueInfoOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static void SaveInfoCheckFail(YuyueInfo info, string name,string msg)
    {
        info.Checked = 2;
        info.CheckOperator = name;
        info.Jbr = name;
        info.CheckResult = msg;
        SimpleOrmOperator.Update(info);
    }

    public static DrvPreasignRequest ConvertInfoToRequest(YuyueInfo info)
    {
        DrvPreasignRequest req = new DrvPreasignRequest();

        req.Lsh = info.Lsh;
        req.Dlr = info.DlrCode;
        req.Jbr = info.CheckOperator;
        //req.setKchp("");
        //44051 上午第一场
        req.Kscc = info.KsccCode;
        req.Jly = info.JlyIdCard;
        req.Kchp = info.Hmhp;
        //汕头大学路考场
        req.Ksdd = info.KsddCode;
        req.Pxshrq = info.Pxshrq;
        String sn = System.Configuration.ConfigurationManager.AppSettings["Drv_Yuyue_Sn"];

        req.Sn = sn;
        req.Xxsj = "0";
        req.Kskm = info.Km;
        req.Ykrq = info.Ksrq;
        return req;
    }
    public static void Check(int id,string name)
    {
        YuyueInfo info = SimpleOrmOperator.Query<YuyueInfo>(id);
        string glbm = System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_glbm"];
        int bkjg = int.Parse(ConfigurationManager.AppSettings["DrvHelperSystem_bkjg"].ToString());
        string idcard = info.IdCard;
        DateTime yyrq = Convert.ToDateTime(info.Ksrq);
        int km = info.Km;
        TempStudentInfo student = DrvQueryHelper.QueryStudent(glbm, info.IdCard);
        if (student == null)
        {
            SaveInfoCheckFail(info,name, "该学员不是本地车管所报名的！");
            return;
        }
        info.Dlr = student.jxmc;
        info.DlrCode = student.jxdm;
        info.JlyIdCard = student.jly;
        info.Km = km;
        info.Lsh = student.lsh;
        info.Xm = student.name;
        info.Zjcx = student.zkcx;
        if (DateTime.Parse(student.yxqz).CompareTo(yyrq) < 0)
        {
            SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "的准考证明有效期到" + student.yxqz + "截止！");
            return;

        }
        if (student.jxdm != null && student.jxdm!=info.DlrCode)
        {
            SaveInfoCheckFail(info, name, "驾校学员只能通过相关驾校帮您预约！");
            return;

        }

        
        ArrayList daylimits = SimpleOrmOperator.QueryConditionList<YuyueDayLimit>(" where c_cartype like '%" + student.zkcx + "%' and i_km=" + km);
        TempKscjInfo kscj = DrvQueryHelper.QueryKscj(glbm, idcard);
        YuyueDayLimit daylimit = null;
        if (daylimits != null && daylimits.Count > 0)
        {
            daylimit = daylimits[0] as YuyueDayLimit;
        }
        if (kscj != null)
        {
            if (km == 1)
            {
                if (kscj.km1 == 1)
                {
                    SaveInfoCheckFail(info,name, "身份证明号码" + idcard + "的科目一已经合格！");
                    return;
                }
            }
            else if (km == 2)
            {
                if (kscj.km2yyrq != null)
                {
                    if (kscj.km2 == 1)
                    {
                        SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "的科目二已经合格！");
                        return;
                    }
                    if (kscj.km2 == 2)
                    {
                        if (yyrq.CompareTo(DateTime.Parse(kscj.km2yyrq).AddDays(bkjg)) < 0)
                        {
                            SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "上次考试时间为：" + kscj.km2yyrq + ",科目二补考必须在上一次考试" + bkjg + "天之后！");
                            return;
                        }
                    }
                }
                else if (kscj.km1 == 1 && daylimit != null)
                {
                    if (yyrq.CompareTo(DateTime.Parse(kscj.km1yyrq).AddDays(daylimit.Days)) < 0)
                    {
                        SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "上次考试时间为：" + kscj.km1yyrq + ",申请" + daylimit.CarType + "牌照的科目二考试必须在" + daylimit.Days + "天之后！");
                        return;
                    }
                }
                else
                {
                    SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "科目一还没有合格！");
                    return;
                }
            }

            else if (km == 3)
            {
                if (kscj.km3yyrq != null)
                {
                    if (kscj.km3 == 1)
                    {
                        SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "的科目三已经合格！");
                        return;
                    }
                    if (kscj.km3 == 2)
                    {
                        if (yyrq.CompareTo(DateTime.Parse(kscj.km3yyrq).AddDays(bkjg)) < 0)
                        {
                            SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "上次考试时间为：" + kscj.km2yyrq + ",科目三补考必须在上一次考试" + bkjg + "天之后！");
                            return;
                        }
                    }
                }
                else if (kscj.km2 == 1 && daylimit != null)
                {
                    if (yyrq.CompareTo(DateTime.Parse(kscj.km2yyrq).AddDays(daylimit.Days)) < 0)
                    {
                        SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "上次考试时间为：" + kscj.km2yyrq + ",申请" + daylimit.CarType + "牌照的科目三考试必须在" + daylimit.Days + "天之后！");
                        return;
                    }
                }
                else
                {
                    SaveInfoCheckFail(info, name, "身份证明号码" + idcard + "科目二还没有合格！");
                    return;
                }
            }
        }
        if (info != null&&info.Checked==0)
        {
            info.CheckOperator = name;
            info.Jbr = name;
             TmriResponse resp=null;
            try
            {
                resp = DriverInterface.WriteDrvBaseTmriRequest(ConvertInfoToRequest(info));
                //resp= DriverInterface.yuyueInfo(info);
            }
            catch (Exception exe)
            {
                info.CheckResult = exe.Message;
                SimpleOrmOperator.Update(info);
                return;
            }
            if (resp.Code == 0)
            {
                info.Checked = 1;
                info.CheckResult = resp.Message;
                SimpleOrmOperator.Update(info);
                DataAccessFactory.GetDataAccess().ExecuteSql("update table_yuyue_limit set i_checked_num=i_checked_num+1 where i_checked_num<i_used_num and id="+info.PaibanId);
            }
            else
            {
                info.Checked = 2;
                info.CheckResult = resp.Message;
                SimpleOrmOperator.Update(info);
                
            }
        }
    }
}
