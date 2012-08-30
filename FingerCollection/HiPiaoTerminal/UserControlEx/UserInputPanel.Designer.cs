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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.picUnderLine = new System.Windows.Forms.PictureBox();
            this.txtMain = new FT.Windows.Controls.TextBoxEx.HintTextBox();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUnderLine)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Gray_Right;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(235, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 74);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Gray_Left;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 74);
            this.panel1.TabIndex = 3;
            // 
            // panelCenter
            // 
            this.panelCenter.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Gray_Center;
            this.panelCenter.Controls.Add(this.picUnderLine);
            this.panelCenter.Controls.Add(this.txtMain);
            this.panelCenter.Location = new System.Drawing.Point(14, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(221, 74);
            this.panelCenter.TabIndex = 2;
            // 
            // picUnderLine
            // 
            this.picUnderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.picUnderLine.Location = new System.Drawing.Point(9, 66);
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
            this.txtMain.Location = new System.Drawing.Point(9, 20);
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
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCenter);
            this.Font = new System.Drawing.Font("宋体", 21F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserInputPanel";
            this.Size = new System.Drawing.Size(249, 74);
            this.Load += new System.EventHandler(this.UserInputPanel_Load);
            this.Leave += new System.EventHandler(this.UserInputPanel_Leave);
            this.Resize += new System.EventHandler(this.UserInputPanel_Resize);
            this.Enter += new System.EventHandler(this.UserInputPanel_Enter);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUnderLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private FT.Windows.Controls.TextBoxEx.HintTextBox txtMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picUnderLine;
    }
}
