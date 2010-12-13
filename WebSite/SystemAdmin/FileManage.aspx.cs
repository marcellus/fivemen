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
using System.IO;

public partial class SystemAdmin_FileManage : System.Web.UI.Page
{
    protected const string Seperator = "</td><td>";
    protected const string UpLevel = "../";
    private void Page_Load(object sender, System.EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        if (!IsPostBack)
        {
            Session["help"] = "FileManageHelp.html";
        }
        if (Session["Path"] == null)
        {
            this.SetDefault();
        }

        this.ShowPath(Session["Path"].ToString());
    }
    public string GetDefault()
    {
        System.Diagnostics.Debug.WriteLine(System.Configuration.ConfigurationSettings.AppSettings["FileManage"].ToString());
        return System.Configuration.ConfigurationSettings.AppSettings["FileManage"].ToString();
    }

    private void SetDefault()
    {
        System.Diagnostics.Debug.WriteLine(Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["FileManage"].ToString()));
        Session["Path"] = System.Configuration.ConfigurationSettings.AppSettings["FileManage"].ToString();
    }
    private void ShowPath(string path)
    {
        System.IO.DirectoryInfo root = new DirectoryInfo(Server.MapPath(path));
        if (!root.Exists&&root.GetFiles().Length==0)
        {
            Literal nocontent = new System.Web.UI.WebControls.Literal();
            nocontent.Text = "<tr><td colspan='5'>没有找到该目录！</td></tr>";
            this.phContent.Controls.Add(nocontent);
        }
        else
        {
            this.lbDir.Text = Session["Path"].ToString();
            if (path != this.GetDefault())
            {
                Literal seperator = new Literal();
                seperator.Text = Seperator;
                Literal seperator1 = new Literal();
                seperator1.Text = Seperator;
                Literal seperator2 = new Literal();
                seperator2.Text = Seperator;
                Literal endRow = new Literal();
                endRow.Text = "</td></tr>";


                //显示图标
                Literal picColumn = new Literal();
                picColumn.Text = "<TR><td><img src=pics/folder.gif></td><td>";

                // 点击按钮事件
                LinkButton lbtnDir = new LinkButton();
                lbtnDir.Text = UpLevel.ToString();
                lbtnDir.CommandArgument = UpLevel.ToString();
                lbtnDir.Command += new CommandEventHandler(lbtnDir_Command);





                // 添加到容器中
                this.phContent.Controls.Add(picColumn);
                this.phContent.Controls.Add(lbtnDir);
                this.phContent.Controls.Add(seperator);
                this.phContent.Controls.Add(seperator1);
                this.phContent.Controls.Add(seperator2);

                this.phContent.Controls.Add(endRow);

            }
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                //间隔的文本
                Literal seperator = new Literal();
                seperator.Text = Seperator;
                Literal seperator1 = new Literal();
                seperator1.Text = Seperator;
                Literal seperator2 = new Literal();
                seperator2.Text = Seperator;
                Literal endRow = new Literal();
                endRow.Text = "</td></tr>";


                //显示图标
                Literal picColumn = new Literal();
                picColumn.Text = "<TR><td><img src=pics/folder.gif></td><td>";

                Label sizeLbl = new Label();
                sizeLbl.Text = "文件数："+d.GetFiles().Length.ToString();


                Label modLbl = new Label();
                modLbl.Text = "子目录："+d.GetDirectories().Length.ToString();


                // 点击按钮事件
                LinkButton lbtnDir = new LinkButton();
                lbtnDir.Text = d.Name.ToString();
                lbtnDir.CommandArgument = d.Name.ToString();
                lbtnDir.Command += new CommandEventHandler(lbtnDir_Command);

                //删除按钮
                System.Web.UI.WebControls.ImageButton deleteBtn = new ImageButton();
                deleteBtn.ImageUrl = "pics/delete_icon.gif";
                deleteBtn.Attributes.Add("onclick", "javascript:return confirm('确定删除目录：" + d.Name + "吗？');");
                deleteBtn.CommandName = "DeleteDir";
                deleteBtn.CommandArgument = d.Name;
                deleteBtn.Command += new CommandEventHandler(deleteBtn_Command);
                //HyperLink deleteBtn = new HyperLink();
                //deleteBtn.ImageUrl = "pics/delete_icon.gif";
                //deleteBtn.NavigateUrl = "javascript:confirmDelete('FileDelete.aspx?Type=Folder&Name=" + Server.UrlEncode(Session["Path"].ToString() + d.Name.ToString()) + "','" + d.Name.ToString()+ "');";



                // 添加到容器中
                this.phContent.Controls.Add(picColumn);
                this.phContent.Controls.Add(lbtnDir);
                this.phContent.Controls.Add(seperator);
                this.phContent.Controls.Add(sizeLbl);
                this.phContent.Controls.Add(seperator1);
                this.phContent.Controls.Add(modLbl);
                this.phContent.Controls.Add(seperator2);
                this.phContent.Controls.Add(deleteBtn);
                this.phContent.Controls.Add(endRow);


            }

            foreach (FileInfo f in root.GetFiles())
            {
                //间隔的文本
                Literal seperator = new Literal();
                seperator.Text = Seperator;
                Literal seperator1 = new Literal();
                seperator1.Text = Seperator;
                Literal seperator2 = new Literal();
                seperator2.Text = Seperator;
                Literal endRow = new Literal();
                endRow.Text = "</td></tr>";


                Literal newColumn = new Literal();
                newColumn.Text = "</td> <td>";

                //显示图标
                Literal picColumn = new Literal();

                picColumn.Text = "<TR><td><img src=pics/file.gif></td><td>";


                // 删除按钮
                HyperLink goToBtn = new HyperLink();
                goToBtn.Text = f.Name.ToString();
                goToBtn.NavigateUrl = "http://" + Request.ServerVariables["SERVER_NAME"].ToString() + Session["Path"].ToString() + f.Name.ToString();
                goToBtn.Target = "_blank";

                long fileSize = f.Length;
                string fileSizeStr;
                if (fileSize > 1000000) fileSizeStr = fileSize / 1000000 + " Mb";
                else if (fileSize > 1000) fileSizeStr = fileSize / 1000 + " Kb";
                else fileSizeStr = fileSize + " b";


                Label sizeLbl = new Label();
                sizeLbl.Text = fileSizeStr;


                Label modLbl = new Label();
                modLbl.Text = f.LastWriteTime.ToString();


                System.Web.UI.WebControls.ImageButton deleteBtn = new ImageButton();
                deleteBtn.ImageUrl = "pics/delete_icon.gif";
                deleteBtn.Attributes.Add("onclick", "javascript:return confirm('确定删除文件：" + f.Name + "吗？');");
                deleteBtn.CommandName = "DeleteFile";
                deleteBtn.CommandArgument = f.Name;
                deleteBtn.Command += new CommandEventHandler(deleteBtn_Command);

                //HyperLink deleteBtn = new HyperLink();
                //deleteBtn.ImageUrl = "pics/delete_icon.gif";
                //deleteBtn.NavigateUrl = "javascript:confirmDelete('FileDelete.aspx?Type=File&Name=" + Server.UrlEncode(Session["Path"].ToString() + f.Name.ToString()) + "','" + f.Name.ToString()+ "');";

                this.phContent.Controls.Add(picColumn);
                this.phContent.Controls.Add(goToBtn);
                this.phContent.Controls.Add(seperator);
                this.phContent.Controls.Add(sizeLbl);
                this.phContent.Controls.Add(seperator1);
                this.phContent.Controls.Add(modLbl);
                this.phContent.Controls.Add(seperator2);
                this.phContent.Controls.Add(deleteBtn);
                this.phContent.Controls.Add(endRow);

            }
        }

    }


    private void lbtnDir_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "/")
            Session["Path"] = "/";
        else if (e.CommandArgument.ToString() == "../")
            Session["Path"] = this.GetParentDirectory();
        else
            Session["Path"] = Session["Path"].ToString() + e.CommandArgument.ToString() + "/";
        Response.Redirect("FileManage.aspx");

    }

    private string GetParentDirectory()
    {
        string path = Session["Path"].ToString();
        if (path == "./")
            return this.GetDefault();
        else if (path == this.GetDefault())
            return this.GetDefault();
        else
        {

            if (path.LastIndexOf("/") == path.Length - 1)
            {
                path = path.Remove(path.LastIndexOf("/"), (path.Length - path.LastIndexOf("/")));
            }
            try
            {
                path = path.Remove(path.LastIndexOf("/"), (path.Length - path.LastIndexOf("/")));
                return (path + "/");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return this.GetDefault();
            }
        }
    }

    private void deleteBtn_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "DeleteFile")
        {
            System.Diagnostics.Debug.WriteLine(Server.MapPath(this.lbDir.Text + e.CommandArgument.ToString()));
            FileInfo file = new FileInfo(Server.MapPath(this.lbDir.Text + e.CommandArgument.ToString()));
            try
            {
                file.Delete();
                //File.Delete(Server.MapPath(Server.UrlDecode(Request.QueryString["Name"].ToString())));

                Response.Redirect("FileManage.aspx");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }
        else
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath(this.lbDir.Text + e.CommandArgument.ToString()));
                dir.Delete(true);
               // dir.Delete();
                Response.Redirect("FileManage.aspx");
            }


            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

            }
        }
    }
}
