namespace TerminalIeForm
{
    partial class YuanTuoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YuanTuoForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerConnectNet = new System.Windows.Forms.Timer(this.components);
            this.timerAnotherDay = new System.Windows.Forms.Timer(this.components);
            this.timerTopFirst = new System.Windows.Forms.Timer(this.components);
            this.btnHint = new System.Windows.Forms.Button();
            this.panelHint = new System.Windows.Forms.Panel();
            this.lbHint = new System.Windows.Forms.Label();
            this.btnHks = new System.Windows.Forms.Button();
            this.btnJiaqu = new System.Windows.Forms.Button();
            this.btnKanke = new System.Windows.Forms.Button();
            this.btnShike = new System.Windows.Forms.Button();
            this.btnWeiGuanDian = new System.Windows.Forms.Button();
            this.btnBenQiTopic = new System.Windows.Forms.Button();
            this.btnReturnHome = new System.Windows.Forms.Button();
            this.btnMagazine = new System.Windows.Forms.PictureBox();
            this.btnServicePhone = new System.Windows.Forms.PictureBox();
            this.btnTickets = new System.Windows.Forms.PictureBox();
            this.btnMemberService = new System.Windows.Forms.PictureBox();
            this.btnRealRoadCondition = new System.Windows.Forms.PictureBox();
            this.btnFreePhone = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new TerminalIeForm.WebBrowserEx();
            this.panelHint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMagazine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnServicePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMemberService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRealRoadCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFreePhone)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerConnectNet
            // 
            this.timerConnectNet.Tick += new System.EventHandler(this.timerConnectNet_Tick);
            // 
            // timerAnotherDay
            // 
            this.timerAnotherDay.Enabled = true;
            this.timerAnotherDay.Interval = 120000;
            this.timerAnotherDay.Tick += new System.EventHandler(this.timerAnotherDay_Tick);
            // 
            // timerTopFirst
            // 
            this.timerTopFirst.Interval = 1000;
            this.timerTopFirst.Tick += new System.EventHandler(this.timerTopFirst_Tick);
            // 
            // btnHint
            // 
            this.btnHint.Font = new System.Drawing.Font("仿宋", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHint.ForeColor = System.Drawing.Color.Red;
            this.btnHint.Location = new System.Drawing.Point(249, 9);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(113, 44);
            this.btnHint.TabIndex = 6;
            this.btnHint.Text = "挂断";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // panelHint
            // 
            this.panelHint.Controls.Add(this.lbHint);
            this.panelHint.Controls.Add(this.btnHint);
            this.panelHint.Location = new System.Drawing.Point(433, 682);
            this.panelHint.Name = "panelHint";
            this.panelHint.Size = new System.Drawing.Size(389, 61);
            this.panelHint.TabIndex = 7;
            this.panelHint.Visible = false;
            this.panelHint.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHint_Paint);
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Font = new System.Drawing.Font("仿宋", 28F, System.Drawing.FontStyle.Bold);
            this.lbHint.ForeColor = System.Drawing.Color.Red;
            this.lbHint.Location = new System.Drawing.Point(17, 9);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(212, 38);
            this.lbHint.TabIndex = 7;
            this.lbHint.Text = "拨号中……";
            // 
            // btnHks
            // 
            this.btnHks.BackgroundImage = global::TerminalIeForm.Properties.Resources.香港卫视;
            this.btnHks.Location = new System.Drawing.Point(985, 180);
            this.btnHks.Name = "btnHks";
            this.btnHks.Size = new System.Drawing.Size(152, 50);
            this.btnHks.TabIndex = 5;
            this.btnHks.UseVisualStyleBackColor = true;
            this.btnHks.Click += new System.EventHandler(this.btnHks_Click);
            // 
            // btnJiaqu
            // 
            this.btnJiaqu.BackgroundImage = global::TerminalIeForm.Properties.Resources.驾趣;
            this.btnJiaqu.Location = new System.Drawing.Point(816, 180);
            this.btnJiaqu.Name = "btnJiaqu";
            this.btnJiaqu.Size = new System.Drawing.Size(152, 50);
            this.btnJiaqu.TabIndex = 5;
            this.btnJiaqu.UseVisualStyleBackColor = true;
            this.btnJiaqu.Click += new System.EventHandler(this.btnJiaqu_Click);
            // 
            // btnKanke
            // 
            this.btnKanke.BackgroundImage = global::TerminalIeForm.Properties.Resources.看客;
            this.btnKanke.Location = new System.Drawing.Point(468, 180);
            this.btnKanke.Name = "btnKanke";
            this.btnKanke.Size = new System.Drawing.Size(152, 50);
            this.btnKanke.TabIndex = 5;
            this.btnKanke.UseVisualStyleBackColor = true;
            this.btnKanke.Click += new System.EventHandler(this.btnKanke_Click);
            // 
            // btnShike
            // 
            this.btnShike.BackgroundImage = global::TerminalIeForm.Properties.Resources.食客;
            this.btnShike.Location = new System.Drawing.Point(642, 180);
            this.btnShike.Name = "btnShike";
            this.btnShike.Size = new System.Drawing.Size(152, 50);
            this.btnShike.TabIndex = 5;
            this.btnShike.UseVisualStyleBackColor = true;
            this.btnShike.Click += new System.EventHandler(this.btnShike_Click);
            // 
            // btnWeiGuanDian
            // 
            this.btnWeiGuanDian.BackgroundImage = global::TerminalIeForm.Properties.Resources.微观点;
            this.btnWeiGuanDian.Location = new System.Drawing.Point(294, 180);
            this.btnWeiGuanDian.Name = "btnWeiGuanDian";
            this.btnWeiGuanDian.Size = new System.Drawing.Size(152, 50);
            this.btnWeiGuanDian.TabIndex = 5;
            this.btnWeiGuanDian.UseVisualStyleBackColor = true;
            this.btnWeiGuanDian.Click += new System.EventHandler(this.btnWeiGuanDian_Click);
            // 
            // btnBenQiTopic
            // 
            this.btnBenQiTopic.BackgroundImage = global::TerminalIeForm.Properties.Resources.本期专题;
            this.btnBenQiTopic.Location = new System.Drawing.Point(120, 180);
            this.btnBenQiTopic.Name = "btnBenQiTopic";
            this.btnBenQiTopic.Size = new System.Drawing.Size(152, 50);
            this.btnBenQiTopic.TabIndex = 5;
            this.btnBenQiTopic.UseVisualStyleBackColor = true;
            this.btnBenQiTopic.Click += new System.EventHandler(this.btnBenQiTopic_Click);
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.BackgroundImage = global::TerminalIeForm.Properties.Resources.shouye;
            this.btnReturnHome.Location = new System.Drawing.Point(1240, 12);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(96, 59);
            this.btnReturnHome.TabIndex = 4;
            this.btnReturnHome.UseVisualStyleBackColor = true;
            this.btnReturnHome.Visible = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // btnMagazine
            // 
            this.btnMagazine.Image = global::TerminalIeForm.Properties.Resources.易捷微刊;
            this.btnMagazine.Location = new System.Drawing.Point(1062, 336);
            this.btnMagazine.Name = "btnMagazine";
            this.btnMagazine.Size = new System.Drawing.Size(261, 62);
            this.btnMagazine.TabIndex = 3;
            this.btnMagazine.TabStop = false;
            this.btnMagazine.Tag = "易捷微刊";
            this.btnMagazine.Click += new System.EventHandler(this.btnMagazine_Click);
            // 
            // btnServicePhone
            // 
            this.btnServicePhone.Image = global::TerminalIeForm.Properties.Resources.咨询热线;
            this.btnServicePhone.Location = new System.Drawing.Point(1062, 660);
            this.btnServicePhone.Name = "btnServicePhone";
            this.btnServicePhone.Size = new System.Drawing.Size(261, 62);
            this.btnServicePhone.TabIndex = 3;
            this.btnServicePhone.TabStop = false;
            this.btnServicePhone.Tag = "产品咨询热线";
            this.btnServicePhone.Click += new System.EventHandler(this.btnServicePhone_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.Image = global::TerminalIeForm.Properties.Resources.票务;
            this.btnTickets.Location = new System.Drawing.Point(1062, 579);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(261, 62);
            this.btnTickets.TabIndex = 3;
            this.btnTickets.TabStop = false;
            this.btnTickets.Tag = "酒店\\餐饮\\票务";
            this.btnTickets.Click += new System.EventHandler(this.btnTickets_Click);
            // 
            // btnMemberService
            // 
            this.btnMemberService.Image = global::TerminalIeForm.Properties.Resources.北京石油会员;
            this.btnMemberService.Location = new System.Drawing.Point(1062, 255);
            this.btnMemberService.Name = "btnMemberService";
            this.btnMemberService.Size = new System.Drawing.Size(261, 62);
            this.btnMemberService.TabIndex = 3;
            this.btnMemberService.TabStop = false;
            this.btnMemberService.Tag = "会员服务";
            this.btnMemberService.Click += new System.EventHandler(this.btnMemberService_Click);
            // 
            // btnRealRoadCondition
            // 
            this.btnRealRoadCondition.Image = global::TerminalIeForm.Properties.Resources.实时路况;
            this.btnRealRoadCondition.Location = new System.Drawing.Point(1062, 498);
            this.btnRealRoadCondition.Name = "btnRealRoadCondition";
            this.btnRealRoadCondition.Size = new System.Drawing.Size(261, 62);
            this.btnRealRoadCondition.TabIndex = 3;
            this.btnRealRoadCondition.TabStop = false;
            this.btnRealRoadCondition.Tag = "实时路况";
            this.btnRealRoadCondition.Click += new System.EventHandler(this.btnRealRoadCondition_Click);
            // 
            // btnFreePhone
            // 
            this.btnFreePhone.Image = global::TerminalIeForm.Properties.Resources.免费电话;
            this.btnFreePhone.Location = new System.Drawing.Point(1062, 417);
            this.btnFreePhone.Name = "btnFreePhone";
            this.btnFreePhone.Size = new System.Drawing.Size(261, 62);
            this.btnFreePhone.TabIndex = 3;
            this.btnFreePhone.TabStop = false;
            this.btnFreePhone.Tag = "免费电话";
            this.btnFreePhone.Click += new System.EventHandler(this.btnFreePhone_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1366, 768);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // YuanTuoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panelHint);
            this.Controls.Add(this.btnHks);
            this.Controls.Add(this.btnJiaqu);
            this.Controls.Add(this.btnKanke);
            this.Controls.Add(this.btnShike);
            this.Controls.Add(this.btnWeiGuanDian);
            this.Controls.Add(this.btnBenQiTopic);
            this.Controls.Add(this.btnReturnHome);
            this.Controls.Add(this.btnMagazine);
            this.Controls.Add(this.btnServicePhone);
            this.Controls.Add(this.btnTickets);
            this.Controls.Add(this.btnMemberService);
            this.Controls.Add(this.btnRealRoadCondition);
            this.Controls.Add(this.btnFreePhone);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YuanTuoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YuanTuoForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.YuanTuoForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YuanTuoForm_FormClosing);
            this.panelHint.ResumeLayout(false);
            this.panelHint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMagazine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnServicePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMemberService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRealRoadCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFreePhone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowserEx webBrowser1;
        private System.Windows.Forms.PictureBox btnFreePhone;
        private System.Windows.Forms.PictureBox btnRealRoadCondition;
        private System.Windows.Forms.PictureBox btnMemberService;
        private System.Windows.Forms.PictureBox btnTickets;
        private System.Windows.Forms.PictureBox btnServicePhone;
        private System.Windows.Forms.PictureBox btnMagazine;
        private System.Windows.Forms.Button btnReturnHome;
        private System.Windows.Forms.Button btnBenQiTopic;
        private System.Windows.Forms.Button btnWeiGuanDian;
        private System.Windows.Forms.Button btnShike;
        private System.Windows.Forms.Button btnKanke;
        private System.Windows.Forms.Button btnJiaqu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerConnectNet;
        private System.Windows.Forms.Timer timerAnotherDay;
        private System.Windows.Forms.Timer timerTopFirst;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Panel panelHint;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Button btnHks;
    }
}