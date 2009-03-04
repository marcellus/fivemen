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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbProduct = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbVersion = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbCopyRight = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDescription = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel5 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel6 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel7 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel8 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbProduct, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbVersion, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbCopyRight, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbDescription, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.simpleLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.simpleLabel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.simpleLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.simpleLabel8, 0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::FT.Windows.Forms.Properties.Resources.about;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lbProduct
            // 
            resources.ApplyResources(this.lbProduct, "lbProduct");
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // lbVersion
            // 
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // lbCopyRight
            // 
            resources.ApplyResources(this.lbCopyRight, "lbCopyRight");
            this.lbCopyRight.Name = "lbCopyRight";
            this.lbCopyRight.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel5
            // 
            resources.ApplyResources(this.simpleLabel5, "simpleLabel5");
            this.simpleLabel5.Name = "simpleLabel5";
            this.simpleLabel5.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel6
            // 
            resources.ApplyResources(this.simpleLabel6, "simpleLabel6");
            this.simpleLabel6.Name = "simpleLabel6";
            this.simpleLabel6.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel7
            // 
            resources.ApplyResources(this.simpleLabel7, "simpleLabel7");
            this.simpleLabel7.Name = "simpleLabel7";
            this.simpleLabel7.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel8
            // 
            resources.ApplyResources(this.simpleLabel8, "simpleLabel8");
            this.simpleLabel8.Name = "simpleLabel8";
            this.simpleLabel8.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // SimpleAbout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleAbout";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbProduct;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbVersion;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbCopyRight;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDescription;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel5;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel6;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel7;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel8;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}