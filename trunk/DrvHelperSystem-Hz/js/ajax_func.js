var _postXmlHttpProcessPostChangeCallBack;
var _xmlHttpRequestObj;
var _loadingFunction;
//-------------------------------
//  功能介绍：Ajax调用，在不密集调用时使用
//  如需显示Loading，需建立loading的div,返回后调用endLoading函数隐藏div
//  参数说明：url调用地址;processName 返回处理函数;isLoad 是否显示提示条;
//  返回值  ：无返回值
//-------------------------------
function send_request(url, processName, isLoad) {
	var spath = url;
	if (isLoad) {
		postXmlHttp(spath, processName, 'load()');
	} else {
		postXmlHttp(spath, processName, '');
	}
}
//-------------------------------
//  功能介绍：隐藏提示DIV层
//-------------------------------
function endLoading() {
	var loadDiv = document.getElementById("loading");
	loadDiv.style.display = "none";
}


var net = new Object();
net.READY_STATE_UNINITIALIZED = 0;
net.READY_STATE_LOADING = 1;
net.READY_STATE_LOADED = 2;
net.READY_STATE_INTERACTIVE = 3;
net.READY_STATE_COMPLETE = 4;
//-------------------------------
//  功能介绍：Ajax调用对象,密集调用时使用
//  参数说明：onload 返回处理函数,onerror 错误函数处理
//  返回值  ：无返回值
//-------------------------------
net.ContentLoader = function (url, onload, onerror) {
    this.url = url+ "&timestamp=" + getNowSec(0);
    this.req = null;
    this.onload = onload;
    this.onerror = (onerror) ? onerror : this.defaultError;
    this.loadXMLDoc(url);
};
net.ContentLoader.prototype = {
    loadXMLDoc:function (url) {
    if (window.XMLHttpRequest) {
        this.req = new XMLHttpRequest();
    } else {
        if (window.ActiveXObject) {
            try {
                this.req = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                try {
                    this.req = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (e) {
                }
            }
        }
    }
    if (this.req) {
        try {
            var loader = this;
            this.req.onreadystatechange = function () {
                loader.onReadyState.call(loader);
            };
            this.req.open("GET", url, true);
            this.req.send(null);
        }
        catch (err) {
            this.onerror.call(this);
        }
    }
}, onReadyState:function () {
    var req = this.req;
    var ready = req.readyState;
    if (ready == net.READY_STATE_COMPLETE) {
        var httpStatus = req.status;
        if (httpStatus == 200 || httpStatus == 0) {
            this.onload.call(this);
        } else {
            this.onerror.call(this);
        }
    }
}, defaultError:function () {
    alert("error fetching data!" + "\n\nreadyState:" + this.req.readyState + "\nstatus: " + this.req.status + "\nheaders: " + this.req.getAllResponseHeaders());
}};
function createXMLHttpRequest() {
	var http_request = false;
	if (window.XMLHttpRequest) {
		http_request = new XMLHttpRequest();
		if (http_request.overrideMimeType) {
			http_request.overrideMimeType('text/xml');
		}
	} else if (window.ActiveXObject) {
		try {
			http_request = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) {
			try {
				http_request = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {
			}
		}
	}
	return http_request;
}
function postXmlHttp(submitUrl, callbackFunc, loadFunc) {
	_postXmlHttpProcessPostChangeCallBack = callbackFunc;
	_loadingFunction = loadFunc;
	_xmlHttpRequestObj = createXMLHttpRequest();
	if (!_xmlHttpRequestObj) {
		window.alert("不能创建XMLHttpRequest对象实例.");
		return false;
	}
	_xmlHttpRequestObj.open('POST', submitUrl + "&timestamp=" + getNowSec(0), true);
	_xmlHttpRequestObj.onreadystatechange = postXmlHttpProcessPostChange;
	_xmlHttpRequestObj.send("");
}

function postXmlHttpProcessPostChange() {
	if (_xmlHttpRequestObj.readyState == 4 && _xmlHttpRequestObj.status == 200) {
		setTimeout(_postXmlHttpProcessPostChangeCallBack, 2);
	}
	if (_xmlHttpRequestObj.readyState == 1) {
		setTimeout(_loadingFunction, 2);
	}
}
function load() {
	var loadDiv = document.getElementById("loading");
	loadDiv.style.display = "block";
}

//
function changchild(objname) {
	delselect(objname);
	var results = _xmlHttpRequestObj.responseXML.getElementsByTagName("unit");
	insselect(objname, results);
}

function delselect(objname) {
	var product = document.getElementById(objname);
	while (product.childNodes.length > 0) {
		product.removeChild(product.childNodes[0]);
	}
	option = document.createElement("option");
	option.innerText = "请选择";
	option.value = "";
	product.appendChild(option);

}

function insselect(objname, xmlresult) {
	var obj = document.getElementById(objname);
	var option = null;
	for ( var i = 0; i < xmlresult.length; i++) {
		option = document.createElement("option");
		option.innerText = xmlresult[i].getElementsByTagName("mc")[0].firstChild.data;
		option.value = xmlresult[i].getElementsByTagName("dm")[0].firstChild.data;
		obj.appendChild(option);
	}
}
function getNowSec(i){
  var today = new Date();
  var day=today.getDate();
  day = day + i;
  today.setDate(day);
  var month=today.getMonth() + 1;
  day=today.getDate();
  if(month<10) sMonth="0" + month;
  else sMonth = month;
  if(day<10) sDay="0" + day;
  else sDay = day;
  hour = today.getHours();
  if(hour<10) strHour = "0" + hour;
  else strHour = hour;
  min = today.getMinutes();
  if(min<10) strMin = "0" + min;
  else strMin = min;
  sec = today.getSeconds();
  if(sec<10) strSec = "0" + sec;
  else strSec = sec;
  r = today.getFullYear() + "-" + sMonth + "-" + sDay + " " + strHour + ":" + strMin + ":" + strSec;
  return r;
}