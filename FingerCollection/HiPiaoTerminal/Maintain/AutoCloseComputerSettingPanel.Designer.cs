namespace HiPiaoTerminal.Maintain
{
    partial class AutoCloseComputerSettingPanel
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
            this.cbAllowAutoCloseComputer = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHour = new HiPiaoTerminal.UserControlEx.NumberInputControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinutes = new HiPiaoTerminal.UserControlEx.NumberInputControl();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // cbAllowAutoCloseComputer
            // 
            this.cbAllowAutoCloseComputer.AutoSize = true;
            this.cbAllowAutoCloseComputer.Font = new System.Drawing.Font("宋体", 27F);
            this.cbAllowAutoCloseComputer.Location = new System.Drawing.Point(3, 251);
            this.cbAllowAutoCloseComputer.Name = "cbAllowAutoCloseComputer";
            this.cbAllowAutoCloseComputer.Size = new System.Drawing.Size(322, 40);
            this.cbAllowAutoCloseComputer.TabIndex = 4;
            this.cbAllowAutoCloseComputer.Text = "打开定时关机功能";
            this.cbAllowAutoCloseComputer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 27F);
            this.label1.Location = new System.Drawing.Point(0, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "关机时间：";
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.SystemColors.Window;
            this.txtHour.Font = new System.Drawing.Font("宋体", 29F);
            this.txtHour.Location = new System.Drawing.Point(176, 332);
            this.txtHour.Margin = new System.Windows.Forms.Padding(10);
            this.txtHour.MaxNum = 24;
            this.txtHour.MinNum = 0;
            this.txtHour.MinNumPadLen = 1;
            this.txtHour.Name = "txtHour";
            this.txtHour.Number = 1;
            this.txtHour.Size = new System.Drawing.Size(129, 69);
            this.txtHour.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "点";
            // 
            // txtMinutes
            // 
            this.txtMinutes.BackColor = System.Drawing.SystemColors.Window;
            this.txtMinutes.Font = new System.Drawing.Font("宋体", 29F);
            this.txtMinutes.Location = new System.Drawing.Point(350, 332);
            this.txtMinutes.Margin = new System.Windows.Forms.Padding(10);
            this.txtMinutes.MaxNum = 60;
            this.txtMinutes.MinNum = 0;
            this.txtMinutes.MinNumPadLen = 2;
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(129, 69);
            this.txtMinutes.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "分";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 75);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存修改";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(242, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(188, 75);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消修改";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(561, 251);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(531, 583);
            this.webBrowser1.TabIndex = 9;
            // 
            // AutoCloseComputerSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAllowAutoCloseComputer);
            this.Name = "AutoCloseComputerSettingPanel";
            this.Load += new System.EventHandler(this.AutoCloseComputerSettingPanel_Load);
            this.Controls.SetChildIndex(this.cbAllowAutoCloseComputer, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtHour, 0);
            this.Controls.SetChildIndex(this.txtMinutes, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.webBrowser1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAllowAutoCloseComputer;
        private System.Windows.Forms.Label label1;
        private HiPiaoTerminal.UserControlEx.NumberInputControl txtHour;
        private System.Windows.Forms.Label label2;
        private HiPiaoTerminal.UserControlEx.NumberInputControl txtMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
