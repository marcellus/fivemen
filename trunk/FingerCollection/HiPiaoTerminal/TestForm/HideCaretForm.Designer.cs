namespace HiPiaoTerminal.TestForm
{
    partial class HideCaretForm
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
            this.userInputPanel1 = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.userInputPanel2 = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 117);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 56);
            this.textBox1.TabIndex = 1;
            // 
            // userInputPanel1
            // 
            this.userInputPanel1.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.userInputPanel1.BackColor = System.Drawing.Color.Transparent;
            this.userInputPanel1.Font = new System.Drawing.Font("宋体", 21F);
            this.userInputPanel1.Hint = null;
            this.userInputPanel1.IsActive = false;
            this.userInputPanel1.IsDeleted = false;
            this.userInputPanel1.KeyboardType = 6;
            this.userInputPanel1.Location = new System.Drawing.Point(70, 37);
            this.userInputPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.userInputPanel1.MaxInputLength = 32767;
            this.userInputPanel1.Name = "userInputPanel1";
            this.userInputPanel1.PasswordChar = '\0';
            this.userInputPanel1.RelativeLabel = null;
            this.userInputPanel1.Size = new System.Drawing.Size(364, 56);
            this.userInputPanel1.TabIndex = 0;
            // 
            // userInputPanel2
            // 
            this.userInputPanel2.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.userInputPanel2.BackColor = System.Drawing.Color.Transparent;
            this.userInputPanel2.Font = new System.Drawing.Font("宋体", 21F);
            this.userInputPanel2.Hint = null;
            this.userInputPanel2.IsActive = false;
            this.userInputPanel2.IsDeleted = false;
            this.userInputPanel2.KeyboardType = 6;
            this.userInputPanel2.Location = new System.Drawing.Point(70, 201);
            this.userInputPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.userInputPanel2.MaxInputLength = 32767;
            this.userInputPanel2.Name = "userInputPanel2";
            this.userInputPanel2.PasswordChar = '*';
            this.userInputPanel2.RelativeLabel = null;
            this.userInputPanel2.Size = new System.Drawing.Size(364, 56);
            this.userInputPanel2.TabIndex = 0;
            // 
            // HideCaretForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(503, 266);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.userInputPanel2);
            this.Controls.Add(this.userInputPanel1);
            this.Name = "HideCaretForm";
            this.Text = "HideCaretForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HiPiaoTerminal.UserControlEx.UserInputPanel userInputPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private HiPiaoTerminal.UserControlEx.UserInputPanel userInputPanel2;
    }
}