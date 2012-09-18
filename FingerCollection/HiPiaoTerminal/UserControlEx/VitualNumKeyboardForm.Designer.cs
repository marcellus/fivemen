namespace HiPiaoTerminal.UserControlEx
{
    partial class VitualNumKeyboardForm
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
            this.vitualNumKeyBoardPanel1 = new FT.Windows.Controls.PanelEx.VitualNumKeyBoardPanel();
            this.SuspendLayout();
            // 
            // vitualNumKeyBoardPanel1
            // 
            this.vitualNumKeyBoardPanel1.InputTextBox = null;
            this.vitualNumKeyBoardPanel1.Location = new System.Drawing.Point(0, 0);
            this.vitualNumKeyBoardPanel1.Name = "vitualNumKeyBoardPanel1";
            this.vitualNumKeyBoardPanel1.ShowWithForm = true;
            this.vitualNumKeyBoardPanel1.Size = new System.Drawing.Size(325, 326);
            this.vitualNumKeyBoardPanel1.TabIndex = 0;
            this.vitualNumKeyBoardPanel1.TabStop = false;
            // 
            // VitualNumKeyboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(325, 323);
            this.Controls.Add(this.vitualNumKeyBoardPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VitualNumKeyboardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VitualNumKeyboardForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.PanelEx.VitualNumKeyBoardPanel vitualNumKeyBoardPanel1;
    }
}