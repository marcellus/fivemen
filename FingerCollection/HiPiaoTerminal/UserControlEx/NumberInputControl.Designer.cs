namespace HiPiaoTerminal.UserControlEx
{
    partial class NumberInputControl
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
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.PictureBox();
            this.btnUp = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNum.Font = new System.Drawing.Font("方正兰亭黑简体", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNum.Location = new System.Drawing.Point(10, 6);
            this.txtNum.Margin = new System.Windows.Forms.Padding(10);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(115, 69);
            this.txtNum.TabIndex = 0;
            this.txtNum.Text = "0";
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Down;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.Location = new System.Drawing.Point(137, 42);
            this.btnDown.Margin = new System.Windows.Forms.Padding(10);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(44, 44);
            this.btnDown.TabIndex = 1;
            this.btnDown.TabStop = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Up;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Location = new System.Drawing.Point(137, -1);
            this.btnUp.Margin = new System.Windows.Forms.Padding(10);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(44, 44);
            this.btnUp.TabIndex = 1;
            this.btnUp.TabStop = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.TimeBack;
            this.panel1.Controls.Add(this.txtNum);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 87);
            this.panel1.TabIndex = 2;
            // 
            // NumberInputControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Font = new System.Drawing.Font("宋体", 29F);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "NumberInputControl";
            this.Size = new System.Drawing.Size(184, 92);
            ((System.ComponentModel.ISupportInitialize)(this.btnDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.PictureBox btnUp;
        private System.Windows.Forms.PictureBox btnDown;
        private System.Windows.Forms.Panel panel1;
    }
}
