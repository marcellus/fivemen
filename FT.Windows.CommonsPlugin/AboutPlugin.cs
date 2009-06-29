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
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "����İ������", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class AboutPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top= this.AddToMenu("����(&H)");
            //top.
            
           // this.AddSeparatorToMenu(top);
            ToolStripMenuItem tmp = this.BuildSubMenu("ע��...", typeof(FT.Windows.Forms.SimpleRegister));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ʹ�õ�λ����...", typeof(FT.Windows.Forms.SimpleCompany));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("ȫ�ִ�ӡ����...", typeof(FT.Windows.Forms.CustomPrinterSetting));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("�����Զ���������...", typeof(FT.Windows.Forms.DbAutoBakConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("���ݱ���");
            tmp.Click += new EventHandler(dbbak_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("���ݻ�ԭ");
            tmp.Click+=new EventHandler(dbrestore_Click);
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("�����ĵ�");
            tmp.Click += new EventHandler(help_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ʹ�����", typeof(FT.Windows.Forms.ProgramRegConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����...", typeof(FT.Windows.Forms.SimpleAbout));
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
                    MessageBoxHelper.Show(" ���ݳɹ���");
                }
                catch (Exception ex)
                {
                    //LogFactoryWrapper.Debug(ex.ToString());
                    MessageBoxHelper.Show(" ����ʧ�ܣ�");
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
            DataTable dt=DataAccessFactory.GetDataAccess().SelectDataTable("select id as ���,c_text as �����ı�,c_value as ���ݴ���,c_blongarea as ����Ͻ��,c_valid as �Ƿ���Ч from table_xiang","test");
            DataTablePrinterContent.Print(dt, new int[] {50,80,100,120 },"������Ϣ��");

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
                    MessageBoxHelper.Show("�Ҳ��������ļ���");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("������Ϣ��" + ex.Message);

            }
        }

        
        public override void EmmitToolBar()
        {
            
           // ToolStripButton btn= this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Config, "����");
            //btn.Click += new EventHandler(help_Click);
            //this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Home_16_16, "�˳�", typeof(FT.Windows.Forms.SimpleAbout));
            ToolStripButton btn=this.AddTopTool(FT.Windows.CommonsPlugin.Resource.dbbak, "���ݱ���");
            btn.Click += new EventHandler(dbbak_Click);
            btn = this.AddTopTool(FT.Windows.CommonsPlugin.Resource.dbrestore, "���ݻ�ԭ");
            btn.Click += new EventHandler(dbrestore_Click);
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.About, "����", typeof(FT.Windows.Forms.SimpleAbout));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
