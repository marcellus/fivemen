using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace PDA.DataInit
{
    public partial class CreateTablesForm : Form
    {
        public CreateTablesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ExecuteFiles("ddl.sql");
        }

        private void ExecuteFiles(string filename)
        {

            string[] sqls = this.ReadSqls(filename);
            MessageBox.Show("获取了" + sqls.Length + "条语句！");
            int i = SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sqls);
            MessageBox.Show("成功执行了" + i + "条语句！");
        }

        private String[] ReadSqls(string filename)
        {
            string result = String.Empty;
            filename = Path.GetDirectoryName(Assembly.Load(Assembly.GetExecutingAssembly().GetName()).GetName().CodeBase) + "\\" + filename;
            try
            {
                //读取INI文件；
                System.IO.StreamReader iniFile = new System.IO.StreamReader(filename, System.Text.Encoding.Default);
                result = iniFile.ReadToEnd();
                iniFile.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                
            }
            return result.Split(';');

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ExecuteFiles("drop-ddl.sql");
            
        }
    }
}