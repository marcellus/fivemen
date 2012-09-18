namespace HiPiaoTerminal.UserControlEx
{
    partial class MaintainFirstPanel
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnReturnFirstUserHome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnFirstUserHome)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Back_HintWithLine;
            this.pictureBox3.Location = new System.Drawing.Point(0, 154);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1280, 104);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // btnReturnFirstUserHome
            // 
            this.btnReturnFirstUserHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.ReturnFirstPanel;
            this.btnReturnFirstUserHome.Location = new System.Drawing.Point(1006, 31);
            this.btnReturnFirstUserHome.Name = "btnReturnFirstUserHome";
            this.btnReturnFirstUserHome.Size = new System.Drawing.Size(242, 101);
            this.btnReturnFirstUserHome.TabIndex = 3;
            this.btnReturnFirstUserHome.TabStop = false;
            this.btnReturnFirstUserHome.Click += new System.EventHandler(this.btnReturnFirstUserHome_Click);
            // 
            // MaintainFirstPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReturnFirstUserHome);
            this.Controls.Add(this.pictureBox3);
            this.Name = "MaintainFirstPanel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnFirstUserHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox btnReturnFirstUserHome;
    }
}
