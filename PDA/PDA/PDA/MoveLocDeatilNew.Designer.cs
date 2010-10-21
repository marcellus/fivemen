namespace PDA
{
    partial class MoveLocDeatilNew
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
            this.btn_ClearLoc = new System.Windows.Forms.Button();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.ck_Rollback = new System.Windows.Forms.CheckBox();
            this.txt_Detail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Loc = new System.Windows.Forms.TextBox();
            this.txt_Disk = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ClearLoc
            // 
            this.btn_ClearLoc.BackColor = System.Drawing.Color.Beige;
            this.btn_ClearLoc.Location = new System.Drawing.Point(207, 7);
            this.btn_ClearLoc.Name = "btn_ClearLoc";
            this.btn_ClearLoc.Size = new System.Drawing.Size(25, 22);
            this.btn_ClearLoc.TabIndex = 19;
            this.btn_ClearLoc.Text = "X";
            this.btn_ClearLoc.Click += new System.EventHandler(this.btn_ClearLoc_Click);
            // 
            // btn_Finish
            // 
            this.btn_Finish.BackColor = System.Drawing.Color.Beige;
            this.btn_Finish.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Finish.Location = new System.Drawing.Point(167, 238);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(61, 25);
            this.btn_Finish.TabIndex = 18;
            this.btn_Finish.Text = "提交";
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // ck_Rollback
            // 
            this.ck_Rollback.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.ck_Rollback.ForeColor = System.Drawing.Color.Red;
            this.ck_Rollback.Location = new System.Drawing.Point(11, 63);
            this.ck_Rollback.Name = "ck_Rollback";
            this.ck_Rollback.Size = new System.Drawing.Size(110, 20);
            this.ck_Rollback.TabIndex = 17;
            this.ck_Rollback.Text = "撤销产品扫描";
            // 
            // txt_Detail
            // 
            this.txt_Detail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Detail.Location = new System.Drawing.Point(6, 89);
            this.txt_Detail.Multiline = true;
            this.txt_Detail.Name = "txt_Detail";
            this.txt_Detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Detail.Size = new System.Drawing.Size(227, 137);
            this.txt_Detail.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.Text = "库位：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.Text = "产品：";
            // 
            // txt_Loc
            // 
            this.txt_Loc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Loc.Location = new System.Drawing.Point(92, 8);
            this.txt_Loc.Name = "txt_Loc";
            this.txt_Loc.Size = new System.Drawing.Size(109, 21);
            this.txt_Loc.TabIndex = 14;
            this.txt_Loc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Loc_KeyUp);
            // 
            // txt_Disk
            // 
            this.txt_Disk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Disk.Location = new System.Drawing.Point(92, 32);
            this.txt_Disk.Name = "txt_Disk";
            this.txt_Disk.Size = new System.Drawing.Size(141, 21);
            this.txt_Disk.TabIndex = 15;
            this.txt_Disk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Disk_KeyUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(78, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 25);
            this.button1.TabIndex = 22;
            this.button1.Text = "临时保存";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Beige;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(11, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 25);
            this.button2.TabIndex = 23;
            this.button2.Text = "查看";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MoveLocDeatilNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ClearLoc);
            this.Controls.Add(this.btn_Finish);
            this.Controls.Add(this.ck_Rollback);
            this.Controls.Add(this.txt_Detail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Loc);
            this.Controls.Add(this.txt_Disk);
            this.Name = "MoveLocDeatilNew";
            this.Text = "新库位扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ClearLoc;
        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.CheckBox ck_Rollback;
        private System.Windows.Forms.TextBox txt_Detail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Loc;
        private System.Windows.Forms.TextBox txt_Disk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}