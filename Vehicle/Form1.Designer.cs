namespace Vehicle
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.myButton3 = new Vehicle.MyButton();
            this.myButton2 = new Vehicle.MyButton();
            this.myButton1 = new Vehicle.MyButton();
            this.myExtendLabel4 = new MyExtendLabel();
            this.myExtendLabel3 = new MyExtendLabel();
            this.myExtendLabel2 = new MyExtendLabel();
            this.myExtendLabel1 = new MyExtendLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myButton3
            // 
            this.myButton3.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.myButton3.Location = new System.Drawing.Point(55, 58);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(152, 30);
            this.myButton3.TabIndex = 7;
            this.myButton3.Text = "myButton3";
            this.myButton3.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.myButton2.Location = new System.Drawing.Point(48, 2);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(120, 34);
            this.myButton2.TabIndex = 6;
            this.myButton2.Text = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myButton1
            // 
            this.myButton1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.myButton1.Location = new System.Drawing.Point(43, 214);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(145, 34);
            this.myButton1.TabIndex = 5;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myExtendLabel4
            // 
            this.myExtendLabel4.AutoSize = true;
            this.myExtendLabel4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Strikeout);
            this.myExtendLabel4.Location = new System.Drawing.Point(39, 190);
            this.myExtendLabel4.Name = "myExtendLabel4";
            this.myExtendLabel4.Size = new System.Drawing.Size(149, 20);
            this.myExtendLabel4.TabIndex = 3;
            this.myExtendLabel4.Text = "myExtendLabel4";
            // 
            // myExtendLabel3
            // 
            this.myExtendLabel3.AutoSize = true;
            this.myExtendLabel3.Location = new System.Drawing.Point(44, 136);
            this.myExtendLabel3.Name = "myExtendLabel3";
            this.myExtendLabel3.Size = new System.Drawing.Size(163, 20);
            this.myExtendLabel3.TabIndex = 2;
            this.myExtendLabel3.Text = "myExtendLabel3";
            // 
            // myExtendLabel2
            // 
            this.myExtendLabel2.AutoSize = true;
            this.myExtendLabel2.Location = new System.Drawing.Point(39, 91);
            this.myExtendLabel2.Name = "myExtendLabel2";
            this.myExtendLabel2.Size = new System.Drawing.Size(163, 20);
            this.myExtendLabel2.TabIndex = 1;
            this.myExtendLabel2.Text = "myExtendLabel2";
            // 
            // myExtendLabel1
            // 
            this.myExtendLabel1.AutoSize = true;
            this.myExtendLabel1.Location = new System.Drawing.Point(51, 34);
            this.myExtendLabel1.Name = "myExtendLabel1";
            this.myExtendLabel1.Size = new System.Drawing.Size(163, 20);
            this.myExtendLabel1.TabIndex = 0;
            this.myExtendLabel1.Text = "myExtendLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myExtendLabel4);
            this.Controls.Add(this.myExtendLabel3);
            this.Controls.Add(this.myExtendLabel2);
            this.Controls.Add(this.myExtendLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyExtendLabel myExtendLabel1;
        private MyExtendLabel myExtendLabel2;
        private MyExtendLabel myExtendLabel3;
        private MyExtendLabel myExtendLabel4;
        private System.Windows.Forms.Button button1;
        private MyButton myButton1;
        private MyButton myButton2;
        private MyButton myButton3;
    }
}