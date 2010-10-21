namespace PDA
{
    partial class FeedBackScan
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ClearLoc = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.cb_Rollback = new System.Windows.Forms.CheckBox();
            this.txt_Detail = new System.Windows.Forms.TextBox();
            this.txt_Num = new System.Windows.Forms.TextBox();
            this.txt_ParentDisk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(7, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 25);
            this.button1.TabIndex = 31;
            this.button1.Text = "查看";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ClearLoc
            // 
            this.btn_ClearLoc.BackColor = System.Drawing.Color.Beige;
            this.btn_ClearLoc.Location = new System.Drawing.Point(205, 6);
            this.btn_ClearLoc.Name = "btn_ClearLoc";
            this.btn_ClearLoc.Size = new System.Drawing.Size(25, 22);
            this.btn_ClearLoc.TabIndex = 30;
            this.btn_ClearLoc.Text = "X";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Beige;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Save.Location = new System.Drawing.Point(163, 240);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(72, 25);
            this.btn_Save.TabIndex = 29;
            this.btn_Save.Text = "完成";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click_1);
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(85, 240);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(72, 25);
            this.btn_TempSave.TabIndex = 28;
            this.btn_TempSave.Text = "临时保存";
            // 
            // cb_Rollback
            // 
            this.cb_Rollback.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Rollback.ForeColor = System.Drawing.Color.Red;
            this.cb_Rollback.Location = new System.Drawing.Point(3, 56);
            this.cb_Rollback.Name = "cb_Rollback";
            this.cb_Rollback.Size = new System.Drawing.Size(113, 20);
            this.cb_Rollback.TabIndex = 27;
            this.cb_Rollback.Text = "撤销产品扫描";
            // 
            // txt_Detail
            // 
            this.txt_Detail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Detail.Location = new System.Drawing.Point(3, 82);
            this.txt_Detail.Multiline = true;
            this.txt_Detail.Name = "txt_Detail";
            this.txt_Detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Detail.Size = new System.Drawing.Size(232, 156);
            this.txt_Detail.TabIndex = 26;
            // 
            // txt_Num
            // 
            this.txt_Num.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Num.Location = new System.Drawing.Point(72, 30);
            this.txt_Num.Name = "txt_Num";
            this.txt_Num.Size = new System.Drawing.Size(158, 21);
            this.txt_Num.TabIndex = 25;
            // 
            // txt_ParentDisk
            // 
            this.txt_ParentDisk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_ParentDisk.Location = new System.Drawing.Point(72, 6);
            this.txt_ParentDisk.Name = "txt_ParentDisk";
            this.txt_ParentDisk.Size = new System.Drawing.Size(127, 21);
            this.txt_ParentDisk.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "产品：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "托盘号：";
            // 
            // FeedBackScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ClearLoc);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.cb_Rollback);
            this.Controls.Add(this.txt_Detail);
            this.Controls.Add(this.txt_Num);
            this.Controls.Add(this.txt_ParentDisk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FeedBackScan";
            this.Text = "解托";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_ClearLoc;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.CheckBox cb_Rollback;
        private System.Windows.Forms.TextBox txt_Detail;
        private System.Windows.Forms.TextBox txt_Num;
        private System.Windows.Forms.TextBox txt_ParentDisk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}