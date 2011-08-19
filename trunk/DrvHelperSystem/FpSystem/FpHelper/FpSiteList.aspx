<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpSiteList.aspx.cs" Inherits="FpSystem_FpHelper_FpSiteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
  <asp:Repeater ID="rpSite" runat="server">
     <HeaderTemplate>
       <ol type=1>
     </HeaderTemplate>
     <ItemTemplate>
       <li>
        <% 
            string bustype = Request.Params["bustype"];
            if (bustype == "lesson")
            { 
            
        %>
             <a href="FpIdentityLesson.aspx?site_id=<%# Eval("ID") %>" target="_blank" ><%# Eval("NAME") %></a>
        <% }
            else if (bustype == "train")
            { %>
             <a href="FpIdentityTrain.aspx?site_id=<%# Eval("ID") %>" target="_blank" ><%# Eval("NAME") %></a>
        <%}
            else if (bustype == "km1" || bustype == "km2" || bustype == "km3")
            { %>
             <a href="FpIdentityExam.aspx?site_id=<%# Eval("ID") %>&bustype=<%=bustype %>" target="_blank" ><%# Eval("NAME") %></a>
        <%} %>
       </li>
     </ItemTemplate>
     <FooterTemplate>
       </ol>
     </FooterTemplate>
  </asp:Repeater>
</asp:Content>

