using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.IO;

namespace FT.Commons.TcpIp
{
    public partial class ClientConfigForm : Form
    {
        
        public ClientConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string port = this.txtPort.Text.Trim();
            try
            {
                int tmp = Convert.ToInt32(port);
                ClientConfig config = new ClientConfig();
                config.Port = tmp;
                config.Ip = this.txtIp.Text.Trim();
                config.ServerIp = this.txtServerIp.Text.Trim();
                ClientConfig.SaveConfig(config);
                MessageBoxHelper.Show("保存成功");
            }
            catch(Exception ex)
            {
                MessageBoxHelper.Show("端口必须是数字！");
            }
        }

        private void ClientConfigForm_Load(object sender, EventArgs e)
        {
            ClientConfig config = ClientConfig.GetConfig();
            if (config != null)
            {
                this.txtServerIp.Text = config.ServerIp;
                this.txtIp.Text = config.Ip;
                this.txtPort.Text = config.Port.ToString();
            }
            else
            {
                this.txtIp.Text=HardwareManager.GetDefaultIp();
            }
        }
    }
}