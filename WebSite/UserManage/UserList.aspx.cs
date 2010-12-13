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

public partial class RoleManage : CqGuoTong.AuthenticatedPage
{
    public int recordCount = 0;
    public int pageCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Operator.Right.IndexOf(BLL.ConstString.UserManage.ToString()) == -1)
            {
                this.RedirectNotRight();
            }
            DgBind();
            Session["help"] = "UserManageHelp.html";
        }
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    private DataTable DgBind()
    {
        DataTable table = null;
        string userName = this.tbUserName.Text;
        table = BLL.UserManage.QueryUser(userName);
    //    recordCount = table.Rows.Count;
    //    pageCount = (int)Math.Ceiling(recordCount * 1.0 / PageSize);//获取当前的页数

    //    //避免纪录从有到无时，并且已经进行过反页的情况下CurrentPageIndex > PageCount出错
    //    if (recordCount == 0)
    //    {
    //        this.dg.CurrentPageIndex = 0;
    //    }
    //    else
    //    {
    //        if (this.dg.CurrentPageIndex >= pageCount)
    //        {
    //            this.dg.CurrentPageIndex = pageCount - 1;
    //        }
    //    }
        this.dg.DataSource = table;
        this.dg.DataBind();
        return table;
        //NavigationStateChange();
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改
    /// 此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        //this.LBtnFirst.Click += new System.EventHandler(this.LBtnNavigation_Click);
        //this.LBtnPrev.Click += new System.EventHandler(this.LBtnNavigation_Click);
        //this.LBtnNext.Click += new System.EventHandler(this.LBtnNavigation_Click);
        //this.LBtnLast.Click += new System.EventHandler(this.LBtnNavigation_Click);
        this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion


    //private void LBtnNavigation_Click(object sender, System.EventArgs e)
    //{
    //    LinkButton btn = (LinkButton)sender;
    //    switch (btn.CommandName)
    //    {
    //        case "First":
    //            PageIndex = 0;
    //            break;
    //        case "Prev"://if( PageIndex > 0 )
    //            PageIndex = PageIndex - 1;
    //            break;
    //        case "Next"://if( PageIndex < PageCount -1)
    //            PageIndex = PageIndex + 1;
    //            break;
    //        case "Last":
    //            PageIndex = PageCount - 1;
    //            break;
    //    }
    //    DgBind();
    //}

    /// <summary>
    /// 控制导航按钮或数字的状态
    /// </summary>
    //private void NavigationStateChange()
    //{
    //    if (PageCount <= 1)       //小于或等于一页
    //    {
    //        //this.LBtnFirst.Enabled = false;
    //        //this.LBtnLast.Enabled = false;
    //        this.LBtnNext.Enabled = false;
    //        this.LBtnPrev.Enabled = false;
    //    }
    //    else                     //有多页
    //    {
    //        if (PageCount == 0)
    //        {
    //            //this.LBtnFirst.Enabled = false;
    //            //this.LBtnPrev.Enabled = false;
    //            this.LBtnLast.Enabled = true;
    //            this.LBtnNext.Enabled = true;
    //        }
    //        else
    //        {

    //            if (PageIndex == PageCount - 1)  //最后一页
    //            {
    //                //this.LBtnLast.Enabled = false;
    //                this.LBtnNext.Enabled = false;
    //                this.LBtnPrev.Enabled = true;
    //                //this.LBtnFirst.Enabled = true;
    //            }
    //            else if (PageIndex == 0)
    //            {
    //                //this.LBtnFirst.Enabled = true;
    //                this.LBtnPrev.Enabled = false;
    //                this.LBtnNext.Enabled = true;
    //                //this.LBtnLast.Enabled = true;
    //            }
    //            else                           //中间页
    //            {
    //                //this.LBtnFirst.Enabled = true;
    //                this.LBtnPrev.Enabled = true;
    //                this.LBtnNext.Enabled = true;
    //                //this.LBtnLast.Enabled = true;
    //            }
    //        }
    //    }

    //    if (RecordCount == 0)   //如果没有记录会显示第一页
    //    {
    //        this.LtlPageCount.Text = "0";
    //    }
    //    else
    //    {
    //        this.LtlPageCount.Text = PageCount.ToString();
    //    }
    //    if (RecordCount == 0)
    //    {
    //        this.LtlPageIndex.Text = "0";
    //    }
    //    else
    //    {
    //        this.LtlPageIndex.Text = Convert.ToString(PageIndex + 1);//在有页数的情况下前台显示页数加1
    //        this.LtlPageSize.Text = PageSize.ToString();
    //        this.LtlRecordCount.Text = RecordCount.ToString();
    //    }
    //}

    //public int PageCount    //页数
    //{
    //    get { return this.dg.PageCount; }
    //}

    //public int PageSize    //页大小
    //{
    //    get { return this.dg.PageSize; }
    //}

    //public int PageIndex   //页索引
    //{
    //    set { this.dg.CurrentPageIndex = value; }
    //    get { return this.dg.CurrentPageIndex; }
    //}

    //public int RecordCount  //记录总数
    //{
    //    set { recordCount = value; }
    //    get { return recordCount; }
    //}

    protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        int userid = Convert.ToInt32(e.Item.Cells[0].Text);
        if (UserManage.DeleteUser(userid))
        {
            Common.WebTools.Alert(this, "删除成功！");
            DgBind();
        }
        else
        {
            Common.WebTools.Alert(this, "删除失败！");
        }
    }

    protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.dg.CurrentPageIndex = e.NewPageIndex;
        DgBind();
    }
    protected void dg_EditCommand(object source, DataGridCommandEventArgs e)
    {
        string username = e.Item.Cells[1].Text;
        Response.Redirect("UserEdit.aspx?username=" + username);
    }
    protected void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
        {
            ((LinkButton)e.Item.Cells[14].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确定删除 " + e.Item.Cells[1].Text + " 吗？');");
        } 
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DgBind();
    }
}
