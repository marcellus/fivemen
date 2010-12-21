
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

   function getUserList()
   {
   	     var xmlDoc=_xmlHttpRequestObj.responseXML;
   	    
         var oUserNode,oNode;
         var iUnitCount,i;
          idUser.loadXML(xmlDoc.xml);
          idUser.async=false;
          clearFieldOptions(document.all["user"]);
          oUserNode=idUser.getElementsByTagName("root");
          iUnitCount=oUserNode.item(0).getElementsByTagName("unit").length;
          for(i = 0; i <iUnitCount ; i++)
          {
          	   oNode=oUserNode.item(0).getElementsByTagName("unit").item(i);
          	   var yhdh=oNode.getElementsByTagName("yhdh").item(0).text;
          	   var yhmc=oNode.getElementsByTagName("yhmc").item(0).text;
          	   if(yhdh=="")
          	   {
          	   	    addcomboxitem(document.all["user"],"","");
          	   }
          	   else
          	   {
          	      addcomboxitem(document.all["user"],yhdh,yhdh+":"+yhmc);
          	   }
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
    window.alert(" 不能创建XMLHttpRequest对象实例.");
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