using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool
{
    public partial class RuntimeView : Form
    {
        public RuntimeView()
        {
            InitializeComponent();
        }

        private void ShowAssembly(Assembly assembly)
        {
            this.txtResult.AppendText("\r\nAssembly FullName:" + assembly.FullName);
            this.txtResult.AppendText("\r\nAssembly Location:" + assembly.Location);
            this.txtResult.AppendText("\r\nAssembly CodeBase:" + assembly.CodeBase);
            this.txtResult.AppendText("\r\nAssembly EscapedCodeBase:" + assembly.EscapedCodeBase);
            //this.txtResult.AppendText("\r\nAssembly EntryPoint:" + assembly.EntryPoint.DeclaringType);
            Module[] modules = assembly.GetLoadedModules();
            foreach (Module module in modules)
            {
                ShowModule(module);
            }

            this.txtResult.AppendText("\r\nAssembly GlobalAssemblyCache:" + assembly.GlobalAssemblyCache);
            this.txtResult.AppendText("\r\nAssembly ImageRuntimeVersion:" + assembly.ImageRuntimeVersion);
            this.txtResult.AppendText("\r\nAssembly ReflectionOnly:" + assembly.ReflectionOnly);
            //this.txtResult.AppendText("\r\nAssembly Location:" + assembly.);
            //this.txtResult.AppendText("\r\nAssembly Location:" + assembly.Location);
        }

        private  void ShowModule(Module module)
        {
            this.txtResult.AppendText("\r\n\tModule Name:" + module.Name);
            this.txtResult.AppendText("\r\n\tModule ScopeName:" + module.ScopeName);
            this.txtResult.AppendText("\r\n\tModule ModuleVersionId:" + module.ModuleVersionId);
            this.txtResult.AppendText("\r\n\tModule MetadataToken:" + module.MetadataToken);
            this.txtResult.AppendText("\r\n\tModule MDStreamVersion:" + module.MDStreamVersion);
            this.txtResult.AppendText("\r\n\tModule FullyQualifiedName:" + module.FullyQualifiedName);
        }

        private  void ShowAllAssembly()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assemblies)
            {
                ShowAssembly(ass);
            }
        }

        private void SetResultTitle(string title)
        {
            this.txtResult.Text = title;
        }

        private void ShowDomainAssembly_Click(object sender, EventArgs e)
        {
            this.SetResultTitle("显示Domain所有的Assembly结果为：");
            this.ShowAllAssembly();
        }

        private void btnCreateInstance_Click(object sender, EventArgs e)
        {
            string name=this.txtReflectClass.Text.Trim();
            if(name.Length==0)
            {
                MessageBoxHelper.Show("请输入类名！");
                this.txtReflectClass.Focus();
                return;
            }
            this.SetResultTitle("反射类名为"+name+"结果为：");
            try
            {
                object obj =ReflectHelper.CreateInstance(name);
                if (obj != null)
                {
                    this.txtResult.AppendText("\r\n反射成功！");
                }
                else
                {
                    this.txtResult.AppendText("\r\n反射结果为空,在Domain中未找到类型！");
                }
            }
            catch(Exception ex)
            {
                this.txtResult.AppendText("\r\n反射异常:"+ex.Message);
            }
        }

        private void btnShowControlName_Click(object sender, EventArgs e)
        {
            string name=this.txtControlName.Text.Trim();
            if(name.Length==0)
            {
                MessageBoxHelper.Show("请输入控件类名！");
                this.txtControlName.Focus();
                return;
            }
            this.SetResultTitle("显示类名为"+name+"所有的子控件Name结果为：");
            try
            {
                Control ctr =ReflectHelper.CreateInstance(name) as Control;
                if(ctr!=null)
                {
                    this.ShowName(ctr);
                }
                else
                {
                    this.txtResult.AppendText("\r\n类名不是正确的控件类型！");
                }
            }
            catch(Exception ex)
            {
                this.txtResult.AppendText("\r\n异常:"+ex.Message);
            }
            
        }

        private void ShowName(Control ctr)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                this.txtResult.AppendText("\r\n控件Name: " + ctr.Name+"  类型:"+ctr.GetType().Name);

            }
            else
            {
                for (int i = 0; i < ctr.Controls.Count; i++)
                {
                    ShowName(ctr.Controls[i]);
                }
            }
        }

        
    }
}