using System;
using System.Collections.Generic;

using System.Text;
using DrvHelperSystemBLL.System.Model;
using FT.Web.Tools;
using FT.DAL;
using FT.DAL.Orm;
using DrvHelperSystemBLL.System.Commons.BLL;
using DrvHelperSystemBLL.System.Rbac.Model;
using System.Web.UI.WebControls;
using System.Data;

namespace DrvHelperSystemBLL.System.Rbac.BLL
{
    public class RoleInfoOperator 
    {
        public static void Bind(DropDownList ddl)
        {
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_role_info", "tempdb");
            ddl.DataSource = dt;
            ddl.DataTextField = "c_role_name";
            ddl.DataValueField = "id";
            ddl.DataBind();
        }
        public static void Delete(int id)
        {
            LogInfoOperator.LogSystem("删除角色", "删除角色ID为" + id.ToString());
            SimpleOrmOperator.Delete<RoleInfo>(id);
        }

        public static void CreateOrUpdate(RoleInfo model)
        {
            if (model.Id < 0)
            {
                if (SimpleOrmOperator.Create(model))
                {
                    LogInfoOperator.LogSystem("添加角色", "添加角色" + model.RoleName);
                    WebTools.Alert("添加成功！");
                }
                else
                {
                    WebTools.Alert("添加失败！");

                }
            }
            else
            {
                if (SimpleOrmOperator.Update(model))
                {
                    LogInfoOperator.LogSystem("修改角色", "修改角色" + model.RoleName);
                    WebTools.Alert("修改成功！");
                }
                else
                {
                    WebTools.Alert("修改失败！");

                }

            }
        }

        public static RoleInfo Get(int id)
        {

            return SimpleOrmOperator.Query<RoleInfo>(id);
        }
    }
}
