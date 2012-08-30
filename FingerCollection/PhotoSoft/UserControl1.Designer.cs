namespace PhotoSoft
{
    partial class UserControl1
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
                if (vedioGrap != null)
                {
                    vedioGrap.StopVideo();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.btnPhoto = new System.Windows.Forms.PictureBox();
            this.panelPhotoRec = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPhoto
            // 
            this.btnPhoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPhoto.BackgroundImage")));
            this.btnPhoto.Location = new System.Drawing.Point(490, 1371);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(502, 499);
            this.btnPhoto.TabIndex = 0;
            this.btnPhoto.TabStop = false;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // panelPhotoRec
            // 
            this.panelPhotoRec.BackColor = System.Drawing.SystemColors.Window;
            this.panelPhotoRec.Location = new System.Drawing.Point(315, 375);
            this.panelPhotoRec.Name = "panelPhotoRec";
            this.panelPhotoRec.Size = new System.Drawing.Size(796, 556);
            this.panelPhotoRec.TabIndex = 1;
            // 
            // UserControl1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.panelPhotoRec);
            this.Controls.Add(this.btnPhoto);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1483, 2637);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnPhoto;
        private System.Windows.Forms.Panel panelPhotoRec;
    }
}
