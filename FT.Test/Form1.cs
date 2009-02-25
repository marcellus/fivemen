using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Controls;
using FT.Commons.Security;

namespace FT.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.SetSkin(SimpleSkinType.Blue);
            //this.toolTip1.
        }

        public void SetSkin(FT.Windows.Controls.SimpleSkinType skin)
        {
           /* ISkinControl tmp = null;
            foreach (Control ctr in this.Controls)
            {
                tmp = ctr as ISkinControl;
                if(tmp!=null)
                {
                   tmp.Skin = skin;
                  
                }
            }*/
            SkinFactory.DesignBySkin(this, skin);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.SetSkin(SimpleSkinType.Black);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.SetSkin(SimpleSkinType.Red);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.SetSkin(SimpleSkinType.Normal);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void myButtonObject1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hint");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text=SecurityFactory.GetSecurity().Encrypt(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = SecurityFactory.GetSecurity().Decrypt(this.textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           this.stateLamp1.IsRunning = true;
        }
    }
}