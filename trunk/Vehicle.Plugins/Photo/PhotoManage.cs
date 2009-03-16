using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Collections;
using FT.Windows.CommonsPlugin;

namespace Vehicle.Plugins
{
    public partial class PhotoManage : Form
    {
        private ArrayList photos = new ArrayList();
        private string suffix = string.Empty;
        public PhotoManage()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.OpenImage();


            if (path != string.Empty)
            {
                int nIndex = path.LastIndexOf(".");
                this.suffix = path.Substring(nIndex + 1);

                try
                {
                    this.picPhoto.Image = Image.FromFile(path);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show("图片格式不对或正被其他程序使用！");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string classical = this.cbClassical.Text.Trim();
            string type = this.cbType.Text.Trim();
            if (classical == string.Empty || classical == "请选择")
            {
                MessageBoxHelper.Show("请选择或者输入中文品牌！");
                return;

            }
            if (type == string.Empty || type == "请选择")
            {
                MessageBoxHelper.Show("请选择或者输入车辆型号！");
                return;
            }
            VehiclePhotoAccess access = new VehiclePhotoAccess();
            VehiclePhoto photo = new VehiclePhoto();
            photo.Cn_Classical = classical;
            photo.Cn_Type = type;
            photo.Picture = this.picPhoto.Image;
            photo.Suffix = this.suffix;
            bool result = access.Add(photo);
            if (result)
            {
                if (access.UpdateImage(access.GetLasted().Id, photo.Picture))
                {
                   
                    Dict temp = new Dict();
                    temp.Text = this.cbClassical.Text;
                    temp.Value = this.cbClassical.Text;
                    temp.GroupType = "中文品牌";
                    temp.Description = temp.Text;
                    FT.DAL.Orm.SimpleOrmOperator.Create(temp);
                    temp.Text = this.cbType.Text;
                    temp.Value = this.cbType.Text;
                    temp.GroupType = "车辆型号";
                    temp.Description = this.cbClassical.Text;
                    FT.DAL.Orm.SimpleOrmOperator.Create(temp);
                    MessageBoxHelper.Show("添加成功！");
                    //Constant.InitCbCnClassical(this.cbClassical);
                }
                else
                {
                    MessageBoxHelper.Show("更新图片过程失败！");
                }

            }
            else
            {
                MessageBoxHelper.Show("添加数据失败！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices != null && this.listView1.SelectedIndices.Count == 1)
            {
                VehiclePhoto temp = this.photos[this.listView1.SelectedIndices[0]] as VehiclePhoto;
                if (MessageBoxHelper.Confirm("确定删除" + temp.Cn_Classical + "-" + temp.Cn_Type + "吗？"))
                {
                    VehiclePhotoAccess access = new VehiclePhotoAccess();
                    if (access.Delete(temp))
                    {
                        this.photos.RemoveAt(this.listView1.SelectedIndices[0]);
                        this.listView1.Items.Remove(this.listView1.SelectedItems[0]);

                    }
                }
            }
            else
            {
                MessageBoxHelper.Show("请先选中需要删除的照片！");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            if (this.cbClassical.Text != string.Empty && this.cbType.Text != string.Empty)
            {
                filename = FileDialogHelper.SaveImageWithName(this.cbClassical.Text + "_" + this.cbType.Text + "." + this.suffix);
            }
            else
            {
                filename = FileDialogHelper.SaveImage();
            }
            if (filename != string.Empty)
            {
                this.picPhoto.Image.Save(filename);
                MessageBoxHelper.Show("导出成功！");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string classical = this.cbClassical.Text.Trim();
            string type = this.cbType.Text.Trim();
            if (classical == string.Empty && type == string.Empty)
            {
                MessageBoxHelper.Show("请至少选择一个条件再查询！");
                return;

            }
            string condition = "where 1=1 ";
            if (classical != string.Empty)
            {
                condition += " and cn_classical like '%" + classical + "%'";
            }
            if (type != string.Empty && type != "请选择")
            {
                condition += " and cn_type like '%" + type + "%'";
            }
            VehiclePhotoAccess access = new VehiclePhotoAccess();
            this.photos = access.SearchList(condition);
            this.ReloadCollection();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices != null && this.listView1.SelectedIndices.Count == 1)
            {
                VehiclePhoto temp = this.photos[this.listView1.SelectedIndices[0]] as VehiclePhoto;
                this.picPhoto.Image = temp.Picture;
                this.cbClassical.Text = temp.Cn_Classical;
                //this.cbType.Text = temp.Cn_Type;
                this.suffix = temp.Suffix;
            }
        }

        /// <summary>
        /// 重新获取查询结果集合数据到ListView上
        /// </summary>
        private void ReloadCollection()
        {
            this.listView1.Items.Clear();
            VehiclePhoto temp = null;
            for (int i = 0; i < this.photos.Count; i++)
            {
                temp = this.photos[i] as VehiclePhoto;
                this.listView1.Items.Add(new ListViewItem(new string[] { temp.Cn_Classical, temp.Cn_Type }));
            }
        }

    }
}