namespace HiPiaoTerminal.BuyTicket
{
    partial class ConfirmPayPwdPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmPayPwdPanel));
            this.label1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMsg = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtUserPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.btnCancel = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive2();
            this.btnConfirmPay = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive2();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("方正兰亭粗黑简体", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(127, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 49);
            this.label1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入账户密码";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("方正兰亭黑简体", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbMsg.Location = new System.Drawing.Point(130, 255);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 36);
            this.lbMsg.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMsg.TabIndex = 1;
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtUserPwd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserPwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtUserPwd.Hint = "账户密码";
            this.txtUserPwd.IsActive = true;
            this.txtUserPwd.IsDeleted = true;
            this.txtUserPwd.KeyboardType = 5;
            this.txtUserPwd.Location = new System.Drawing.Point(125, 132);
            this.txtUserPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserPwd.MaxInputLength = 6;
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.RelativeLabel = null;
            this.txtUserPwd.Size = new System.Drawing.Size(560, 110);
            this.txtUserPwd.TabIndex = 3;
            this.txtUserPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserPwd_onSubTextChanged);
            this.txtUserPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.userInputPanel1_KeyUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.IsActived = true;
            this.btnCancel.Location = new System.Drawing.Point(428, 304);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(241, 92);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取   消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmPay
            // 
            this.btnConfirmPay.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnConfirmPay.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPay.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmPay.Image")));
            this.btnConfirmPay.IsActived = false;
            this.btnConfirmPay.Location = new System.Drawing.Point(142, 304);
            this.btnConfirmPay.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirmPay.Name = "btnConfirmPay";
            this.btnConfirmPay.Size = new System.Drawing.Size(241, 92);
            this.btnConfirmPay.TabIndex = 4;
            this.btnConfirmPay.Text = "支   付";
            this.btnConfirmPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirmPay.Click += new System.EventHandler(this.btnConfirmPay_Click_1);
            // 
            // ConfirmPayPwdPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmPay);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.label1);
            this.Name = "ConfirmPayPwdPanel";
            this.Size = new System.Drawing.Size(805, 490);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel label1;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMsg;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtUserPwd;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive2 btnConfirmPay;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive2 btnCancel;
    }
}
