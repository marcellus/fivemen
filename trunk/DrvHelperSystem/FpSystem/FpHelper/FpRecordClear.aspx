<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpRecordClear.aspx.cs" Inherits="FpSystem_FpHelper_FpRecordClear" Title="无标题页" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="table-border">
   
       <tr class="table-content">
          <td style=" padding:10px; text-align:right">

              &nbsp;  驾校：<asp:DropDownList ID="ddlSchoolCode" runat="server" >
               <asp:ListItem Text="全部" Value="all"></asp:ListItem>
              </asp:DropDownList>
              &nbsp;  车型：<asp:DropDownList ID="ddlCarType" runat="server">
              </asp:DropDownList>
              &nbsp; 学员信息:
              <asp:DropDownList ID="ddlQueryType" runat="server">
              <asp:ListItem Text="证件号码" Value="idcard"></asp:ListItem>
              <asp:ListItem Text="受理号" Value="lsh"></asp:ListItem>
              <asp:ListItem Text="姓名" Value="name"></asp:ListItem>
           </asp:DropDownList>
           <asp:TextBox ID="txtQueryValue" runat="server"></asp:TextBox>
          
              <asp:Button Text="查询" runat="server" ID="btnSearch" onclick="btnSearch_Click" />
          </td>
          
       </tr>
       
       <tr class="table-content">
          <td style="padding:15px;  text-align:right">
             <asp:CheckBox runat="server" Text="全选" id="cbAll"  AutoPostBack="true"
                  oncheckedchanged="cbAll_CheckedChanged" /> &nbsp;
             <asp:Button runat="server" Text="批量清除" id="btnBatchClear" 
                  onclick="btnBatchClear_Click" />&nbsp;
  
          </td>
       </tr>
   
   </table>
   

   <table class="table-border">
          
   
        <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border"  OnItemCommand="DataGrid1_ItemCommand1"
                         
                        Width="100%">
                        <Columns>
                        
                            <asp:TemplateColumn HeaderStyle-Width="30px">
                               <ItemTemplate>
                                   <asp:CheckBox runat="server" ID="cbIdCard"   ></asp:CheckBox>
                               </ItemTemplate>
                            </asp:TemplateColumn>
                        
                            <asp:BoundColumn DataField="lsh" HeaderText="流水号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
                             <asp:BoundColumn DataField="idcard" HeaderText="身份证明号码"></asp:BoundColumn>
                            <asp:BoundColumn DataField="school_name" HeaderText="驾校"></asp:BoundColumn>
                            <asp:BoundColumn DataField="car_type" HeaderText="车型"></asp:BoundColumn>
                             
                             <asp:TemplateColumn HeaderText="操作">
                                <ItemTemplate>
     
                                   <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="清除" CommandArgument='<%#Eval("idcard") %>'
                                        CommandName="Clear" ImageUrl="~/images/delete.gif" 
                                        ToolTip="清除" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            
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
                 
                    <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True"  PageSize="30"
                        BindControlString="DataGrid1">
                    </WC:ProcedurePager>
                 
                </td>
            </tr>
   </table>

</asp:Content>

