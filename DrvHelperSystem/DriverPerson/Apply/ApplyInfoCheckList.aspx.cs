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
            this.ProcedurePager1.TableName = "table_student_apply_info_c";
            this.ProcedurePager1.FieldString = @"id,c_lsh,sfzmhm,c_xm,c_jxmc,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') as i_checked,
c_check_result,c_check_operator,
decode(i_photo_syn,0,'未同步',1,'已同步',2,'同步失败') as i_photo_syn
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.RowFilter = " i_checked=0 ";
            this.ProcedurePager1.SortString = " order by id desc";

            DepartMentOperator.BindNick(cbJxdm, "驾校");
            cbJxdm.Items.Add(new ListItem("全部", ""));
            cbJxdm.SelectedIndex = cbJxdm.Items.Count - 1;
            
        }

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        IList<int> ids = new List<int>();
        int checkNum = 0;
        int reNum = 0;
        foreach (DataGridItem item in DataGrid1.Items)
        {

            CheckBox cb = (CheckBox)item.FindControl("CheckBox1");
            if (cb.Checked)
            {
                try{
                ids.Add(Convert.ToInt32( item.Cells[1].Text));
                checkNum++;
                }catch(Exception){}
            }
        }

        if (checkNum == 0)
        {
            WebTools.Alert("没有记录被选中");
            return;
        }

        foreach (int id in ids)
        {

            StudentApplyInfo sai = SimpleOrmOperator.Query<StudentApplyInfo>(id);
            if (sai == null) continue;
            if (StudentApplyInfoOperator.CheckInfo(sai, this.Operator.OperatorName))
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
        string checkStatus = this.cbCheckResult.SelectedValue;
        string jxdm = this.cbJxdm.SelectedValue;
        string queryValue = txtQueryValue.Text;
        string queryText = ddlQueryType.SelectedItem.Text;
        string queryType = ddlQueryType.SelectedValue;

        string query = " 1=1 ";
        if (!string.IsNullOrEmpty(queryValue)) { 
           query += string.Format(" and {0} like '%{1}%' ",queryType,queryValue);
        }

        if (this.cbCheckResult.SelectedIndex != 3)
        {
            query += " and i_checked=" + checkStatus;
           // this.ProcedurePager1.RowFilter = "i_checked=" + checkStatus + "  and sfzmhm like '%" + this.txtIdCard.Text.Trim() + "%'" + " and c_jxdm='" + this.Operator.Desp3 + "'";
        }
        if( !string.IsNullOrEmpty(this.cbJxdm.SelectedValue))
        {
            query += " and c_jxdm='" + jxdm + "'";
           // this.ProcedurePager1.RowFilter = " sfzmhm like '%" + this.txtIdCard.Text.Trim() + "%'" + " and c_jxdm='" + this.Operator.Desp3 + "'";
        }
        this.ProcedurePager1.RowFilter = query;
        this.ProcedurePager1.Changed = true;
           
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
        int id = Convert.ToInt32(e.CommandArgument);
        StudentApplyInfoChecked infoCheck = SimpleOrmOperator.Query<StudentApplyInfoChecked>(id);
        if (e.CommandName == "Delete")
        {

            if (infoCheck != null && infoCheck.Checked == 1)
            {
                WebTools.Alert(this, "已审核过的数据无法删除！");
            }
            else
            {
                SimpleOrmOperator.Delete(infoCheck);
                WebTools.Alert(this, "删除成功！");
                this.ProcedurePager1.Changed = true;
            }
        }
        else if (e.CommandName == "Detail")
        {
            //int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
}
