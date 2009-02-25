using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using FT.Windows.Forms;

namespace FT.Test
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            
        }

        private void ShowForm(Type type)
        {
            Form form = Assembly.GetExecutingAssembly().CreateInstance(type.FullName) as Form;
            if (form != null)
            {
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(type.FullName + "类型不是Form对象！");
            }
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            Button btn = null;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                btn = Controls[i] as FT.Windows.Controls.ButtonEx.SimpleButton;
                if (btn != null)
                {
                    btn.Click += new EventHandler(btn_Click);
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string typename = this.GetType().Namespace + "." + btn.Text;
            this.ShowForm(System.Type.GetType(typename));

        }

        private void simpleComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.simpleComboBox1.SelectedIndex == 1)
            {
                
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
                this.Refresh();
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                this.Refresh();
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fm =new  FT.Windows.Forms.SimpleAbout();
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fm = new FT.Windows.Forms.SimpleRegister();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fm = new FT.Windows.Forms.SimpleCompany();
            fm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FT.Windows.Forms.PluginManageForm form = new PluginManageForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FT.Windows.Forms.BaseMainForm form = new BaseMainForm();
            form.Show();
        }

    }
}