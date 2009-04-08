using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Commons.Bar
{
    public partial class BarReaderConfigForm : Form
    {
        ConfigLoader<BarReaderConfig> loader = null;
        public BarReaderConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<BarReaderConfig>(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("保存成功！");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SimpleBarReader reader = new SimpleBarReader();
            if (reader.StartWatching())
            {
                MessageBoxHelper.Show("测试成功！");
                reader.StopWatching();
            }
            else
            {
                MessageBoxHelper.Show("测试失败！");
            }
        }
    }
}