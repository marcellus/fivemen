namespace PDA
{
    partial class PutAwayScan
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
            this.txt_PutAwayBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_PutAway = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_PutAway = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_PutAwayBill
            // 
            this.txt_PutAwayBill.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_PutAwayBill.Location = new System.Drawing.Point(72, 6);
            this.txt_PutAwayBill.Name = "txt_PutAwayBill";
            this.txt_PutAwayBill.Size = new System.Drawing.Size(155, 21);
            this.txt_PutAwayBill.TabIndex = 0;
            this.txt_PutAwayBill.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PutAwayBill_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.Text = "ASN：";
            // 
            // dg_PutAway
            // 
            this.dg_PutAway.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_PutAway.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.dg_PutAway.Location = new System.Drawing.Point(11, 51);
            this.dg_PutAway.Name = "dg_PutAway";
            this.dg_PutAway.RowHeadersVisible = false;
            this.dg_PutAway.Size = new System.Drawing.Size(216, 184);
            this.dg_PutAway.TabIndex = 3;
            this.dg_PutAway.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.MappingName = "PutAwayBill";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "供应商";
            this.dataGridTextBoxColumn1.MappingName = "COMPANY";
            this.dataGridTextBoxColumn1.Width = 60;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "物料";
            this.dataGridTextBoxColumn2.MappingName = "SKU";
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "数量";
            this.dataGridTextBoxColumn3.MappingName = "EXPECTED_PUTAWAY_QTY";
            this.dataGridTextBoxColumn3.Width = 30;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "指导库位";
            this.dataGridTextBoxColumn4.MappingName = "EXPECTED_LOC";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(61, 241);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(117, 25);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "开始上架";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_PutAway
            // 
            this.lbl_PutAway.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_PutAway.Location = new System.Drawing.Point(5, 30);
            this.lbl_PutAway.Name = "lbl_PutAway";
            this.lbl_PutAway.Size = new System.Drawing.Size(227, 18);
            this.lbl_PutAway.Text = "ASN：";
            // 
            // PutAwayScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.lbl_PutAway);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dg_PutAway);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PutAwayBill);
            this.Name = "PutAwayScan";
            this.Text = "上架单";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_PutAwayBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dg_PutAway;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Label lbl_PutAway;
    }
}