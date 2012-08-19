namespace HiPiaoTerminal.TestForm
{
    partial class RoundForm
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
            this.SuspendLayout();
            // 
            // RoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 515);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoundForm";
            this.Text = "RoundForm";
            this.Load += new System.EventHandler(this.RoundForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundForm_Paint);
            this.Click += new System.EventHandler(this.RoundForm_Click);
            this.Resize += new System.EventHandler(this.RoundForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}