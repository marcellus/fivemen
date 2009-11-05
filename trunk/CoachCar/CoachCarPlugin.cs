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

namespace CoachCar
{
    [Plugin(ChangeLogPath = "ExternalTool-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "教练车信息插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class CoachCarPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            ToolStripMenuItem top = this.AddToMenu("教练车管理(&C)");
            ToolStripMenuItem tmp = this.BuildSubMenu("添加教练车", typeof(CoachCarBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("教练车管理", typeof(CoachCarSearchControl));
            top.DropDownItems.Add(tmp);
            //this.AddSeparatorToMenu(top);
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(CoachCar.Resource.Car, "教练车管理", typeof(CoachCarSearchControl));
        }
    }
}
