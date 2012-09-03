using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.TwainSupport;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;

namespace FT.Commons.Tools
{
    public class TwainHelper : BaseHelper, IMessageFilter
    {
        Twain tw;
        private Control ctr;
        private Form frm;
        public TwainHelper(Control ctr)
        {
            tw = new Twain();
            this.ctr = ctr;
            frm = ctr.FindForm();
            
            ctr.BackgroundImageLayout = ImageLayout.Stretch;
            tw.Init(ctr.Handle);
        }

        public void SelectDevice()
        {
            tw.Select();
        }

        public void BeginPhoto()
        {
            if (!msgfilter)
            {
               // ctr.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            tw.Acquire();
        }

        public void EndPhoto()
        {
            tw.Finish();
        }


        public bool PreFilterMessage(ref Message m)
        {
            TwainCommand cmd = tw.PassMessage(ref m);
            if (cmd == TwainCommand.Not)
                return false;

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
                        for (int i = 0; i < pics.Count; i++)
                        {
                            IntPtr img = (IntPtr)pics[i];


                            dibhand = img;
                            bmpptr = GlobalLock(dibhand);
                            pixptr = GetPixelInfo(bmpptr);
                            Bitmap map = new Bitmap(bmprect.Width, bmprect.Height);
                            Graphics scannedImageGraphics = Graphics.FromImage(map);

                            IntPtr hdc = scannedImageGraphics.GetHdc();
                            // IntPtr hdc = map.GetHbitmap();
                            SetDIBitsToDevice(hdc, 0, 0, bmprect.Width, bmprect.Height,
                                    0, 0, 0, bmprect.Height, pixptr, bmpptr, 0);
                            scannedImageGraphics.ReleaseHdc(hdc);

                            ctr.BackgroundImage = map;
                            
                            // map.Save("c:\\tempgetimageformdevice.bmp");
                           // this.pictureBox1.Image = map;

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
                //ctr.Enabled = true;
               // ctr.Activate();
            }
        }

        private bool msgfilter;
        private int picnumber = 0;


    }
}
