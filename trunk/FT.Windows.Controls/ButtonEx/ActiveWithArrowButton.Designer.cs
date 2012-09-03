using FT.Windows.Controls.LabelEx;
namespace FT.Windows.Controls.ButtonEx
{
    partial class ActiveWithArrowButton
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
            this.lbHintText = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // lbHintText
            // 
            this.lbHintText.BackColor = System.Drawing.Color.Transparent;
            this.lbHintText.ForeColor = System.Drawing.Color.Black;
            this.lbHintText.Location = new System.Drawing.Point(3, 0);
            this.lbHintText.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lbHintText.Name = "lbHintText";
            this.lbHintText.Size = new System.Drawing.Size(215, 65);
            this.lbHintText.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbHintText.TabIndex = 1;
            this.lbHintText.Text = "sdfdsfds";
            this.lbHintText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHintText.Click += new System.EventHandler(this.lbHintText_Click);
            // 
            // ActiveWithArrowButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbHintText);
            this.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ActiveWithArrowButton";
            this.Size = new System.Drawing.Size(218, 69);
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleLabel lbHintText;
    }
}
