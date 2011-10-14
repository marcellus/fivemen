
function getNowSec(i) {
    var today = new Date();
    var day = today.getDate();
    day = day + i;
    today.setDate(day);
    var month = today.getMonth() + 1;
    day = today.getDate();
    if (month < 10) {
        sMonth = "0" + month;
    } else {
        sMonth = month;
    }
    if (day < 10) {
        sDay = "0" + day;
    } else {
        sDay = day;
    }
    hour = today.getHours();
    if (hour < 10) {
        strHour = "0" + hour;
    } else {
        strHour = hour;
    }
    min = today.getMinutes();
    if (min < 10) {
        strMin = "0" + min;
    } else {
        strMin = min;
    }
    sec = today.getSeconds();
    if (sec < 10) {
        strSec = "0" + sec;
    } else {
        strSec = sec;
    }
    r = today.getFullYear() + "-" + sMonth + "-" + sDay + " " + strHour + ":" + strMin + ":" + strSec;
    return r;
}
function createXMLHttpRequest() {
    var http_request = false;
    if (window.XMLHttpRequest) {
        http_request = new XMLHttpRequest();
        if (http_request.overrideMimeType) {
            http_request.overrideMimeType("text/xml");
        }
    } else {
        if (window.ActiveXObject) {
            try {
                http_request = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                try {
                    http_request = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (e) {
                }
            }
        }
    }
    return http_request;
}


function send_request( url,processName,isLoad)
{
  var spath=url + "&timestamp=" + getNowSec(0);
  if(isLoad)
  {
    postXmlHttp( spath, processName ,'load()');
  }
  else
  {
    postXmlHttp( spath, processName ,'');
  }
}

function load()
{
   var loadDiv= document.getElementById( "loading" );
   loadDiv.style.display="block";
}
function endLoading()
{
   var loadDiv= document.getElementById( "loading" );
   loadDiv.style.display="none"; 
}
var _postXmlHttpProcessPostChangeCallBack;
var _xmlHttpRequestObj;
var _loadingFunction;

function postXmlHttp( submitUrl, callbackFunc ,loadFunc)
{
  _postXmlHttpProcessPostChangeCallBack = callbackFunc;
  _loadingFunction = loadFunc;
  _xmlHttpRequestObj=createXMLHttpRequest();
  if (!_xmlHttpRequestObj) 
  {
    window.alert("不能创建XMLHttpRequest对象实例.");
	return false;
  }
  _xmlHttpRequestObj.open('POST',submitUrl,true);
  _xmlHttpRequestObj.onreadystatechange=postXmlHttpProcessPostChange;
  _xmlHttpRequestObj.send("");
};

function postXmlHttpProcessPostChange( )
{
  if( _xmlHttpRequestObj.readyState==4 && _xmlHttpRequestObj.status==200 )
  {
    setTimeout( _postXmlHttpProcessPostChangeCallBack, 2 );
  }
  if ( _xmlHttpRequestObj.readyState==1 )
  {
    setTimeout( _loadingFunction, 2 );
  }
}
