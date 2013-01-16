<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WeatherShowControl.ascx.cs" Inherits="YuanTuo_UserControlEx_WeatherShowControl" %>
<asp:Panel ID="Panel1"  runat="server" Height="113px" Width="120px" Font-Size="10">
<div style=" margin-top:8px; padding-top:8px;">
    &nbsp; &nbsp;<asp:Label ID="lbCity" Font-Bold="true" Font-Size="15" runat="server" Text="北京" ForeColor="Red" ></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="img1" runat="server" ImageAlign="Bottom" Height="25" Width="25" />
    <div style="text-align:right;  margin-right:2px">
          
          <asp:Label ID="lbTemp" Font-Size="12" runat="server" Text="温度：4-9" Visible="true"></asp:Label>
    </div>
    <div style="height:21px; margin-right:2px">
    <span style="float:left;margin-left:4px"><asp:Label ID="lbDate"  Font-Size="11"  runat="server" Text="12月9日"></asp:Label></span>
   <span style="float:right"><asp:Label ID="lbWeek"  Font-Size="11"  runat="server" Text="星期一"></asp:Label></span>
   </div>
   <div style="margin-top:5px; padding-top:5px; margin-left:4px;">
   <asp:Label ID="lbTrafficLimit"  Font-Bold="true" Font-Size="10" ForeColor="White" runat="server" Text="今日限行"></asp:Label>
   </div>
   <div style="display:none">
    <br />
    &nbsp;&nbsp; <asp:Label ID="lbTempTmp" runat="server" Text="温度：4-9" Visible="false"></asp:Label>
    <br />
   &nbsp; &nbsp; <asp:Label ID="lbWind" runat="server" Text="风向" Visible="false"></asp:Label>
    </div>
    </div>


</asp:Panel>
