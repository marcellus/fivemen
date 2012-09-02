namespace HiPiaoTerminal.Account
{
    partial class ModifyPwdPanel
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
            this.picRepeatPwdHint = new System.Windows.Forms.PictureBox();
            this.picNewPwdHint = new System.Windows.Forms.PictureBox();
            this.picOldPwdHint = new System.Windows.Forms.PictureBox();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnSure = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbOldPwdHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbNewPwdHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRepeatPwdHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtRepeatPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtOldPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtNewPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picRepeatPwdHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewPwdHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOldPwdHint)).BeginInit();
            this.SuspendLayout();
            // 
            // picRepeatPwdHint
            // 
            this.picRepeatPwdHint.Location = new System.Drawing.Point(983, 395);
            this.picRepeatPwdHint.Name = "picRepeatPwdHint";
            this.picRepeatPwdHint.Size = new System.Drawing.Size(28, 31);
            this.picRepeatPwdHint.TabIndex = 12;
            this.picRepeatPwdHint.TabStop = false;
            // 
            // picNewPwdHint
            // 
            this.picNewPwdHint.Location = new System.Drawing.Point(983, 253);
            this.picNewPwdHint.Name = "picNewPwdHint";
            this.picNewPwdHint.Size = new System.Drawing.Size(28, 31);
            this.picNewPwdHint.TabIndex = 11;
            this.picNewPwdHint.TabStop = false;
            // 
            // picOldPwdHint
            // 
            this.picOldPwdHint.Location = new System.Drawing.Point(983, 112);
            this.picOldPwdHint.Name = "picOldPwdHint";
            this.picOldPwdHint.Size = new System.Drawing.Size(28, 31);
            this.picOldPwdHint.TabIndex = 10;
            this.picOldPwdHint.TabStop = false;
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel1.ForeColor = System.Drawing.Color.White;
            this.simpleLabel1.Image = global::HiPiaoTerminal.Properties.Resources.Account_btn_Active;
            this.simpleLabel1.Location = new System.Drawing.Point(712, 494);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(268, 95);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel1.TabIndex = 14;
            this.simpleLabel1.Text = "取  消";
            this.simpleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabel1.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnSure
            // 
            this.btnSure.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.Image = global::HiPiaoTerminal.Properties.Resources.Account_btn_Not_Active;
            this.btnSure.Location = new System.Drawing.Point(381, 494);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(268, 95);
            this.btnSure.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnSure.TabIndex = 14;
            this.btnSure.Text = "确  定";
            this.btnSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // lbOldPwdHint
            // 
            this.lbOldPwdHint.AutoSize = true;
            this.lbOldPwdHint.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOldPwdHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbOldPwdHint.Location = new System.Drawing.Point(374, 180);
            this.lbOldPwdHint.Name = "lbOldPwdHint";
            this.lbOldPwdHint.Size = new System.Drawing.Size(0, 32);
            this.lbOldPwdHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbOldPwdHint.TabIndex = 13;
            // 
            // lbNewPwdHint
            // 
            this.lbNewPwdHint.AutoSize = true;
            this.lbNewPwdHint.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNewPwdHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbNewPwdHint.Location = new System.Drawing.Point(374, 322);
            this.lbNewPwdHint.Name = "lbNewPwdHint";
            this.lbNewPwdHint.Size = new System.Drawing.Size(0, 32);
            this.lbNewPwdHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbNewPwdHint.TabIndex = 13;
            // 
            // lbRepeatPwdHint
            // 
            this.lbRepeatPwdHint.AutoSize = true;
            this.lbRepeatPwdHint.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRepeatPwdHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbRepeatPwdHint.Location = new System.Drawing.Point(374, 462);
            this.lbRepeatPwdHint.Name = "lbRepeatPwdHint";
            this.lbRepeatPwdHint.Size = new System.Drawing.Size(0, 32);
            this.lbRepeatPwdHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRepeatPwdHint.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("方正兰亭黑简体", 26F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(131, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 40);
            this.label2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label2.TabIndex = 9;
            this.label2.Text = "重复新密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("方正兰亭黑简体", 26F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(131, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 40);
            this.label1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label1.TabIndex = 9;
            this.label1.Text = "设定新密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("方正兰亭黑简体", 26F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(201, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 40);
            this.label3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label3.TabIndex = 9;
            this.label3.Text = "旧密码";
            // 
            // txtRepeatPwd
            // 
            this.txtRepeatPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtRepeatPwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtRepeatPwd.Hint = "请再次输新密码";
            this.txtRepeatPwd.IsActive = false;
            this.txtRepeatPwd.IsDeleted = false;
            this.txtRepeatPwd.Location = new System.Drawing.Point(368, 352);
            this.txtRepeatPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtRepeatPwd.MaxInputLength = 32767;
            this.txtRepeatPwd.Name = "txtRepeatPwd";
            this.txtRepeatPwd.PasswordChar = '*';
            this.txtRepeatPwd.RelativeLabel = null;
            this.txtRepeatPwd.Size = new System.Drawing.Size(612, 110);
            this.txtRepeatPwd.TabIndex = 3;
            this.txtRepeatPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtOldPwd_onSubTextChanged);
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldPwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtOldPwd.Hint = "请输入旧密码";
            this.txtOldPwd.IsActive = false;
            this.txtOldPwd.IsDeleted = false;
            this.txtOldPwd.Location = new System.Drawing.Point(368, 70);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtOldPwd.MaxInputLength = 32767;
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.RelativeLabel = null;
            this.txtOldPwd.Size = new System.Drawing.Size(612, 110);
            this.txtOldPwd.TabIndex = 1;
            this.txtOldPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtOldPwd_onSubTextChanged);
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtNewPwd.Hint = "请输入新密码";
            this.txtNewPwd.IsActive = false;
            this.txtNewPwd.IsDeleted = false;
            this.txtNewPwd.Location = new System.Drawing.Point(368, 212);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewPwd.MaxInputLength = 32767;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.RelativeLabel = null;
            this.txtNewPwd.Size = new System.Drawing.Size(612, 110);
            this.txtNewPwd.TabIndex = 2;
            this.txtNewPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtOldPwd_onSubTextChanged);
            // 
            // ModifyPwdPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.lbOldPwdHint);
            this.Controls.Add(this.lbNewPwdHint);
            this.Controls.Add(this.lbRepeatPwdHint);
            this.Controls.Add(this.picRepeatPwdHint);
            this.Controls.Add(this.picNewPwdHint);
            this.Controls.Add(this.picOldPwdHint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRepeatPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Font = new System.Drawing.Font("方正兰亭黑简体", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ModifyPwdPanel";
            this.Size = new System.Drawing.Size(1280, 600);
            ((System.ComponentModel.ISupportInitialize)(this.picRepeatPwdHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewPwdHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOldPwdHint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HiPiaoTerminal.UserControlEx.UserInputPanel txtRepeatPwd;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtOldPwd;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtNewPwd;
        private FT.Windows.Controls.LabelEx.SimpleLabel label3;
        private FT.Windows.Controls.LabelEx.SimpleLabel label1;
        private FT.Windows.Controls.LabelEx.SimpleLabel label2;
        private System.Windows.Forms.PictureBox picRepeatPwdHint;
        private System.Windows.Forms.PictureBox picNewPwdHint;
        private System.Windows.Forms.PictureBox picOldPwdHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRepeatPwdHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbNewPwdHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbOldPwdHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnSure;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
    }
}
