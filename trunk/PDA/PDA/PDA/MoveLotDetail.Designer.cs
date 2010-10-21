namespace PDA
{
    partial class MoveLotDetail
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
            this.txt_NewLot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Disk = new System.Windows.Forms.TextBox();
            this.txt_Detail = new System.Windows.Forms.TextBox();
            this.cb_RollBack = new System.Windows.Forms.CheckBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.Text = "新批次号：";
            // 
            // txt_NewLot
            // 
            this.txt_NewLot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_NewLot.Location = new System.Drawing.Point(90, 8);
            this.txt_NewLot.Name = "txt_NewLot";
            this.txt_NewLot.Size = new System.Drawing.Size(112, 21);
            this.txt_NewLot.TabIndex = 1;
            this.txt_NewLot.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_NewLot_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.Text = "料盘：";
            // 
            // txt_Disk
            // 
            this.txt_Disk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Disk.Location = new System.Drawing.Point(90, 35);
            this.txt_Disk.Name = "txt_Disk";
            this.txt_Disk.Size = new System.Drawing.Size(138, 21);
            this.txt_Disk.TabIndex = 4;
            this.txt_Disk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Disk_KeyUp);
            // 
            // txt_Detail
            // 
            this.txt_Detail.Location = new System.Drawing.Point(6, 64);
            this.txt_Detail.Multiline = true;
            this.txt_Detail.Name = "txt_Detail";
            this.txt_Detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Detail.Size = new System.Drawing.Size(222, 168);
            this.txt_Detail.TabIndex = 5;
            // 
            // cb_RollBack
            // 
            this.cb_RollBack.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.cb_RollBack.Location = new System.Drawing.Point(1, 244);
            this.cb_RollBack.Name = "cb_RollBack";
            this.cb_RollBack.Size = new System.Drawing.Size(91, 20);
            this.cb_RollBack.TabIndex = 6;
            this.cb_RollBack.Text = "撤销扫描";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Beige;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Save.Location = new System.Drawing.Point(156, 240);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(72, 25);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "完成";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.Beige;
            this.btn_Clear.Location = new System.Drawing.Point(208, 8);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(20, 22);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "X";
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // MoveLotDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cb_RollBack);
            this.Controls.Add(this.txt_Detail);
            this.Controls.Add(this.txt_Disk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_NewLot);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.Name = "MoveLotDetail";
            this.Text = "移储扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NewLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Disk;
        private System.Windows.Forms.TextBox txt_Detail;
        private System.Windows.Forms.CheckBox cb_RollBack;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Clear;
    }
}