using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Commons.Web.Tools;
using FT.Web.Bll.Terminal;
using FT.Commons.ExtendServices.Weather;
using FT.Commons.Tools;

public partial class YuanTuo_UserControlEx_WeatherShowControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string cityIp = WebToolsHelper.GetIp();
            TerminalStatus terminal= TerminalOnlineMonitorThread.GetTerminal(cityIp);
            string cityCode = string.Empty;
            if (terminal != null)
            {
                cityCode = terminal.CityCode;
            }
            else
            {
                cityCode = "101010100";
            }
            if (cityCode != null && cityCode.Length > 0)
            {
                WeatherObject weather=null;
                try
                {
                    weather = WeatherHelper.GetCityWeather(cityCode);
                }
                catch
                {
                }
                if (weather != null)
                {
                    this.lbCity.Text = weather.weatherinfo.city;
                    this.lbDate.Text = System.DateTime.Now.ToString("M月d日");
                    this.lbTemp.Text = weather.weatherinfo.temp1;
                    this.lbTrafficLimit.Text = this.GetTrafficLimitInfo(cityCode);
                    this.lbWeek.Text = weather.weatherinfo.week;
                    this.lbWind.Text = weather.weatherinfo.wind1;
                    this.img1.Visible = true;
                    this.img1.ImageUrl = weather.weatherinfo.img1;
                }
                else
                {
                    this.lbCity.Text = "预报出错";
                    this.lbDate.Text = System.DateTime.Now.ToString("M月d日");
                    this.lbTemp.Text = string.Empty;
                    this.lbTrafficLimit.Text = this.GetTrafficLimitInfo(cityCode);
                    this.lbWeek.Text = DateTimeHelper.GetChineseXq(System.DateTime.Now);
                    this.lbWind.Text = string.Empty;
                    this.img1.Visible = false;
                   // this.img1.ImageUrl = weather.weatherinfo.img1;

                }
            }
        }
    }

    private string GetTrafficLimitInfo(string citycode)
    {
       
        string result = string.Empty;
        FT.DAL.IDataAccess dataAccess = FT.DAL.DataAccessFactory.GetDataAccess();
        string sql = "select limitcontent from  common_traffic_limitinfo_extend where citycode='" + citycode + "' and getdate() between startdate and enddate";

        object obj=dataAccess.SelectScalar(sql);
        if (obj != null)
        {
            result = obj.ToString();
        }
        else
        {
            sql = "select limitcontent from  common_traffic_limitinfo where citycode='" + citycode + "' and weekday=" + FT.Commons.Tools.DateTimeHelper.GetNumberWeekDay(System.DateTime.Now);

            object obj2 = dataAccess.SelectScalar(sql);
            if (obj2 != null)
            {
                result = obj2.ToString();
            }
        }
        result = result.Replace("-", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        return result;
    }

   
}
