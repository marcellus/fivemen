using System;
using System.Collections.Generic;

using System.Text;
using FT.DAL;
using FT.DAL.Orm;
using DrvHelperSystemBLL.System.Rbac.Model;
using System.Data;
using System.Web.UI.WebControls;
using DrvHelperSystemBLL.System.Commons.BLL;
using FT.Web.Tools;


namespace DrvHelperSystemBLL.System.Rbac.BLL
{
    public class DepartmentInfoOperator
    {

        public static void Delete(int id)
        {
            LogInfoOperator.LogSystem("删除车管所部门", "删除车管所部门ID为"+id.ToString());
            SimpleOrmOperator.Delete<DepartmentInfo>(id);
        }

        public static void CreateOrUpdate(DepartmentInfo dep)
        {
            if (dep.Id < 0)
            {
                if (SimpleOrmOperator.Create(dep))
                {
                    LogInfoOperator.LogSystem("添加车管所部门", "添加车管所部门" +dep.DepFullName);
                    WebTools.Alert("添加成功！");
                }
                else
                {
                    WebTools.Alert("添加失败！");

                }
            }
            else
            {
                if (SimpleOrmOperator.Update(dep))
                {
                    LogInfoOperator.LogSystem("修改车管所部门", "修改车管所部门" + dep.DepFullName);
                    WebTools.Alert("修改成功！");
                }
                else
                {
                    WebTools.Alert("修改失败！");

                }

            }
        }

        public static DepartmentInfo Get(int id)
        {
            
            return SimpleOrmOperator.Query<DepartmentInfo>(id);
        }

        public static DataTable Search(string depname)
        {
            return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_department_info where c_depfullname like '%" + depname + "%'", "tempdb");
        }

       

        public static void BindDeptNick(DropDownList ddl)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_department_info", "tempdb");
            ddl.DataSource = dt;
            ddl.DataTextField = "c_depnickname";
            ddl.DataValueField = "id";
            ddl.DataBind();
        }

        public static void BindDept(DropDownList ddl)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_department_info ", "tempdb");
            ddl.DataSource = dt;
            ddl.DataTextField = "c_depfullname";
            ddl.DataValueField = "id";
            ddl.DataBind();
        }


        public static void BindSchoolNick(DropDownList ddl)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_school_info", "tempdb");
            ddl.DataSource = dt;
            ddl.DataTextField = "c_depnickname";
            ddl.DataValueField = "id";
            ddl.DataBind();
        }

        public static void BindSchool(DropDownList ddl)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_school_info ", "tempdb");
            ddl.DataSource = dt;
            ddl.DataTextField = "c_depfullname";
            ddl.DataValueField = "id";
            ddl.DataBind();
        }

    }
}
