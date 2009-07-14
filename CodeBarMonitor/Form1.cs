using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.NoUser;
using FT.Commons.Cache;
using FT.Windows.Forms.SimpleLog;
using FT.Commons.Tools;
using System.IO;
using System.Text.RegularExpressions;
using log4net;
using System.Xml;
using FT.Windows.ExternalTool;
using FT.Commons.Bar;

namespace CodeBarMonitor
{
    public partial class Form1 : Form
    {

        private SimpleBarReader reader = new SimpleBarReader();
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        //protected static ILog log = log4net.LogManager.GetLogger("tools");

        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="obj"></param>
        protected static void Debug(object obj)
        {
            if (log != null && log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="obj"></param>
        protected static void Info(object obj)
        {
            if (log != null && log.IsInfoEnabled)
            {
                log.Info(obj);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.About();
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }

        private void �鿴��־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ShowLogs();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ChangePwd();
        }

        private void �����־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ClearLogs();
        }

        private void ϵͳ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NoUserHelper.Unlock())
            {
                Form form = new BarReaderConfigForm();
                form.ShowDialog();
             }
        }

        public const string OptUserConst = "�����ع���";

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.CreateLog("ϵͳ������");
                if (!reader.StartWatching())
                {
                    MessageBoxHelper.Show("�����������ʧ�ܣ�");
                }
                else
                {
                   
                }
            }
           
        }

        public void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = OptUserConst;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }

        

        

        private String GetTextInXml(string xml, string xpath)
        {
            XmlDocument   doc=new XmlDocument();
            doc.LoadXml(xml);
            XmlNode node=doc.SelectSingleNode(xpath);
            if(node!=null)
            {
                return node.InnerText;
            }
            return string.Empty;
        }

        public void SetHintText(String str)
        {
            this.notifyIcon1.Text = "���������-" + str;
        }

        

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "<?xml version=\"1.0\" encoding=\"GBK\" ?> "
+"<response><head><code>integer</code>"
+"<message>String</message>"
+"</head>"
+"<body>"
+"	    <rownum>int</rownum>"
+"	    <item>"
 +"<hpzl>string</hpzl>"
 +"<hphm>string</hphm>"
 +"<zp>string</zp>"
+"</item>"
+ "</body>"
+"</response>";
            Console.WriteLine(this.GetTextInXml(str, "//code"));
            Console.WriteLine(this.GetTextInXml(str, "//message"));
            Console.WriteLine(this.GetTextInXml(str, "//body"));
            Console.WriteLine(this.GetTextInXml(str, "//rownum"));
            Console.WriteLine(this.GetTextInXml(str, "//zp"));

            Form form = new Form();
            Control editor = new FT.Windows.Controls.Editor();
            editor.Dock = DockStyle.Fill;
            form.Controls.Add(editor);
            form.Show();
        }

        private void ͼƬת������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CodeReader();
            form.ShowInTaskbar = true;
            form.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader.IsOpen)
            {
                reader.StopWatching();
            }
        } 
    }
}