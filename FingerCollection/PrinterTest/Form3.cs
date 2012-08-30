using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetDimension.Weibo;
using FT.Commons.Tools;
using System.Drawing.Text;

namespace PrinterTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // return o.ClientLogin(passport, password);
        }

        //static string passport = "myweibo3333@163.com";
        // static string password = "qwe123";
        static string passport = "cbw123_1984@163.com";
        static string password = "helloneal";
        static string appKey = "3459327953";
        static string appSecrect = "002772588c332b84bd831b35767333cd";
        static string callbackUrl = "";

        private static bool ClientLogin(OAuth o)
        {

            return o.ClientLogin(passport, password);
        }

        static OAuth Authorize()
        {
            OAuth o = new OAuth(appKey, appSecrect, callbackUrl);
            //让使用者自行选择一个授权方式
            /*
             * Console.WriteLine("请选择授权模式");
                    Console.WriteLine("1. 标准授权方式");
                    Console.WriteLine("2. 模拟授权方式");//一键授权登录
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    Console.WriteLine();
                    if (key.Key == ConsoleKey.D2)
                    {
              * */
            while (!ClientLogin(o))	//使用模拟方法
            {
                Console.WriteLine("授权登录失败，请重试。");
            }

            /*	}
                else
                {
   
                    string authorizeUrl = o.GetAuthorizeURL(ResponseType.Token,"",DisplayType.JS);
                    System.Diagnostics.Process.Start(authorizeUrl);
                    Console.WriteLine("复制浏览器中的Code:"+authorizeUrl);
                    string code = Console.ReadLine();
                    try
                    {
                        AccessToken accessToken = o.GetAccessTokenByAuthorizationCode(code); //请注意这里返回的是AccessToken对象，不是string
                    }
                    catch (WeiboException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                //}*/

            return o;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OAuth oauth = new OAuth(appKey, appSecrect, callbackUrl);
            bool result = oauth.ClientLogin(passport, password);
            if (!result)
            {
                MessageBoxHelper.Show("微博登陆失败！");
                return;
            }


            //好吧，授权至此应该成功了。下一步调用接口吧。
            Client Sina = new Client(oauth);

            try
            {

                //.Net其他版本
                string uid = Sina.API.Account.GetUID();	//获取UID
                //这里用VS2010的var关键字和可选参数最惬意了。
                //如果用VS2005什么的你得这样写：
                //NetDimension.Weibo.Entities.user.Entity userInfo = Sina.API.Users.Show(uid,null);
                //如果用VS2008什么的也不方便，你得把参数写全：
                //var userInfo = Sina.API.Users.Show(uid,null);
                var userInfo = Sina.API.Users.Show(uid, null);
                Console.WriteLine("昵称：{0}", userInfo.ScreenName);
                Console.WriteLine("来自：{0}", userInfo.Location);

                //发条微博啥的
                Image img = Image.FromFile("test.jpg");

                //var statusInfo = Sina.API.Statuses.Update(string.Format("我是{0}，我来自{1}，我在{2}用《新浪微博开放平台API for .Net SDK》开发了一个小程序并发了这条微博，欢迎关注http://weibosdk.codeplex.com/", userInfo.ScreenName, userInfo.Location, DateTime.Now.ToShortTimeString()),0,0,"");
                var statusInfo = Sina.API.Statuses.Upload("测试内容", ImageHelper.GetBytesByImage(img), 0, 0, "");
                //加个当前时间防止重复提交报错。

                Console.WriteLine("微博已发送，发送时间：{0}", statusInfo.CreatedAt);
            }
            catch (WeiboException ex)
            {
                Console.WriteLine("出错啦！" + ex.Message);
            }

            Console.WriteLine("演示结束，按任意键继续...");

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.TransLabel(this.label1, 30,Color.WhiteSmoke);
           // this.label1.Text = string.Empty;
        }

        private void TransLabel(Control ctr, int fontSize, Color color)
        {
            Bitmap img = new Bitmap(ctr.Width, ctr.Height);
            Graphics g = Graphics.FromImage(img);
           /* Font font = new Font("方正兰亭黑简体", fontSize, FontStyle.Regular);
            
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawString(ctr.Text, font, Brushes.Tomato, new RectangleF(0, 0, img.Width, img.Height));
            g.Dispose();
            ctr.BackgroundImage = img;
            img.Save("bgfont.jpg");
            ctr.BackgroundImageLayout = ImageLayout.Stretch;
            ctr.Text = string.Empty;
            * */

            FontFamily fontFamily = new FontFamily("方正兰亭黑简体");
            Font font = new Font(
               fontFamily,
               32,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
          
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawString(ctr.Text, font, solidBrush, new RectangleF(0, 0, img.Width, img.Height));
            g.Dispose();
            img.Save("bgfont2.jpg");

            
           // g.DrawString(string2, font, solidBrush, new PointF(10, 60));
            //g.SetSmoothingMode(SmoothingModeAntiAlias);
        }

        private void TransLabel(Control ctr,int size)
        {
            Graphics formGraphics =ctr.CreateGraphics();
            // Retrieve the graphics object. Graphics formGraphics = e.Graphics;
            // Declare a new font. 
            Font myFont = new Font("方正兰亭黑简体", size, FontStyle.Regular);
            // Set the TextRenderingHint property. 
            formGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            // Draw the string. 
            formGraphics.DrawString(ctr.Text, myFont, Brushes.Firebrick, 20.0F, 20.0F);
           // formGraphics.DrawString("",myFont,Brushes.FloralWhite,
            // Change the TextRenderingHint property. 
            formGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // Draw the string again. 
            formGraphics.DrawString(ctr.Text, myFont, Brushes.Firebrick, 20.0F, 60.0F);
            // Set the text contrast to a high-contrast setting. 
            formGraphics.TextContrast = 0;
            // Draw the string. 
            formGraphics.DrawString(ctr.Text, myFont, Brushes.DodgerBlue, 20.0F, 100.0F);
            // Set the text contrast to a low-contrast setting.
            formGraphics.TextContrast = 12;
            // Draw the string again. 
            formGraphics.DrawString(ctr.Text, myFont, Brushes.DodgerBlue, 20.0F, 140.0F);
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
          //  FontFamily fontFamily = new FontFamily("方正兰亭黑简体");
           // Font font = new Font(
           //    fontFamily,
           //    32,
            //   FontStyle.Regular,
            //   GraphicsUnit.Pixel);
           // SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
           // string string1 = "人噶发送发达放大";
           // string string2 = "发的萨芬";

           // e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
          //  e.Graphics.DrawString(string1, font, solidBrush, new PointF(10, 10));

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
           // e.Graphics.DrawString(string2, font, solidBrush, new PointF(10, 60));

        }
    }
}
