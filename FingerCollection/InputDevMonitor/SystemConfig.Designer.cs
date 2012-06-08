namespace InputDevMonitor
{
    partial class SystemConfig
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
            this.checkIsStart = new System.Windows.Forms.CheckBox();
            this.checkIsStartBarReader = new System.Windows.Forms.CheckBox();
            this.checkIsStartIdCardReader = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkIsStart
            // 
            this.checkIsStart.AutoSize = true;
            this.checkIsStart.Location = new System.Drawing.Point(26, 23);
            this.checkIsStart.Name = "checkIsStart";
            this.checkIsStart.Size = new System.Drawing.Size(96, 16);
            this.checkIsStart.TabIndex = 0;
            this.checkIsStart.Text = "随window启动";
            this.checkIsStart.UseVisualStyleBackColor = true;
            // 
            // checkIsStartBarReader
            // 
            this.checkIsStartBarReader.AutoSize = true;
            this.checkIsStartBarReader.Location = new System.Drawing.Point(26, 69);
            this.checkIsStartBarReader.Name = "checkIsStartBarReader";
            this.checkIsStartBarReader.Size = new System.Drawing.Size(120, 16);
            this.checkIsStartBarReader.TabIndex = 1;
            this.checkIsStartBarReader.Text = "启动条码读写监听";
            this.checkIsStartBarReader.UseVisualStyleBackColor = true;
            // 
            // checkIsStartIdCardReader
            // 
            this.checkIsStartIdCardReader.AutoSize = true;
            this.checkIsStartIdCardReader.Location = new System.Drawing.Point(152, 69);
            this.checkIsStartIdCardReader.Name = "checkIsStartIdCardReader";
            this.checkIsStartIdCardReader.Size = new System.Drawing.Size(132, 16);
            this.checkIsStartIdCardReader.TabIndex = 2;
            this.checkIsStartIdCardReader.Text = "启动二代证读写监听";
            this.checkIsStartIdCardReader.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 167);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkIsStartIdCardReader);
            this.Controls.Add(this.checkIsStartBarReader);
            this.Controls.Add(this.checkIsStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SystemConfig";
            this.Text = "输入设备监控配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkIsStart;
        private System.Windows.Forms.CheckBox checkIsStartBarReader;
        private System.Windows.Forms.CheckBox checkIsStartIdCardReader;
        private System.Windows.Forms.Button btnSave;
    }
}