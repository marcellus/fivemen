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
            this.txt_PickBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Loc = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_PickBill
            // 
            this.txt_PickBill.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_PickBill.Location = new System.Drawing.Point(69, 56);
            this.txt_PickBill.Name = "txt_PickBill";
            this.txt_PickBill.Size = new System.Drawing.Size(161, 21);
            this.txt_PickBill.TabIndex = 1;
            this.txt_PickBill.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PickBill_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.Text = "发货单：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.Text = "仓库：";
            // 
            // txt_Loc
            // 
            this.txt_Loc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Loc.Location = new System.Drawing.Point(69, 110);
            this.txt_Loc.Name = "txt_Loc";
            this.txt_Loc.Size = new System.Drawing.Size(161, 21);
            this.txt_Loc.TabIndex = 11;
            this.txt_Loc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Loc_KeyUp);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(69, 189);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(109, 25);
            this.btn_OK.TabIndex = 15;
            this.btn_OK.Text = "开始发货";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // PickScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_Loc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_PickBill);
            this.Controls.Add(this.label1);
            this.Name = "PickScan";
            this.Text = "发货单扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_PickBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Loc;
        private System.Windows.Forms.Button btn_OK;

    }
}