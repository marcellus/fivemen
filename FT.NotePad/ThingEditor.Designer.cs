﻿namespace FT.NotePad
{
    partial class ThingEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThingEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增计划书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增代办事项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增记事ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.editor1 = new FT.Windows.Controls.Editor();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.展开节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收缩节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.editor1);
            this.splitContainer1.Size = new System.Drawing.Size(933, 547);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 547);
            this.treeView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建文件夹ToolStripMenuItem,
            this.新增计划书ToolStripMenuItem,
            this.新增代办事项ToolStripMenuItem,
            this.新增记事ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.toolStripSeparator1,
            this.展开节点ToolStripMenuItem,
            this.收缩节点ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 186);
            // 
            // 新建文件夹ToolStripMenuItem
            // 
            this.新建文件夹ToolStripMenuItem.Name = "新建文件夹ToolStripMenuItem";
            this.新建文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建文件夹ToolStripMenuItem.Text = "新建文件夹";
            this.新建文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建文件夹ToolStripMenuItem_Click);
            // 
            // 新增计划书ToolStripMenuItem
            // 
            this.新增计划书ToolStripMenuItem.Name = "新增计划书ToolStripMenuItem";
            this.新增计划书ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增计划书ToolStripMenuItem.Text = "新增计划书";
            this.新增计划书ToolStripMenuItem.Click += new System.EventHandler(this.新增计划书ToolStripMenuItem_Click);
            // 
            // 新增代办事项ToolStripMenuItem
            // 
            this.新增代办事项ToolStripMenuItem.Name = "新增代办事项ToolStripMenuItem";
            this.新增代办事项ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增代办事项ToolStripMenuItem.Text = "新增代办事项";
            this.新增代办事项ToolStripMenuItem.Click += new System.EventHandler(this.新增代办事项ToolStripMenuItem_Click);
            // 
            // 新增记事ToolStripMenuItem
            // 
            this.新增记事ToolStripMenuItem.Name = "新增记事ToolStripMenuItem";
            this.新增记事ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增记事ToolStripMenuItem.Text = "新增记事";
            this.新增记事ToolStripMenuItem.Click += new System.EventHandler(this.新增记事ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "top0.ico");
            this.imageList1.Images.SetKeyName(1, "top2.ico");
            this.imageList1.Images.SetKeyName(2, "folder.ico");
            this.imageList1.Images.SetKeyName(3, "schedule.ico");
            this.imageList1.Images.SetKeyName(4, "task.ico");
            this.imageList1.Images.SetKeyName(5, "file.ico");
            this.imageList1.Images.SetKeyName(6, "thing.ico");
            // 
            // editor1
            // 
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontSize = FT.Windows.Controls.FontSize.Three;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(729, 547);
            this.editor1.TabIndex = 0;
            this.editor1.Load += new System.EventHandler(this.editor1_Load);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 展开节点ToolStripMenuItem
            // 
            this.展开节点ToolStripMenuItem.Name = "展开节点ToolStripMenuItem";
            this.展开节点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.展开节点ToolStripMenuItem.Text = "展开节点";
            this.展开节点ToolStripMenuItem.Click += new System.EventHandler(this.展开节点ToolStripMenuItem_Click);
            // 
            // 收缩节点ToolStripMenuItem
            // 
            this.收缩节点ToolStripMenuItem.Name = "收缩节点ToolStripMenuItem";
            this.收缩节点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.收缩节点ToolStripMenuItem.Text = "收缩节点";
            this.收缩节点ToolStripMenuItem.Click += new System.EventHandler(this.收缩节点ToolStripMenuItem_Click);
            // 
            // ThingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ThingEditor";
            this.Size = new System.Drawing.Size(933, 547);
            this.Load += new System.EventHandler(this.ThingEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private FT.Windows.Controls.Editor editor1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增计划书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增代办事项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增记事ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 展开节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收缩节点ToolStripMenuItem;
    }
}
