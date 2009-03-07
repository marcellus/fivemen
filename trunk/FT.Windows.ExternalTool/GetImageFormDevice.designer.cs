namespace FT.Windows.ExternalTool
{
    partial class GetImageFormDevice
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSetDevice = new System.Windows.Forms.Button();
            this.btnGetImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(27, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSetDevice
            // 
            this.btnSetDevice.Location = new System.Drawing.Point(235, 44);
            this.btnSetDevice.Name = "btnSetDevice";
            this.btnSetDevice.Size = new System.Drawing.Size(75, 23);
            this.btnSetDevice.TabIndex = 1;
            this.btnSetDevice.Text = "设置外设";
            this.btnSetDevice.UseVisualStyleBackColor = true;
            this.btnSetDevice.Click += new System.EventHandler(this.btnSetDevice_Click);
            // 
            // btnGetImage
            // 
            this.btnGetImage.Location = new System.Drawing.Point(235, 116);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(75, 23);
            this.btnGetImage.TabIndex = 2;
            this.btnGetImage.Text = "获取图片";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // GetImageFormDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 266);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.btnSetDevice);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GetImageFormDevice";
            this.Text = "从外设获取图片测试";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSetDevice;
        private System.Windows.Forms.Button btnGetImage;
    }
}