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
    public partial class ServicePhoneControl : UserControl
    {
        public ServicePhoneControl()
        {
            InitializeComponent();
        }

        private void ServicePhoneControl_Load(object sender, EventArgs e)
        {
            try
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                this.lbServicePhone.Text = config.ServicePhone;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
