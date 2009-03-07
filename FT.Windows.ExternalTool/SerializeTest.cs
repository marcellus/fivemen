using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fm.Common.Info;
using FT.Commons.Tools;
using Fm.Common.TcpIp;

namespace FT.Windows.ExternalTool
{
    public partial class SerializeTest : Form
    {
        public SerializeTest()
        {
            InitializeComponent();
            
        }

       /* public SoftInfo soft=new SoftInfo();

        private void InitSoftInfo()
        {
            soft.ChangeLogPath = "c:\\changelog.log";
            soft.Company = "fm-company";
            soft.Developer = "austin chen";
            soft.Email = "cbw123_1984@163.com";
            soft.IsDeploy = true;
            soft.IsGlobalization = true;
            soft.MainVersion = "1.0.0.1";
            soft.Name = "驾校预录入系统";
            soft.Tel = "15912345678";
            soft.Url = "http://www.hutong.com";
            RegInfo reginfo=new RegInfo();
            reginfo.BeginDate=new DateTime(2007,12,12);
            reginfo.LastDate=new DateTime(2008,1,1);
            reginfo.MachineCode="machinecode";
            reginfo.RegCode="regcode";
            reginfo.UserName="softusername";
            reginfo.UseTimes=100;
            soft.RegInfo = reginfo;
            PluginInfo plugin1 = new PluginInfo();
            plugin1.CategoryIndex = 1;
            plugin1.ChangeLogPath = "plugin1.changelog.log";
            plugin1.Company = "plugin1company";
            plugin1.Developer = "develper1";
            plugin1.Email = "email";
           // plugin1.Img = null;
            plugin1.IsDeploy = false;
            plugin1.IsGlobalization = false;
            plugin1.MainVersion="2.0.0.5";
            plugin1.Method = "method";
            plugin1.Name = "plugin1";
            plugin1.Text = "生活工具";
            plugin1.Url = "pluginurl";
            plugin1.Tel = "tel";
            soft.Plugins.Add(plugin1);

            PluginInfo plugin2 = new PluginInfo();
            plugin2.CategoryIndex = 2;
            plugin2.ChangeLogPath = "plugin2.changelog.log";
            plugin2.Company = "plugin2company";
            plugin2.Developer = "develper2";
            plugin2.Email = "email";
            //plugin2.Img = null;
            plugin2.IsDeploy = false;
            plugin2.IsGlobalization = false;
            plugin2.MainVersion = "2.0.0.5";
            plugin2.Method = "method";
            plugin2.Name = "plugin2";
            plugin2.Text = "生活工具2";
            plugin2.Url = "pluginurl";
            plugin2.Tel = "tel";

            soft.Plugins.Add(plugin2);
        }
        * */

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                PluginInfo plugin2 = new PluginInfo();
                plugin2.CategoryIndex = 2;
                plugin2.ChangeLogPath = "plugin2.changelog.log";
                plugin2.Company = "plugin2company";
                plugin2.Developer = "develper2";
                plugin2.Email = "email";
                //plugin2.Img = null;
                plugin2.IsDeploy = false;
                plugin2.IsGlobalization = false;
                plugin2.MainVersion = "2.0.0.5";
                plugin2.Method = "method";
                plugin2.Name = "plugin2";
                plugin2.Text = "生活工具2";
                plugin2.Url = "pluginurl";
                plugin2.Tel = "tel";

                this.textBox1.Text = SerializeHelper.SerializeToXml(plugin2);
                 * */
                SoftInfo soft = new SoftInfo();
                soft.ChangeLogPath = "c:\\changelog.log";
                soft.Company = "fm-company";
                soft.Developer = "austin chen";
                soft.Email = "cbw123_1984@163.com";
                soft.IsDeploy = true;
                soft.IsGlobalization = true;
                soft.MainVersion = "1.0.0.1";
                soft.Name = "驾校预录入系统";
                soft.Tel = "15912345678";
                soft.Url = "http://www.hutong.com";
                RegInfo reginfo = new RegInfo();
                reginfo.BeginDate = new DateTime(2007, 12, 12);
                reginfo.LastDate = new DateTime(2008, 1, 1);
                reginfo.MachineCode = "machinecode";
                reginfo.RegCode = "regcode";
                reginfo.UserName = "softusername";
                reginfo.UseTimes = 100;
                soft.RegInfo = reginfo;
                PluginInfo plugin1 = new PluginInfo();
                plugin1.CategoryIndex = 1;
                plugin1.ChangeLogPath = "plugin1.changelog.log";
                plugin1.Company = "plugin1company";
                plugin1.Developer = "develper1";
                plugin1.Email = "email";
                // plugin1.Img = null;
                plugin1.IsDeploy = false;
                plugin1.IsGlobalization = false;
                plugin1.MainVersion = "2.0.0.5";
                plugin1.Method = "method";
                plugin1.Name = "plugin1";
                plugin1.Text = "生活工具";
                plugin1.Url = "pluginurl";
                plugin1.Tel = "tel";
                soft.Plugins.Add(plugin1);

                PluginInfo plugin2 = new PluginInfo();
                plugin2.CategoryIndex = 2;
                plugin2.ChangeLogPath = "plugin2.changelog.log";
                plugin2.Company = "plugin2company";
                plugin2.Developer = "develper2";
                plugin2.Email = "email";
                //plugin2.Img = null;
                plugin2.IsDeploy = false;
                plugin2.IsGlobalization = false;
                plugin2.MainVersion = "2.0.0.5";
                plugin2.Method = "method";
                plugin2.Name = "plugin2";
                plugin2.Text = "生活工具2";
                plugin2.Url = "pluginurl";
                plugin2.Tel = "tel";

                soft.Plugins.Add(plugin2);
               // string temp = "<![CDATA[" + SerializeHelper.SerializeToXml(soft) + "]]>";
              //  SerializeSupport support = new SerializeSupport();
              //  support.data = temp;
              //  this.textBox1.Text = SerializeHelper.SerializeToXml(support);

                 this.textBox1.Text = SerializeHelper.SerializeToXml(soft);
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.StackTrace);
                string tmp = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoftInfo tmp = (SoftInfo)SerializeHelper.DeserializeFromXml(typeof(SoftInfo),this.textBox1.Text.Trim());
            MessageBox.Show(tmp.Plugins.Count.ToString());
            PluginInfo tmp2 = tmp.Plugins[1] as PluginInfo;
            MessageBox.Show(tmp2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
        }

        private void SerializeTest_Load(object sender, EventArgs e)
        {
           // this.InitSoftInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageInfo msg = new MessageInfo();
            SenderInfo send = new SenderInfo();
            send.MachineCode = "cpu";
            send.ProgramName = "驾校管理软件";
            send.Version = "5.0.0.6";
            OrgInfo org=new OrgInfo();
            org.FullName = "济南泰安国际股份有限驾校";
            org.NickName = "泰安驾校";
            org.Telephone = "tel";
            org.Url = "url";
            msg.ObjectType = (typeof(Fm.Driver.StudentInfo)).ToString();
            msg.Version = "1.0";
            msg.Sender = send;
            msg.Org = org;
            msg.Data = "data";

            this.textBox1.Text = SerializeHelper.SerializeToXml(msg);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageInfo tmp = (MessageInfo)SerializeHelper.DeserializeFromXml(typeof(MessageInfo), this.textBox1.Text.Trim());
            MessageBox.Show(tmp.Org.Telephone);
        }
    }

}