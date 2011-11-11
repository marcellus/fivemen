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
using FT.DAL.Orm;
using FT.Web.Tools;
using System.Collections.Generic;

public partial class FpSystem_FpHelper_FpFeeVerify  : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartMentOperator.Bind2(ddlSchoolCode);
            ddlSchoolCode.Items.Insert(0, new ListItem("全部", "all"));

            DictOperator.BindDropDownList("车辆类型", ddlCarType);
            ddlCarType.Items.Insert(0, new ListItem("全部", "all"));

            string condition = " fee_statue != '{0}' and statue<{1}";
            this.ProcedurePager1.TableName = "fp_student";
            this.ProcedurePager1.FieldString = @" lsh,idcard ,name ,school_name,car_type,fee_verify_date ".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by idcard desc";
            this.ProcedurePager1.RowFilter = string.Format(condition, "Y",FpStudentObject.STATUE_LESSON_START);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string queryValue = txtQueryValue.Text;
        string queryText = ddlQueryType.SelectedItem.Text;
        string queryType = ddlQueryType.SelectedValue;
        string condition = "";
        string feeStatue = ddlFeeStatue.SelectedValue;
        string schoolCode = ddlSchoolCode.SelectedValue;
        string carType = ddlCarType.SelectedValue;
        if (string.IsNullOrEmpty(queryValue))
        {
            if (feeStatue == "Y")
            {
                condition = "fee_statue = 'Y'";
            }
            else
            {
                condition = "fee_statue != 'Y'";
            }

            if (schoolCode != "all")
            {
                condition += string.Format(" and school_code='{0}' ", schoolCode);
            }

            if (carType != "all")
            {
                condition += string.Format(" and car_type='{0}' ", carType);
            }
        }
        else {
            condition = string.Format(" {0}='{1}'", queryType, queryValue);
        }
        //ArrayList students = SimpleOrmOperator.QueryConditionList<FpStudentObject>(condition);

        this.ProcedurePager1.RowFilter = condition;
        //else
        //this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;

    }





    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Verify")
        {
            string idcard = e.CommandArgument.ToString();
            //ZwTpOperator.Delete(id);
            FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
            fso.FEE_STATUE = "Y";
            fso.FEE_VERIFY_DATE = DateTime.Now;
            if (SimpleOrmOperator.Update(fso))
            {
                WebTools.Alert(this, string.Format("{0}:{1}  交费审核成功！", fso.LSH, fso.NAME));
            }
            else {
                WebTools.Alert(this, string.Format("{0}:{1}  交费审核失败！", fso.LSH, fso.NAME));
            }
            
            this.ProcedurePager1.Changed = true;
        }else if (e.CommandName=="DisVerify"){

            string idcard = e.CommandArgument.ToString();
            //ZwTpOperator.Delete(id);
            FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
            fso.FEE_STATUE = "N";
            fso.FEE_VERIFY_DATE = DateTime.Now;
            if (SimpleOrmOperator.Update(fso))
            {
                WebTools.Alert(this, string.Format("{0}:{1}  交费取消审核成功！", fso.LSH, fso.NAME));
            }
            else
            {
                WebTools.Alert(this, string.Format("{0}:{1}  交费取消审核失败！", fso.LSH, fso.NAME));
            }

            this.ProcedurePager1.Changed = true;
        }
    }



    protected void cbAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAll=(CheckBox)sender;
        bool isChecked=cbAll.Checked;
        foreach (DataGridItem item in DataGrid1.Items) {
           CheckBox cb= (CheckBox)item.FindControl("cbIdCard");
           cb.Checked = isChecked;
        }

    }


    protected void btnBatchVerify_Click(object sender, EventArgs e)
    {
        IList<string> idcards=new List<string>();
        int checkNum = 0;
        int reNum = 0;

        foreach (DataGridItem item in DataGrid1.Items)
        { 

            CheckBox cb = (CheckBox)item.FindControl("cbIdCard");
            if (cb.Checked) {
              idcards.Add(item.Cells[3].Text);
              checkNum++;
            }
        }

        if (checkNum == 0) {
            WebTools.Alert("没有记录被选中");
            return;
        }

        foreach (string idcard in idcards) { 
          
            FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
            fso.FEE_STATUE = "Y";
            fso.FEE_VERIFY_DATE = DateTime.Now;
            if (SimpleOrmOperator.Update(fso)) {
                reNum++;    
            }
        
        }

        WebTools.Alert(string.Format( "审核结果：选中{0}条记录，{1}条成功通过审核",checkNum,reNum));
        this.ProcedurePager1.Changed = true;
    }
    protected void btnBatchDisVerify_Click(object sender, EventArgs e)
    {
        IList<string> idcards = new List<string>();
        int checkNum = 0;
        int reNum = 0;

        foreach (DataGridItem item in DataGrid1.Items)
        {

            CheckBox cb = (CheckBox)item.FindControl("cbIdCard");
            if (cb.Checked)
            {
                idcards.Add(item.Cells[3].Text);
                checkNum++;
            }
        }

        if (checkNum == 0)
        {
            WebTools.Alert("没有记录被选中");
            return;
        }

        foreach (string idcard in idcards)
        {

            FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
            fso.FEE_STATUE = "N";
            fso.FEE_VERIFY_DATE = DateTime.Now;
            if (SimpleOrmOperator.Update(fso))
            {
                reNum++;
            }

        }

        WebTools.Alert(string.Format("审核结果：选中{0}条记录，{1}条成功取消审核", checkNum, reNum));
        this.ProcedurePager1.Changed = true;
    }
}
