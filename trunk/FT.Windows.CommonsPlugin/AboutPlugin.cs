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
using System.Data;
using FT.DAL.Orm;
using FT.Commons.Cache;

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
            
           // this.AddSeparatorToMenu(top);
            ToolStripMenuItem tmp = this.BuildSubMenu("注册...", typeof(FT.Windows.Forms.SimpleRegister));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("使用单位配置...", typeof(FT.Windows.Forms.SimpleCompany));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("全局打印配置...", typeof(FT.Windows.Forms.CustomPrinterSetting));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("数据自动备份配置...", typeof(FT.Windows.Forms.DbAutoBakConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("数据备份");
            tmp.Click += new EventHandler(dbbak_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("数据还原");
            tmp.Click+=new EventHandler(dbrestore_Click);
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

        void dbbak_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.SaveBakDb();
            if (path != null && path != string.Empty)
            {
                try
                {
                    File.Copy(ReflectHelper.GetExePath() + @"\db\db.mdb", path, true);
                    MessageBoxHelper.Show(" 备份成功！");
                }
                catch (Exception ex)
                {
                    //LogFactoryWrapper.Debug(ex.ToString());
                    MessageBoxHelper.Show(" 备份失败！");
                }
            }
        }

        void dbrestore_Click(object sender, EventArgs e)
        {
            DbAutoBakConfig dbconfig = StaticCacheManager.GetConfig<DbAutoBakConfig>();
            dbconfig.RestoreDb();
        }

        void help_Click(object sender, EventArgs e)
        {
            //this.Test();
            this.ShowHelp();
            //throw new Exception("The method or operation is not implemented.");
        }

        private void Test()
        {
            DataTable dt=DataAccessFactory.GetDataAccess().SelectDataTable("select id as 编号,c_text as 数据文本,c_value as 数据代码,c_blongarea as 所属辖区,c_valid as 是否有效 from table_xiang","test");
            DataTablePrinterContent.Print(dt, new int[] {50,80,100,120 },"乡镇信息表");

        }

        private void ShowHelp()
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
        }

        
        public override void EmmitToolBar()
        {
            
           // ToolStripButton btn= this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Config, "帮助");
            //btn.Click += new EventHandler(help_Click);
            //this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Home_16_16, "退出", typeof(FT.Windows.Forms.SimpleAbout));
            ToolStripButton btn=this.AddTopTool(FT.Windows.CommonsPlugin.Resource.dbbak, "数据备份");
            btn.Click += new EventHandler(dbbak_Click);
            btn = this.AddTopTool(FT.Windows.CommonsPlugin.Resource.dbrestore, "数据还原");
            btn.Click += new EventHandler(dbrestore_Click);
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.About, "关于", typeof(FT.Windows.Forms.SimpleAbout));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
