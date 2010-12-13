using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

public partial class UserManage_RoleAlter : CqGuoTong.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["help"] = "RightManageHelp.html";
            if (this.Operator.Right.IndexOf(BLL.ConstString.RoleManage.ToString()) == -1)
            {
                this.RedirectNotRight();
            }
            this.btnOK.Attributes.Add("onclick", "javascript:if(confirm('确定此次操作吗？')) {if(document.form1.lstbNowRight.options.length==0) { alert('用户权限不能为空！'); return false;} return true;};");
            if (Request.Params["roleid"] != null)
            {
                this.Hidden1.Value = Request.Params["roleid"];
                MyDataBind();
            }
            else
            {
                this.Hidden1.Value = "";
                InitLstbOtherRight();
            }
        }
    }

    private void InitLstbOtherRight()
    {
        DataTable table = UserManage.SlctRight();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            this.lstbOtherRight.Items.Add(new ListItem(table.Rows[i]["rightname"].ToString(), table.Rows[i]["rightcode"].ToString()));
        }
    }

    private void MyDataBind()
    {
        DataTable table = null;
        table = UserManage.RoleQuery(Convert.ToInt32(Request.Params["roleid"]));
        string right = table.Rows[0]["rolestring"].ToString();
        //string[] rightArray = right.Split('/');
        this.tbRoleName.Text = table.Rows[0]["rolename"].ToString();
        this.tbDscp.Text = table.Rows[0]["roledsc"].ToString();

        //根据该角色初始化lstbNowRight和lstbOtherRight
        DataTable table1 = UserManage.SlctRight();
        this.lstbNowRight.Items.Clear();
        this.lstbOtherRight.Items.Clear();
        for (int i = 0; i < table1.Rows.Count; i++)
        {
            if (right.IndexOf(table1.Rows[i]["rightcode"].ToString()) != -1)
            {
                this.lstbNowRight.Items.Add(new ListItem(table1.Rows[i]["rightname"].ToString(),table1.Rows[i]["rightcode"].ToString()));
            }
            else
            {
                this.lstbOtherRight.Items.Add(new ListItem(table1.Rows[i]["rightname"].ToString(),table1.Rows[i]["rightcode"].ToString()));
            }
        }

        //循环求得现有权限，并添加到lstNowRight里
        //DataTable table_1 = UserManage.SlctRight();
        //for (int i = 0; i < rightArray.Length; i++)
        //{
        //    for (int j = 0; j < table_1.Rows.Count; j++)
        //    {
        //        if (rightArray[i].ToString() == table_1.Rows[j]["rightcode"].ToString())
        //        {
        //            this.lstbNowRight.Items.Add(table_1.Rows[j]["rightname"].ToString());
        //        }
        //    }
        //}

        //绑定数据到lstbAllRight的方法
        //this.lstbAllRight.DataSource = UserManage.SlctRight();
        //this.lstbAllRight.DataTextField = "rightname";
        //this.lstbAllRight.DataValueField = "rightcode";
        //this.lstbAllRight.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string roleName = this.tbRoleName.Text;
        string roleString = "";
        for (int i = 0; i < this.lstbNowRight.Items.Count; i++)
        {
            roleString += this.lstbNowRight.Items[i].Value.ToString() + "/";
        }

        //roleString = roleString.TrimEnd("/".ToCharArray());

        roleString = roleString.TrimEnd('/');
        string roleDesc = this.tbDscp.Text;

        if (this.Hidden1.Value != "")
        {
            if (UserManage.UpdateRole(2, Convert.ToInt32(Request.Params["roleid"]), roleName, roleString, roleDesc))
            {
                FT.Web.Tools.WebTools.Alert(this, "更新成功！");
                //MyDataBind();
            }
            else
            {
                Common.WebTools.Alert(this, "更新失败！");
                return;
            }
        }
        else
        {
            if (UserManage.InsertRole(2, roleName, roleString, roleDesc))
            {
                Common.WebTools.Alert(this, "添加成功！");
                //MyDataBind();
            }
            else
            {
                Common.WebTools.Alert(this, "添加失败！");
                return;
            }
        }
    }

    protected void btnLeft_Click(object sender, EventArgs e)
    {
        if (this.lstbNowRight.SelectedIndex == -1)
        {
            Common.WebTools.Alert(this, "请选择要排除的权限！");
        }
        else
        {
            for (int i = lstbNowRight.Items.Count - 1; i >= 0; i--)
            {
                if (this.lstbNowRight.Items[i].Selected == true)
                {
                    this.lstbOtherRight.Items.Add(new ListItem(this.lstbNowRight.Items[i].Text.ToString(), this.lstbNowRight.Items[i].Value.ToString()));
                    this.lstbNowRight.Items.RemoveAt(i);
                }
            }
        }
    }

    protected void btnRight_Click(object sender, EventArgs e)
    {
        if (this.lstbOtherRight.SelectedIndex == -1)
        {
            Common.WebTools.Alert(this, "请选择要添加的权限！");
        }
        else
        {
            for (int i = lstbOtherRight.Items.Count - 1; i >= 0; i--)
            {
                if (this.lstbOtherRight.Items[i].Selected == true)
                {
                    this.lstbNowRight.Items.Add(new ListItem(this.lstbOtherRight.Items[i].Text.ToString(), this.lstbOtherRight.Items[i].Value.ToString()));
                    this.lstbOtherRight.Items.RemoveAt(i);
                }
            }
        }
    }

    protected void btnRoleAdd_Click(object sender, EventArgs e)
    {
        this.Hidden1.Value = "";
        this.btnRoleAdd.Enabled = false;
        this.tbRoleName.Text = "";
        this.tbDscp.Text = "";
        this.lstbNowRight.Items.Clear();
        this.lstbOtherRight.Items.Clear();
        InitLstbOtherRight();
        this.btnOK.Text = "添加";
    }
}
