namespace PDA
{
    partial class StockCondition
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Disk = new System.Windows.Forms.TextBox();
            this.txt_SKU = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ASN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "料盘：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(9, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.Text = "物料代码：";
            // 
            // txt_Disk
            // 
            this.txt_Disk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Disk.Location = new System.Drawing.Point(85, 93);
            this.txt_Disk.Name = "txt_Disk";
            this.txt_Disk.Size = new System.Drawing.Size(137, 21);
            this.txt_Disk.TabIndex = 8;
            // 
            // txt_SKU
            // 
            this.txt_SKU.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_SKU.Location = new System.Drawing.Point(85, 143);
            this.txt_SKU.Name = "txt_SKU";
            this.txt_SKU.Size = new System.Drawing.Size(137, 21);
            this.txt_SKU.TabIndex = 9;
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(85, 219);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 27);
            this.btn_OK.TabIndex = 14;
            this.btn_OK.Text = "确定";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.Text = "ASN：";
            // 
            // txt_ASN
            // 
            this.txt_ASN.Location = new System.Drawing.Point(85, 45);
            this.txt_ASN.Name = "txt_ASN";
            this.txt_ASN.Size = new System.Drawing.Size(137, 23);
            this.txt_ASN.TabIndex = 0;
            // 
            // StockCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.txt_ASN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_SKU);
            this.Controls.Add(this.txt_Disk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StockCondition";
            this.Text = "库存查询条件";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Disk;
        private System.Windows.Forms.TextBox txt_SKU;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ASN;
    }
}