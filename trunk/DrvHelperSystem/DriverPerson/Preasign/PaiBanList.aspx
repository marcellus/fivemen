<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaiBanList.aspx.cs" Inherits="DriverPerson_Preasign_PaiBanList" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>天排班+场地排班</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/setday.js"></script>
    <style media="print">
        .Noprint{display:none;}
        .PageNext{page-break-after: always;}
    </style>
    <script type="text/javascript" >
    function printview()
    {
    //document.all.WebBrowser.Document.Frames(3).ExecWB(7,1)
    }
    
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div class="Noprint"> 
     查看日期&nbsp; 
        <input  onclick="setday(this)"  id="txtDate" runat="server" />
<br />地点&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbKsdd" runat="server" Font-Size="15pt">
        </asp:DropDownList>
场次&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbKscc" runat="server" Font-Size="15pt">
        </asp:DropDownList>
       &nbsp;&nbsp; 科目 
        <asp:DropDownList ID="cbKm" runat="server" Font-Size="15pt">
            <asp:ListItem Value="1">科目一</asp:ListItem>
            <asp:ListItem Value="2">科目二</asp:ListItem>
            <asp:ListItem Value="3">科目三</asp:ListItem>
        </asp:DropDownList>
&nbsp; <br />查看类别<asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            EnableTheming="False" RepeatColumns="2" RepeatLayout="Flow">
            <asp:ListItem Selected="True" Value="0">天排班</asp:ListItem>
            <asp:ListItem Value="1">场排班</asp:ListItem>
        </asp:RadioButtonList>
&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="查看" onclick="btnSubmit_Click" />
<object id="WebBrowser" width=0 height=0 classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">   
</object> 
&nbsp;<input   type="button"   onclick= "window.print() "   value= "打印该页 "   id="pr" />
<input type="button" id="btnpriview" onclick="document.all.WebBrowser.ExecWB(7,1)" value="打印预览" />


    </div>
    <div>
       
    <asp:Repeater id="parentRepeater" runat="server">
    <headertemplate>
<table border="1" cellpadding="4" cellspacing="0" class="table-border">
</headertemplate>

      <itemtemplate>
      <tr class="table-content"><td>
      <div style="color:Red; font-size:15px">
          <%# DataBinder.Eval(Container.DataItem,"date_ksrq") %>
           &nbsp;<%# DataBinder.Eval(Container.DataItem,"c_school_name") %>
            &nbsp;总人数&nbsp;<%# DataBinder.Eval(Container.DataItem,"total") %>
             &nbsp;已用&nbsp;<%# DataBinder.Eval(Container.DataItem,"used") %>
              &nbsp;已审核&nbsp;<%# DataBinder.Eval(Container.DataItem,"checked") %>
        <br />
         &nbsp;<%# DataBinder.Eval(Container.DataItem,"c_ksdd") %>
           &nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem,"c_kscc") %>
            &nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem,"c_km") %>
            
        <br />
        </div>
                <!-- 子Repeater开始 -->
                <asp:Repeater id="childRepeater" runat="server" 
    	            datasource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("myrelation") %>'>
    	            
    	          <headertemplate>
<table border="1" cellpadding="4" cellspacing="0" class="table-border">
<tr class="table-content">
<td class="table-title">流水号</td>
<td class="table-title">身份证明号码</td>
<td class="table-title">姓名</td>

<td class="table-title">培训审核日期</td>
<td class="table-title">号码号牌</td>
<td class="table-title">经办人</td>
<td class="table-title">审核结果</td>
</tr>
</headertemplate>

                  <itemtemplate>
                    <tr class=" table-content">
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"c_lsh\"]")%>
                    </td>
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"c_idcard\"]")%>
                    </td>
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"c_xm\"]")%>
                    </td>
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"date_pxshrq\"]")%>
                    </td>
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"c_hmhp\"]")%>
                    </td>
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"c_jbr\"]")%>
                    </td>
                    <td>
                     <%# DataBinder.Eval(Container.DataItem, "[\"i_checked\"]")%>
                    </td>
                    </tr>
                  </itemtemplate>
                 <footertemplate>
                    </table>
                 </footertemplate>

                </asp:Repeater>
                </td>
        </tr>
                <!-- 子Repeater结束 -->
      </itemtemplate>
      <footertemplate>
        </table>
      </footertemplate>

    </asp:Repeater>

    
    </div>
    </form>
</body>
</html>
