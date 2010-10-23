namespace PDA
{
    partial class AsnDetailScanHadTray
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TrayNo = new System.Windows.Forms.TextBox();
            this.ck_Rollback = new System.Windows.Forms.CheckBox();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.ck_HOLD = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_DiskDetail = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dg_Resume = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dg_Summarizing = new System.Windows.Forms.DataGrid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.Text = "托盘号：";
            // 
            // txt_TrayNo
            // 
            this.txt_TrayNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_TrayNo.Location = new System.Drawing.Point(91, 15);
            this.txt_TrayNo.Name = "txt_TrayNo";
            this.txt_TrayNo.Size = new System.Drawing.Size(134, 21);
            this.txt_TrayNo.TabIndex = 1;
            this.txt_TrayNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TrayNo_KeyUp);
            // 
            // ck_Rollback
            // 
            this.ck_Rollback.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.ck_Rollback.ForeColor = System.Drawing.Color.Red;
            this.ck_Rollback.Location = new System.Drawing.Point(91, 54);
            this.ck_Rollback.Name = "ck_Rollback";
            this.ck_Rollback.Size = new System.Drawing.Size(111, 20);
            this.ck_Rollback.TabIndex = 3;
            this.ck_Rollback.Text = "撤销产品扫描";
            this.ck_Rollback.CheckStateChanged += new System.EventHandler(this.ck_Rollback_CheckStateChanged);
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(10, 240);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(75, 25);
            this.btn_TempSave.TabIndex = 5;
            this.btn_TempSave.Text = "临时保存";
            // 
            // btn_Finish
            // 
            this.btn_Finish.BackColor = System.Drawing.Color.Beige;
            this.btn_Finish.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Finish.Location = new System.Drawing.Point(150, 242);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(75, 25);
            this.btn_Finish.TabIndex = 6;
            this.btn_Finish.Text = "提交";
            // 
            // ck_HOLD
            // 
            this.ck_HOLD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.ck_HOLD.Location = new System.Drawing.Point(11, 54);
            this.ck_HOLD.Name = "ck_HOLD";
            this.ck_HOLD.Size = new System.Drawing.Size(59, 20);
            this.ck_HOLD.TabIndex = 2;
            this.ck_HOLD.Text = "HOLD";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(225, 141);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_DiskDetail);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(217, 112);
            this.tabPage1.Text = "扫描";
            // 
            // txt_DiskDetail
            // 
            this.txt_DiskDetail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_DiskDetail.ForeColor = System.Drawing.Color.Black;
            this.txt_DiskDetail.Location = new System.Drawing.Point(3, 3);
            this.txt_DiskDetail.Multiline = true;
            this.txt_DiskDetail.Name = "txt_DiskDetail";
            this.txt_DiskDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_DiskDetail.Size = new System.Drawing.Size(211, 106);
            this.txt_DiskDetail.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dg_Resume);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(217, 112);
            this.tabPage2.Text = "履历";
            // 
            // dg_Resume
            // 
            this.dg_Resume.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_Resume.ColumnHeadersVisible = false;
            this.dg_Resume.Location = new System.Drawing.Point(4, 4);
            this.dg_Resume.Name = "dg_Resume";
            this.dg_Resume.Size = new System.Drawing.Size(210, 105);
            this.dg_Resume.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dg_Summarizing);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(217, 112);
            this.tabPage3.Text = "汇总";
            // 
            // dg_Summarizing
            // 
            this.dg_Summarizing.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_Summarizing.ColumnHeadersVisible = false;
            this.dg_Summarizing.Location = new System.Drawing.Point(4, 4);
            this.dg_Summarizing.Name = "dg_Summarizing";
            this.dg_Summarizing.Size = new System.Drawing.Size(210, 105);
            this.dg_Summarizing.TabIndex = 0;
            // 
            // AsnDetailScanHadTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ck_HOLD);
            this.Controls.Add(this.btn_Finish);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.ck_Rollback);
            this.Controls.Add(this.txt_TrayNo);
            this.Controls.Add(this.label2);
            this.Name = "AsnDetailScanHadTray";
            this.Text = "有托收货";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TrayNo;
        private System.Windows.Forms.CheckBox ck_Rollback;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.CheckBox ck_HOLD;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_DiskDetail;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGrid dg_Resume;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGrid dg_Summarizing;
    }
}