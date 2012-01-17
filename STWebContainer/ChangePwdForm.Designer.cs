namespace STWebContainer
{
    partial class ChangePwdForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtRepeatPwd = new System.Windows.Forms.TextBox();
            this.lbHint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pwdInputControl1 = new STWebContainer.PwdInputControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(61, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "新密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "重复密码";
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd.HideSelection = false;
            this.txtNewPwd.Location = new System.Drawing.Point(209, 31);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(229, 42);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.Enter += new System.EventHandler(this.txtNewPwd_Enter);
            // 
            // txtRepeatPwd
            // 
            this.txtRepeatPwd.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepeatPwd.Location = new System.Drawing.Point(209, 101);
            this.txtRepeatPwd.Name = "txtRepeatPwd";
            this.txtRepeatPwd.PasswordChar = '*';
            this.txtRepeatPwd.Size = new System.Drawing.Size(229, 42);
            this.txtRepeatPwd.TabIndex = 3;
            this.txtRepeatPwd.Enter += new System.EventHandler(this.txtRepeatPwd_Enter);
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHint.ForeColor = System.Drawing.Color.Red;
            this.lbHint.Location = new System.Drawing.Point(85, 178);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(0, 31);
            this.lbHint.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(36, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 67);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "确  认";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(294, 236);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 67);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pwdInputControl1
            // 
            this.pwdInputControl1.Location = new System.Drawing.Point(466, 12);
            this.pwdInputControl1.Name = "pwdInputControl1";
            this.pwdInputControl1.Size = new System.Drawing.Size(219, 291);
            this.pwdInputControl1.TabIndex = 4;
            this.pwdInputControl1.Enter += new System.EventHandler(this.pwdInputControl1_Enter);
            // 
            // ChangePwdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 318);
            this.Controls.Add(this.pwdInputControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.txtRepeatPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePwdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.ChangePwdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtRepeatPwd;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private PwdInputControl pwdInputControl1;
    }
}