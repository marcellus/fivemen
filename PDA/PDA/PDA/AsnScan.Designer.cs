namespace PDA
{
    partial class ASNScan
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
            this.txt_ASN = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Company = new System.Windows.Forms.ComboBox();
            this.cb_Storage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CarNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ASNType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Different = new System.Windows.Forms.TextBox();
            this.ck_Different = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.Text = "收货单：";
            // 
            // txt_ASN
            // 
            this.txt_ASN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_ASN.Location = new System.Drawing.Point(84, 14);
            this.txt_ASN.Name = "txt_ASN";
            this.txt_ASN.Size = new System.Drawing.Size(138, 21);
            this.txt_ASN.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(84, 228);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(109, 25);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "开始收货";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "工厂：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "仓库：";
            // 
            // cb_Company
            // 
            this.cb_Company.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Company.Location = new System.Drawing.Point(84, 48);
            this.cb_Company.Name = "cb_Company";
            this.cb_Company.Size = new System.Drawing.Size(138, 21);
            this.cb_Company.TabIndex = 2;
            // 
            // cb_Storage
            // 
            this.cb_Storage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Storage.Location = new System.Drawing.Point(84, 84);
            this.cb_Storage.Name = "cb_Storage";
            this.cb_Storage.Size = new System.Drawing.Size(138, 21);
            this.cb_Storage.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.Text = "车牌：";
            // 
            // txt_CarNo
            // 
            this.txt_CarNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_CarNo.Location = new System.Drawing.Point(84, 120);
            this.txt_CarNo.Name = "txt_CarNo";
            this.txt_CarNo.Size = new System.Drawing.Size(138, 21);
            this.txt_CarNo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.Text = "收货类型：";
            // 
            // cb_ASNType
            // 
            this.cb_ASNType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_ASNType.Location = new System.Drawing.Point(84, 156);
            this.cb_ASNType.Name = "cb_ASNType";
            this.cb_ASNType.Size = new System.Drawing.Size(138, 21);
            this.cb_ASNType.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(3, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.Text = "区分：";
            // 
            // txt_Different
            // 
            this.txt_Different.Enabled = false;
            this.txt_Different.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Different.Location = new System.Drawing.Point(84, 192);
            this.txt_Different.Name = "txt_Different";
            this.txt_Different.Size = new System.Drawing.Size(114, 21);
            this.txt_Different.TabIndex = 6;
            // 
            // ck_Different
            // 
            this.ck_Different.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.ck_Different.Location = new System.Drawing.Point(204, 195);
            this.ck_Different.Name = "ck_Different";
            this.ck_Different.Size = new System.Drawing.Size(24, 20);
            this.ck_Different.TabIndex = 7;
            this.ck_Different.CheckStateChanged += new System.EventHandler(this.chk_Different_CheckStateChanged);
            // 
            // ASNScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.ck_Different);
            this.Controls.Add(this.txt_Different);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_ASNType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_CarNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Storage);
            this.Controls.Add(this.cb_Company);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_ASN);
            this.Controls.Add(this.label1);
            this.Name = "ASNScan";
            this.Text = "收货";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ASN;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Company;
        private System.Windows.Forms.ComboBox cb_Storage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CarNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ASNType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Different;
        private System.Windows.Forms.CheckBox ck_Different;
    }
}

