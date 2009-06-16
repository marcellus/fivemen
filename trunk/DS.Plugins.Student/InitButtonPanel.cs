using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Cache;

namespace DS.Plugins.Student
{
    public partial class InitButtonPanel : UserControl
    {
        public InitButtonPanel()
        {
            InitializeComponent();

            StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
            if (config.SubjectIs4)
            {
                this.btnSubject2.Visible = false;
                this.btnSubject20.Visible = true;
                this.btnSubject21.Visible = true;
                this.btnSubject20.Click += new EventHandler(StudentHelper.subject20_Click);
                this.btnSubject21.Click += new EventHandler(StudentHelper.subject21_Click);
            }
            else
            {
                this.btnSubject2.Visible = true;
                this.btnSubject2.Click += new EventHandler(StudentHelper.subject2_Click);
                this.btnSubject20.Visible = false;
                this.btnSubject21.Visible = false;
            }
            this.btnSubject1.Click += new EventHandler(StudentHelper.subject1_Click);
            this.btnSubject3.Click += new EventHandler(StudentHelper.subject3_Click);

            this.btnChangePwd.Click += new EventHandler(btnChangePwd_Click);
            this.btnExitSystem.Click += new EventHandler(btnExitSystem_Click);
            this.btnLockSystem.Click += new EventHandler(btnLockSystem_Click);

            this.btnReg.Click += new EventHandler(btnReg_Click);
            this.btnPhoto.Click += new EventHandler(btnPhoto_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.btnFee.Click += new EventHandler(btnFee_Click);

            this.btnApplyF6.Click += new EventHandler(StudentHelper.F6_Click);
            this.btnApplyF7.Click += new EventHandler(StudentHelper.F7_Click);

            this.btnExamHint.Click += new EventHandler(btnExamHint_Click);
            

        }

        void btnExamHint_Click(object sender, EventArgs e)
        {
            FormHelper.PopControlForm(typeof(BaoMinReport), "考试提醒");
        }

        void btnFee_Click(object sender, EventArgs e)
        {
            FormHelper.PopDialogForm(typeof(StudentFeeBrowser));
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            FormHelper.PopDialogForm(typeof(UpdateForm));
        }

        void btnPhoto_Click(object sender, EventArgs e)
        {
            FormHelper.PopDialogForm(typeof(DriverPicCapture));
        }

        void btnReg_Click(object sender, EventArgs e)
        {
            FormHelper.PopDialogForm(typeof(StudentBrowser));
        }

        void btnLockSystem_Click(object sender, EventArgs e)
        {
            FormHelper.PopDialogForm(typeof(FT.Windows.Forms.LockSystemForm));
        }

        void btnExitSystem_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Confirm("确定退出本系统吗？"))
            {
                Application.Exit();
            }
        }

        void btnChangePwd_Click(object sender, EventArgs e)
        {
            FormHelper.PopDialogForm(typeof(FT.Windows.Forms.PwdChangeForm));
        }
    }
}
