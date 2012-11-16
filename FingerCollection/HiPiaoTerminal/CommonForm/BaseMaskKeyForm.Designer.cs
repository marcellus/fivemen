namespace HiPiaoTerminal.CommonForm
{
    partial class BaseMaskKeyForm
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
            // BaseMaskKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseMaskKeyForm";
            this.Text = "BaseMaskKeyForm";
            this.Load += new System.EventHandler(this.BaseMaskKeyForm_Load);
            this.SizeChanged += new System.EventHandler(this.BaseMaskKeyForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseMaskKeyForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
    }
}