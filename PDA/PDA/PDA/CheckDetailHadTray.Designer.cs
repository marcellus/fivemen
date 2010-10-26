namespace PDA
{
    partial class CheckDetailHadTray
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
            this.txt_Tray = new System.Windows.Forms.TextBox();
            this.txt_Loc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ck_Rollback = new System.Windows.Forms.CheckBox();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.btn_ClearLoc = new System.Windows.Forms.Button();
            this.dg_ScanList = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Tray
            // 
            this.txt_Tray.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Tray.Location = new System.Drawing.Point(91, 28);
            this.txt_Tray.Name = "txt_Tray";
            this.txt_Tray.Size = new System.Drawing.Size(141, 20);
            this.txt_Tray.TabIndex = 2;
            this.txt_Tray.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Tray_KeyUp);
            // 
            // txt_Loc
            // 
            this.txt_Loc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Loc.Location = new System.Drawing.Point(91, 4);
            this.txt_Loc.Name = "txt_Loc";
            this.txt_Loc.Size = new System.Drawing.Size(109, 20);
            this.txt_Loc.TabIndex = 1;
            this.txt_Loc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Loc_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.Text = "托盘号：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.Text = "库位：";
            // 
            // ck_Rollback
            // 
            this.ck_Rollback.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.ck_Rollback.ForeColor = System.Drawing.Color.Red;
            this.ck_Rollback.Location = new System.Drawing.Point(87, 54);
            this.ck_Rollback.Name = "ck_Rollback";
            this.ck_Rollback.Size = new System.Drawing.Size(122, 20);
            this.ck_Rollback.TabIndex = 3;
            this.ck_Rollback.Text = "撤销产品扫描";
            this.ck_Rollback.CheckStateChanged += new System.EventHandler(this.ck_Rollback_CheckStateChanged);
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(19, 234);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(72, 25);
            this.btn_TempSave.TabIndex = 4;
            this.btn_TempSave.Text = "临时保存";
            // 
            // btn_Finish
            // 
            this.btn_Finish.BackColor = System.Drawing.Color.Beige;
            this.btn_Finish.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Finish.Location = new System.Drawing.Point(157, 234);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(61, 25);
            this.btn_Finish.TabIndex = 5;
            this.btn_Finish.Text = "提交";
            // 
            // btn_ClearLoc
            // 
            this.btn_ClearLoc.BackColor = System.Drawing.Color.Beige;
            this.btn_ClearLoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_ClearLoc.Location = new System.Drawing.Point(206, 3);
            this.btn_ClearLoc.Name = "btn_ClearLoc";
            this.btn_ClearLoc.Size = new System.Drawing.Size(25, 22);
            this.btn_ClearLoc.TabIndex = 6;
            this.btn_ClearLoc.Text = "X";
            this.btn_ClearLoc.Click += new System.EventHandler(this.btn_ClearLoc_Click);
            // 
            // dg_ScanList
            // 
            this.dg_ScanList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_ScanList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.dg_ScanList.Location = new System.Drawing.Point(10, 82);
            this.dg_ScanList.Name = "dg_ScanList";
            this.dg_ScanList.Size = new System.Drawing.Size(217, 146);
            this.dg_ScanList.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(10, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.Text = "扫描信息：";
            // 
            // CheckDetailHadTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.dg_ScanList);
            this.Controls.Add(this.btn_ClearLoc);
            this.Controls.Add(this.btn_Finish);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.ck_Rollback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Loc);
            this.Controls.Add(this.txt_Tray);
            this.Controls.Add(this.label3);
            this.Name = "CheckDetailHadTray";
            this.Text = "有托盘点";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Tray;
        private System.Windows.Forms.TextBox txt_Loc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ck_Rollback;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.Button btn_ClearLoc;
        private System.Windows.Forms.DataGrid dg_ScanList;
        private System.Windows.Forms.Label label3;
    }
}