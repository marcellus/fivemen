using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Windows.CommonsPlugin;

namespace Jxc.Plugin
{
    /// <summary>
    /// �����������
    /// </summary>
    [FT.Windows.Forms.Plugins.Plugin(ChangeLogPath = "CarOwnerPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "�����������", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class JxcPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("���������(&M)");
            ToolStripMenuItem tmp = this.BuildSubMenu("������ۼ�¼", typeof(SellRecordBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("���ۼ�¼����", typeof(SellRecordSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("�������¼", typeof(InRecordBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����¼����", typeof(InRecordSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("��Ӳ�Ʒ����", typeof(BaseDataBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("��Ʒ�������", typeof(BaseDataSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("����ͳ��", typeof(SellCounter));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("ģ���ж������", typeof(FT.Windows.Forms.EntityConfigSearch));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("�������ݹ���", typeof(DictSearch));
            top.DropDownItems.Add(tmp);
            
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(Jxc.Plugin.Resource.Sell, "������ۼ�¼", typeof(SellRecordBrowser));
            this.AddTopTool(Jxc.Plugin.Resource.In, "�������¼", typeof(InRecordBrowser));
        }
    }
}
