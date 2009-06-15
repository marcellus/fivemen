using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using log4net;
using System.IO;
using System.Net;
using FT.Commons.Tools;
using System.Text.RegularExpressions;

namespace FT.Commons.WebCatcher
{
    public partial class RegexTest : Form
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.WebCatcher.RegexTest");
        private CatcherConfig config;
        public RegexTest()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            config=StaticCacheManager.GetConfig<CatcherConfig>();
            this.txtUrl.Text = config.Url;
        }

        private void btnGetSource_Click(object sender, EventArgs e)
        {
            if (this.txtUrl.Text.Trim().Length > 0)
            {
                SimpleCatcher catcher = new SimpleCatcher();
                this.txtPageSource.Text=catcher.GetPageSource(this.txtUrl.Text.Trim());
            }
            
        }

        

        private void btnMatch_Click(object sender, EventArgs e)
        {
            if (this.txtRegex.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("��������������ʽ��");
                this.txtRegex.Focus();
                return;
            }
            if (this.txtPageSource.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("����������������ַ�����");
                this.txtPageSource.Focus();
                return;
            }
            string source = this.txtPageSource.Text.Trim();
            Regex reg = new Regex(this.txtRegex.Text.Trim());
            Match m = reg.Match(source);
            int matchCount = 0;
            StringBuilder sb = new StringBuilder("ƥ������");
            while (m.Success)
            {
                matchCount++;
                sb.Append("\r\n ��" + matchCount.ToString()+"�");
                foreach (Group group in m.Groups)
                {
                    sb.Append("|"+group.Value);
                }
                m = m.NextMatch();
            }
            sb.Append("\r\n ��ƥ�䵽"+matchCount.ToString()+"���");
            this.txtResult.Text = sb.ToString();
        }
    }
}