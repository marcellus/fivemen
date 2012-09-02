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

        public static string  DownLoad(string url, string dir)
        {
            try
            {
                FileHelper.CheckDirExistsAndCreate(dir);
                WebClient client = new WebClient();
                string filename = url.Substring(url.LastIndexOf('/') + 1);
                string fullname = System.IO.Path.Combine(Path.Combine(Application.StartupPath, dir), filename);
                client.DownloadFile(url, fullname);
                return fullname;
            }
            catch
            {
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
            XmlNode node2 = node.SelectSingleNode("//savetype");
            string language = node2.Attributes["language"].Value;
            string type = node2.Attributes["type"].Value;
            moviePlan.Language = language;
            moviePlan.Type = type;
            XmlNodeList objsNode = node.SelectNodes("//plan");
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
            if (File.Exists(HotMovieCacheFile))
                hotMovie = SerializeHelper.DeserializeFromFile(HotMovieCacheFile) as List<MovieObject>;
            if (File.Exists(ProvincesCacheFile))
                provincesList = SerializeHelper.DeserializeFromFile(ProvincesCacheFile) as List<ProvinceObject>;
           
        }

        public static void SerializedCache()
        {
            CheckAllDir();
            SerializeHelper.SerializeToFile(hotMovie, HotMovieCacheFile+"");
            SerializeHelper.SerializeToFile(provincesList,ProvincesCacheFile );
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


        public static List<MovieObject> GetDayMovie(string cinema, DateTime day)
        {
            List<MovieObject> lists = new List<MovieObject>();
            string xml = hiPiaoSrv.GetDayMovie(cinema, day);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            MovieObject obj = null;
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

                obj.AdImagePath = DownLoad(picurl, downdir+"\\"+obj.Name+"\\"+obj.Id);
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
