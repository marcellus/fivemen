namespace HiPiaoTerminal.Maintain
{
    partial class ManagerFunctionsPanel
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAutoCloseComputer = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnReturnDesktop = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnCloseComputer = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnMoreSetting = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnModifyManagePwd = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Manager_Home_Hint;
            this.pictureBox1.Location = new System.Drawing.Point(0, 179);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 66);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnAutoCloseComputer
            // 
            this.btnAutoCloseComputer.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAutoCloseComputer.ForeColor = System.Drawing.Color.White;
            this.btnAutoCloseComputer.Image = global::HiPiaoTerminal.Properties.Resources.Manager_AutoClose_FunctionBack;
            this.btnAutoCloseComputer.Location = new System.Drawing.Point(190, 388);
            this.btnAutoCloseComputer.Name = "btnAutoCloseComputer";
            this.btnAutoCloseComputer.Size = new System.Drawing.Size(275, 176);
            this.btnAutoCloseComputer.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnAutoCloseComputer.TabIndex = 7;
            this.btnAutoCloseComputer.Text = "关机设置";
            this.btnAutoCloseComputer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAutoCloseComputer.Click += new System.EventHandler(this.btnAutoCloseComputer_Click);
            // 
            // btnReturnDesktop
            // 
            this.btnReturnDesktop.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturnDesktop.ForeColor = System.Drawing.Color.White;
            this.btnReturnDesktop.Image = global::HiPiaoTerminal.Properties.Resources.Manager_AutoClose_FunctionBack;
            this.btnReturnDesktop.Location = new System.Drawing.Point(190, 610);
            this.btnReturnDesktop.Name = "btnReturnDesktop";
            this.btnReturnDesktop.Size = new System.Drawing.Size(275, 176);
            this.btnReturnDesktop.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnReturnDesktop.TabIndex = 7;
            this.btnReturnDesktop.Text = "返回桌面";
            this.btnReturnDesktop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReturnDesktop.Click += new System.EventHandler(this.btnReturnDesktop_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = global::HiPiaoTerminal.Properties.Resources.Manager_AutoClose_FunctionBack;
            this.label2.Location = new System.Drawing.Point(518, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 176);
            this.label2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label2.TabIndex = 7;
            this.label2.Text = "系统设置";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // btnCloseComputer
            // 
            this.btnCloseComputer.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseComputer.ForeColor = System.Drawing.Color.White;
            this.btnCloseComputer.Image = global::HiPiaoTerminal.Properties.Resources.Manager_AutoClose_FunctionBack;
            this.btnCloseComputer.Location = new System.Drawing.Point(518, 610);
            this.btnCloseComputer.Name = "btnCloseComputer";
            this.btnCloseComputer.Size = new System.Drawing.Size(275, 176);
            this.btnCloseComputer.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnCloseComputer.TabIndex = 7;
            this.btnCloseComputer.Text = "关      机";
            this.btnCloseComputer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseComputer.Click += new System.EventHandler(this.btnCloseComputer_Click);
            // 
            // btnMoreSetting
            // 
            this.btnMoreSetting.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMoreSetting.ForeColor = System.Drawing.Color.White;
            this.btnMoreSetting.Image = global::HiPiaoTerminal.Properties.Resources.Manager_AutoClose_FunctionBack;
            this.btnMoreSetting.Location = new System.Drawing.Point(846, 610);
            this.btnMoreSetting.Name = "btnMoreSetting";
            this.btnMoreSetting.Size = new System.Drawing.Size(275, 176);
            this.btnMoreSetting.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnMoreSetting.TabIndex = 7;
            this.btnMoreSetting.Text = "更多设置";
            this.btnMoreSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMoreSetting.Click += new System.EventHandler(this.btnMoreSetting_Click);
            // 
            // btnModifyManagePwd
            // 
            this.btnModifyManagePwd.Font = new System.Drawing.Font("方正兰亭黑简体", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyManagePwd.ForeColor = System.Drawing.Color.White;
            this.btnModifyManagePwd.Image = global::HiPiaoTerminal.Properties.Resources.Manager_AutoClose_FunctionBack;
            this.btnModifyManagePwd.Location = new System.Drawing.Point(846, 388);
            this.btnModifyManagePwd.Name = "btnModifyManagePwd";
            this.btnModifyManagePwd.Size = new System.Drawing.Size(275, 176);
            this.btnModifyManagePwd.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnModifyManagePwd.TabIndex = 7;
            this.btnModifyManagePwd.Text = "修改密码";
            this.btnModifyManagePwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnModifyManagePwd.Click += new System.EventHandler(this.btnModifyManagePwd_Click);
            // 
            // ManagerFunctionsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnMoreSetting);
            this.Controls.Add(this.btnCloseComputer);
            this.Controls.Add(this.btnModifyManagePwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReturnDesktop);
            this.Controls.Add(this.btnAutoCloseComputer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ManagerFunctionsPanel";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.btnAutoCloseComputer, 0);
            this.Controls.SetChildIndex(this.btnReturnDesktop, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnModifyManagePwd, 0);
            this.Controls.SetChildIndex(this.btnCloseComputer, 0);
            this.Controls.SetChildIndex(this.btnMoreSetting, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnAutoCloseComputer;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnReturnDesktop;
        private FT.Windows.Controls.LabelEx.SimpleLabel label2;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnCloseComputer;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnMoreSetting;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnModifyManagePwd;

    }
}
