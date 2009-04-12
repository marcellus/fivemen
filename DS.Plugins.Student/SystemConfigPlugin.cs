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

namespace DS.Plugins.Student
{
    /// <summary>
    /// 学员管理的插件
    /// </summary>
    [Plugin(ChangeLogPath = "SystemConfigPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "驾校系统配置插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class SystemConfigPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("驾校系统配置(&G)");
            ToolStripMenuItem tmp = this.BuildSubMenu("全局打印配置...", typeof(FT.Windows.Forms.CustomPrinterSetting));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("学员打印配置", typeof(PrintSettingForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("模板列定义管理", typeof(FT.Windows.Forms.EntityConfigSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("考试时间配置", typeof(StudentSystemConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("二代证配置", typeof(FT.Device.IDCard.IDCardConfigForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("备份所有配置");
            tmp.Click += new EventHandler(bak_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("还原所有配置");
            tmp.Click += new EventHandler(restore_Click);
            top.DropDownItems.Add(tmp);
            
        }

        void bak_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveZip(string.Empty);
            if(file.Length>0)
            {
                string path=ReflectHelper.GetExePath();
                string dir = Path.Combine(path, "config");
                if(FileHelper.ZipDir(dir,file))
                {
                    MessageBoxHelper.Show("备份成功！");
                }
                else
                {
                     MessageBoxHelper.Show("备份失败！");
                }
            }
        }
        void restore_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.OpenZip(string.Empty);
            if (file.Length > 0)
            {
                string path = ReflectHelper.GetExePath();
                string dir = Path.Combine(path, "config");
                if (FileHelper.UnZipDir( file,dir))
                {
                    MessageBoxHelper.Show("还原成功！请退出重进使配置生效！");
                   //FT.Commons.Cache.StaticCacheManager.Caches.Clear();
                }
                else
                {
                    MessageBoxHelper.Show("还原失败！");
                }
            }
        }

        public override void EmmitToolBar()
        {

        }
    }
}
