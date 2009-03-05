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
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "��½���", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class LoginPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("ϵͳ�û�(&U)");
            //top.
            ToolStripMenuItem tmp = this.BuildSubMenu("����û�", typeof(FT.Windows.CommonsPlugin.UserBrowser));


            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�û�����", typeof(FT.Windows.CommonsPlugin.UserSearchControl));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("�޸�����", typeof(FT.Windows.CommonsPlugin.PwdChangeForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����ϵͳ", typeof(FT.Windows.CommonsPlugin.LockSystemForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�˳�ϵͳ");
            tmp.Click += new EventHandler(quit_Click);
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = true;
            //throw new Exception("The method or operation is not implemented.");
        }

        void quit_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Confirm("ȷ���˳���ϵͳ��"))
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
                    MessageBoxHelper.Show("�Ҳ��������ļ���");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("������Ϣ��" + ex.Message);

            }
            //throw new Exception("The method or operation is not implemented.");
        }


        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.WLM, "�û�����", typeof(FT.Windows.CommonsPlugin.UserSearchControl));
            this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Locker, "����ϵͳ", typeof(FT.Windows.CommonsPlugin.LockSystemForm));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
