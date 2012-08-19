using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace FT.Windows.Controls.PanelEx
{
    public partial class AdShowPanel : UserControl
    {
        public AdShowPanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private bool IsIn = true;
        private int CurrentIndex = 0;

        private void BeginCycleImage()
        {
            while (true)
            {

                if (IsIn)
                {
                    DateTime begin=System.DateTime.Now;
                    InImage(CurrentIndex);
                    DateTime end = System.DateTime.Now;
                    double c = end.Subtract(begin).TotalMilliseconds;
                    Console.WriteLine("淡入图像花费时间:"+c.ToString());
                }
                else
                {
                    DateTime begin = System.DateTime.Now;
                    OutImage(CurrentIndex);
                    DateTime end = System.DateTime.Now;
                    double c = end.Subtract(begin).TotalMilliseconds;
                    Console.WriteLine("淡出图像花费时间:" + c.ToString());
                }
                //System.Threading.Thread.Sleep(1000);
            }
            
        }
        private void OutImage(int index)
        {
            //淡出显示图像
            try
            {
                Image MyBitmap = lists[index];
                Console.WriteLine(System.DateTime.Now.ToLongTimeString()+"淡出图像"+index);
                Graphics g = this.CreateGraphics();
                g.Clear(Color.Gray);
                int width = MyBitmap.Width;
                int height = MyBitmap.Height;
                ImageAttributes attributes = new ImageAttributes();
                ColorMatrix matrix = new ColorMatrix();
                //创建淡出颜色矩阵
                matrix.Matrix00 = (float)0.0;
                matrix.Matrix01 = (float)0.0;
                matrix.Matrix02 = (float)0.0;
                matrix.Matrix03 = (float)0.0;
                matrix.Matrix04 = (float)0.0;
                matrix.Matrix10 = (float)0.0;
                matrix.Matrix11 = (float)0.0;
                matrix.Matrix12 = (float)0.0;
                matrix.Matrix13 = (float)0.0;
                matrix.Matrix14 = (float)0.0;
                matrix.Matrix20 = (float)0.0;
                matrix.Matrix21 = (float)0.0;
                matrix.Matrix22 = (float)0.0;
                matrix.Matrix23 = (float)0.0;
                matrix.Matrix24 = (float)0.0;
                matrix.Matrix30 = (float)0.0;
                matrix.Matrix31 = (float)0.0;
                matrix.Matrix32 = (float)0.0;
                matrix.Matrix33 = (float)0.0;
                matrix.Matrix34 = (float)0.0;
                matrix.Matrix40 = (float)0.0;
                matrix.Matrix41 = (float)0.0;
                matrix.Matrix42 = (float)0.0;
                matrix.Matrix43 = (float)0.0;
                matrix.Matrix44 = (float)0.0;
                matrix.Matrix33 = (float)1.0;
                matrix.Matrix44 = (float)1.0;
                //从1到0进行修改色彩变换矩阵主对角线上的数值
                //依次减少每种色彩分量
                Single count = (float)1.0;
                while (count > 0.0)
                {
                    matrix.Matrix00 = (float)count;
                    matrix.Matrix11 = (float)count;
                    matrix.Matrix22 = (float)count;
                    matrix.Matrix33 = (float)count;
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(MyBitmap, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, attributes);
                    System.Threading.Thread.Sleep(40);
                    count = (float)(count - 0.01);
                }
                IsIn = true;
                if (CurrentIndex < this.lists.Count-1)
                {
                    CurrentIndex++;
                }
                else
                {
                    CurrentIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

        }

        private void InImage(int index)
        {
            //淡入显示图像
            try
            {
                Console.WriteLine(System.DateTime.Now.ToLongTimeString() + "淡入图像" + index);
                Image MyBitmap=lists[index];
                Graphics g = this.CreateGraphics();
                g.Clear(Color.Gray);
                int width = MyBitmap.Width;
                int height = MyBitmap.Height;
                ImageAttributes attributes = new ImageAttributes();
                ColorMatrix matrix = new ColorMatrix();
                //创建淡入颜色矩阵
                matrix.Matrix00 = (float)0.0;
                matrix.Matrix01 = (float)0.0;
                matrix.Matrix02 = (float)0.0;
                matrix.Matrix03 = (float)0.0;
                matrix.Matrix04 = (float)0.0;
                matrix.Matrix10 = (float)0.0;
                matrix.Matrix11 = (float)0.0;
                matrix.Matrix12 = (float)0.0;
                matrix.Matrix13 = (float)0.0;
                matrix.Matrix14 = (float)0.0;
                matrix.Matrix20 = (float)0.0;
                matrix.Matrix21 = (float)0.0;
                matrix.Matrix22 = (float)0.0;
                matrix.Matrix23 = (float)0.0;
                matrix.Matrix24 = (float)0.0;
                matrix.Matrix30 = (float)0.0;
                matrix.Matrix31 = (float)0.0;
                matrix.Matrix32 = (float)0.0;
                matrix.Matrix33 = (float)0.0;
                matrix.Matrix34 = (float)0.0;
                matrix.Matrix40 = (float)0.0;
                matrix.Matrix41 = (float)0.0;
                matrix.Matrix42 = (float)0.0;
                matrix.Matrix43 = (float)0.0;
                matrix.Matrix44 = (float)0.0;
                matrix.Matrix33 = (float)1.0;
                matrix.Matrix44 = (float)1.0;
                //从0到1进行修改色彩变换矩阵主对角线上的数值
                //使三种基准色的饱和度渐增
                Single count = (float)0.0;
                while (count < 1.0)
                {
                    matrix.Matrix00 = count;
                    matrix.Matrix11 = count;
                    matrix.Matrix22 = count;
                    matrix.Matrix33 = count;
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(MyBitmap, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, attributes);
                    System.Threading.Thread.Sleep(40);
                    count = (float)(count + 0.02);
                }
                IsIn = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

        }

        private Thread cycleThread;

        private List<Image> lists = new List<Image>();

        /// <summary>
        /// 设置要展示的广告内容图片
        /// </summary>
        public List<Image> Lists
        {
            get { return lists; }
            set {
                if (
                cycleThread
                    != null)
                {
                    cycleThread.Abort();
                }
                lists = value;
                if (lists.Count > 0)
                {
                    cycleThread = new Thread(new ThreadStart(BeginCycleImage));
                    cycleThread.IsBackground = true;
                    cycleThread.Start();
                }
            
            }
        }
        
        
    }
}
