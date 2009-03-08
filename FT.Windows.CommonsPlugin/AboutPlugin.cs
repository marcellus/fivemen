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
    [Plugin(ChangeLogPath = "AboutPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "软件的帮助插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class AboutPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top= this.AddToMenu("帮助(&H)");
            //top.
            
            this.AddSeparatorToMenu(top);
            ToolStripMenuItem tmp = this.BuildSubMenu("注册...", typeof(FT.Windows.Forms.SimpleRegister));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("使用单位配置...", typeof(FT.Windows.Forms.SimpleCompany));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("帮助文档");
            tmp.Click += new EventHandler(help_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("使用情况", typeof(FT.Windows.Forms.ProgramRegConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("关于...", typeof(FT.Windows.Forms.SimpleAbout));
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = true;
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
                MessageBoxHelper.Show("错误信息："+ex.Message);

            }
            //throw new Exception("The method or operation is not implemented.");
        }

        
        public override void EmmitToolBar()
        {
            
           // ToolStripButton btn= this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Config, "帮助");
            //btn.Click += new EventHandler(help_Click);
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Home_16_16, "关于", typeof(FT.Windows.Forms.SimpleAbout));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
