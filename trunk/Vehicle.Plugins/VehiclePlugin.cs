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
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "机动车预登记插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class VehiclePlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("机动车管理(&U)");
            //top.
            ToolStripMenuItem tmp = this.BuildSubMenu("添加机动车", typeof(VehicleBrowser));


            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("机动车管理", typeof(VehicleSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("照片维护", typeof(PhotoManage));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("系统配置", typeof(VehicleConfig));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("操作日志", typeof(OptLogSearch));
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = true;
            //throw new Exception("The method or operation is not implemented.");
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(Vehicle.Plugins.Resource.add, "初次登记", typeof(VehicleBrowser));
            this.AddTopTool(Vehicle.Plugins.Resource.search, "查询登记", typeof(VehicleSearch));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
