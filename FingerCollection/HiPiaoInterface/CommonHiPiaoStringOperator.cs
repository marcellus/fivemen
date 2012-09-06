using System;
using System.Collections.Generic;
using System.Text;
using HiPiaoInterface.com._51cp.iphone;
using System.Net;
using System.IO;

namespace HiPiaoInterface
{
    public class CommonHiPiaoStringOperator
    {
        private static string  Common_Soap_Header=string.Empty;
        private static string Common_Soap_Footer = string.Empty;

        private static string Interface_Url = string.Empty;
        public static string GetInterfaceUrl()
        {
            if (Interface_Url.Length == 0)
            {
                Interface_Url = "http://iphone.51cp.com:8080/ws/hpcinema";
            }
            return Interface_Url;
        }
        public static string BuildSoapHeader()
        {
            if (Common_Soap_Header.Length == 0)
            {
                StringBuilder header = new StringBuilder();
                header.Append("<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP-ENV:Header>");
                header.Append("<xs:RequestSOAPHeader xmlns:xs=\"http://www\"><xs:spId xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">hipiao</xs:spId>");
                header.Append("<xs:spPassword xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">hipiao@iphone</xs:spPassword>");
                header.Append("<xs:mobilekey xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">13800000000</xs:mobilekey>");
                header.Append("</xs:RequestSOAPHeader></SOAP-ENV:Header><SOAP-ENV:Body>");
                Common_Soap_Header = header.ToString();
            }
            return Common_Soap_Header;
        }

        public static string BuildSoapHeader(string sessionKey)
        {
            
                StringBuilder header = new StringBuilder();
                header.Append("<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP-ENV:Header>");
                header.Append("<xs:RequestSOAPHeader xmlns:xs=\"http://www\"><xs:spId xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">hipiao</xs:spId>");
                header.Append("<xs:spPassword xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">hipiao@iphone</xs:spPassword>");
                header.Append("<xs:sessionkey xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">" + sessionKey + "</xs:sessionkey>");
                header.Append("<xs:mobilekey xmlns:xs=\"http://www.chinatelecom.com.cn/schema/ctcc/common/v2_1\">13800000000</xs:mobilekey>");
                
                header.Append("</xs:RequestSOAPHeader></SOAP-ENV:Header><SOAP-ENV:Body>");
               return header.ToString();
            
        }

        public static string GetSoapServiceResult(StringBuilder body,string sessionKey)
        {
            StringBuilder soap = new StringBuilder();
            soap.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            soap.Append(BuildSoapHeader(sessionKey));
            soap.Append(body);
            soap.Append(BuildSoapFooter());
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "发送的xml请求内容为：" + soap.ToString());
            
#endif
            string result = GetSOAPReSource(GetInterfaceUrl(), soap.ToString());
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "xml请求结果内容为：" + result);
#endif
            return result;
        }

        public static string GetSoapServiceResult(StringBuilder body)
        {
            StringBuilder soap = new StringBuilder();
            soap.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            soap.Append(BuildSoapHeader());
            soap.Append(body);
            soap.Append(BuildSoapFooter());
#if DEBUG
            Console.WriteLine("发送的xml请求内容为："+soap.ToString());
#endif
            string result = GetSOAPReSource(GetInterfaceUrl(), soap.ToString());
#if DEBUG
            Console.WriteLine("xml请求结果内容为："+result);
#endif
            return result;
        }

        public static string BuildSoapFooter()
        {
            if (Common_Soap_Footer.Length == 0)
            {
                StringBuilder footer = new StringBuilder();
                footer.Append("</SOAP-ENV:Body></SOAP-ENV:Envelope>"); ;
                Common_Soap_Footer = footer.ToString();
            }
            return Common_Soap_Footer;
        }

        /// <summary>
        /// 获取 即将上映列表
        /// </summary>
        /// <returns>即将上映列表</returns>
        public  string   GetTopicWillRequest()
        {

            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getTopicWillRequest xmlns:ns2=\"http://service.server.com\">");
            body.Append("<clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getTopicWillRequest>");
           
            return GetSoapServiceResult(body);
        }


        /// <summary>
        /// 获取 即将上映列表
        /// </summary>
        /// <returns>即将上映列表</returns>
        public string GetSiteMap(string planid)
        {

            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getSiteMap  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<planid>"+planid+"</planid><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getSiteMap >");

            return GetSoapServiceResult(body);
        }


       
        public string GetMoviePlanVii(string province, string city, string pixnumber, DateTime date)
        {
              StringBuilder body = new StringBuilder();

            body.Append("<ns2:getPlanVii  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<province>"+province+"</province><city>"+city+"</city><pixnumber>"+pixnumber+"</pixnumber><date>"+date.ToString("MM月dd日")+"</date><version>2</version><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getPlanVii>");         
           return GetSoapServiceResult(body);

        }

        public string GetLastPixnumber(string province, string city)
        {
            return GetSoapServiceResult(GetProvinceBody("getLastPixnumber", province, city));
        }

        /// <summary>
        /// 给出所有省市对应的列表信息
        /// </summary>
        /// <returns></returns>
        public string  GetCityOfprovince()
        {

          //  StringBuilder body = new StringBuilder();

          //  body.Append("<ns2:getCityOfprovince  xmlns:ns2=\"http://service.server.com\">");
          //  body.Append("<province>广东省</province><city>广州市</city><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getCityOfprovince>");         
        //    return GetSoapServiceResult(body);
            return GetSoapServiceResult(GetProvinceBody("getCityOfprovince", "广东省", "广州市"));

        }
        public string QueryUserBuyRecord(UserObject user)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getConsumptionRequest xmlns:ns2=\"http://service.server.com\">");
            body.Append("<memberid>" + user.MemberId + "</memberid><clintform>ANDROID</clintform></ns2:getConsumptionRequest>");
            return GetSoapServiceResult(body,user.SessionKey);
        }

        public string QueryUserBuyRecordDetail(UserObject user,string orderid)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getConsumptionDatialRequest xmlns:ns2=\"http://service.server.com\">");
            body.Append("<memberid>" + user.MemberId + "</memberid><orderformid>"+orderid+"</orderformid><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getConsumptionDatialRequest>");
            return GetSoapServiceResult(body, user.SessionKey);
        }

        public string LoginUser(string name, string pwd)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getUserLoginResult  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<username>" + name + "</username><password>" + pwd + "</password><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getUserLoginResult>");
            return GetSoapServiceResult(body);
        }


        public string UpdateUserPwd(UserObject user, string newPwd)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:updateUserInfo  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<memberid>" + user.MemberId + "</memberid><oldpass>" + user.Pwd + "</oldpass><newpass>" + newPwd + "</newpass><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:updateUserInfo>");
            return GetSoapServiceResult(body);
        }

        public string QueryUserCoupon(UserObject user)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getCouponInfo xmlns:ns2=\"http://service.server.com\">");
            body.Append("<memberid>" + user.MemberId + "</memberid><clintform>ANDROID</clintform></ns2:getCouponInfo>");
            return GetSoapServiceResult(body,user.SessionKey);
        }

        public string QueryUserDeduction(UserObject user)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getDeductionInfo xmlns:ns2=\"http://service.server.com\">");
            body.Append("<memberid>" + user.MemberId + "</memberid><clintform>ANDROID</clintform></ns2:getDeductionInfo>");
            return GetSoapServiceResult(body, user.SessionKey);
        }

        public string RegisterUser(string name,string pwd,string phone)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getRegisterRequest  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<username>"+name+"</username><password>"+pwd+"</password><telphone>"+phone+"</telphone><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getRegisterRequest>");
            return GetSoapServiceResult(body);
        }
        private static StringBuilder GetProvinceBody(string msgType, string province, string city)
        {
             StringBuilder result = new StringBuilder();
            result.Append("<ns2:"+msgType+" xmlns:ns2=\"http://service.server.com\">");
            result.Append("<province>" + province + "</province><city>" + city + "</city><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:"+msgType+">");
            return result;
        }

        public string GetHotMovie(string province, string city)
        {
           return GetSoapServiceResult(GetProvinceBody("getHotMovieinfo",province,city));
          
        }


        public string GetDayMovie(string cinema,DateTime day)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getPlancinemaVii xmlns:ns2=\"http://service.server.com\">");
            body.Append("<cinemanumber>" + cinema + "</cinemanumber><date>" + day.ToString("MM月dd日") + "</date><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getPlancinemaVii>");
            return GetSoapServiceResult(body);
        }

        public string GetAdvertisement()
        {
             StringBuilder body = new StringBuilder();

            body.Append("<ns2:getAdvertisement  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<clintform>ANDROID</clintform></ns2:getAdvertisement>");
            return GetSoapServiceResult(body);
        }

        public string GetCinemaMoviePlan(string cinemaId, DateTime dt)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<ns2:getPlancinema  xmlns:ns2=\"http://service.server.com\">");
            body.Append("<cinemanumber>" + cinemaId + "</cinemanumber><date>" + dt.ToString("MM月dd日") + "</date><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getPlancinema>");
            return GetSoapServiceResult(body);
        }


        public  string  GetCityCinema(string province,string city)
        {

           // StringBuilder body = new StringBuilder();

            //body.Append("<ns2:getCityCinema xmlns:ns2=\"http://service.server.com\">");
            //body.Append("<province>" + province + "</province><city>" + city + "</city><clintform>ANDROID/IPHONE/IPAD</clintform></ns2:getCityCinema>");
           // return GetSoapServiceResult(body);

            return GetSoapServiceResult(GetProvinceBody("getCityCinema", province, city));
        }
        public static string GetSOAPReSource(string url, string datastr)
 
        {
 
           //发起请求
 
　　　　    Uri uri = new Uri(url);
 
　　　　    WebRequest webRequest = WebRequest.Create(uri);
 
            webRequest.ContentType ="text/xml; charset=utf-8";
 
            webRequest.Method ="POST";
 
            using (Stream requestStream = webRequest.GetRequestStream())
 
            {
 
               byte[] paramBytes = Encoding.UTF8.GetBytes(datastr.ToString());
 
               requestStream.Write(paramBytes, 0, paramBytes.Length);
 
            }
 
           //响应
 
           WebResponse webResponse = webRequest.GetResponse();
 
           using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
 
            {
 
               string result = "";
 
               return result = myStreamReader.ReadToEnd();
              
 
            }
 
        }


        public TicketPrintObject GetTicket(string mobile, string valid)
        {
            TicketPrintObject ticket = null;
            
            return ticket;
        }
        public bool UpdatePwd(UserObject user, string newPwd)
        {
            return true;
        }
        public HipiaoService CreateWebService()
        {
            com._51cp.iphone.HipiaoService service = new com._51cp.iphone.HipiaoService();
            return service;
            //service.Url = "";
           // CommonInterface.provinceCity city = new provinceCity();
            //city.
          
        }

        public void GetCity2()
        {
           // GetCityCinema();
            
        }

        public void GetCity()
        {
            HipiaoService service = this.CreateWebService();
            provinceCity[] citys=service.getCityOfprovince("广东省", "广州市");
            for (int i = 0; i < citys.Length; i++)
            {

                Console.WriteLine("city-"+i+"-"+citys[i].name);
            }
        }
        
    }
}
