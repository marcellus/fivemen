<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg_Finger.aspx.cs" Inherits="Reg_Finger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .btn_hidden {display:none;}
    </style>


    
    <script language="javascript" type="text/javascript">
        function AutoEnroll() 
        {
            var stru = document.getElementById("userID").value;
            var strinfo = document.getElementById("info").value;
            var strFin = document.getElementById("Fingers").value;
            var strTmp;
            EnrollForm.UCtrl.SetAgentInfo(strinfo);
            strTmp = EnrollForm.UCtrl.EnrollByPwdExport(stru,strFin,"", 0, 0, "sa", "sa");
            strTmp = UrlEncode(strTmp);
            window.location.href = "addfinger.aspx?strTmp=" + strTmp;
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

</head>
<body onload="return AutoEnroll()">
    <form id="EnrollForm"  runat="server">
    <OBJECT ID="UCtrl" WIDTH=0 HEIGHT=0 CLASSID="CLSID:F84BECA7-1166-44F4-9EAA-38AFD7BF971C">
    <PARAM NAME="IconVisible" VALUE="0">
    <PARAM NAME="DoubleBuffered" VALUE="0">
    <PARAM NAME="Enabled" VALUE="-1">
    <PARAM NAME="Visible" VALUE="-1">
</OBJECT>
     <asp:HiddenField ID="TemplateData_hfld" runat="server" />
     <input type="hidden" name="info" value="<%=AGENT_INFO%>"/>
     <input type="hidden" name="userID" value="<%=USER_ID%>"/>
         <input type="hidden" name="Fingers" value="<%=ENROLLEDFINGERS%>"/>
     <asp:HiddenField ID="username" runat="server" />
       
    </form>
</body>
</html>
