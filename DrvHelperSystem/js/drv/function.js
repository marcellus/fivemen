/*
  �ļ���: function.js
  ��  ��: ���õĹ��ܿ�
  ���ܿ�:

  ��  ��: ������ 2004��4��16��
	  ���� 2004.05.20
          �޼��� 2008.02.12
*/
//�ж��Ƿ��Ǳ��ص�ַ
function checkIsLocal(bddzxx,djzsxxdz)
{
    bddzxx = bddzxx.replace(/��/g,",");
    bddzarray = bddzxx.split(",");
    for (i = 0; i < bddzarray.length; i++)
    {
        if (djzsxxdz.indexOf(bddzarray[i]) >= 0)
        {
            return true;
        }
    }
    return false;
}
//��ʻ֤֤о���У��λ�ж�
function zxbhCheck(hm,obj)
{
  try
  {
  	var w=new Array();
  	var ll_sum;
  	var ll_i;
  	var ls_check;
  	w[0]=9;
  	w[1]=8;
  	w[2]=0;
  	w[3]=8;
  	w[4]=7;
  	w[5]=3;
  	w[6]=2;
  	w[7]=3;
  	w[8]=5;
  	w[9]=6;
  	w[10]=7;
  	w[11]=8;
  	w[12]=9;
  	ll_sum=0;
  	hm = hm.substr(0,2).replace(/4/g,"8") + hm.substr(2,1) + hm.substr(3).replace(/4/g,"8");

  	if (hm.length < 13)
  	{
  		alert("��ʻ֤֤о���¼��������˶ԣ�");
  		obj.focus();
  		return 0;
  	}
  	for (ll_i=0;ll_i<=12;ll_i++)
  	{
  		if (ll_i != 2)
  		{
  			if (hm.substr(ll_i,1) < "0" || hm.substr(ll_i,1) > "9")
  			{
  				alert("��ʻ֤֤о���¼��������˶ԣ�");
  				obj.focus();
  				return 0;
  			}
  			ll_sum=ll_sum+(hm.substr(ll_i,1)-0)*w[ll_i];
  		}
  		else
  		{
  			if ((hm.substr(ll_i,1) < "0" || hm.substr(ll_i,1) > "9") && hm.substr(ll_i,1) != "X")
  			{
  				alert("��ʻ֤֤о���¼��������˶ԣ�");
  				obj.focus();
  				return 0;
  			}
  		}
  	 }
     ll_sum=ll_sum % 11;
  	 if (ll_sum == 10) ls_check = "X";
  		else ls_check = ll_sum;
  
  	 if (hm.substr(2,1) != ls_check)
  	 {
	 	 alert("��ʻ֤֤о���¼��������˶ԣ�");
	  	 obj.focus();
	  	 return 0;
     }
  	 return 1;
   }
   catch(err)
   {
  	  alert(err.description);
  	  return 0;
   }
}
//-------------------------------
//  �� �� ����cal_years(rq)
//  ���ܽ��ܣ�����ָ�����ڵ������Ƕ�����.
//  ����˵��������
//  ��    �أ�����
//-------------------------------

function cal_years(rq)
{
	var years;
	var dDate=new Date(sysnowdate.substr(0,4),sysnowdate.substr(5,2),sysnowdate.substr(8,2));
	var month1= dDate.getMonth()+1;
	var year1= dDate.getFullYear();
	var day1=dDate.getDate()
	var year2= rq.substr(0,4);
	var month2= rq.substr(5,2);
	var day2=rq.substr(8,2);
    years = year1 - year2 - 0;
    if (month2 > month1)   //�·�δ����years-1
    {
       years = years - 1;
    }
    else
    {
       if ( (month1 == month2) && (day2 > day1))  //�·ݵ��ˣ�����δ����years-1
       {
         years = years - 1;
       }
    }
	return years;
}

//-------------------------------
//  �� �� ����cal_years1(rq1,rq2)
//  ���ܽ��ܣ�����ָ�����ڵ������Ƕ�����.(rq1-rq2)
//  ����˵��������1,����2
//  ��    �أ�����
//-------------------------------

function cal_years1(rq1,rq2)
{
	var years;
	var year1= rq1.substr(0,4);
	var month1= rq1.substr(5,2);
	var day1=rq1.substr(8,2);
	var year2= rq2.substr(0,4);
	var month2= rq2.substr(5,2);
	var day2=rq2.substr(8,2);
    years = year1 - year2 - 0;
    if (month2 > month1)   //�·�δ����years-1
    {
       years = years - 1;
    }
    else
    {
       if ( (month1 == month2) && (day2 > day1))  //�·ݵ��ˣ�����δ����years-1
       {
         years = years - 1;
       }
    }
	return years;
}
//-------------------------------
//  �� �� ����cal_days(rq1,rq2)
//  ���ܽ��ܣ������������ڼ������(Ҫ��rq2>=rq1).
//  ����˵��������1,����2
//  ��    �أ�����
//-------------------------------

function cal_days(rq1,rq2)
{  
	var d, s, t, d1 , d2, s1 , s2;
    var DyMilli = 24 * 60 * 60 * 1000;  //һ��ĺ�����
    d=todaystr
    s = d.getTime();  //ϵͳ������ 1970 �� 1 �� 1 ����ҹ��ȫ���׼ʱ�� �ĺ�����
    var days;
     //ϵͳ���ڡ��ꡢ�¡���
     //var dDate = new Date();
    var dDate=todaystr
    var month= dDate.getMonth()+1;
    var year= dDate.getFullYear();
    var day=dDate.getDate();
    d=new Date(year,month-1,day);
    s = d.getTime()
    var month1;
    var month2;
    var year1;
    var year2;
    var day1;
    var day2;
    if (rq1=="")
    {
     	s1=s;
      	month1= month;
     	year1= year;
     	day1= day;
    }
    else
    {
        year1= rq1.substr(0,4);
        month1= rq1.substr(5,2);
        day1=rq1.substr(8,2);
        d1=new Date(year1,month1-1,day1);
        s1=d1.getTime();
    }

    if (rq2=="")
    {
     	s2=s;
     	month2= month;
     	year2= year;
     	day2= day;
    }
    else
    {
        year2= rq2.substr(0,4);
        month2= rq2.substr(5,2);
        day2=rq2.substr(8,2);
        d2=new Date(year2,month2-1,day2);
        s2=d2.getTime();
    }
    days=Math.round((s2 - s1) / DyMilli);;
	return days;
}



//-------------------------------
//  �� �� ����get_checkbox(get_item)
//  ���ܽ��ܣ�ȡ��ѡ�������.
//  ����˵������ѡ���������
//  ��    �أ���ѡ���ֵ
//-------------------------------
function get_checkbox(get_item)
{
	var get_item_content
	get_item_content=""
	var item_length=get_item.length
	//alert(item_length)
	for(var i=0;i<item_length;i++)
	{
 	 	if(get_item.item(i).checked)
  		{
  			 //alert(get_item.item(i).value)
  			get_item_content=get_item_content+get_item.item(i).value
		}
	}
	return get_item_content;
}


//-------------------------------
//  �� �� ����set_checkbox(set_item,s_value)
//  ���ܽ��ܣ����ø�ѡ�����������.
//  ����˵������ѡ��Ŀؼ�������󣬱�ʾ״̬���ַ�����checkbox��valueֵ��
//  ��    �أ����õĸ�ѡ������
//
//  ���� 2004.05.11
//-------------------------------
function set_checkbox(set_item,s_value)
{
    var i,j;	//ѭ����������i-�ؼ�����ѭ����j-�ַ���ֵλ�ÿ���

	//��ѭ״̬�ַ���
	for(j=0;j<s_value.length;j++)
        {
        	//��ѭ�ؼ�����
	        for(i=0;i<set_item.length;i++)
        	{
        		if(set_item.item(i).value==s_value.substr(j,1))
                {
                		set_item.item(i).checked=true;
                                break;
                }
        	}
        }

	return j;
}



//-------------------------------
//  �� �� ����bulidXzqh(obj,Opt_name,Opt_value)
//  ���ܽ��ܣ������µ�����Ͻ�������б�
//  ����˵��������1,����2
//  ��    �أ�
//-------------------------------

function bulidXzqh(obj,Opt_name,Opt_value)
{
  var n1
  if(Opt_name.length>0)
  {

    n1=document.createElement("OPTION")
    n1.value=Opt_value
    n1.text=Opt_name
    obj.add(n1)
    var i=obj.length-1
    obj.options[i].selected=true
 }

}







//----------���������б�--------------

function buildList(get_xml_id,put_id,view_type)
{
	var xmldoc,theNode,code1Node;
	var get_list,get_list_code,get_list_value
	var str1="document.all."+get_xml_id+".XMLDocument"
	xmldoc=eval(str1)
	xmldoc.async=false

	//ȡ����
	var str2="xmldoc.getElementsByTagName(\"Codes\")"
	get_list=eval(str2)
	if(view_type==null || view_type==""){view_type="0"}   //ȱʡ

	//��ʾ����,��������,view_type=="2"
	if(view_type=="2")
	{
		for(var i=0;i<get_list.length;i++)
		{
			var str3="document.all[\""+put_id+"\"].options[i]=new Option(get_list.item(i).lastChild.text,get_list.item(i).lastChild.text)"
			eval(str3)
		}
	}
	//��ʾʱ������,view_type=="1"
	if(view_type=="1")
	{
		for(var i=0;i<get_list.length;i++)
		{
			var str3="document.all[\""+put_id+"\"].options[i]=new Option(get_list.item(i).firstChild.text+get_list.item(i).lastChild.text,get_list.item(i).firstChild.text)"
			eval(str3)
		}
	}
	if(view_type=="0")
	{
		//��ʾʱ��������,view_type=="0"
		for(var i=0;i<get_list.length;i++)
		{
			var str3="document.all[\""+put_id+"\"].options[i]=new Option(get_list.item(i).lastChild.text,get_list.item(i).firstChild.text)"
			eval(str3)
		}
	}
}
//----------������ѡ�б�(׼�ݱر����ύ����)--------------
function build_checkbox(get_xml_id,put_id,checkbox_name)
{
  var xmldoc,theNode,code1Node;
  var get_list,get_list_code,get_list_value
  var str1="document.all."+get_xml_id+".XMLDocument"
  xmldoc=eval(str1)
  var htmlstr=""
  //ȡ����
  var str2="xmldoc.getElementsByTagName(\"Codes\")"
  get_list=eval(str2)
  for(var i=0;i<get_list.length;i++)
  {
     htmlstr=htmlstr+"<input type=\"checkbox\"  name=\""+checkbox_name+ "\"   value=\""+get_list.item(i).firstChild.text+"\">"+get_list.item(i).lastChild.text
  }
  var str3="document.all."+put_id+".innerHTML=htmlstr"
  eval(str3)
}

//----------�����ύ������Ŀ--------------
function get_checkbox1(get_item,put_id)
{
	var get_item_content
	get_item_content=""
	var item_length=get_item.length

	for(var i=0;i<item_length;i++)
	{
  		if(get_item.item(i).checked)
  		{
  			get_item_content=get_item_content+get_item.item(i).value
  		}
	}
	alert(get_item_content);
	var the_str="document.all[\""+put_id+"\"].value=get_item_content"
	eval(the_str)
}


/*����ѡ��checkbox�������
box_value  Ϊ�ַ���
box_name   checkbox��name
2003-05-10
*/
function back_checkbox(box_name,box_value)
{
	var box_length
	var item_value
	var obj_str
	var obj
	obj_str="document.all[\""+box_name+"\"]"
	obj=eval(obj_str)
	box_length=obj.length
	for(var i=0;i<box_length;i++)
    {
    	item_value=obj.item(i).value
    	if(box_value.indexOf(item_value)>-1)
     	{
      		obj.item(i).checked=true
     	}
   	}
}

function decode_from_xml(xml_id,the_code)    //���뷭��
{
 	var de_code=""
 	var str,obj
 	str="document.all[\""+xml_id+"\"]"
 	obj=eval(str)
  	while(!obj.recordset.EOF)
  	{
    	var code=obj.recordset("code")
    	if(code==the_code)
    	{
    		de_code=new String(obj.recordset("Value"))
    	}
    	obj.recordset.moveNext();
	}
  	obj.recordset.moveFirst();
  	return  de_code;
}


function decode_self(the_code)
{
 	var de_code
 	de_code=""

	if(the_code=="1")
 	{
    	de_code="�ϸ�";
 	}
 	else
 	{
   		de_code="���ϸ�";
	}
  	return  de_code;
}


//----------�����ɹ����������б�--------------

function glcx_list(get_xml_id,glcx,put_id)
{
	var xmldoc,theNode,code1Node;
	var get_list,get_list_code,get_list_value
	var str1="document.all."+get_xml_id+".XMLDocument"
	//alert(str1)
	xmldoc=eval(str1)
	xmldoc.async=false
	//alert(xmldoc.xml)
	//ȡ����
	var str2="xmldoc.getElementsByTagName(\"Codes\")"
	get_list=eval(str2)

	//alert("AAA:"+get_list.length)
	var j=0
	for(var i=0;i<get_list.length;i++)
	{
		if(glcx.indexOf(get_list.item(i).firstChild.text)>-1)
  		{
  			var str3="document.all[\""+put_id+"\"].options[j]=new Option(get_list.item(i).firstChild.text+get_list.item(i).lastChild.text,get_list.item(i).firstChild.text)"
  			eval(str3)
  			j=j+1
  		}
	}
}

function cReadonly(obj)
{
	if (obj.type=="text")
	{
		obj.readOnly=true;
		obj.className="text_nobord";
	}
	else
	{
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
//  ��������jstrim(s_value)
//  ���ܽ��ܣ�ȥ��s_value���˵Ŀո�
//  ����˵�������������ַ���
//  ����ֵ  ���������ַ���
//-------------------------------
function jstrim(s_value)
{
	var i;
	var ibegin;

	for(i=0;i<s_value.length;i++)
	{
		if(s_value.charAt(i)!=' ')
			break;
	}

	if(i==s_value.length)
		return "";
	else
		ibegin=i;

	for(i=s_value.length-1;i>=0;i--)
	{
		if(s_value.charAt(i)!=' ')
			break;
	}

	return s_value.substr(ibegin,i-ibegin+1);
}

//-------------------------------
//  ��������trimall()
//  ���ܽ��ܣ�ȥ��document������form��������е�input(text)��������˿ո�
//  ����˵������
//  ����ֵ  ����
//-------------------------------
function trimall()
{
	var i,j;
	var allforms;
	var myelement;

	allforms=document.forms;

	for(i=0;i<allforms.length;i++)
	{
		for(j=0;j<allforms(i).elements.length;j++)
		{
			myelement=allforms(i).elements(j);
			if(myelement.type=="text")
				myelement.value=jstrim(myelement.value.toUpperCase());
		}
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
	if (rq1.length==10)
	{
		y=parseInt(rq1.substring(0,4))+ns
		m=parseInt(rq1.substring(5,7))
		d=parseInt(rq1.substring(8,10))
	}
	else if (rq1.length==8)
	{
		y=parseInt(rq1.substring(0,4))+ns
		m=parseInt(rq1.substring(4,6))
		d=parseInt(rq1.substring(6,8))
	}
	else
	{
		return "";
	}
	var str =y+rq1.substring(4,10);
	if (m==2 && d==29)
	{
		str=y+rq1.substring(4,7)+"-28";
	}
	return str
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


//����obj(select)�е�ֵ
function trancode(obj,val)
{
	for (var i=0;i<obj.length;i++)
	{
		var tmp
		tmp=obj.options(i).text
		tmp=tmp.substr((tmp.indexOf(":")+1),tmp.length-tmp.indexOf(":")-1)
		if (obj.options(i).value==val)
		{
			return tmp
		}
	}
	return ""
}
//-------------------------------
//  ��������DateAddMonth(strDate,iMonths)
//  ���ܽ��ܣ�������ڼ���iMonths�����������
//  ����˵����strDate ����
//  ����ֵ  ���޷���ֵ
//-------------------------------
function DateAddMonth(strDate,iMonths)
{
   var thisYear = parseFloat(strDate.substring(0,4));
   var thisMonth = parseFloat(strDate.substring(5,7));
   var thisDate = parseFloat(strDate.substring(8,10));
   var d =thisYear *12 + thisMonth + parseFloat(iMonths);

   var newMonth = d % 12;
   if (newMonth==0) 
   {
   		newMonth=12;
   }
   var newYear = (d - newMonth) /12;
   var newDate = thisDate;
   var iMonthLastDate=getMonthLastDate(newYear,newMonth)
   if (newDate>iMonthLastDate) newDate=iMonthLastDate;
   var newDay="";

   newDay += newYear;
   if (newMonth<10) 
   {
   		newDay +="-" + "0" + newMonth;
   }
   else
   {
   		newDay +="-" + newMonth;
   }

   if (newDate<10) 
   {
   		newDay +="-" + "0" + newDate;
   }
   else
   {
   		newDay +="-" + newDate;
   }
   return(newDay);                                // �������ڡ�
}
function getMonthLastDate(iYear,iMonth){
	var dateArray= new Array(31,28,31,30,31,30,31,31,30,31,30,31);
	var days=dateArray[iMonth-1];
	if ((((iYear % 4 == 0) && (iYear % 100 != 0)) || (iYear % 400 == 0)) && iMonth==2){
		days=29;
	}
	return days;
}


function strlen(str)
{
	var len;
	var i;
	len = 0;
	for (i=0;i<str.length;i++)
	{
		if (str.charCodeAt(i)>255) len+=2; else len++;	
	}
	return len;
}


//####################################
//����ͻ���Ϣ
//
//
//#####################################
function getcookie(nKey)
{
	var search=nKey+"=";
	begin=document.cookie.indexOf(search);
	if (begin!=-1)
	{
		begin+=search.length
		end=document.cookie.indexOf(";",begin);
		if (end==-1)
		{
			end=document.cookie.length;
		}
		return document.cookie.substring(begin,end)
	}
	else
	{
		return ""
	}
}

function setcookie(nKey,nVal)
{
	document.cookie=nKey+"="+nVal+";expires=wednesday,09-oct-2099 23:00:00 GMT"
}


var keyvalue="";
var srcStr="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
var objName="";
function findCode(event,obj)
{
	if (objName != obj.name)
	{
		objName=obj.name;
		keyvalue="";
	}
    if (event.keyCode==13 || event.keyCode==9 ) 
    {
        keyvalue="";
        return true;
    }

	keyvalue=keyvalue+String.fromCharCode(event.keyCode).toUpperCase();
	for(var i=0;i<obj.options.length;i++)
	{
		if(obj.options[i].value.indexOf(keyvalue)!=-1)
		{
			obj.value=obj.options[i].value;
            if (obj.options[i].value==keyvalue)
            {
				objName=""
			}
			return true;
		}
	}
}
function findName(event,obj)  //���ݴ���ȡ����
{
	if (objName != obj.name)
	{
		objName=obj.name;
		keyvalue="";
	}
    if (event.keyCode==13 || event.keyCode==9 ) 
    {
          keyvalue="";
          return true;
     }

	keyvalue=keyvalue+String.fromCharCode(event.keyCode).toUpperCase();

	for(var i=0;i<obj.options.length;i++)
	{
		if(obj.options[i].text.indexOf(keyvalue)!=-1)
		{
			obj.value=obj.options[i].value;
			return true;
		}
	}
}
//�Զ����������еĿո�
function ignoreSpaces(string) 
{
	var temp = "";
	string = '' + string;
	splitstring = string.split(" "); //˫����֮���Ǹ��ո�
	for(i = 0; i < splitstring.length; i++)
	{
		temp += splitstring[i];
	}
	return temp;
}

//-------------------------------
//��������isLength(i_field,i_length,i_value)
//���ܽ��ܣ��������ֵ�Ƿ�Ϊָ������
//����˵���������Ҫ�󳤶ȣ�ֵ
//����ֵ  ��1-��ָ������,0-����
//-------------------------------
function isLength(i_field,i_length,obj)
{//  alert("---����Ҫ��:"+i_length+" "+i_value.length);
obj.value=obj.value.trim();
var i_value=obj.value;
if (!(i_value.length==i_length))
{
 alert("'"+i_field+"' �ĳ���Ҫ��Ϊ' "+i_length+" '��");
 obj.focus();
 return 0;
}
return 1;
}