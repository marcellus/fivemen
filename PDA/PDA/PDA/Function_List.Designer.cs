namespace PDA
{
    partial class Function_List
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
            this.btn_Pingtuo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Pingtuo
            // 
            this.btn_Pingtuo.BackColor = System.Drawing.Color.Beige;
            this.btn_Pingtuo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Pingtuo.Location = new System.Drawing.Point(15, 231);
            this.btn_Pingtuo.Name = "btn_Pingtuo";
            this.btn_Pingtuo.Size = new System.Drawing.Size(208, 23);
            this.btn_Pingtuo.TabIndex = 13;
            this.btn_Pingtuo.Text = "拼托";
            this.btn_Pingtuo.Click += new System.EventHandler(this.btn_Pingtuo_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(15, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "解托";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Beige;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(15, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "组托";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Beige;
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(15, 120);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "盘点";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Beige;
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button4.Location = new System.Drawing.Point(15, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "移库";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Beige;
            this.button5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button5.Location = new System.Drawing.Point(15, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(208, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "发货";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Beige;
            this.button6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button6.Location = new System.Drawing.Point(15, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(208, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "收货";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Function_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Pingtuo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.Name = "Function_List";
            this.Text = "功能选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Pingtuo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}