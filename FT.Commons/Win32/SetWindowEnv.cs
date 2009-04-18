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
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//��HKEY_LOCAL_MACHINE�µ�SYSTEM
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//��ControlSet001
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//��Control
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//��Control 
            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);//��MSSQLServer�µ�MSSQLServer
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
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//��HKEY_LOCAL_MACHINE�µ�SYSTEM
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//��ControlSet001
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//��Control
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//��Control 
            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);//��MSSQLServer�µ�MSSQLServer
            regEnvironment.SetValue("path", this.txtPath.Text.Trim());//����path��ֵ 
            regEnvironment.SetValue("CLASSPATH", this.txtClassPath.Text.Trim());//����CLASSPATH��ֵ 
            regEnvironment.SetValue("JAVA_HOME", this.txtJaveHome.Text.Trim());//����JAVA_HOME��ֵ 
            regEnvironment.SetValue("M2_HOME", this.txtM2Home.Text.Trim());//����M2_HOME��ֵ 
            regEnvironment.SetValue("catalina_home", this.txtCatalinaHome.Text.Trim());//����catalina_home��ֵ
            regEnvironment.Close();
            regManager.Close();
            regControl.Close();
            regControlSet001.Close();
            regSYSTEM.Close();
            regLocalMachine.Close();
            loader.SaveConfig();
            SystemDefine.ModifySystemEnvPath();
            MessageBoxHelper.Show("�޸ĳɹ���");
            
            
        }
    }
}