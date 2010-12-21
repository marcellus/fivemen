function setcookie(nKey,nVal){
document.cookie=nKey+"="+nVal+";expires=wednesday,09-oct-2099 23:00:00 GMT"
}
//-------------------------------
//函数名：notNull(i_field,i_value)
//功能介绍：检查输入是否为非空
//参数说明：数据项，输入的对应值
//返回值  ：1-非空,0-为空
//-------------------------------
function notNull(i_field,i_value)
{
if (i_value==null || jstrim(i_value)=="")
{
 alert("'"+i_field+"' 不可为空！");
 return 0;
}
return 1;
}

//-------------------------------
//函数名：isNum(i_field,i_value)
//功能介绍：检查输入字符串是否为数字
//参数说明：数据项，输入的对应值
//返回值  ：1-是数字,0-非数字
//-------------------------------
function isNum(i_field,i_value)
{
if (notNull(i_field,i_value)==0)
{return 0;
}

re=new RegExp("[^0-9]");
var s;
if(s=i_value.match(re))
 {
    alert("'"+i_field+"' 中含有非法字符 '"+s+"' ！");
    return 0;
 }
return 1;
}

//-------------------------------
//函数名：isDate(i_field,thedate)
//功能介绍：校验字符串是否为日期格式
//参数说明：数据项，输入的字符串
//返回值  ：0-不是，1--是
//-------------------------------

function isDate(i_field,thedate)
{
if (!(thedate.length==8 || thedate.length==10))
{    alert("'"+i_field+"'日期格式不对,\n要求为yyyymmdd或yyyy-mm-dd！");
 return 0;
}
if (thedate.length==8)
{
	thedate=thedate.substr(0,4)+"-"+thedate.substr(4,2)+"-"+thedate.substr(6,2);
}

var reg = /^(\d{1,4})(-)(\d{1,2})\2(\d{1,2})$/;
var r = thedate.match(reg);

 if (r==null)
{
   alert("请输入正确的'"+i_field+"' ！");
   return 0;

}
var d= new Date(r[1],r[3]-1,r[4]);
var newStr=d.getFullYear()+r[2]+(d.getMonth()+1)+r[2]+d.getDate()
var newDate=r[1]+r[2]+(r[3]-0)+r[2]+(r[4]-0)
//alert("----------r:"+r+" d:"+d+" newStr:"+newStr+" newDate:"+newDate);
if (newStr==newDate)
     {
      return 1;
     }
 alert("'"+i_field+"'日期格式不对,\n要求为yyyymmdd或yyyy-mm-dd！");
 return 0;
}

//-------------------------------
//函数名：jstrim(s_value)
//功能介绍：去掉s_value两端的空格
//参数说明：被操作的字符串
//返回值  ：处理结果字符串
//-------------------------------
function jstrim(s_value){
var i;
var ibegin;

for(i=0;i<s_value.length;i++){
	if(s_value.charAt(i)!=' ')
		break;
}

if(i==s_value.length)
	return "";
else
	ibegin=i;

for(i=s_value.length-1;i>=0;i--){
	if(s_value.charAt(i)!=' ')
		break;
}
return s_value.substr(ibegin,i-ibegin+1);
}


function changeDate(thedate){
	 if (thedate.length==8){
	  	thedate=thedate.substr(0,4)+"-"+thedate.substr(4,2)+"-"+thedate.substr(6,2);
	 }
	 return thedate;
	}
//####################################
//保存客户信息
//
//
//#####################################
function getcookie(nKey){
	var search=nKey+"=";
	begin=document.cookie.indexOf(search);
	if (begin!=-1){
		begin+=search.length
		end=document.cookie.indexOf(";",begin);
		if (end==-1){
			end=document.cookie.length;
		}
		return document.cookie.substring(begin,end)
	}else{
	return ""
	}
}

function setcookie(nKey,nVal){
document.cookie=nKey+"="+nVal+";expires=wednesday,09-oct-2099 23:00:00 GMT"
}