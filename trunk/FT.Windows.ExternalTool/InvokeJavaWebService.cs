using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.ExternalTool.localhost;

namespace FT.Windows.ExternalTool
{
    public partial class InvokeJavaWebService : Form
    {
        public const string url="http://localhost:8080/axis2/services/MyService";
        public InvokeJavaWebService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          MyService services=new   MyService();
          services.Url = url;
          this.txtResult.Text=services.getDrvimage(this.txtIdCardType.Text, this.txtIdCard.Text, this.txtReadSn.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyService services = new MyService();
             services.Url = url;
            this.txtResult.Text = services.write_drvimage(this.txtIdCardType.Text, this.txtIdCard.Text,this.txtZp.Text, this.txtWriteSn.Text);
        }
    }
}