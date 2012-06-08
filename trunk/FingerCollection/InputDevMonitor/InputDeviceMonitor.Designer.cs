namespace InputDevMonitor
{
    partial class InputDeviceMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDeviceMonitor));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.输入设备系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入设备系统配置ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出监控ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 76);
            // 
            // 输入设备系统配置ToolStripMenuItem
            // 
            this.输入设备系统配置ToolStripMenuItem.Name = "输入设备系统配置ToolStripMenuItem";
            this.输入设备系统配置ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.输入设备系统配置ToolStripMenuItem.Text = "输入设备系统配置";
            this.输入设备系统配置ToolStripMenuItem.Click += new System.EventHandler(this.输入设备系统配置ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "输入设备监控";
            this.notifyIcon1.Visible = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // 退出监控ToolStripMenuItem
            // 
            this.退出监控ToolStripMenuItem.Name = "退出监控ToolStripMenuItem";
            this.退出监控ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.退出监控ToolStripMenuItem.Text = "退出监控";
            this.退出监控ToolStripMenuItem.Click += new System.EventHandler(this.退出监控ToolStripMenuItem_Click);
            // 
            // InputDeviceMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 38);
            this.Name = "InputDeviceMonitor";
            this.Text = "InputDeviceMonitor";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 输入设备系统配置ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出监控ToolStripMenuItem;
    }
}