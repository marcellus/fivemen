using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;
using FT.DAL;
using FT.WebServiceInterface.WebService;
using System.Data.Common;
using System.Data.OracleClient;
using System.IO;
using FT.Commons.Tools;
using System.Drawing;


/// <summary>
///StudentApplyInfoOperator 的摘要说明
/// </summary>
public class StudentApplyInfoOperator
{
    public StudentApplyInfoOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static bool CheckInfoAndPhoto(StudentApplyInfo info, string optname)
    {
        CheckInfo(info, optname);
        return CheckPhoto(info);
    }


    public static void CheckInfo(StudentApplyInfo info,string optname)
    {
        Check(info.Id,optname);
    }

    public static bool CheckPhoto(StudentApplyInfo info)
    {
        bool result = false;
        try
        {
            MemoryStream ms = new MemoryStream(GetPhoto(info.Sfzmhm));

            Image image = Image.FromStream(ms, true);

           // result = DriverInterface.WritePersonPhoto(info.Sfzmmc, info.Sfzmhm, image);
            string zp = ImageHelper.ImageToBase64Str(image);
            string[] res= DrvNewInterface.WritePhoto(info.Sfzmhm,zp);
            if (res.Length == 2)
            {
                info.PhotoSyn = 1;
                result= SimpleOrmOperator.Update(info);
            }
            else if(res.Length==3) {
                info.PhotoSyn = 2;
                info.CheckResult = res[2];
                SimpleOrmOperator.Update(info);
            }
        }
        catch (System.Exception e)
        {
            result = false;
            info.PhotoSyn = 2;
            SimpleOrmOperator.Update(info);
            
        	
        }
       
    
        return result;
    }


    public static bool UpdatePhoto(string sfzmhm,byte[] buff)
    {
        string sql="update table_student_apply_info_i set blob_photo=:photo where sfzmhm='"+sfzmhm+"'";
        System.Data.Common.DbParameter  param=new OracleParameter("photo",OracleType.Blob,buff.Length);
        param.Value = buff;
       return   DataAccessFactory.GetDataAccess().ExecuteSqlByParam(sql,param);
    }

    public static byte[] GetPhoto(string sfzmhm)
    {
        byte[] img = new byte[0];
        string sql = "select blob_photo from table_student_apply_info_i where sfzmhm='" + sfzmhm + "'";
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "photo");
        if (dt != null && dt.Rows.Count >0)
        {
            if (dt.Rows[0][0]!=null&&!Convert.IsDBNull(dt.Rows[0][0]))
            img = (byte[])dt.Rows[0][0];
        }
        return img;
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<StudentApplyInfo>(id);
    }

    public static StudentApplyInfo Get(int id)
    {
        return SimpleOrmOperator.Query<StudentApplyInfo>(id);
        // SimpleOrmOperator.Delete<WeekRecord>(id);
    }


    public static void Check(int id, string optname)
    {
        StudentApplyInfo info = SimpleOrmOperator.Query<StudentApplyInfo>(id);
        string glbm = System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_glbm"];
        TmriResponse resp = null;
        string[] res=new string[]{};
        try
        {
            string useold = System.Configuration.ConfigurationManager.AppSettings["Drv_Apply_Use_Old"];
            if (useold == "true")
            {
                resp = new TmriResponse();
                bool resultold = DriverInterface.WriteApplyOld(ConvertInfoToRequest(info));
                // resultold ? 0 : 2;
                if (resultold)
                {
                    resp.Code = 0;
                    resp.Message = "更新成功";
                }
                else
                {
                    resp.Code = 2;
                    resp.Message = "更新不成功";
                }

            }
           // resp = DriverInterface.WriteDrvBaseTmriRequest(ConvertInfoToRequest(info));
            //resp= DriverInterface.yuyueInfo(info);
            info.Hmcd = "1";

            string xml = ConvertInfoToRequest(info).ToXml();
            res  = DrvNewInterface.WritePresign(xml);
            
        }
        catch (Exception exe)
        {
            SaveInfoCheckFail(info, optname, exe.Message);
            //info.CheckResult = exe.Message;
            // SimpleOrmOperator.Update(info);
            return;
        }
        if(res.Length==2)
        //if (resp.Code == 0 || resp.Code == 1)
        {
            info.Checked = 1;
            info.CheckResult = res[1];
            SimpleOrmOperator.Update(info);
            StudentApplyInfoChecked infoChecked = new StudentApplyInfoChecked();
            infoChecked.from(info);
            bool isOk = SimpleOrmOperator.Create(infoChecked);
            if (!isOk)
            {
                SimpleOrmOperator.Update(infoChecked);
            }

            //DataAccessFactory.GetDataAccess().ExecuteSql("update table_student_apply_info set i_tpchecked_num=i_tpchecked_num+1 where i_tpchecked_num<i_tpused_num and id=" + info.PaibanId);
        }
        else if(res.Length==3)
        {
            info.Checked = 2;
            info.CheckResult = res[1];
            SimpleOrmOperator.Update(info);
            StudentApplyInfoChecked infoChecked = new StudentApplyInfoChecked();
            bool isOk = SimpleOrmOperator.Create(infoChecked);
            if (!isOk) {
                SimpleOrmOperator.Update(infoChecked);
            }

        }
    }

    public static void SaveInfoCheckFail(StudentApplyInfo info, string name, string msg)
    {
        info.Checked = 2;
        info.CheckOperator = name;
       // info.Jbr = name;
        info.CheckResult = msg;
        SimpleOrmOperator.Update(info);
       // DataAccessFactory.GetDataAccess().ExecuteSql("update table_student_apply_info set c_check_result='"+msg+"'  and id=" + info.Id);
    }


    public static DrvPresonApplyInfoRequest ConvertInfoToRequest(StudentApplyInfo info)
    {
        DrvPresonApplyInfoRequest req = new DrvPresonApplyInfoRequest();


        String sn=req.GetSn();
        req.Bsl = info.Bsl;
        req.Csrq = info.Csrq;
        req.Dabh = info.Dabh;
        req.Djzsxxdz = info.Djzsxxdz;
        req.Djzsxzqh = info.Djzsxzqh;
        req.Dzyx = info.Dzyx;
        req.Gj = info.Gj;
        req.Hmcd = info.Hmcd;
        req.Jxdm = info.Jxdm;
        req.Jxmc = info.Jxmc;
        req.Lsh = info.Lsh;
        req.Lxdh = info.Lxdh;
        req.Lxzsxxdz = info.Lxzsxxdz;
        req.Lxzsxzqh = info.Lxzsxzqh;
        req.Lxzsyzbm = info.Lxzsyzbm;
        req.Ly = info.Ly;
        req.Qgjb = info.Qgjb;
        req.Sfzmhm = info.Sfzmhm;
        req.Sfzmmc = info.Sfzmmc;
        req.Sg = info.Sg;
        req.Sjhm = info.Sjhm;
        req.Sz = info.Sz;
        req.Tjrq = info.Tjrq;
        req.Tjyymc = info.Tjyymc;
        req.Tl = info.Tl;
        req.Xb = info.Xb;
        req.Xm = info.Xm;
        req.Xzqh = info.Xzqh;
        req.Ysl = info.Ysl;
        req.Yxz=info.Yxz;
        req.Zkcx = info.Zkcx;
        req.Zkzmbh = info.Zkzmbh;
        req.Zsl = info.Zsl;
        req.Zxz = info.Zxz;
        req.Zzzm = info.Zzzm;
        req.Sn = sn;
       
        return req;
    }
}
