namespace FT.Windows.Forms
{
    partial class SimpleRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleRegister));
            this.txtRightCode = new FT.Windows.Controls.TextBoxEx.SimpleTextBox();
            this.txtCompany = new FT.Windows.Controls.TextBoxEx.SimpleTextBox();
            this.txtKeyCode = new FT.Windows.Controls.TextBoxEx.SimpleTextBox();
            this.txtMachineCode = new FT.Windows.Controls.TextBoxEx.SimpleTextBox();
            this.simpleButton1 = new FT.Windows.Controls.ButtonEx.SimpleButton();
            this.simpleLabel4 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // txtRightCode
            // 
            resources.ApplyResources(this.txtRightCode, "txtRightCode");
            this.txtRightCode.Name = "txtRightCode";
            this.txtRightCode.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // txtCompany
            // 
            resources.ApplyResources(this.txtCompany, "txtCompany");
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // txtKeyCode
            // 
            resources.ApplyResources(this.txtKeyCode, "txtKeyCode");
            this.txtKeyCode.Name = "txtKeyCode";
            this.txtKeyCode.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // txtMachineCode
            // 
            resources.ApplyResources(this.txtMachineCode, "txtMachineCode");
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.ReadOnly = true;
            this.txtMachineCode.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::FT.Windows.Forms.Properties.Resources.Save_16_16;
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            this.simpleButton1.UseVisualStyleBackColor = true;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleLabel4
            // 
            resources.ApplyResources(this.simpleLabel4, "simpleLabel4");
            this.simpleLabel4.Name = "simpleLabel4";
            this.simpleLabel4.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel3
            // 
            resources.ApplyResources(this.simpleLabel3, "simpleLabel3");
            this.simpleLabel3.Name = "simpleLabel3";
            this.simpleLabel3.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel2
            // 
            resources.ApplyResources(this.simpleLabel2, "simpleLabel2");
            this.simpleLabel2.Name = "simpleLabel2";
            this.simpleLabel2.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // simpleLabel1
            // 
            resources.ApplyResources(this.simpleLabel1, "simpleLabel1");
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Normal;
            // 
            // SimpleRegister
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRightCode);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtKeyCode);
            this.Controls.Add(this.txtMachineCode);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleLabel4);
            this.Controls.Add(this.simpleLabel3);
            this.Controls.Add(this.simpleLabel2);
            this.Controls.Add(this.simpleLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleRegister";
            this.Load += new System.EventHandler(this.SimpleRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel2;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel3;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel4;
        private FT.Windows.Controls.ButtonEx.SimpleButton simpleButton1;
        private FT.Windows.Controls.TextBoxEx.SimpleTextBox txtMachineCode;
        private FT.Windows.Controls.TextBoxEx.SimpleTextBox txtKeyCode;
        private FT.Windows.Controls.TextBoxEx.SimpleTextBox txtCompany;
        private FT.Windows.Controls.TextBoxEx.SimpleTextBox txtRightCode;
    }
}