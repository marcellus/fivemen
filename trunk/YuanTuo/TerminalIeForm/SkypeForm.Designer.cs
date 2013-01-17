namespace TerminalIeForm
{
    partial class SkypeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkypeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.Label();
            this.btnNum9 = new System.Windows.Forms.Button();
            this.btnNum6 = new System.Windows.Forms.Button();
            this.btnHandOff = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnNum0 = new System.Windows.Forms.Button();
            this.btnNum8 = new System.Windows.Forms.Button();
            this.btnDial = new System.Windows.Forms.Button();
            this.btnNum5 = new System.Windows.Forms.Button();
            this.btnNum7 = new System.Windows.Forms.Button();
            this.btnNum4 = new System.Windows.Forms.Button();
            this.btnNum3 = new System.Windows.Forms.Button();
            this.btnNum2 = new System.Windows.Forms.Button();
            this.btnNum1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入要拨号的号码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "（免费通话时长为：3分钟）";
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.txtMobile.ForeColor = System.Drawing.Color.CadetBlue;
            this.txtMobile.Image = global::TerminalIeForm.Properties.Resources.mobileinput;
            this.txtMobile.Location = new System.Drawing.Point(24, 81);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(350, 70);
            this.txtMobile.TabIndex = 0;
            this.txtMobile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNum9
            // 
            this.btnNum9.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum9.Image = ((System.Drawing.Image)(resources.GetObject("btnNum9.Image")));
            this.btnNum9.Location = new System.Drawing.Point(28, 291);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(75, 61);
            this.btnNum9.TabIndex = 0;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = true;
            this.btnNum9.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum9.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum9.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum6
            // 
            this.btnNum6.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum6.Image = ((System.Drawing.Image)(resources.GetObject("btnNum6.Image")));
            this.btnNum6.Location = new System.Drawing.Point(117, 224);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(75, 61);
            this.btnNum6.TabIndex = 0;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = true;
            this.btnNum6.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum6.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum6.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnHandOff
            // 
            this.btnHandOff.Font = new System.Drawing.Font("楷体", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHandOff.Image = ((System.Drawing.Image)(resources.GetObject("btnHandOff.Image")));
            this.btnHandOff.Location = new System.Drawing.Point(206, 358);
            this.btnHandOff.Name = "btnHandOff";
            this.btnHandOff.Size = new System.Drawing.Size(164, 61);
            this.btnHandOff.TabIndex = 0;
            this.btnHandOff.Text = "挂  断";
            this.btnHandOff.UseVisualStyleBackColor = true;
            this.btnHandOff.MouseLeave += new System.EventHandler(this.btnReset_MouseLeave);
            this.btnHandOff.Click += new System.EventHandler(this.btnHandOff_Click);
            this.btnHandOff.MouseEnter += new System.EventHandler(this.btnReset_MouseEnter);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("楷体", 28F, System.Drawing.FontStyle.Bold);
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(206, 291);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(164, 61);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "删  除";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.MouseLeave += new System.EventHandler(this.btnReset_MouseLeave);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseEnter += new System.EventHandler(this.btnReset_MouseEnter);
            // 
            // btnNum0
            // 
            this.btnNum0.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum0.Image = ((System.Drawing.Image)(resources.GetObject("btnNum0.Image")));
            this.btnNum0.Location = new System.Drawing.Point(117, 291);
            this.btnNum0.Name = "btnNum0";
            this.btnNum0.Size = new System.Drawing.Size(75, 61);
            this.btnNum0.TabIndex = 0;
            this.btnNum0.Text = "0";
            this.btnNum0.UseVisualStyleBackColor = true;
            this.btnNum0.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum0.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum0.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum8
            // 
            this.btnNum8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum8.Image = ((System.Drawing.Image)(resources.GetObject("btnNum8.Image")));
            this.btnNum8.Location = new System.Drawing.Point(295, 224);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(75, 61);
            this.btnNum8.TabIndex = 0;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = true;
            this.btnNum8.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum8.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum8.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnDial
            // 
            this.btnDial.Font = new System.Drawing.Font("楷体", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDial.Image = ((System.Drawing.Image)(resources.GetObject("btnDial.Image")));
            this.btnDial.Location = new System.Drawing.Point(28, 358);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(164, 61);
            this.btnDial.TabIndex = 0;
            this.btnDial.Text = "拨  号";
            this.btnDial.UseVisualStyleBackColor = true;
            this.btnDial.MouseLeave += new System.EventHandler(this.btnReset_MouseLeave);
            this.btnDial.Click += new System.EventHandler(this.btnDial_Click);
            this.btnDial.MouseEnter += new System.EventHandler(this.btnReset_MouseEnter);
            // 
            // btnNum5
            // 
            this.btnNum5.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum5.Image = ((System.Drawing.Image)(resources.GetObject("btnNum5.Image")));
            this.btnNum5.Location = new System.Drawing.Point(28, 224);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(75, 61);
            this.btnNum5.TabIndex = 0;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = true;
            this.btnNum5.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum5.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum5.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum7
            // 
            this.btnNum7.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum7.Image = ((System.Drawing.Image)(resources.GetObject("btnNum7.Image")));
            this.btnNum7.Location = new System.Drawing.Point(206, 224);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(75, 61);
            this.btnNum7.TabIndex = 0;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = true;
            this.btnNum7.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum7.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum7.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum4
            // 
            this.btnNum4.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum4.Image = ((System.Drawing.Image)(resources.GetObject("btnNum4.Image")));
            this.btnNum4.Location = new System.Drawing.Point(295, 158);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(75, 61);
            this.btnNum4.TabIndex = 0;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = true;
            this.btnNum4.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum4.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum4.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum3
            // 
            this.btnNum3.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum3.Image = ((System.Drawing.Image)(resources.GetObject("btnNum3.Image")));
            this.btnNum3.Location = new System.Drawing.Point(206, 157);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(75, 61);
            this.btnNum3.TabIndex = 0;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = true;
            this.btnNum3.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum3.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum3.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum2
            // 
            this.btnNum2.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum2.Image = ((System.Drawing.Image)(resources.GetObject("btnNum2.Image")));
            this.btnNum2.Location = new System.Drawing.Point(117, 157);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(75, 61);
            this.btnNum2.TabIndex = 0;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = true;
            this.btnNum2.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum2.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum2.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // btnNum1
            // 
            this.btnNum1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnNum1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNum1.Image = global::TerminalIeForm.Properties.Resources.defaultbtnbg;
            this.btnNum1.Location = new System.Drawing.Point(28, 157);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(75, 61);
            this.btnNum1.TabIndex = 0;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = true;
            this.btnNum1.MouseLeave += new System.EventHandler(this.btnNum1_MouseLeave);
            this.btnNum1.Click += new System.EventHandler(this.btnNum1_Click);
            this.btnNum1.MouseEnter += new System.EventHandler(this.btnNum1_MouseEnter);
            // 
            // SkypeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(393, 431);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNum9);
            this.Controls.Add(this.btnNum6);
            this.Controls.Add(this.btnHandOff);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnNum0);
            this.Controls.Add(this.btnNum8);
            this.Controls.Add(this.btnDial);
            this.Controls.Add(this.btnNum5);
            this.Controls.Add(this.btnNum7);
            this.Controls.Add(this.btnNum4);
            this.Controls.Add(this.btnNum3);
            this.Controls.Add(this.btnNum2);
            this.Controls.Add(this.btnNum1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SkypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkypeForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SkypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNum1;
        private System.Windows.Forms.Button btnNum2;
        private System.Windows.Forms.Button btnNum3;
        private System.Windows.Forms.Button btnNum4;
        private System.Windows.Forms.Button btnNum5;
        private System.Windows.Forms.Button btnNum6;
        private System.Windows.Forms.Button btnNum7;
        private System.Windows.Forms.Button btnNum8;
        private System.Windows.Forms.Button btnNum9;
        private System.Windows.Forms.Button btnNum0;
        private System.Windows.Forms.Button btnDial;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHandOff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtMobile;
    }
}