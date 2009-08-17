using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Device.ImageSupport;
using FT.Commons.Cache;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using FT.Windows.Forms;
using System.Drawing.Imaging;
using FT.Windows.Forms.CommonForm;
using FT.Windows.CommonsPlugin;

namespace DS.Plugins.Student
{
    public partial class DriverPicCapture : BaseSkinForm, IMessageFilter
    {
        #region 捕获图片

        Twain tw;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tw.Finish();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            TwainCommand cmd = tw.PassMessage(ref m);
            if (cmd == TwainCommand.Null)
            {
                EndingScan();
                tw.CloseSrc();
                return false;
            }
            if (cmd == TwainCommand.Not)
            {
                return false;
            }

            switch (cmd)
            {
                case TwainCommand.CloseRequest:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.CloseOk:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.DeviceEvent:
                    {
                        break;
                    }
                case TwainCommand.TransferReady:
                    {
                        ArrayList pics = tw.TransferPictures();
                        EndingScan();
                        tw.CloseSrc();
                        picnumber++;
                        if (pics.Count > 0)
                        {
                           
                        }
                        for (int i = 0; i < pics.Count; i++)
                        {
                            IntPtr img = (IntPtr)pics[i];


                            dibhand = img;
                            bmpptr = GlobalLock(dibhand);
                            pixptr = GetPixelInfo(bmpptr);
                            //Bitmap map = new Bitmap(130, 170);
                            Bitmap map = new Bitmap(bmprect.Width, bmprect.Height);
                            Graphics scannedImageGraphics = Graphics.FromImage(map);

                            IntPtr hdc = scannedImageGraphics.GetHdc();
                            // IntPtr hdc = map.GetHbitmap();
                            SetDIBitsToDevice(hdc, 0, 0, bmprect.Width, bmprect.Height,
                                    0, 0, 0, bmprect.Height, pixptr, bmpptr, 0);
                            scannedImageGraphics.ReleaseHdc(hdc);

                            // map.Save("c:\\tempgetimageformdevice.bmp");
                            // this.pictureBox1.Image = map;
                            if (set.CapWidth== set.DevWidth &&set.CapHeight ==  set.DevHeight)
                            {
                                this.picPic.Image = map;
                                this.SavePic();
                            }
                            else
                            {
                            CaptureImage form = new CaptureImage(map, this.picPic,set);
                            form.ShowDialog();
                            this.SavePic();
                            
                        }
                        
                            

                            /*
                            //333,266
                            Rectangle cltrect = ClientRectangle;
                            Point loc = this.pictureBox1.Location;
                            //100 128
                            Size size=this.pictureBox1.Size;
                            //Point scrol = AutoScrollPosition;

                           // Rectangle realrect = this.pictureBox1.Location;
                           // realrect.X -= scrol.X;
                          //  realrect.Y -= scrol.Y;

                            //240
                            int bot = bmprect.Height;

                           
                            dibhand = img;
                            bmpptr = GlobalLock(dibhand);
                            pixptr = GetPixelInfo(bmpptr);
                            IntPtr hdc = this.pictureBox1.CreateGraphics().GetHdc();
                            SetDIBitsToDevice(hdc, 0, 0, bmprect.Width, bmprect.Height,
                                    0, 0, 0, bmprect.Height, pixptr, bmpptr, 0);
                            //this.pictureBox1.CreateGraphics().ReleaseHdc(hdc);
                           // Image img = (Image)pics[i];
                           // PicForm newpic = new PicForm(img);
                           // newpic.MdiParent = this;
                            //this.pictureBox1.Image = img;
                            int picnum = i + 1;

                           
                           // newpic.Text = "ScanPass" + picnumber.ToString() + "_Pic" + picnum.ToString();
                          //  newpic.Show();
                             */

                        }
                        break;
                    }
            }

            return true;
        }

        protected IntPtr GetPixelInfo(IntPtr bmpptr)
        {
            bmi = new BITMAPINFOHEADER();
            Marshal.PtrToStructure(bmpptr, bmi);

            bmprect.X = bmprect.Y = 0;
            bmprect.Width = bmi.biWidth;
            bmprect.Height = bmi.biHeight;

            if (bmi.biSizeImage == 0)
                bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

            int p = bmi.biClrUsed;
            if ((p == 0) && (bmi.biBitCount <= 8))
                p = 1 << bmi.biBitCount;
            p = (p * 4) + bmi.biSize + (int)bmpptr;
            return (IntPtr)p;
        }

        BITMAPINFOHEADER bmi;

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst,
                                                int width, int height, int xsrc, int ysrc, int start, int lines,
                                                IntPtr bitsptr, IntPtr bmiptr, int color);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string outstr);

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal class BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }


        Rectangle bmprect;
        IntPtr dibhand;
        IntPtr bmpptr;
        IntPtr pixptr;

        private void EndingScan()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
                this.Enabled = true;
                this.Activate();
            }
        }

        private bool msgfilter;
        private int picnumber = 0;

        #endregion
        private void InitOnConstruct()
        {
            DictManager.BindIdCardType(this.cbIdCardType);
        }

        private CapturePhotoSet set=null;

        private Color transColor = SystemColors.Control;
        public DriverPicCapture()
        {
            InitializeComponent();
            this.InitOnConstruct();
            DriverPicCaptureConfig config = StaticCacheManager.GetConfig<DriverPicCaptureConfig>();
            set = StaticCacheManager.GetConfig<CapturePhotoSet>();
            if(set.BgRgbEnable)
            {
                transColor = Color.FromArgb(set.BgRgbR, set.BgRgbG, set.BgRgbB);
            }
            this.picPic.Size = new Size(set.CapWidth + 2, set.CapHeight + 2);
            this.Height = this.picPic.Location.Y + set.CapHeight + 40;
            this.txtPicPath.Text = config.PicPath;
            this.txtExportPath.Text = config.PicExpPath;
            tw = new Twain();
            tw.Init(this.Handle);
        }

        public DriverPicCapture(string idcard):this()
        {
            string path = this.txtPicPath.Text + "/" + idcard + ".jpg";
            this.txtIdCard.Text = idcard;
            if(File.Exists(path))
            {
                this.picPic.Image = Image.FromFile(path);
            }
        }

        public DriverPicCapture(string idcardType,string idcard):this()
        {
            this.cbIdCardType.SelectedValue = idcardType;
            this.txtIdCard.Text = idcard;
            string path = this.txtPicPath.Text + "/" + this.GetFileName();
            
            if (File.Exists(path))
            {
                this.picPic.Image = Image.FromFile(path);
            }
        }

        private string GetFileName()
        {
            if(this.cbIdCardType.SelectedValue.ToString()!="A")
            {
                return this.cbIdCardType.SelectedValue.ToString() + this.txtIdCard.Text.Trim() + ".jpg";
            }
            else{
                return this.txtIdCard.Text.Trim() + ".jpg";

            }
        }

        private string GetRealPath()
        {
            return this.txtPicPath.Text + "/" + this.GetFileName();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(this.txtExportPath.Text.Length==0)
            {

                MessageBoxHelper.Show("必须先设置导出的图片路径！");
                return;
            }
            if(this.picPic.Image!=null)
            {
                string realpath = this.GetRealPath();
                if(File.Exists(realpath))
                {

                    try
                    {
                        File.Copy(realpath, this.txtExportPath.Text + "/" + this.GetFileName(), true);
                        MessageBoxHelper.Show("成功导出图片！");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBoxHelper.Show("导出路径不存在！");
                    }
                   
                }

            }
        }

        private void btnPathSet_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtPicPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtPicPath.Text = result;
                this.SaveSetting();
            }
        }

        private void btnDeviceSet_Click(object sender, EventArgs e)
        {
            tw.Select();
        }

       

        private void SavePic()
        {
            if(this.picPic.Image!=null)
            {
                Color tmp = transColor;
                if(!set.BgRgbEnable)
                {
                    tmp = SystemColors.Control;
                }
                ImageHelper.SaveOneInchPic(this.picPic.Image,tmp,set.Dpi, this.GetRealPath());
            }

            
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            
            
            if(this.txtPicPath.Text.Length==0)
            {
                MessageBoxHelper.Show("请先配置要采集的照片的存放路径！");
                this.txtPicPath.Focus();
                return;

            }
            string idcard = this.txtIdCard.Text.Trim();
            if(idcard.Length==0)
            {
                
                MessageBoxHelper.Show("请先输入要采集人的身份证明号码！");
                this.txtIdCard.Focus();
                return;
            }
            if (idcard.Length == 15)
            {
                idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
                this.txtIdCard.Text = idcard;
            }
            if (this.cbIdCardType.SelectedIndex == 0)
            {
                string error = IDCardHelper.Validate(idcard);
                if (error.Length > 0)
                {
                    MessageBoxHelper.Show(error);
                    this.txtIdCard.Focus();
                    return;
                }
            }
            try
            {
                

                if (!msgfilter)
                {
                    this.Enabled = false;
                    msgfilter = true;
                    Application.AddMessageFilter(this);
                }
                FileHelper.ClearCapturePhotoes();
                tw.Acquire();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("没有找到合适外设！");
            }
        }

        private void btnExportPathSet_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtExportPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtExportPath.Text = result;
                this.SaveSetting();
            }
        }

        private void SaveSetting()
        {

            DriverPicCaptureConfig config = new DriverPicCaptureConfig();
            config.PicPath = this.txtPicPath.Text;
            config.PicExpPath = this.txtExportPath.Text;
            StaticCacheManager.SaveConfig<DriverPicCaptureConfig>(config);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureImage form = new CaptureImage(Image.FromFile("c:\\test.jpg"), this.picPic, set);
            form.ShowDialog();
            this.SavePic();
        }

        private void picPic_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.OpenImage();

            if (path != string.Empty)
            {

                try
                {
                    this.picPic.Image = Image.FromFile(path);
                    this.SavePic();
                    
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show("图片格式不对或正被其他程序使用！");
                }
            }
        }

      
    }
}