namespace FT.Exam
{
    partial class UserLoginFirstForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginFirstForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkExam = new System.Windows.Forms.CheckBox();
            this.checkTrain = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTrain1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lbTrain2 = new System.Windows.Forms.Label();
            this.txtEndNum = new System.Windows.Forms.TextBox();
            this.lbTrain3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lbAllCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLearnCar = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入您的身份证明号码";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(20, 60);
            this.txtIdCard.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(352, 24);
            this.txtIdCard.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 183);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始考试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 183);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "系统管理";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkExam
            // 
            this.checkExam.AutoSize = true;
            this.checkExam.Checked = true;
            this.checkExam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExam.Location = new System.Drawing.Point(168, 115);
            this.checkExam.Name = "checkExam";
            this.checkExam.Size = new System.Drawing.Size(86, 19);
            this.checkExam.TabIndex = 6;
            this.checkExam.Text = "随机考试";
            this.checkExam.UseVisualStyleBackColor = true;
            this.checkExam.CheckedChanged += new System.EventHandler(this.checkExam_CheckedChanged);
            // 
            // checkTrain
            // 
            this.checkTrain.AutoSize = true;
            this.checkTrain.Location = new System.Drawing.Point(96, 115);
            this.checkTrain.Name = "checkTrain";
            this.checkTrain.Size = new System.Drawing.Size(56, 19);
            this.checkTrain.TabIndex = 5;
            this.checkTrain.Text = "练习";
            this.checkTrain.UseVisualStyleBackColor = true;
            this.checkTrain.CheckedChanged += new System.EventHandler(this.checkTrain_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "练习种类";
            // 
            // lbTrain1
            // 
            this.lbTrain1.AutoSize = true;
            this.lbTrain1.Location = new System.Drawing.Point(20, 155);
            this.lbTrain1.Name = "lbTrain1";
            this.lbTrain1.Size = new System.Drawing.Size(37, 15);
            this.lbTrain1.TabIndex = 7;
            this.lbTrain1.Text = "从第";
            this.lbTrain1.Visible = false;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(57, 148);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(49, 24);
            this.txtFrom.TabIndex = 8;
            this.txtFrom.Text = "1";
            this.txtFrom.Visible = false;
            // 
            // lbTrain2
            // 
            this.lbTrain2.AutoSize = true;
            this.lbTrain2.Location = new System.Drawing.Point(112, 157);
            this.lbTrain2.Name = "lbTrain2";
            this.lbTrain2.Size = new System.Drawing.Size(82, 15);
            this.lbTrain2.TabIndex = 9;
            this.lbTrain2.Text = "题开始挑选";
            this.lbTrain2.Visible = false;
            // 
            // txtEndNum
            // 
            this.txtEndNum.Location = new System.Drawing.Point(200, 148);
            this.txtEndNum.Name = "txtEndNum";
            this.txtEndNum.Size = new System.Drawing.Size(62, 24);
            this.txtEndNum.TabIndex = 10;
            this.txtEndNum.Text = "100";
            this.txtEndNum.Visible = false;
            // 
            // lbTrain3
            // 
            this.lbTrain3.AutoSize = true;
            this.lbTrain3.Location = new System.Drawing.Point(270, 155);
            this.lbTrain3.Name = "lbTrain3";
            this.lbTrain3.Size = new System.Drawing.Size(37, 15);
            this.lbTrain3.TabIndex = 11;
            this.lbTrain3.Text = "题目";
            this.lbTrain3.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(232, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "查找我的考试记录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbAllCount
            // 
            this.lbAllCount.AutoSize = true;
            this.lbAllCount.Location = new System.Drawing.Point(273, 115);
            this.lbAllCount.Name = "lbAllCount";
            this.lbAllCount.Size = new System.Drawing.Size(55, 15);
            this.lbAllCount.TabIndex = 14;
            this.lbAllCount.Text = "label3";
            this.lbAllCount.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "请输入驾照类型";
            // 
            // cbLearnCar
            // 
            this.cbLearnCar.FormattingEnabled = true;
            this.cbLearnCar.Location = new System.Drawing.Point(139, 86);
            this.cbLearnCar.Name = "cbLearnCar";
            this.cbLearnCar.Size = new System.Drawing.Size(121, 23);
            this.cbLearnCar.TabIndex = 16;
            this.cbLearnCar.TextChanged += new System.EventHandler(this.cbLearnCar_TextChanged);
            // 
            // UserLoginFirstForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 245);
            this.Controls.Add(this.cbLearnCar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbAllCount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbTrain3);
            this.Controls.Add(this.txtEndNum);
            this.Controls.Add(this.lbTrain2);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lbTrain1);
            this.Controls.Add(this.checkExam);
            this.Controls.Add(this.checkTrain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIdCard);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserLoginFirstForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科目一模拟考试系统";
            this.Load += new System.EventHandler(this.UserLoginFirstForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkExam;
        private System.Windows.Forms.CheckBox checkTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTrain1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lbTrain2;
        private System.Windows.Forms.TextBox txtEndNum;
        private System.Windows.Forms.Label lbTrain3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbAllCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLearnCar;
    }
}