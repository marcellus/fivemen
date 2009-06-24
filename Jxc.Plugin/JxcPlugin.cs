using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Windows.CommonsPlugin;

namespace Jxc.Plugin
{
    /// <summary>
    /// 进销存管理插件
    /// </summary>
    [FT.Windows.Forms.Plugins.Plugin(ChangeLogPath = "CarOwnerPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "进销存管理插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class JxcPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("进销存管理(&M)");
            ToolStripMenuItem tmp = this.BuildSubMenu("添加销售记录", typeof(SellRecordBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("销售记录管理", typeof(SellRecordSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("添加入库记录", typeof(InRecordBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("入库记录管理", typeof(InRecordSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("添加产品种类", typeof(BaseDataBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("产品种类管理", typeof(BaseDataSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("销售统计", typeof(SellCounter));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("模板列定义管理", typeof(FT.Windows.Forms.EntityConfigSearch));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("基础数据管理", typeof(DictSearch));
            top.DropDownItems.Add(tmp);
            
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(Jxc.Plugin.Resource.Sell, "添加销售记录", typeof(SellRecordBrowser));
            this.AddTopTool(Jxc.Plugin.Resource.In, "添加入库记录", typeof(InRecordBrowser));
        }
    }
}
