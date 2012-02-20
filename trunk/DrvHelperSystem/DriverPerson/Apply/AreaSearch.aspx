<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaSearch.aspx.cs" Inherits="DriverPerson_Apply_AreaSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地区查询窗口</title>
    <meta content="no-cache" http-equiv="pragma">
       <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
       <script type="text/javascript" src="../../js/jquery-easyui-1.2.3/jquery-1.4.4.min.js" ></script>
    <style>
    
      tr.q
      {
        cursor:pointer;
      }
      
      tr.q:hover
      {
      	background-color:Yellow;
      }
    
    </style>
    <script type="text/javascript">
    
    
    $(document).ready(function(){
     
       $("tr.q").click(function(){
         var sf=$(this).find("td:eq(0)").text();
         var cs=$(this).find("td:eq(1)").text();
         var dmz=$(this).find("td:eq(2)").text();
         var dmmc1=$(this).find("td:eq(3)").text();
        window.returnValue = sf+"|"+cs+"|"+dmz+"|"+dmmc1;   
        window.opener=null;
        window.close();   
       });
     
    });
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
    <form id="form1" runat="server" style="text-align:center; margin-top:0px">
    <div style="">
    <table style="text-align:left; padding:0px; vertical-align:top"  >
    <tr>
    <td>
    输入查询区划名或代码:<asp:TextBox ID="txtCode" runat="server" Width="240px"  
            ></asp:TextBox>
    <asp:Button  Text="查询" ID="btnSearch" runat="server" onclick="btnSearch_Click" />
    </td>
    </tr>
    
    <tr>
      <td>
        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="sf" HeaderText="省份"></asp:BoundColumn>
                             <asp:BoundColumn DataField="cs" HeaderText="城市"></asp:BoundColumn>
                            <asp:BoundColumn DataField="dmz" HeaderText="代码值"></asp:BoundColumn>
                             <asp:BoundColumn DataField="dmsm1" HeaderText="区名"></asp:BoundColumn>
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content q" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
      </td>
    </tr>
    
    </table>
    
    
    
    
    </div>
    </form>
</body>
</html>
