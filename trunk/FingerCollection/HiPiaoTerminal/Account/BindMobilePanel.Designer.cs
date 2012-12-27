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
            this.components = new System.ComponentModel.Container();
            this.lbUserName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtMobile = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtCode = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.simpleLabel3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnSure = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbUserName.Location = new System.Drawing.Point(31, 66);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(279, 56);
            this.lbUserName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbUserName.TabIndex = 1;
            this.lbUserName.Text = "用户名：{0}";
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Font = new System.Drawing.Font("方正兰亭纤黑简体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.simpleLabel1.Location = new System.Drawing.Point(31, 192);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(278, 56);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel1.TabIndex = 1;
            this.simpleLabel1.Text = "绑定手机号:";
            // 
            // simpleLabel2
            // 
            this.simpleLabel2.AutoSize = true;
            this.simpleLabel2.Font = new System.Drawing.Font("方正兰亭纤黑简体", 36F);
            this.simpleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.simpleLabel2.Location = new System.Drawing.Point(31, 330);
            this.simpleLabel2.Name = "simpleLabel2";
            this.simpleLabel2.Size = new System.Drawing.Size(374, 56);
            this.simpleLabel2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel2.TabIndex = 1;
            this.simpleLabel2.Text = "输入手机验证码:";
            // 
            // txtMobile
            // 
            this.txtMobile.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtMobile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMobile.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMobile.Hint = null;
            this.txtMobile.IsActive = true;
            this.txtMobile.IsDeleted = true;
            this.txtMobile.KeyboardType = 6;
            this.txtMobile.Location = new System.Drawing.Point(313, 183);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(0);
            this.txtMobile.MaxInputLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PasswordChar = '\0';
            this.txtMobile.RelativeLabel = null;
            this.txtMobile.Size = new System.Drawing.Size(434, 72);
            this.txtMobile.TabIndex = 2;
            this.txtMobile.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtMobile_onSubTextChanged);
            // 
            // txtCode
            // 
            this.txtCode.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCode.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Hint = null;
            this.txtCode.IsActive = true;
            this.txtCode.IsDeleted = true;
            this.txtCode.KeyboardType = 6;
            this.txtCode.Location = new System.Drawing.Point(409, 321);
            this.txtCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCode.MaxInputLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.RelativeLabel = null;
            this.txtCode.Size = new System.Drawing.Size(279, 72);
            this.txtCode.TabIndex = 2;
            // 
            // simpleLabel3
            // 
            this.simpleLabel3.AutoSize = true;
            this.simpleLabel3.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(119)))), ((int)(((byte)(8)))));
            this.simpleLabel3.Location = new System.Drawing.Point(302, 266);
            this.simpleLabel3.Name = "simpleLabel3";
            this.simpleLabel3.Size = new System.Drawing.Size(657, 27);
            this.simpleLabel3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel3.TabIndex = 1;
            this.simpleLabel3.Text = "若未收到手机验证码, 30秒后请点击“发送验证码”重新发送";
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHint.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbHint.Location = new System.Drawing.Point(415, 416);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(0, 27);
            this.lbHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbHint.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BindMobile_SendValidCode;
            this.pictureBox1.Location = new System.Drawing.Point(765, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 68);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BindMobilePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.simpleLabel2);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.simpleLabel3);
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Name = "BindMobilePanel";
            this.Size = new System.Drawing.Size(996, 700);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnSure;
        private System.Windows.Forms.PictureBox btnCancel;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbUserName;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel2;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtMobile;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel3;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbHint;
        private System.Windows.Forms.Timer timer1;
    }
}
