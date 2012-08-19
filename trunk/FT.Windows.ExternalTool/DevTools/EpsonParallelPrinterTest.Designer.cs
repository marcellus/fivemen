namespace FT.Windows.ExternalTool.DevTools
{
    partial class EpsonParallelPrinterTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|64",
            "初始化"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|64",
            "设置字体"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|33|(0-7)",
            "走纸"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|106|n",
            "退纸"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "10|10",
            "打印一行"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|105",
            "全切"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|109",
            "半切"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "28|38",
            "进入汉字打印"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "28|46",
            "退出汉字"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "29|40|70|4|0|1|48|4|0",
            "黑标有效"}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "29|86",
            "黑标切纸定位"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|12",
            "黑标定位"}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|116|n",
            "选择字符集"}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|60",
            "打印头归位"}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "29|86|66|1",
            "走纸到切纸点"}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|100|n",
            "进纸N行"}, -1);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "27|101|n",
            "退纸N行"}, -1);
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "初始化",
            "27 64"}, -1);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbOperationHint = new System.Windows.Forms.Label();
            this.btnHotGetState = new System.Windows.Forms.Button();
            this.btnHotCloseDevice = new System.Windows.Forms.Button();
            this.btnHotOpenDevice = new System.Windows.Forms.Button();
            this.txtStopBit = new System.Windows.Forms.TextBox();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.txtHotPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbPrintHint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEndPrint = new System.Windows.Forms.Button();
            this.btnPrintCommandOnce = new System.Windows.Forms.Button();
            this.btnBeginPrint = new System.Windows.Forms.Button();
            this.txtPrintThreadSeconds = new System.Windows.Forms.TextBox();
            this.txtPrintTotalNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvCommonPrintCommand = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvCommandLists = new System.Windows.Forms.ListView();
            this.txtPrintCommand = new System.Windows.Forms.TextBox();
            this.btnAddToPrintQuence = new System.Windows.Forms.Button();
            this.btnRemoveFromQuence = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtReturnData = new System.Windows.Forms.TextBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "指令";
            columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "内容";
            columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "指令内容";
            columnHeader3.Width = 287;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbOperationHint);
            this.groupBox1.Controls.Add(this.btnHotGetState);
            this.groupBox1.Controls.Add(this.btnHotCloseDevice);
            this.groupBox1.Controls.Add(this.btnHotOpenDevice);
            this.groupBox1.Controls.Add(this.txtStopBit);
            this.groupBox1.Controls.Add(this.txtDataBits);
            this.groupBox1.Controls.Add(this.txtParity);
            this.groupBox1.Controls.Add(this.txtBaudRate);
            this.groupBox1.Controls.Add(this.txtHotPort);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "并口配置";
            // 
            // lbOperationHint
            // 
            this.lbOperationHint.AutoSize = true;
            this.lbOperationHint.Location = new System.Drawing.Point(7, 55);
            this.lbOperationHint.Name = "lbOperationHint";
            this.lbOperationHint.Size = new System.Drawing.Size(0, 12);
            this.lbOperationHint.TabIndex = 16;
            // 
            // btnHotGetState
            // 
            this.btnHotGetState.Enabled = false;
            this.btnHotGetState.Location = new System.Drawing.Point(327, 15);
            this.btnHotGetState.Name = "btnHotGetState";
            this.btnHotGetState.Size = new System.Drawing.Size(75, 23);
            this.btnHotGetState.TabIndex = 4;
            this.btnHotGetState.Text = "获取状态";
            this.btnHotGetState.UseVisualStyleBackColor = true;
            // 
            // btnHotCloseDevice
            // 
            this.btnHotCloseDevice.Enabled = false;
            this.btnHotCloseDevice.Location = new System.Drawing.Point(223, 15);
            this.btnHotCloseDevice.Name = "btnHotCloseDevice";
            this.btnHotCloseDevice.Size = new System.Drawing.Size(75, 23);
            this.btnHotCloseDevice.TabIndex = 3;
            this.btnHotCloseDevice.Text = "关闭并口";
            this.btnHotCloseDevice.UseVisualStyleBackColor = true;
            this.btnHotCloseDevice.Click += new System.EventHandler(this.btnHotCloseDevice_Click);
            // 
            // btnHotOpenDevice
            // 
            this.btnHotOpenDevice.Location = new System.Drawing.Point(108, 15);
            this.btnHotOpenDevice.Name = "btnHotOpenDevice";
            this.btnHotOpenDevice.Size = new System.Drawing.Size(75, 23);
            this.btnHotOpenDevice.TabIndex = 2;
            this.btnHotOpenDevice.Text = "打开并口";
            this.btnHotOpenDevice.UseVisualStyleBackColor = true;
            this.btnHotOpenDevice.Click += new System.EventHandler(this.btnHotOpenDevice_Click);
            // 
            // txtStopBit
            // 
            this.txtStopBit.Location = new System.Drawing.Point(292, 41);
            this.txtStopBit.Name = "txtStopBit";
            this.txtStopBit.Size = new System.Drawing.Size(35, 21);
            this.txtStopBit.TabIndex = 1;
            this.txtStopBit.Text = "1";
            // 
            // txtDataBits
            // 
            this.txtDataBits.Location = new System.Drawing.Point(210, 41);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Size = new System.Drawing.Size(35, 21);
            this.txtDataBits.TabIndex = 1;
            this.txtDataBits.Text = "8";
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(142, 41);
            this.txtParity.Name = "txtParity";
            this.txtParity.Size = new System.Drawing.Size(16, 21);
            this.txtParity.TabIndex = 1;
            this.txtParity.Text = "0";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(49, 41);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(35, 21);
            this.txtBaudRate.TabIndex = 1;
            this.txtBaudRate.Text = "38400";
            // 
            // txtHotPort
            // 
            this.txtHotPort.Location = new System.Drawing.Point(42, 18);
            this.txtHotPort.Name = "txtHotPort";
            this.txtHotPort.Size = new System.Drawing.Size(35, 21);
            this.txtHotPort.TabIndex = 1;
            this.txtHotPort.Text = "lpt1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "停止位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "数据位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "奇偶校验";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "并口";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbPrintHint);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnEndPrint);
            this.groupBox3.Controls.Add(this.btnPrintCommandOnce);
            this.groupBox3.Controls.Add(this.btnBeginPrint);
            this.groupBox3.Controls.Add(this.txtPrintThreadSeconds);
            this.groupBox3.Controls.Add(this.txtPrintTotalNum);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(33, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 92);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "打印机压力测试";
            // 
            // lbPrintHint
            // 
            this.lbPrintHint.AutoSize = true;
            this.lbPrintHint.Location = new System.Drawing.Point(13, 67);
            this.lbPrintHint.Name = "lbPrintHint";
            this.lbPrintHint.Size = new System.Drawing.Size(0, 12);
            this.lbPrintHint.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "秒";
            // 
            // btnEndPrint
            // 
            this.btnEndPrint.Enabled = false;
            this.btnEndPrint.Location = new System.Drawing.Point(118, 29);
            this.btnEndPrint.Name = "btnEndPrint";
            this.btnEndPrint.Size = new System.Drawing.Size(75, 23);
            this.btnEndPrint.TabIndex = 13;
            this.btnEndPrint.Text = "停止打印";
            this.btnEndPrint.UseVisualStyleBackColor = true;
            this.btnEndPrint.Click += new System.EventHandler(this.btnEndPrint_Click);
            // 
            // btnPrintCommandOnce
            // 
            this.btnPrintCommandOnce.Location = new System.Drawing.Point(223, 62);
            this.btnPrintCommandOnce.Name = "btnPrintCommandOnce";
            this.btnPrintCommandOnce.Size = new System.Drawing.Size(111, 23);
            this.btnPrintCommandOnce.TabIndex = 13;
            this.btnPrintCommandOnce.Text = "打印一次队列";
            this.btnPrintCommandOnce.UseVisualStyleBackColor = true;
            this.btnPrintCommandOnce.Click += new System.EventHandler(this.btnPrintCommandOnce_Click);
            // 
            // btnBeginPrint
            // 
            this.btnBeginPrint.Enabled = false;
            this.btnBeginPrint.Location = new System.Drawing.Point(15, 29);
            this.btnBeginPrint.Name = "btnBeginPrint";
            this.btnBeginPrint.Size = new System.Drawing.Size(75, 23);
            this.btnBeginPrint.TabIndex = 13;
            this.btnBeginPrint.Text = "开始打印";
            this.btnBeginPrint.UseVisualStyleBackColor = true;
            this.btnBeginPrint.Click += new System.EventHandler(this.btnBeginPrint_Click);
            // 
            // txtPrintThreadSeconds
            // 
            this.txtPrintThreadSeconds.Location = new System.Drawing.Point(393, 26);
            this.txtPrintThreadSeconds.Name = "txtPrintThreadSeconds";
            this.txtPrintThreadSeconds.Size = new System.Drawing.Size(40, 21);
            this.txtPrintThreadSeconds.TabIndex = 12;
            this.txtPrintThreadSeconds.Text = "3";
            // 
            // txtPrintTotalNum
            // 
            this.txtPrintTotalNum.Location = new System.Drawing.Point(277, 25);
            this.txtPrintTotalNum.Name = "txtPrintTotalNum";
            this.txtPrintTotalNum.Size = new System.Drawing.Size(40, 21);
            this.txtPrintTotalNum.TabIndex = 12;
            this.txtPrintTotalNum.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "打印间隔";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "打印页数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvCommonPrintCommand);
            this.groupBox2.Location = new System.Drawing.Point(33, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 249);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "常用打印指令";
            // 
            // lvCommonPrintCommand
            // 
            this.lvCommonPrintCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2});
            this.lvCommonPrintCommand.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17});
            this.lvCommonPrintCommand.Location = new System.Drawing.Point(9, 21);
            this.lvCommonPrintCommand.MultiSelect = false;
            this.lvCommonPrintCommand.Name = "lvCommonPrintCommand";
            this.lvCommonPrintCommand.Size = new System.Drawing.Size(168, 209);
            this.lvCommonPrintCommand.TabIndex = 0;
            this.lvCommonPrintCommand.UseCompatibleStateImageBehavior = false;
            this.lvCommonPrintCommand.View = System.Windows.Forms.View.Details;
            this.lvCommonPrintCommand.SelectedIndexChanged += new System.EventHandler(this.lvCommonPrintCommand_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvCommandLists);
            this.groupBox4.Location = new System.Drawing.Point(237, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 249);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "打印模板指令队列";
            // 
            // lvCommandLists
            // 
            this.lvCommandLists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader3});
            this.lvCommandLists.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem18});
            this.lvCommandLists.Location = new System.Drawing.Point(6, 20);
            this.lvCommandLists.MultiSelect = false;
            this.lvCommandLists.Name = "lvCommandLists";
            this.lvCommandLists.Size = new System.Drawing.Size(247, 209);
            this.lvCommandLists.TabIndex = 0;
            this.lvCommandLists.UseCompatibleStateImageBehavior = false;
            this.lvCommandLists.View = System.Windows.Forms.View.Details;
            // 
            // txtPrintCommand
            // 
            this.txtPrintCommand.Location = new System.Drawing.Point(33, 259);
            this.txtPrintCommand.Multiline = true;
            this.txtPrintCommand.Name = "txtPrintCommand";
            this.txtPrintCommand.Size = new System.Drawing.Size(343, 50);
            this.txtPrintCommand.TabIndex = 17;
            // 
            // btnAddToPrintQuence
            // 
            this.btnAddToPrintQuence.Location = new System.Drawing.Point(394, 257);
            this.btnAddToPrintQuence.Name = "btnAddToPrintQuence";
            this.btnAddToPrintQuence.Size = new System.Drawing.Size(105, 23);
            this.btnAddToPrintQuence.TabIndex = 13;
            this.btnAddToPrintQuence.Text = "增加到队列中";
            this.btnAddToPrintQuence.UseVisualStyleBackColor = true;
            this.btnAddToPrintQuence.Click += new System.EventHandler(this.btnAddToPrintQuence_Click);
            // 
            // btnRemoveFromQuence
            // 
            this.btnRemoveFromQuence.Location = new System.Drawing.Point(394, 283);
            this.btnRemoveFromQuence.Name = "btnRemoveFromQuence";
            this.btnRemoveFromQuence.Size = new System.Drawing.Size(105, 23);
            this.btnRemoveFromQuence.TabIndex = 13;
            this.btnRemoveFromQuence.Text = "从队列中移除";
            this.btnRemoveFromQuence.UseVisualStyleBackColor = true;
            this.btnRemoveFromQuence.Click += new System.EventHandler(this.btnRemoveFromQuence_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtReturnData);
            this.groupBox5.Location = new System.Drawing.Point(33, 187);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(466, 64);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "并口返回数据";
            // 
            // txtReturnData
            // 
            this.txtReturnData.Location = new System.Drawing.Point(6, 14);
            this.txtReturnData.Multiline = true;
            this.txtReturnData.Name = "txtReturnData";
            this.txtReturnData.ReadOnly = true;
            this.txtReturnData.Size = new System.Drawing.Size(451, 44);
            this.txtReturnData.TabIndex = 17;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(394, 309);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(105, 23);
            this.btnClearAll.TabIndex = 13;
            this.btnClearAll.Text = "清空队列";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // EpsonParallelPrinterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 600);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtPrintCommand);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnRemoveFromQuence);
            this.Controls.Add(this.btnAddToPrintQuence);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "EpsonParallelPrinterTest";
            this.Text = "EpsonParallelPrinterTest";
            this.Load += new System.EventHandler(this.EpsonParallelPrinterTest_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EpsonParallelPrinterTest_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHotGetState;
        private System.Windows.Forms.Button btnHotCloseDevice;
        private System.Windows.Forms.Button btnHotOpenDevice;
        private System.Windows.Forms.TextBox txtHotPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEndPrint;
        private System.Windows.Forms.Button btnBeginPrint;
        private System.Windows.Forms.TextBox txtPrintThreadSeconds;
        private System.Windows.Forms.TextBox txtPrintTotalNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPrintHint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPrintCommand;
        private System.Windows.Forms.Button btnAddToPrintQuence;
        private System.Windows.Forms.ListView lvCommonPrintCommand;
        private System.Windows.Forms.ListView lvCommandLists;
        private System.Windows.Forms.Label lbOperationHint;
        private System.Windows.Forms.Button btnPrintCommandOnce;
        private System.Windows.Forms.Button btnRemoveFromQuence;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtReturnData;
        private System.Windows.Forms.TextBox txtStopBit;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.Button btnClearAll;
    }
}