namespace PrinterTest
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("方正兰亭黑简体", 29F);
            this.label1.Location = new System.Drawing.Point(117, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(405, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 40);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 467);
            this.button1.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 61);
            this.button1.TabIndex = 2;
            this.button1.Text = "登陆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(480, 467);
            this.button2.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 61);
            this.button2.TabIndex = 3;
            this.button2.Text = "发布图片";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(111, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 51);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Font = new System.Drawing.Font("方正兰亭黑简体", 30F);
            this.simpleLabel1.Location = new System.Drawing.Point(372, 218);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(140, 46);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleLabel1.TabIndex = 5;
            this.simpleLabel1.Text = "用户名";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 699);
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
    }
}