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
    /// ѧԱ����Ĳ��
    /// </summary>
    [Plugin(ChangeLogPath = "SystemConfigPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "��Уϵͳ���ò��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class SystemConfigPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("��Уϵͳ����(&G)");
            ToolStripMenuItem tmp = this.BuildSubMenu("ȫ�ִ�ӡ����...", typeof(FT.Windows.Forms.CustomPrinterSetting));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ѧԱ��ӡ����", typeof(PrintSettingForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("ģ���ж������", typeof(FT.Windows.Forms.EntityConfigSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("����ʱ������", typeof(StudentSystemConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����֤����", typeof(FT.Device.IDCard.IDCardConfigForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildTopMenu("������������");
            tmp.Click += new EventHandler(bak_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("��ԭ��������");
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
                    MessageBoxHelper.Show("���ݳɹ���");
                }
                else
                {
                     MessageBoxHelper.Show("����ʧ�ܣ�");
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
                    MessageBoxHelper.Show("��ԭ�ɹ������˳��ؽ�ʹ������Ч��");
                   //FT.Commons.Cache.StaticCacheManager.Caches.Clear();
                }
                else
                {
                    MessageBoxHelper.Show("��ԭʧ�ܣ�");
                }
            }
        }

        public override void EmmitToolBar()
        {

        }
    }
}
