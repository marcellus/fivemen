<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TruePaiBanList.aspx.cs" Inherits="DriverPerson_Preasign_TruePaiBanList" %>
<%@ Import Namespace="System.Data" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>实际的天排班+场地排班</title>
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
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    <asp:label runat="server" text="排班表" ID="lbTitle"></asp:label><br />
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="lsh" HeaderText="流水号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="sfzmhm" HeaderText="身份证明号码"></asp:BoundColumn>
                            
                             <asp:BoundColumn DataField="xm" HeaderText="姓名"></asp:BoundColumn>
                             <asp:BoundColumn DataField="kscx" HeaderText="考试车型"></asp:BoundColumn>
                             <asp:BoundColumn DataField="pxshrq" HeaderText="培训审核日期"></asp:BoundColumn>
                            <asp:BoundColumn DataField="kchp" HeaderText="号码号牌"></asp:BoundColumn>
                           
                             <asp:BoundColumn DataField="ykrq" HeaderText="约考日期"></asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="jbr" HeaderText="经办人"></asp:BoundColumn>
                            <asp:BoundColumn DataField="dmmc1" HeaderText="驾校名称"></asp:BoundColumn>
                            
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                 
                    <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
                        BindControlString="DataGrid1">
                    </WC:ProcedurePager>
                 
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
