using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Collections;

namespace HiPiaoInterface
{
  
    
    public class ResObject
    {
        public int status;
        public string errorMessage;
        public DataObject data;
    }
    
    public class DataObject
    {
        public string CNAME;
        public string CHNAME;
        public string hName;
        public string start;
       
        public List<ItemObject> item;
    }

    public class ItemObject
    {
        public string no;
        public string printed;
        public string seat;
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
         "data": {
 "CNAME":"南昌万达",
 "CHNAME":"生化危机5",
 "hName":"一号厅"
 "start":"2012.10.18 16:00",
 "item":{
 "no":"5000006",
 "printed":"1",
 "seat":"8排10号",
 "price":"60",
 "handleFee":"5"
 }
         }
     }
 }

      */
        /*
        
         {"res":{"status":1,"errorMessage":null,"data":
         * {"CNAME":"115\uff0c\u4e07\u8fbe",
         * "CHNAME":"\u5728\u52ab\u96be\u9003","hName":
         * "2\u53f7\u5385","start":"2012-12-31 23:30:00",
         * "item":[
         * {"no":"a39723aa","printed":"0","seat":"20\u63929\u53f7","price":"63.00","handleFee":"5.00"},
         * {"no":"a3972440","printed":"0","seat":"20\u639210\u53f7","price":"63.00","handleFee":"5.00"}]}}}
        
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
