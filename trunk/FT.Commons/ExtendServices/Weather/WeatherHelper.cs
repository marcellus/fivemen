using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;

namespace FT.Commons.ExtendServices.Weather
{
    public class WeatherHelper:BaseHelper
    {
        private WeatherHelper()
        {
        }
        /*
         * http://m.weather.com.cn/data/101110101.html
         * {"weatherinfo":{"city":"西安","city_en":"xian","date_y":"2012年12月29日","date":"","week":"星期六","fchh":"18","cityid":"101110101","temp1":"-7℃~3℃","temp2":"-6℃~4℃","temp3":"-4℃~3℃","temp4":"-3℃~3℃","temp5":"-5℃~1℃","temp6":"-3℃~0℃","tempF1":"19.4℉~37.4℉","tempF2":"21.2℉~39.2℉","tempF3":"24.8℉~37.4℉","tempF4":"26.6℉~37.4℉","tempF5":"23℉~33.8℉","tempF6":"26.6℉~32℉","weather1":"晴","weather2":"晴","weather3":"晴转多云","weather4":"多云","weather5":"多云转阴","weather6":"小雪","img1":"0","img2":"99","img3":"0","img4":"99","img5":"0","img6":"1","img7":"1","img8":"99","img9":"1","img10":"2","img11":"14","img12":"99","img_single":"0","img_title1":"晴","img_title2":"晴","img_title3":"晴","img_title4":"晴","img_title5":"晴","img_title6":"多云","img_title7":"多云","img_title8":"多云","img_title9":"多云","img_title10":"阴","img_title11":"小雪","img_title12":"小雪","img_title_single":"晴","wind1":"西北风小于3级","wind2":"西北风小于3级","wind3":"西北风小于3级","wind4":"西北风小于3级","wind5":"西风小于3级","wind6":"西南风小于3级","fx1":"西北风","fx2":"西北风","fl1":"小于3级","fl2":"小于3级","fl3":"小于3级","fl4":"小于3级","fl5":"小于3级","fl6":"小于3级","index":"冷","index_d":"天气冷，建议着棉衣、皮夹克加羊毛衫等冬季服装。年老体弱者宜着厚棉衣或冬大衣。","index48":"冷","index48_d":"天气冷，建议着棉衣、皮夹克加羊毛衫等冬季服装。年老体弱者宜着厚棉衣或冬大衣。","index_uv":"弱","index48_uv":"弱","index_xc":"适宜","index_tr":"较适宜","index_co":"较不舒适","st1":"2","st2":"-6","st3":"4","st4":"-4","st5":"3","st6":"-2","index_cl":"不宜","index_ls":"基本适宜","index_ag":"极不易发"}}
         * 
         * http://www.weather.com.cn/data/sk/101010100.html
         * {"weatherinfo":{"city":"北京","cityid":"101010100","temp":"-2","WD":"西北风","WS":"3级","SD":"241%","WSE":"3","time":"10:61","isRadar":"1","Radar":"JC_RADAR_AZ9010_JB"}}
         * 
         * http://www.weather.com.cn/data/sk/101010100.html
         * 
         * {"weatherinfo":{"city":"北京","cityid":"101010100","temp":"-2","WD":"西北风","WS":"3级","SD":"241%","WSE":"3","time":"10:61","isRadar":"1","Radar":"JC_RADAR_AZ9010_JB"}}
         * 
         * 
         * 
         * **/

        public static readonly string AllWeatherUrl = "http://m.weather.com.cn/data/{0}.html";
        public static readonly string SdWeatherUrl = "http://www.weather.com.cn/data/sk/{0}.html";
        public static readonly string TimeWeatherUrl = "http://www.weather.com.cn/data/sk/{0}.html";

        public static readonly string WeatherImgUrl = "http://m.weather.com.cn/img/c{0}.gif";
        public static WeatherObject GetCityWeather(string cityid)
        {
            string result = HttpMockRequestHelper.GetMockRequestResult(string.Format(AllWeatherUrl, cityid));
            WeatherObject weather=JsonHelper.FromJson<WeatherObject>(result);

            weather.weatherinfo.img1 = string.Format(WeatherImgUrl, weather.weatherinfo.img1);
            return weather;
        }
    }
}
