namespace PDA
{
    partial class AsnDetailScan
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
            this.txt_Disk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PN = new System.Windows.Forms.TextBox();
            this.txt_DiskDetail = new System.Windows.Forms.TextBox();
            this.ck_Rollback = new System.Windows.Forms.CheckBox();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.btn_ClearPN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Disk
            // 
            this.txt_Disk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Disk.Location = new System.Drawing.Point(91, 54);
            this.txt_Disk.Name = "txt_Disk";
            this.txt_Disk.Size = new System.Drawing.Size(134, 21);
            this.txt_Disk.TabIndex = 3;
            this.txt_Disk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Disk_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.Text = "产品条码：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.Text = "P/N:";
            // 
            // txt_PN
            // 
            this.txt_PN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_PN.Location = new System.Drawing.Point(91, 15);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Size = new System.Drawing.Size(104, 21);
            this.txt_PN.TabIndex = 1;
            this.txt_PN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PN_KeyUp);
            // 
            // txt_DiskDetail
            // 
            this.txt_DiskDetail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_DiskDetail.ForeColor = System.Drawing.Color.Black;
            this.txt_DiskDetail.Location = new System.Drawing.Point(6, 131);
            this.txt_DiskDetail.Multiline = true;
            this.txt_DiskDetail.Name = "txt_DiskDetail";
            this.txt_DiskDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_DiskDetail.Size = new System.Drawing.Size(224, 103);
            this.txt_DiskDetail.TabIndex = 7;
            // 
            // ck_Rollback
            // 
            this.ck_Rollback.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.ck_Rollback.ForeColor = System.Drawing.Color.Red;
            this.ck_Rollback.Location = new System.Drawing.Point(10, 90);
            this.ck_Rollback.Name = "ck_Rollback";
            this.ck_Rollback.Size = new System.Drawing.Size(126, 20);
            this.ck_Rollback.TabIndex = 8;
            this.ck_Rollback.Text = "撤销产品扫描";
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(74, 240);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(75, 25);
            this.btn_TempSave.TabIndex = 9;
            this.btn_TempSave.Text = "临时保存";
            this.btn_TempSave.Click += new System.EventHandler(this.btn_TempSave_Click);
            // 
            // btn_Finish
            // 
            this.btn_Finish.BackColor = System.Drawing.Color.Beige;
            this.btn_Finish.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Finish.Location = new System.Drawing.Point(154, 240);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(75, 25);
            this.btn_Finish.TabIndex = 10;
            this.btn_Finish.Text = "提交";
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // btn_ClearPN
            // 
            this.btn_ClearPN.BackColor = System.Drawing.Color.Beige;
            this.btn_ClearPN.Location = new System.Drawing.Point(201, 16);
            this.btn_ClearPN.Name = "btn_ClearPN";
            this.btn_ClearPN.Size = new System.Drawing.Size(24, 22);
            this.btn_ClearPN.TabIndex = 18;
            this.btn_ClearPN.Text = "X";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(6, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 38;
            this.button1.Text = "查看";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AsnDetailScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ClearPN);
            this.Controls.Add(this.btn_Finish);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.ck_Rollback);
            this.Controls.Add(this.txt_DiskDetail);
            this.Controls.Add(this.txt_PN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Disk);
            this.Name = "AsnDetailScan";
            this.Text = "收货扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Disk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PN;
        private System.Windows.Forms.TextBox txt_DiskDetail;
        private System.Windows.Forms.CheckBox ck_Rollback;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.Button btn_ClearPN;
        private System.Windows.Forms.Button button1;
    }
}