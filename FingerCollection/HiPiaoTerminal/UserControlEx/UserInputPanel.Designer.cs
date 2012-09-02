namespace HiPiaoTerminal.UserControlEx
{
    partial class UserInputPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCenter = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.panelRightCenterBorder = new System.Windows.Forms.Panel();
            this.panelLeftCenterBorder = new System.Windows.Forms.Panel();
            this.panelMainBottomBorder = new System.Windows.Forms.Panel();
            this.panelLeftBottonBorder = new System.Windows.Forms.Panel();
            this.panelMainTopBorder = new System.Windows.Forms.Panel();
            this.panelRightBottonBorder = new System.Windows.Forms.Panel();
            this.panelRightTopBorder = new System.Windows.Forms.Panel();
            this.panelLeftTopBorder = new System.Windows.Forms.Panel();
            this.picUnderLine = new System.Windows.Forms.PictureBox();
            this.txtMain = new FT.Windows.Controls.TextBoxEx.HintTextBox();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnderLine)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.picUnderLine);
            this.panelCenter.Controls.Add(this.txtMain);
            this.panelCenter.Location = new System.Drawing.Point(14, 14);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(221, 68);
            this.panelCenter.TabIndex = 2;
            this.panelCenter.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelCenter.Resize += new System.EventHandler(this.panelCenter_Resize);
            this.panelCenter.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(123, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 45);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelRightCenterBorder
            // 
            this.panelRightCenterBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Right_Center_NotActive;
            this.panelRightCenterBorder.Location = new System.Drawing.Point(235, 14);
            this.panelRightCenterBorder.Name = "panelRightCenterBorder";
            this.panelRightCenterBorder.Size = new System.Drawing.Size(14, 70);
            this.panelRightCenterBorder.TabIndex = 5;
            this.panelRightCenterBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelRightCenterBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // panelLeftCenterBorder
            // 
            this.panelLeftCenterBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Left_Center_NotActive;
            this.panelLeftCenterBorder.Location = new System.Drawing.Point(0, 14);
            this.panelLeftCenterBorder.Name = "panelLeftCenterBorder";
            this.panelLeftCenterBorder.Size = new System.Drawing.Size(14, 70);
            this.panelLeftCenterBorder.TabIndex = 5;
            this.panelLeftCenterBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelLeftCenterBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // panelMainBottomBorder
            // 
            this.panelMainBottomBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_MainBottom_NotActive;
            this.panelMainBottomBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMainBottomBorder.Location = new System.Drawing.Point(14, 84);
            this.panelMainBottomBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainBottomBorder.Name = "panelMainBottomBorder";
            this.panelMainBottomBorder.Size = new System.Drawing.Size(221, 14);
            this.panelMainBottomBorder.TabIndex = 3;
            this.panelMainBottomBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelMainBottomBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // panelLeftBottonBorder
            // 
            this.panelLeftBottonBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Left_Bottom_NotActive;
            this.panelLeftBottonBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLeftBottonBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelLeftBottonBorder.Location = new System.Drawing.Point(0, 84);
            this.panelLeftBottonBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeftBottonBorder.Name = "panelLeftBottonBorder";
            this.panelLeftBottonBorder.Size = new System.Drawing.Size(14, 14);
            this.panelLeftBottonBorder.TabIndex = 3;
            this.panelLeftBottonBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelLeftBottonBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // panelMainTopBorder
            // 
            this.panelMainTopBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_MainTop_NotActive;
            this.panelMainTopBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMainTopBorder.Location = new System.Drawing.Point(14, 0);
            this.panelMainTopBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainTopBorder.Name = "panelMainTopBorder";
            this.panelMainTopBorder.Size = new System.Drawing.Size(221, 16);
            this.panelMainTopBorder.TabIndex = 3;
            this.panelMainTopBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelMainTopBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            this.panelMainTopBorder.MouseEnter += new System.EventHandler(this.panelMainTopBorder_MouseEnter);
            // 
            // panelRightBottonBorder
            // 
            this.panelRightBottonBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Right_Bottom_NotActive;
            this.panelRightBottonBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelRightBottonBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelRightBottonBorder.Location = new System.Drawing.Point(235, 84);
            this.panelRightBottonBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelRightBottonBorder.Name = "panelRightBottonBorder";
            this.panelRightBottonBorder.Size = new System.Drawing.Size(14, 14);
            this.panelRightBottonBorder.TabIndex = 3;
            this.panelRightBottonBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelRightBottonBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // panelRightTopBorder
            // 
            this.panelRightTopBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Right_Top_NotActive;
            this.panelRightTopBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelRightTopBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelRightTopBorder.Location = new System.Drawing.Point(235, 0);
            this.panelRightTopBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelRightTopBorder.Name = "panelRightTopBorder";
            this.panelRightTopBorder.Size = new System.Drawing.Size(14, 14);
            this.panelRightTopBorder.TabIndex = 3;
            this.panelRightTopBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelRightTopBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // panelLeftTopBorder
            // 
            this.panelLeftTopBorder.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.UserInput_Left_Top_NotActive;
            this.panelLeftTopBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLeftTopBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelLeftTopBorder.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTopBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeftTopBorder.Name = "panelLeftTopBorder";
            this.panelLeftTopBorder.Size = new System.Drawing.Size(14, 14);
            this.panelLeftTopBorder.TabIndex = 3;
            this.panelLeftTopBorder.Leave += new System.EventHandler(this.panelMainBottomBorder_Leave);
            this.panelLeftTopBorder.Enter += new System.EventHandler(this.panelMainBottomBorder_Enter);
            // 
            // picUnderLine
            // 
            this.picUnderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.picUnderLine.Location = new System.Drawing.Point(9, 61);
            this.picUnderLine.Name = "picUnderLine";
            this.picUnderLine.Size = new System.Drawing.Size(18, 2);
            this.picUnderLine.TabIndex = 1;
            this.picUnderLine.TabStop = false;
            this.picUnderLine.Visible = false;
            // 
            // txtMain
            // 
            this.txtMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMain.Font = new System.Drawing.Font("方正兰亭黑简体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.txtMain.Hint = null;
            this.txtMain.Location = new System.Drawing.Point(9, 16);
            this.txtMain.Margin = new System.Windows.Forms.Padding(0);
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(198, 43);
            this.txtMain.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.txtMain.TabIndex = 0;
            this.txtMain.TempPasswordChar = '\0';
            this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged_1);
            this.txtMain.Click += new System.EventHandler(this.txtMain_Click);
            this.txtMain.Enter += new System.EventHandler(this.txtMain_Enter);
            // 
            // UserInputPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panelRightCenterBorder);
            this.Controls.Add(this.panelLeftCenterBorder);
            this.Controls.Add(this.panelMainBottomBorder);
            this.Controls.Add(this.panelLeftBottonBorder);
            this.Controls.Add(this.panelMainTopBorder);
            this.Controls.Add(this.panelRightBottonBorder);
            this.Controls.Add(this.panelRightTopBorder);
            this.Controls.Add(this.panelLeftTopBorder);
            this.Controls.Add(this.panelCenter);
            this.Font = new System.Drawing.Font("宋体", 21F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserInputPanel";
            this.Size = new System.Drawing.Size(249, 181);
            this.Load += new System.EventHandler(this.UserInputPanel_Load);
            this.Leave += new System.EventHandler(this.UserInputPanel_Leave);
            this.Resize += new System.EventHandler(this.UserInputPanel_Resize);
            this.Enter += new System.EventHandler(this.UserInputPanel_Enter);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnderLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private FT.Windows.Controls.TextBoxEx.HintTextBox txtMain;
        private System.Windows.Forms.Panel panelLeftTopBorder;
        private System.Windows.Forms.PictureBox picUnderLine;
        private System.Windows.Forms.Panel panelLeftCenterBorder;
        private System.Windows.Forms.Panel panelLeftBottonBorder;
        private System.Windows.Forms.Panel panelMainTopBorder;
        private System.Windows.Forms.Panel panelRightTopBorder;
        private System.Windows.Forms.Panel panelRightBottonBorder;
        private System.Windows.Forms.Panel panelRightCenterBorder;
        private System.Windows.Forms.Panel panelMainBottomBorder;
        private System.Windows.Forms.PictureBox btnDelete;
    }
}
