namespace PDA
{
    partial class PickDetail
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
            this.txt_XiaXiangJi = new System.Windows.Forms.TextBox();
            this.cb_Rollback = new System.Windows.Forms.CheckBox();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_SN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_XiaXiangJi = new System.Windows.Forms.CheckBox();
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
            // txt_XiaXiangJi
            // 
            this.txt_XiaXiangJi.Enabled = false;
            this.txt_XiaXiangJi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_XiaXiangJi.Location = new System.Drawing.Point(91, 10);
            this.txt_XiaXiangJi.Name = "txt_XiaXiangJi";
            this.txt_XiaXiangJi.Size = new System.Drawing.Size(137, 21);
            this.txt_XiaXiangJi.TabIndex = 0;
            this.txt_XiaXiangJi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_XiaXiangJi_KeyUp);
            // 
            // cb_Rollback
            // 
            this.cb_Rollback.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Rollback.ForeColor = System.Drawing.Color.Red;
            this.cb_Rollback.Location = new System.Drawing.Point(85, 65);
            this.cb_Rollback.Name = "cb_Rollback";
            this.cb_Rollback.Size = new System.Drawing.Size(146, 20);
            this.cb_Rollback.TabIndex = 2;
            this.cb_Rollback.Text = "撤销产品扫描";
            this.cb_Rollback.CheckStateChanged += new System.EventHandler(this.cb_Rollback_CheckStateChanged);
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(13, 242);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(72, 22);
            this.btn_TempSave.TabIndex = 4;
            this.btn_TempSave.Text = "临时保存";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Beige;
            this.btn_Save.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Save.Location = new System.Drawing.Point(170, 242);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(55, 22);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "提交";
            // 
            // txt_SN
            // 
            this.txt_SN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_SN.Location = new System.Drawing.Point(91, 36);
            this.txt_SN.Name = "txt_SN";
            this.txt_SN.Size = new System.Drawing.Size(137, 21);
            this.txt_SN.TabIndex = 1;
            this.txt_SN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SN_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.Text = "S/N:";
            // 
            // cb_XiaXiangJi
            // 
            this.cb_XiaXiangJi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_XiaXiangJi.Location = new System.Drawing.Point(6, 10);
            this.cb_XiaXiangJi.Name = "cb_XiaXiangJi";
            this.cb_XiaXiangJi.Size = new System.Drawing.Size(88, 20);
            this.cb_XiaXiangJi.TabIndex = 41;
            this.cb_XiaXiangJi.Text = "下乡机：";
            this.cb_XiaXiangJi.CheckStateChanged += new System.EventHandler(this.cb_XiaXiangJi_CheckStateChanged);
            this.cb_XiaXiangJi.Click += new System.EventHandler(this.cb_XiaXiangJi_CheckStateChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(225, 141);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            this.txt_DiskDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
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
            this.dg_Resume.RowHeadersVisible = false;
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
            this.dg_Summarizing.RowHeadersVisible = false;
            this.dg_Summarizing.Location = new System.Drawing.Point(4, 4);
            this.dg_Summarizing.Name = "dg_Summarizing";
            this.dg_Summarizing.Size = new System.Drawing.Size(210, 105);
            this.dg_Summarizing.TabIndex = 0;
            // 
            // PickDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txt_SN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.cb_Rollback);
            this.Controls.Add(this.txt_XiaXiangJi);
            this.Controls.Add(this.cb_XiaXiangJi);
            this.Name = "PickDetail";
            this.Text = "无托发货";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_XiaXiangJi;
        private System.Windows.Forms.CheckBox cb_Rollback;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_SN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_XiaXiangJi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_DiskDetail;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGrid dg_Resume;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGrid dg_Summarizing;
    }
}