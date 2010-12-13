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
using System.Text;
using FT.Web;

public partial class SystemAdmin_menu :AuthenticatedPage
{
    public const string MenuStr = @"<SCRIPT>
 
 var o = new createOutlookBar('Bar',0,0,screenSize.width,screenSize.height,'white','imgs');
 
###content###

o.draw();
//draw the OutlookBar 
      

//-----------------------------------------------------------------------------
//functions to manage window resize
//-----------------------------------------------------------------------------
//resize OP5 (test screenSize every 100ms)

function resize_op5() {	
  if (bt.op5) {
    o.showPanel(o.aktPanel);
    var s = new createPageSize();
    if ((screenSize.width!=s.width) || (screenSize.height!=s.height)) {
      screenSize=new createPageSize();
      //need setTimeout or resize on window-maximize will not work correct!
      //ben\uFFFDige das setTimeout oder das Maximieren funktioniert nicht richtig
      setTimeout('o.resize(0,0,screenSize.width,screenSize.height)',100);
    }
    setTimeout('resize_op5()',100);
  }
  else {
    o.showPanel(0);
  }
}

//resize IE & NS (onResize event!)
function myOnResize() {
  if (bt.ie4 || bt.ie5 || bt.ns5) {
    var s=new createPageSize();
    o.resize(0,0,s.width,s.height);
  }
  else
    if (bt.ns4) location.reload();
}
function openWin(m){
	window.open(m, 'popupnav', 'top=0,left=0,resizable=1,scrollbars=1');
}

</SCRIPT>";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // this.lbUser.Text = this.Operator.OperatorName;
           // this.lbTime.Text = System.DateTime.Now.ToShortTimeString();
          //  this.lbtnCancel.Attributes.Add("onclick", "javascript:return confirm('确定退出？');");
           InitPage();
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Session.Clear();
       // Common.WebTools.CloseSelf(this);
       //this.RegisterStartupScript("cancel", "<script>window.parent.location.href='../homepage.aspx';</script>");
        this.RegisterStartupScript("cancel", "<script>window.parent.opener=null;window.parent.window.close();</script>");
    }
    private DataTable GetMenu(String rights)
    {

        if (rights == string.Empty)
        {
            return null;
        }
        string[] array = rights.Split('/');
        string where = " where rightcode in( ";
        if (array.Length == 0)
        {
            return null;
        }
        foreach (string str in array)
        {
            where += str + " ,";
        }
        where += "0) ";
        string sql = "select id,rightname,rightcode,imgsource,url,mainmenu from righttable " + where + " order by mainmenu";
        return FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "righttable");
    }

    private void InitPage()
    {
       // string[] tableRight = this.Operator.Right.Split('/');
        //BLL.ProjectsManage pro = new ProjectsManage();

        DataTable menu = this.GetMenu(this.Operator.Right);

        /*******
         * 
         *   p = new createPanel('a0','用户管理');

p.addButton('imgs/059.gif','用户管理','parent.main.location="../UserManage/RoleManage.aspx"');
p.addButton('imgs/038.gif','角色管理','parent.main.location="../UserManage/RoleEdit.aspx"');
p.addButton('imgs/022.gif','权限管理','parent.main.location="../UserManage/RoleAlter.aspx"');
o.addPanel(p);
         * id,rightname,rightcode,imgsource,url,mainmenu
         * ****************/
        StringBuilder sb = new StringBuilder();
        int count = 0;
        string mainmenu = string.Empty;

        foreach (DataRow dr in menu.Rows)
        {
            if (dr[5].ToString() == "notmenu")
            {
                continue;
            }
            if (mainmenu != dr[5].ToString())
            {
                mainmenu = dr[5].ToString();
                count++;
                sb.Append("p"+count.ToString()+"=new createPanel('a"+count.ToString()+"','"+mainmenu+"');");
            }
            sb.Append("p"+count.ToString()+".addButton('"+dr[3].ToString()+"','"+dr[1].ToString()+"','"+dr[4].ToString()+"');");

        }
        for (int i = 1; i <= count; i++)
        {
            sb.Append("o.addPanel(p"+i.ToString()+");");
        }
        System.Diagnostics.Debug.WriteLine(sb.ToString());
        StringBuilder sb2 = new StringBuilder(MenuStr);
        sb2.Replace("###content###", sb.ToString());
        Page.RegisterStartupScript("menutest", sb2.ToString());
        //this.divContent.InnerHtml = sb2.ToString();

        // DataView dv = menu.DefaultView;
       
        //menu.Select()
       // DataTable menuRight = new DataTable();

      // string menuString = "";

       // for (int i = 0; i < tableRight.Length; i++)
      //  {
     //     dv.RowFilter="rightcode="+tableRight[i]
      //  }
      //  this.DataGrid1.DataSource = menuRight;
      //  this.DataGrid1.DataBind();

       
    }
}
