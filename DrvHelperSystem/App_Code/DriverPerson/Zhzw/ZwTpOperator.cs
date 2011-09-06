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

/// <summary>
///ZwTpOperator 的摘要说明
/// </summary>
public class ZwTpOperator
{
    public ZwTpOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<ZwTpObject>(id);
        // DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_yuyue_limit where i_week_num=" + week.WeekNum);
    }

    public static void Create(ZwTpObject tp)
    {
        SimpleOrmOperator.Create(tp);
        // DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_yuyue_limit where i_week_num=" + week.WeekNum);
    }

    public static FpStudentObject QueryByIdcard(FpStudentObject fp)
    {
       // ArrayList<FpStudentObject> info = SimpleOrmOperator.QueryConditionList<FpStudentObject>(" where IDCARD=? ", fp.IDCARD);string condition
       // if (info.Count != 0)
       // {
      //      return info.IndexOf(0);
      //  }
        return null;
    }
    public static bool Update(FpStudentObject fp)
    {
        return SimpleOrmOperator.Update(fp);
    }
}
