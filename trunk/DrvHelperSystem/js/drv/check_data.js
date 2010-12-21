/*
  文件名: check_data.js
  功  能: 主要进行数据校验
  更  新: 金永俊 2004年4月16日
  	  戴  嘉 2004.05.11
*/

//-------------------------------
//  函数名：isNull(i_field,i_value)
//  功能介绍：检查输入是否为非空
//  参数说明：数据项，输入的对应值
//  返回值  ：0-非空,1-为空
//-------------------------------
function isNull(i_field,i_value)
{
 if (i_value==null || jstrim(i_value)=="")
 {
    return 1;
 }
 else
 {
     alert("'"+i_field+"' 要求为空！");
     return 0;
 }
}

//-------------------------------
//  函数名：notNull(i_field,i_value)
//  功能介绍：检查输入是否为非空
//  参数说明：数据项，输入的对应值
//  返回值  ：1-非空,0-为空
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
//  函数名：isNum(i_field,i_value)
//  功能介绍：检查输入字符串是否为数字
//  参数说明：数据项，输入的对应值
//  返回值  ：1-是数字,0-非数字
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
//  函数名：isGreatNum(i_field,i_value,i_value1)
//  功能介绍：检查输入字符串是否是数字并且大于i_value1
//  参数说明：数据项，输入的对应值，比较数值
//  返回值  ：1-给定的i_value为数字且大于i_value1,
//           0-非数字或者i_value小于等于i_value1
//
//  戴嘉 2004.05.11
//-------------------------------
function isGreatNum(i_field,i_value,i_value1)
{
    //校验输入的是否为数值
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
//  函数名：isSmallNum(i_field,i_value,i_value1)
//  功能介绍：检查输入字符串是否是数字并且小于i_value1
//  参数说明：数据项，输入的对应值，比较数值
//  返回值  ：1-给定的i_value为数字且小于i_value1,
//           0-非数字或者i_value大于等于i_value1
//
//  戴嘉 2004.05.11
//-------------------------------
function isSmallNum(i_field,i_value,i_value1)
{
    //校验输入的是否为数值
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
//  函数名：isDate(i_field,thedate)
//  功能介绍：校验字符串是否为日期格式
//  参数说明：数据项，输入的字符串
//  返回值  ：0-不是，1--是
//-------------------------------

function isDate(i_field,thedate)
{
  if (!(thedate.length==8 || thedate.length==10))
   {  
	  alert(thedate.length);
	  alert("'"+i_field+"'日期格式不对,\n要求为yyyymmdd或yyyy-mm-dd！");
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
//  函数名：changeDate(thedate)
//  功能介绍：日期yyyymmdd转换成yyyy-mm-dd格式
//  参数说明：输入日期
//  返回值  ：0-不是，1--是
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
//  函数名：isLength(i_field,i_length,i_value)
//  功能介绍：检查输入值是否为指定长度
//  参数说明：数据项，要求长度，值
//  返回值  ：1-是指定长度,0-不是
//-------------------------------
function isLength(i_field,i_length,i_value)
{//  alert("---长度要求:"+i_length+" "+i_value.length);
 if (!(i_value.length==i_length))
 {
     alert("'"+i_field+"' 的长度要求为' "+i_length+" '！");
     return 0;
 }
 return 1;
}

//-------------------------------
//  函数名：dyLength(i_field,i_length,i_value)
//  功能介绍：检查输入值是否达到指定长度以上
//  参数说明：数据项，要求长度，值
//  返回值  ：1-符合,0-不是
//-------------------------------
function dyLength(i_field,i_length,i_value)
{ //alert("---长度要求:"+i_length+" "+i_value.length);
 if (i_value.length<i_length)
 {
     alert("'"+i_field+"' 的长度至少为 '"+i_length+"'！");
     return 0;
 }
 return 1;
}

//-------------------------------
//  函数名：xyLength(i_field,i_length,i_value)
//  功能介绍：检查输入值不要超过指定长度
//  参数说明：数据项，要求长度，值
//  返回值  ：1-符合,0-不是
//-------------------------------
function xyLength(i_field,i_length,i_value)
{ //alert("---长度要求:"+i_length+" "+i_value.length);
 if (i_value.length>i_length)
 {
     alert("'"+i_field+"' 的长度最长为 '"+i_length+"' ！");
     return 0;
 }
 return 1;
}

//-------------------------------
//  函数名：check_hm(标签，长度,i_value)
//  参数说明：标签，长度,值。
//  功能介绍：检查输入号码字符串长度是否满足；是否全数字。
//  返回值  ：1-是，false-不是
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
//  函数名：check_yzbm(i_value)
//  参数说明：邮政编码值。
//  功能介绍：检查邮政编码是否是6位长数字。
//  返回值  ：1-是，false-不是
//-------------------------------
function check_yzbm(i_value)
{

    if (isLength("邮政编码","6",i_value)==0)
    {
    	return 0;
    }
    if (isNum("邮政编码",i_value)==0)
    {
    	return 0;
    }
return 1;
}//-------------------------------
//  函数名：check_zjhm(zjmc,obj)
//  参数说明：证件名称，证件号码。
//  功能介绍：检查身份证号码合法性。
//	      对身份证检查是否为全数字；出生日期格式是否正确；是否<=18,<=70；校验码检查
//  返回值  ：1-是，0-不
//-------------------------------
function check_zjhm(zjmc,zjhm)
{

  var birthday="";
  var zjhm1="";
  var zjhm2="";

  var s="";
  if (notNull("证件号码",zjhm)==0)  { return 0;  }
  if(zjmc=="A")   //身份证号码
   {
       if(!(zjhm.length==15 || zjhm.length==18) )
	     {
	       alert("身份证长度不对,请检查！") ;
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
	        alert("输入的值中含有非法字符'"+s+"'请检查！");
	        return 0;
             }
        //取出生日期
        if(zjhm.length==15 )
            {
               birthday="19"+zjhm.substr(6,6);
            }
         else
            {
            	re=new RegExp("[^0-9X]");
               if(s=zjhm2.match(re))     //18位身份证对末位要求数字或字符
               {
                   alert("输入的值中含有非法字符'"+s+"'请检查！");
                   return 0;
                }
                birthday=zjhm.substr(6,8);
            }
           birthday=birthday.substr(0,4)+"-"+birthday.substr(4,2)+"-"+birthday.substr(6,2)
          //alert("birthday"+birthday)

          if(isDate("证件号码",birthday)==0)  //检查日期的合法性
          {
             return 0;
          }

         var nl=cal_years(birthday);//求年龄

         //if (nl-0<18 || nl>70)
         if (nl-0<18)
 	   {
             alert("年龄要求 18岁以上 ,当前 "+nl+" ！");
            return 0;
           }
          if(zjhm.length==18 )
          {
          	return(sfzCheck(zjhm));  //对18位长的身份证进行末位校验
          }
       }
else
	{if (zjhm.length>17){

	       alert("非‘居民身份证’长度不得超过17位,请检查！") ;
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
  if (notNull("证件号码",zjhm)==0)  { return 0;  }
  if(zjmc=="A")   //身份证号码
   {
       if(!(zjhm.length==15 || zjhm.length==18) )
	     {
	       alert("身份证长度不对,请检查！") ;
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
	        alert("输入的值中含有非法字符'"+s+"'请检查！");
	        return 0;
             }
        //取出生日期
        if(zjhm.length==15 )
            {
               birthday="19"+zjhm.substr(6,6);
            }
         else
            {
            	re=new RegExp("[^0-9X]");
               if(s=zjhm2.match(re))     //18位身份证对末位要求数字或字符
               {
                   alert("输入的值中含有非法字符'"+s+"'请检查！");
                   return 0;
                }
                birthday=zjhm.substr(6,8);
            }
           birthday=birthday.substr(0,4)+"-"+birthday.substr(4,2)+"-"+birthday.substr(6,2)
          //alert("birthday"+birthday)

          if(isDate("证件号码",birthday)==0)  //检查日期的合法性
          {
             return 0;
          }


          if(zjhm.length==18 )
          {
          	return(sfzCheck(zjhm));  //对18位长的身份证进行末位校验
          }
       }
else
	{if (zjhm.length>17){

	       alert("非‘居民身份证’长度不得超过17位,请检查！") ;
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
//  函数名  ：check_sg(i_value)
//  参数说明：身高。
//  功能介绍：检查身高是否为数字；是否>=100,<=250
//  返回值  ：1-是，0-不是
//-------------------------------

function check_sg(i_value)
{
        if(isNum("身高",i_value)==0)  //检查身高是否为数字
        {
               return 0;
        }
        else
        {
	 if ((i_value-0)<100 ||(i_value-0)>250)
	 {
	       alert("'身高'合理范围应在 100--250 ！");
               return 0;
	 }
        }
  return 1;
}

//-------------------------------
//  函数名  ：check_sl(i_value)
//  参数说明：视力。
//  功能介绍：检查视力是否为数字；是否>=4.9,<=5.5
//  返回值  ：1-是，false-不是
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
         alert("左视力的格式应为：x.x ！")
         return 0;
       }
    if(r1==null)
    	{
         alert("右视力的格式应为：x.x ！")
         return 0;
       }

    if ((document.all["zsl"].value-0)<4.9 || (document.all["zsl"].value-0)>5.5)
    {
         alert("'左视力'应在 4.9--5.5 范围！");
         return 0;
    }
    if ((document.all["ysl"].value-0)<4.9 || (document.all["ysl"].value-0)>5.5)
    {
         alert("'右视力'应在 4.9--5.5 范围！");
         return 0;
    }
 return 1;
}

//-------------------------------
//  函数名：isHg(bsl,tl,sz,qgjb)
//  功能介绍：辨色力,听力,上肢,躯干颈部是否合格
//  参数说明：辨色力,听力,上肢,躯干颈部
//  返回值  ：1-符合申请,0-不符合
//-------------------------------

function isHg(bsl,tl,sz,qgjb)
{//alert(bsl+tl+sz+qgjb)
    if (!(bsl==1))
       {
       	  alert("'辨色力'不合格者不能申请！");
          return 0;
       }
    if (!(tl==1))
       {
       	  alert("'听力'不合格者不能申请！");
          return 0;
       }
    if (!(sz==1))
       {
       	  alert("'上肢'不合格者不能申请！");
          return 0;
       }
    if (!(qgjb==1))
       {
       	  alert("'躯干颈部'不合格者不能申请！");
          return 0;
       }
 if((document.all["yxz"].value)==0)
 {
   alert("右下肢必须合格！")
   document.all.yxz.focus();
   return 0;
 }
     return 1;
}

//-------------------------------
//  函数名：sfzCheck(hm)
//  功能介绍：对18位长的身份证进行末位校验
//  参数说明：身份证号码
//  返回值  ：1-符合,0-不符合
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
            alert("身份证校验错误！------ 末位应该:"+ls_check+" 实际:"+hm.substr(17,1));
            return 0;
     }
return 1
}

function  comm_check(){
if (document.all["xm"].value.length<2)
{
document.all["xm"].focus();
alert("'姓名'长度至少两汉字！");
return 0;
 }
if (document.all["lxdh"].value.length<6)
{
document.all["lxdh"].focus();
alert("'联系电话'长度至少6位！");
return 0;
 }
return 1;
}

//-------------------------------
//  函数名  ：check_zjcx(s_value，s_cx_dm)
//  参数说明：准驾车型字符串，合法的准驾车行字符串数组。
//  功能介绍：检查车型输入是否正确，只检查是否包含合法的准驾车行字符串，重复、次序颠倒不认为是错误
//  返回值  ：1-包含合法的准驾车行，0-不合法
//
//  戴嘉 2004.05.12
//-------------------------------
function check_zjcx(s_value,s_cx_dm)
{
  	//合法的准驾车行字符串数组
	//var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P");
        //字符串数组的长度
        var s_cx_input;	//存放需要检验的字符串
	var i_pos;	//查找子串定位
        var i;

        s_cx_input=s_value;
	for(i in s_cx_dm)	//对合法准驾车行字符串数组轮循
	{
		do
		{
			i_pos=s_cx_input.indexOf(s_cx_dm[i]);	//是否包含当前车型
			if(i_pos!=-1)	//包含
			{
                          	//去掉找到的子串
				s_cx_input=s_cx_input.slice(0,i_pos)+s_cx_input.slice(i_pos+s_cx_dm[i].length);
			}
		}while(i_pos!=-1);	//找不到当前车型子串，进入下一车型子串查找
	}

	if(s_cx_input.length==0)	//输入字符串包含的都是合法的车型子串（全部被去掉了）
		return 1;
	else	//输入字符串还包含有非法的字符串
		return 0;
}


//-------------------------------
//  函数名：DateAddMonth(strDate,iMonths)
//  功能介绍：获得日期加上iMonths月数后的日期
//  参数说明：strDate 日期
//  返回值  ：无返回值
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
   return(newDay);                                // 返回日期。
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
function findName(event,obj)  //根据代码取名称
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
//自动清除输入框中的空格
function ignoreSpaces(string) {
var temp = "";
string = '' + string;
splitstring = string.split(" "); //双引号之间是个空格；
for(i = 0; i < splitstring.length; i++)
temp += splitstring[i];
return temp;
}
