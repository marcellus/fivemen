using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HiPiaoInterface
{
    public class HiPiaoOperator:IHiPiaoOperator
    {
        #region IHiPiaoOperator 成员

        public bool CheckUserName(string name)
        {
            throw new NotImplementedException();
        }

        public bool CheckMobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public TicketPrintObject GetTicket(string mobile, string valid)
        {
            throw new NotImplementedException();
        }

        public UserObject Login(string memberId)
        {
            string xml = hiPiaoSrv.LoginUserMemberId(memberId);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode ret = doc.SelectSingleNode("//result");
            UserObject user = null;
            string returnCode = ret.InnerText;

            if (ret.InnerText == "1")
            {
                user = new UserObject();
                //user.Name = doc.SelectSingleNode("//nickname").InnerText;
                user.Name = memberId;
                user.Mobile = doc.SelectSingleNode("//phone").InnerText;
                user.MemberId = doc.SelectSingleNode("//memberId").InnerText;
                user.HipiaoCard = doc.SelectSingleNode("//hipiaocard").InnerText;
                user.SessionKey = doc.SelectSingleNode("//sessionkey").InnerText;
                user.RewardPoints = Convert.ToInt32(doc.SelectSingleNode("//score").InnerText);
                XmlNode blance = doc.SelectSingleNode("//blance");
                user.IsBindMobile = doc.SelectSingleNode("//isbanded").InnerText == "1";
                user.Balance = Convert.ToDouble(blance.InnerText);
                user.Email = doc.SelectSingleNode("//mail").InnerText;
                user.Pwd = string.Empty;
            }


            return user;
        }
        public UserObject Login(string name, string pwd)
        {
            string xml = hiPiaoSrv.LoginUser(name, pwd);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode ret = doc.SelectSingleNode("//result");
            UserObject user = null;
            string returnCode = ret.InnerText;

            if (ret.InnerText == "1")
            {
                user = new UserObject();
                user.Name = name;
               // user.Name = doc.SelectSingleNode("//nickname").InnerText;
                user.Mobile = doc.SelectSingleNode("//phone").InnerText;
                user.MemberId = doc.SelectSingleNode("//memberId").InnerText;
                user.HipiaoCard = doc.SelectSingleNode("//hipiaocard").InnerText;
                user.SessionKey = doc.SelectSingleNode("//sessionkey").InnerText;
                user.RewardPoints = Convert.ToInt32(doc.SelectSingleNode("//score").InnerText);
                XmlNode blance = doc.SelectSingleNode("//blance");
                user.IsBindMobile = doc.SelectSingleNode("//isbanded").InnerText == "1";
                user.Balance = Convert.ToDouble(blance.InnerText);
                user.Email = doc.SelectSingleNode("//mail").InnerText;
                user.Pwd = pwd;
            }


            return user;
        }

        public bool UpdatePwd(UserObject user, string newPwd)
        {
            string xml = hiPiaoSrv.UpdateUserPwd(user, newPwd);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode ret = doc.SelectSingleNode("//result");
            bool result= ret.InnerText == "1";
            if (result)
            {
                user.Pwd = newPwd;
            }
            return result;
        }

        public TicketObject BuyTicket(UserObject user, CinemaObject cinema, MovieObject movie, DateTime playTime)
        {
            throw new NotImplementedException();
        }

       

        public UserObject Register(string name, string pwd, string mobile, ref string returnCode)
        {

            string xml = hiPiaoSrv.RegisterUser(name, pwd, mobile);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode ret = doc.SelectSingleNode("//result");
            UserObject user=null;
            returnCode = ret.InnerText;
           
            if (ret.InnerText == "1")
            {
                user = new UserObject();
                user.Name = doc.SelectSingleNode("//nickname").InnerText;
                user.Mobile = doc.SelectSingleNode("//phone").InnerText;
                user.MemberId = doc.SelectSingleNode("//memberId").InnerText;
                user.MemberId = doc.SelectSingleNode("//hipiaocard").InnerText;
                user.SessionKey = doc.SelectSingleNode("//sessionkey").InnerText;
                user.RewardPoints = Convert.ToInt32(doc.SelectSingleNode("//score").InnerText);
                XmlNode blance=doc.SelectSingleNode("//blance");
                user.Balance = Convert.ToDouble(blance.InnerText);
                user.Pwd = pwd;
            }
            
            
            return user;
            //throw new NotImplementedException();
        }

        public ReturnObject PrintTicket(UserObject user, TicketObject ticket)
        {
            throw new NotImplementedException();
        }

        #endregion

        private CommonHiPiaoStringOperator hiPiaoSrv = new CommonHiPiaoStringOperator();

        #region IHiPiaoOperator 成员


        public void QueryUser(UserObject user)
        {
            int c=user.Deductions.Count;
            int t = user.Coupons.Count;

/*
            string xmlBuyRecord = hiPiaoSrv.QueryUserBuyRecord(user);
            XmlDocument docBuyRecord = new XmlDocument();
            docBuyRecord.LoadXml(xmlBuyRecord);
            XmlNodeList buyrecordNode = docDeduction.SelectNodes("//consum");

            BuyRecordObject buyRecord = null;
            TicketObject ticket = null;
            MovieObject movie=null;

            for (int i = 0; i < buyrecordNode.Count; i++)
            {
                buyRecord = new BuyRecordObject();
                string movieName = buyrecordNode[i].Attributes["cinemaname"].Value;
                int totalPrice = Convert.ToInt32(buyrecordNode[i].Attributes["crossmoney"].Value);
                //buyRecord.TotalPrice = buyrecordNode[i].Attributes["orderformid"].Value;

                buyRecord.BuyTime = Convert.ToDateTime(buyrecordNode[i].Attributes["costtime"].Value);
                int count = Convert.ToInt32(buyrecordNode[i].Attributes["ticketcount"].Value);
                for (int j = 0; j < count; j++)
                {
                    ticket = new TicketObject();
                    movie=new MovieObject();
                    movie.Name=movieName;
                    ticket.Movie = movie;
                    ticket.Price = totalPrice / count;
                    buyRecord.Tickets.Add(ticket);

                }
                user.BuyRecords.Add(buyRecord);
            }
*/
            
        }

        #endregion
    }
}
