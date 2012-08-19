namespace HiPiaoTerminal.UserControlEx
{
    partial class MaintainParentPanel
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
            this.btnReturnMaintain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnMaintain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturnMaintain
            // 
            this.btnReturnMaintain.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Manager_Return_Maintain;
            this.btnReturnMaintain.Location = new System.Drawing.Point(1044, 167);
            this.btnReturnMaintain.Name = "btnReturnMaintain";
            this.btnReturnMaintain.Size = new System.Drawing.Size(209, 77);
            this.btnReturnMaintain.TabIndex = 1;
            this.btnReturnMaintain.TabStop = false;
            this.btnReturnMaintain.Click += new System.EventHandler(this.btnReturnMaintain_Click);
            // 
            // MaintainParentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.Controls.Add(this.btnReturnMaintain);
            this.Name = "MaintainParentPanel";
            this.Controls.SetChildIndex(this.btnReturnMaintain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnMaintain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnReturnMaintain;


    }
}
