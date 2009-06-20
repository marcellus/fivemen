using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Exam
{
    public partial class ExamPolicySetting : Form
    {
       ConfigLoader<ExamPolicy> loader = null;
        public ExamPolicySetting()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<ExamPolicy>(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æ³É¹¦£¡");
        }
    }
}