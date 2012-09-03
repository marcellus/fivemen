using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FT.Commons.TwainSupport
{
    public class VedioGrap
    {
        private static int hHwnd;
        //private const int port = 2000;

        private struct videohdr_tag
        {
            //private byte[] lpData;
            //private int dwBufferLength;
            //private int dwBytesUsed;
            //private int dwTimeCaptured;
            //private int dwUser;
            //private int dwFlags;
            //private int[] dwReserved;
        }

        private delegate bool CallBack(int hwnd, int lParam);

        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);

        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszVer, int cbVer);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool DestroyWindow(int hndw);

        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)]   object lParam);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("vfw32.dll")]
        private static extern string capVideoStreamCallback(int hwnd, videohdr_tag videohdr_tag);

        [DllImport("vicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool capSetCallbackOnFrame(int hwnd, string s);



        /// <summary>
        /// 开始载入视频
        /// </summary>            
        public bool OpenCapture(Panel pnlVideo)
        {
            bool videostart = false;
            int intWidth = pnlVideo.Width;
            int intHeight = pnlVideo.Height;
            int intDevice = 0;
            string refDevice = intDevice.ToString();

            //创建视频窗口并得到句柄            
            hHwnd = VedioGrap.capCreateCaptureWindowA(ref refDevice, 1342177280, 0, 0, 640, 480, pnlVideo.Handle.ToInt32(), 0);

            if (SendMessage(hHwnd, 0x40a, intDevice, 0) > 0)
            {
                SendMessage(hHwnd, 0x435, -1, 0);
                SendMessage(hHwnd, 0x434, 0x01, 0);
                SendMessage(hHwnd, 0x432, -1, 0);
                SetWindowPos(hHwnd, 1, 0, 0, intWidth, intHeight, 6);

                videostart = true;
            }
            else
            {
                VedioGrap.DestroyWindow(hHwnd);

                videostart = false;
                MessageBox.Show("加载视频失败,请检查是否有安装设备！", "拍照");
            }

            return videostart;
        }

        /// <summary>
        /// 停止视频
        /// </summary>
        public void StopVideo()
        {
            try
            {
                //停止视频注销视频句柄
                SendMessage(hHwnd, 0x40b, 0, 0);
                DestroyWindow(hHwnd);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 截图
        /// </summary>
        /// <returns></returns>
        public Image GrapPhoto()
        {
            Image photo = null;

            SendMessage(hHwnd, 0x41e, 0, 0);

            IDataObject obj1 = Clipboard.GetDataObject();

            if (obj1.GetDataPresent(typeof(Bitmap)))
            {
                photo = (Image)obj1.GetData(typeof(Bitmap));
                //截完图不能关闭视频，否则无法继续截图
                //StopVideo();
            }

            return photo;
        }

    }
}
