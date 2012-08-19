using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Controls.FormEx;

namespace HiPiaoTerminal.TestForm
{
    public partial class AdShowTestForm : Form
    {
        public AdShowTestForm()
        {
            InitializeComponent();
        }

        private void AdShowForm_Load(object sender, EventArgs e)
        {
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            images.Add(Properties.Resources.Account_PrePage_Active);
            images.Add(Properties.Resources.Account_GoBuyTicket);
            images.Add(Properties.Resources.Account_HomePage);
            // this.adShowPanel1.Lists = images;
            AdShowForm form = new AdShowForm();
            form.Lists = images;
            form.ShowDialog();
        }
    }
}
