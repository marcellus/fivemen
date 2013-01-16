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
using FT.Web.Bll.Product;
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web.Tools;

public partial class YuanTuo_DiscountEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindProduct(this.cbProductIdValue);
            if (Request.Params["id"] != null)
            {
                ProductDiscountInfo entity = SimpleOrmOperator.Query<ProductDiscountInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.txtBeginDate.Value = DateTimeHelper.DtToLongString(entity.StartDate);
                this.txtEndDate.Value = DateTimeHelper.DtToLongString(entity.EndDate);
            }
            else
            {
                this.txtBeginDate.Value = DateTimeHelper.DtToLongString(System.DateTime.Now);
                this.txtEndDate.Value = DateTimeHelper.DtToLongString(System.DateTime.Now);

            }
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        ProductDiscountInfo entity = new ProductDiscountInfo();
        WebFormHelper.GetDataFromForm(this, entity);
        entity.StartDate = Convert.ToDateTime(this.txtBeginDate.Value.ToString());
        entity.EndDate = Convert.ToDateTime(this.txtEndDate.Value.ToString());
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
            {
                WebTools.Alert(this, "添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(entity))
            {
                WebTools.Alert(this, "修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
    }
}
