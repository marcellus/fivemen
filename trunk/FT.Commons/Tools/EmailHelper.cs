using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.ComponentModel;

namespace FT.Commons.Tools
{
    public class EmailHelper:BaseHelper
    {

       
       

       

       

        #region 检测附件大小
        private static bool Attachment_MaiInit(string path)
        {
            if (path.Length==0||!File.Exists(path))
            {
                return true;
            }

            try
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                string name = stream.Name;
                int size = (int)(stream.Length / 1024 / 1024);
                stream.Close();
                //控制文件大小不大于10Ｍ
                if (size > 10)
                {

                    MessageBoxHelper.Show("文件长度不能大于10M！你选择的文件大小为" + size.ToString() + "M");
                    return false;
                }

                return true;
            }
            catch (IOException E)
            {
                MessageBoxHelper.Show(E.Message);
                return false;
            }

        }
        #endregion

        public static bool Send(string host,int port,string fromEmail,string fromName,string pwd,string path,string toUser,string title,string body)
        {
            //检测附件大小 发件必需小于10M 否则返回  不会执行以下代码
            if (path != "")
            {
                if (!Attachment_MaiInit(path))
                {
                    return false;
                }
            }
            if (host == "")
            {
                MessageBoxHelper.Show("请输入SMTP服务器名！");
                return false;
            }
            
           
            if (fromEmail == "")
            {
                MessageBoxHelper.Show("请输入发件人邮箱地址！");
                return false;
            }
            if (pwd == "")
            {
                MessageBoxHelper.Show("请输入发件人邮箱密码！");
                return false;
            }

            if (toUser.Length==0)
            {
                MessageBoxHelper.Show("无效收件人！"+toUser);
                return false;
            }
            SmtpClient smtpClient = null;   //设置SMTP协议
            MailAddress mailAddress_from = null; //设置发信人地址  当然还需要密码
            MailMessage mailMessage_Mai = null;
            try
                {
                    smtpClient = new SmtpClient();
                    smtpClient.Host = host;//指定SMTP服务名  例如QQ邮箱为 smtp.qq.com 新浪cn邮箱为 smtp.sina.cn等
                    smtpClient.Port = port; //指定端口号
                    smtpClient.Timeout = 0;  //超时时间
                }
                catch (Exception Ex)
                {
                    MessageBoxHelper.Show("邮件发送失败,请确定SMTP服务名是否正确！" + "\n" + "技术信息:\n" + Ex.Message);
                    return false;
                }
                try
                {
                    
                    mailAddress_from = new System.Net.Mail.MailAddress(fromEmail, fromName);
                    //指定发件人信息  包括邮箱地址和邮箱密码
                    smtpClient.Credentials = new System.Net.NetworkCredential(mailAddress_from.Address, pwd);
                }
                catch (Exception Ex)
                {
                    MessageBoxHelper.Show("邮件发送失败,请确定发件邮箱地址和密码的正确性！" + "\n" + "技术信息:\n" + Ex.Message);
                    return false;
                }
                //清空历史发送信息 以防发送时收件人收到的错误信息(收件人列表会不断重复)
                //mailMessage_Mai.To.Clear();
                mailMessage_Mai = new MailMessage();
                string[] toUsers = toUser.Split(';');
                //添加收件人邮箱地址
                foreach (string  str in toUsers)
                {

                    mailMessage_Mai.To.Add( new MailAddress(str));
                }
                //MessageBox.Show("收件人：" + dataGridViewX1.Rows.Count.ToString() + "  个");

                //发件人邮箱
                mailMessage_Mai.From = mailAddress_from;
                //邮件主题
                mailMessage_Mai.Subject = title;
                mailMessage_Mai.SubjectEncoding = System.Text.Encoding.UTF8;
                //邮件正文
                mailMessage_Mai.Body = body;
                mailMessage_Mai.BodyEncoding = System.Text.Encoding.UTF8;
                //清空历史附件  以防附件重复发送
                mailMessage_Mai.Attachments.Clear();
                //添加附件
                mailMessage_Mai.Attachments.Add(new Attachment(path, MediaTypeNames.Application.Octet));
                //注册邮件发送完毕后的处理事件
               // smtpClient.SendCompleted += callback;
                //开始发送邮件
                //smtpClient.SendAsync(mailMessage_Mai, "000000000");
                smtpClient.Send(mailMessage_Mai);
                return true;
        }

        #region 发送邮件后所处理的函数
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    MessageBoxHelper.Show("发送已取消！");
                }
                if (e.Error != null)
                {

                    MessageBoxHelper.Show("邮件发送失败！" + "\n" + "技术信息:\n" + e.ToString());

                }
                else
                {
                    MessageBoxHelper.Show("邮件成功发出!");
                }
            }
            catch (Exception Ex)
            {
                MessageBoxHelper.Show("邮件发送失败！" + "\n" + "技术信息:\n" + Ex.Message);
            }

        }
        #endregion
    }
}
