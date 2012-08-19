using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class WebSiteHintControl : UserControl
    {
        public WebSiteHintControl()
        {
            InitializeComponent();
        }

        private void WebSiteHintControl_Load(object sender, EventArgs e)
        {
            try
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                this.lbWebSiteUrl.Text = config.InternalUrl;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
