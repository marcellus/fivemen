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

public partial class FpSystem_FpHelper_FpRecordClear : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartMentOperator.Bind2(ddlSchoolCode);
            ddlSchoolCode.Items.Insert(0, new ListItem("全部", "all"));

            DictOperator.BindDropDownList("车辆类型",ddlCarType);
            ddlCarType.Items.Insert(0, new ListItem("全部", "all"));

            string condition = " statue>={0}";
            this.ProcedurePager1.TableName = "fp_student";
            this.ProcedurePager1.FieldString = @" lsh,idcard ,name ,school_name,car_type ".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by idcard desc";
            this.ProcedurePager1.RowFilter = string.Format(condition,FpStudentObject.STATUE_KM3_ENTER);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string queryValue = txtQueryValue.Text;
        string queryText = ddlQueryType.SelectedItem.Text;
        string queryType = ddlQueryType.SelectedValue;
        

        string condition = "";

        if (string.IsNullOrEmpty(queryValue))
        {

            //string feeStatue = ddlFeeStatue.SelectedValue;
            string schoolId = ddlSchoolCode.SelectedValue;
            string carType = ddlCarType.SelectedValue;
          //  if (feeStatue == "Y")
         //   {
          //      condition = "km3_verify = 'Y'";
        //    }
        //    else
         //   {
        //        condition = "km3_verify != 'Y'";
          //  }

            if (schoolId != "all")
            {
                //DepartMent depart = SimpleOrmOperator.Query<DepartMent>(schoolId);
                //string schoolCode = depart.DepCode;
                condition += string.Format(" and school_code='{0}' ", schoolId);
            }

            if (carType  != "all")
            {
                condition += string.Format(" and car_type='{0}' ", carType );
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
        if (e.CommandName == "Clear")
        {
            string idcard = e.CommandArgument.ToString();
            //ZwTpOperator.Delete(id);
            FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
            fso.KM3_VERIFY = "Y";
           // fso.FEE_VERIFY_DATE = DateTime.Now;
            if (SimpleOrmOperator.Delete(fso))
            {
                WebTools.Alert(this, string.Format("{0}:{1}  学员记录删除成功！", fso.LSH, fso.NAME));
            }
            else
            {
                WebTools.Alert(this, string.Format("{0}:{1}  学员记录删除失败！", fso.LSH, fso.NAME));
            }

            this.ProcedurePager1.Changed = true;
        }

    }



    protected void cbAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAll = (CheckBox)sender;
        bool isChecked = cbAll.Checked;
        foreach (DataGridItem item in DataGrid1.Items)
        {
            CheckBox cb = (CheckBox)item.FindControl("cbIdCard");
            cb.Checked = isChecked;
        }

    }


    protected void btnBatchClear_Click(object sender, EventArgs e)
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
            //fso.KM3_VERIFY = "Y";
            //fso.FEE_VERIFY_DATE = DateTime.Now;
            if (SimpleOrmOperator.Delete(fso))
            {
                reNum++;
            }

        }

        WebTools.Alert(string.Format("删除结果：选中{0}条记录，{1}条成功删除", checkNum, reNum));
        this.ProcedurePager1.Changed = true;
    }
    
}
