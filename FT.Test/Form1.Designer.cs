namespace FT.Test
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.simpleLine1 = new FT.Windows.Controls.SimpleLine();
            this.stateLamp1 = new FT.Windows.Controls.StateLamp();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.myButtonObject1 = new FT.Windows.Controls.ButtonEx.MyButtonObject();
            this.simpleButton5 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.simpleButton4 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.simpleButton3 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.simpleButton2 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.simpleButton1 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.stateLamp2 = new FT.Windows.Controls.StateLamp();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(252, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 111);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(252, 189);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 111);
            this.textBox2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(404, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // simpleLine1
            // 
            this.simpleLine1.Location = new System.Drawing.Point(211, 321);
            this.simpleLine1.Name = "simpleLine1";
            this.simpleLine1.Size = new System.Drawing.Size(89, 38);
            this.simpleLine1.TabIndex = 10;
            this.simpleLine1.Text = "simpleLine1";
            // 
            // stateLamp1
            // 
            this.stateLamp1.IsRunning = false;
            this.stateLamp1.Location = new System.Drawing.Point(306, 321);
            this.stateLamp1.Name = "stateLamp1";
            this.stateLamp1.Radius = 15;
            this.stateLamp1.Size = new System.Drawing.Size(30, 30);
            this.stateLamp1.TabIndex = 9;
            this.stateLamp1.Text = "stateLamp1";
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.BackColor = System.Drawing.Color.Turquoise;
            this.simpleLabel1.Location = new System.Drawing.Point(29, 177);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(77, 12);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleLabel1.TabIndex = 3;
            this.simpleLabel1.Text = "simpleLabel1";
            // 
            // myButtonObject1
            // 
            this.myButtonObject1.Location = new System.Drawing.Point(31, 312);
            this.myButtonObject1.Name = "myButtonObject1";
            this.myButtonObject1.Size = new System.Drawing.Size(108, 103);
            this.myButtonObject1.TabIndex = 2;
            this.myButtonObject1.Click += new System.EventHandler(this.myButtonObject1_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(29, 151);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(77, 23);
            this.simpleButton5.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleButton5.TabIndex = 0;
            this.simpleButton5.Text = "Windows";
            this.simpleButton5.UseVisualStyleBackColor = true;
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(29, 110);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(77, 23);
            this.simpleButton4.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleButton4.TabIndex = 0;
            this.simpleButton4.Text = "红色魅影";
            this.simpleButton4.UseVisualStyleBackColor = true;
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.AutoSize = true;
            this.simpleButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.simpleButton3.ForeColor = System.Drawing.Color.Black;
            this.simpleButton3.Location = new System.Drawing.Point(29, 81);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(77, 23);
            this.simpleButton3.Skin = FT.Windows.Controls.SimpleSkinType.Blue;
            this.simpleButton3.TabIndex = 0;
            this.simpleButton3.Text = "黑色天地";
            this.simpleButton3.UseVisualStyleBackColor = false;
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.simpleButton2.ForeColor = System.Drawing.Color.Black;
            this.simpleButton2.Location = new System.Drawing.Point(29, 42);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(77, 23);
            this.simpleButton2.Skin = FT.Windows.Controls.SimpleSkinType.Blue;
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "湛蓝风情";
            this.simpleButton2.UseVisualStyleBackColor = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(29, 231);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(77, 23);
            this.simpleButton1.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.UseVisualStyleBackColor = true;
            // 
            // stateLamp2
            // 
            this.stateLamp2.IsRunning = false;
            this.stateLamp2.Location = new System.Drawing.Point(165, 330);
            this.stateLamp2.Name = "stateLamp2";
            this.stateLamp2.Radius = 10;
            this.stateLamp2.Size = new System.Drawing.Size(20, 20);
            this.stateLamp2.TabIndex = 11;
            this.stateLamp2.Text = "stateLamp2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 450);
            this.Controls.Add(this.stateLamp2);
            this.Controls.Add(this.stateLamp1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.myButtonObject1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton1;
        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton2;
        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton3;
        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton4;
        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton5;
        private System.Windows.Forms.Label label1;
        private FT.Windows.Controls.ButtonEx.MyButtonObject myButtonObject1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private FT.Windows.Controls.StateLamp stateLamp1;
        private FT.Windows.Controls.SimpleLine simpleLine1;
        private FT.Windows.Controls.StateLamp stateLamp2;
    }
}

