namespace HiPiaoTerminal
{
    partial class TicketPrintPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketPrintPanel));
            this.lbMobileHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbValidCode = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picReturnHome = new System.Windows.Forms.PictureBox();
            this.btnPrint = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive();
            this.numButton9 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton8 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.btnClear = new HiPiaoTerminal.UserControlEx.NumButton();
            this.btnBack = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton10 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton7 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton6 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton5 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton4 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton3 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton2 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.numButton1 = new HiPiaoTerminal.UserControlEx.NumButton();
            this.txtValidCode = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtMobile = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMobileHint
            // 
            this.lbMobileHint.AutoSize = true;
            this.lbMobileHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbMobileHint.Location = new System.Drawing.Point(239, 184);
            this.lbMobileHint.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lbMobileHint.Name = "lbMobileHint";
            this.lbMobileHint.Size = new System.Drawing.Size(125, 46);
            this.lbMobileHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMobileHint.TabIndex = 4;
            this.lbMobileHint.Text = "手机号";
            // 
            // lbValidCode
            // 
            this.lbValidCode.AutoSize = true;
            this.lbValidCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbValidCode.Location = new System.Drawing.Point(239, 278);
            this.lbValidCode.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lbValidCode.Name = "lbValidCode";
            this.lbValidCode.Size = new System.Drawing.Size(125, 46);
            this.lbValidCode.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbValidCode.TabIndex = 4;
            this.lbValidCode.Text = "验票码";
            // 
            // picReturn
            // 
            this.picReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Print_ReturnBack;
            this.picReturn.Location = new System.Drawing.Point(1053, 40);
            this.picReturn.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.picReturn.Name = "picReturn";
            this.picReturn.Size = new System.Drawing.Size(160, 83);
            this.picReturn.TabIndex = 3;
            this.picReturn.TabStop = false;
            this.picReturn.Click += new System.EventHandler(this.picReturn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Print_Site_Hint;
            this.pictureBox2.Location = new System.Drawing.Point(244, 40);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(812, 83);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // picReturnHome
            // 
            this.picReturnHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Print_Home;
            this.picReturnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picReturnHome.Location = new System.Drawing.Point(0, 40);
            this.picReturnHome.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.picReturnHome.Name = "picReturnHome";
            this.picReturnHome.Size = new System.Drawing.Size(250, 83);
            this.picReturnHome.TabIndex = 1;
            this.picReturnHome.TabStop = false;
            this.picReturnHome.Click += new System.EventHandler(this.picReturnHome_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.IsActived = false;
            this.btnPrint.Location = new System.Drawing.Point(92, 670);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(288, 85);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "取  票";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // numButton9
            // 
            this.numButton9.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton9.ForeColor = System.Drawing.Color.White;
            this.numButton9.Image = ((System.Drawing.Image)(resources.GetObject("numButton9.Image")));
            this.numButton9.IsActive = false;
            this.numButton9.Location = new System.Drawing.Point(725, 567);
            this.numButton9.Name = "numButton9";
            this.numButton9.Size = new System.Drawing.Size(140, 85);
            this.numButton9.TabIndex = 11;
            this.numButton9.Text = "9";
            this.numButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton9.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton8
            // 
            this.numButton8.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton8.ForeColor = System.Drawing.Color.White;
            this.numButton8.Image = ((System.Drawing.Image)(resources.GetObject("numButton8.Image")));
            this.numButton8.IsActive = false;
            this.numButton8.Location = new System.Drawing.Point(567, 567);
            this.numButton8.Name = "numButton8";
            this.numButton8.Size = new System.Drawing.Size(140, 85);
            this.numButton8.TabIndex = 11;
            this.numButton8.Text = "8";
            this.numButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton8.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.IsActive = false;
            this.btnClear.Location = new System.Drawing.Point(725, 670);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 85);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "清空";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.IsActive = false;
            this.btnBack.Location = new System.Drawing.Point(567, 670);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 85);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "退格";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // numButton10
            // 
            this.numButton10.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton10.ForeColor = System.Drawing.Color.White;
            this.numButton10.Image = ((System.Drawing.Image)(resources.GetObject("numButton10.Image")));
            this.numButton10.IsActive = false;
            this.numButton10.Location = new System.Drawing.Point(409, 670);
            this.numButton10.Name = "numButton10";
            this.numButton10.Size = new System.Drawing.Size(140, 85);
            this.numButton10.TabIndex = 11;
            this.numButton10.Text = "0";
            this.numButton10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton10.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton7
            // 
            this.numButton7.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton7.ForeColor = System.Drawing.Color.White;
            this.numButton7.Image = ((System.Drawing.Image)(resources.GetObject("numButton7.Image")));
            this.numButton7.IsActive = false;
            this.numButton7.Location = new System.Drawing.Point(409, 567);
            this.numButton7.Name = "numButton7";
            this.numButton7.Size = new System.Drawing.Size(140, 85);
            this.numButton7.TabIndex = 11;
            this.numButton7.Text = "7";
            this.numButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton7.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton6
            // 
            this.numButton6.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton6.ForeColor = System.Drawing.Color.White;
            this.numButton6.Image = ((System.Drawing.Image)(resources.GetObject("numButton6.Image")));
            this.numButton6.IsActive = false;
            this.numButton6.Location = new System.Drawing.Point(725, 464);
            this.numButton6.Name = "numButton6";
            this.numButton6.Size = new System.Drawing.Size(140, 85);
            this.numButton6.TabIndex = 11;
            this.numButton6.Text = "6";
            this.numButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton6.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton5
            // 
            this.numButton5.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton5.ForeColor = System.Drawing.Color.White;
            this.numButton5.Image = ((System.Drawing.Image)(resources.GetObject("numButton5.Image")));
            this.numButton5.IsActive = false;
            this.numButton5.Location = new System.Drawing.Point(567, 464);
            this.numButton5.Name = "numButton5";
            this.numButton5.Size = new System.Drawing.Size(140, 85);
            this.numButton5.TabIndex = 11;
            this.numButton5.Text = "5";
            this.numButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton5.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton4
            // 
            this.numButton4.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton4.ForeColor = System.Drawing.Color.White;
            this.numButton4.Image = ((System.Drawing.Image)(resources.GetObject("numButton4.Image")));
            this.numButton4.IsActive = false;
            this.numButton4.Location = new System.Drawing.Point(409, 464);
            this.numButton4.Name = "numButton4";
            this.numButton4.Size = new System.Drawing.Size(140, 85);
            this.numButton4.TabIndex = 11;
            this.numButton4.Text = "4";
            this.numButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton4.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton3
            // 
            this.numButton3.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton3.ForeColor = System.Drawing.Color.White;
            this.numButton3.Image = ((System.Drawing.Image)(resources.GetObject("numButton3.Image")));
            this.numButton3.IsActive = false;
            this.numButton3.Location = new System.Drawing.Point(725, 361);
            this.numButton3.Name = "numButton3";
            this.numButton3.Size = new System.Drawing.Size(140, 85);
            this.numButton3.TabIndex = 11;
            this.numButton3.Text = "3";
            this.numButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton3.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton2
            // 
            this.numButton2.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton2.ForeColor = System.Drawing.Color.White;
            this.numButton2.Image = ((System.Drawing.Image)(resources.GetObject("numButton2.Image")));
            this.numButton2.IsActive = false;
            this.numButton2.Location = new System.Drawing.Point(567, 361);
            this.numButton2.Name = "numButton2";
            this.numButton2.Size = new System.Drawing.Size(140, 85);
            this.numButton2.TabIndex = 11;
            this.numButton2.Text = "2";
            this.numButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton2.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // numButton1
            // 
            this.numButton1.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.numButton1.ForeColor = System.Drawing.Color.White;
            this.numButton1.Image = ((System.Drawing.Image)(resources.GetObject("numButton1.Image")));
            this.numButton1.IsActive = false;
            this.numButton1.Location = new System.Drawing.Point(409, 361);
            this.numButton1.Name = "numButton1";
            this.numButton1.Size = new System.Drawing.Size(140, 85);
            this.numButton1.TabIndex = 11;
            this.numButton1.Text = "1";
            this.numButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numButton1.Click += new System.EventHandler(this.numButton1_Click);
            // 
            // txtValidCode
            // 
            this.txtValidCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValidCode.Font = new System.Drawing.Font("宋体", 21F);
            this.txtValidCode.Hint = "验票码";
            this.txtValidCode.Location = new System.Drawing.Point(408, 264);
            this.txtValidCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtValidCode.MaxInputLength = 6;
            this.txtValidCode.Name = "txtValidCode";
            this.txtValidCode.PasswordChar = '\0';
            this.txtValidCode.RelativeLabel = this.lbValidCode;
            this.txtValidCode.Size = new System.Drawing.Size(311, 74);
            this.txtValidCode.TabIndex = 2;
            this.txtValidCode.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtValidCode_onSubTextChanged);
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMobile.Font = new System.Drawing.Font("宋体", 21F);
            this.txtMobile.Hint = "购票所留手机号";
            this.txtMobile.Location = new System.Drawing.Point(408, 170);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(0);
            this.txtMobile.MaxInputLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PasswordChar = '\0';
            this.txtMobile.RelativeLabel = this.lbMobileHint;
            this.txtMobile.Size = new System.Drawing.Size(311, 74);
            this.txtMobile.TabIndex = 1;
            this.txtMobile.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtMobile_onSubTextChanged);
            // 
            // TicketPrintPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.numButton9);
            this.Controls.Add(this.numButton8);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.numButton10);
            this.Controls.Add(this.numButton7);
            this.Controls.Add(this.numButton6);
            this.Controls.Add(this.numButton5);
            this.Controls.Add(this.numButton4);
            this.Controls.Add(this.numButton3);
            this.Controls.Add(this.numButton2);
            this.Controls.Add(this.numButton1);
            this.Controls.Add(this.txtValidCode);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lbValidCode);
            this.Controls.Add(this.lbMobileHint);
            this.Controls.Add(this.picReturn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picReturnHome);
            this.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Name = "TicketPrintPanel";
            this.Size = new System.Drawing.Size(1280, 960);
            this.Load += new System.EventHandler(this.TicketPrintPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturnHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picReturnHome;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picReturn;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMobileHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbValidCode;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtMobile;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtValidCode;
        private HiPiaoTerminal.UserControlEx.NumButton numButton1;
        private HiPiaoTerminal.UserControlEx.NumButton numButton2;
        private HiPiaoTerminal.UserControlEx.NumButton numButton3;
        private HiPiaoTerminal.UserControlEx.NumButton numButton4;
        private HiPiaoTerminal.UserControlEx.NumButton numButton5;
        private HiPiaoTerminal.UserControlEx.NumButton numButton6;
        private HiPiaoTerminal.UserControlEx.NumButton numButton7;
        private HiPiaoTerminal.UserControlEx.NumButton numButton8;
        private HiPiaoTerminal.UserControlEx.NumButton numButton9;
        private HiPiaoTerminal.UserControlEx.NumButton numButton10;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive btnPrint;
        private HiPiaoTerminal.UserControlEx.NumButton btnBack;
        private HiPiaoTerminal.UserControlEx.NumButton btnClear;
    }
}
