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
      Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "基础数据工具插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ToolsPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("基础数据工具(&B)");
            //top.
            //ToolStripMenuItem tmp = this.BuildTopMenu("数据库备份");
            //tmp.Click += new EventHandler(dbbak_Click);
            //top.DropDownItems.Add(tmp);
            //tmp = this.BuildTopMenu("数据库还原");
            //tmp.Click+=new EventHandler(dbrestore_Click);
            //top.DropDownItems.Add(tmp);
            //this.AddSeparatorToMenu(top);
            ToolStripMenuItem tmp = this.BuildSubMenu("添加基础数据", typeof(DictBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("基础数据管理", typeof(DictSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("添加省份信息", typeof(ProvinceBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("省份信息管理", typeof(ProvinceSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("添加市区信息", typeof(CityBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("市区信息管理", typeof(CitySearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("添加县市信息", typeof(AreaBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("县市信息管理", typeof(AreaSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("添加乡镇信息", typeof(XiangBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("乡镇信息管理", typeof(XiangSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("添加村居委信息", typeof(CunBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("村居委信息管理", typeof(CunSearch));
            top.DropDownItems.Add(tmp);

         
            this.IsEmmitSeparator = true;
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
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.BaseData, "基础数据管理",typeof(DictSearch));
            //this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Notepad, "记事本").Click += new EventHandler(notepad_Click);
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
