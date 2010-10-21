namespace PDA
{
    partial class PickDetail
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
            this.txt_Disk = new System.Windows.Forms.TextBox();
            this.txt_Detail = new System.Windows.Forms.TextBox();
            this.cb_Rollback = new System.Windows.Forms.CheckBox();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_ClearPN = new System.Windows.Forms.Button();
            this.txt_PN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.Text = "产品条码：";
            // 
            // txt_Disk
            // 
            this.txt_Disk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Disk.Location = new System.Drawing.Point(91, 46);
            this.txt_Disk.Name = "txt_Disk";
            this.txt_Disk.Size = new System.Drawing.Size(137, 21);
            this.txt_Disk.TabIndex = 4;
            this.txt_Disk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Disk_KeyUp);
            // 
            // txt_Detail
            // 
            this.txt_Detail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Detail.Location = new System.Drawing.Point(6, 114);
            this.txt_Detail.Multiline = true;
            this.txt_Detail.Name = "txt_Detail";
            this.txt_Detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Detail.Size = new System.Drawing.Size(222, 122);
            this.txt_Detail.TabIndex = 8;
            // 
            // cb_Rollback
            // 
            this.cb_Rollback.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Rollback.ForeColor = System.Drawing.Color.Red;
            this.cb_Rollback.Location = new System.Drawing.Point(6, 88);
            this.cb_Rollback.Name = "cb_Rollback";
            this.cb_Rollback.Size = new System.Drawing.Size(146, 20);
            this.cb_Rollback.TabIndex = 9;
            this.cb_Rollback.Text = "撤销产品扫描";
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(80, 242);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(72, 22);
            this.btn_TempSave.TabIndex = 10;
            this.btn_TempSave.Text = "临时保存";
            this.btn_TempSave.Click += new System.EventHandler(this.btn_TempSave_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Beige;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Save.Location = new System.Drawing.Point(170, 242);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(55, 22);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "提交";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_ClearPN
            // 
            this.btn_ClearPN.BackColor = System.Drawing.Color.Beige;
            this.btn_ClearPN.Location = new System.Drawing.Point(201, 13);
            this.btn_ClearPN.Name = "btn_ClearPN";
            this.btn_ClearPN.Size = new System.Drawing.Size(24, 22);
            this.btn_ClearPN.TabIndex = 21;
            this.btn_ClearPN.Text = "X";
            // 
            // txt_PN
            // 
            this.txt_PN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_PN.Location = new System.Drawing.Point(91, 12);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Size = new System.Drawing.Size(104, 21);
            this.txt_PN.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.Text = "P/N:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(6, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 22);
            this.button1.TabIndex = 39;
            this.button1.Text = "查看";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PickDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ClearPN);
            this.Controls.Add(this.txt_PN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.cb_Rollback);
            this.Controls.Add(this.txt_Detail);
            this.Controls.Add(this.txt_Disk);
            this.Controls.Add(this.label1);
            this.Name = "PickDetail";
            this.Text = "出货扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Disk;
        private System.Windows.Forms.TextBox txt_Detail;
        private System.Windows.Forms.CheckBox cb_Rollback;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_ClearPN;
        private System.Windows.Forms.TextBox txt_PN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}