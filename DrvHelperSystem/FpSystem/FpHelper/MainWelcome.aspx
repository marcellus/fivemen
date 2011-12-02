<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainWelcome.aspx.cs" Inherits="FpSystem_FpHelper_MainWelcome" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>指纹验证项目首页</title>

<link  href="../css/main.css" rel="Stylesheet" type="text/css" />

</head>


<body>

    <form id="form1" runat="server">
    <div style=" overflow:visible">
      <table id="tableSite" >
          <%  
              ArrayList sites=ViewState[typeof(FpSite).Name] as ArrayList;
              foreach (string key in FpSite.GetDictBusType().Keys)
              {
                  string val = FpSite.GetDictBusType()[key];             
 
          %>
             <tr>
               <th class="thBustype"><%=val %></th>
               <td  class="tdSites">
                  <% foreach (FpSite site in sites)
                     {
                         if (site.BUSTYPE != key) continue;       
                  %>
                      
                                       <%
                        if (key == "lesson")
                        { 
                    %>
                         <a href="../FpSystem/FpHelper/FpIdentityLesson.aspx?site_id=<%=site.ID %>" target="_top" ><%=site.NAME %></a>
                    
                    <% 
                        }
                        else if (key == "collect"&&1==2) { 
                    %>
                         <a href="../FpSystem/FpHelper/FpRecordCollect2.aspx"><%=site.NAME %></a>
                    <%
                        }
                        else if (key == "train")
                        {
                    %>
                        <a href="../FpSystem/FpHelper/FpIdentityTrain.aspx?site_id=<%=site.ID %>" target="_top" ><%=site.NAME%></a>
                    <%
                        }
                        else if (key == "km1" || key == "km2" || key == "km3" || key == "3in9")
                        {
                    %>
                       <a href="../FpSystem/FpHelper/FpIdentityExam.aspx?site_id=<%=site.ID %>&bustype=<%=key %>" target="_top" ><%=site.NAME%></a>       
                    <% } %> 
                  <%} %>
               </td>
             </tr>
          <%} %>
      </table>
    </div>
    </form>
</body>
</html>
