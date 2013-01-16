<%@ Page Language="C#" MasterPageFile="~/Layout/YuanTuoSearch.master" AutoEventWireup="true" CodeFile="SendSmsToUser.aspx.cs" Inherits="YuanTuo_SendSmsToUser" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="../js/jquery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="display:none">
    <input id="hidId" runat="server" type="hidden" />
                                            <object id="printer" classid="clsid:{8047878A-E370-4987-85CA-9CCADB83126E}" width="320"
                                                height="240">
                                            </object>
                                            <input type="button" value="测试打印" onclick="javascript:PrintContent();" />
</div>
<script type="text/javascript" >
function setHint(value)
{

var hint=document.getElementById("spanHint");
hint.innerHTML=value;
}

function btnValidCode_onclick() {
 var btn=document.getElementById("ctl00_ContentPlaceHolder1_btnSure");
 btn.click();
}

function setValidError()
{
var hint=document.getElementById("spanHintValidCode");
hint.innerHTML="验证码验证失败，请重新输入！";
document.getElementById('ctl00_ContentPlaceHolder1_txtValidCode').value="";
 document.getElementById("btnValidCode").disabled=false;
  
}
function sendsms()
{

    var mobile=document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value;
    var btn=document.getElementById("btnsendsms");
    if(!$("#ctl00_ContentPlaceHolder1_txtMobile").val().match(/^1[3|4|5|8][0-9]\d{8}$/)){
    
    setHint("非有效手机号码，请重新输入！");
    document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value="";
    //document.getElementById("txtMobile").click();
    return;
    }
    setHint("验证码发送中…");
    //btn.value="正在发送...";
    btn.disabled=true;
    setTimeout("ajaxRequest();",2000);
    
}

function ajaxRequest()
{
var mobile=document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value;
    var btn=document.getElementById("btnsendsms");
$.ajax
    (
    {
        type: "get",
        url: "SendSmsInterface.aspx?mobile="+mobile,
        beforeSend: function(XMLHttpRequest){
        //ShowLoading();
        //alert("before send ajax");
        },
        success: function(data)
            {
            //alert("success");
           // alert(data.result);
        //$(".ajax.ajaxResult").html("");
        //$("item",data).each(function(i, domEle){
        //$(".ajax.ajaxResult").append("<li>"+$(domEle).children("title").text()+"</li>");
        //var dataObj=eval("("+data+")");
       // alert(dataObj);
          //alert(dataObj.result);
         //});
         if(data.result=="Success")
         {
         setHint("短信已发送，请收取并填入验证码框！");
        // alert(document.getElementById("btnValidCode"));
        // alert(document.getElementById("btnValidCode").disabled);
         document.getElementById("btnValidCode").disabled=false;
         }
         else{
         setHint("短信发送失败！");
         }
        },
     complete: function(XMLHttpRequest, textStatus){
    //HideLoading();
    //alert("complete ajax!");
     btn.value="确认";
    btn.disabled=false;
        },
      //  error: function()
      //  {
    //请求出错处理
   // alert("error ajax");
      //  }
      error: function(XMLHttpRequest, textStatus, errorThrown) {
                       // alert(XMLHttpRequest.status);
                       // alert(XMLHttpRequest.readyState);
                        alert(textStatus);
                    }
    });
}


</script>
<table  border="0" cellpadding="0" cellspacing="0"  style=" table-layout:fixed; vertical-align:top; " ><tr
><td style="width:100px">&nbsp;
&nbsp;
&nbsp;
&nbsp;</td><td style="vertical-align:top;">

<table width="100%" border="0" align="center" style="vertical-align:top">
<tr><td style="vertical-align:top">
<span style="padding-bottom:15px; font-family:宋体; line-height:40px;font-size:26pt;  color:#5d6a70">为了更好的为您服务，请输入手机号验证！</span>
<br />
<input type="text" maxlength="11" onclick="javascript:showKeyboard(this);" value="" style="width:400px;height:73px;line-height:73px;font-size:32pt; border:solid 1px black; " runat="server" id="txtMobile"/>
    &nbsp;<input type="button" id="btnsendsms" onclick="sendsms();" value="确认" 
        style="background-image:url('images/btnSmsSendSure.png');width: 124px; height: 80px; background-color:#f1cf75;border:0px; line-height:80px; font-size:26pt; font-weight:bold" />&nbsp;&nbsp;
<span id="spanHint" style="font-size:21pt;color:red;font-family:楷体;"></span>
    <br />
    <span  style="padding-bottom:15px;font-family:宋体; line-height:40px;font-size:26pt; color:#5d6a70">
    请输入验证码！</span>

<br />
    <asp:TextBox ID="txtValidCode" BorderStyle="Solid" BorderWidth="1" MaxLength="4"  runat="server" Height="73px"  Width="400px" 
        Font-Size="32pt"></asp:TextBox>&nbsp;
        <input type="button" id="btnValidCode" disabled="disabled" value="确认" 
        style=" background-image:url('images/btnSmsSendSure.png');width:124px; height: 80px;  border:0px; line-height:80px; font-size:26pt; font-weight:bold" onclick="return btnValidCode_onclick()" />
        &nbsp;&nbsp;
<span id="spanHintValidCode" style="font-size:21pt;color:red;font-family:楷体;"></span>
        
       
<div style="display:none">
    <asp:Button ID="btnSure" runat="server" onclick="btnSure_Click" Text="Button" />
        
   </div>    

</td></tr>


</table> 


</td></tr></table>


<div  id="numberkeyboard" style="margin-left:30px;background-color:Olive;width:270px;display:none; position:absolute">
<TABLE border="0"> 
 
<TR> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 7 " onclick="funKey('7');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 8 " onclick="funKey('8');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 9 " onclick="funKey('9');"></TD> 
</TR> 
<TR> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 4 " onclick="funKey('4');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 5 " onclick="funKey('5');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 6 " onclick="funKey('6');"></TD> 

</TR> 
<TR> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 1 " onclick="funKey('1');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 2 " onclick="funKey('2');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 3 " onclick="funKey('3');"></TD> 

</TR> 
<TR> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 0 " onclick="funKey('0');"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value="清空" onclick="clearInput();"></TD> 
<TD align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value="确定" onclick="cancelKey();"></TD> 
 
</TR> 
</TABLE> 
</div>
<SCRIPT  type="text/javascript"> 
<!-- 
var showFlag = false; 

function funKey(cmd){ 
    if(txtObj)
    {
        var obj =  txtObj; 
      //  alert(txtObj.value.length);
       // alert(txtObj.attributes["maxLength"].value);
        if(txtObj.value.length<txtObj.attributes["maxLength"].value)
        {
        obj.value = obj.value + cmd; 
        }
    }
} 
var txtObj=null;
function showKeyboard(obj)
{
txtObj=obj;
var left = obj.offsetLeft;
            var top = obj.offsetTop;
            var width = obj.offsetWidth ;
            var height = obj.offsetHeight ;
           //alert(width);
          // alert(height)
            while(obj = obj.offsetParent){
                left += obj.offsetLeft-30;
                top += obj.offsetTop;
            }
             left += width+180;
            //top += height-80;
           // alert(left);
           // alert(top);
var keyboard=document.getElementById("numberkeyboard");
keyboard.style.display="";
keyboard.style.left = left;
    keyboard.style.top = top;
    keyboard.style.zIndex = 1000;
document.getElementById("txtOrderNum").value="";

}
function clearInput()
{
//alert(txtObj);
   if(txtObj)
   {
       txtObj.value="";
   }
}

function cancelKey()
{

var keyboard=document.getElementById("numberkeyboard");
//alert(keyboard);
keyboard.style.display="none";

}



//--> 
</SCRIPT> 

</asp:Content>

