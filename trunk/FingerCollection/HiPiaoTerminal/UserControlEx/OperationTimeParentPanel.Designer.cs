namespace HiPiaoTerminal.UserControlEx
{
    partial class OperationTimeParentPanel
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
            if (timer1 != null)
            {
                timer1.Enabled = false;
                timer1.Stop();

            }
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lbTimeSecond = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.panelContent);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panelHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_FooterBack;
            this.splitContainer1.Panel2.Controls.Add(this.lbTimeSecond);
            this.splitContainer1.Panel2MinSize = 20;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 960);
            this.splitContainer1.SplitterDistance = 824;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(0, 233);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1280, 570);
            this.panelContent.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(0, 211);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 3);
            this.panel1.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1280, 241);
            this.panelHeader.TabIndex = 0;
            // 
            // lbTimeSecond
            // 
            this.lbTimeSecond.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeSecond.Font = new System.Drawing.Font("方正兰亭黑简体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimeSecond.ForeColor = System.Drawing.SystemColors.Window;
            this.lbTimeSecond.Location = new System.Drawing.Point(62, 40);
            this.lbTimeSecond.Name = "lbTimeSecond";
            this.lbTimeSecond.Size = new System.Drawing.Size(154, 63);
            this.lbTimeSecond.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTimeSecond.TabIndex = 0;
            this.lbTimeSecond.Text = "30";
            this.lbTimeSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // OperationTimeParentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "OperationTimeParentPanel";
            this.Size = new System.Drawing.Size(1280, 960);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected FT.Windows.Controls.LabelEx.SimpleLabel lbTimeSecond;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panelContent;
        protected System.Windows.Forms.Panel panelHeader;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timer1;
    }
}
