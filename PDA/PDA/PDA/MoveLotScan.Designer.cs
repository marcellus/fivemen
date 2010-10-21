namespace PDA
{
    partial class MoveLotScan
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
            this.txt_MoveLotBill = new System.Windows.Forms.TextBox();
            this.txt_OldLot = new System.Windows.Forms.TextBox();
            this.dg_MoveLot = new System.Windows.Forms.DataGrid();
            this.btn_OK = new System.Windows.Forms.Button();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.Text = "转储单号：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "原批次号：";
            // 
            // txt_MoveLotBill
            // 
            this.txt_MoveLotBill.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_MoveLotBill.Location = new System.Drawing.Point(89, 7);
            this.txt_MoveLotBill.Name = "txt_MoveLotBill";
            this.txt_MoveLotBill.Size = new System.Drawing.Size(137, 21);
            this.txt_MoveLotBill.TabIndex = 3;
            this.txt_MoveLotBill.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_MoveLotBill_KeyUp);
            // 
            // txt_OldLot
            // 
            this.txt_OldLot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_OldLot.Location = new System.Drawing.Point(89, 36);
            this.txt_OldLot.Name = "txt_OldLot";
            this.txt_OldLot.Size = new System.Drawing.Size(137, 21);
            this.txt_OldLot.TabIndex = 4;
            this.txt_OldLot.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_OldLot_KeyUp);
            // 
            // dg_MoveLot
            // 
            this.dg_MoveLot.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_MoveLot.Location = new System.Drawing.Point(10, 70);
            this.dg_MoveLot.Name = "dg_MoveLot";
            this.dg_MoveLot.Size = new System.Drawing.Size(216, 164);
            this.dg_MoveLot.TabIndex = 5;
            this.dg_MoveLot.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Beige;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_OK.Location = new System.Drawing.Point(38, 240);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(132, 25);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "开始扫描";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.MappingName = "MOVELOTBILL";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "供应商";
            this.dataGridTextBoxColumn1.MappingName = "COMPANY";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "物料";
            this.dataGridTextBoxColumn2.MappingName = "SKU";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "原批次";
            this.dataGridTextBoxColumn3.MappingName = "OLDLOT";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "新批次";
            this.dataGridTextBoxColumn4.MappingName = "NEWLOT";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "数量";
            this.dataGridTextBoxColumn5.MappingName = "QTY";
            // 
            // MoveLotScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dg_MoveLot);
            this.Controls.Add(this.txt_OldLot);
            this.Controls.Add(this.txt_MoveLotBill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MoveLotScan";
            this.Text = "移储";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MoveLotBill;
        private System.Windows.Forms.TextBox txt_OldLot;
        private System.Windows.Forms.DataGrid dg_MoveLot;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
    }
}