namespace PDA
{
    partial class Login
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
            this.txt_User = new System.Windows.Forms.TextBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.cb_UpdateUserData = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_User
            // 
            this.txt_User.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_User.Location = new System.Drawing.Point(73, 36);
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(135, 21);
            this.txt_User.TabIndex = 0;
            this.txt_User.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_User_KeyUp);
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Pwd.Location = new System.Drawing.Point(73, 80);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(135, 21);
            this.txt_Pwd.TabIndex = 1;
            this.txt_Pwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Pwd_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.Text = "用户：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(20, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.Text = "密码：";
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(83, 194);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 27);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "确定";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // cb_UpdateUserData
            // 
            this.cb_UpdateUserData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_UpdateUserData.Location = new System.Drawing.Point(73, 124);
            this.cb_UpdateUserData.Name = "cb_UpdateUserData";
            this.cb_UpdateUserData.Size = new System.Drawing.Size(135, 20);
            this.cb_UpdateUserData.TabIndex = 8;
            this.cb_UpdateUserData.Text = "同步用户数据";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(73, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.Text = "同步需要连接网络";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_UpdateUserData);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Pwd);
            this.Controls.Add(this.txt_User);
            this.Name = "Login";
            this.Text = " 登录";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.CheckBox cb_UpdateUserData;
        private System.Windows.Forms.Label label3;
    }
}