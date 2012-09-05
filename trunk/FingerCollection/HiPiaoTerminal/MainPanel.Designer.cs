﻿namespace HiPiaoTerminal
{
    partial class MainPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerShowMovie = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.picToMaintain = new System.Windows.Forms.PictureBox();
            this.btnTicketPrint = new System.Windows.Forms.PictureBox();
            this.btnBuyTicket = new System.Windows.Forms.PictureBox();
            this.btnLoginPassport = new System.Windows.Forms.PictureBox();
            this.btnQuickRegister = new System.Windows.Forms.PictureBox();
            this.btnUserTaste = new System.Windows.Forms.PictureBox();
            this.picShowMovies = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.PictureBox();
            this.lbWelcome1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbWelcomeName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbWelcome3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picToMaintain2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picToMaintain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTicketPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuyTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoginPassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserTaste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToMaintain2)).BeginInit();
            this.SuspendLayout();
            // 
            // timerShowMovie
            // 
            this.timerShowMovie.Interval = 2000;
            this.timerShowMovie.Tick += new System.EventHandler(this.timerShowMovie_Tick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Main_TicketPrint;
            this.button1.Location = new System.Drawing.Point(437, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 156);
            this.button1.TabIndex = 5;
            this.button1.Text = "维护管理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picToMaintain
            // 
            this.picToMaintain.Location = new System.Drawing.Point(0, 0);
            this.picToMaintain.Margin = new System.Windows.Forms.Padding(7);
            this.picToMaintain.Name = "picToMaintain";
            this.picToMaintain.Size = new System.Drawing.Size(84, 86);
            this.picToMaintain.TabIndex = 13;
            this.picToMaintain.TabStop = false;
            this.picToMaintain.DoubleClick += new System.EventHandler(this.picToMaintain_DoubleClick);
            this.picToMaintain.Click += new System.EventHandler(this.picToMaintain_Click);
            // 
            // btnTicketPrint
            // 
            this.btnTicketPrint.Image = global::HiPiaoTerminal.Properties.Resources.Main_TicketPrint;
            this.btnTicketPrint.Location = new System.Drawing.Point(660, 142);
            this.btnTicketPrint.Margin = new System.Windows.Forms.Padding(7);
            this.btnTicketPrint.Name = "btnTicketPrint";
            this.btnTicketPrint.Size = new System.Drawing.Size(149, 150);
            this.btnTicketPrint.TabIndex = 10;
            this.btnTicketPrint.TabStop = false;
            this.btnTicketPrint.Click += new System.EventHandler(this.btnTicketPrint_Click);
            // 
            // btnBuyTicket
            // 
            this.btnBuyTicket.Image = global::HiPiaoTerminal.Properties.Resources.Main_QuickBuyTicket;
            this.btnBuyTicket.Location = new System.Drawing.Point(816, 142);
            this.btnBuyTicket.Margin = new System.Windows.Forms.Padding(7);
            this.btnBuyTicket.Name = "btnBuyTicket";
            this.btnBuyTicket.Size = new System.Drawing.Size(149, 150);
            this.btnBuyTicket.TabIndex = 9;
            this.btnBuyTicket.TabStop = false;
            this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            // 
            // btnLoginPassport
            // 
            this.btnLoginPassport.Image = global::HiPiaoTerminal.Properties.Resources.Main_UserAccount;
            this.btnLoginPassport.Location = new System.Drawing.Point(972, 142);
            this.btnLoginPassport.Margin = new System.Windows.Forms.Padding(7);
            this.btnLoginPassport.Name = "btnLoginPassport";
            this.btnLoginPassport.Size = new System.Drawing.Size(149, 150);
            this.btnLoginPassport.TabIndex = 8;
            this.btnLoginPassport.TabStop = false;
            this.btnLoginPassport.Click += new System.EventHandler(this.btnLoginPassport_Click);
            // 
            // btnQuickRegister
            // 
            this.btnQuickRegister.Image = global::HiPiaoTerminal.Properties.Resources.Main_UserRegister;
            this.btnQuickRegister.Location = new System.Drawing.Point(972, 299);
            this.btnQuickRegister.Margin = new System.Windows.Forms.Padding(7);
            this.btnQuickRegister.Name = "btnQuickRegister";
            this.btnQuickRegister.Size = new System.Drawing.Size(149, 150);
            this.btnQuickRegister.TabIndex = 7;
            this.btnQuickRegister.TabStop = false;
            this.btnQuickRegister.Click += new System.EventHandler(this.btnQuickRegister_Click);
            // 
            // btnUserTaste
            // 
            this.btnUserTaste.Image = global::HiPiaoTerminal.Properties.Resources.Main_HiPiaoTaste;
            this.btnUserTaste.Location = new System.Drawing.Point(972, 456);
            this.btnUserTaste.Margin = new System.Windows.Forms.Padding(7);
            this.btnUserTaste.Name = "btnUserTaste";
            this.btnUserTaste.Size = new System.Drawing.Size(149, 150);
            this.btnUserTaste.TabIndex = 6;
            this.btnUserTaste.TabStop = false;
            this.btnUserTaste.Click += new System.EventHandler(this.btnUserTaste_Click);
            // 
            // picShowMovies
            // 
            this.picShowMovies.Location = new System.Drawing.Point(111, 299);
            this.picShowMovies.Margin = new System.Windows.Forms.Padding(7);
            this.picShowMovies.Name = "picShowMovies";
            this.picShowMovies.Size = new System.Drawing.Size(854, 480);
            this.picShowMovies.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShowMovies.TabIndex = 1;
            this.picShowMovies.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Main_Quit;
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuit.Location = new System.Drawing.Point(972, 613);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(7);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(149, 150);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.TabStop = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lbWelcome1
            // 
            this.lbWelcome1.AutoSize = true;
            this.lbWelcome1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbWelcome1.Location = new System.Drawing.Point(105, 255);
            this.lbWelcome1.Name = "lbWelcome1";
            this.lbWelcome1.Size = new System.Drawing.Size(124, 28);
            this.lbWelcome1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbWelcome1.TabIndex = 14;
            this.lbWelcome1.Text = "欢迎回来";
            // 
            // lbWelcomeName
            // 
            this.lbWelcomeName.AutoSize = true;
            this.lbWelcomeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbWelcomeName.Location = new System.Drawing.Point(224, 255);
            this.lbWelcomeName.Name = "lbWelcomeName";
            this.lbWelcomeName.Size = new System.Drawing.Size(124, 28);
            this.lbWelcomeName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbWelcomeName.TabIndex = 14;
            this.lbWelcomeName.Text = "欢迎回来";
            // 
            // lbWelcome3
            // 
            this.lbWelcome3.AutoSize = true;
            this.lbWelcome3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbWelcome3.Location = new System.Drawing.Point(354, 255);
            this.lbWelcome3.Name = "lbWelcome3";
            this.lbWelcome3.Size = new System.Drawing.Size(264, 28);
            this.lbWelcome3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbWelcome3.TabIndex = 14;
            this.lbWelcome3.Text = "，请选择您的操作：";
            // 
            // picToMaintain2
            // 
            this.picToMaintain2.Location = new System.Drawing.Point(1196, 0);
            this.picToMaintain2.Margin = new System.Windows.Forms.Padding(7);
            this.picToMaintain2.Name = "picToMaintain2";
            this.picToMaintain2.Size = new System.Drawing.Size(84, 86);
            this.picToMaintain2.TabIndex = 13;
            this.picToMaintain2.TabStop = false;
            this.picToMaintain2.DoubleClick += new System.EventHandler(this.picToMaintain2_DoubleClick);
            this.picToMaintain2.Click += new System.EventHandler(this.picToMaintain2_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lbWelcomeName);
            this.Controls.Add(this.lbWelcome3);
            this.Controls.Add(this.lbWelcome1);
            this.Controls.Add(this.picToMaintain2);
            this.Controls.Add(this.picToMaintain);
            this.Controls.Add(this.btnTicketPrint);
            this.Controls.Add(this.btnBuyTicket);
            this.Controls.Add(this.btnLoginPassport);
            this.Controls.Add(this.btnQuickRegister);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnUserTaste);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picShowMovies);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainPanel";
            this.Load += new System.EventHandler(this.MainPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picToMaintain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTicketPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuyTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoginPassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserTaste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToMaintain2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picShowMovies;
        private System.Windows.Forms.Timer timerShowMovie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox btnUserTaste;
        private System.Windows.Forms.PictureBox btnQuickRegister;
        private System.Windows.Forms.PictureBox btnLoginPassport;
        private System.Windows.Forms.PictureBox btnBuyTicket;
        private System.Windows.Forms.PictureBox btnTicketPrint;
        private System.Windows.Forms.PictureBox picToMaintain;
        private System.Windows.Forms.PictureBox btnQuit;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbWelcome1;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbWelcomeName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbWelcome3;
        private System.Windows.Forms.PictureBox picToMaintain2;
        
    }
}
