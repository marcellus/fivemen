<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusRecord.aspx.cs" Inherits="DriverPreson_Hospital_BusRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>体检录入</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                                        体检录入
                </td>
            </tr>
            <tr class="table-title" style=" text-align:left">
            <td>查询条件</td>
            </tr>
            <tr class="table-content"><td>
    
        <table style="width:100% "  border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-content">
                <td >
                    证件名称：<asp:DropDownList ID="cbIdCardType" runat="server" 
                Width="165px" Font-Size="15pt">
                    </asp:DropDownList>
                </td>
                <td>
                    证件号码：<asp:TextBox ID="txtIdCard" runat="server" 
                Width="173px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td >
                    档案编号：<asp:TextBox ID="txtDabh1" runat="server" 
                Width="41px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtDabh2" runat="server" Width="114px"></asp:TextBox>
                </td>
                <td>
                    业务类型：<asp:DropDownList ID="cbBusType" runat="server" 
                Width="170px" Font-Size="15pt">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
       
  
</td></tr>
 <tr class="table-title" style=" text-align:left">
            <td>体检详细信息</td>
            </tr>
    <tr  class="table-content"><td>
       
        
            <table style="width:100%;"  border="0" cellpadding="4" cellspacing="1" class="table-border">
                <tr class="table-content">
                    <td  class="table-title" width="80px">
                        证件名称</td>
                    <td >
                        <asp:Label ID="lbIDCardType" runat="server"></asp:Label>
                    </td>
                    <td class="table-title" width="80px">
                        证件号码</td>
                    <td width="120px">
                        <asp:Label ID="lbIdCard" runat="server"></asp:Label>
                    </td>
                    <td class="table-title" width="80px">
                        档案编号</td>
                    <td width="160px">
                        <asp:Label ID="lbDabh" runat="server"></asp:Label>
                    </td>
                    <td rowspan="4">
                        <asp:Image ID="imgPerson" runat="server" Height="160px" Width="133px" 
                            BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        姓名</td>
                    <td>
                        <asp:Label ID="lbXm" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        性别</td>
                    <td>
                        <asp:Label ID="lbSex" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        出生日期</td>
                    <td>
                        <asp:Label ID="lbBrithday" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        国籍</td>
                    <td>
                        <asp:Label ID="lbNation" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        准驾车型</td>
                    <td>
                        <asp:Label ID="lbLearnCar" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        体检日期</td>
                    <td>
                        <asp:Label ID="lbCheckDay" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidLsh" runat="server" />
                    </td>
                    
                </tr>
                 <tr class="table-content">
                    <td class="table-title">
                        登记住所</td>
                    <td colspan="5">
                        <asp:DropDownList ID="cbRegArea" runat="server" Height="16px" Width="130px">
                        </asp:DropDownList> &nbsp;&nbsp;
                        <asp:TextBox ID="txtRegArea" runat="server" Width="350px"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        邮政编码</td>
                    <td>
                        <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
                    </td>
                    <td class="table-title">
                        联系电话</td>
                    <td colspan="4">
                      
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        备注</td>
                    <td colspan="6">
                        <asp:Label ID="lbDescription" runat="server"></asp:Label>
                    </td>
                    
                </tr>
               
            </table>
        <br />
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
        <tr class="table-content">
        
        <td class="table-title"> 身高(cm)</td>
         <td>
             <asp:TextBox ID="txtHeight" runat="server" Width="50px"></asp:TextBox>
                                </td>
          <td class="table-title">视力</td>
           <td>左<asp:TextBox ID="txtZsl" runat="server" Width="27px"></asp:TextBox>
               右<asp:TextBox ID="txtYsl" runat="server" Width="29px"></asp:TextBox>
                                </td>
            <td class="table-title">辨色力</td>
             <td>
                 <asp:DropDownList ID="cbBsl" runat="server">
                     <asp:ListItem Value="1">合格</asp:ListItem>
                     <asp:ListItem Value="0">不合格</asp:ListItem>
                 </asp:DropDownList>
                                </td>
              <td class="table-title">听力</td>
               <td>
                   <asp:DropDownList ID="cbTl" runat="server">
                      <asp:ListItem Value="1">合格</asp:ListItem>
                     <asp:ListItem Value="0">不合格</asp:ListItem>
                   </asp:DropDownList>
                                </td>
        
        </tr>
        
        <tr class="table-content">
        
        <td class="table-title"> 上肢</td>
         <td>
             <asp:DropDownList ID="cbSz" runat="server">
                <asp:ListItem Value="1">合格</asp:ListItem>
                     <asp:ListItem Value="0">不合格</asp:ListItem>
             </asp:DropDownList>
                                </td>
          <td class="table-title">左下肢</td>
           <td>
               <asp:DropDownList ID="cbZxz" runat="server">
                  <asp:ListItem Value="1">合格</asp:ListItem>
                     <asp:ListItem Value="0">不合格</asp:ListItem>
               </asp:DropDownList>
                                </td>
            <td class="table-title">右下肢</td>
             <td>
                 <asp:DropDownList ID="cbYxz" runat="server">
                    <asp:ListItem Value="1">合格</asp:ListItem>
                     <asp:ListItem Value="0">不合格</asp:ListItem>
                 </asp:DropDownList>
                                </td>
              <td class="table-title">躯干颈部</td>
               <td>
                   <asp:DropDownList ID="cbQgjb" runat="server">
                      <asp:ListItem Value="1">合格</asp:ListItem>
                     <asp:ListItem Value="0">不合格</asp:ListItem>
                   </asp:DropDownList>
                                </td>
        
        </tr>
        
        <tr class="table-content">
        
        <td class="table-title"> 体检日期</td>
         <td colspan="2">
                             <input onclick="popUpCalendar(this,document.getElementById('txtCheckDate'),'yyyy-mm-dd')" id="txtCheckDate" runat="server" />

                                </td>
            <td class="table-title">体检医院</td>
             <td colspan="4">
                 <asp:TextBox ID="txtHospital" runat="server" Width="395px" ReadOnly="True"></asp:TextBox>
                                </td>
        
        </tr>
        
         <tr class="table-content">
        
      
         <td colspan="8" style="text-align:right"> 
             <asp:Button ID="btnSave" runat="server" 
                 Text="保存" onclick="btnSave_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnPrintReturn" runat="server" Text="打印回执单" 
                 Enabled="False" onclick="btnPrintReturn_Click"/>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnQuitBus" Visible="false" runat="server" Text="退办" Enabled="False" 
                 onclick="btnQuitBus_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="取消" Visible="False"/></td>
           
        
        </tr>
        
        </table>
        
        </td></tr></table>
    </form>
</body>
</html>
