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
using System.Data.SqlClient;

public partial class UserEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["help"] = "UserManageHelp.html";
            //部门绑定
            DdlDetpBind();
            //角色绑定
            DdlRoleBind();
            //System.Diagnostics.Debug.WriteLine("helloworld");
            //this.btnOK.Url = "UserEdit.aspx?username=" + Request.Params["username"].ToString();
            if (Request.Params["username"] == null)
            {
                this.btnOK.Text = "添加";
                this.ddlSex.SelectedIndex = 0;
            }
            else
            {
                System.Data.OleDb.OleDbDataReader reader = UserManage.UserRegisterValidate(Request.Params["username"]);
                while (reader.Read())
                {
                    ViewState["userid"] = reader[0].ToString();
                    this.tbUser.Text = Request.Params["username"];
                    if (Convert.ToInt32(reader[3]) == 1)
                    {
                        this.ddlSex.SelectedIndex = 0;
                    }
                    else
                    {
                        this.ddlSex.SelectedIndex = 1;
                    }
                    this.tbPhone.Text = reader[4].ToString();
                    this.tbMPhone.Text = reader[5].ToString();
                    this.tbEmail.Text = reader[6].ToString();
                    this.tbFax.Text = reader[7].ToString();
                    this.ddlProvince.Text = reader[8].ToString();
                    this.tbBirthday.Value = reader[9].ToString();

                    //DdlDetpBind();
                    for (int i = 0; i < this.ddlDept.Items.Count; i++)
                    {
                        if (reader[10].ToString() == ddlDept.Items[i].Value)
                        {
                            this.ddlDept.SelectedIndex = i;
                        }
                    }

                    this.ddlType.Text = reader[11].ToString();
                    this.ddlRole.Text = reader[12].ToString();

                    //DdlRoleBind();
                    for (int i = 0; i < this.ddlRole.Items.Count; i++)
                    {
                        if (reader[12].ToString() == this.ddlRole.Items[i].Value)
                        {
                            this.ddlRole.SelectedIndex = i;
                        }
                    }

                }
            }
        }
    }

    private void DdlRoleBind()
    {
        this.ddlRole.DataValueField = "roleid";
        this.ddlRole.DataTextField = "rolename";
        this.ddlRole.DataSource = BLL.UserManage.DdlBind("roleid", "rolename", "roletable", "1=1 and rolename<>'SystemAdmin'");
        this.ddlRole.DataBind();
        this.ddlRole.Items.Insert(0, new ListItem("--请选择--", "-1"));
    }

    private void DdlDetpBind()
    {
        this.ddlDept.DataValueField = "typeid";
        this.ddlDept.DataTextField = "typename";
        this.ddlDept.DataSource = BLL.UserManage.DdlBind("typeid", "typename", "dict_type", "belongtype=201");
        this.ddlDept.DataBind();
        this.ddlDept.Items.Insert(0, new ListItem("--请选择--", "-1"));
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string userName = this.tbUser.Text;
        char sex = Convert.ToChar(this.ddlSex.SelectedItem.Value);
        string phoneNum = this.tbPhone.Text;
        string mPhoneNum = this.tbMPhone.Text;
        string Email = this.tbEmail.Text;
        string fax = this.tbFax.Text;
        string province = this.ddlProvince.SelectedValue;
        string birth = this.tbBirthday.Value;
        string dept = this.ddlDept.Text;
        string type = this.ddlType.SelectedValue.ToString();
        string role = this.ddlRole.SelectedValue.ToString();
        if (this.btnOK.Text == "修改")
        {
            if (UserManage.UpdateUser(Convert.ToInt32(ViewState["userid"]), sex, phoneNum, mPhoneNum, Email, fax, province, birth, dept, type, role))
            {
               // Common.WebTools.Alert(this,"修改成功！");
                this.btnOK.SubmitSuccess("修改成功！");
                //Page.RegisterStartupScript("script", "<script>alert('修改成功！');window.location.href='UserEdit.aspx?username=" + Request.Params["username"] + "';");
            }
            else
            {
                Common.WebTools.Alert(this, "修改失败！");
            }
        }
        else
        {
            if ((UserManage.UserRegisterValidate(userName)).Read())
            {
                Common.WebTools.Alert(this, "该用户名已存在！");
                return;
            }
            else
            {
                if (UserManage.AddEmployee(userName, sex, phoneNum, mPhoneNum, Email, fax, province, birth, dept, type, role))
                {
                    this.btnOK.Url = "UserEdit.aspx?username=" + this.tbUser.Text;
                    this.btnOK.SubmitSuccess("添加成功！");
                }
                else
                {
                    Common.WebTools.Alert(this, "添加失败！");
                }
            }
        }
    }

    protected void btnModifyRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleEdit.aspx");
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        this.btnOK.Text = "添加";
        this.tbUser.ReadOnly = false;
        this.tbUser.Text = string.Empty;
        this.ddlSex.SelectedIndex = 0;
        this.tbPhone.Text = string.Empty;
        this.tbMPhone.Text = string.Empty;
        this.tbEmail.Text = string.Empty;
        this.tbFax.Text = string.Empty;
        this.ddlProvince.SelectedIndex = 1;
        this.tbBirthday.Value = string.Empty;
        this.ddlDept.SelectedIndex = 0;
        this.ddlType.SelectedIndex = 0;
        this.ddlRole.SelectedIndex = 1;
    }
}
