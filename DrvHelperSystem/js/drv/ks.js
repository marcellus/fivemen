function setcookie(nKey,nVal){
document.cookie=nKey+"="+nVal+";expires=wednesday,09-oct-2099 23:00:00 GMT"
}
//-------------------------------
//��������notNull(i_field,i_value)
//���ܽ��ܣ���������Ƿ�Ϊ�ǿ�
//����˵�������������Ķ�Ӧֵ
//����ֵ  ��1-�ǿ�,0-Ϊ��
//-------------------------------
function notNull(i_field,i_value)
{
if (i_value==null || jstrim(i_value)=="")
{
 alert("'"+i_field+"' ����Ϊ�գ�");
 return 0;
}
return 1;
}

//-------------------------------
//��������isNum(i_field,i_value)
//���ܽ��ܣ���������ַ����Ƿ�Ϊ����
//����˵�������������Ķ�Ӧֵ
//����ֵ  ��1-������,0-������
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
    alert("'"+i_field+"' �к��зǷ��ַ� '"+s+"' ��");
    return 0;
 }
return 1;
}

//-------------------------------
//��������isDate(i_field,thedate)
//���ܽ��ܣ�У���ַ����Ƿ�Ϊ���ڸ�ʽ
//����˵���������������ַ���
//����ֵ  ��0-���ǣ�1--��
//-------------------------------

function isDate(i_field,thedate)
{
if (!(thedate.length==8 || thedate.length==10))
{    alert("'"+i_field+"'���ڸ�ʽ����,\nҪ��Ϊyyyymmdd��yyyy-mm-dd��");
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
   alert("��������ȷ��'"+i_field+"' ��");
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
 alert("'"+i_field+"'���ڸ�ʽ����,\nҪ��Ϊyyyymmdd��yyyy-mm-dd��");
 return 0;
}

//-------------------------------
//��������jstrim(s_value)
//���ܽ��ܣ�ȥ��s_value���˵Ŀո�
//����˵�������������ַ���
//����ֵ  ���������ַ���
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
//����ͻ���Ϣ
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