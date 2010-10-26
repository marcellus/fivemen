namespace PDA
{
    partial class JieTuoDetail
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
            this.btn_ClearTray = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_TempSave = new System.Windows.Forms.Button();
            this.cb_Rollback = new System.Windows.Forms.CheckBox();
            this.txt_SN = new System.Windows.Forms.TextBox();
            this.txt_TrayNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_ScanList = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_AllTary = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_ClearTray
            // 
            this.btn_ClearTray.BackColor = System.Drawing.Color.Beige;
            this.btn_ClearTray.Location = new System.Drawing.Point(205, 6);
            this.btn_ClearTray.Name = "btn_ClearTray";
            this.btn_ClearTray.Size = new System.Drawing.Size(25, 22);
            this.btn_ClearTray.TabIndex = 7;
            this.btn_ClearTray.Text = "X";
            this.btn_ClearTray.Click += new System.EventHandler(this.btn_ClearTray_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Beige;
            this.btn_Save.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Save.Location = new System.Drawing.Point(158, 240);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(72, 25);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "提交";
            // 
            // btn_TempSave
            // 
            this.btn_TempSave.BackColor = System.Drawing.Color.Beige;
            this.btn_TempSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_TempSave.Location = new System.Drawing.Point(21, 240);
            this.btn_TempSave.Name = "btn_TempSave";
            this.btn_TempSave.Size = new System.Drawing.Size(72, 25);
            this.btn_TempSave.TabIndex = 5;
            this.btn_TempSave.Text = "临时保存";
            // 
            // cb_Rollback
            // 
            this.cb_Rollback.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Rollback.ForeColor = System.Drawing.Color.Red;
            this.cb_Rollback.Location = new System.Drawing.Point(117, 57);
            this.cb_Rollback.Name = "cb_Rollback";
            this.cb_Rollback.Size = new System.Drawing.Size(113, 20);
            this.cb_Rollback.TabIndex = 4;
            this.cb_Rollback.Text = "撤销产品扫描";
            this.cb_Rollback.CheckStateChanged += new System.EventHandler(this.cb_Rollback_CheckStateChanged);
            // 
            // txt_SN
            // 
            this.txt_SN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_SN.Location = new System.Drawing.Point(72, 30);
            this.txt_SN.Name = "txt_SN";
            this.txt_SN.Size = new System.Drawing.Size(158, 21);
            this.txt_SN.TabIndex = 2;
            this.txt_SN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SN_KeyUp);
            // 
            // txt_TrayNo
            // 
            this.txt_TrayNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_TrayNo.Location = new System.Drawing.Point(72, 6);
            this.txt_TrayNo.Name = "txt_TrayNo";
            this.txt_TrayNo.Size = new System.Drawing.Size(127, 21);
            this.txt_TrayNo.TabIndex = 1;
            this.txt_TrayNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TrayNo_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "S/N：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "托盘号：";
            // 
            // dg_ScanList
            // 
            this.dg_ScanList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_ScanList.RowHeadersVisible = false;
            this.dg_ScanList.Location = new System.Drawing.Point(11, 101);
            this.dg_ScanList.Name = "dg_ScanList";
            this.dg_ScanList.Size = new System.Drawing.Size(217, 133);
            this.dg_ScanList.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.Text = "扫描信息：";
            // 
            // cb_AllTary
            // 
            this.cb_AllTary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_AllTary.Location = new System.Drawing.Point(6, 57);
            this.cb_AllTary.Name = "cb_AllTary";
            this.cb_AllTary.Size = new System.Drawing.Size(100, 20);
            this.cb_AllTary.TabIndex = 3;
            this.cb_AllTary.Text = "整盘解托";
            this.cb_AllTary.CheckStateChanged += new System.EventHandler(this.cb_AllTary_CheckStateChanged);
            // 
            // JieTuoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.cb_AllTary);
            this.Controls.Add(this.dg_ScanList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ClearTray);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_TempSave);
            this.Controls.Add(this.cb_Rollback);
            this.Controls.Add(this.txt_SN);
            this.Controls.Add(this.txt_TrayNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JieTuoDetail";
            this.Text = "解托";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ClearTray;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_TempSave;
        private System.Windows.Forms.CheckBox cb_Rollback;
        private System.Windows.Forms.TextBox txt_SN;
        private System.Windows.Forms.TextBox txt_TrayNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dg_ScanList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_AllTary;

    }
}