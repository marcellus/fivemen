namespace FT.Windows.Forms
{
    partial class SimpleAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simpleLabel5 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel7 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel6 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbVersion = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbProduct = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel8 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbCopyRight = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDescription = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FT.Windows.Forms.Properties.Resources.about;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // simpleLabel5
            // 
            this.simpleLabel5.AutoSize = true;
            this.simpleLabel5.Font = new System.Drawing.Font("宋体", 11F);
            this.simpleLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.simpleLabel5.Location = new System.Drawing.Point(12, 108);
            this.simpleLabel5.Name = "simpleLabel5";
            this.simpleLabel5.Size = new System.Drawing.Size(37, 15);
            this.simpleLabel5.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleLabel5.TabIndex = 6;
            this.simpleLabel5.Text = "产品";
            this.simpleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // simpleLabel7
            // 
            this.simpleLabel7.AutoSize = true;
            this.simpleLabel7.Font = new System.Drawing.Font("宋体", 11F);
            this.simpleLabel7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.simpleLabel7.Location = new System.Drawing.Point(12, 150);
            this.simpleLabel7.Name = "simpleLabel7";
            this.simpleLabel7.Size = new System.Drawing.Size(37, 15);
            this.simpleLabel7.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleLabel7.TabIndex = 6;
            this.simpleLabel7.Text = "版权";
            this.simpleLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // simpleLabel6
            // 
            this.simpleLabel6.AutoSize = true;
            this.simpleLabel6.Font = new System.Drawing.Font("宋体", 11F);
            this.simpleLabel6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.simpleLabel6.Location = new System.Drawing.Point(12, 129);
            this.simpleLabel6.Name = "simpleLabel6";
            this.simpleLabel6.Size = new System.Drawing.Size(37, 15);
            this.simpleLabel6.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleLabel6.TabIndex = 6;
            this.simpleLabel6.Text = "版本";
            this.simpleLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Font = new System.Drawing.Font("宋体", 11F);
            this.lbVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbVersion.Location = new System.Drawing.Point(49, 129);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(103, 15);
            this.lbVersion.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.lbVersion.TabIndex = 5;
            this.lbVersion.Text = "simpleLabel1";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProduct
            // 
            this.lbProduct.AutoSize = true;
            this.lbProduct.Font = new System.Drawing.Font("宋体", 11F);
            this.lbProduct.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProduct.Location = new System.Drawing.Point(49, 108);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(103, 15);
            this.lbProduct.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.lbProduct.TabIndex = 5;
            this.lbProduct.Text = "simpleLabel1";
            this.lbProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleLabel8
            // 
            this.simpleLabel8.AutoSize = true;
            this.simpleLabel8.Font = new System.Drawing.Font("宋体", 11F);
            this.simpleLabel8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.simpleLabel8.Location = new System.Drawing.Point(12, 171);
            this.simpleLabel8.Name = "simpleLabel8";
            this.simpleLabel8.Size = new System.Drawing.Size(37, 15);
            this.simpleLabel8.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleLabel8.TabIndex = 6;
            this.simpleLabel8.Text = "描述";
            this.simpleLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCopyRight
            // 
            this.lbCopyRight.AutoSize = true;
            this.lbCopyRight.Font = new System.Drawing.Font("宋体", 11F);
            this.lbCopyRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCopyRight.Location = new System.Drawing.Point(49, 150);
            this.lbCopyRight.Name = "lbCopyRight";
            this.lbCopyRight.Size = new System.Drawing.Size(103, 15);
            this.lbCopyRight.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.lbCopyRight.TabIndex = 5;
            this.lbCopyRight.Text = "simpleLabel1";
            this.lbCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("宋体", 11F);
            this.lbDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescription.Location = new System.Drawing.Point(49, 171);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(103, 15);
            this.lbDescription.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.lbDescription.TabIndex = 5;
            this.lbDescription.Text = "simpleLabel1";
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SimpleAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 231);
            this.Controls.Add(this.simpleLabel5);
            this.Controls.Add(this.simpleLabel7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.simpleLabel6);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbProduct);
            this.Controls.Add(this.simpleLabel8);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbCopyRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            this.Click += new System.EventHandler(this.SimpleAbout_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbProduct;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbVersion;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbCopyRight;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel5;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel6;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel7;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel8;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDescription;
    }
}