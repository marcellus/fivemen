//打发上发�?
function isChinese(obj){
    srcLen=obj.length;
    theLen = lenX(obj);    
    if(theLen ==srcLen){
    	return false
    }else{
    	return  true;	
	}
    //return (theLen ==srcLen) ? false: true;	
}

//
function lenX(obj){
    theLen = 0;
    for( i = 0; i < obj.length; i++)
    {       
       if (obj.charCodeAt(i) > 255 ){  
          theLen=theLen + 2;
       }else{
          theLen=theLen + 1;
       }    
    }
    return theLen;	
}

//??
//true ??????????false??????????
function overLength(obj,leng)
{    
   if(lenX(obj)> leng){
      return true	
   }
   return false;
}

function chkObj(pObj,max,nullMsg,lenMsg)
{
	if(isEmpty(pObj,nullMsg)&&isOverLength(pObj,max,lenMsg))
	{
		return true;
	}else{
		return false;
	}
	
}

function Trim(str){
 if(str.charAt(0) == " "){
  str = str.slice(1);
  str = Trim(str); 
 }
 return str;
}
//????????????
function isOverLength(pObj,max,errMsg){
 var obj = eval(pObj);
 if( obj == null || Trim(obj.value) == ""){
  return true;
 }else if(Trim(obj.value).length>max){
 if (errMsg == null || errMsg =="")
   alert("????????!");
  else
   alert(errMsg); 
  obj.focus(); 
  return false;
}
 return true;
}
//????????????
function isEmpty(pObj,errMsg){
 var obj = eval(pObj);
 if( obj == null || Trim(obj.value) == ""){
  if (errMsg == null || errMsg =="")
   alert("????????!");
  else
   alert(errMsg); 
  obj.focus(); 
  return false;
 }
 return true;
}
//??????????????
function isNumber(pObj,errMsg){
 var obj = eval(pObj);
 strRef = "1234567890";
 if(!isEmpty(pObj,errMsg))return false;
 for (i=0;i<obj.value.length;i++) {
  tempChar= obj.value.substring(i,i+1);
  if (strRef.indexOf(tempChar,0)==-1) {
   if (errMsg == null || errMsg =="")
    alert("??????????????,??????");
   else
    alert(errMsg);
   if(obj.type=="text") 
    obj.focus(); 
   return false; 
  }
 }
 return true;
}

//??????????????,??????????????
function isNegative(pObj,errMsg){
 var obj = eval(pObj);
 strRef = "1234567890-";
 if(!isEmpty(pObj,errMsg))return false;
 for (i=0;i<obj.value.length;i++) {
  tempChar= obj.value.substring(i,i+1);
  if (strRef.indexOf(tempChar,0)==-1) {
   if (errMsg == null || errMsg =="")
    alert("??????????????,??????");
   else
    alert(errMsg);
   if(obj.type=="text") 
    obj.focus(); 
   return false; 
  }else{
   if(i>0){
    if(obj.value.substring(i,i+1)=="-"){
     if (errMsg == null || errMsg =="")
      alert("??????????????,??????");
     else
      alert(errMsg);   
     if(obj.type=="text") 
     obj.focus(); 
     return false; 
    }
   }
  }
 }
 return true;
}


//??????????????????
function isMoney(pObj,errMsg){
 var obj = eval(pObj);
 strRef = "1234567890.";
 if(!isEmpty(pObj,errMsg)) return false;
 for (i=0;i<obj.value.length;i++) {
  tempChar= obj.value.substring(i,i+1);
  if (strRef.indexOf(tempChar,0)==-1) {
   if (errMsg == null || errMsg =="")
    alert("??????????????,??????");
   else
    alert(errMsg);   
   if(obj.type=="text") 
    obj.focus(); 
   return false; 
  }else{
   tempLen=obj.value.indexOf(".");
   if(tempLen!=-1){
    strLen=obj.value.substring(tempLen+1,obj.value.length);
    if(strLen.length>2){
     if (errMsg == null || errMsg =="")
      alert("??????????????,??????");
     else
      alert(errMsg);   
     if(obj.type=="text") 
     obj.focus(); 
     return false; 
    }
   }
  }
 }
 return true;
}

function isLeapYear(year) 
{ 
 if((year%4==0&&year%100!=0)||(year%400==0)) 
 { 
 return true; 
 }  
 return false; 
} 

//????????????????

function isDate(checktext){
var datetime;
var year,month,day;
var gone,gtwo;
if(Trim(checktext.value)!=""){
 datetime=Trim(checktext.value);
 if(datetime.length==10){
  year=datetime.substring(0,4);
  if(isNaN(year)==true){
   alert("??????????!??????(yyyy-mm-dd) \n??(2001-01-01)??");
   checktext.focus();
   return false;
  }
  gone=datetime.substring(4,5);
  month=datetime.substring(5,7);
  if(isNaN(month)==true){
   alert("??????????!??????(yyyy-mm-dd) \n??(2001-01-01)??");
   checktext.focus();
   return false;
  }
  gtwo=datetime.substring(7,8);
  day=datetime.substring(8,10);
  if(isNaN(day)==true){
   alert("??????????!??????(yyyy-mm-dd) \n??(2001-01-01)??");
   checktext.focus();
   return false;
  }
  if((gone=="-")&&(gtwo=="-")){
   if(month<1||month>12) { 
    alert("??????????01??12????!"); 
    checktext.focus();
    return false; 
    } 
   if(day<1||day>31){ 
    alert("??????????01??31????!");
    checktext.focus(); 
    return false; 
   }else{
    if(month==2){  
     if(isLeapYear(year)&&day>29){ 
       alert("????????????????01??29????!"); 
       checktext.focus();
       return false; 
     }       
     if(!isLeapYear(year)&&day>28){ 
       alert("????????????????01??28????!");
       checktext.focus(); 
       return false; 
     } 
    } 
    if((month==4||month==6||month==9||month==11)&&(day>30)){ 
     alert("?????????????????????? \n??????????01??30????!");
     checktext.focus(); 
     return false; 
    } 
   }
  }else{
   alert("??????????!??????(yyyy-mm-dd) \n??(2001-01-01)");
   checktext.focus();
   return false;
  }
 }else{
  alert("??????????!??????(yyyy-mm-dd) \n??(2001-01-01)");
  checktext.focus();
  return false;
 }
}else{
 return true;
}
return true;
}

function isEmail(pObj,errMsg)
{
	 var obj = eval(pObj);
	 if( obj == null || Trim(obj.value) == ""){
		  return true;
	 }else{
	 	var email = Trim(obj.value);	 	
	 	var index1 = email.indexOf("@");	 	 
	 	if( email.lastIndexOf('.')  == email.length -1 ){
	 		alertMsg(errMsg);
	 		obj.focus(); 
	  		return false;
	 	}	 	
	 	
	 	if(index1<=0){
	 		alertMsg(errMsg);
	 		obj.focus(); 
	  		return false;
	  	}else{
			var index2 = email.indexOf(".",index1+1);
	 		if(index2<=index1+1){
		 		alertMsg(errMsg);
		 		obj.focus();
		 		return false;
		 	}	  		
	 	}	 	
	 	
	}  
    return true;
}

function alertMsg(errMsg){
 if (errMsg == null || errMsg =="")
   alert("????????!");
  else
   alert(errMsg); 
}

function moveOption(srcObj,targetObj){
        len  = srcObj.options.length;
        arr = new Array();
        index=0;
        for(var i=0;i<len;i++)
        {
                if(srcObj.options[i].selected)
                {
                        arr[index++]=new Array(srcObj.options[i].text,srcObj.options[i].value);
                }
        }
        for(var i=0;i<arr.length;i++)
        {
                a = arr[i];
                addOption(targetObj,a[0],a[1]);
        }
        removeOption(srcObj);
}

function removeOption(obj){
        len  = obj.options.length;
        arr = new Array();
        index=0;
        for(var i=0;i<len;i++)
        {
                if(!obj.options[i].selected)
                {
                        arr[index++] = new Array(obj.options[i].text,obj.options[i].value);
                }
        }
        for(var i=len-1;i>=0;i--){
                if(i<arr.length){
                        obj.options[i] = new Option(arr[i][0],arr[i][1]);
                }else{
                        obj.options[i] =null;
                }
        }

}

function selectAll(obj){
        len  = obj.options.length;
        for(var i=0;i<len;i++)
        {
                obj.options[i].selected=true;
        }
}
function addOption(obj,text,value){
        len = obj.options.length;
        if(value!=""){
                obj.options[len]= new Option(text,value);
        }
}

function moveAllOption(srcObj,targetObj){
        selectAll(srcObj);
        moveOption(srcObj,targetObj);
}

function onlyNumber(){
	if(event.keyCode<48||event.keyCode>57){
		return false;
	}else {
		return true;
	}
}

function selectOption(obj,value){
	obj.value = value;
}

//????????????????
function Jump(Item,evt)
{
	var CharCode=(window.Event)? evt.which:evt.keyCode;
	
	if(CharCode==13)
	{
    	Item.focus();
	}
}

function CheckKit(Item,evt)
{
	var CharCode=(window.Event)? evt.which:evt.keyCode;

	if((CharCode>31)&&(CharCode<48||CharCode>57))
	{
    	return(false);
	}	
  	else
	if(CharCode==13)
	{
    	Item.focus();
	}	
	
	return(true);
}

function trim(s)
{
	if (s == null) return "";
	var i;
	
	//????????????
	for (i=0;i<s.length;i++)
	{
		if (s.charAt(i) != " ") break;
	}
	s = s.substring(i,s.length);

	//????????????
	for (i=s.length-1;i>=0;i--)
	{
		if (s.charAt(i) != " ") break;
	}
	s = s.substring(0,i+1);
	
	if (s == null) s = "";
	return s;
}

function GetStrLen(str)
{  
	var s,n=0;
	
	for(var i=0;i<str.length;i++)
	{
		s=str.substring(i,i+1);
		if(s<="~") 
		{
			n+=1;
		}	
		else
		{
			n+=2;
		}	
	}	
	
	return n;
}

function InputFix(eSrc)
{
	eSrc.focus();
	eSrc.select();
}

function avoidChineseInput()
{
	if(event.keyCode<7 || event.keyCode>57 && event.keyCode<96 || event.keyCode>105)
	{
    event.returnValue = false;
  }
}
function IsDigit(cCheck)      
{      
	return ((('0'<=cCheck) && (cCheck<='9')) || cCheck=='.');      
}    
//????RADIO????????
function conf(obj){
   var j=0;
	for ( i = 0; i < obj.elements.length; i ++ )
	{
		if ( obj.elements[i].type == "radio" && obj.elements[i].checked )
		{
			j=j+1;
		}
	}
	if (j <1 )
	{
		alert ( "??????????????????" );
		return false;
	}
	return true;
}