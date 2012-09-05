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
                user.Name = doc.SelectSingleNode("//nickname").InnerText;
                user.Mobile = doc.SelectSingleNode("//phone").InnerText;
                user.MemberId = doc.SelectSingleNode("//memberId").InnerText;
                user.MemberId = doc.SelectSingleNode("//hipiaocard").InnerText;
                user.SessionKey = doc.SelectSingleNode("//sessionkey").InnerText;
                user.RewardPoints = Convert.ToInt32(doc.SelectSingleNode("//score").InnerText);
                XmlNode blance = doc.SelectSingleNode("//blance");
                user.Balance = Convert.ToDouble(blance.InnerText);
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
            string xmlCoupon = hiPiaoSrv.QueryUserCoupon(user);
            XmlDocument docCoupon = new XmlDocument();
            docCoupon.LoadXml(xmlCoupon);
            XmlNodeList couponNode = docCoupon.SelectNodes("//CouponInfo");
            
            CouponObject coupon = null;

            for (int i = 0; i < couponNode.Count; i++)
            {
                coupon = new CouponObject();
                coupon.CardId = couponNode[i].Attributes["cardId"].Value;
                coupon.Period = couponNode[i].Attributes["period"].Value;
                coupon.UseDate = couponNode[i].Attributes["useDate"].Value;
                coupon.Status = Convert.ToInt32(couponNode[i].Attributes["status"].Value);
                coupon.Type = Convert.ToInt32(couponNode[i].Attributes["type"].Value);

                coupon.WeekEnd = couponNode[i].Attributes["weekEnd"].Value == "1";
                coupon.Enable3D = couponNode[i].Attributes["3D"].Value == "1";
                coupon.UseCinema = couponNode[i].Attributes["useCinema"].Value;

                coupon.FileRule = couponNode[i].Attributes["fileRule"].Value;
                coupon.EveryDayTime = couponNode[i].Attributes["everyDayTime"].Value;

                user.Coupons.Add(coupon);
            }


            string xmlDeduction = hiPiaoSrv.QueryUserDeduction(user);
            XmlDocument docDeduction = new XmlDocument();
            docDeduction.LoadXml(xmlDeduction);
            XmlNodeList deductionNode = docDeduction.SelectNodes("//DeductionInfo");

            DeductionObject deduction = null;

            for (int i = 0; i < deductionNode.Count; i++)
            {
                deduction = new DeductionObject();
                deduction.CardId = deductionNode[i].Attributes["cardId"].Value;
                deduction.Period = deductionNode[i].Attributes["period"].Value;
                deduction.UseDate = deductionNode[i].Attributes["useDate"].Value;
                deduction.Status = Convert.ToInt32(deductionNode[i].Attributes["status"].Value);
                deduction.Amount = Convert.ToDouble(deductionNode[i].Attributes["amount"].Value);

                deduction.UseRule = deductionNode[i].Attributes["useRule"].Value;
               

                user.Deductions.Add(deduction);
            }

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
