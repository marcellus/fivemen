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
      Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "�������ݹ��߲��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ToolsPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("�������ݹ���(&B)");
            //top.
            //ToolStripMenuItem tmp = this.BuildTopMenu("���ݿⱸ��");
            //tmp.Click += new EventHandler(dbbak_Click);
            //top.DropDownItems.Add(tmp);
            //tmp = this.BuildTopMenu("���ݿ⻹ԭ");
            //tmp.Click+=new EventHandler(dbrestore_Click);
            //top.DropDownItems.Add(tmp);
            //this.AddSeparatorToMenu(top);
            ToolStripMenuItem tmp = this.BuildSubMenu("��ӻ�������", typeof(DictBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�������ݹ���", typeof(DictSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("���ʡ����Ϣ", typeof(ProvinceBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ʡ����Ϣ����", typeof(ProvinceSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("���������Ϣ", typeof(CityBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("������Ϣ����", typeof(CitySearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("���������Ϣ", typeof(AreaBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("������Ϣ����", typeof(AreaSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("���������Ϣ", typeof(XiangBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("������Ϣ����", typeof(XiangSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("��Ӵ��ί��Ϣ", typeof(CunBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("���ί��Ϣ����", typeof(CunSearch));
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
            string path = FileDialogHelper.OpenAccessDb();
            if (path != null && path != string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("ȷ��Ҫ��ԭ�����ڻ�ԭǰ���б��ݣ�", "������ʾ", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        File.Copy(path, ReflectHelper.GetExePath() + @"\db\db.mdb", true);
                        MessageBoxHelper.Show("��ԭ�ɹ���");
                    }
                    catch (Exception ex)
                    {
                        //LogFactoryWrapper.Debug(ex.ToString());
                        MessageBoxHelper.Show("��ԭʧ�ܣ�");
                    }
                }

            }
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.BaseData, "�������ݹ���",typeof(DictSearch));
            //this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Notepad, "���±�").Click += new EventHandler(notepad_Click);
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
