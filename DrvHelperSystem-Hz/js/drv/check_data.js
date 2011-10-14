/*
  �ļ���: check_data.js
  ��  ��: ��Ҫ��������У��
  ��  ��: ������ 2004��4��16��
  	  ��  �� 2004.05.11
*/

//-------------------------------
//  ��������isNull(i_field,i_value)
//  ���ܽ��ܣ���������Ƿ�Ϊ�ǿ�
//  ����˵�������������Ķ�Ӧֵ
//  ����ֵ  ��0-�ǿ�,1-Ϊ��
//-------------------------------
function isNull(i_field,i_value)
{
 if (i_value==null || jstrim(i_value)=="")
 {
    return 1;
 }
 else
 {
     alert("'"+i_field+"' Ҫ��Ϊ�գ�");
     return 0;
 }
}

//-------------------------------
//  ��������notNull(i_field,i_value)
//  ���ܽ��ܣ���������Ƿ�Ϊ�ǿ�
//  ����˵�������������Ķ�Ӧֵ
//  ����ֵ  ��1-�ǿ�,0-Ϊ��
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
//  ��������isNum(i_field,i_value)
//  ���ܽ��ܣ���������ַ����Ƿ�Ϊ����
//  ����˵�������������Ķ�Ӧֵ
//  ����ֵ  ��1-������,0-������
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
//  ��������isGreatNum(i_field,i_value,i_value1)
//  ���ܽ��ܣ���������ַ����Ƿ������ֲ��Ҵ���i_value1
//  ����˵�������������Ķ�Ӧֵ���Ƚ���ֵ
//  ����ֵ  ��1-������i_valueΪ�����Ҵ���i_value1,
//           0-�����ֻ���i_valueС�ڵ���i_value1
//
//  ���� 2004.05.11
//-------------------------------
function isGreatNum(i_field,i_value,i_value1)
{
    //У��������Ƿ�Ϊ��ֵ
    if(isNum(i_field,i_value)==0)
    	return 0;
    else
    {
        if(i_value<=i_value1)
        	return 0;
    }

    return 1;
}

//-------------------------------
//  ��������isSmallNum(i_field,i_value,i_value1)
//  ���ܽ��ܣ���������ַ����Ƿ������ֲ���С��i_value1
//  ����˵�������������Ķ�Ӧֵ���Ƚ���ֵ
//  ����ֵ  ��1-������i_valueΪ������С��i_value1,
//           0-�����ֻ���i_value���ڵ���i_value1
//
//  ���� 2004.05.11
//-------------------------------
function isSmallNum(i_field,i_value,i_value1)
{
    //У��������Ƿ�Ϊ��ֵ
    if(isNum(i_field,i_value)==0)
    	return 0;
    else
    {
        if(i_value>=i_value1)
        	return 0;
    }

    return 1;
}


//-------------------------------
//  ��������isDate(i_field,thedate)
//  ���ܽ��ܣ�У���ַ����Ƿ�Ϊ���ڸ�ʽ
//  ����˵���������������ַ���
//  ����ֵ  ��0-���ǣ�1--��
//-------------------------------

function isDate(i_field,thedate)
{
  if (!(thedate.length==8 || thedate.length==10))
   {  
	  alert(thedate.length);
	  alert("'"+i_field+"'���ڸ�ʽ����,\nҪ��Ϊyyyymmdd��yyyy-mm-dd��");
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
//  ��������changeDate(thedate)
//  ���ܽ��ܣ�����yyyymmddת����yyyy-mm-dd��ʽ
//  ����˵������������
//  ����ֵ  ��0-���ǣ�1--��
//-------------------------------

function changeDate(thedate)
{

 if (thedate.length==8)
  {
  	thedate=thedate.substr(0,4)+"-"+thedate.substr(4,2)+"-"+thedate.substr(6,2);
  }

     return thedate;

}

//-------------------------------
//  ��������isLength(i_field,i_length,i_value)
//  ���ܽ��ܣ��������ֵ�Ƿ�Ϊָ������
//  ����˵���������Ҫ�󳤶ȣ�ֵ
//  ����ֵ  ��1-��ָ������,0-����
//-------------------------------
function isLength(i_field,i_length,i_value)
{//  alert("---����Ҫ��:"+i_length+" "+i_value.length);
 if (!(i_value.length==i_length))
 {
     alert("'"+i_field+"' �ĳ���Ҫ��Ϊ' "+i_length+" '��");
     return 0;
 }
 return 1;
}

//-------------------------------
//  ��������dyLength(i_field,i_length,i_value)
//  ���ܽ��ܣ��������ֵ�Ƿ�ﵽָ����������
//  ����˵���������Ҫ�󳤶ȣ�ֵ
//  ����ֵ  ��1-����,0-����
//-------------------------------
function dyLength(i_field,i_length,i_value)
{ //alert("---����Ҫ��:"+i_length+" "+i_value.length);
 if (i_value.length<i_length)
 {
     alert("'"+i_field+"' �ĳ�������Ϊ '"+i_length+"'��");
     return 0;
 }
 return 1;
}

//-------------------------------
//  ��������xyLength(i_field,i_length,i_value)
//  ���ܽ��ܣ��������ֵ��Ҫ����ָ������
//  ����˵���������Ҫ�󳤶ȣ�ֵ
//  ����ֵ  ��1-����,0-����
//-------------------------------
function xyLength(i_field,i_length,i_value)
{ //alert("---����Ҫ��:"+i_length+" "+i_value.length);
 if (i_value.length>i_length)
 {
     alert("'"+i_field+"' �ĳ����Ϊ '"+i_length+"' ��");
     return 0;
 }
 return 1;
}

//-------------------------------
//  ��������check_hm(��ǩ������,i_value)
//  ����˵������ǩ������,ֵ��
//  ���ܽ��ܣ������������ַ��������Ƿ����㣻�Ƿ�ȫ���֡�
//  ����ֵ  ��1-�ǣ�false-����
//-------------------------------
function check_hm(i_field,i_length,i_value)
{

    if (isLength(i_field,i_length,i_value)==0)
    {
    	return 0;
    }
    if (isNum(i_field,i_value)==0)
    {
    	return 0;
    }
return 1;
}

//-------------------------------
//  ��������check_yzbm(i_value)
//  ����˵������������ֵ��
//  ���ܽ��ܣ�������������Ƿ���6λ�����֡�
//  ����ֵ  ��1-�ǣ�false-����
//-------------------------------
function check_yzbm(i_value)
{

    if (isLength("��������","6",i_value)==0)
    {
    	return 0;
    }
    if (isNum("��������",i_value)==0)
    {
    	return 0;
    }
return 1;
}//-------------------------------
//  ��������check_zjhm(zjmc,obj)
//  ����˵����֤�����ƣ�֤�����롣
//  ���ܽ��ܣ�������֤����Ϸ��ԡ�
//	      �����֤����Ƿ�Ϊȫ���֣��������ڸ�ʽ�Ƿ���ȷ���Ƿ�<=18,<=70��У������
//  ����ֵ  ��1-�ǣ�0-��
//-------------------------------
function check_zjhm(zjmc,zjhm)
{

  var birthday="";
  var zjhm1="";
  var zjhm2="";

  var s="";
  if (notNull("֤������",zjhm)==0)  { return 0;  }
  if(zjmc=="A")   //���֤����
   {
       if(!(zjhm.length==15 || zjhm.length==18) )
	     {
	       alert("���֤���Ȳ���,���飡") ;
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
            	re=new RegExp("[^0-9X]");
               if(s=zjhm2.match(re))     //18λ���֤��ĩλҪ�����ֻ��ַ�
               {
                   alert("�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
                   return 0;
                }
                birthday=zjhm.substr(6,8);
            }
           birthday=birthday.substr(0,4)+"-"+birthday.substr(4,2)+"-"+birthday.substr(6,2)
          //alert("birthday"+birthday)

          if(isDate("֤������",birthday)==0)  //������ڵĺϷ���
          {
             return 0;
          }

         var nl=cal_years(birthday);//������

         //if (nl-0<18 || nl>70)
         if (nl-0<18)
 	   {
             alert("����Ҫ�� 18������ ,��ǰ "+nl+" ��");
            return 0;
           }
          if(zjhm.length==18 )
          {
          	return(sfzCheck(zjhm));  //��18λ�������֤����ĩλУ��
          }
       }
else
	{if (zjhm.length>17){

	       alert("�ǡ��������֤�����Ȳ��ó���17λ,���飡") ;
               return 0;
	}
	}

   return 1;
   }
function check_zjhmNoAge(zjmc,zjhm)
{

  var birthday="";
  var zjhm1="";
  var zjhm2="";

  var s="";
  if (notNull("֤������",zjhm)==0)  { return 0;  }
  if(zjmc=="A")   //���֤����
   {
       if(!(zjhm.length==15 || zjhm.length==18) )
	     {
	       alert("���֤���Ȳ���,���飡") ;
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
            	re=new RegExp("[^0-9X]");
               if(s=zjhm2.match(re))     //18λ���֤��ĩλҪ�����ֻ��ַ�
               {
                   alert("�����ֵ�к��зǷ��ַ�'"+s+"'���飡");
                   return 0;
                }
                birthday=zjhm.substr(6,8);
            }
           birthday=birthday.substr(0,4)+"-"+birthday.substr(4,2)+"-"+birthday.substr(6,2)
          //alert("birthday"+birthday)

          if(isDate("֤������",birthday)==0)  //������ڵĺϷ���
          {
             return 0;
          }


          if(zjhm.length==18 )
          {
          	return(sfzCheck(zjhm));  //��18λ�������֤����ĩλУ��
          }
       }
else
	{if (zjhm.length>17){

	       alert("�ǡ��������֤�����Ȳ��ó���17λ,���飡") ;
               return 0;
	}
	}

   return 1;
   }

function id15to18(zjhm)
{


	var strJiaoYan =new  Array("1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2");
	var intQuan =new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1);
	var ll_sum=0;
	var i;
	var ls_check;
	zjhm = zjhm.substring(0, 6) + "19" + zjhm.substring(6);
	for (i=0;i<=16;i++){
		ll_sum=ll_sum+(parseFloat(zjhm.substr(i,1)))*intQuan[i];
	}
	ll_sum = ll_sum % 11;
	zjhm=zjhm + strJiaoYan[ll_sum];
	return zjhm;
}
//-------------------------------
//  ������  ��check_sg(i_value)
//  ����˵������ߡ�
//  ���ܽ��ܣ��������Ƿ�Ϊ���֣��Ƿ�>=100,<=250
//  ����ֵ  ��1-�ǣ�0-����
//-------------------------------

function check_sg(i_value)
{
        if(isNum("���",i_value)==0)  //�������Ƿ�Ϊ����
        {
               return 0;
        }
        else
        {
	 if ((i_value-0)<100 ||(i_value-0)>250)
	 {
	       alert("'���'����ΧӦ�� 100--250 ��");
               return 0;
	 }
        }
  return 1;
}

//-------------------------------
//  ������  ��check_sl(i_value)
//  ����˵����������
//  ���ܽ��ܣ���������Ƿ�Ϊ���֣��Ƿ�>=4.9,<=5.5
//  ����ֵ  ��1-�ǣ�false-����
//-------------------------------

function check_sl(i_value)
{
    var reg = /^(\d{1,1})(\.)(\d{1,1})$/;

if (document.all["zsl"].value.length==2)
 {
 document.all["zsl"].value=document.all["zsl"].value.substr(0,1)+"."+document.all["zsl"].value.substr(1,1);
 }
 if (document.all["ysl"].value.length==2)
 {
    document.all["ysl"].value=document.all["ysl"].value.substr(0,1)+"."+document.all["ysl"].value.substr(1,1);
 }
    var r = document.all["zsl"].value.match(reg);
    var r1 = document.all["ysl"].value.match(reg);
    if(r==null)
    	{
         alert("�������ĸ�ʽӦΪ��x.x ��")
         return 0;
       }
    if(r1==null)
    	{
         alert("�������ĸ�ʽӦΪ��x.x ��")
         return 0;
       }

    if ((document.all["zsl"].value-0)<4.9 || (document.all["zsl"].value-0)>5.5)
    {
         alert("'������'Ӧ�� 4.9--5.5 ��Χ��");
         return 0;
    }
    if ((document.all["ysl"].value-0)<4.9 || (document.all["ysl"].value-0)>5.5)
    {
         alert("'������'Ӧ�� 4.9--5.5 ��Χ��");
         return 0;
    }
 return 1;
}

//-------------------------------
//  ��������isHg(bsl,tl,sz,qgjb)
//  ���ܽ��ܣ���ɫ��,����,��֫,���ɾ����Ƿ�ϸ�
//  ����˵������ɫ��,����,��֫,���ɾ���
//  ����ֵ  ��1-��������,0-������
//-------------------------------

function isHg(bsl,tl,sz,qgjb)
{//alert(bsl+tl+sz+qgjb)
    if (!(bsl==1))
       {
       	  alert("'��ɫ��'���ϸ��߲������룡");
          return 0;
       }
    if (!(tl==1))
       {
       	  alert("'����'���ϸ��߲������룡");
          return 0;
       }
    if (!(sz==1))
       {
       	  alert("'��֫'���ϸ��߲������룡");
          return 0;
       }
    if (!(qgjb==1))
       {
       	  alert("'���ɾ���'���ϸ��߲������룡");
          return 0;
       }
 if((document.all["yxz"].value)==0)
 {
   alert("����֫����ϸ�")
   document.all.yxz.focus();
   return 0;
 }
     return 1;
}

//-------------------------------
//  ��������sfzCheck(hm)
//  ���ܽ��ܣ���18λ�������֤����ĩλУ��
//  ����˵�������֤����
//  ����ֵ  ��1-����,0-������
//-------------------------------

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
            alert("���֤У�����------ ĩλӦ��:"+ls_check+" ʵ��:"+hm.substr(17,1));
            return 0;
     }
return 1
}

function  comm_check(){
if (document.all["xm"].value.length<2)
{
document.all["xm"].focus();
alert("'����'�������������֣�");
return 0;
 }
if (document.all["lxdh"].value.length<6)
{
document.all["lxdh"].focus();
alert("'��ϵ�绰'��������6λ��");
return 0;
 }
return 1;
}

//-------------------------------
//  ������  ��check_zjcx(s_value��s_cx_dm)
//  ����˵����׼�ݳ����ַ������Ϸ���׼�ݳ����ַ������顣
//  ���ܽ��ܣ���鳵�������Ƿ���ȷ��ֻ����Ƿ�����Ϸ���׼�ݳ����ַ������ظ�������ߵ�����Ϊ�Ǵ���
//  ����ֵ  ��1-�����Ϸ���׼�ݳ��У�0-���Ϸ�
//
//  ���� 2004.05.12
//-------------------------------
function check_zjcx(s_value,s_cx_dm)
{
  	//�Ϸ���׼�ݳ����ַ�������
	//var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P");
        //�ַ�������ĳ���
        var s_cx_input;	//�����Ҫ������ַ���
	var i_pos;	//�����Ӵ���λ
        var i;

        s_cx_input=s_value;
	for(i in s_cx_dm)	//�ԺϷ�׼�ݳ����ַ���������ѭ
	{
		do
		{
			i_pos=s_cx_input.indexOf(s_cx_dm[i]);	//�Ƿ������ǰ����
			if(i_pos!=-1)	//����
			{
                          	//ȥ���ҵ����Ӵ�
				s_cx_input=s_cx_input.slice(0,i_pos)+s_cx_input.slice(i_pos+s_cx_dm[i].length);
			}
		}while(i_pos!=-1);	//�Ҳ�����ǰ�����Ӵ���������һ�����Ӵ�����
	}

	if(s_cx_input.length==0)	//�����ַ��������Ķ��ǺϷ��ĳ����Ӵ���ȫ����ȥ���ˣ�
		return 1;
	else	//�����ַ����������зǷ����ַ���
		return 0;
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
   var d =thisYear *12 + thisMonth + iMonths;

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

function getMonthLastDate(iYear,iMonth){
	var dateArray= new Array(31,28,31,30,31,30,31,31,30,31,30,31);
	var days=dateArray[iMonth-1];
	if ((((iYear % 4 == 0) && (iYear % 100 != 0)) || (iYear % 400 == 0)) && iMonth==2){
		days=29;
	}
	return days;
}

var keyvalue="";
var srcStr="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
var objName="";
function findCode(event,obj)
{
	if (objName != obj.name){
		objName=obj.name;
		keyvalue="";
	}
        if (event.keyCode==13 || event.keyCode==9 ) {
          keyvalue="";
          return true;
        }

	//if(srcStr.indexOf(String.fromCharCode(event.keyCode))!=-1)
	//	keyvalue="";
	keyvalue=keyvalue+String.fromCharCode(event.keyCode).toUpperCase();
	//alert(keyvalue);
	for(var i=0;i<obj.options.length;i++)
	{
		if(obj.options[i].value.indexOf(keyvalue)!=-1)
		{
			obj.value=obj.options[i].value;
                        if (obj.options[i].value==keyvalue){
				objName=""
			}
			return true;
		}
	}
}
function findName(event,obj)  //���ݴ���ȡ����
{
	if (objName != obj.name){
		objName=obj.name;
		keyvalue="";
	}
        if (event.keyCode==13 || event.keyCode==9 ) {
          keyvalue="";
          return true;
        }

	//if(srcStr.indexOf(String.fromCharCode(event.keyCode))!=-1)
	//	keyvalue="";
	keyvalue=keyvalue+String.fromCharCode(event.keyCode).toUpperCase();
	//alert(keyvalue);
	//alert(obj.options.length);
	for(var i=0;i<obj.options.length;i++)
	{
		//alert(obj.options[i].text);

		if(obj.options[i].text.indexOf(keyvalue)!=-1)
		{
			obj.value=obj.options[i].value;
			return true;
		}
	}
}
//�Զ����������еĿո�
function ignoreSpaces(string) {
var temp = "";
string = '' + string;
splitstring = string.split(" "); //˫����֮���Ǹ��ո�
for(i = 0; i < splitstring.length; i++)
temp += splitstring[i];
return temp;
}
