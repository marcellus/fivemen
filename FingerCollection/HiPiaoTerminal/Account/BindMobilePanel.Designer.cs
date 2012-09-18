namespace HiPiaoTerminal.Account
{
    partial class BindMobilePanel
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
            this.btnSure = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.lbUserName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.userInputPanel1 = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.userInputPanel2 = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simpleLabel3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BindMobile_Sure;
            this.btnSure.Location = new System.Drawing.Point(169, 520);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(293, 111);
            this.btnSure.TabIndex = 0;
            this.btnSure.TabStop = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BindMobile_Cancel;
            this.btnCancel.Location = new System.Drawing.Point(531, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(293, 111);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 36F);
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbUserName.Location = new System.Drawing.Point(31, 66);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(279, 55);
            this.lbUserName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbUserName.TabIndex = 1;
            this.lbUserName.Text = "用户名：{0}";
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 36F);
            this.simpleLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.simpleLabel1.Location = new System.Drawing.Point(31, 192);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(279, 55);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel1.TabIndex = 1;
            this.simpleLabel1.Text = "绑定手机号:";
            // 
            // simpleLabel2
            // 
            this.simpleLabel2.AutoSize = true;
            this.simpleLabel2.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 36F);
            this.simpleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.simpleLabel2.Location = new System.Drawing.Point(31, 330);
            this.simpleLabel2.Name = "simpleLabel2";
            this.simpleLabel2.Size = new System.Drawing.Size(375, 55);
            this.simpleLabel2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel2.TabIndex = 1;
            this.simpleLabel2.Text = "输入手机验证码:";
            // 
            // userInputPanel1
            // 
            this.userInputPanel1.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.userInputPanel1.BackColor = System.Drawing.Color.Transparent;
            this.userInputPanel1.Font = new System.Drawing.Font("宋体", 21F);
            this.userInputPanel1.Hint = null;
            this.userInputPanel1.IsActive = true;
            this.userInputPanel1.IsDeleted = false;
            this.userInputPanel1.KeyboardType = 1;
            this.userInputPanel1.Location = new System.Drawing.Point(313, 183);
            this.userInputPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.userInputPanel1.MaxInputLength = 11;
            this.userInputPanel1.Name = "userInputPanel1";
            this.userInputPanel1.PasswordChar = '\0';
            this.userInputPanel1.RelativeLabel = null;
            this.userInputPanel1.Size = new System.Drawing.Size(434, 72);
            this.userInputPanel1.TabIndex = 2;
            // 
            // userInputPanel2
            // 
            this.userInputPanel2.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.userInputPanel2.BackColor = System.Drawing.Color.Transparent;
            this.userInputPanel2.Font = new System.Drawing.Font("宋体", 21F);
            this.userInputPanel2.Hint = null;
            this.userInputPanel2.IsActive = true;
            this.userInputPanel2.IsDeleted = false;
            this.userInputPanel2.KeyboardType = 1;
            this.userInputPanel2.Location = new System.Drawing.Point(409, 321);
            this.userInputPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.userInputPanel2.MaxInputLength = 6;
            this.userInputPanel2.Name = "userInputPanel2";
            this.userInputPanel2.PasswordChar = '\0';
            this.userInputPanel2.RelativeLabel = null;
            this.userInputPanel2.Size = new System.Drawing.Size(279, 72);
            this.userInputPanel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BindMobile_SendValidCode;
            this.pictureBox1.Location = new System.Drawing.Point(765, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 68);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // simpleLabel3
            // 
            this.simpleLabel3.AutoSize = true;
            this.simpleLabel3.Font = new System.Drawing.Font("方正兰亭粗黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(119)))), ((int)(((byte)(8)))));
            this.simpleLabel3.Location = new System.Drawing.Point(331, 266);
            this.simpleLabel3.Name = "simpleLabel3";
            this.simpleLabel3.Size = new System.Drawing.Size(631, 27);
            this.simpleLabel3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel3.TabIndex = 1;
            this.simpleLabel3.Text = "若未收到手机验证码, 30秒后请点击“发送验证码”重新发送";
            // 
            // BindMobilePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userInputPanel2);
            this.Controls.Add(this.userInputPanel1);
            this.Controls.Add(this.simpleLabel2);
            this.Controls.Add(this.simpleLabel3);
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Name = "BindMobilePanel";
            this.Size = new System.Drawing.Size(996, 700);
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnSure;
        private System.Windows.Forms.PictureBox btnCancel;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbUserName;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel2;
        private HiPiaoTerminal.UserControlEx.UserInputPanel userInputPanel1;
        private HiPiaoTerminal.UserControlEx.UserInputPanel userInputPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel3;
    }
}
