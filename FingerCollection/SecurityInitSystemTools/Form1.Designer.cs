namespace SecurityInitSystemTools
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnInitSystemInfo = new System.Windows.Forms.Button();
            this.btnInitOperationSystem = new System.Windows.Forms.Button();
            this.btnInitNetwork = new System.Windows.Forms.Button();
            this.btnInitService = new System.Windows.Forms.Button();
            this.btnInitHardware = new System.Windows.Forms.Button();
            this.btnInitProcess = new System.Windows.Forms.Button();
            this.lbSystemVersion = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbSystem = new System.Windows.Forms.Label();
            this.lbSystemLabel = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.txtSystemInitLog = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtWzhInitLog = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbWzhVersions = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnWzhInit = new System.Windows.Forms.Button();
            this.btnWzhFolderSelector = new System.Windows.Forms.Button();
            this.txtWzhPath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtDBInitLog = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDBInit = new System.Windows.Forms.Button();
            this.txtDBUserPwd = new System.Windows.Forms.TextBox();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDBType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtKtIEInitLog = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbIEVersions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKtIEInit = new System.Windows.Forms.Button();
            this.btnKtIESelector = new System.Windows.Forms.Button();
            this.txtKtIEPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtKtBHOInitLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(630, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "操作系统初始化";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnInitSystemInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btnInitOperationSystem);
            this.splitContainer1.Panel1.Controls.Add(this.btnInitNetwork);
            this.splitContainer1.Panel1.Controls.Add(this.btnInitService);
            this.splitContainer1.Panel1.Controls.Add(this.btnInitHardware);
            this.splitContainer1.Panel1.Controls.Add(this.btnInitProcess);
            this.splitContainer1.Panel1.Controls.Add(this.lbSystemVersion);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.lbSystem);
            this.splitContainer1.Panel1.Controls.Add(this.lbSystemLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(624, 410);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnInitSystemInfo
            // 
            this.btnInitSystemInfo.Location = new System.Drawing.Point(458, 42);
            this.btnInitSystemInfo.Name = "btnInitSystemInfo";
            this.btnInitSystemInfo.Size = new System.Drawing.Size(141, 23);
            this.btnInitSystemInfo.TabIndex = 6;
            this.btnInitSystemInfo.Text = "初始化操作系统";
            this.btnInitSystemInfo.UseVisualStyleBackColor = true;
            this.btnInitSystemInfo.Click += new System.EventHandler(this.btnInitSystemInfo_Click);
            // 
            // btnInitOperationSystem
            // 
            this.btnInitOperationSystem.Location = new System.Drawing.Point(154, 40);
            this.btnInitOperationSystem.Name = "btnInitOperationSystem";
            this.btnInitOperationSystem.Size = new System.Drawing.Size(75, 23);
            this.btnInitOperationSystem.TabIndex = 5;
            this.btnInitOperationSystem.Text = "初始化操作系统";
            this.btnInitOperationSystem.UseVisualStyleBackColor = true;
            this.btnInitOperationSystem.Click += new System.EventHandler(this.btnInitOperationSystem_Click);
            // 
            // btnInitNetwork
            // 
            this.btnInitNetwork.Location = new System.Drawing.Point(338, 0);
            this.btnInitNetwork.Name = "btnInitNetwork";
            this.btnInitNetwork.Size = new System.Drawing.Size(104, 23);
            this.btnInitNetwork.TabIndex = 4;
            this.btnInitNetwork.Text = "初始化网络连接";
            this.btnInitNetwork.UseVisualStyleBackColor = true;
            this.btnInitNetwork.Click += new System.EventHandler(this.btnInitNetwork_Click);
            // 
            // btnInitService
            // 
            this.btnInitService.Location = new System.Drawing.Point(248, 0);
            this.btnInitService.Name = "btnInitService";
            this.btnInitService.Size = new System.Drawing.Size(75, 23);
            this.btnInitService.TabIndex = 4;
            this.btnInitService.Text = "初始化服务";
            this.btnInitService.UseVisualStyleBackColor = true;
            this.btnInitService.Click += new System.EventHandler(this.btnInitService_Click);
            // 
            // btnInitHardware
            // 
            this.btnInitHardware.Location = new System.Drawing.Point(458, 0);
            this.btnInitHardware.Name = "btnInitHardware";
            this.btnInitHardware.Size = new System.Drawing.Size(86, 23);
            this.btnInitHardware.TabIndex = 4;
            this.btnInitHardware.Text = "初始化硬件";
            this.btnInitHardware.UseVisualStyleBackColor = true;
            this.btnInitHardware.Click += new System.EventHandler(this.btnInitHardware_Click);
            // 
            // btnInitProcess
            // 
            this.btnInitProcess.Location = new System.Drawing.Point(154, 0);
            this.btnInitProcess.Name = "btnInitProcess";
            this.btnInitProcess.Size = new System.Drawing.Size(75, 23);
            this.btnInitProcess.TabIndex = 4;
            this.btnInitProcess.Text = "初始化进程";
            this.btnInitProcess.UseVisualStyleBackColor = true;
            this.btnInitProcess.Click += new System.EventHandler(this.btnInitProcess_Click);
            // 
            // lbSystemVersion
            // 
            this.lbSystemVersion.AutoSize = true;
            this.lbSystemVersion.Location = new System.Drawing.Point(20, 64);
            this.lbSystemVersion.Name = "lbSystemVersion";
            this.lbSystemVersion.Size = new System.Drawing.Size(41, 12);
            this.lbSystemVersion.TabIndex = 3;
            this.lbSystemVersion.Text = "XP SP3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "系统版本";
            // 
            // lbSystem
            // 
            this.lbSystem.AutoSize = true;
            this.lbSystem.Location = new System.Drawing.Point(20, 26);
            this.lbSystem.Name = "lbSystem";
            this.lbSystem.Size = new System.Drawing.Size(47, 12);
            this.lbSystem.TabIndex = 1;
            this.lbSystem.Text = "Windows";
            // 
            // lbSystemLabel
            // 
            this.lbSystemLabel.AutoSize = true;
            this.lbSystemLabel.Location = new System.Drawing.Point(20, 7);
            this.lbSystemLabel.Name = "lbSystemLabel";
            this.lbSystemLabel.Size = new System.Drawing.Size(53, 12);
            this.lbSystemLabel.TabIndex = 0;
            this.lbSystemLabel.Text = "操作系统";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(624, 326);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(616, 301);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "运行中进程";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 21);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(616, 301);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "启动的服务";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 21);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(616, 301);
            this.tabPage10.TabIndex = 5;
            this.tabPage10.Text = "网络连接";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 21);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(616, 301);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "常用端口监控";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 21);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(616, 301);
            this.tabPage11.TabIndex = 4;
            this.tabPage11.Text = "硬件信息";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.txtSystemInitLog);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(616, 301);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "初始化日志";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // txtSystemInitLog
            // 
            this.txtSystemInitLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSystemInitLog.Location = new System.Drawing.Point(3, 3);
            this.txtSystemInitLog.Name = "txtSystemInitLog";
            this.txtSystemInitLog.ReadOnly = true;
            this.txtSystemInitLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtSystemInitLog.Size = new System.Drawing.Size(610, 295);
            this.txtSystemInitLog.TabIndex = 0;
            this.txtSystemInitLog.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtWzhInitLog);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.cbWzhVersions);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.btnWzhInit);
            this.tabPage2.Controls.Add(this.btnWzhFolderSelector);
            this.tabPage2.Controls.Add(this.txtWzhPath);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(630, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "无纸化应用初始化";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtWzhInitLog
            // 
            this.txtWzhInitLog.Location = new System.Drawing.Point(23, 246);
            this.txtWzhInitLog.Name = "txtWzhInitLog";
            this.txtWzhInitLog.ReadOnly = true;
            this.txtWzhInitLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtWzhInitLog.Size = new System.Drawing.Size(591, 146);
            this.txtWzhInitLog.TabIndex = 14;
            this.txtWzhInitLog.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "三、点击开始初始化进行初始化";
            // 
            // cbWzhVersions
            // 
            this.cbWzhVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWzhVersions.FormattingEnabled = true;
            this.cbWzhVersions.Location = new System.Drawing.Point(222, 80);
            this.cbWzhVersions.Name = "cbWzhVersions";
            this.cbWzhVersions.Size = new System.Drawing.Size(149, 20);
            this.cbWzhVersions.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "二、请选择无纸化考试系统的版本号";
            // 
            // btnWzhInit
            // 
            this.btnWzhInit.Location = new System.Drawing.Point(46, 171);
            this.btnWzhInit.Name = "btnWzhInit";
            this.btnWzhInit.Size = new System.Drawing.Size(119, 52);
            this.btnWzhInit.TabIndex = 10;
            this.btnWzhInit.Text = "开始初始化";
            this.btnWzhInit.UseVisualStyleBackColor = true;
            this.btnWzhInit.Click += new System.EventHandler(this.btnWzhInit_Click);
            // 
            // btnWzhFolderSelector
            // 
            this.btnWzhFolderSelector.Location = new System.Drawing.Point(539, 45);
            this.btnWzhFolderSelector.Name = "btnWzhFolderSelector";
            this.btnWzhFolderSelector.Size = new System.Drawing.Size(75, 23);
            this.btnWzhFolderSelector.TabIndex = 9;
            this.btnWzhFolderSelector.Text = "浏览";
            this.btnWzhFolderSelector.UseVisualStyleBackColor = true;
            this.btnWzhFolderSelector.Click += new System.EventHandler(this.btnWzhFolderSelector_Click);
            // 
            // txtWzhPath
            // 
            this.txtWzhPath.Location = new System.Drawing.Point(46, 47);
            this.txtWzhPath.Name = "txtWzhPath";
            this.txtWzhPath.ReadOnly = true;
            this.txtWzhPath.Size = new System.Drawing.Size(479, 21);
            this.txtWzhPath.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(281, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "一、请选择要初始化的科目一无纸化考试应用目录：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtDBInitLog);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.btnDBInit);
            this.tabPage3.Controls.Add(this.txtDBUserPwd);
            this.tabPage3.Controls.Add(this.txtDBUserName);
            this.tabPage3.Controls.Add(this.txtDBName);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.cbDBType);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(630, 416);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "数据库服务器初始化";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtDBInitLog
            // 
            this.txtDBInitLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtDBInitLog.Location = new System.Drawing.Point(33, 256);
            this.txtDBInitLog.Multiline = true;
            this.txtDBInitLog.Name = "txtDBInitLog";
            this.txtDBInitLog.ReadOnly = true;
            this.txtDBInitLog.Size = new System.Drawing.Size(571, 141);
            this.txtDBInitLog.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "三、点击开始初始化进行初始化";
            // 
            // btnDBInit
            // 
            this.btnDBInit.Location = new System.Drawing.Point(58, 182);
            this.btnDBInit.Name = "btnDBInit";
            this.btnDBInit.Size = new System.Drawing.Size(119, 52);
            this.btnDBInit.TabIndex = 7;
            this.btnDBInit.Text = "开始初始化";
            this.btnDBInit.UseVisualStyleBackColor = true;
            // 
            // txtDBUserPwd
            // 
            this.txtDBUserPwd.Location = new System.Drawing.Point(452, 104);
            this.txtDBUserPwd.Name = "txtDBUserPwd";
            this.txtDBUserPwd.PasswordChar = '*';
            this.txtDBUserPwd.Size = new System.Drawing.Size(152, 21);
            this.txtDBUserPwd.TabIndex = 4;
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Location = new System.Drawing.Point(294, 104);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(97, 21);
            this.txtDBUserName.TabIndex = 4;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(125, 104);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(100, 21);
            this.txtDBName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "用户名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "数据库名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "二、请输入数据库名，用户名和密码";
            // 
            // cbDBType
            // 
            this.cbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDBType.FormattingEnabled = true;
            this.cbDBType.Items.AddRange(new object[] {
            "oracle",
            "sqlserver",
            "mysql",
            "access"});
            this.cbDBType.Location = new System.Drawing.Point(179, 16);
            this.cbDBType.Name = "cbDBType";
            this.cbDBType.Size = new System.Drawing.Size(121, 20);
            this.cbDBType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "一、请选择数据库类型";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtKtIEInitLog);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.cbIEVersions);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.btnKtIEInit);
            this.tabPage4.Controls.Add(this.btnKtIESelector);
            this.tabPage4.Controls.Add(this.txtKtIEPath);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(630, 416);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "考台浏览器初始化";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtKtIEInitLog
            // 
            this.txtKtIEInitLog.Location = new System.Drawing.Point(31, 253);
            this.txtKtIEInitLog.Name = "txtKtIEInitLog";
            this.txtKtIEInitLog.ReadOnly = true;
            this.txtKtIEInitLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtKtIEInitLog.Size = new System.Drawing.Size(591, 143);
            this.txtKtIEInitLog.TabIndex = 7;
            this.txtKtIEInitLog.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "三、点击开始初始化进行初始化";
            // 
            // cbIEVersions
            // 
            this.cbIEVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIEVersions.FormattingEnabled = true;
            this.cbIEVersions.Items.AddRange(new object[] {
            "9.0.7930.16406",
            "8.00.7600.16385",
            "8.00.7000.00000",
            "8.00.6001.18702",
            "8.00.6001.18372",
            "8.00.6001.18241",
            "8.00.6001.17184",
            "7.00.6001.1800",
            "7.00.6000.16441",
            "7.00.6000.16386",
            "7.00.5730.1300",
            "7.00.5730.1100",
            "6.00.3790.3959",
            "6.00.3790.1830",
            "6.00.3790.0000",
            "6.00.3718.0000",
            "6.00.3663.0000",
            "6.00.2900.5512",
            "6.00.2900.2180",
            "6.00.2800.1106",
            "6.00.2600.0000",
            "6.00.2479.0006",
            "6.00.2462.0000"});
            this.cbIEVersions.Location = new System.Drawing.Point(159, 90);
            this.cbIEVersions.Name = "cbIEVersions";
            this.cbIEVersions.Size = new System.Drawing.Size(149, 20);
            this.cbIEVersions.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "二、请选择IE的版本号";
            // 
            // btnKtIEInit
            // 
            this.btnKtIEInit.Location = new System.Drawing.Point(54, 182);
            this.btnKtIEInit.Name = "btnKtIEInit";
            this.btnKtIEInit.Size = new System.Drawing.Size(119, 52);
            this.btnKtIEInit.TabIndex = 3;
            this.btnKtIEInit.Text = "开始初始化";
            this.btnKtIEInit.UseVisualStyleBackColor = true;
            this.btnKtIEInit.Click += new System.EventHandler(this.btnKtIEInit_Click);
            // 
            // btnKtIESelector
            // 
            this.btnKtIESelector.Location = new System.Drawing.Point(547, 56);
            this.btnKtIESelector.Name = "btnKtIESelector";
            this.btnKtIESelector.Size = new System.Drawing.Size(75, 23);
            this.btnKtIESelector.TabIndex = 2;
            this.btnKtIESelector.Text = "浏览";
            this.btnKtIESelector.UseVisualStyleBackColor = true;
            this.btnKtIESelector.Click += new System.EventHandler(this.btnKtIESelector_Click);
            // 
            // txtKtIEPath
            // 
            this.txtKtIEPath.Location = new System.Drawing.Point(54, 58);
            this.txtKtIEPath.Name = "txtKtIEPath";
            this.txtKtIEPath.ReadOnly = true;
            this.txtKtIEPath.Size = new System.Drawing.Size(479, 21);
            this.txtKtIEPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "一、请选择要初始化的浏览器目录：";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtKtBHOInitLog);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(630, 416);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "考台BHO初始化";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtKtBHOInitLog
            // 
            this.txtKtBHOInitLog.Location = new System.Drawing.Point(38, 143);
            this.txtKtBHOInitLog.Multiline = true;
            this.txtKtBHOInitLog.Name = "txtKtBHOInitLog";
            this.txtKtBHOInitLog.ReadOnly = true;
            this.txtKtBHOInitLog.Size = new System.Drawing.Size(568, 252);
            this.txtKtBHOInitLog.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始初始化";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 441);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "系统安全初始化工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKtIEPath;
        private System.Windows.Forms.Button btnKtIESelector;
        private System.Windows.Forms.Button btnKtIEInit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbIEVersions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDBType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBUserPwd;
        private System.Windows.Forms.TextBox txtDBUserName;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDBInit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbWzhVersions;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnWzhInit;
        private System.Windows.Forms.Button btnWzhFolderSelector;
        private System.Windows.Forms.TextBox txtWzhPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDBInitLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtKtBHOInitLog;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.RichTextBox txtSystemInitLog;
        private System.Windows.Forms.Label lbSystemLabel;
        private System.Windows.Forms.Label lbSystem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbSystemVersion;
        private System.Windows.Forms.Button btnInitProcess;
        private System.Windows.Forms.Button btnInitService;
        private System.Windows.Forms.Button btnInitNetwork;
        private System.Windows.Forms.Button btnInitHardware;
        private System.Windows.Forms.Button btnInitOperationSystem;
        private System.Windows.Forms.RichTextBox txtKtIEInitLog;
        private System.Windows.Forms.RichTextBox txtWzhInitLog;
        private System.Windows.Forms.Button btnInitSystemInfo;
    }
}

