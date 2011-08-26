<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpSiteList.aspx.cs" Inherits="FpSystem_FpHelper_FpSiteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <asp:Repeater ID="rpSite" runat="server">
     <HeaderTemplate>
       <ul style=" list-style-type:none; float:left;">
     </HeaderTemplate>
     <ItemTemplate>
       <li>
        <% 
            string bustype = Request.Params["bustype"];
            if (bustype == "lesson")
            { 
            
        %>
             <div class="site"><a href="FpIdentityLesson.aspx?site_id=<%# Eval("ID") %>" target="_blank" ><%# Eval("NAME") %></a></div>
        <% }
            else if (bustype == "train")
            { %>
             <div class="site"><a href="FpIdentityTrain.aspx?site_id=<%# Eval("ID") %>" target="_blank" ><%# Eval("NAME") %></a></div>
        <%}
            else if (bustype == "km1" || bustype == "km2" || bustype == "km3")
            { %>
             <div class="site"><a href="FpIdentityExam.aspx?site_id=<%# Eval("ID") %>&bustype=<%=bustype %>" target="_blank" ><%# Eval("NAME") %></a></
        <%} %>
       </li>
     </ItemTemplate>
     <FooterTemplate>
       </ul>
     </FooterTemplate>
  </asp:Repeater>
</asp:Content>

