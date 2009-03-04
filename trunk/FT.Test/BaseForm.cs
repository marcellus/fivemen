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
            //FT.Commons.SkinProcessor.IrisSkin2Proccssor.InitSkinEngine();
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
            string path = FT.Commons.Tools.ReflectHelper.GetStartUpPath("plugins1\\FT.Lottery.dll");
            Console.WriteLine("the path is->"+path);
            form.GetStatusStrip().Visible = false;
            //form.LoadPluginDebug(path);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form = new EntityForm();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EncrptForm form = new EncrptForm();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Show(typeof(TestNameForm));
        }

        private void Show(Type type)
        {
            if (type.BaseType == typeof(Form))
            {
                Form form=System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(type.FullName) as Form;
                form.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Show(typeof(ReflectTestForm));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form form = new FT.Windows.Forms.ConditionBuildForm(typeof(FT.Plugins.PersonCard.Card));
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form form = new FT.Windows.Forms.ConditionBuildForm(typeof(TestUsers));
            form.Show();
        }

    }
}