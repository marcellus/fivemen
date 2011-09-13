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


public partial class Shop_ShopManageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
           // this.btnSearch.Click += new EventHandler(btnSearch_Click);

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string name = this.txtName.Text.Trim();
        if(name.Length>0)
        {
            //this.gridview.WhereClause = " Name.Contains(\""+name+"\")";

        }
        else
        {

           // this.gridview.WhereClause="";

        }
       // this.gridview.BindGrid<Shop>();
    }

    /// <summary>
    /// Method to bind datagrid of user.
    /// </summary>
    private void BindGrid()
    {
        try
        {
            //string criteria = SearchCriteriaList.SelectedValue.ToString().Trim();
            //string value = this.lblSearch.Text.ToString();
            //grduser.WhereClause = "IsDeleted = " + isdelete + " and ApplicationKey =" + SessionProperties.CRMApplicationPkey;
            //if (!string.IsNullOrEmpty(value))
            //    grduser.WhereClause = grduser.WhereClause + " and " + criteria + " like upper('" + value + "%')";

            //grduser.SelectList = "e.pkey, FirstName, LoginName , Email , DateCreated, DBO.GetUserRoles(e.pkey) AS Role, Reportingto,MOBILE_NO1 as MobileNo";
            //grduser.BindGrid();
           // this.gridview.BindGrid<Shop>();

        }
        catch (Exception ex)
        {
        }
    }
}
