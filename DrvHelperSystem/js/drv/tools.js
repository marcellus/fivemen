String.prototype.ReplaceAll = stringReplaceAll;

function  stringReplaceAll(AFindText,ARepText){
  raRegExp = new RegExp(AFindText,"g");
  return this.replace(raRegExp,ARepText)
}

//获得当前日期+i天
function fCheckInputInt(){
  if (event.keyCode < 48 || event.keyCode > 57)
    event.returnValue = false;
}
function setformselectvalue(form)
{
  for(i=0;i<form.elements.length;i++)
  {
    if(form.elements[i].type=="select-one")
    {
      if(form.elements[i].options.selectedIndex<0)
      form.elements[i].options.selectedIndex=0;
    }
  }
}

//关闭子窗口
function closesubwin(){
  if(subwinname!=null&&isclosesubwin==1){
    subwinname.close();
  }
}
//关闭窗口
function closewin(){
	window.close();
}
  
//-------------------------------
//  函数名：isNum(i_field,i_value)
//  功能介绍：检查输入字符串是否为数字
//  参数说明：数据项，输入的对应值
//  返回值  ：1-是数字,0-非数字
//-------------------------------
function isNum(i_field,i_value)
{
    re=new RegExp("[^0-9]");
    var s;
    if(s=i_value.match(re))
     {
        alertDialog("'"+i_field+"' 中含有非法字符 '"+s+"' ！");
        return 0;
     }
    return 1;
}

function isDate(obj){
	var thedate="";
	try{
		thedate=document.all[obj];
	}catch(e){
		thedate=document.all[obj];
	}
	if(typeof(thedate.value)=='undefined'){
		thedate=document.all[obj];
	}
	if(thedate.value.length==0||thedate.value==null){
		alert("日期格式不对,\n要求为yyyy-mm-dd！");
		riqi(obj);
		return 0;
	}
/*
	if (!(thedate.value.length==10)){    
		alert("日期格式不对,\n要求为yyyy-mm-dd！");
		riqi(obj);
		return 0;
	}
*/
	var reg = /^(\d{1,4})(-)(\d{1,2})\2(\d{1,2})$/;
	var r = thedate.value.match(reg);
	if (!(r==null)){
		var d= new Date(r[1],r[3]-1,r[4]);
		var newStr=d.getFullYear()+r[2]+(d.getMonth()+1)+r[2]+d.getDate()
		var newDate=r[1]+r[2]+(r[3]-0)+r[2]+(r[4]-0)
		if (newStr==newDate){
			return 1;
		}
		alert("日期格式不对,\n要求为yyyy-mm-dd！");
		riqi(obj);
		return 0;
	}
	alert("日期格式不对,\n要求为yyyy-mm-dd！");
	riqi(obj);
	return 0;
}

//判断身份证号的合法性
function sfzCheck(hm,obj)
{
      var w=new Array();
      var ll_sum;
      var ll_i;
      var ls_check;
      w[0]=7;
      w[1]=9;
      w[2]=10;
      w[3]=5;
      w[4]=8;
      w[5]=4;
      w[6]=2;
      w[7]=1;
      w[8]=6;
      w[9]=3;
      w[10]=7;
      w[11]=9;
      w[12]=10;
      w[13]=5;
      w[14]=8;
      w[15]=4;
      w[16]=2;
     ll_sum=0;

     for (ll_i=0;ll_i<=16;ll_i++)
     {   //alert("ll_i:"+ll_i+" "+hm.substr(ll_i,1)+"w[ll_i]:"+w[ll_i]+"  ll_sum:"+ll_sum);
        ll_sum=ll_sum+(hm.substr(ll_i,1)-0)*w[ll_i];

     }
     ll_sum=ll_sum % 11;


     switch (ll_sum)
      {
        case 0 :
            ls_check="1";
            break;
        case 1 :
            ls_check="0";
            break;
        case 2 :
            ls_check="X";
            break;
        case 3 :
            ls_check="9";
            break;
        case 4 :
            ls_check="8";
            break;
        case 5 :
            ls_check="7";
            break;
        case 6 :
            ls_check="6";
            break;
        case 7 :
            ls_check="5";
            break;
        case 8 :
            ls_check="4";
            break;
        case 9 :
            ls_check="3";
            break;
        case 10 :
            ls_check="2";
            break;
      }

      if (hm.substr(17,1) != ls_check)
      {
            alertDialog("身份证校验错误！------ 末位应该:"+ls_check+" 实际:"+hm.substr(17,1),2);
            obj.focus();
           // obj.focus();
            return 0;
     }
     return 1
}
function check_sfzh(zjhmObj) {
  var birthday = "";
  var zjhm1 = "";
  var zjhm2 = "";
  var s = "";
  var zjhm = zjhmObj.value;
    if (notNull(zjhmObj,"身份证号") == 0) {
      return 0;
    }
    if (! (zjhm.length == 15 || zjhm.length == 18)) {
      alert("身份证长度不对,请检查！");
      zjhmObj.focus();
      //zjhmObj.focus();
      return 0;
    }
    zjhm1 = zjhm;
    if (zjhm.length == 18) {
      zjhm1 = zjhm.substr(0, 17);
      zjhm2 = zjhm.substr(17, 1);
    }

    re = new RegExp("[^0-9]");
    if (s = zjhm1.match(re)) {
      alert("输入的值中含有非法字符'" + s + "'请检查！");
      zjhmObj.focus();
      // zjhmObj.focus();
      return 0;
    }
    //取出生日期
    if (zjhm.length == 15) {
      birthday = "19" + zjhm.substr(6, 6);
    }
    else {
      re = new RegExp("[^0-9A-Z]");
      if (s = zjhm2.match(re)) { //18位身份证对末位要求数字或字符
        alert("输入的值中含有非法字符'" + s + "'请检查！");
        zjhmObj.focus();
        //zjhmObj.focus();
        return 0;
      }
      birthday = zjhm.substr(6, 8);
    }
    birthday = birthday.substr(0, 4) + "-" + birthday.substr(4, 2) + "-" +
        birthday.substr(6, 2)
        //alert("birthday"+birthday)

        if (newisDate("身份证号码出生日期", birthday) == 0) { //检查日期的合法性
        zjhmObj.focus();
      return 0;
    }

    //var nl=cal_years(birthday);//求年龄
    /*
             if (nl-0<18 || nl>70)
                {
                 alert("申请年龄要求 18--70 ,当前 "+nl+" ！");
                return 0;
               }*/
    if (zjhm.length == 18) {
      return (newsfzCheck(zjhm)); //对18位长的身份证进行末位校验
    }
    // else{
    //  zjhmObj.value=id15to18(zjhm);
    // }

  return 1;
}
//检测日期是否正确
function newisDate(i_field,thedate)
{if (thedate.length==8)
  {
  	thedate=thedate.substr(0,4)+"-"+thedate.substr(4,2)+"-"+thedate.substr(6,2);
  }
    var reg = /^(\d{1,4})(-)(\d{1,2})\2(\d{1,2})$/;
    var r = thedate.match(reg);

     if (r==null)
    {
       alert("'"+i_field+"' 含非法字符！");
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
     alert("'"+i_field+"'日期格式不对！");
     return 0;
}
//检测身份证号
function newsfzCheck(hm)
{

      var w=new Array();
      var ll_sum;
      var ll_i;
      var ls_check;

      w[0]=7;
      w[1]=9;
      w[2]=10;
      w[3]=5;
      w[4]=8;
      w[5]=4;
      w[6]=2;
      w[7]=1;
      w[8]=6;
      w[9]=3;
      w[10]=7;
      w[11]=9;
      w[12]=10;
      w[13]=5;
      w[14]=8;
      w[15]=4;
      w[16]=2;
     ll_sum=0;

     for (ll_i=0;ll_i<=16;ll_i++)
     {   //alert("ll_i:"+ll_i+" "+hm.substr(ll_i,1)+"w[ll_i]:"+w[ll_i]+"  ll_sum:"+ll_sum);
        ll_sum=ll_sum+(hm.substr(ll_i,1)-0)*w[ll_i];

     }
     ll_sum=ll_sum % 11;


     switch (ll_sum)
      {
        case 0 :
            ls_check="1";
            break;
        case 1 :
            ls_check="0";
            break;
        case 2 :
            ls_check="X";
            break;
        case 3 :
            ls_check="9";
            break;
        case 4 :
            ls_check="8";
            break;
        case 5 :
            ls_check="7";
            break;
        case 6 :
            ls_check="6";
            break;
        case 7 :
            ls_check="5";
            break;
        case 8 :
            ls_check="4";
            break;
        case 9 :
            ls_check="3";
            break;
        case 10 :
            ls_check="2";
            break;
      }
      if (hm.substr(17,1) != ls_check)
      {
            alert("证件校验错误！------ 末位应该:"+ls_check+" 实际:"+hm.substr(17,1));
            return 0;
     }
return 1
}
function id15to18(zjhm) {
    var strJiaoYan = new Array("1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2");
    var intQuan = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1);
    var ll_sum = 0;
    var i;
    var t;
    zjhm = zjhm.substr(0, 6) + "19" + zjhm.substr(6);
    for (i = 0; i < zjhm.length; i++) {
      ll_sum = ll_sum +
          parseInt(zjhm.substr(i,1)) * intQuan[i];
    }
    ll_sum = ll_sum % 11;
    zjhm = zjhm + strJiaoYan[ll_sum];
    return zjhm;
}

function isTrueDateTime(day, month, year,hour,min,second) {
      if (month < 1 || month > 12) {
          return false;
          }
      if (day < 1 || day > 31) {
          return false;
          }
      if ((month == 4 || month == 6 || month == 9 || month == 11) &&
          (day == 31)) {
          return false;
          }
      if (month == 2) {
          var leap = (year % 4 == 0 &&
         (year % 100 != 0 || year % 400 == 0));
          if (day>29 || (day == 29 && !leap)) {
          return false;
          }
         }
      if(hour<0||hour>23){
         return false;
         }
      if(min<0||min>59){
         return false;
         }
      if(second<0||second>59){
         return false;
         }
      return true;
}

//显示分行信息
function displayInfo(strinfo,flag)
{
  if(strinfo==null) strinfo="";
  while(strinfo.indexOf("A~A~")>0) {
	  strinfo = strinfo.replace("A~A~", "\n");
  }
  if(flag!=null)
    alertDialog(strinfo,flag);
  else
    alertDialog(strinfo,1);
}
//改变form的状态 0-可写 1-编辑只读 disabled 2-查看只读readonly
function changeformstate(form,iZt){
  switch (iZt){
    case 0:
      for(i=0;i<form.elements.length;i++)
        form.elements[i].disabled = false;
      break;
    case 1:
      for(i=0;i<form.elements.length;i++){
        form.elements[i].disabled = true;
      }
      break;
    case 2:
      for(j=0;j<form.elements.length;j++)
      {
        if(form.elements[j].type=="select-one"&&form.elements[j].size<=1){
          if(form.elements[j].options.selectedIndex>=0){
            sValue = form.elements[j].value;
            sCaption = form.elements[j].options[form.elements[j].options.selectedIndex].innerText;
            //clearFieldOptions(form.elements[j]);
            form.elements[j].innerHTML = "";
            changecomboxvalue(form.elements[j],sValue,sCaption);
          }else{
            //clearFieldOptions(form.elements[j]);
            form.elements[j].innerHTML = "";
          }
        }else if(form.elements[j].type=="checkbox"||form.elements[j].type=="radio"){
          form.elements[j].disabled = true;
        }else if(form.elements[j].type=="button"){
          form.elements[j].style.visibility = 'hidden';
        }else{
          form.elements[j].readOnly = true;
        }
      }
      break;
  }

}

function setformtextvalue(form,value){
  for(i=0;i<form.elements.length;i++)
    if(form.elements[i].type=="text"||form.elements[i].type=="select-one"||form.elements[i].type=="hidden")
    	form.elements[i].value = value;
}

function invalidLetter(m_fields,obj,strLetter){
    var m_Value=obj.value;
    var i, c;
    for (i = 0; i < m_Value.length; i++) {
      c = m_Value.charAt(i); //字符串s中的字符
      if (strLetter.indexOf(c) == -1) {
        alertDialog(m_fields + "含有非法字符‘" + c + "’!",2);
        obj.focus();
        return false;
      }
    }
    return true;
}
//替换A~A~为'\n'
function replaceEnter(strinfo){
	if(strinfo==null) strinfo="";
	while(strinfo.indexOf("A~A~")>=0){
		strinfo = strinfo.replace("A~A~", "\r\n");
	}
	return strinfo;
}
function replaceAll(str,oChar,nChar){
	if(str==null) str="";
	while(str.indexOf(oChar)>=0){
		str=str.replace(oChar,nChar);
	}
	return str;
}
//取字符串的字节长度
function strlen(str){
	var len;
	var i;
	len = 0;
	for (i=0;i<str.length;i++){
		if (str.charCodeAt(i)>255) len+=2; else len++;
	}
	return len;
}

function getMonthLastDate(iYear,iMonth){
	var dateArray= new Array(31,28,31,30,31,30,31,31,30,31,30,31);
	var days=dateArray[iMonth-1];
	if ((((iYear % 4 == 0) && (iYear % 100 != 0)) || (iYear % 400 == 0)) && iMonth==2){
		days=29;
	}
	return days;
}

function DateAddMonth(strDate,iMonths){
   var thisYear = parseFloat(strDate.substring(0,4));
   var thisMonth = parseFloat(strDate.substring(5,7));
   var thisDate = parseFloat(strDate.substring(8,10));
   var d =thisYear *12 + thisMonth + parseFloat(iMonths);

   var newMonth = d % 12;
   if (newMonth==0) {
   	newMonth=12;
   }
   var newYear = (d - newMonth) /12;
   var newDate = thisDate;
   var iMonthLastDate=getMonthLastDate(newYear,newMonth)
   if (newDate>iMonthLastDate) newDate=iMonthLastDate;
   var newDay="";

   newDay += newYear;
   if (newMonth<10) {
   	newDay +="-" + "0" + newMonth;
   }else{
   	newDay +="-" + newMonth;
   }

   if (newDate<10) {
   	newDay +="-" + "0" + newDate;
   }else{
   	newDay +="-" + newDate;
   }
   return(newDay);                                // 返回日期。
}

function getNyr(date)
{
  if(date.length==10)//类似2005-02-01
  {
    return date.substring(0,4)+"年"+date.substring(5,7)+"月"+date.substring(8,10)+"日";
  }else if(date.length==16)//类似2005-02-01 01:01
  {
    return date.substring(0,4)+"年"+date.substring(5,7)+"月"+date.substring(8,10)+"日"+date.substring(11,13)+"时"+date.substring(14,16)+"分";
  }else if(date.length==18)//18位身份证号
  {
    return date.substring(6,10)+"年"+date.substring(10,12)+"月"+date.substring(12,14)+"日";
  }else if(date.length==15)//15位身份证号
  {
    return "19"+date.substring(6,8)+"年"+date.substring(8,10)+"月"+date.substring(10,12)+"日";
  }else
  {
    return "";
  }
}


function  addDay(str,num){   
var   d=new   Date(str);
  d.setDate(d.getDate()+num);
  return   d.getFullYear()+"-"+("0"+(1+d.getMonth())).slice(-2)+"-"+("0"+d.getDate()).slice(-2);   
}

//日期类设置方法
function riqi_other(rq,otherrq,num){
	riqi(rq);
}

function formatMm(mm){
	var month=mm;
		if(month.length<2) {
		month="0" + month;
	}
	return month;
}

function getStatsBeginDay2(iStartDay){
	var today = new Date();
	var day=today.getDate();
	//  today.setDate(day-10);
	day = today.getDate();
	var month=today.getMonth() + 1;
	var year=today.getFullYear();
	if(day>=iStartDay){
		if(month>=2){
			if(month<10)
				r = year + "-0" + (month - 1) + "-" + iStartDay;
			else
				r = year + "-" + (month - 1) + "-" + iStartDay;
		}else{
			r = (year-1) + "-" + "12" + "-" + iStartDay;
		}
	}else{	//当天小于21日
		//当月大于等于2月
		if(month>=3){
			if(month-1<10)
				r = year + "-0" + (month-2) + "-" + iStartDay;
			else
				r = year + "-" + (month-2) + "-" + iStartDay;
		}else{//当月等于1月
			if(month==1) r = (year-1) + "-" + "11" + "-" + iStartDay;
			else r = (year-1) + "-" + "12" + "-" + iStartDay;
		}
	}
	return r;
}
function getStatsEndDay2(iStartDay){
	var today = new Date();
	var day=today.getDate();
	day = day - 10;
	today.setDate(day);
	var month=today.getMonth() + 1;
	day=today.getDate();
	if(month<10) sMonth="0" + month;
	else sMonth = month;
	if((day<iStartDay-1&&day>10)||day>iStartDay) day = iStartDay-1;
	else day = day +10;
	if(day<10) sDay="0" + day;
	else sDay = day;
	r = today.getFullYear() + "-" + sMonth + "-" + sDay;
	return r;
}


//固定表头的滚动条占位计算方法
function echo() {
	var a, t = document.getElementById("scrollbar");
	t.wrap = 'off';
	a = t.offsetHeight;
	t.wrap = 'soft';
	a -= t.offsetHeight;
	a ? a : 0;
	return a
}

//强制把大写转换成小写
function fCheckInputLow(){
	if(event.keyCode>=65 && event.keyCode<=90)
		event.keyCode=event.keyCode+32;
}
//检测对象项是否已输入值	by wengyf
function isEmpty(obj,msg){
	if(document.all[obj].value.length<1){
		if(msg.length>1)
			alert(msg)
		else
			alert('请输入必填项！');
		document.all[obj].focus();
		return true;
	}else{
		return false;
	}
}
//打开详细页	by wengyf
function winopen(url,winname,width,height){
	var w=640;
	var h=480;
	if(width!=null&&width!=""&&typeof(width)!="undefined")
		w=width;
	if(height!=null&&height!=""&&typeof(height)!="undefined")
		h=height;
	var windowheight=screen.height;
	var windowwidth =screen.width;
	windowheight=(windowheight-h)/2;
	windowwidth=(windowwidth-w)/2;
	subwinname = window.open(url,winname,"resizable=no,scrollbars=yes,status=no,toolbar=no,menubar=no,location=no,directories=no,width="+w+",height="+h+",top="+windowheight+",left="+windowwidth);
	return subwinname;
}
//截字显示	by wengyf
function wordshow(str,len){
	var t_Str = "";
	if(len<str.length){
		t_Str="<span title = \""+str+"\" style=\"cursor:hand;\">";
		t_Str+=str.substr(0,len)+"..";
		t_Str+="</span>"
	}else{
		t_Str = str;
	}
	document.write(t_Str);
}
//显示年月日	by wengyf
function showdate(str){
	var t_Str = "";
	if(str.length>0){
		t_Str=str.substr(0,10);	
	}
	document.write(t_Str);
}
function getshowdate(str){
	var t_Str = "";
	if(str.length>0){
		t_Str=str.substr(0,10);	
	}
	return t_Str;
}
function showalldate(str){
	var t_Str = "";
	if(str.length==10){
		t_Str=str+" 00:00:00";
	}
	if(str.length>19){
		t_Str=str.substr(0,19);	
	}
	document.write(t_Str);
}
function getshowalldate(str){
	var t_Str = "";
	if(str.length==10){
		t_Str=str+" 00:00:00";
	}
	if(str.length>19){
		t_Str=str.substr(0,19);	
	}
	return t_Str;
}
//反射OBJECT中的CHECK属性和WARN属性	by wengyf
function check(oForm){
	var els = oForm.elements;
	for(var i=0;i<els.length;i++){
		if(els[i].check){
			var sReg = els[i].check;
			var sVal = GetValue(els[i]);
			var reg = new RegExp(sReg,"i");
			if(!reg.test(sVal)){
				alert(els[i].warn);
				GoBack(els[i]) 
				return true;
			}
		}
	}
	return false;
}
function GetValue(el){
	var sType = el.type;
	switch(sType){
		case "text":
		case "hidden":
		case "password":
		case "file":
		case "textarea": return el.value;
		case "checkbox":
		case "radio": return GetValueChoose(el);
		case "select-one":
		case "select-multiple": return GetValueSel(el);
	}
}
function GetValueChoose(el){
	var sValue = "";
	var tmpels = document.getElementsByName(el.name);
	for(var i=0;i<tmpels.length;i++){
		if(tmpels[i].checked){
			sValue += "0";
		}
	}
	return sValue;
}
function GetValueSel(el){
	var sValue = "";
	for(var i=0;i<el.options.length;i++){
		if(el.options[i].selected && el.options[i].value!=""){
			sValue += "0";
		}
	}
	return sValue;
}
function GoBack(el){
	var sType = el.type;
	switch(sType){
		case "text":
		case "hidden":
		case "password":
		case "file":
		case "textarea": el.focus();var rng = el.createTextRange(); rng.collapse(false); rng.select();
		case "checkbox":
		case "radio": var els = document.getElementsByName(el.name);els[0].focus();
		case "select-one":
		case "select-multiple":el.focus();
	}
}
//取得当前时间
function getNow(){
	var r;
	var d=new Date();
	r=d.getYear()+"-";
	if(d.getMonth()>=9)
		r+=(d.getMonth()+1)+"-";
	else
		r+="0"+(d.getMonth()+1)+"-";	
	if(d.getDate()<10)
		r+="0"+(d.getDate());
	else
		r+=(d.getDate());
//	r=d.getYear()+"-"+(d.getMonth()+1)+"-"+d.getDate()+" "+d.getHours()+":"+d.getMinutes()+":"+d.getSeconds();
	return r;
}
//取得上月时间
function getLastMonth(){
	var today = new Date(); 
	var x=today.getMonth(); 
	x=x-1;
	today.setMonth(x); 
	var month=today.getMonth()+1; 
	var day=today.getDate(); 
	if(month<10) sMonth="0"+month; 
	else sMonth = month; 
	if(day<10) sDay="0"+day; 
	else sDay = day; 
	r=today.getFullYear()+"-"+sMonth+"-"+sDay; 
	return r;
}
//取得去年时间
function getLastYear(){
	var today = new Date(); 
	var x=today.getYear(); 
	x=x-1;
	today.setYear(x); 
	var month=today.getMonth()+1; 
	var day=today.getDate(); 
	if(month<10) sMonth="0"+month; 
	else sMonth = month; 
	if(day<10) sDay="0"+day; 
	else sDay = day; 
	r=today.getFullYear()+"-"+sMonth+"-"+sDay; 
	return r;
}
//校验是否符合该字符规则
function invalidLetter(msg,str,LetterReg){
	var i,c;
	for (i=0;i<str.length;i++) {
		c=str.charAt(i);
		if(LetterReg.indexOf(c)==-1) {
			alert(msg+"含有非法字符‘"+c+"’!");
			return false;
		}
	}
	return true;
}
//校验号牌号码
function checkHPHM(hpzl,hphm){
  var h=hphm.toUpperCase();
	var jp="军海空北南沈济兰成广";
	if(hpzl.length<1||hphm.length<1){
		return false;
	}
	if(hphm.length<6){
		alert("请输入完整的号牌号码！");
		return false;
	}
/*
	if(hpzl=="31"){
		h=hphm.substr(2,hphm.length-2);
	}else if(hpzl=="41"||hpzl=="42"||hpzl=="43"||hpzl=="99"){
		h=h;
	}else{
		h=hphm.substr(1,hphm.length-1);
	}
*/
  if(!invalidLetter("号牌号码",h,"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ")){
    return false;
  }
	if((hpzl=="04"||hpzl=="10"||hpzl=="15"||hpzl=="16"||hpzl=="17"||hpzl=="18"||hpzl=="19"||hpzl=="23"||hpzl=="24"||hpzl=="09")&&h.length!=5){
		alert("号牌号码长度必须为5位！");
		return false;
	}else if((hpzl=="12"||hpzl=="13"||hpzl=="14"||hpzl=="20"||hpzl=="21"||hpzl=="22"||hpzl=="01"||hpzl=="02"||hpzl=="03"||hpzl=="05"||hpzl=="06"||hpzl=="07"||hpzl=="08"||hpzl=="11")&&h.length!=6){
		alert("号牌号码长度必须为6位！")
		return false;
	}else if(hpzl=="31"&&hphm.toUpperCase().substr(0,2)!="WJ"){
		alert("错误的武警号牌！")		
		return false;
	}else if(hpzl=="32"&&jp.indexOf(hphm.substr(0,1))==-1){
		alert("错误的军牌！");
		return false;
	}
	return true;
}
function notNull(obj,vMc){
var v;
v=obj.value;
v=v.trim();

if (v.length==0)
{
	alert(vMc+"输入值为空！");
	obj.focus();
	return 0;
}
obj.value=v;
return 1;
}
function Arabia_to_Chinese(Num){
    if(Num=="null")
    {Num="0";}
   for(i=Num.length-1;i>=0;i--)
   {
    Num = Num.replace(",","")//替换tomoney()中的“,”
    Num = Num.replace(" ","")//替换tomoney()中的空格
   }
   Num = Num.replace("￥","")//替换掉可能出现的￥字符
   if(isNaN(Num)) { //验证输入的字符是否为数字
    alert("请检查小写金额是否正确");
    return;
   }
   //---字符处理完毕，开始转换，转换采用前后两部分分别转换---//
   part = String(Num).split(".");
   newchar = "";
   //小数点前进行转化
   for(i=part[0].length-1;i>=0;i--){
   if(part[0].length > 10){ alert("位数过大，无法计算");return "";}//若数量超过拾亿单位，提示
    tmpnewchar = ""
    perchar = part[0].charAt(i);
    switch(perchar){
    case "0": tmpnewchar="零" + tmpnewchar ;break;
    case "1": tmpnewchar="壹" + tmpnewchar ;break;
    case "2": tmpnewchar="贰" + tmpnewchar ;break;

   case "3": tmpnewchar="叁" + tmpnewchar ;break;
    case "4": tmpnewchar="肆" + tmpnewchar ;break;
    case "5": tmpnewchar="伍" + tmpnewchar ;break;
    case "6": tmpnewchar="陆" + tmpnewchar ;break;
    case "7": tmpnewchar="柒" + tmpnewchar ;break;
    case "8": tmpnewchar="捌" + tmpnewchar ;break;
    case "9": tmpnewchar="玖" + tmpnewchar ;break;
    }
    switch(part[0].length-i-1){
    case 0: tmpnewchar = tmpnewchar +"元" ;break;
    case 1: if(perchar!=0)tmpnewchar= tmpnewchar +"拾" ;break;
    case 2: if(perchar!=0)tmpnewchar= tmpnewchar +"佰" ;break;
    case 3: if(perchar!=0)tmpnewchar= tmpnewchar +"仟" ;break;
    case 4: tmpnewchar= tmpnewchar +"万" ;break;
    case 5: if(perchar!=0)tmpnewchar= tmpnewchar +"拾" ;break;
    case 6: if(perchar!=0)tmpnewchar= tmpnewchar +"佰" ;break;
    case 7: if(perchar!=0)tmpnewchar= tmpnewchar +"仟" ;break;
    case 8: tmpnewchar= tmpnewchar +"亿" ;break;
    case 9: tmpnewchar= tmpnewchar +"拾" ;break;
    }
    newchar = tmpnewchar + newchar;
   }
   //小数点之后进行转化
   if(Num.indexOf(".")!=-1){
   if(part[1].length > 2) {
    alert("小数点之后只能保留两位,系统将自动截段");
    part[1] = part[1].substr(0,2)
    }
   for(i=0;i<part[1].length;i++){
    tmpnewchar = ""
    perchar = part[1].charAt(i)
    switch(perchar){
    case "0": tmpnewchar="零" + tmpnewchar ;break;
    case "1": tmpnewchar="壹" + tmpnewchar ;break;
    case "2": tmpnewchar="贰" + tmpnewchar ;break;
    case "3": tmpnewchar="叁" + tmpnewchar ;break;
    case "4": tmpnewchar="肆" + tmpnewchar ;break;
  case "5": tmpnewchar="伍" + tmpnewchar ;break;
    case "6": tmpnewchar="陆" + tmpnewchar ;break;
    case "7": tmpnewchar="柒" + tmpnewchar ;break;
    case "8": tmpnewchar="捌" + tmpnewchar ;break;
    case "9": tmpnewchar="玖" + tmpnewchar ;break;
    }
    if(i==0)tmpnewchar =tmpnewchar + "角";
    if(i==1)tmpnewchar = tmpnewchar + "分";
    newchar = newchar + tmpnewchar;
   }
   }
   //替换所有无用汉字
   while(newchar.search("零零") != -1)
    newchar = newchar.replace("零零", "零");
   newchar = newchar.replace("零亿", "亿");
   newchar = newchar.replace("亿万", "亿");
   newchar = newchar.replace("零万", "万");
   newchar = newchar.replace("零元", "元");
   newchar = newchar.replace("零角", "");
   newchar = newchar.replace("零分", "");
   newchar = newchar.replace("元","");

   if (newchar.charAt(newchar.length-1) == "元" || newchar.charAt(newchar.length-1) == "角")
    newchar = newchar+"整"
   return newchar;
  }

  //光标移动至最后
function movelast()
{
  var e = event.srcElement;
  var r =e.createTextRange();
  r.moveStart('character',e.value.length);
  r.collapse(true);
  r.select();
}
//聚焦到下一个控件
function goNext()
{
  if (event.keyCode==8)
  {
    if(event.srcElement.type=="text"||event.srcElement.type=="password")
    {
    }
    else
    {
      event.keyCode=0;
      event.returnValue=false;
    }
  }
  else
  {
    if (event.srcElement.name!="Submit")
    {
      if (event.keyCode==13)
      event.keyCode=9;
    }
  }
}
function mouse_over(obj)
{
  obj.style.backgroundColor="#ffff33";
}

function mouse_out(obj)
{
  obj.style.backgroundColor="";
}