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
        /// 套打-全部6张(F1)
        /// 套打-机动车驾驶培训记录*3(F2)(完成)
        /// 套打-机动车驾驶人身体条件证明(F3)(开发区完成)
        /// 套打-机动车驾驶员培训学员登记表(F4)(完成)
        /// 套打-科目三考试成绩表(F5)(完成)
        /// 套打-机动车驾驶证申请表F6
        /// 直接打-驾驶证申请表F7
        /// 套打-结业证F8

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
                    printer = new ApplyPrinter(student);
                }
                else if (e.KeyCode == Keys.F7)
                {
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
            if (printSetting.PrintModel == "直接打")
            {
                commonPrinter.Print();
            }
            else if (printSetting.PrintModel == "选择打印机")
            {
                commonPrinter.ShowPreviewPrinter();
            }
            else
            {
                commonPrinter.Preview();
            }
        }

        private void AddSearch()
        {
           ToolStripTextBox txt= new System.Windows.Forms.ToolStripTextBox();
           txt.KeyDown += new KeyEventHandler(txt_KeyDown);
           txt.ToolTipText = "输入姓名按回车查询";
           this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt=sender as ToolStripTextBox;
                this.SetConditions(" c_name like '"+txt.Text.Trim()+"%'");
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
            this.CreateColumn("姓名", 80);
            this.CreateColumn("身份证明号码", 120);
            this.CreateColumn("性别", 80);
            this.CreateColumn("固话", 80);
            this.CreateColumn("手机", 80);
            this.CreateColumn("准教车型", 80);
            this.CreateColumn("号码号牌", 80);
            this.CreateColumn("教练证号", 100);
            this.CreateColumn("驾驶证编号");
        }*/

        private bool IsChecked()
        {
            return this.dataGridView1.SelectedRows.Count >0;
        }

        private void 套打全部4张F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i=this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer =new AllPrinter(student);
                this.Print(printer);
            }
        }

        private void 套打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F2Printer(student);
                this.Print(printer);
            }

        }

        private void 套打机动车驾驶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F3Printer(student);
                this.Print(printer);
            }

        }

        private void 套打机动车驾驶员培训学员登记表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F4Printer(student);
                this.Print(printer);
            }

        }

        private void 套打ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new F5Printer(student);
                this.Print(printer);
            }

        }

        private void 套打ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                BaseStudentPrinter printer = new ApplyPrinter(student);
                this.Print(printer);
            }

        }

        private void 直接打机动车驾驶证申请表F7需OfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                StudentInfo student = this.pager.Lists[i] as StudentInfo;
                ApplyExcelPrinter printer = new ApplyExcelPrinter(student);
                printer.PrintExcel(false);
                //this.Print(printer);
            }

        }

        private void 套打结业证明ToolStripMenuItem_Click(object sender, EventArgs e)
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

