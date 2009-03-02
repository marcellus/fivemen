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
      Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "���߲��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ToolsPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("����");
            //top.
            ToolStripMenuItem tmp = this.BuildTopMenu("���ݿⱸ��");
            tmp.Click += new EventHandler(dbbak_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("���ݿ⻹ԭ");
            tmp.Click+=new EventHandler(dbrestore_Click);
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("�������ݹ���");
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("������");
            tmp.Click += new EventHandler(calc_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("���±�");
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
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
