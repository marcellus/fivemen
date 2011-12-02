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
using FT.Web.Tools;
using System.Collections.Generic;
using FT.DAL.Orm;

public partial class DriverPerson_Apply_ApplyInfoCheckList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.AllowBinded = true;
            this.ProcedurePager1.TableName = "table_student_apply_info_i";
            this.ProcedurePager1.FieldString = @"id,c_lsh,sfzmhm,c_xm,c_jxmc,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') as i_checked,
c_check_result,c_photo_syn,c_check_operator
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
        }

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        IList<string> ids = new List<string>();
        int checkNum = 0;
        int reNum = 0;
        foreach (DataGridItem item in DataGrid1.Items)
        {

            CheckBox cb = (CheckBox)item.FindControl("CheckBox1");
            if (cb.Checked)
            {
                ids.Add(item.Cells[3].Text);
                checkNum++;
            }
        }

        if (checkNum == 0)
        {
            WebTools.Alert("没有记录被选中");
            return;
        }

        foreach (string id in ids)
        {

            StudentApplyInfo sai = StudentApplyInfoOperator.Get(Convert.ToInt32(id));
            //fso.FEE_VERIFY_DATE = DateTime.Now;
            if (StudentApplyInfoOperator.CheckInfoAndPhoto(sai, ""))
            {
                reNum++;
            }

        }

        WebTools.Alert(string.Format("审核结果：选中{0}条记录，{1}条成功通过审核", checkNum, reNum));
        this.ProcedurePager1.Changed = true;
        //txtQueryValue.Text = "";
        //txtQueryValue.Focus();

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string checkStatus = this.cbCheckResult.SelectedItem.Value;
        if (this.cbCheckResult.SelectedIndex != 3)
        {
            if (checkStatus == "1" || checkStatus == "2")
            {
                this.ProcedurePager1.TableName = "table_student_apply_info_c";
            }
            else {
                this.ProcedurePager1.TableName = "table_student_apply_info_i";
            }
            this.ProcedurePager1.RowFilter = "i_checked=" + checkStatus + "  and sfzmhm like '%" + this.txtIdCard.Text.Trim() + "%'" + " and c_jxdm='" + this.Operator.Desp3 + "'";
        }
        else
        {

            this.ProcedurePager1.RowFilter = " sfzmhm like '%" + this.txtIdCard.Text.Trim() + "%'" + " and c_jxdm='" + this.Operator.Desp3 + "'";
        } this.ProcedurePager1.Changed = true;
           
    }


    private void Pop(int id)
    {
        string url = "ApplyInfoAdd.aspx";
        if (id > 0)
        {
            url += "?allowcheck=true&id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 1024, 600);
    }


    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //allowcheck
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            StudentApplyInfo record = StudentApplyInfoOperator.Get(id);
            if (record != null && record.Checked == 1)
            {
                WebTools.Alert(this, "已审核过的数据无法删除！");
            }
            else
            {
                StudentApplyInfoOperator.Delete(id);
                WebTools.Alert(this, "删除成功！");
                this.ProcedurePager1.Changed = true;
            }
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
}
