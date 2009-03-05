using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace FT.Windows.CommonsPlugin
{
    [Plugin(ChangeLogPath = "LoginPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "登陆插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class LoginPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("系统用户(&U)");
            //top.
            ToolStripMenuItem tmp = this.BuildSubMenu("添加用户", typeof(FT.Windows.CommonsPlugin.UserBrowser));


            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("用户管理", typeof(FT.Windows.CommonsPlugin.UserSearchControl));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("修改密码", typeof(FT.Windows.CommonsPlugin.PwdChangeForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("锁定系统", typeof(FT.Windows.CommonsPlugin.LockSystemForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("退出系统");
            tmp.Click += new EventHandler(quit_Click);
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = true;
            //throw new Exception("The method or operation is not implemented.");
        }

        void quit_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Confirm("确定退出本系统吗？"))
            {
                Application.Exit();
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        void help_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("help.exe"))
                {
                    Process.Start("help.exe");
                    return;
                }
                else if (File.Exists("help.chm"))
                {
                    Process.Start("help.chm");
                    return;
                }
                else
                {
                    MessageBoxHelper.Show("找不到帮助文件！");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("错误信息：" + ex.Message);

            }
            //throw new Exception("The method or operation is not implemented.");
        }


        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.WLM, "用户管理", typeof(FT.Windows.CommonsPlugin.UserSearchControl));
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Locker, "锁定系统", typeof(FT.Windows.CommonsPlugin.LockSystemForm));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
