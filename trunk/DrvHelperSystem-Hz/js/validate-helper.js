function checkIdCardNo(idValue) {
        var len=0, re;
        len=idValue.length;
        if (len == 15 && isNumberString(idValue,"1234567890"))
        re = new RegExp(/^(\d{6})()?(\d{2})(\d{2})(\d{2})(\d{3})$/);
        else if (len == 18 && isNumberString(idValue,"1234567890xX"))
        re = new RegExp(/^(\d{6})()?(\d{4})(\d{2})(\d{2})(\d{3})(\d)$/);
        else {
        alert("输入的公民身份号码不合法，请重新输入!");
        return false;
        }
        var a = idValue.match(re);
        if (a != null){
            if (len==15){
                var D = new Date("19"+a[3]+"/"+a[4]+"/"+a[5]);
                var B = D.getYear()==a[3]&&(D.getMonth()+1)==a[4]&&D.getDate()==a[5];
            }else{
                var D = new Date(a[3]+"/"+a[4]+"/"+a[5]);
                var B = D.getFullYear()==a[3]&&(D.getMonth()+1)==a[4]&&D.getDate()==a[5];
            }
          if (!B) {
            //alert("输入的公民身份号码 "+ a[0] +" 的日期不合法，请重新输入!");
      alert("输入的公民身份号码不合法，请重新输入!");
            return false;
          }
        }
        if(len == 18 && !verifyGmsfhLast(idValue)){
      //alert("公民身份号码的最后一位校验码不正确('x'应为大写),请检查!");
      alert("输入的公民身份号码不合法，请重新输入!");
            return false;
        }
        return true;
      }
    function verifyGmsfhLast(sVal){
        if(sVal.length != 18) return false;
        var wi = new Array(7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2,1);

        var vi = new Array(1,0,'X',9,8,7,6,5,4,3,2)
        var ai = new Array(17);
        var sum = 0;
        var remaining = 0;
        var verifyNum = "";
        //通过循环把18位身份证的前17位存到数组ai中
        for(var i = 0; i < 17; i++){
            ai[i] = parseInt(sVal.substring(i,i+1));
        }
        for(var m = 0; m < ai.length; m++){
            //加权
            sum = sum + wi[m] * ai[m];
        }
        remaining = sum % 11;
        if(remaining == 2){
            verifyNum = "X";
        }else{
            verifyNum = vi[remaining];
        }
        if(verifyNum != sVal.substring(17,18)){
            return false;
        }else{
            return true;
        }
    }

   /*
    ******************************************************************
    目的  ：判断输入的字符串是否在参考字符串范围之内
    参数  ：InString  : 输入串
 参数  ：RefString : 参考串
    返回值：boolean型变量:true/false
    *******************************************************************
  */
 function isNumberString(InString,RefString){
  if(InString.length==0)
   return false;
  for(Count=0; Count < InString.length; Count++){
   TempChar= InString.substring (Count, Count+1);
   if (RefString.indexOf (TempChar, 0)==-1)
    return false;
  }
  return true;
 }
 
 
 function CheckPhone(s)
  {  
  //alert("待验证的电话号码："+s); 
      var filter=/^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,13})(-(\d{3,}))?$/;   
      if(filter.test(s))
      {
      //不合法时
          return true;
      }
      else
      {  
      alert("对不起，您输入的电话号码不正确！");
           return false;
      }
  } 
  
function CheckPostCode(code)     
{     
//alert("待验证的邮政编码："+code);
       
        if(code.length!=0){    
        reg=/^\d{6}$/;    
        if(!reg.test(code)){    
            alert("对不起，您输入的邮编格式不正确!");//请将“字符串类型”要换成你要验证的那个属性名称！  
             return false;  
        }  
        else
          return true;  
        }  
         return false;  
}  