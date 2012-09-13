using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using FT.Commons.Tools;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace HiPiaoInterface
{
    public class HiPiaoCache
    {
        private HiPiaoCache()
        {
        }



        


        

        private static List<MoviePlanObject> GetCinemasMoviePlan(string cinemaId, DateTime dt)
        {
            List<MoviePlanObject> lists = new List<MoviePlanObject>();
            hiPiaoSrv.GetCinemaMoviePlan(cinemaId, dt);
            return lists;
        }
        private static List<ProvinceObject> provincesList = new List<ProvinceObject>();

        private static List<CinemaObject> cinemasList = new List<CinemaObject>();

        private static CommonHiPiaoStringOperator hiPiaoSrv =new  CommonHiPiaoStringOperator();

        public static string UserBuyTicket(UserObject user, List<TicketPrintObject> tickets)
        {
            string xml = hiPiaoSrv.UserBuyTicket(user, tickets);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode node = doc.SelectSingleNode("//order");
            if (node != null)
            {
                return node.Attributes["res"].Value.ToString();
            }
            else return "-1";
        }

        public static List<CinemaObject> GetCinemas(string province, string city)
        {
            string path = CinemasCacheDir + "\\" + province + "-" + city + "-cinemas.txt";
            if (File.Exists(path))
                cinemasList = SerializeHelper.DeserializeFromFile(path) as List<CinemaObject>;
            else
            {
                RefreshCinemas(province,city);
            }
            if (cinemasList.Count == 0)
            {
                RefreshCinemas(province, city);
            }
           

            
            return cinemasList;
        }

       

        public static List<CinemaObject> RefreshCinemas(string province, string city)
        {
            List<CinemaObject> lists = new List<CinemaObject>();
            string xml = hiPiaoSrv.GetCityCinema(province, city);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            CinemaObject cinema = null;
            XmlNodeList cinemasNode = doc.SelectNodes("//cinema");
            for (int i = 0; i < cinemasNode.Count; i++)
            {
                cinema = new CinemaObject();
                cinema.Address = cinemasNode[i].Attributes["address"].Value;
                cinema.Cinemanumber = cinemasNode[i].Attributes["cinemanumber"].Value;
                cinema.Tel = cinemasNode[i].Attributes["tel"].Value;
                cinema.Name = cinemasNode[i].Attributes["name"].Value;
                lists.Add(cinema);
            }
            cinemasList = lists;
            string path = CinemasCacheDir + "\\" + province + "-" + city + "-cinemas.txt";
            SerializeHelper.SerializeToFile(lists, path);
            return lists;
        }

        public void GetTopicWillRequest()
        {
        }

        public static string  DownLoad(string url, string dir,string file)
        {
            try
            {
                FileHelper.CheckDirExistsAndCreate(dir);
                WebClient client = new WebClient();
                string filename=string.Empty;
                if (file.Length == 0)
                {
                    filename = url.Substring(url.LastIndexOf('/') + 1);
                }
                else
                {
                    filename = file;
                }
                string fullname = System.IO.Path.Combine(Path.Combine(Application.StartupPath, dir), filename);
                if (!File.Exists(fullname))
                {
                    client.DownloadFile(url, fullname);
                }
                return fullname;
            }
            catch(Exception ex)
            {

                Console.WriteLine("下载"+url+"到"+dir+"文件名"+file+"失败");
                Console.WriteLine(ex);

                return string.Empty;
            }
        }

        private static SeatObject ParseSeatObject(XmlNode node)
        {
            SeatObject obj=new SeatObject();
            obj.RowNum = Convert.ToInt32(node.Attributes["linenum"].Value);
            obj.SeatNo = Convert.ToInt32(node.Attributes["colnum"].Value);
            obj.LockState = node.Attributes["lockstate"].Value;
            obj.SeatId = node.Attributes["seatid"].Value;
            obj.XPoint = Convert.ToInt32(node.Attributes["xpoint"].Value);
            obj.YPoint = Convert.ToInt32(node.Attributes["ypoint"].Value);
            return obj;
        }

        public static List<SeatObject> GetSeatList(string planId)
        {
            List<SeatObject> lists = new List<SeatObject>();
            string xml = hiPiaoSrv.GetSiteMap(planId);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList objsNode = doc.SelectNodes("//siteinfo");
            for (int i = 0; i < objsNode.Count; i++)
            {
                lists.Add(ParseSeatObject(objsNode[i]));
            }
            return lists;
        }

        //private static string LastMoviePath = "hotmovies";

        public static MoviePlanObject GetMoviePlanVii(string province, string city, string pixnumber, string cinemaId, DateTime date)
        {
            List<RoomPlanObject> lists = new List<RoomPlanObject>();
            MoviePlanObject moviePlan = new MoviePlanObject();
            
            string xml = hiPiaoSrv.GetMoviePlanVii(province, city,pixnumber,date);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
           
            XmlNode node = doc.SelectSingleNode("//cinema[@cinemanumber='"+cinemaId+"']");
            if (node == null)
            {
                return null;
            }
            XmlNode node2 = node.SelectSingleNode("savetype");
            string language = node2.Attributes["language"].Value;
            string type = node2.Attributes["type"].Value;
            moviePlan.Language = language;
            moviePlan.Type = type;
            XmlNodeList objsNode = node2.SelectNodes("plan");
           // XmlNodeList objsNode = node2.ChildNodes;
            for (int i = 0; i < objsNode.Count; i++)
            {
                lists.Add(ParseRoomPlan(objsNode[i]));
            }
            moviePlan.RoomPlans = lists;
            return moviePlan;

        }

        private static RoomPlanObject ParseRoomPlan(XmlNode node)
        {
            RoomPlanObject obj = new RoomPlanObject();
            obj.Color = node.Attributes["color"].Value;
            obj.PlanId = node.Attributes["planId"].Value;
            obj.Playtime = node.Attributes["playtime"].Value;
            obj.Price = Convert.ToDouble(node.Attributes["price"].Value.TrimEnd('元'));
            obj.SPrice = Convert.ToDouble(node.Attributes["sprice"].Value.TrimEnd('元'));
            obj.RoomId = node.Attributes["hallId"].Value;
            obj.RoomName = node.Attributes["hname"].Value;
            return obj;
        }

        public static string[] GetLastMovies(string province, string city)
        {
            string[] lists = null;
            string xml = hiPiaoSrv.GetLastPixnumber(province, city);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode node = doc.SelectSingleNode("//pixnumber");
            lists = node.Value.Split(',');
            return lists;

        }


        private static string HotMoviePath = "hotmovies";

        private static string HotMovieCacheFile = "Caches\\hotmovie.txt";
        private static string ProvincesCacheFile = "Caches\\provinces.txt";
        private static string CinemasCacheDir = "Caches\\Cinemas";

        public static void CheckAllDir()
        {
            FileHelper.CheckDirExistsAndCreate("Caches");
            FileHelper.CheckDirExistsAndCreate("Caches\\Cinemas");
        }
        public static void DeSerializedCache()
        {
            CheckAllDir();
            
            if (File.Exists(ProvincesCacheFile))
                provincesList = SerializeHelper.DeserializeFromFile(ProvincesCacheFile) as List<ProvinceObject>;
            if (File.Exists(HotMovieCacheFile))
            {
                hotMovie = SerializeHelper.DeserializeFromFile(HotMovieCacheFile) as List<MovieObject>;
                for (int i = 0; i < hotMovie.Count; i++)
                {
                    if (hotMovie[i].AdImagePath.Length > 0)
                    {
                        hotMovie[i].AdImage = Image.FromFile(hotMovie[i].AdImagePath);
                    }
                }
            }
            //hotMovie = FT.Commons.Cache.StaticCacheManager.GetFromConfig( "hotmovie") as List<MovieObject>;
            advertisementLists = FT.Commons.Cache.StaticCacheManager.GetFromCaches("advertisement") as List<AdvertisementObject>;
            if (advertisementLists != null)
            {
                for (int i = 0; i < advertisementLists.Count; i++)
                {
                    if (advertisementLists[i].AdImagePath.Length > 0)
                    {
                        advertisementLists[i].AdvPic = Image.FromFile(advertisementLists[i].AdImagePath);
                    }
                }
            }
           
        }

        public static void SerializedCache()
        {
            CheckAllDir();
            SerializeHelper.SerializeToFile(hotMovie, HotMovieCacheFile+"");
            SerializeHelper.SerializeToFile(provincesList,ProvincesCacheFile );
            FT.Commons.Cache.StaticCacheManager.SaveToCaches(advertisementLists, "advertisement");
            //SerializeHelper.SerializeToFile(cinemasList,CinemasCacheDir);
        }

        private static List<MovieObject> hotMovie = new List<MovieObject>();

        public static List<MovieObject> GetHotMovie(string province, string city)
        {
            if (hotMovie.Count == 0)
            {
                RefreshHotMovie(province,city);
            }
            return hotMovie;
        }
        public static int GetUserDeductionCount(UserObject user)
        {
#if DEBUG
            Console.WriteLine("开始执行获取用户折扣券数量时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            string xml = hiPiaoSrv.QueryUserDeduction(user);
#if DEBUG
            Console.WriteLine("结束执行获取用户折扣券数量时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
#if DEBUG
            Console.WriteLine("加载返回结果到XmlDocument文档中！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlNodeList deductionNodes = doc.SelectNodes("//dif");
            return deductionNodes.Count;
        }
        public static List<DeductionObject> GetUserDeduction(UserObject user)
        {
            List<DeductionObject> lists = new List<DeductionObject>();
#if DEBUG
            Console.WriteLine("开始执行获取用户折扣券时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            string xml = hiPiaoSrv.QueryUserDeduction(user);
#if DEBUG
            Console.WriteLine("结束执行获取用户折扣券时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
#if DEBUG
            Console.WriteLine("加载返回结果到XmlDocument文档中！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlNodeList deductionNodes = doc.SelectNodes("//dif");
            DeductionObject deduction;
            for (int i = 0; i < deductionNodes.Count; i++)
            {
#if DEBUG
                Console.WriteLine("初始化折扣券对象时间1！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif 
                deduction = new DeductionObject();
                /*
                deduction.Amount = Double.Parse(deductionNodes[i].Attributes["amount"].Value);
                deduction.CardId = deductionNodes[i].Attributes["cardId"].Value;
                deduction.Period = deductionNodes[i].Attributes["period"].Value;
                deduction.UseDate =deductionNodes[i].Attributes["useDate"]!=null? deductionNodes[i].Attributes["useDate"].Value:string.Empty;
                deduction.UseRule = deductionNodes[i].Attributes["useRule"].Value;
                deduction.Status = deductionNodes[i].Attributes["status"].Value;
#if DEBUG
                Console.WriteLine("初始化折扣券对象时间2！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif      
                 * */
                lists.Add(deduction);
            }
            return lists;
        }
        public static int GetUserCouponsCount(UserObject user)
        {
#if DEBUG
            Console.WriteLine("开始执行获取用户抵购券数量时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            string xml = hiPiaoSrv.QueryUserCoupon(user);
#if DEBUG
            Console.WriteLine("结束执行获取用户抵购券数量时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
#if DEBUG
            Console.WriteLine("加载返回结果到XmlDocument文档中！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlNodeList couponNodes = doc.SelectNodes("//couponInfo");
            return couponNodes.Count;
        }
        public static List<CouponObject> GetUserCoupons(UserObject user)
        {
            List<CouponObject> lists = new List<CouponObject>();
#if DEBUG
            Console.WriteLine("开始执行获取用户抵购券时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif        
            string xml = hiPiaoSrv.QueryUserCoupon(user);
#if DEBUG
            Console.WriteLine("结束执行获取用户抵购券时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
#if DEBUG
            Console.WriteLine("加载返回结果到XmlDocument文档中！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlNodeList couponNodes = doc.SelectNodes("//couponInfo");
            XmlNode useRuleNode;
            CouponObject coupon;
            for (int i = 0; i < couponNodes.Count; i++)
            {
#if DEBUG
                Console.WriteLine("初始化抵购券对象时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif 
                coupon = new CouponObject();
                /*
                coupon.CardId = couponNodes[i].Attributes["cardId"].Value;
#if DEBUG
                Console.WriteLine("抵扣券ID："+coupon.CardId);
#endif
                coupon.Period = couponNodes[i].Attributes["period"].Value;
                coupon.UseDate = couponNodes[i].Attributes["useDate"].Value;
                coupon.Status = Convert.ToInt32(couponNodes[i].Attributes["status"].Value);
#if DEBUG
                Console.WriteLine("初始化抵购券对象时间2！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif 
                useRuleNode=couponNodes[i].SelectSingleNode("useRule");
                if(useRuleNode!=null)
                {
                    coupon.UseCinema = useRuleNode.Attributes["useDate"]==null?string.Empty:useRuleNode.Attributes["useDate"].Value;
                    coupon.Enable3D = useRuleNode.Attributes["is3D"].Value == "1";
                    coupon.EveryDayTime = useRuleNode.Attributes["everyDayTime"].Value;
                    coupon.WeekEnd = useRuleNode.Attributes["weekEnd"].Value == "1";
                    coupon.FileRule = useRuleNode.Attributes["fileRule"]==null?string.Empty:useRuleNode.Attributes["fileRule"].Value;
                    coupon.Type = Convert.ToInt32(useRuleNode.Attributes["type"].Value);
                    
                }
                 * */
#if DEBUG
                Console.WriteLine("初始化抵购券对象时间3！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif 
                lists.Add(coupon);
                
            }
            return lists;

        }

        public static void GetUserBuyRecordDetail(BuyRecordObject obj)
        {
            string xmlOrderDetail = string.Empty;
            xmlOrderDetail = hiPiaoSrv.QueryUserBuyRecordDetail(obj.User,obj.OrderId);
            XmlDocument docOrderDetail = new XmlDocument();
            docOrderDetail.LoadXml(xmlOrderDetail);
            XmlNode detailNode = docOrderDetail.SelectSingleNode("//return");

            obj.BuyTime = DateTime.Parse(docOrderDetail.SelectSingleNode("//buytime").InnerText);
            obj.ConnectMobile = docOrderDetail.SelectSingleNode("//phonenum").InnerText;
            //obj.TotalPrice = Int32.Parse(docOrderDetail.SelectSingleNode("//summoney").InnerText);
            obj.ValidCode = docOrderDetail.SelectSingleNode("//hipiaonumber").InnerText;
            TicketObject ticket = null;
            MovieObject movie = null;
            CinemaObject cinema = null;
            SeatObject seat = null;
            RoomObject room = null;
            int count = Int32.Parse(docOrderDetail.SelectSingleNode("//ticketnum").InnerText);
            cinema = new CinemaObject();
            cinema.Name = docOrderDetail.SelectSingleNode("//cinemaname").InnerText;
            seat = new SeatObject();
            seat.SeatId = docOrderDetail.SelectSingleNode("//cinemaseat").InnerText;
            room = new RoomObject();
            room.Name = docOrderDetail.SelectSingleNode("//cinemahall").InnerText;
            seat.Room = room;
            room.Cinema = cinema;
            string tmp = docOrderDetail.SelectSingleNode("//onemoney").InnerText;
            tmp = tmp.Substring(1, tmp.IndexOf("元*") - 1);
            //cinemaseat onemoney
            double price = double.Parse(tmp);
            movie = new MovieObject();
            movie.Name = docOrderDetail.SelectSingleNode("//pixname").InnerText;
            DateTime buyTime = DateTime.Parse(docOrderDetail.SelectSingleNode("//buytime").InnerText);
            DateTime playTime=DateTime.Parse(docOrderDetail.SelectSingleNode("//playtime").InnerText);
            for (int j = 0; j < count; j++)
            {
                ticket = new TicketObject();
                ticket.BuyTime =buyTime ;
                ticket.Price = (int)price;
                ticket.PlayTime = playTime;
                ticket.Movie = movie;
                ticket.Seat = seat;
                obj.Tickets.Add(ticket);
            }
        }
        public static int GetUserBuyRecordCount(UserObject user)
        {
#if DEBUG
            Console.WriteLine("开始执行获取订购记录数量时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            string xml = hiPiaoSrv.QueryUserBuyRecord(user);
#if DEBUG
            Console.WriteLine("结束执行获取订购记录数量时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
#if DEBUG
            Console.WriteLine("加载返回结果到XmlDocument文档中！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            string xmlOrderDetail = string.Empty;
            XmlNodeList orderNodes = doc.SelectNodes("//consumption");
            return orderNodes.Count;
        }

        public static List<BuyRecordObject> GetUserBuyRecord(UserObject user)
        {
            List<BuyRecordObject> lists = new List<BuyRecordObject>();
#if DEBUG
            Console.WriteLine("开始执行获取订购记录时间！"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif      
            string xml = hiPiaoSrv.QueryUserBuyRecord(user);
#if DEBUG
            Console.WriteLine("结束执行获取订购记录时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
#if DEBUG
            Console.WriteLine("加载返回结果到XmlDocument文档中！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            string xmlOrderDetail = string.Empty;
            XmlNodeList orderNodes = doc.SelectNodes("//consumption");
            
            string orderid = string.Empty;
            BuyRecordObject obj = null;
          
            for (int i = 0; i < orderNodes.Count; i++)
            {
#if DEBUG
                Console.WriteLine("开始执行获取订购记录详细时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif          
                obj = new BuyRecordObject();
                /*
                 <return xmlns:ns2="http://service.server.com/">
        <buyplace>WEB</buyplace>
        <buytime>2012-09-05 16:40:40</buytime>
        <cinemahall>4号厅</cinemahall>
        <cinemaname>大地数字影院--广州增城东汇城</cinemaname>
        <cinemaseat>11排17号</cinemaseat>
        <format>数字</format>
        <hipiaonumber>340887</hipiaonumber>
        <issend>全部退票</issend>
        <language>英语</language>
        <memberId>26c52c2e-69ae-102e-8c3d-001a4beef7e4</memberId>
        <onemoney>￥301</onemoney>
        <paytype>仅使用账户余额</paytype>
        <phonenum>13269402753</phonenum>
        <pixname>蝙蝠侠：黑暗骑士崛起</pixname>
        <playtime>2012-09-05 22:10:00</playtime>
        <result>1</result>
        <summoney>30元</summoney>
        <ticketnum>1</ticketnum>
      </return>
                 */
                //obj.BuyTime
                orderid = orderNodes[i].Attributes["orderformid"].Value;
                obj.OrderId = orderid;
                obj.User = user;
               
                lists.Add(obj);
#if DEBUG
                Console.WriteLine("开始结束获取订购记录详细时间！" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            }

            return lists;
        }


        public static List<MovieObject> GetDayMovie(string cinema, DateTime day,List<MovieObject> all)
        {
            List<MovieObject> lists = new List<MovieObject>();
            string xml = hiPiaoSrv.GetDayMovie(cinema, day);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList objsNode = doc.SelectNodes("//movieInfo");
            string pixs = string.Empty;
            for (int i = 0; i < objsNode.Count; i++)
            {
                pixs += ";" + objsNode[i].Attributes["pixnumber"].Value + ";";
            }
            for (int i = 0; i < all.Count; i++)
            {
                if (pixs.IndexOf(";" + all[i].Id + ";") != -1)
                {
                    lists.Add(all[i]);
                }
            }
                /*
                XmlNodeList objsNode = doc.SelectNodes("//movieInfo");
                string picurl = string.Empty;
                string downdir = HotMoviePath + "\\" + province + "\\" + city;
                for (int i = 0; i < objsNode.Count; i++)
                {
                    obj = new MovieObject();
                    obj.Name = objsNode[i].Attributes["chname"].Value;
                    obj.BelongArea = objsNode[i].Attributes["country"].Value;
                    obj.Director = objsNode[i].Attributes["director"].Value;
                    obj.OtherName = objsNode[i].Attributes["enname"].Value;
                    obj.ShowDate = Convert.ToDateTime(objsNode[i].Attributes["fshowtime"].Value);
                    obj.MainActors = objsNode[i].Attributes["leadrole"].Value;
                    obj.TotalMinutes = Convert.ToInt32(objsNode[i].Attributes["pixlength"].Value);
                    obj.Id = objsNode[i].Attributes["pixnumber"].Value;
                    obj.Type = objsNode[i].Attributes["pixtype"].Value;

                    picurl = objsNode[i].Attributes["picurl"].Value;

                    obj.AdImagePath = DownLoad(picurl, downdir + "\\" + obj.Name + "\\" + obj.Id);
                    if (obj.AdImagePath.Length > 0)
                        obj.AdImage = Image.FromFile(obj.AdImagePath);
                    //picurl="http://img.hipiao.com/hipiao15/film/201208/174732921950207b3c903e3.jpg" pixlength="89" pixnumber="05110035"
                    //pixtype
                    obj.Introduction = objsNode[i].Attributes["intro"].Value;
                    lists.Add(obj);
                }
                hotMovie = lists;
                 * */
                return lists;

        }
        //<advertisement advName="" advPic="" advPicLink="" advWeizhiOne="" advWeizhiTwo="" />

        private static List<AdvertisementObject> advertisementLists = new List<AdvertisementObject>();

        public static List<AdvertisementObject> GetAdvertisement(string cinema)
        {
            if (advertisementLists.Count == 0)
            {
                RefreshAdvertisement(cinema);
            }
            return advertisementLists;
        }

        public static List<AdvertisementObject> RefreshAdvertisement(string cinema)
        {
            List<AdvertisementObject> lists = new List<AdvertisementObject>();
            string xml = hiPiaoSrv.GetAdvertisement();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            AdvertisementObject obj = null;
            XmlNodeList objsNode = doc.SelectNodes("//advertisement");
            string picurl = string.Empty;
            string downdir = "Caches\\Advertisement\\" ;
            for (int i = 0; i < objsNode.Count; i++)
            {
                obj = new AdvertisementObject();
                obj.AdvName = objsNode[i].Attributes["advName"].Value;
                obj.AdvPicLink = objsNode[i].Attributes["advPicLink"].Value;
                obj.AdvWeizhiOne = objsNode[i].Attributes["advWeizhiOne"].Value;
                obj.AdvWeizhiTwo = objsNode[i].Attributes["advWeizhiTwo"].Value;
                picurl = objsNode[i].Attributes["advPic"].Value;
                obj.AdImagePath = DownLoad(picurl, downdir, string.Empty);
                if (obj.AdImagePath.Length > 0)
                    obj.AdvPic = Image.FromFile(obj.AdImagePath);
                //picurl="http://img.hipiao.com/hipiao15/film/201208/174732921950207b3c903e3.jpg" pixlength="89" pixnumber="05110035"
                //pixtype
                lists.Add(obj);
            }
            advertisementLists = lists;
            return lists;
        } 

        public static List<MovieObject> RefreshHotMovie(string province,string city)
        {
            List<MovieObject> lists = new List<MovieObject>();
            string xml=hiPiaoSrv.GetHotMovie(province, city);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            MovieObject obj = null;
            XmlNodeList objsNode = doc.SelectNodes("//movieInfo");
            string picurl=string.Empty;
            string downdir = HotMoviePath+"\\"+province+"\\"+city;
            for (int i = 0; i < objsNode.Count; i++)
            {
                obj = new MovieObject();
                obj.Name=objsNode[i].Attributes["chname"].Value;
                obj.BelongArea = objsNode[i].Attributes["country"].Value;
                obj.Director = objsNode[i].Attributes["director"].Value;
                obj.OtherName = objsNode[i].Attributes["enname"].Value;
                obj.ShowDate = Convert.ToDateTime(objsNode[i].Attributes["fshowtime"].Value);
                obj.MainActors = objsNode[i].Attributes["leadrole"].Value;
                obj.TotalMinutes = Convert.ToInt32(objsNode[i].Attributes["pixlength"].Value);
                obj.Id = objsNode[i].Attributes["pixnumber"].Value;
                obj.Type = objsNode[i].Attributes["pixtype"].Value;

                picurl=objsNode[i].Attributes["picurl"].Value;

                obj.AdImagePath = DownLoad(picurl, downdir+"\\"+obj.Name+"\\"+obj.Id+"\\adimage","shortimg.jpg");
                if(obj.AdImagePath.Length>0)
                    obj.AdImage = Image.FromFile(obj.AdImagePath);
                //picurl="http://img.hipiao.com/hipiao15/film/201208/174732921950207b3c903e3.jpg" pixlength="89" pixnumber="05110035"
                //pixtype
                obj.Introduction = objsNode[i].Attributes["intro"].Value;
                lists.Add(obj);
            }
            hotMovie = lists;
            return lists;

        }

        public static List<CityObject> GetCitys(string province)
        {
            if (provincesList.Count == 0)
            {
                RefreshProvince();
            }
            for (int i = 0; i < provincesList.Count; i++)
            {
                if (provincesList[i].Name == province)
                {
                    return provincesList[i].Citys;
                }
            }
            return new List<CityObject>();
        }

        public static List<ProvinceObject> GetProvince()
        {
            if (provincesList.Count == 0)
            {
                RefreshProvince();
            }
            return provincesList;
        }

        public static void RefreshProvince()
        {
            provincesList.Clear();
            string xml = hiPiaoSrv.GetCityOfprovince();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList provincesNode = doc.SelectNodes("//Province");
            XmlNodeList citysNode=null;
            CityObject city=null;
            ProvinceObject province = null;
            for (int i = 0; i < provincesNode.Count; i++)
            {
                province = new ProvinceObject();
                province.Name = provincesNode[i].Attributes["name"].Value;
                citysNode = provincesNode[i].ChildNodes;
                for (int j = 0; j < citysNode.Count; j++)
                {
                    city = new CityObject();
                    city.Id = citysNode[j].Attributes["id"].Value;
                    city.McityId = citysNode[j].Attributes["mcityId"].Value;
                    city.Name = citysNode[j].Attributes["name"].Value;
                    province.Citys.Add(city);
                }
                provincesList.Add(province);
            }
        }

    }
}
