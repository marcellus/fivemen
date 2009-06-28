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

namespace DS.Plugins.Car
{
    /// <summary>
    /// ����������
    /// </summary>
    [Plugin(ChangeLogPath = "CarOwnerPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "����������", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class CarOwnerPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("������������(&V)");
            ToolStripMenuItem tmp = this.BuildSubMenu("��ӳ���", typeof(CarOwnerBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("��������", typeof(CarOwnerSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("��ӽ���Ա", typeof(CoachBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����Ա����", typeof(CoachSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("��ӳ���", typeof(CarBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("��������", typeof(CarSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("��ӳ�����¼", typeof(CarOutBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("������¼����", typeof(CarOutSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("��ӳ�������", typeof(CarFeeBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�������ù���", typeof(CarFeeSearch));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(DS.Plugins.Car.Resource.Ower, "��������", typeof(CarOwnerSearch));
            this.AddTopTool(DS.Plugins.Car.Resource.Coach, "��������", typeof(CoachSearch));
            this.AddTopTool(DS.Plugins.Car.Resource.Car, "��������", typeof(CarSearch));
        }
    }
}
