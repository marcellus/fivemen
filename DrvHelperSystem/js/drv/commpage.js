

function checkNull(obj,vMc){
var v;
v=obj.value;
v=v.trim();

if (v.length==0)
{
	alert(vMc+"����ֵ����Ϊ�գ�");
	return false;
}
obj.value=v;
return true;
}
//��⵵�����
function checkDabh(obj){
	obj.value=obj.value.trim();
	if(obj.value.length==0){
		alert("������Ų���Ϊ�գ�")
		obj.focus();
		return 0;
	}
	if(obj.value!="��"){
		if(checkNumber(obj,"�������")==false){
			obj.focus();
			return 0;
		}
		if(obj.value.length!=10&&obj.value.length!=12){
			obj.focus();
			alert("������Ų�Ϊ10λ��12λ��");
			return 0;
		}
	}
	return 1;
}
function checkJszh(obj,vZjmc){
obj.value=obj.value.trim();
if(checkNull(obj,"֤������")==false){
	obj.focus();
	return 0;
}
if(obj.value!="��"){
	if(obj.value.length<6||obj.value.length>18){
		alert("֤�����볤�Ȳ�����");
		obj.focus();
		return 0;
	}else{
		if(obj.value.length==15){
			obj.value=id15to18(obj.value);
		}
		if(obj.value.length==18){
			if(check_jszh(obj.value)==0){
				obj.focus();
				return 0;
			}
		}
	}
}
return 1;
}

//����ʻ֤���Ƿ���ȷ
function check_jszh(zjhm)
{
  var birthday="";
  var zjhm1="";
  var zjhm2="";
  var s="";
  var zjmc="";
  var zjhmt="";
  
  zjhmt=zjhm.substr(0,1);
  if(zjhmt=="C"||zjhmt=="D"||zjhmt=="E"||zjhmt=="F"||zjhmt=="G"){
	  zjmc=zjhmt;
  }else{
	  zjmc="A";
  }
  
  if(zjmc=="A")   //���֤����
   {
       if(!(zjhm.length==15 || zjhm.length==18) )
	     {
	       alert("֤�����Ȳ���,���飡") ;
           return 0;
	     }
        zjhm1=zjhm;
        if (zjhm.length==18)
            {
                zjhm1=zjhm.substr(0,17)	;
                zjhm2=zjhm.substr(17,1);
            }
        re=new RegExp("[^0-9]");
	 	if(s=zjhm1.match(re))
	    	{
	        alert("�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
	        return 0;
             }
        //ȡ��������
        if(zjhm.length==15 )
            {
               birthday="19"+zjhm.substr(6,6);
            }
         else
            {
			   re=new RegExp("[^0-9A-Z]");
               if(s=zjhm2.match(re))     //18λ���֤��ĩλҪ�����ֻ��ַ�
               {
                   alert("�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
                   return 0;
                }
                birthday=zjhm.substr(6,8);
            }
           birthday=birthday.substr(0,4)+"-"+birthday.substr(4,2)+"-"+birthday.substr(6,2)
          //alert("birthday"+birthday)

          if(newisDate("֤������",birthday)==0)  //������ڵĺϷ���
          {
             return 0;
          }
		 
         if(zjhm.length==18 )
         {
          	return(sfzCheck(zjhm));  //��18λ�������֤����ĩλУ��
         }
       }
   return 1;
   }
   
//��������Ƿ���ȷ
function newisDate(i_field,thedate)
{if (thedate.length==8)
  {
  	thedate=thedate.substr(0,4)+"-"+thedate.substr(4,2)+"-"+thedate.substr(6,2);
  }
    var reg = /^(\d{1,4})(-)(\d{1,2})\2(\d{1,2})$/;
    var r = thedate.match(reg);

     if (r==null)
    {
       alert("'"+i_field+"' ���Ƿ��ַ���");
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
     alert("'"+i_field+"'���ڸ�ʽ���ԣ�");
     return 0;
}   
//������֤��
function sfzCheck(hm)
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
            alert("֤��У�����------ ĩλӦ��:"+ls_check+" ʵ��:"+hm.substr(17,1));
            return 0;
     }
return 1
}


//У�鴫����ı����ı��Ƿ�Ϊ��ֵ����
function checkNumber(obj,vMc){
var v;
v=obj.value;
v=v.trim();
re=new RegExp("[^0-9]");
if(s=v.match(re))
{
alert(vMc+"�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
return false;
}
obj.value=v;
return true;
}


//У�鴫����ı����ı��Ƿ�Ϊ��ֵ����
function checkDouble(obj,vMc){
var v;
v=obj.value;
v=v.trim();
re=new RegExp("[^0-9]");
if(s=v.match(re)){
	if(s!="."){
		alert(vMc+"�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
		return false;
	}
}
obj.value=v;
return true;
}

String.prototype.trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
//У�鴫����ı����ı��Ƿ�Ϊ��ֵ���ͳ����Ƿ����Ҫ��
function checkCharAndLength(obj,vMc,vLength){
  var v;
  v=obj.value;
  v=v.trim();
  if (v.length!=vLength){
    alert("�����"+vMc+"�ĳ��Ȳ���"+vLength+"λ��");
    return false;
  }
  re=new RegExp("[^0-9A-Za-z]");
  if(s=v.match(re)){
    alert(vMc+"�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
    return false;
  }
  obj.value=v;
  return true;
}
//У�鴫����ı����ı��Ƿ�Ϊ��ֵ���ͳ����Ƿ����Ҫ��
function checkNumberAndLength(obj,vMc,vLength){
	var v;
	v=obj.value;
	v=v.trim();
	if (v.length!=vLength)
	{
		alert("�����"+vMc+"�ĳ��Ȳ���"+vLength+"λ��");
		 obj.focus();
		return false;
	}
	re=new RegExp("[^0-9]");
	if(s=v.match(re))
	{
	alert(vMc+"�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
	obj.focus();
	return false;
	}
	obj.value=v;
	return true;
}

//��ȡʱ��
function riqi(rq){
  gfPop.fPopCalendar(document.all[rq]);
  return false;
}

function riqi_fy(obj){
	  gfPop.fPopCalendar(obj);
	  return false;
}

function riqitime(rq){
  if(document.all[rq].readOnly == false){
	  gfPoptime.fPopCalendar(document.all[rq]);
	  return false;  
  }
}
function formatwfsj(obj){
	if(obj.value.length==12){
	obj.value=obj.value.substring(0,4)+"-"+obj.value.substring(4,6)+"-"+obj.value.substring(6,8)+" "+obj.value.substring(8,10)+":"+obj.value.substring(10,12);
	}
}
function changewfsj(lx){
  if(lx==1){
  	if(document.all["clsj"].value==""){
  		document.all["clsj"].value = document.all["wfsj"].value;
  	}
  }
}
function get_fzjg(vBdfzjg,lx){	    
	document.all["fzjg"].value=document.all["pro"].value+document.all["az"].value;
	if(lx=="4"){
		document.all["hphm"].value = document.all["fzjg"].value;
	}
	if(vBdfzjg==document.all["fzjg"].value){
	   if(lx==undefined)
		document.all["hqydinfo"].disabled=true;
	   else if(lx=="4")
  	    document.all["hqjdcinfo"].disabled=true;
	}else{
		if(lx==undefined){
			if(document.all["ryfl_c"].value=="4")
				document.all["hqydinfo"].disabled=false;
			else
				document.all["hqydinfo"].disabled=true;		
		}else if(lx=="4"){
			if(document.all["clfl"].value=="3")
				document.all["hqjdcinfo"].disabled=false;
			else
				document.all["hqjdcinfo"].disabled=true;		
		}
	}	
}

//��ȡ��֤����
function get_fzjg_new(vBdfzjg){
	document.all["fzjg"].value=document.all["pro"].value+document.all["az"].value;
	if(vBdfzjg==document.all["fzjg"].value){
		document.all["hqjsrinfo"].disabled=true;
	}else{
		document.all["hqjsrinfo"].disabled=false;
	}
}


function setSfzmhm(){
	if(document.all["zjmc"].value!="A"){
		if(document.all["jszh"].value.length<2){
			document.all["jszh"].value=document.all["zjmc"].value;
		}
	}else{
		if(document.all["jszh"].value.length<2){
			document.all["jszh"].value="";
		}
	}
}

function parseText(sValue,sReg){
	var iPos = sValue.indexOf("<" + sReg + ">");
	var iPos1 = sValue.indexOf("</" + sReg + ">");
	var result = sValue.substring(iPos + sReg.length + 2,iPos1);
	return result;
}

function change_zjmc(value){
	if(value!="A"){
		document.all["jszh"].value = value;
	}else{
		document.all["jszh"].value = "";
	}
}


function transCase(fieldobj){
	fieldobj.value=fieldobj.value.toUpperCase();
}

//���֤15λת18λ
function  id15to18(zjhm) {
    zjhm = zjhm.substr(0, 6) + "19" + zjhm.substr(6);
	zjhm=zjhm+getmwsfzh(zjhm);
    return zjhm;
  }
  
  function getmwsfzh(hm)
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
     {
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
	return ls_check;
}
//-------------------------------
//  ��������DateAddMonth(strDate,iMonths)
//  ���ܽ��ܣ�������ڼ���iMonths�����������
//  ����˵����strDate ����
//  ����ֵ  ���޷���ֵ
//-------------------------------
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
   return(newDay);                                // �������ڡ�
}

  function bodyKeyDown(){
    	if (event.keyCode==13) event.keyCode=9;
  }  
  function openwin(url,winname,scrollbars){
		var windowheight=screen.height;
		var windowwidth =screen.width;
		var subwinname;
		windowheight=(windowheight-620)/2;
		windowwidth=(windowwidth-800)/2;

		if(scrollbars==null)
		  subwinname = window.open(url,winname,"resizable=yes,scrollbars=yes,status=yes,toolbar=no,menubar=no,location=no,directories=no,width=800,height=600,top="+windowheight+",left="+windowwidth);
		else
		  subwinname = window.open(url,winname,"resizable=yes,scrollbars=yes,status=yes,toolbar=no,menubar=no,location=no,directories=no,width=800,height=600,top="+windowheight+",left="+windowwidth);

		return subwinname;
	}
	function LPad(ContentToSize,PadLength,PadChar)
	 {
	    var PaddedString=ContentToSize.toString();
	    for(i=ContentToSize.length+1;i<=PadLength;i++)
	    {
	        PaddedString=PadChar+PaddedString;
	    }
	    return PaddedString;
	 }
	 
	 function RPad(ContentToSize,PadLength,PadChar)
	 {
	    var PaddedString=ContentToSize.toString();
	    for(i=ContentToSize.length+1;i<=PadLength;i++)
	    {
	        PaddedString=PaddedString+PadChar;
	    }
	    return PaddedString;
	 }
	 
	 function falterqzcslx(){
	 	var maxqzcslx="";
	 	if(document.all["cqzcslx"]){
		 	for(var i = 1; i <=5; i++){
		 		if(document.all["wfxw"+i]){
		 			maxqzcslx=maxqzcslx+document.all["qzcslx"+i].value;
		 		}else{
		 			break;
		 		}
		 	}
		 	for(i=0;i<document.all["cqzcslx"].length;i++){
		 		document.all["cqzcslx"][i].disabled=false;
		 		if(maxqzcslx.indexOf(document.all["cqzcslx"][i].value)>=0){
		 			document.all["cqzcslx"][i].disabled=false;
		 		}else{
		 			document.all["cqzcslx"][i].checked=false;
		 			document.all["cqzcslx"][i].disabled=true;
		 		}
		 	}
		 }
	 	
	 }
  function getWindowlocation(sUrl){
	var sTmp = sUrl;
	if(sTmp.substr(sTmp.length - 1,1)=="#"){
		sTmp = sTmp.substr(0,sTmp.length - 1);
	}
	return sTmp;
}
  function checkjpg(sFilename){
    var sExt;
    if(sFilename==""){
    	return 1;
    }
  	if(sFilename.length>=4){
  		sExt = sFilename.substr(sFilename.length - 4);
  		sExt = sExt.toLowerCase();
  		if(sExt==".jpg"){
  			return 1;
  		}else{
  			return 0;
  		}
  	}else{
  		return 0;
  	}
  }
  
  function changepageselvis(isVis){
  	for (i=0;i< document.all.tags("select").length; i++ )
	{
		if(isVis)
          document.all.tags("select")[i].style.visibility="visible";
        else
          document.all.tags("select")[i].style.visibility="hidden";
	}
  }
  
  function cReadonly(obj){
		if (obj.type=="text"){
			obj.readOnly=true;
			obj.className="text_nobord";
		}else{
			obj.className="text_nobord";
		}
	}

	function cEditable(obj){
		if (obj.type=="text"){
			obj.readOnly=false;
			obj.className="god1";
		}else{
			obj.className="god1";
		}
	}
	
	//-------------------------------
//  ��������
//  ���ܽ��ܣ����ڼ���
//  ����˵������
//  ����ֵ  ����
//-------------------------------
function rqaddyears(rq1,ns)
{
if (rq1.length==10){
y=parseInt(rq1.substring(0,4))+ns
m=parseInt(rq1.substring(5,7))
d=parseInt(rq1.substring(8,10))

}else if (rq1.length==8){
y=parseInt(rq1.substring(0,4))+ns
m=parseInt(rq1.substring(4,6))
d=parseInt(rq1.substring(6,8))
}else{
return "";
}
var str =y+rq1.substring(4,10);
if (m==2 && d==29){
str=y+rq1.substring(4,7)+"-28";
}
return str;
}

//-------------------------------
//��������changeDate(thedate)
//���ܽ��ܣ�����yyyymmddת����yyyy-mm-dd��ʽ
//����˵������������
//����ֵ  ��0-���ǣ�1--��
//-------------------------------

function changeDate(thedate)
{

if (thedate.length==8)
{
	thedate=thedate.substr(0,4)+"-"+thedate.substr(4,2)+"-"+thedate.substr(6,2);
}
return thedate;
}


//��ȡ���з�֤������Ϣ
function changepro(pro){
    var spath;
    spath=encodeURI(encodeURI("dagl.do?method=getcityfzjg&pro="+pro));
    send_request1(spath);  
    var fzjgxx=processRequest();
    if(fzjgxx!='exception'){
    	divcity.innerHTML = fzjgxx;
    }
}

var http_request = false;
function send_request1(url) {
	http_request = false;
	if(window.XMLHttpRequest) {
		http_request = new XMLHttpRequest();
		if (http_request.overrideMimeType) {
			http_request.overrideMimeType('text/xml');
		}
	}else if (window.ActiveXObject) {
		try {
			http_request = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) {
			try {
				http_request = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {}
		}
	}
	if (!http_request) {
		window.alert("���ܴ���XMLHttpRequest����ʵ��.");
		return false;
	}
	http_request.onreadystatechange = processRequest;
	http_request.open("GET", url + "&timestamp=" + getNowSec(0), false);
	http_request.send(null);
}

function processRequest() {
    if (http_request.readyState == 4) {
        if (http_request.status == 200) {
           return http_request.responseText;
        } else {
            return 'exception';
        }
    }
}