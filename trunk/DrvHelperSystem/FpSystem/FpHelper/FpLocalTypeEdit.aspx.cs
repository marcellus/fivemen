using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web.Tools;

public partial class FpSystem_FpHelper_FpLocalTypeEdit : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = StringHelper.fnFormatNullOrBlankInt(Request.Params["id"], -1);
            FpLocalType localtype = SimpleOrmOperator.Query<FpLocalType>(id);
            if (localtype == null) { return; }
            this.lbId.Text = id.ToString();
            this.txtLocalTypeName.Text = localtype.NAME;
            this.txtLocalTypeDescp.Text = localtype.DESCP;
            this.txtTrainTimes.Text = localtype.TRAIN_TIMES == null ? "0" : localtype.TRAIN_TIMES.ToString();
            this.cbKm3VerifyInd.Checked = (localtype.KM3_VERIFY_IND == "Y");
            this.cbKm1Ind.Checked=localtype.KM1_IND=="Y";
            this.cbKm2_3in9Ind.Checked = localtype.KM2_3IN9_IND == "Y";
            this.cbKm2Ind.Checked = localtype.KM2_IND == "Y";
            this.cbKm3Ind.Checked = localtype.KM3_IND == "Y";
            this.cbLessonInd.Checked = localtype.LESSON_IND == "Y";
            
        }
    }


    protected void btnCommit_Click(object sender, EventArgs e)
    {
        FpLocalType localtype = new FpLocalType();
        localtype.ID = StringHelper.fnFormatNullOrBlankInt(this.lbId.Text, -1);
        localtype.NAME = txtLocalTypeName.Text;
        localtype.DESCP = txtLocalTypeDescp.Text;
        localtype.TRAIN_TIMES = StringHelper.fnFormatNullOrBlankInt(txtTrainTimes.Text, 8);
        localtype.KM3_VERIFY_IND = cbKm3VerifyInd.Checked ? "Y" : "N";
        localtype.KM1_IND = cbKm1Ind.Checked ? "Y" : "N";
        localtype.KM2_3IN9_IND = cbKm2_3in9Ind.Checked ? "Y" : "N";
        localtype.KM2_IND = cbKm2Ind.Checked ? "Y" : "N";
        localtype.KM3_IND = cbKm3Ind.Checked ? "Y" : "N";
        localtype.LESSON_IND = cbLessonInd.Checked ? "Y" : "N";
        if (SimpleOrmOperator.Update(localtype))
        {
            WebTools.Alert("修改成功！");
        }
        else if (SimpleOrmOperator.Create(localtype))
        {
            WebTools.Alert("添加成功！");
        }
        else
        {
            WebTools.Alert("保存失败！");
        }
    }
}
