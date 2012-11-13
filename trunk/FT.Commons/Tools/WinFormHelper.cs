using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.WindowsService.SystemInfo;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FT.Commons.Tools
{
    public class WinFormHelper : BaseHelper
    {
        private WinFormHelper()
        {
        }
        #region （注：该方法可以屏蔽win和alt+F4但是不能屏蔽ctrl+alt+del）
        // 安装钩子
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        // 卸载钩子
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int idHook);
        // 继续下一个钩子
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        //声明定义
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        static int hKeyboardHook = 0;
        static HookProc KeyboardHookProcedure;

        // 安装钩子
        public static void HookStart()
        {
            if (hKeyboardHook == 0)
            {
                // 创建HookProc实例
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                //定义全局钩子
                hKeyboardHook = SetWindowsHookEx(13, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (hKeyboardHook == 0)
                {
                    HookStop(hKeyboardHook);
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }
        //钩子子程就是钩子所要做的事情。
        private static int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            //这里可以添加别的功能的代码
            return 1;
        }
        // 卸载钩子
        public static void HookStop(int handler)
        {
            bool retKeyboard = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard)) throw new Exception("UnhookWindowsHookEx failed.");
        }
        #endregion

        /*  public static void LocationAfter(Control ctr, Control ctr...)
          {
              next.Location = new Point(ctr.Location.X + ctr.Width, ctr.Location.Y);
          }
         * */
        public static void LocationAfter(Control ctr, Control next)
        {
            next.Location = new Point(ctr.Location.X + ctr.Width, ctr.Location.Y);
        }

        public static void VerLocationAfter(Control ctr, Control next, int sep)
        {
            next.Location = new Point(ctr.Location.X, ctr.Location.Y + ctr.Height + sep);
        }


        public static void InitButtonStyle(Control ctr)
        {
            if (ctr == null)
            {
                return;
            }
            ctr.MouseHover += new EventHandler(ctr_MouseHover);
            ctr.MouseLeave += new EventHandler(ctr_Click);
            ctr.Click += new EventHandler(ctr_Click);


        }

        static void ctr_MouseHover(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("用户鼠标悬停到按钮上了！！");
#endif
            if (sender is PictureBox)
            {
                PictureBox btn = sender as PictureBox;

                btn.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (sender is Button)
            {
                Button btn = sender as Button;
                btn.FlatStyle = FlatStyle.Standard;

            }
            else if (sender is Label)
            {
                Label btn = sender as Label;

                btn.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        static void ctr_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("用户单击了样式按钮！！");
#endif
            if (sender is PictureBox)
            {
                PictureBox btn = sender as PictureBox;

                btn.BorderStyle = BorderStyle.None;
            }
            else if (sender is Button)
            {
                Button btn = sender as Button;
                btn.FlatStyle = FlatStyle.Flat;
            }
            else if (sender is Label)
            {
                Label btn = sender as Label;

                btn.BorderStyle = BorderStyle.None;
            }
        }

        static void ctr_MouseMove(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("用户鼠标移动到按钮上了！！");
#endif
            if (sender is PictureBox)
            {
                PictureBox btn = sender as PictureBox;

                btn.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (sender is Button)
            {
                Button btn = sender as Button;
                btn.FlatStyle = FlatStyle.Standard;

            }
            else if (sender is Label)
            {
                Label btn = sender as Label;

                btn.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private static Point mouse_offset;


        public static void DropMove(Control ctr)
        {
            ctr.MouseDown += new MouseEventHandler(ctr_MouseDown);
            ctr.MouseUp += new MouseEventHandler(ctr_MouseUp);
            ctr.MouseMove += new MouseEventHandler(ctr_MouseMove);
        }

        static void ctr_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Arrow;//设置拖动时鼠标箭头
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);//设置偏移
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePos);
            }

        }

        static void ctr_MouseUp(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        static void ctr_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);//
            //throw new NotImplementedException();
        }
        public static void CenterHor(Control ctr)
        {
            if (ctr != null && ctr.Parent != null)
            {
                ctr.Location = new Point((ctr.Parent.Width - ctr.Width) / 2, ctr.Location.Y);
            }
        }

        public static void CenterVer(Control ctr)
        {
            if (ctr != null && ctr.Parent != null)
            {
                ctr.Location = new Point(ctr.Location.X, (ctr.Parent.Height - ctr.Height) / 2);
            }
        }

        public static void Center(Control ctr)
        {
            if (ctr != null && ctr.Parent != null)
            {
                ctr.Location = new Point((ctr.Parent.Width - ctr.Width) / 2, (ctr.Parent.Height - ctr.Height) / 2);
            }
        }

        //private static GraphicsPath shape=null;
        private static Color yellowBorderColor = Color.FromArgb(243, 152, 0);

        private static Color secondBorderColor = Color.FromArgb(125, 183, 0);
        private static int yellowBorderWidth = 4;

        private static Color grayBorderColor = Color.Gray;

        public static void PainGrayBorder(object sender, PaintEventArgs e)
        {
            PaintBorder(sender, grayBorderColor, yellowBorderWidth, e);
        }

        public static void PainSecondBorder(object sender, PaintEventArgs e)
        {
            PaintBorder(sender, secondBorderColor, yellowBorderWidth, e);
        }

        public static void PainYellowBorder(object sender, PaintEventArgs e)
        {
            PaintBorder(sender, yellowBorderColor, yellowBorderWidth, e);
        }

        public static void PaintBorder(object sender, Color borderColor, int borderWidth, PaintEventArgs e)
        {
            Control ctr = ((Control)sender);
            ///*
            ControlPaint.DrawBorder(e.Graphics,
                               ctr.ClientRectangle,
                               borderColor,//7f9db9
                               borderWidth,
                               ButtonBorderStyle.Solid,
                              borderColor,
                              borderWidth,
                              ButtonBorderStyle.Solid,
                              borderColor,
                              borderWidth,
                              ButtonBorderStyle.Solid,
                              borderColor,
                              borderWidth,
                              ButtonBorderStyle.Solid);
            // * */

            //  PaintPath(e.Graphics,ctr, borderColor, borderWidth);
        }

        private static void PaintPath(Graphics graphics, Control ctr, Color borderColor, int borderWidth)
        {
            Pen pen = new Pen(borderColor, borderWidth);
            pen.DashStyle = DashStyle.Solid;
            List<Point> list = new List<Point>();
            int width = ctr.Width;
            int height = ctr.Height;
            list.Add(new Point(0, 47));
            list.Add(new Point(1, 42));
            list.Add(new Point(2, 38));
            list.Add(new Point(3, 36));
            list.Add(new Point(4, 33));
            list.Add(new Point(5, 32));
            list.Add(new Point(6, 29));
            list.Add(new Point(7, 27));
            list.Add(new Point(8, 26));
            list.Add(new Point(9, 24));
            list.Add(new Point(10, 22));
            list.Add(new Point(11, 21));
            list.Add(new Point(12, 20));
            list.Add(new Point(13, 19));
            list.Add(new Point(14, 17));
            list.Add(new Point(15, 16));
            list.Add(new Point(16, 15));
            list.Add(new Point(17, 14));
            list.Add(new Point(19, 13));
            list.Add(new Point(20, 12));
            list.Add(new Point(21, 11));
            list.Add(new Point(22, 10));
            list.Add(new Point(24, 9));
            list.Add(new Point(26, 8));
            list.Add(new Point(27, 7));
            list.Add(new Point(29, 6));
            list.Add(new Point(32, 5));
            list.Add(new Point(33, 4));
            list.Add(new Point(36, 3));
            list.Add(new Point(38, 2));
            list.Add(new Point(42, 1));
            list.Add(new Point(47, 0));

            //右上  
            list.Add(new Point(width - 47, 0));
            list.Add(new Point(width - 42, 1));
            list.Add(new Point(width - 38, 2));
            list.Add(new Point(width - 36, 3));
            list.Add(new Point(width - 33, 4));
            list.Add(new Point(width - 32, 5));
            list.Add(new Point(width - 29, 6));
            list.Add(new Point(width - 27, 7));
            list.Add(new Point(width - 26, 8));
            list.Add(new Point(width - 24, 9));
            list.Add(new Point(width - 22, 10));
            list.Add(new Point(width - 21, 11));
            list.Add(new Point(width - 20, 12));
            list.Add(new Point(width - 19, 13));
            list.Add(new Point(width - 17, 14));
            list.Add(new Point(width - 16, 15));
            list.Add(new Point(width - 15, 16));
            list.Add(new Point(width - 14, 17));
            list.Add(new Point(width - 13, 19));
            list.Add(new Point(width - 12, 20));
            list.Add(new Point(width - 11, 21));
            list.Add(new Point(width - 10, 22));
            list.Add(new Point(width - 9, 24));
            list.Add(new Point(width - 8, 26));
            list.Add(new Point(width - 7, 27));
            list.Add(new Point(width - 6, 29));
            list.Add(new Point(width - 5, 32));
            list.Add(new Point(width - 4, 33));
            list.Add(new Point(width - 3, 36));
            list.Add(new Point(width - 2, 38));
            list.Add(new Point(width - 1, 42));
            list.Add(new Point(width - 0, 47));

            //右下  
            list.Add(new Point(width - 0, height - 47));
            list.Add(new Point(width - 1, height - 42));
            list.Add(new Point(width - 2, height - 38));
            list.Add(new Point(width - 3, height - 36));
            list.Add(new Point(width - 4, height - 33));
            list.Add(new Point(width - 5, height - 32));
            list.Add(new Point(width - 6, height - 29));
            list.Add(new Point(width - 7, height - 27));
            list.Add(new Point(width - 8, height - 26));
            list.Add(new Point(width - 9, height - 24));
            list.Add(new Point(width - 10, height - 22));
            list.Add(new Point(width - 11, height - 21));
            list.Add(new Point(width - 12, height - 20));
            list.Add(new Point(width - 13, height - 19));
            list.Add(new Point(width - 14, height - 17));
            list.Add(new Point(width - 15, height - 16));
            list.Add(new Point(width - 16, height - 15));
            list.Add(new Point(width - 17, height - 14));
            list.Add(new Point(width - 19, height - 13));
            list.Add(new Point(width - 20, height - 12));
            list.Add(new Point(width - 21, height - 11));
            list.Add(new Point(width - 22, height - 10));
            list.Add(new Point(width - 24, height - 9));
            list.Add(new Point(width - 26, height - 8));
            list.Add(new Point(width - 27, height - 7));
            list.Add(new Point(width - 29, height - 6));
            list.Add(new Point(width - 32, height - 5));
            list.Add(new Point(width - 33, height - 4));
            list.Add(new Point(width - 36, height - 3));
            list.Add(new Point(width - 38, height - 2));
            list.Add(new Point(width - 42, height - 1));
            list.Add(new Point(width - 47, height - 0));

            //左下  
            list.Add(new Point(47, height - 0));
            list.Add(new Point(42, height - 1));
            list.Add(new Point(38, height - 2));
            list.Add(new Point(36, height - 3));
            list.Add(new Point(33, height - 4));
            list.Add(new Point(32, height - 5));
            list.Add(new Point(29, height - 6));
            list.Add(new Point(27, height - 7));
            list.Add(new Point(26, height - 8));
            list.Add(new Point(24, height - 9));
            list.Add(new Point(22, height - 10));
            list.Add(new Point(21, height - 11));
            list.Add(new Point(20, height - 12));
            list.Add(new Point(19, height - 13));
            list.Add(new Point(17, height - 14));
            list.Add(new Point(16, height - 15));
            list.Add(new Point(15, height - 16));
            list.Add(new Point(14, height - 17));
            list.Add(new Point(13, height - 19));
            list.Add(new Point(12, height - 20));
            list.Add(new Point(11, height - 21));
            list.Add(new Point(10, height - 22));
            list.Add(new Point(9, height - 24));
            list.Add(new Point(8, height - 26));
            list.Add(new Point(7, height - 27));
            list.Add(new Point(6, height - 29));
            list.Add(new Point(5, height - 32));
            list.Add(new Point(4, height - 33));
            list.Add(new Point(3, height - 36));
            list.Add(new Point(2, height - 38));
            list.Add(new Point(1, height - 42));
            list.Add(new Point(0, height - 47));

            Point[] points = list.ToArray();
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);

            graphics.DrawPath(pen, path);
        }
        public static void PaintFirstRound(object sender)
        {
            PaintRound(sender, yellowBorderColor, yellowBorderWidth);
        }

        public static void PaintFirstRound(object sender, PaintEventArgs e)
        {
            PaintRound(sender, yellowBorderColor, yellowBorderWidth, e);
        }

        public static void PaintSecondRound(object sender)
        {
            PaintRound(sender, secondBorderColor, yellowBorderWidth);
        }


        public static void PaintSecondRound(object sender, PaintEventArgs e)
        {
            PaintRound(sender, secondBorderColor, yellowBorderWidth, e);
        }


        /*
          sharecodes.org 友情提醒：尊重知识，转载请注明原创作者、出处！
        */

        /// <summary>
        /// C# GDI+ 绘制圆角矩形
        /// </summary>
        /// <param name="g">Graphics 对象</param>
        /// <param name="rectangle">Rectangle 对象，圆角矩形区域</param>
        /// <param name="borderColor">边框颜色</param>
        /// <param name="borderWidth">边框宽度</param>
        /// <param name="r">圆角半径</param>
        public static void DrawRoundRectangle(Graphics g, Rectangle rectangle, Color borderColor, float borderWidth, int r)
        {
            // 如要使边缘平滑，请取消下行的注释
            // g.SmoothingMode = SmoothingMode.HighQuality;

            // 由于边框也需要一定宽度，需要对矩形进行修正
            rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
            Pen p = new Pen(borderColor, borderWidth);
            // 调用 getRoundRectangle 得到圆角矩形的路径，然后再进行绘制
            g.DrawPath(p, getRoundRectangle(rectangle, r));
        }

        /// <summary>
        /// 根据普通矩形得到圆角矩形的路径
        /// </summary>
        /// <param name="rectangle">原始矩形</param>
        /// <param name="r">半径</param>
        /// <returns>图形路径</returns>
        private static GraphicsPath getRoundRectangle(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);
            return gp;
        }
        public static void PaintRound(object sender, Color borderColor, int borderWidth)
        {
            Control form = ((Control)sender);
#if DEBUG
            Console.WriteLine("控件：" + form.Name + "画椭圆边框");
#endif

            //if (shape == null)
            // {
            List<Point> list = new List<Point>();
            int width = form.Width;
            int height = form.Height;
            int r = 17;
            DrawRoundRectangle(form.CreateGraphics(), form.ClientRectangle, borderColor, borderWidth, r);
            DrawRoundRectangle(form.CreateGraphics(), form.ClientRectangle, borderColor, borderWidth, r);
            DrawRoundRectangle(form.CreateGraphics(), form.ClientRectangle, borderColor, borderWidth, r);
            GraphicsPath shape = getRoundRectangle(form.ClientRectangle, r);
            //将控件的显示区域设为GraphicsPath的实例 
            form.Region = new System.Drawing.Region(shape);




        }

        public static void PaintRound(object sender, Color borderColor, int borderWidth, PaintEventArgs e)
        {
            Control form = ((Control)sender);
#if DEBUG
            Console.WriteLine("控件：" + form.Name + "画椭圆边框");
#endif

            //if (shape == null)
            // {
            List<Point> list = new List<Point>();
            int width = form.Width;
            int height = form.Height;
            #region 边框有锯齿的
            /*

               //左上
               list.Add(new Point(0, 5));
               list.Add(new Point(1, 5));
               list.Add(new Point(1, 3));
               list.Add(new Point(2, 3));
               list.Add(new Point(2, 2));
               list.Add(new Point(3, 2));
               list.Add(new Point(3, 1));
               list.Add(new Point(5, 1));
               list.Add(new Point(5, 0));
               //右上
               list.Add(new Point(width - 5, 0));
               list.Add(new Point(width - 5, 1));
               list.Add(new Point(width - 3, 1));
               list.Add(new Point(width - 3, 2));
               list.Add(new Point(width - 2, 2));
               list.Add(new Point(width - 2, 3));
               list.Add(new Point(width - 1, 3));
               list.Add(new Point(width - 1, 5));
               list.Add(new Point(width - 0, 5));
               //右下
               list.Add(new Point(width - 0, height - 5));
               list.Add(new Point(width - 1, height - 5));
               list.Add(new Point(width - 1, height - 3));
               list.Add(new Point(width - 2, height - 3));
               list.Add(new Point(width - 2, height - 2));
               list.Add(new Point(width - 3, height - 2));
               list.Add(new Point(width - 3, height - 1));
               list.Add(new Point(width - 5, height - 1));
               list.Add(new Point(width - 5, height - 0));
               //左下
               list.Add(new Point(5, height - 0));
               list.Add(new Point(5, height - 1));
               list.Add(new Point(3, height - 1));
               list.Add(new Point(3, height - 2));
               list.Add(new Point(2, height - 2));
               list.Add(new Point(2, height - 3));
               list.Add(new Point(1, height - 3));
               list.Add(new Point(1, height - 5));
               list.Add(new Point(0, height - 5));

              */
            #endregion

            #region 四个圆角
            /*
             //左上  
             list.Add(new Point(0, 47));
             list.Add(new Point(1, 42));
             list.Add(new Point(2, 38));
             list.Add(new Point(3, 36));
             list.Add(new Point(4, 33));
             list.Add(new Point(5, 32));
             list.Add(new Point(6, 29));
             list.Add(new Point(7, 27));
             list.Add(new Point(8, 26));
             list.Add(new Point(9, 24));
             list.Add(new Point(10, 22));
             list.Add(new Point(11, 21));
             list.Add(new Point(12, 20));
             list.Add(new Point(13, 19));
             list.Add(new Point(14, 17));
             list.Add(new Point(15, 16));
             list.Add(new Point(16, 15));
             list.Add(new Point(17, 14));
             list.Add(new Point(19, 13));
             list.Add(new Point(20, 12));
             list.Add(new Point(21, 11));
             list.Add(new Point(22, 10));
             list.Add(new Point(24, 9));
             list.Add(new Point(26, 8));
             list.Add(new Point(27, 7));
             list.Add(new Point(29, 6));
             list.Add(new Point(32, 5));
             list.Add(new Point(33, 4));
             list.Add(new Point(36, 3));
             list.Add(new Point(38, 2));
             list.Add(new Point(42, 1));
             list.Add(new Point(47, 0));
 
             //右上  
             list.Add(new Point(width - 47, 0));
             list.Add(new Point(width - 42, 1));
             list.Add(new Point(width - 38, 2));
             list.Add(new Point(width - 36, 3));
             list.Add(new Point(width - 33, 4));
             list.Add(new Point(width - 32, 5));
             list.Add(new Point(width - 29, 6));
             list.Add(new Point(width - 27, 7));
             list.Add(new Point(width - 26, 8));
             list.Add(new Point(width - 24, 9));
             list.Add(new Point(width - 22, 10));
             list.Add(new Point(width - 21, 11));
             list.Add(new Point(width - 20, 12));
             list.Add(new Point(width - 19, 13));
             list.Add(new Point(width - 17, 14));
             list.Add(new Point(width - 16, 15));
             list.Add(new Point(width - 15, 16));
             list.Add(new Point(width - 14, 17));
             list.Add(new Point(width - 13, 19));
             list.Add(new Point(width - 12, 20));
             list.Add(new Point(width - 11, 21));
             list.Add(new Point(width - 10, 22));
             list.Add(new Point(width - 9, 24));
             list.Add(new Point(width - 8, 26));
             list.Add(new Point(width - 7, 27));
             list.Add(new Point(width - 6, 29));
             list.Add(new Point(width - 5, 32));
             list.Add(new Point(width - 4, 33));
             list.Add(new Point(width - 3, 36));
             list.Add(new Point(width - 2, 38));
             list.Add(new Point(width - 1, 42));
             list.Add(new Point(width - 0, 47));
 
             //右下  
             list.Add(new Point(width - 0, height - 47));
             list.Add(new Point(width - 1, height - 42));
             list.Add(new Point(width - 2, height - 38));
            list.Add(new Point(width - 3, height - 36));
            list.Add(new Point(width - 4, height - 33));
            list.Add(new Point(width - 5, height - 32));
            list.Add(new Point(width - 6, height - 29));
            list.Add(new Point(width - 7, height - 27));
            list.Add(new Point(width - 8, height - 26));
            list.Add(new Point(width - 9, height - 24));
            list.Add(new Point(width - 10, height - 22));
            list.Add(new Point(width - 11, height - 21));
            list.Add(new Point(width - 12, height - 20));
            list.Add(new Point(width - 13, height - 19));
            list.Add(new Point(width - 14, height - 17));
            list.Add(new Point(width - 15, height - 16));
            list.Add(new Point(width - 16, height - 15));
            list.Add(new Point(width - 17, height - 14));
            list.Add(new Point(width - 19, height - 13));
            list.Add(new Point(width - 20, height - 12));
            list.Add(new Point(width - 21, height - 11));
            list.Add(new Point(width - 22, height - 10));
            list.Add(new Point(width - 24, height - 9));
            list.Add(new Point(width - 26, height - 8));
            list.Add(new Point(width - 27, height - 7));
            list.Add(new Point(width - 29, height - 6));
            list.Add(new Point(width - 32, height - 5));
            list.Add(new Point(width - 33, height - 4));
            list.Add(new Point(width - 36, height - 3));
            list.Add(new Point(width - 38, height - 2));
            list.Add(new Point(width - 42, height - 1));
            list.Add(new Point(width - 47, height - 0));

            //左下  
            list.Add(new Point(47, height - 0));
            list.Add(new Point(42, height - 1));
            list.Add(new Point(38, height - 2));
            list.Add(new Point(36, height - 3));
            list.Add(new Point(33, height - 4));
            list.Add(new Point(32, height - 5));
            list.Add(new Point(29, height - 6));
            list.Add(new Point(27, height - 7));
            list.Add(new Point(26, height - 8));
            list.Add(new Point(24, height - 9));
            list.Add(new Point(22, height - 10));
            list.Add(new Point(21, height - 11));
            list.Add(new Point(20, height - 12));
            list.Add(new Point(19, height - 13));
            list.Add(new Point(17, height - 14));
            list.Add(new Point(16, height - 15));
            list.Add(new Point(15, height - 16));
            list.Add(new Point(14, height - 17));
            list.Add(new Point(13, height - 19));
            list.Add(new Point(12, height - 20));
            list.Add(new Point(11, height - 21));
            list.Add(new Point(10, height - 22));
            list.Add(new Point(9, height - 24));
            list.Add(new Point(8, height - 26));
            list.Add(new Point(7, height - 27));
            list.Add(new Point(6, height - 29));
            list.Add(new Point(5, height - 32));
            list.Add(new Point(4, height - 33));
            list.Add(new Point(3, height - 36));
            list.Add(new Point(2, height - 38));
            list.Add(new Point(1, height - 42));
            list.Add(new Point(0, height - 47));
*/
            #endregion
            #region 临时
            /*
                Point[] points = list.ToArray();

                GraphicsPath shape = new GraphicsPath();
                shape.AddPolygon(points);
                Pen pen = new Pen(borderColor, borderWidth);
                pen.DashStyle = DashStyle.Solid;
                GraphicsPath path = new GraphicsPath();
                path.AddLines(points);

                e.Graphics.DrawPath(pen, path);

                ControlPaint.DrawBorder(e.Graphics,
                                  form.ClientRectangle,
                                  borderColor,//7f9db9
                                  borderWidth,
                                  ButtonBorderStyle.Solid,
                                 borderColor,
                                 borderWidth,
                                 ButtonBorderStyle.Solid,
                                 borderColor,
                                 borderWidth,
                                 ButtonBorderStyle.Solid,
                                 borderColor,
                                 borderWidth,
                                 ButtonBorderStyle.Solid);
 */
            // }
            #endregion
            int r = 17;
            DrawRoundRectangle(e.Graphics, form.ClientRectangle, borderColor, borderWidth, r);
            DrawRoundRectangle(e.Graphics, form.ClientRectangle, borderColor, borderWidth, r);
            DrawRoundRectangle(e.Graphics, form.ClientRectangle, borderColor, borderWidth, r);
            GraphicsPath shape = getRoundRectangle(form.ClientRectangle, r);
            //将控件的显示区域设为GraphicsPath的实例 
            form.Region = new System.Drawing.Region(shape);




        }


    }
}
