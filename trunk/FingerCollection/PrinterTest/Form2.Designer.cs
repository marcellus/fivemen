namespace PrinterTest
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageProcessPanel1 = new FT.Windows.Controls.PanelEx.ImageProcessPanel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmails = new System.Windows.Forms.TextBox();
            this.label1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnSendToWeibo = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.btnBeginPhoto = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageProcessPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadImage);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtPwd);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmails);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnSendToWeibo);
            this.splitContainer1.Panel2.Controls.Add(this.btnSendEmail);
            this.splitContainer1.Panel2.Controls.Add(this.btnPhoto);
            this.splitContainer1.Panel2.Controls.Add(this.btnBeginPhoto);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(503, 560);
            this.splitContainer1.SplitterDistance = 496;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // imageProcessPanel1
            // 
            this.imageProcessPanel1.Location = new System.Drawing.Point(0, 0);
            this.imageProcessPanel1.Name = "imageProcessPanel1";
            this.imageProcessPanel1.ProcessImage = null;
            this.imageProcessPanel1.Size = new System.Drawing.Size(468, 484);
            this.imageProcessPanel1.TabIndex = 0;
            this.imageProcessPanel1.Load += new System.EventHandler(this.imageProcessPanel1_Load);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(422, 461);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "加载图像";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Visible = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label3.TabIndex = 5;
            this.label3.Text = "微博密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(385, 9);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(87, 21);
            this.txtPwd.TabIndex = 4;
            this.txtPwd.Text = "qwe123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label2.TabIndex = 5;
            this.label2.Text = "微博名称";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(233, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(87, 21);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "95673039@qq.com";
            // 
            // txtEmails
            // 
            this.txtEmails.Location = new System.Drawing.Point(80, 42);
            this.txtEmails.Name = "txtEmails";
            this.txtEmails.Size = new System.Drawing.Size(169, 21);
            this.txtEmails.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label1.TabIndex = 3;
            this.label1.Text = "邮箱地址";
            // 
            // btnSendToWeibo
            // 
            this.btnSendToWeibo.Location = new System.Drawing.Point(385, 40);
            this.btnSendToWeibo.Name = "btnSendToWeibo";
            this.btnSendToWeibo.Size = new System.Drawing.Size(83, 23);
            this.btnSendToWeibo.TabIndex = 2;
            this.btnSendToWeibo.Text = "发送到微博";
            this.btnSendToWeibo.UseVisualStyleBackColor = true;
            this.btnSendToWeibo.Click += new System.EventHandler(this.btnSendToWeibo_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(267, 42);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSendEmail.TabIndex = 2;
            this.btnSendEmail.Text = "发送邮件";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnPhoto
            // 
            this.btnPhoto.Location = new System.Drawing.Point(93, 13);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnPhoto.TabIndex = 2;
            this.btnPhoto.Text = "拍照";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // btnBeginPhoto
            // 
            this.btnBeginPhoto.Location = new System.Drawing.Point(12, 13);
            this.btnBeginPhoto.Name = "btnBeginPhoto";
            this.btnBeginPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnBeginPhoto.TabIndex = 2;
            this.btnBeginPhoto.Text = "开始视频";
            this.btnBeginPhoto.UseVisualStyleBackColor = true;
            this.btnBeginPhoto.Click += new System.EventHandler(this.btnBeginPhoto_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 560);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLoadImage;
        private FT.Windows.Controls.PanelEx.ImageProcessPanel imageProcessPanel1;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnBeginPhoto;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.TextBox txtEmails;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSendToWeibo;
        private FT.Windows.Controls.LabelEx.SimpleLabel label1;
        private FT.Windows.Controls.LabelEx.SimpleLabel label2;
        private FT.Windows.Controls.LabelEx.SimpleLabel label3;

    }
}