namespace FT.Windows.ExternalTool
{
    partial class Image2Base64Test
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPicPath = new System.Windows.Forms.TextBox();
            this.btnSelector = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBase64 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片路径";
            // 
            // txtPicPath
            // 
            this.txtPicPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtPicPath.Enabled = false;
            this.txtPicPath.Location = new System.Drawing.Point(92, 22);
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.Size = new System.Drawing.Size(389, 21);
            this.txtPicPath.TabIndex = 1;
            // 
            // btnSelector
            // 
            this.btnSelector.Location = new System.Drawing.Point(510, 19);
            this.btnSelector.Name = "btnSelector";
            this.btnSelector.Size = new System.Drawing.Size(60, 23);
            this.btnSelector.TabIndex = 2;
            this.btnSelector.Text = "选择";
            this.btnSelector.UseVisualStyleBackColor = true;
            this.btnSelector.Click += new System.EventHandler(this.btnSelector_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtBase64
            // 
            this.txtBase64.Location = new System.Drawing.Point(187, 81);
            this.txtBase64.Multiline = true;
            this.txtBase64.Name = "txtBase64";
            this.txtBase64.Size = new System.Drawing.Size(367, 189);
            this.txtBase64.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "图片到字符串";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "字符串到图片";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Image2Base64Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 385);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBase64);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSelector);
            this.Controls.Add(this.txtPicPath);
            this.Controls.Add(this.label1);
            this.Name = "Image2Base64Test";
            this.Text = "图片和base64转换";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPicPath;
        private System.Windows.Forms.Button btnSelector;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBase64;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}