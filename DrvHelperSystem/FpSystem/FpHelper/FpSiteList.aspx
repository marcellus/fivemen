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
            
             <table class="site">
             <tr>
               <td rowspan="2">
                 <img src="../../images/car.jpg"></img>
               </td>
               <td>
               <table class="site" border="1">
               <tr>
               <td colspan="2" align="center">
               <%# Eval("NAME") %>
               </td>
               </tr>
               <tr>
               <td >业务类型：
               <%# Eval("BUSTYPE") %>
               </td>
               <td>限制人数：
               <%# Eval("LIMIT") %>
               </td>
               </tr>
               </table >
               </td>
               <td>
                 <a href="FpIdentityLesson.aspx?site_id=<%# Eval("ID") %>" target="_blank" >进入</a>
               </td>
             </tr>
             </table>
        <% }
            else if (bustype == "train")
            { %>
             <table class="site">
             <tr>
               <td rowspan="2">
                 <img src="../../images/car.jpg"></img>
               </td>
               <td>
               <table class="site" border="1">
               <tr>
               <td colspan="2" align="center">
               <%#Eval("NAME") %>
               </td>
               </tr>
               <tr>
               <td >业务类型：
               <%#Eval("BUSTYPE") %>
               </td>
               <td>限制人数：
               <%#Eval("LIMIT") %>
               </td>
               </tr>
               </table >
               </td>
               <td>
                 <a href="FpIdentityTrain.aspx?site_id=<%# Eval("ID") %>" target="_blank" >进入</a>
               </td>
             </tr>
             </table>
            
        <%}
            else if (bustype == "km1" || bustype == "km2" || bustype == "km3")
            { %>
             <table class="site" >
             <tr>
               <td rowspan="2" style="width:255px">
                 <img src="../../images/car.jpg"></img>
               </td>
               <td >
               <table class="site" border="1" cellspacing="1" >
               <tr>
               <td colspan="2" align="center">
               <%# Eval("NAME") %>
               </td>
               </tr>
               <tr>
               <td >业务类型：
               <%# Eval("BUSTYPE") %>
               </td>
               <td>限制人数：
               <%# Eval("LIMIT") %>
               </td>
               </tr>
               </table >
               </td>
               <td>
                 <a href="FpIdentityExam.aspx?site_id=<%# Eval("ID") %>&bustype=<%=bustype %>" target="_blank" ><img src="../../images/enter.jpg">进入</a>
               </td>
             </tr>
             </table>
        <%} %>
       </li>
     </ItemTemplate>
     <FooterTemplate>
       </ul>
     </FooterTemplate>
  </asp:Repeater>
</asp:Content>

