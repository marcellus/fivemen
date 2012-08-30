using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using NetDimension.Weibo;

namespace PrinterTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            this.imageProcessPanel1.ProcessImage = Image.FromFile("test.jpg");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.imageProcessPanel1.BeginPhoto();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string file = "email.jpg";
            Image img=this.imageProcessPanel1.GetFinalImage();
            img.Save(file);
            bool result=EmailHelper.Send("smtp.163.com", 25, "cbw123_1984@163.com", "模拟用户", "913048910504", file, this.txtEmails.Text.Trim(), "模拟发送邮件标题", "欢迎使用XXX拍照系统！！！");
            if(result) MessageBoxHelper.Show("发送邮件成功，请查收！");

        }

        private void btnBeginPhoto_Click(object sender, EventArgs e)
        {
            this.imageProcessPanel1.BeginPhoto();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            this.imageProcessPanel1.EndPhoto();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.imageProcessPanel1.EndPhoto();
        }

        private void imageProcessPanel1_Load(object sender, EventArgs e)
        {
           // this.imageProcessPanel1.BeginPhoto();
        }

        static string appKey = "3459327953";
        static string appSecrect = "002772588c332b84bd831b35767333cd";
        static string callbackUrl = "";

        private void btnSendToWeibo_Click(object sender, EventArgs e)
        {
            OAuth oauth = new OAuth(appKey, appSecrect, callbackUrl);
            string passport = this.txtName.Text.Trim();
            string password = this.txtPwd.Text.Trim();
           
          
            //string accessToken = string.Empty;
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
               
                Image img = this.imageProcessPanel1.GetFinalImage();
                

                //var statusInfo = Sina.API.Statuses.Update(string.Format("我是{0}，我来自{1}，我在{2}用《新浪微博开放平台API for .Net SDK》开发了一个小程序并发了这条微博，欢迎关注http://weibosdk.codeplex.com/", userInfo.ScreenName, userInfo.Location, DateTime.Now.ToShortTimeString()),0,0,"");
                var statusInfo = Sina.API.Statuses.Upload("测试内容"+System.DateTime.Now.ToLocalTime().ToString(), ImageHelper.GetBytesByImage(img), 0, 0, "");
                //加个当前时间防止重复提交报错。

                Console.WriteLine("微博已发送，发送时间：{0}", statusInfo.CreatedAt);
                MessageBoxHelper.Show("微博已发送");
            }
            catch (WeiboException ex)
            {
                Console.WriteLine("出错啦！" + ex.Message);
                MessageBoxHelper.Show("出错啦！" + ex.Message);
            }

            Console.WriteLine("演示结束，按任意键继续...");
        }
    }
}
