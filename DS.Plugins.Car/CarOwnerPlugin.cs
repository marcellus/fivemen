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
    /// 车主管理插件
    /// </summary>
    [Plugin(ChangeLogPath = "CarOwnerPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "车辆管理插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class CarOwnerPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("教练车辆管理(&V)");
            ToolStripMenuItem tmp = this.BuildSubMenu("添加车主", typeof(CarOwnerBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("车主管理", typeof(CarOwnerSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("添加教练员", typeof(CoachBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("教练员管理", typeof(CoachSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("添加车辆", typeof(CarBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("车辆管理", typeof(CarSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("添加出车记录", typeof(CarOutBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("出车记录管理", typeof(CarOutSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("添加车辆费用", typeof(CarFeeBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("车辆费用管理", typeof(CarFeeSearch));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(DS.Plugins.Car.Resource.Ower, "车主管理", typeof(CarOwnerSearch));
            this.AddTopTool(DS.Plugins.Car.Resource.Coach, "教练管理", typeof(CoachSearch));
            this.AddTopTool(DS.Plugins.Car.Resource.Car, "车辆管理", typeof(CarSearch));
        }
    }
}
