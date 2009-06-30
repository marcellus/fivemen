namespace FT.Windows.ExternalTool
{
    partial class InvokeJavaWebService
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
            this.txtIdCardType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWriteSn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReadSn = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "身份证明名称";
            // 
            // txtIdCardType
            // 
            this.txtIdCardType.Location = new System.Drawing.Point(97, 3);
            this.txtIdCardType.Name = "txtIdCardType";
            this.txtIdCardType.Size = new System.Drawing.Size(100, 21);
            this.txtIdCardType.TabIndex = 1;
            this.txtIdCardType.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "身份证明号码";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(97, 30);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(100, 21);
            this.txtIdCard.TabIndex = 1;
            this.txtIdCard.Text = "idcard123";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "照片数据";
            // 
            // txtZp
            // 
            this.txtZp.Location = new System.Drawing.Point(97, 59);
            this.txtZp.Name = "txtZp";
            this.txtZp.Size = new System.Drawing.Size(100, 21);
            this.txtZp.TabIndex = 3;
            this.txtZp.Text = "zp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "写入sn";
            // 
            // txtWriteSn
            // 
            this.txtWriteSn.Location = new System.Drawing.Point(97, 94);
            this.txtWriteSn.Name = "txtWriteSn";
            this.txtWriteSn.Size = new System.Drawing.Size(100, 21);
            this.txtWriteSn.TabIndex = 5;
            this.txtWriteSn.Text = "snwrite";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "读取sn";
            // 
            // txtReadSn
            // 
            this.txtReadSn.Location = new System.Drawing.Point(97, 121);
            this.txtReadSn.Name = "txtReadSn";
            this.txtReadSn.Size = new System.Drawing.Size(100, 21);
            this.txtReadSn.TabIndex = 5;
            this.txtReadSn.Text = "snread";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "测试读取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(97, 206);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(159, 21);
            this.txtResult.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "返回结果";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "测试写入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InvokeJavaWebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtReadSn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWriteSn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtZp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdCard);
            this.Controls.Add(this.txtIdCardType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InvokeJavaWebService";
            this.Text = "InvokeJavaWebService";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdCardType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtZp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWriteSn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReadSn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}