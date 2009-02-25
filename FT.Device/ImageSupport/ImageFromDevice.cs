using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FT.Device.ImageSupport
{
    /// <summary>
    /// 用来获取硬件的图像
    /// </summary>
    public class ImageFromDevice
    {
        [DllImport("Eztw32.dll")]
        private static extern int TWAIN_AcquireToClipboard(int hwndApp, int wPixTypes);
        [DllImport("Eztw32.dll")]
        private static extern int TWAIN_SelectImageSource(int hwndApp);
        /// <summary> 
        /// 选择设备 
        /// </summary> 
        public static void SelectImageSource()
        {
            //Func.TWAIN_SelectImageSource(0);

        }
        /// <summary>
        /// 从设备获取图像
        /// </summary>
        /// <returns></returns>
        public static Image GetImageFromImageSource()
        {
            
            TWAIN_AcquireToClipboard(0, 0);
            IDataObject obj1 = Clipboard.GetDataObject();
            if (obj1.GetDataPresent(DataFormats.Bitmap))
            {
                return (Image)obj1.GetData(DataFormats.Bitmap);
            }
            return null;
        } 


    }
}
