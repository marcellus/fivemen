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
            this.vitualKeyBoardPanel21 = new FT.Windows.Controls.PanelEx.VitualKeyBoardPanel2();
            this.SuspendLayout();
            // 
            // vitualKeyBoardPanel21
            // 
            this.vitualKeyBoardPanel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.vitualKeyBoardPanel21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vitualKeyBoardPanel21.BackgroundImage")));
            this.vitualKeyBoardPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vitualKeyBoardPanel21.InputTextBox = null;
            this.vitualKeyBoardPanel21.Location = new System.Drawing.Point(0, 0);
            this.vitualKeyBoardPanel21.Name = "vitualKeyBoardPanel21";
            this.vitualKeyBoardPanel21.ShowWithForm = false;
            this.vitualKeyBoardPanel21.Size = new System.Drawing.Size(952, 325);
            this.vitualKeyBoardPanel21.TabIndex = 0;
            this.vitualKeyBoardPanel21.TabStop = false;
            this.vitualKeyBoardPanel21.Load += new System.EventHandler(this.vitualKeyBoardPanel21_Load);
            // 
            // VitualKeyboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(952, 325);
            this.Controls.Add(this.vitualKeyBoardPanel21);
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

        private FT.Windows.Controls.PanelEx.VitualKeyBoardPanel2 vitualKeyBoardPanel21;
    }
}