using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using FT.Commons.Tools;

namespace FT.Test
{
    public partial class ReflectTestForm : Form
    {
        public ReflectTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.txtTimes.Text.Trim());
            Assembly ass = null;
            for (int i = 0; i < num; i++)
            {
                ass=Assembly.LoadFrom(ReflectHelper.GetStartUpPath("plugins\\FT.Lottery.dll"));
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReflectHelper.ShowAllAssembly();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object obj = ReflectHelper.CreateInstance("FT.Lottery.LotteryPersonalResult");
            Console.WriteLine("创建反射Assembly中类型的结果为："+obj);
        }
    }
}