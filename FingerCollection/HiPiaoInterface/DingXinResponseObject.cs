using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HiPiaoInterface
{

    public class ResObject
    {
        public int status;
        public string errorMessage;
        public string errorCode;
        public DataObject data;
    }

    public class DataObject
    {
        public string printed;
        public string printTime;
        public string cinemaName;
        public string movieName;
        public string movieLanguage;
        public string movieSubtitle;

        public string movieStart;
        public string movieEnd;
        public ItemObject item;
    }

    public class ItemObject
    {
        public string no;
        public string hallName;
        public string row;
        public string column;
        public string type;
        public string price;
        public string handleFee;
       
    }
    /// <summary>
    /// 鼎新取票返回结果
    /// </summary>
   public  class DingXinResponseObject
    {
       /*
        {
    "res": {
        "status": 1,
        "errorMessage":null,
        "errorCode": null,
        "data": {
            "printed":"1",
            "printTime":"2012-10-18 13:56:12",
            "cinemaName":"南昌万达",
            "movieName":"生化危机5",
            "movieLanguage":"英语",
            "movieSubtitle":"中文",
            "movieStart":"2012-10-18 16:00:45",
            "movieEnd":"2012-10-18 18:00:45",
            "item":{
                "no":"5000006",
                "hallName":"3号IMAX厅",
                "row":"8排",
                "column":"10号",
                "type":"半价票",
                "price":"60",
                "handleFee":"5"
             }
        }
    }
}

        
        */

       public ResObject res;
       public static DingXinResponseObject Parse(string output)
       {
/*
           output = "{"
              // +"\"status\": 1,"
   +" \"res\": {"
    +"   \"status\": 1,"
     +"   \"errorMessage\":null,"
     +"  \"errorCode\": null,"
     +"   \"data\": {"
      +"      \"printed\":\"1\","
      +"      \"printTime\":\"2012-10-18 13:56:12\","
      +"      \"cinemaName\":\"南昌万达\","
      +"      \"movieName\":\"生化危机5\","
      +"      \"movieLanguage\":\"英语\","
      +"      \"movieSubtitle\":\"中文\","
      +"      \"movieStart\":\"2012-10-18 16:00:45\","
      +"      \"movieEnd\":\"2012-10-18 18:00:45\","
      +"      \"item\":{"
      +"          \"no\":\"5000006\","
      +"          \"hallName\":\"3号IMAX厅\","
      +"          \"row\":\"8排\","
      +"          \"column\":\"10号\","
      +"          \"type\":\"半价票\","
      +"          \"price\":\"60\","
      +"          \"handleFee\":\"5\" }}}}";
 * */
           
           DingXinResponseObject response = (DingXinResponseObject)Newtonsoft.Json.JsonConvert.DeserializeObject(output, typeof(DingXinResponseObject));
           string tt = "";
           return response;

       }
    }
}
