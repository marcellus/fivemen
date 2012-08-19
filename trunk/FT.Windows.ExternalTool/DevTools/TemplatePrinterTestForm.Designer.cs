namespace FT.Windows.ExternalTool.DevTools
{
    partial class TemplatePrinterTestForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbHint = new System.Windows.Forms.Label();
            this.txtPageWidth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrintTotalNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnEndPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPageHeight = new System.Windows.Forms.TextBox();
            this.btnBeginPrint = new System.Windows.Forms.Button();
            this.txtPrintThreadSeconds = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRemovePrintTemplate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAddToPrintTemplate = new System.Windows.Forms.Button();
            this.cbFonts = new System.Windows.Forms.ComboBox();
            this.txtFontSize = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.txtTop = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.txtLeft = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreview = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemovePrintTemplate);
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddToPrintTemplate);
            this.splitContainer1.Panel1.Controls.Add(this.cbFonts);
            this.splitContainer1.Panel1.Controls.Add(this.txtFontSize);
            this.splitContainer1.Panel1.Controls.Add(this.txtTop);
            this.splitContainer1.Panel1.Controls.Add(this.txtLeft);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtContent);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(795, 431);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lbHint);
            this.groupBox1.Controls.Add(this.txtPageWidth);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPrintTotalNum);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnEndPrint);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtPageHeight);
            this.groupBox1.Controls.Add(this.btnBeginPrint);
            this.groupBox1.Controls.Add(this.txtPrintThreadSeconds);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(454, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 184);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "全局打印配置";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "页面宽度";
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Location = new System.Drawing.Point(9, 166);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(0, 12);
            this.lbHint.TabIndex = 26;
            // 
            // txtPageWidth
            // 
            this.txtPageWidth.Location = new System.Drawing.Point(116, 30);
            this.txtPageWidth.Name = "txtPageWidth";
            this.txtPageWidth.Size = new System.Drawing.Size(52, 21);
            this.txtPageWidth.TabIndex = 20;
            this.txtPageWidth.Text = "600";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "打印页数";
            // 
            // txtPrintTotalNum
            // 
            this.txtPrintTotalNum.Location = new System.Drawing.Point(116, 110);
            this.txtPrintTotalNum.Name = "txtPrintTotalNum";
            this.txtPrintTotalNum.Size = new System.Drawing.Size(52, 21);
            this.txtPrintTotalNum.TabIndex = 20;
            this.txtPrintTotalNum.Text = "5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "页面长度";
            // 
            // btnEndPrint
            // 
            this.btnEndPrint.Enabled = false;
            this.btnEndPrint.Location = new System.Drawing.Point(216, 143);
            this.btnEndPrint.Name = "btnEndPrint";
            this.btnEndPrint.Size = new System.Drawing.Size(75, 23);
            this.btnEndPrint.TabIndex = 25;
            this.btnEndPrint.Text = "停止打印";
            this.btnEndPrint.UseVisualStyleBackColor = true;
            this.btnEndPrint.Click += new System.EventHandler(this.btnEndPrint_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "打印间隔";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(174, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "px";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(174, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "px";
            // 
            // txtPageHeight
            // 
            this.txtPageHeight.Location = new System.Drawing.Point(116, 60);
            this.txtPageHeight.Name = "txtPageHeight";
            this.txtPageHeight.Size = new System.Drawing.Size(52, 21);
            this.txtPageHeight.TabIndex = 22;
            this.txtPageHeight.Text = "400";
            // 
            // btnBeginPrint
            // 
            this.btnBeginPrint.Location = new System.Drawing.Point(216, 108);
            this.btnBeginPrint.Name = "btnBeginPrint";
            this.btnBeginPrint.Size = new System.Drawing.Size(75, 23);
            this.btnBeginPrint.TabIndex = 24;
            this.btnBeginPrint.Text = "开始打印";
            this.btnBeginPrint.UseVisualStyleBackColor = true;
            this.btnBeginPrint.Click += new System.EventHandler(this.btnBeginPrint_Click);
            // 
            // txtPrintThreadSeconds
            // 
            this.txtPrintThreadSeconds.Location = new System.Drawing.Point(116, 140);
            this.txtPrintThreadSeconds.Name = "txtPrintThreadSeconds";
            this.txtPrintThreadSeconds.Size = new System.Drawing.Size(52, 21);
            this.txtPrintThreadSeconds.TabIndex = 22;
            this.txtPrintThreadSeconds.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "秒";
            // 
            // btnRemovePrintTemplate
            // 
            this.btnRemovePrintTemplate.Location = new System.Drawing.Point(120, 96);
            this.btnRemovePrintTemplate.Name = "btnRemovePrintTemplate";
            this.btnRemovePrintTemplate.Size = new System.Drawing.Size(97, 82);
            this.btnRemovePrintTemplate.TabIndex = 5;
            this.btnRemovePrintTemplate.Text = "删除所选打印模板";
            this.btnRemovePrintTemplate.UseVisualStyleBackColor = true;
            this.btnRemovePrintTemplate.Click += new System.EventHandler(this.btnRemovePrintTemplate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(226, 96);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 82);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印模板测试";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAddToPrintTemplate
            // 
            this.btnAddToPrintTemplate.Location = new System.Drawing.Point(14, 96);
            this.btnAddToPrintTemplate.Name = "btnAddToPrintTemplate";
            this.btnAddToPrintTemplate.Size = new System.Drawing.Size(97, 82);
            this.btnAddToPrintTemplate.TabIndex = 5;
            this.btnAddToPrintTemplate.Text = "添加到打印模板";
            this.btnAddToPrintTemplate.UseVisualStyleBackColor = true;
            this.btnAddToPrintTemplate.Click += new System.EventHandler(this.btnAddToPrintTemplate_Click);
            // 
            // cbFonts
            // 
            this.cbFonts.FormattingEnabled = true;
            this.cbFonts.Location = new System.Drawing.Point(82, 70);
            this.cbFonts.Name = "cbFonts";
            this.cbFonts.Size = new System.Drawing.Size(209, 20);
            this.cbFonts.TabIndex = 4;
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(365, 71);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(45, 21);
            this.txtFontSize.TabIndex = 3;
            this.txtFontSize.Text = "11";
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(203, 42);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(45, 21);
            this.txtTop.TabIndex = 3;
            this.txtTop.Text = "100";
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(82, 43);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(45, 21);
            this.txtLeft.TabIndex = 3;
            this.txtLeft.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "pt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "字体大小";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "上边距";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "字体";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "左边距";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(82, 11);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(347, 21);
            this.txtContent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印内容";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Content,
            this.Left,
            this.Top,
            this.FontName,
            this.FontSize});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(795, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "打印内容";
            this.Content.Name = "Content";
            // 
            // Left
            // 
            this.Left.DataPropertyName = "Left";
            this.Left.HeaderText = "左边距";
            this.Left.Name = "Left";
            // 
            // Top
            // 
            this.Top.DataPropertyName = "Top";
            this.Top.HeaderText = "上边距";
            this.Top.Name = "Top";
            // 
            // FontName
            // 
            this.FontName.DataPropertyName = "FontName";
            this.FontName.HeaderText = "字体";
            this.FontName.Name = "FontName";
            // 
            // FontSize
            // 
            this.FontSize.DataPropertyName = "FontSize";
            this.FontSize.HeaderText = "字体大小";
            this.FontSize.Name = "FontSize";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(332, 96);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(97, 82);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "打印模板预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // TemplatePrinterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 431);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TemplatePrinterTestForm";
            this.Text = "模板打印测试";
            this.Load += new System.EventHandler(this.TemplatePrinterTestForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplatePrinterTestForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContent;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtLeft;
        private System.Windows.Forms.Label label3;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFonts;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtFontSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddToPrintTemplate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrintThreadSeconds;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrintTotalNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEndPrint;
        private System.Windows.Forms.Button btnBeginPrint;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPageWidth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPageHeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRemovePrintTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn Left;
        private System.Windows.Forms.DataGridViewTextBoxColumn Top;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontSize;
        private System.Windows.Forms.Button btnPreview;
    }
}