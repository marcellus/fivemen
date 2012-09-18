namespace HiPiaoTerminal
{
    partial class FullAdShowForm
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
            this.adShowPanel1 = new HiPiaoTerminal.UserControlEx.AdShowPanel();
            this.SuspendLayout();
            // 
            // adShowPanel1
            // 
            this.adShowPanel1.AdType = "所有位置";
            this.adShowPanel1.AutoScroll = true;
            this.adShowPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.adShowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adShowPanel1.Interval = 1000;
            this.adShowPanel1.Location = new System.Drawing.Point(0, 0);
            this.adShowPanel1.Name = "adShowPanel1";
            this.adShowPanel1.Size = new System.Drawing.Size(1280, 780);
            this.adShowPanel1.TabIndex = 0;
            this.adShowPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.adShowPanel1_MouseMove);
            this.adShowPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.adShowPanel1_MouseClick);
            // 
            // FullAdShowForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this.adShowPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullAdShowForm";
            this.Text = "FullAdShowForm";
            this.ResumeLayout(false);

        }

        #endregion

        private HiPiaoTerminal.UserControlEx.AdShowPanel adShowPanel1;
    }
}