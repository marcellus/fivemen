namespace PDA
{
    partial class MoveLocDetail
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
            this.btn_Finish = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_OldLoc = new System.Windows.Forms.TextBox();
            this.txt_Product = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Count = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NewLoc = new System.Windows.Forms.TextBox();
            this.dg_ScanList = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Rollback = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_RollbackTray = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TrayNo = new System.Windows.Forms.TextBox();
            this.txt_NewTrayLoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Finish
            // 
            this.btn_Finish.BackColor = System.Drawing.Color.Beige;
            this.btn_Finish.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btn_Finish.Location = new System.Drawing.Point(94, 241);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(64, 22);
            this.btn_Finish.TabIndex = 7;
            this.btn_Finish.Text = "提交";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.Text = "原库位：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.Text = "产品：";
            // 
            // txt_OldLoc
            // 
            this.txt_OldLoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_OldLoc.Location = new System.Drawing.Point(62, 0);
            this.txt_OldLoc.Name = "txt_OldLoc";
            this.txt_OldLoc.Size = new System.Drawing.Size(168, 20);
            this.txt_OldLoc.TabIndex = 0;
            this.txt_OldLoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_OldLoc_KeyUp);
            // 
            // txt_Product
            // 
            this.txt_Product.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Product.Location = new System.Drawing.Point(62, 26);
            this.txt_Product.Name = "txt_Product";
            this.txt_Product.Size = new System.Drawing.Size(96, 20);
            this.txt_Product.TabIndex = 1;
            this.txt_Product.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Product_KeyUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(161, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.Text = "数量：";
            // 
            // txt_Count
            // 
            this.txt_Count.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Count.Location = new System.Drawing.Point(203, 26);
            this.txt_Count.Name = "txt_Count";
            this.txt_Count.Size = new System.Drawing.Size(27, 20);
            this.txt_Count.TabIndex = 2;
            this.txt_Count.Text = "1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(2, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 22);
            this.button1.TabIndex = 6;
            this.button1.Text = "临时保存";
            this.button1.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.Text = "新库位：";
            // 
            // txt_NewLoc
            // 
            this.txt_NewLoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_NewLoc.Location = new System.Drawing.Point(62, 55);
            this.txt_NewLoc.Name = "txt_NewLoc";
            this.txt_NewLoc.Size = new System.Drawing.Size(168, 20);
            this.txt_NewLoc.TabIndex = 3;
            this.txt_NewLoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_NewLoc_KeyUp);
            // 
            // dg_ScanList
            // 
            this.dg_ScanList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_ScanList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.dg_ScanList.Location = new System.Drawing.Point(-1, 133);
            this.dg_ScanList.Name = "dg_ScanList";
            this.dg_ScanList.RowHeadersVisible = false;
            this.dg_ScanList.Size = new System.Drawing.Size(239, 102);
            this.dg_ScanList.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "扫描记录：";
            // 
            // cb_Rollback
            // 
            this.cb_Rollback.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_Rollback.ForeColor = System.Drawing.Color.Red;
            this.cb_Rollback.Location = new System.Drawing.Point(125, 80);
            this.cb_Rollback.Name = "cb_Rollback";
            this.cb_Rollback.Size = new System.Drawing.Size(110, 20);
            this.cb_Rollback.TabIndex = 4;
            this.cb_Rollback.Text = "撤销产品扫描";
            this.cb_Rollback.CheckStateChanged += new System.EventHandler(this.ck_Rollback_CheckStateChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(239, 131);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cb_Rollback);
            this.tabPage1.Controls.Add(this.txt_Product);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_OldLoc);
            this.tabPage1.Controls.Add(this.txt_Count);
            this.tabPage1.Controls.Add(this.txt_NewLoc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(231, 104);
            this.tabPage1.Text = "按货";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_RollbackTray);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txt_TrayNo);
            this.tabPage2.Controls.Add(this.txt_NewTrayLoc);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(231, 104);
            this.tabPage2.Text = "按托";
            // 
            // cb_RollbackTray
            // 
            this.cb_RollbackTray.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cb_RollbackTray.ForeColor = System.Drawing.Color.Red;
            this.cb_RollbackTray.Location = new System.Drawing.Point(81, 63);
            this.cb_RollbackTray.Name = "cb_RollbackTray";
            this.cb_RollbackTray.Size = new System.Drawing.Size(110, 20);
            this.cb_RollbackTray.TabIndex = 9;
            this.cb_RollbackTray.Text = "撤销产品扫描";
            this.cb_RollbackTray.CheckStateChanged += new System.EventHandler(this.cb_RollbackTray_CheckStateChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(0, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.Text = "托盘号：";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(0, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 19);
            this.label7.Text = "目的库位：";
            // 
            // txt_TrayNo
            // 
            this.txt_TrayNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_TrayNo.Location = new System.Drawing.Point(81, 8);
            this.txt_TrayNo.Name = "txt_TrayNo";
            this.txt_TrayNo.Size = new System.Drawing.Size(141, 20);
            this.txt_TrayNo.TabIndex = 7;
            this.txt_TrayNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TrayNo_KeyUp);
            // 
            // txt_NewTrayLoc
            // 
            this.txt_NewTrayLoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txt_NewTrayLoc.Location = new System.Drawing.Point(81, 32);
            this.txt_NewTrayLoc.Name = "txt_NewTrayLoc";
            this.txt_NewTrayLoc.Size = new System.Drawing.Size(141, 20);
            this.txt_NewTrayLoc.TabIndex = 8;
            this.txt_NewTrayLoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_NewTrayLoc_KeyUp);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(0, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.Text = "扫描记录：";
            // 
            // MoveLocDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dg_ScanList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Finish);
            this.Name = "MoveLocDetail";
            this.Text = "移库";
            this.Load += new System.EventHandler(this.MoveLocDetail_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_OldLoc;
        private System.Windows.Forms.TextBox txt_Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Count;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NewLoc;
        private System.Windows.Forms.DataGrid dg_ScanList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_Rollback;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cb_RollbackTray;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TrayNo;
        private System.Windows.Forms.TextBox txt_NewTrayLoc;
        private System.Windows.Forms.Label label8;
    }
}