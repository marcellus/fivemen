using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool
{
    public partial class ZipTestForm : Form
    {
        public ZipTestForm()
        {
            InitializeComponent();
        }

        private void btnZipDir_Click(object sender, EventArgs e)
        {
            string dir=FileDialogHelper.OpenDir(this.txtZipDir.Text.Trim());
            if (dir.Length > 0)
            {
                this.txtZipDir.Text = dir;
            }
        }

        private void btnZipFile_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.SaveZip(this.txtZipFile.Text.Trim());
            if (result.Length > 0)
            {
                this.txtZipFile.Text = result;
            }
        }

        private void btnUnzipDir_Click(object sender, EventArgs e)
        {
            string dir = FileDialogHelper.OpenDir(this.txtUnZipDir.Text.Trim());
            if (dir.Length > 0)
            {
                this.txtUnZipDir.Text = dir;
            }
        }

        private void btnUnZipFile_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenZip(this.txtUnZipFile.Text.Trim());
            if (result.Length > 0)
            {
                this.txtUnZipFile.Text = result;
            }
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            if (this.txtZipDir.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("请选择要压缩的文件夹路径！");
                return;
            }
            if (this.txtZipFile.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("请选择要压缩的文件名称！");
                return;
            }
            if (FileHelper.ZipDir(this.txtZipDir.Text.Trim(), this.txtZipFile.Text.Trim(),this.txtPassword.Text.Trim()))
            {
                MessageBoxHelper.Show("压缩成功！");
            }
        }

        private void btnUnZip_Click(object sender, EventArgs e)
        {
            if (this.txtUnZipDir.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("请选择要解压的文件夹路径！");
                return;
            }
            if (this.txtUnZipFile.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("请选择要解压缩的文件名称！");
                return;
            }
            if (FileHelper.UnZipDir(this.txtUnZipFile.Text.Trim(), this.txtUnZipDir.Text.Trim(), this.txtPassword.Text.Trim()))
            {
                MessageBoxHelper.Show("解压缩成功！");
            }
        }
    }
}