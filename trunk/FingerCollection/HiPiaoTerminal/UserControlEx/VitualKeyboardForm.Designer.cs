namespace HiPiaoTerminal.UserControlEx
{
    partial class VitualKeyboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VitualKeyboardForm));
            this.vitualKeyBoardPanel31 = new FT.Windows.Controls.PanelEx.VitualKeyBoardPanel3();
            this.SuspendLayout();
            // 
            // vitualKeyBoardPanel31
            // 
            this.vitualKeyBoardPanel31.AutoScroll = true;
            this.vitualKeyBoardPanel31.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vitualKeyBoardPanel31.BackgroundImage")));
            this.vitualKeyBoardPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vitualKeyBoardPanel31.InputTextBox = null;
            this.vitualKeyBoardPanel31.Location = new System.Drawing.Point(0, 0);
            this.vitualKeyBoardPanel31.Name = "vitualKeyBoardPanel31";
            this.vitualKeyBoardPanel31.ShowWithForm = true;
            this.vitualKeyBoardPanel31.Size = new System.Drawing.Size(955, 338);
            this.vitualKeyBoardPanel31.TabIndex = 0;
            // 
            // VitualKeyboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(955, 338);
            this.Controls.Add(this.vitualKeyBoardPanel31);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VitualKeyboardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "VitualKeyboardForm";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VitualKeyboardForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.PanelEx.VitualKeyBoardPanel3 vitualKeyBoardPanel31;

    }
}