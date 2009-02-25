namespace FT.Test
{
    partial class TabControlExTest
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.simpleButton1 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.simpleTabControl1 = new FT.Windows.Controls.TabControlEx.SimpleTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.simpleTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 17);
            this.tabControl1.Location = new System.Drawing.Point(28, 255);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 60, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(192, 75);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "测试tabpage长度    94";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(192, 75);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(16, 204);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.UseVisualStyleBackColor = true;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleTabControl1
            // 
            this.simpleTabControl1.Controls.Add(this.tabPage1);
            this.simpleTabControl1.Controls.Add(this.tabPage2);
            this.simpleTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.simpleTabControl1.ItemSize = new System.Drawing.Size(80, 30);
            this.simpleTabControl1.Location = new System.Drawing.Point(12, 12);
            this.simpleTabControl1.Multiline = true;
            this.simpleTabControl1.Name = "simpleTabControl1";
            this.simpleTabControl1.SelectedIndex = 0;
            this.simpleTabControl1.Size = new System.Drawing.Size(365, 177);
            this.simpleTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.tabPage1.Size = new System.Drawing.Size(357, 139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(357, 139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2   ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TabControlExTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 404);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleTabControl1);
            this.Name = "TabControlExTest";
            this.Text = "TabControlExTest";
            this.Load += new System.EventHandler(this.TabControlExTest_Load);
            this.tabControl1.ResumeLayout(false);
            this.simpleTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.TabControlEx.SimpleTabControl simpleTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}