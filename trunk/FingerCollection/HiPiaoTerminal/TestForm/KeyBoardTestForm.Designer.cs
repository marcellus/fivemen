namespace HiPiaoTerminal.TestForm
{
    partial class KeyBoardTestForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.userInputPanel1 = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 198);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userInputPanel1
            // 
            this.userInputPanel1.BackColor = System.Drawing.Color.IndianRed;
            this.userInputPanel1.Font = new System.Drawing.Font("宋体", 21F);
            this.userInputPanel1.Hint = null;
            this.userInputPanel1.Location = new System.Drawing.Point(18, 35);
            this.userInputPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.userInputPanel1.Name = "userInputPanel1";
            this.userInputPanel1.PasswordChar = '\0';
            this.userInputPanel1.Size = new System.Drawing.Size(249, 74);
            this.userInputPanel1.TabIndex = 0;
            // 
            // KeyBoardTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 516);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.userInputPanel1);
            this.Name = "KeyBoardTestForm";
            this.Text = "KeyBoardTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HiPiaoTerminal.UserControlEx.UserInputPanel userInputPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}