<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Finger_As_PWD.aspx.cs" Inherits="Finger_As_PWD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
      function AutoVerify() 
          {
              var stru = document.getElementById("userID").value;
              var strinfo = document.getElementById("info").value;

              var strFin = document.getElementById("Fingers").value;

              var strTmp;
              
              VerifyForm.UCtrl.SetAgentInfo(strinfo);
              strTmp = VerifyForm.UCtrl.AuthenDlgExport(stru, strFin, 0);
              strTmp = UrlEncode(strTmp);
              window.location.href = "Verify.aspx?strTmp=" + strTmp
          }
      function UrlEncode(str) 
          {
              var ret = "";
              var strSpecial = "!\"#$%&'()*+,/:;<=>?[]^`{|}~%";
              for (var i = 0; i < str.length; i++) 
              {
                  var chr = str.charAt(i);
                  var c = str2asc(chr);
                  if (parseInt("0x" + c) > 0x7f)
                  {
                      ret += "%" + c.slice(0, 2) + "%" + c.slice(-2);
                  } else 
                  {
                      if (chr == " ")
                          ret += "+";
                      else if (strSpecial.indexOf(chr) != -1)
                          ret += "%" + c.toString(16);
                      else
                          ret += chr;
                  }
              }
              return ret;
          }
      function UrlDecode(str) 
          {
              var ret = "";
              for (var i = 0; i < str.length; i++) 
              {
                  var chr = str.charAt(i);
                  if (chr == "+") 
                  {
                      ret += " ";
                  }
                  else if (chr == "%") 
                  {
                      var asc = str.substring(i + 1, i + 3);
                      if (parseInt("0x" + asc) > 0x7f) 
                      {
                          ret += asc2str(parseInt("0x" + asc + str.substring(i + 4, i + 6)));
                          i += 5;
                      }
                      else 
                      {
                          ret += asc2str(parseInt("0x" + asc));
                          i += 2;
                      }
                  }
                  else 
                  {
                      ret += chr;
                  }
              }
              return ret;
          } 
     </script>
     <script language="vbscript"> 
            Function str2asc(strstr) 
            str2asc = hex(asc(strstr)) 
            End Function 
            Function asc2str(ascasc) 
            asc2str = chr(ascasc) 
            End Function 

    </script>
    <style type="text/css">
        .btn_hidden {display:none;}
    </style>
</head>
<body onload="return AutoVerify()">
    <form id="VerifyForm" runat="server">
    <object id="UCtrl" width="97" height="104" classid="CLSID:DFA34C41-D461-480A-B598-854A99C90392">
    
    </object>
        <asp:HiddenField ID="TemplateData_hfld" runat="server" />
         <input type="hidden" name="info" value="<%=AGENT_INFO%>"/>
         <input type="hidden" name="userID" value="<%=USER_ID%>"/>
         <input type="hidden" name="Fingers" value="<%=ENROLLEDFINGERS%>"/>
    
    </form>
</body>
</html>
