<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Hr.aspx.cs" Inherits="Hr" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>广州互信电子科技有限公司-人才招聘</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border=0 style="width:1002px">
        <tr style="text-align:left">
        <td style="text-align:left; padding:0; margin:0">
        <div style="float:left;height:300px; margin-left:20px;width:186px;
            padding:0px; background-image:url('images/人才招聘1.png');
             background-position:top; background-repeat:no-repeat;
              background-attachment:fixed; margin:0px; display:inline; padding-left:0px;
              padding-top:60px;margin-left:0; margin-right:0;
              ">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;<img src="images/14.gif" /><a class="hint" href="#Introduction">职位发布</a>
        </div>
        <div  style=" width:790px; float:right; display:inline; border:1px; border-color:Red;">
            <div style="background-image:url('images/header-bg1.png'); background-position: left top; background-repeat:repeat-x;">
            <img  src="images/arrow-right.png"/>
            <img  src="images/人才招聘-header.png"/>
            
            </div>
   <div>

<p>
    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="Both" HeaderStyle-Height="60px" HeaderStyle-BackColor="#F2F2F2" HeaderStyle-ForeColor="Black"
     HeaderStyle-HorizontalAlign="Center"  RowStyle-Height="120px">
<Columns>
<asp:BoundField  HeaderText="招聘职位" HeaderStyle-Width="140px" ItemStyle-HorizontalAlign="Center" DataField="job"/>
<asp:BoundField  HeaderText="招聘描述" DataField="requirement"/>
<asp:BoundField  HeaderText="招聘人数" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" DataField="num"/>
<asp:BoundField  HeaderText="截止日期" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" DataField="enddate"/>
</Columns>
    </asp:GridView>

   </p>
   
   </div>     
        </div>
            
            </td>
        
        </tr>
        
        </table>
</asp:Content>

