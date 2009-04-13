using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Print;
using FT.Windows.Forms;
using FT.Commons.Cache;

namespace DS.Plugins.Student
{
    public partial class StudentSearch : FT.Windows.Forms.DataSearchControl
    {
        public StudentSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(StudentInfo);
            this.DetailFormType = typeof(StudentBrowser);
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);
            this.dataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseDown);
        }

        void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            //this.mouseClickRow = e.RowIndex;
        }

       // private int mouseClickRow = -1;

        /// <summary>
        /// ���ô�ӡ״̬ 
        /// </summary>
        /// <param name="student"></param>
        private void SetPrinted(StudentInfo student)
        {
            student.PrintedState = "�Ѵ�ӡ";
            FT.DAL.Orm.SimpleOrmOperator.Update(student);
        }

        /// <summary>
        /// �״�-ȫ��6��(F1)
        /// �״�-��������ʻ��ѵ��¼*3(F2)(���)
        /// �״�-��������ʻ����������֤��(F3)(���������)
        /// �״�-��������ʻԱ��ѵѧԱ�ǼǱ�(F4)(���)
        /// �״�-��Ŀ�����Գɼ���(F5)(���)
        /// �״�-��������ʻ֤�����F6
        /// ֱ�Ӵ�-��ʻ֤�����F7
        /// �״�-��ҵ֤F8
        /// 
        

        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int i=this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = null;
                if (e.KeyCode == Keys.F1)
                {
                    printer = new AllPrinter(student);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    printer = new F2Printer(student);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    printer = new F3Printer(student);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    printer = new F4Printer(student);

                }
                else if (e.KeyCode == Keys.F5)
                {
                    printer = new F5Printer(student);
                    //printer = new F5Printer(this.student);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    this.SetPrinted(student);
                    printer = new ApplyPrinter(student);
                }
                else if (e.KeyCode == Keys.F7)
                {
                    this.SetPrinted(student);
                    printer = new ApplyExcelPrinter(student);
                    ApplyExcelPrinter tmp = printer as ApplyExcelPrinter;
                    tmp.PrintExcel(false);
                    return;
                }
                else if (e.KeyCode == Keys.F8)
                {
                    printer = new F8Printer(student);
                }
                else if (e.KeyCode == Keys.F9)
                {
                    printer = new F9Printer(student);
                }
                if (printer != null)
                {
                    this.Print(printer);
                    //commonPrinter.ShowPreviewPrinter();
                }
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void Print(IPrinter printer)
        {
            CommonPrinter commonPrinter = new CommonPrinter(printer);
            //commonPrinter.ShowPreviewPrinter();
            GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
            if (printSetting.PrintModel == "ֱ�Ӵ�")
            {
                commonPrinter.Print();
            }
            else if (printSetting.PrintModel == "ѡ���ӡ��")
            {
                commonPrinter.ShowPreviewPrinter();
            }
            else
            {
                commonPrinter.Preview();
            }
        }
        private ToolStripComboBox cb;
        private ToolStripTextBox txt;
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("��ӡ״̬");
            cb = new ToolStripComboBox();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            //cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            cb.ToolTipText = "ѡ���ѯ�Ĵ�ӡ״̬";
            cb.Items.Add("��ѡ��");
            cb.Items.Add("δ��ӡ");
            cb.Items.Add("�Ѵ�ӡ");
            cb.SelectedIndex = 0;
            this.toolStrip1.Items.Add(cb);
            this.toolStrip1.Items.Add("����");
            txt= new System.Windows.Forms.ToolStripTextBox();
           txt.KeyDown += new KeyEventHandler(txt_KeyDown);
           txt.ToolTipText = "�����������س���ѯ";
           this.toolStrip1.Items.Add(txt);

          
          

        }
        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condition = " c_name like '" + txt.Text.Trim() + "%'";
            if (this.cb.SelectedIndex != 0)
            {
                condition += " and c_printed_state='" + this.cb.Text + "'";
            }
            this.SetConditions(condition);
        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string condition = " c_name like '" + txt.Text.Trim() + "%'";
                if (this.cb.SelectedIndex != 0)
                {
                    condition += " and c_printed_state='" + this.cb.Text + "'";
                }
                this.SetConditions(condition);
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(StudentInfo);
            this.pager.OrderField = "id";
        }
        /*
        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("���֤������", 120);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("׼�̳���", 80);
            this.CreateColumn("�������", 80);
            this.CreateColumn("����֤��", 100);
            this.CreateColumn("��ʻ֤���");
        }*/

        private bool IsChecked()
        {
            return this.dataGridView1.SelectedRows.Count >0;
        }

        private void �״�ȫ��4��F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i=this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer =new AllPrinter(student);
                this.Print(printer);
            }
        }

        private void �״�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F2Printer(student);
                this.Print(printer);
            }

        }

        private void �״��������ʻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F3Printer(student);
                this.Print(printer);
            }

        }

        private void �״��������ʻԱ��ѵѧԱ�ǼǱ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F4Printer(student);
                this.Print(printer);
            }

        }

        private void �״�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F5Printer(student);
                this.Print(printer);
            }

        }

        private void �״�ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                this.SetPrinted(student);
                BaseStudentPrinter printer = new ApplyPrinter(student);
                this.Print(printer);
            }

        }

        private void ֱ�Ӵ��������ʻ֤�����F7��OfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                this.SetPrinted(student);
                ApplyExcelPrinter printer = new ApplyExcelPrinter(student);
                printer.PrintExcel(false);
                //this.Print(printer);
            }

        }

        private void �״��ҵ֤��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F8Printer(student);
                this.Print(printer);
            }

        }
    }
}

