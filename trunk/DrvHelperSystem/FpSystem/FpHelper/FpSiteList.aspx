<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpSiteList.aspx.cs" Inherits="FpSystem_FpHelper_FpSiteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <asp:Repeater ID="rpSite" runat="server">
     <HeaderTemplate>
       <table class="table-border"  style=" width:100%" cellspacing="1">
     </HeaderTemplate>
     <ItemTemplate>
        <% 
            string bustype = Request.Params["bustype"];
        %>
        
         <tr class="table-content">
               <td rowspan="2"  style="width:250px; height:180px;">
                 <img  style=" height:180px;" src="../../images/site.jpg"></img>
               </td>
          

               <td colspan="2" align="center">
                      <span style=" font-size:2.0em; font-weight:bolder"> <%# Eval("NAME") %> </span>
               </td>
          
               <td rowspan="2" style=" text-align:center; vertical-align:middle ">      
                    <%
                        if (bustype == "lesson")
                        { 
                    %>
                         <a href="FpIdentityLesson.aspx?site_id=<%# Eval("ID") %>" target="_blank" ><img src="../../images/enter.jpg">进入</a>
                    
                    <% 
                        } else if (bustype == "train"){
                    %>
                        <a href="FpIdentityTrain.aspx?site_id=<%# Eval("ID") %>" target="_blank" ><img src="../../images/enter.jpg">进入</a>
                    <%
                        }else if (bustype == "km1" || bustype == "km2" || bustype == "km3"||bustype=="3in9"){
                    %>
                       <a href="FpIdentityExam.aspx?site_id=<%# Eval("ID") %>&bustype=<%=bustype %>" target="_blank" ><img src="../../images/enter.jpg">进入</a>       
                    <% } %>
              </td>
         </tr>
         
         <tr class="table-content">
                <td style=" padding-left:5%; font-size:1.2em;" >业务类型：
                       <%# Eval("BUSTYPE") %>
                 </td>
                <td style=" padding-left:5% ;font-size:1.2em;" >限制人数：
                       <%# Eval("LIMIT") %>
                </td>
         </tr>
     </ItemTemplate>
     <FooterTemplate>
       </table>
     </FooterTemplate>
  </asp:Repeater>
</asp:Content>

