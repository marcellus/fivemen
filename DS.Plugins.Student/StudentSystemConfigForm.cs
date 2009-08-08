using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;


namespace DS.Plugins.Student
{
    public partial class StudentSystemConfigForm : BaseSkinForm
    {
        ConfigLoader<StudentSystemConfig> loader = null;
        public StudentSystemConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<StudentSystemConfig>(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æ³É¹¦£¡");
        }
    }
}