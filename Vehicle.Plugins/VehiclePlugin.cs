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

namespace Vehicle.Plugins
{
    [Plugin(ChangeLogPath = "VehiclePlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "������Ԥ�Ǽǲ��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class VehiclePlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("����������(&U)");
            //top.
            ToolStripMenuItem tmp = this.BuildSubMenu("��ӻ�����", typeof(VehicleBrowser));


            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����������", typeof(VehicleSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("��Ƭά��", typeof(PhotoManage));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("ϵͳ����", typeof(VehicleConfig));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("������־", typeof(OptLogSearch));
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = true;
            //throw new Exception("The method or operation is not implemented.");
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(Vehicle.Plugins.Resource.add, "���εǼ�", typeof(VehicleBrowser));
            this.AddTopTool(Vehicle.Plugins.Resource.search, "��ѯ�Ǽ�", typeof(VehicleSearch));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
