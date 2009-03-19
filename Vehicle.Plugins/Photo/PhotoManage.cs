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
using System.IO;

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
        //����·���г�·���µ�ͼƬ,ֻ����bmp��jpg�ļ�
        private void ListImageFileName(string dir)
        {
            if (dir.Length > 0)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(dir);
                if (dirinfo.Exists)
                {
                    this.cbImageFiles.Items.Clear();
                    string extension=string.Empty;
                    foreach (FileInfo file in dirinfo.GetFiles())
                    {
                        extension=file.Extension.ToLower();
                        if (extension.EndsWith("bmp") || extension.EndsWith("jpg"))
                        {
                            this.cbImageFiles.Items.Add(file.Name);
                        }
                    }
                }
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            string dir = FileDialogHelper.OpenDir();
            if (dir.Length > 0)
            {
                this.txtDir.Text = dir;
                this.ListImageFileName(dir);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string classical = this.cbClassical.Text.Trim();
            string type = this.cbType.Text.Trim();
            if (classical == string.Empty || classical == "��ѡ��")
            {
                MessageBoxHelper.Show("��ѡ�������������Ʒ�ƣ�");
                return;

            }
            if (type == string.Empty || type == "��ѡ��")
            {
                MessageBoxHelper.Show("��ѡ��������복���ͺţ�");
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
                    temp.GroupType = "����Ʒ��";
                    temp.Description = temp.Text;
                    FT.DAL.Orm.SimpleOrmOperator.Create(temp);
                    temp.Text = this.cbType.Text;
                    temp.Value = this.cbType.Text;
                    temp.GroupType = "�����ͺ�";
                    temp.Description = this.cbClassical.Text;
                    FT.DAL.Orm.SimpleOrmOperator.Create(temp);
                    MessageBoxHelper.Show("��ӳɹ���");
                    //Constant.InitCbCnClassical(this.cbClassical);
                }
                else
                {
                    MessageBoxHelper.Show("����ͼƬ����ʧ�ܣ�");
                }

            }
            else
            {
                MessageBoxHelper.Show("�������ʧ�ܣ�");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices != null && this.listView1.SelectedIndices.Count == 1)
            {
                VehiclePhoto temp = this.photos[this.listView1.SelectedIndices[0]] as VehiclePhoto;
                if (MessageBoxHelper.Confirm("ȷ��ɾ��" + temp.Cn_Classical + "-" + temp.Cn_Type + "��"))
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
                MessageBoxHelper.Show("����ѡ����Ҫɾ������Ƭ��");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.picPhoto.Image == null)
            {
                MessageBoxHelper.Show("û��ͼƬ�ɵ�����");
                return;
            }

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
                MessageBoxHelper.Show("�����ɹ���");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string classical = this.cbClassical.Text.Trim();
            string type = this.cbType.Text.Trim();
            if (classical == string.Empty && type == string.Empty)
            {
                MessageBoxHelper.Show("������ѡ��һ�������ٲ�ѯ��");
                return;

            }
            string condition = "where 1=1 ";
            if (classical != string.Empty)
            {
                condition += " and cn_classical like '%" + classical + "%'";
            }
            if (type != string.Empty && type != "��ѡ��")
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
        /// ���»�ȡ��ѯ����������ݵ�ListView��
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

        private SystemConfig config;

        private void PhotoManage_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                if (config.PhotoDir != null && config.PhotoDir.Length > 0)
                {
                    this.txtDir.Text = config.PhotoDir;
                    this.ListImageFileName(config.PhotoDir);
                }
            }
        }

        private void cbImageFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string path = this.txtDir.Text + "\\" + this.cbImageFiles.Text;
                FileInfo file = new FileInfo(path);
                if (file.Length > config.CompressLength)
                {
                    Bitmap myBitmap = new Bitmap(path);

                    //����80*100������ͼ
                    Bitmap image = (Bitmap)myBitmap.GetThumbnailImage(config.ImageWidth,config.ImageHeight, null, IntPtr.Zero);
                    //Bitmap image = (Bitmap)Image.FromFile(path);
                    //image.Width = this.picPhoto.Width;
                    //image.Height = this.picPhoto.Height;
                    if (this.picPhoto.Image != null)
                    {
                        this.picPhoto.Image.Dispose();
                        this.picPhoto.Image = null;
                    }
                    ImageHelper.KiSaveAsJPEG(image, "tmpphoto.jpg", config.CompressRate);
                    myBitmap.Dispose();
                    image.Dispose();
                    FileInfo newfile = new FileInfo("tmpphoto.jpg");
                    if (newfile.Length > config.CompressLength)
                    {
                        MessageBoxHelper.Show("ѹ�����ͼƬ��Ȼ����" + config.CompressLength/1024 + "KB��");

                    }
                    Image newimage = Image.FromFile("tmpphoto.jpg");
                    this.picPhoto.Image = newimage;

                }
                else
                {
                    Image image = Image.FromFile(path);
                    this.picPhoto.Image = image;
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}