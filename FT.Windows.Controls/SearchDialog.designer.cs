namespace FT.Windows.Controls
{
    partial class SearchDialog
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
            this.matchCase = new System.Windows.Forms.CheckBox();
            this.matchWholeWord = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downButton = new System.Windows.Forms.RadioButton();
            this.upButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.searchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // matchCase
            // 
            this.matchCase.AutoSize = true;
            this.matchCase.Location = new System.Drawing.Point(14, 67);
            this.matchCase.Name = "matchCase";
            this.matchCase.Size = new System.Drawing.Size(84, 16);
            this.matchCase.TabIndex = 13;
            this.matchCase.Text = "区分大小写";
            this.matchCase.UseVisualStyleBackColor = true;
            // 
            // matchWholeWord
            // 
            this.matchWholeWord.AutoSize = true;
            this.matchWholeWord.Location = new System.Drawing.Point(14, 43);
            this.matchWholeWord.Name = "matchWholeWord";
            this.matchWholeWord.Size = new System.Drawing.Size(72, 16);
            this.matchWholeWord.TabIndex = 12;
            this.matchWholeWord.Text = "全字匹配";
            this.matchWholeWord.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.downButton);
            this.groupBox1.Controls.Add(this.upButton);
            this.groupBox1.Location = new System.Drawing.Point(155, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 43);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "方向";
            // 
            // downButton
            // 
            this.downButton.AutoSize = true;
            this.downButton.Location = new System.Drawing.Point(51, 18);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(47, 16);
            this.downButton.TabIndex = 1;
            this.downButton.TabStop = true;
            this.downButton.Text = "向下";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.AutoSize = true;
            this.upButton.Location = new System.Drawing.Point(6, 18);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(47, 16);
            this.upButton.TabIndex = 0;
            this.upButton.TabStop = true;
            this.upButton.Text = "向上";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(282, 40);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 21);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(282, 12);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 21);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "查找下一个";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // searchString
            // 
            this.searchString.Location = new System.Drawing.Point(77, 13);
            this.searchString.Name = "searchString";
            this.searchString.Size = new System.Drawing.Size(190, 21);
            this.searchString.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "查找内容";
            // 
            // SearchDialog
            // 
            this.AcceptButton = this.findButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(368, 95);
            this.Controls.Add(this.matchCase);
            this.Controls.Add(this.matchWholeWord);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.searchString);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchDialog";
            this.Text = "查找";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox matchCase;
        private System.Windows.Forms.CheckBox matchWholeWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton downButton;
        private System.Windows.Forms.RadioButton upButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox searchString;
        private System.Windows.Forms.Label label1;
    }
}