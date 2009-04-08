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
    public partial class TcpServerConfigForm : Form
    {
        
        public TcpServerConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            //�������еļ�����
            //�������õ����л�
            //�����Ĭ�Ͽ���������
            string port = this.txtPort.Text.Trim();
            try
            {
                int tmp = Convert.ToInt32(port);
                ServerConfig config = new ServerConfig();
                config.Port = tmp;
                config.Ip = this.txtIp.Text.Trim();
                config.DefaultOpen = this.cbDefaultStart.Checked;
                ServerConfig.SaveConfig(config);
                MessageBoxHelper.Show("����ɹ�");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("�˿ڱ��������֣�");
            }
        }

        private void TcpServerConfig_Load(object sender, EventArgs e)
        {
            ServerConfig config = ServerConfig.GetConfig();
            if (config != null)
            {
                this.cbDefaultStart.Checked = config.DefaultOpen;
                this.txtIp.Text = config.Ip;
                this.txtPort.Text = config.Port.ToString();
            }
            else
            {
                this.txtIp.Text =HardwareManager.GetDefaultIp();
            }
        }
    }
}

