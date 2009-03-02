using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;
using System.IO;

namespace FT.Windows.CommonsPlugin
{
    [Plugin(ChangeLogPath = "Tools-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
      Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "工具插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ToolsPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("工具");
            //top.
            ToolStripMenuItem tmp = this.BuildTopMenu("数据库备份");
            tmp.Click += new EventHandler(dbbak_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("数据库还原");
            tmp.Click+=new EventHandler(dbrestore_Click);
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("基础数据管理");
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("计算器");
            tmp.Click += new EventHandler(calc_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("记事本");
            tmp.Click += new EventHandler(notepad_Click);
            top.DropDownItems.Add(tmp);
        }

        void calc_Click(object sender, EventArgs e)
        {
            this.StartExtendTools("calc.exe");
        }

        void notepad_Click(object sender, EventArgs e)
        {
            this.StartExtendTools("notepad.exe");
        }

        //calc.exe
        //notepad.exe

        void dbbak_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.SaveAccessDb();
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
            string path = FileDialogHelper.OpenAccessDb();
            if (path != null && path != string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("确定要还原吗？请在还原前进行备份！", "窗口提示", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        File.Copy(path, ReflectHelper.GetExePath() + @"\db\db.mdb", true);
                        MessageBoxHelper.Show("还原成功！");
                    }
                    catch (Exception ex)
                    {
                        //LogFactoryWrapper.Debug(ex.ToString());
                        MessageBoxHelper.Show("还原失败！");
                    }
                }

            }
        }

        public override void EmmitToolBar()
        {
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
