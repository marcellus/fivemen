String.prototype.ReplaceAll = stringReplaceAll;

function  stringReplaceAll(AFindText,ARepText){
  raRegExp = new RegExp(AFindText,"g");
  return this.replace(raRegExp,ARepText)
}

//��õ�ǰ����+i��
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

//�ر��Ӵ���
function closesubwin(){
  if(subwinname!=null&&isclosesubwin==1){
    subwinname.close();
  }
}
//�رմ���
function closewin(){
	window.close();
}
  
//-------------------------------
//  ��������isNum(i_field,i_value)
//  ���ܽ��ܣ���������ַ����Ƿ�Ϊ����
//  ����˵�������������Ķ�Ӧֵ
//  ����ֵ  ��1-������,0-������
//-------------------------------
function isNum(i_field,i_value)
{
    re=new RegExp("[^0-9]");
    var s;
    if(s=i_value.match(re))
     {
        alertDialog("'"+i_field+"' �к��зǷ��ַ� '"+s+"' ��");
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
		alert("���ڸ�ʽ����,\nҪ��Ϊyyyy-mm-dd��");
		riqi(obj);
		return 0;
	}
/*
	if (!(thedate.value.length==10)){    
		alert("���ڸ�ʽ����,\nҪ��Ϊyyyy-mm-dd��");
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
		alert("���ڸ�ʽ����,\nҪ��Ϊyyyy-mm-dd��");
		riqi(obj);
		return 0;
	}
	alert("���ڸ�ʽ����,\nҪ��Ϊyyyy-mm-dd��");
	riqi(obj);
	return 0;
}

//�ж����֤�ŵĺϷ���
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
            alertDialog("���֤У�����------ ĩλӦ��:"+ls_check+" ʵ��:"+hm.substr(17,1),2);
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
    if (notNull(zjhmObj,"���֤��") == 0) {
      return 0;
    }
    if (! (zjhm.length == 15 || zjhm.length == 18)) {
      alert("���֤���Ȳ���,���飡");
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
      alert("�����ֵ�к��зǷ��ַ�'" + s + "'���飡");
      zjhmObj.focus();
      // zjhmObj.focus();
      return 0;
    }
    //ȡ��������
    if (zjhm.length == 15) {
      birthday = "19" + zjhm.substr(6, 6);
    }
    else {
      re = new RegExp("[^0-9A-Z]");
      if (s = zjhm2.match(re)) { //18λ���֤��ĩλҪ�����ֻ��ַ�
        alert("�����ֵ�к��зǷ��ַ�'" + s + "'���飡");
        zjhmObj.focus();
        //zjhmObj.focus();
        return 0;
      }
      birthday = zjhm.substr(6, 8);
    }
    birthday = birthday.substr(0, 4) + "-" + birthday.substr(4, 2) + "-" +
        birthday.substr(6, 2)
        //alert("birthday"+birthday)

        if (newisDate("���֤�����������", birthday) == 0) { //������ڵĺϷ���
        zjhmObj.focus();
      return 0;
    }

    //var nl=cal_years(birthday);//������
    /*
             if (nl-0<18 || nl>70)
                {
                 alert("��������Ҫ�� 18--70 ,��ǰ "+nl+" ��");
                return 0;
               }*/
    if (zjhm.length == 18) {
      return (newsfzCheck(zjhm)); //��18λ�������֤����ĩλУ��
    }
    // else{
    //  zjhmObj.value=id15to18(zjhm);
    // }

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
            alert("֤��У�����------ ĩλӦ��:"+ls_check+" ʵ��:"+hm.substr(17,1));
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

//��ʾ������Ϣ
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
//�ı�form��״̬ 0-��д 1-�༭ֻ�� disabled 2-�鿴ֻ��readonly
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
      c = m_Value.charAt(i); //�ַ���s�е��ַ�
      if (strLetter.indexOf(c) == -1) {
        alertDialog(m_fields + "���зǷ��ַ���" + c + "��!",2);
        obj.focus();
        return false;
      }
    }
    return true;
}
//�滻A~A~Ϊ'\n'
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
//ȡ�ַ������ֽڳ���
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
   return(newDay);                                // �������ڡ�
}

function getNyr(date)
{
  if(date.length==10)//����2005-02-01
  {
    return date.substring(0,4)+"��"+date.substring(5,7)+"��"+date.substring(8,10)+"��";
  }else if(date.length==16)//����2005-02-01 01:01
  {
    return date.substring(0,4)+"��"+date.substring(5,7)+"��"+date.substring(8,10)+"��"+date.substring(11,13)+"ʱ"+date.substring(14,16)+"��";
  }else if(date.length==18)//18λ���֤��
  {
    return date.substring(6,10)+"��"+date.substring(10,12)+"��"+date.substring(12,14)+"��";
  }else if(date.length==15)//15λ���֤��
  {
    return "19"+date.substring(6,8)+"��"+date.substring(8,10)+"��"+date.substring(10,12)+"��";
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

//���������÷���
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
	}else{	//����С��21��
		//���´��ڵ���2��
		if(month>=3){
			if(month-1<10)
				r = year + "-0" + (month-2) + "-" + iStartDay;
			else
				r = year + "-" + (month-2) + "-" + iStartDay;
		}else{//���µ���1��
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


//�̶���ͷ�Ĺ�����ռλ���㷽��
function echo() {
	var a, t = document.getElementById("scrollbar");
	t.wrap = 'off';
	a = t.offsetHeight;
	t.wrap = 'soft';
	a -= t.offsetHeight;
	a ? a : 0;
	return a
}

//ǿ�ưѴ�дת����Сд
function fCheckInputLow(){
	if(event.keyCode>=65 && event.keyCode<=90)
		event.keyCode=event.keyCode+32;
}
//���������Ƿ�������ֵ	by wengyf
function isEmpty(obj,msg){
	if(document.all[obj].value.length<1){
		if(msg.length>1)
			alert(msg)
		else
			alert('����������');
		document.all[obj].focus();
		return true;
	}else{
		return false;
	}
}
//����ϸҳ	by wengyf
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
//������ʾ	by wengyf
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
//��ʾ������	by wengyf
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
//����OBJECT�е�CHECK���Ժ�WARN����	by wengyf
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
//ȡ�õ�ǰʱ��
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
//ȡ������ʱ��
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
//ȡ��ȥ��ʱ��
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
//У���Ƿ���ϸ��ַ�����
function invalidLetter(msg,str,LetterReg){
	var i,c;
	for (i=0;i<str.length;i++) {
		c=str.charAt(i);
		if(LetterReg.indexOf(c)==-1) {
			alert(msg+"���зǷ��ַ���"+c+"��!");
			return false;
		}
	}
	return true;
}
//У����ƺ���
function checkHPHM(hpzl,hphm){
  var h=hphm.toUpperCase();
	var jp="�����ձ���������ɹ�";
	if(hpzl.length<1||hphm.length<1){
		return false;
	}
	if(hphm.length<6){
		alert("�����������ĺ��ƺ��룡");
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
  if(!invalidLetter("���ƺ���",h,"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ")){
    return false;
  }
	if((hpzl=="04"||hpzl=="10"||hpzl=="15"||hpzl=="16"||hpzl=="17"||hpzl=="18"||hpzl=="19"||hpzl=="23"||hpzl=="24"||hpzl=="09")&&h.length!=5){
		alert("���ƺ��볤�ȱ���Ϊ5λ��");
		return false;
	}else if((hpzl=="12"||hpzl=="13"||hpzl=="14"||hpzl=="20"||hpzl=="21"||hpzl=="22"||hpzl=="01"||hpzl=="02"||hpzl=="03"||hpzl=="05"||hpzl=="06"||hpzl=="07"||hpzl=="08"||hpzl=="11")&&h.length!=6){
		alert("���ƺ��볤�ȱ���Ϊ6λ��")
		return false;
	}else if(hpzl=="31"&&hphm.toUpperCase().substr(0,2)!="WJ"){
		alert("������侯���ƣ�")		
		return false;
	}else if(hpzl=="32"&&jp.indexOf(hphm.substr(0,1))==-1){
		alert("����ľ��ƣ�");
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
	alert(vMc+"����ֵΪ�գ�");
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
    Num = Num.replace(",","")//�滻tomoney()�еġ�,��
    Num = Num.replace(" ","")//�滻tomoney()�еĿո�
   }
   Num = Num.replace("��","")//�滻�����ܳ��ֵģ��ַ�
   if(isNaN(Num)) { //��֤������ַ��Ƿ�Ϊ����
    alert("����Сд����Ƿ���ȷ");
    return;
   }
   //---�ַ�������ϣ���ʼת����ת������ǰ�������ֱַ�ת��---//
   part = String(Num).split(".");
   newchar = "";
   //С����ǰ����ת��
   for(i=part[0].length-1;i>=0;i--){
   if(part[0].length > 10){ alert("λ�������޷�����");return "";}//����������ʰ�ڵ�λ����ʾ
    tmpnewchar = ""
    perchar = part[0].charAt(i);
    switch(perchar){
    case "0": tmpnewchar="��" + tmpnewchar ;break;
    case "1": tmpnewchar="Ҽ" + tmpnewchar ;break;
    case "2": tmpnewchar="��" + tmpnewchar ;break;

   case "3": tmpnewchar="��" + tmpnewchar ;break;
    case "4": tmpnewchar="��" + tmpnewchar ;break;
    case "5": tmpnewchar="��" + tmpnewchar ;break;
    case "6": tmpnewchar="½" + tmpnewchar ;break;
    case "7": tmpnewchar="��" + tmpnewchar ;break;
    case "8": tmpnewchar="��" + tmpnewchar ;break;
    case "9": tmpnewchar="��" + tmpnewchar ;break;
    }
    switch(part[0].length-i-1){
    case 0: tmpnewchar = tmpnewchar +"Ԫ" ;break;
    case 1: if(perchar!=0)tmpnewchar= tmpnewchar +"ʰ" ;break;
    case 2: if(perchar!=0)tmpnewchar= tmpnewchar +"��" ;break;
    case 3: if(perchar!=0)tmpnewchar= tmpnewchar +"Ǫ" ;break;
    case 4: tmpnewchar= tmpnewchar +"��" ;break;
    case 5: if(perchar!=0)tmpnewchar= tmpnewchar +"ʰ" ;break;
    case 6: if(perchar!=0)tmpnewchar= tmpnewchar +"��" ;break;
    case 7: if(perchar!=0)tmpnewchar= tmpnewchar +"Ǫ" ;break;
    case 8: tmpnewchar= tmpnewchar +"��" ;break;
    case 9: tmpnewchar= tmpnewchar +"ʰ" ;break;
    }
    newchar = tmpnewchar + newchar;
   }
   //С����֮�����ת��
   if(Num.indexOf(".")!=-1){
   if(part[1].length > 2) {
    alert("С����֮��ֻ�ܱ�����λ,ϵͳ���Զ��ض�");
    part[1] = part[1].substr(0,2)
    }
   for(i=0;i<part[1].length;i++){
    tmpnewchar = ""
    perchar = part[1].charAt(i)
    switch(perchar){
    case "0": tmpnewchar="��" + tmpnewchar ;break;
    case "1": tmpnewchar="Ҽ" + tmpnewchar ;break;
    case "2": tmpnewchar="��" + tmpnewchar ;break;
    case "3": tmpnewchar="��" + tmpnewchar ;break;
    case "4": tmpnewchar="��" + tmpnewchar ;break;
  case "5": tmpnewchar="��" + tmpnewchar ;break;
    case "6": tmpnewchar="½" + tmpnewchar ;break;
    case "7": tmpnewchar="��" + tmpnewchar ;break;
    case "8": tmpnewchar="��" + tmpnewchar ;break;
    case "9": tmpnewchar="��" + tmpnewchar ;break;
    }
    if(i==0)tmpnewchar =tmpnewchar + "��";
    if(i==1)tmpnewchar = tmpnewchar + "��";
    newchar = newchar + tmpnewchar;
   }
   }
   //�滻�������ú���
   while(newchar.search("����") != -1)
    newchar = newchar.replace("����", "��");
   newchar = newchar.replace("����", "��");
   newchar = newchar.replace("����", "��");
   newchar = newchar.replace("����", "��");
   newchar = newchar.replace("��Ԫ", "Ԫ");
   newchar = newchar.replace("���", "");
   newchar = newchar.replace("���", "");
   newchar = newchar.replace("Ԫ","");

   if (newchar.charAt(newchar.length-1) == "Ԫ" || newchar.charAt(newchar.length-1) == "��")
    newchar = newchar+"��"
   return newchar;
  }

  //����ƶ������
function movelast()
{
  var e = event.srcElement;
  var r =e.createTextRange();
  r.moveStart('character',e.value.length);
  r.collapse(true);
  r.select();
}
//�۽�����һ���ؼ�
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