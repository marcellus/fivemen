namespace PDA
{
    partial class PickScan
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
            this.txt_SO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CarNo = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.ck_MoreSO = new System.Windows.Forms.CheckBox();
            this.txt_MoreSO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ck_Different = new System.Windows.Forms.CheckBox();
            this.txt_Different = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_SO
            // 
            this.txt_SO.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_SO.Location = new System.Drawing.Point(73, 13);
            this.txt_SO.Name = "txt_SO";
            this.txt_SO.Size = new System.Drawing.Size(152, 21);
            this.txt_SO.TabIndex = 1;
            this.txt_SO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SO_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.Text = "SO：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.Text = "车牌：";
            // 
            // txt_CarNo
            // 
            this.txt_CarNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_CarNo.Location = new System.Drawing.Point(73, 167);
            this.txt_CarNo.Name = "txt_CarNo";
            this.txt_CarNo.Size = new System.Drawing.Size(152, 21);
            this.txt_CarNo.TabIndex = 4;
            this.txt_CarNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_CarNo_KeyUp);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(73, 235);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(109, 25);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "开始发货";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // ck_MoreSO
            // 
            this.ck_MoreSO.Location = new System.Drawing.Point(73, 47);
            this.ck_MoreSO.Name = "ck_MoreSO";
            this.ck_MoreSO.Size = new System.Drawing.Size(100, 20);
            this.ck_MoreSO.TabIndex = 2;
            this.ck_MoreSO.Text = "多个SO";
            this.ck_MoreSO.CheckStateChanged += new System.EventHandler(this.ck_MoreSO_CheckStateChanged);
            // 
            // txt_MoreSO
            // 
            this.txt_MoreSO.Enabled = false;
            this.txt_MoreSO.Location = new System.Drawing.Point(73, 80);
            this.txt_MoreSO.Multiline = true;
            this.txt_MoreSO.Name = "txt_MoreSO";
            this.txt_MoreSO.Size = new System.Drawing.Size(152, 74);
            this.txt_MoreSO.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.Text = "其它SO：";
            // 
            // ck_Different
            // 
            this.ck_Different.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.ck_Different.Location = new System.Drawing.Point(206, 203);
            this.ck_Different.Name = "ck_Different";
            this.ck_Different.Size = new System.Drawing.Size(24, 20);
            this.ck_Different.TabIndex = 6;
            this.ck_Different.CheckStateChanged += new System.EventHandler(this.ck_Different_CheckStateChanged);
            // 
            // txt_Different
            // 
            this.txt_Different.Enabled = false;
            this.txt_Different.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Different.Location = new System.Drawing.Point(73, 203);
            this.txt_Different.Name = "txt_Different";
            this.txt_Different.Size = new System.Drawing.Size(130, 21);
            this.txt_Different.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(7, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.Text = "区分：";
            // 
            // PickScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.ck_Different);
            this.Controls.Add(this.txt_Different);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_MoreSO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ck_MoreSO);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_CarNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_SO);
            this.Controls.Add(this.label1);
            this.Name = "PickScan";
            this.Text = "发货单扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_SO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CarNo;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.CheckBox ck_MoreSO;
        private System.Windows.Forms.TextBox txt_MoreSO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_Different;
        private System.Windows.Forms.TextBox txt_Different;
        private System.Windows.Forms.Label label6;

    }
}