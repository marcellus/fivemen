<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaSearch.aspx.cs" Inherits="DriverPerson_Apply_AreaSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地区查询窗口</title>
    <meta content="no-cache" http-equiv="pragma">
    <script type="text/javascript">
    function CloseSelfWin()
    {
      //alert("123");
      
    var prov=document.getElementById("ddlProvince");
    //alert(prov);
    var city=document.getElementById("ddlCity");
      var area=document.getElementById("ddlArea");
       //var value=sel.options[area.selectedIndex].value;
      // alert(prov.options[prov.selectedIndex].text);
       var text=prov.options[prov.selectedIndex].text.split("：")[1]+
       city.options[city.selectedIndex].text.split("：")[1]+
       area.options[area.selectedIndex].text.split("：")[1];
       //alert(text);
        window.returnValue = area.options[area.selectedIndex].text+"|"+area.options[area.selectedIndex].value+"|"+text;   
        window.opener=null;
        window.close();   
    
    }
    </script>
     <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server" style="text-align:center; margin-top:15px">
    <div style="">
    <table style="text-align:left;" width="600px">
    <tr>
    <td>
    代码<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
    &nbsp;名称<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="查询" onclick="Button3_Click" />
    
    </td>
    </tr>
    <tr>
    <td>省份<asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlProvince_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
       市级<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlCity_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    
        地区<asp:DropDownList ID="ddlArea" runat="server">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td style="text-align:center">
        <input id="Button1"  onclick="CloseSelfWin()" type="button" value="确定" />
        &nbsp;<input id="Button2" type="button" value="取消" />
    </td>
    </tr>
    
    </table>
    </div>
    </form>
</body>
</html>
