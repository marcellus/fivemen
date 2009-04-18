using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using FT.Commons.Tools;
using FT.Commons.Win32;

namespace FT.Commons.Win32
{
    public partial class SetWindowEnv : Form
    {
        ConfigLoader<SystemEnvConfig> loader = null;
        public SetWindowEnv()
        {

            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<SystemEnvConfig>(this);
        }

        private void btnReadFromReg_Click(object sender, EventArgs e)
        {
            RegistryKey regLocalMachine = Registry.LocalMachine;
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//打开HKEY_LOCAL_MACHINE下的SYSTEM
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//打开ControlSet001
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//打开Control
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//打开Control 
            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);//打开MSSQLServer下的MSSQLServer
            this.txtPath.Text=regEnvironment.GetValue("path", "").ToString();
            this.txtClassPath.Text = regEnvironment.GetValue("CLASSPATH", "").ToString();
            this.txtJaveHome.Text = regEnvironment.GetValue("JAVA_HOME", "").ToString();
            this.txtM2Home.Text = regEnvironment.GetValue("M2_HOME", "").ToString();
            this.txtCatalinaHome.Text = regEnvironment.GetValue("catalina_home", "").ToString();
            regEnvironment.Close();
            regManager.Close();
            regControl.Close();
            regControlSet001.Close();
            regSYSTEM.Close();
            regLocalMachine.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            RegistryKey regLocalMachine = Registry.LocalMachine;
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//打开HKEY_LOCAL_MACHINE下的SYSTEM
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//打开ControlSet001
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//打开Control
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//打开Control 
            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);//打开MSSQLServer下的MSSQLServer
            regEnvironment.SetValue("path", this.txtPath.Text.Trim());//设置path的值 
            regEnvironment.SetValue("CLASSPATH", this.txtClassPath.Text.Trim());//设置CLASSPATH的值 
            regEnvironment.SetValue("JAVA_HOME", this.txtJaveHome.Text.Trim());//设置JAVA_HOME的值 
            regEnvironment.SetValue("M2_HOME", this.txtM2Home.Text.Trim());//设置M2_HOME的值 
            regEnvironment.SetValue("catalina_home", this.txtCatalinaHome.Text.Trim());//设置catalina_home的值
            regEnvironment.Close();
            regManager.Close();
            regControl.Close();
            regControlSet001.Close();
            regSYSTEM.Close();
            regLocalMachine.Close();
            loader.SaveConfig();
            SystemDefine.ModifySystemEnvPath();
            MessageBoxHelper.Show("修改成功！");
            
            
        }
    }
}