namespace HiPiaoTerminal.Maintain
{
    partial class ManagerModifyPwdPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerModifyPwdPanel));
            this.txtNewPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.lbNewPwd = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtOldPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.lbOldPwd = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtRepeatPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.lbRepeatPwd = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnCancelSave = new System.Windows.Forms.PictureBox();
            this.btnKeepSave = new System.Windows.Forms.PictureBox();
            this.lbReturnMsg = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeepSave)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.txtNewPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F);
            this.txtNewPwd.Hint = "请输入新密码";
            this.txtNewPwd.IsActive = false;
            this.txtNewPwd.IsDeleted = false;
            this.txtNewPwd.KeyboardType = 6;
            this.txtNewPwd.Location = new System.Drawing.Point(454, 434);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewPwd.MaxInputLength = 32767;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.RelativeLabel = this.lbNewPwd;
            this.txtNewPwd.Size = new System.Drawing.Size(352, 74);
            this.txtNewPwd.TabIndex = 5;
            // 
            // lbNewPwd
            // 
            this.lbNewPwd.AutoSize = true;
            this.lbNewPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNewPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbNewPwd.Location = new System.Drawing.Point(301, 452);
            this.lbNewPwd.Name = "lbNewPwd";
            this.lbNewPwd.Size = new System.Drawing.Size(125, 40);
            this.lbNewPwd.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbNewPwd.TabIndex = 20;
            this.lbNewPwd.Text = "新密码";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Manager_ModifyPwd_Hint;
            this.pictureBox5.Location = new System.Drawing.Point(0, 174);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(392, 70);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.txtOldPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F);
            this.txtOldPwd.Hint = "请输入旧密码";
            this.txtOldPwd.IsActive = false;
            this.txtOldPwd.IsDeleted = false;
            this.txtOldPwd.KeyboardType = 6;
            this.txtOldPwd.Location = new System.Drawing.Point(454, 341);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtOldPwd.MaxInputLength = 32767;
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.RelativeLabel = this.lbOldPwd;
            this.txtOldPwd.Size = new System.Drawing.Size(352, 74);
            this.txtOldPwd.TabIndex = 5;
            // 
            // lbOldPwd
            // 
            this.lbOldPwd.AutoSize = true;
            this.lbOldPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOldPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbOldPwd.Location = new System.Drawing.Point(301, 359);
            this.lbOldPwd.Name = "lbOldPwd";
            this.lbOldPwd.Size = new System.Drawing.Size(125, 40);
            this.lbOldPwd.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbOldPwd.TabIndex = 19;
            this.lbOldPwd.Text = "旧密码";
            this.lbOldPwd.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtRepeatPwd
            // 
            this.txtRepeatPwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.txtRepeatPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtRepeatPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F);
            this.txtRepeatPwd.Hint = "请再次输新密码";
            this.txtRepeatPwd.IsActive = false;
            this.txtRepeatPwd.IsDeleted = false;
            this.txtRepeatPwd.KeyboardType = 6;
            this.txtRepeatPwd.Location = new System.Drawing.Point(454, 520);
            this.txtRepeatPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtRepeatPwd.MaxInputLength = 32767;
            this.txtRepeatPwd.Name = "txtRepeatPwd";
            this.txtRepeatPwd.PasswordChar = '*';
            this.txtRepeatPwd.RelativeLabel = this.lbRepeatPwd;
            this.txtRepeatPwd.Size = new System.Drawing.Size(352, 74);
            this.txtRepeatPwd.TabIndex = 5;
            // 
            // lbRepeatPwd
            // 
            this.lbRepeatPwd.AutoSize = true;
            this.lbRepeatPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRepeatPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbRepeatPwd.Location = new System.Drawing.Point(231, 541);
            this.lbRepeatPwd.Name = "lbRepeatPwd";
            this.lbRepeatPwd.Size = new System.Drawing.Size(197, 40);
            this.lbRepeatPwd.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRepeatPwd.TabIndex = 21;
            this.lbRepeatPwd.Text = "重复新密码";
            // 
            // btnCancelSave
            // 
            this.btnCancelSave.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Cancel_Save;
            this.btnCancelSave.Location = new System.Drawing.Point(639, 654);
            this.btnCancelSave.Name = "btnCancelSave";
            this.btnCancelSave.Size = new System.Drawing.Size(220, 68);
            this.btnCancelSave.TabIndex = 17;
            this.btnCancelSave.TabStop = false;
            this.btnCancelSave.Click += new System.EventHandler(this.btnCancelSave_Click);
            // 
            // btnKeepSave
            // 
            this.btnKeepSave.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Keep_Save;
            this.btnKeepSave.Location = new System.Drawing.Point(366, 654);
            this.btnKeepSave.Name = "btnKeepSave";
            this.btnKeepSave.Size = new System.Drawing.Size(220, 68);
            this.btnKeepSave.TabIndex = 16;
            this.btnKeepSave.TabStop = false;
            this.btnKeepSave.Click += new System.EventHandler(this.btnKeepSave_Click);
            // 
            // lbReturnMsg
            // 
            this.lbReturnMsg.AutoSize = true;
            this.lbReturnMsg.BackColor = System.Drawing.SystemColors.Window;
            this.lbReturnMsg.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReturnMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbReturnMsg.Location = new System.Drawing.Point(313, 288);
            this.lbReturnMsg.Name = "lbReturnMsg";
            this.lbReturnMsg.Size = new System.Drawing.Size(0, 32);
            this.lbReturnMsg.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbReturnMsg.TabIndex = 18;
            // 
            // ManagerModifyPwdPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.lbRepeatPwd);
            this.Controls.Add(this.lbNewPwd);
            this.Controls.Add(this.lbOldPwd);
            this.Controls.Add(this.lbReturnMsg);
            this.Controls.Add(this.btnCancelSave);
            this.Controls.Add(this.btnKeepSave);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtRepeatPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Name = "ManagerModifyPwdPanel";
            this.Controls.SetChildIndex(this.txtNewPwd, 0);
            this.Controls.SetChildIndex(this.txtOldPwd, 0);
            this.Controls.SetChildIndex(this.txtRepeatPwd, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            this.Controls.SetChildIndex(this.btnKeepSave, 0);
            this.Controls.SetChildIndex(this.btnCancelSave, 0);
            this.Controls.SetChildIndex(this.lbReturnMsg, 0);
            this.Controls.SetChildIndex(this.lbOldPwd, 0);
            this.Controls.SetChildIndex(this.lbNewPwd, 0);
            this.Controls.SetChildIndex(this.lbRepeatPwd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeepSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HiPiaoTerminal.UserControlEx.UserInputPanel txtNewPwd;
        private System.Windows.Forms.PictureBox pictureBox5;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtOldPwd;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtRepeatPwd;
        private System.Windows.Forms.PictureBox btnCancelSave;
        private System.Windows.Forms.PictureBox btnKeepSave;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbReturnMsg;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRepeatPwd;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbNewPwd;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbOldPwd;





    }
}
