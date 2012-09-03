using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FT.Commons.Tools;
using System.Drawing.Imaging;
using FT.Commons.TwainSupport;
using System.Collections;
using System.Runtime.InteropServices;


namespace FT.Windows.Controls.PanelEx
{
    public partial class ImageProcessPanel : UserControl
    {
        //TwainHelper twain;
        VedioGrap vedioGrap;
        /*Usage
         
         VedioGrap vedioOperator = new VedioGrap (); //实例化视频类
         videostart = vedioOperator.OpenCapture (pnlVideo); //打开视频
         pbTakePhoto.Image = vedioOperator.GrapPhoto (); //拍照
         vedioOperator.StopVideo (); Clipboard.Clear (); //关闭移除
         */
        public ImageProcessPanel()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (twain != null)
               // {
                   // twain.EndPhoto();
                //}
                if (vedioGrap != null)
                {
                    vedioGrap.StopVideo();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

       

        private Image processImage;

        private Image processedImage;

        public Image ProcessImage
        {
            get { return processImage; }



            set { processImage = value;

            if (this.processImage != null)
            {
                processedImage = processImage;
                this.OrgBackImage();
               //Graphics g= this.CreateGraphics();
                //Point point=new Point(10,10);
               // Size size=new Size(this.Width-100,this.Height-120);

               // Rectangle rec = new Rectangle(point, size);
              //  g.DrawImage(this.processImage, rec);
               // this.panelContent.BackgroundImage = this.processImage;
               // this.panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            }
            
            }
        }

        private void ImageProcessPanel_Resize(object sender, EventArgs e)
        {
           // this.btnBigSize.Location = new Point(this.Width - 100, 100);
           // this.btnSmallSize.Location = new Point(this.Width - 100, 150);
        }

        private void btnBorder_Click(object sender, EventArgs e)
        {
            this.LoadImage("SuCai\\Borders", 1);
        }

        private void LoadImage(string dir,int type)
        {
            this.panelDecorator.Controls.Clear();

            int width=80;
            int height=120;
            int sep=10;
            int x=20;
            int y=30;
            string dirTmp=Path.Combine(Application.StartupPath,dir);
            DirectoryInfo dirInfo = new DirectoryInfo(dirTmp);
            FileInfo[] files=dirInfo.GetFiles();
            PictureBox pic=null;
            for(int i=0;i<files.Length;i++)
            {
                if(i==3)
                {
                    break;
                }
                pic=new PictureBox();
                pic.Width=width;
                pic.Height=height;
                pic.BackgroundImageLayout=ImageLayout.Stretch;
                pic.BackgroundImage=Image.FromFile(files[i].FullName);
                pic.Location=new Point(x+i*(sep+width),y);
                if (type == 0)
                {
                    pic.Click += new EventHandler(pic_Image_Click);
                }
                else
                {
                    pic.Click += new EventHandler(pic_Border_Click);
                }
                this.panelDecorator.Controls.Add(pic);
                
            }

            
        }

        private PictureBox currentPic;

        void pic_Image_Click(object sender, EventArgs e)
        {
            if (processImage == null)
            {
                return;
            }
            PictureBox pic = sender as PictureBox;
            PictureBox picAdd = new PictureBox();
            picAdd.Width = pic.Width;
            picAdd.Height = pic.Height;
            picAdd.Image = pic.BackgroundImage.Clone() as Image;
            picAdd.SizeMode = PictureBoxSizeMode.StretchImage;
            picAdd.Location = new Point((this.panelContent.Width-pic.Width) / 2, (this.panelContent.Height-pic.Height) / 2);
            picAdd.Click += new EventHandler(picAdd_Click);
            WinFormHelper.DropMove(picAdd);
            picAdd.MouseMove += new MouseEventHandler(picAdd_MouseMove);
            this.panelContent.Controls.Add(picAdd);
            this.currentPic = picAdd;

            //throw new NotImplementedException();
        }

        void picAdd_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void ResetBackImage()
        {
            if (this.processedImage != null)
            {
               // Graphics g = this.panelContent.CreateGraphics();
               // g.DrawImage(this.processedImage, new Rectangle(new Point(0, 0), new Size(this.panelContent.Width, this.panelContent.Height)));
               // g.Dispose();
                this.panelContent.BackgroundImage = this.processedImage;
                this.panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        void picAdd_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            this.currentPic = pic;
            //pic.BorderStyle=BorderStyle.
        }

        private PictureBox picBorder = null;
        void pic_Border_Click(object sender, EventArgs e)
        {
            if (processImage == null)
            {
                return;
            }
            PictureBox pic = sender as PictureBox;
            Image img = pic.BackgroundImage.Clone() as Image;
           

            img=ImageHelper.ClearWhiteToTransparent(img);
           // Image img = this.processImage.Clone() as Image;
            //Graphics.
            //OrgBackImage();
            //this.processImage.Width = this.panelContent.Width;
            //this.processImage.Height
            Image orgImg=this.processImage.Clone() as Image;
            Graphics g = Graphics.FromImage(orgImg);
            g.DrawImage(img, new Rectangle(new Point(0, 0), new Size(orgImg.Width, orgImg.Height)));
           // Brush brush = new SolidBrush(Color.Red);
           // Pen pen = new Pen(brush,3);
            //pen.Alignment = PenAlignment.Inset;
           // pen.DashStyle = ds;
           // g.DrawLine(pen,new Point(0,0),new Point(300,300));
            g.Dispose();
            this.processedImage = orgImg;
           // this.processedImage.Save("tmp.jpg");
            this.ResetBackImage();
            /*
            if (this.picBorder != null)
            {
                
                picBorder.Image = img;
            }
            else
            {
                PictureBox picAddBorder = new PictureBox();
                
                picAddBorder.Width = this.panelContent.Width;
                picAddBorder.Height = this.panelContent.Height;
                Image img=pic.BackgroundImage.Clone() as Image;
                picAddBorder.Image = img;
                picAddBorder.SizeMode = PictureBoxSizeMode.StretchImage;
                this.panelContent.Controls.Add(picAddBorder);
                this.picBorder = picAddBorder;
            }
            picBorder.BringToFront();
             * */
           
            //throw new NotImplementedException();
        }

        private void btnImages_Click(object sender, EventArgs e)
        {
            this.LoadImage("SuCai\\Images",0);
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            
        }

        public void BeginPhoto()
        {
           // twain.BeginPhoto();
            vedioGrap.OpenCapture(this.panelContent);
        }

        public void EndPhoto()
        {
           // twain.EndPhoto();
            Image image = vedioGrap.GrapPhoto();
            
            vedioGrap.StopVideo();
            Clipboard.Clear();
            this.ProcessImage = image;
        }

        private void ImageProcessPanel_Load(object sender, EventArgs e)
        {
            //twain = new TwainHelper(this.panelContent);
            vedioGrap = new VedioGrap();
        }

        private void btnSmallSize_Click(object sender, EventArgs e)
        {
            if (this.currentPic != null)
            {
                this.currentPic.Scale(new SizeF(0.8f,0.8f));
            }
        }

        private void btnBigSize_Click(object sender, EventArgs e)
        {
            if (this.currentPic != null)
            {
                this.currentPic.Scale(new SizeF(1.2f, 1.2f));
            }
        }

        public Image GetFinalImage()
        {
            // Graphics grpScreen = Graphics.FromHwnd(IntPtr.Zero);
            /*
            Bitmap bmpTmp = new Bitmap("bg.jpg");
             Bitmap bmp = new Bitmap(bmpTmp,new Size(this.panelContent.Width, this.panelContent.Height));
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(this.panelContent.Location.X, this.panelContent.Location.Y, this.panelContent.Location.X+this.panelContent.Width,this.panelContent.Height+this.panelContent.Location.Y, bmp.Size);
            bmp.Save("final.jpg");
            g.Dispose();
             * */

           Image bmp= ImageHelper.CaptureControl(this.panelContent);
           bmp.Save("final.jpg");
           return bmp;

         
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.panelContent.Controls.Clear();
            OrgBackImage();
           
        }

        private void OrgBackImage()
        {
            if (this.processImage != null)
            {
                Graphics g = this.panelContent.CreateGraphics();
                g.DrawImage(this.processImage, new Rectangle(new Point(0, 0), new Size(this.panelContent.Width, this.panelContent.Height)));
                g.Dispose();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentPic != null)
            {
                this.panelContent.Controls.Remove(this.currentPic);
                this.currentPic = null;
            }
        }
    }
}
