<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>广州互信电子科技有限公司-产品展示</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border=0 style="width:1002px">
        <tr style="text-align:left">
        <td style="text-align:left; padding:0; margin:0">
        <div style="float:left;height:300px; margin-left:20px;width:186px;
            padding:0px; background-image:url('images/产品展示1.png');
             background-position:top; background-repeat:no-repeat;
              background-attachment:fixed; margin:0px; display:inline; padding-left:0px;
              padding-top:60px;margin-left:0; margin-right:0;
              ">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;<img src="images/14.gif" /><a class="hint" href="Product.aspx?id=1">软件产品</a>
        <br />
         &nbsp;&nbsp;&nbsp;&nbsp;<img src="images/14.gif" /><a class="hint" href="Product.aspx?id=2">硬件产品</a>
        </div>
        <div  style=" width:790px; float:right; display:inline; border:1px; border-color:Red;">
            <div style="background-image:url('images/header-bg1.png'); background-position: left top; background-repeat:repeat-x;">
            <img  src="images/arrow-right.png"/>
            <img  src="images/产品展示-header.png"/>
            
            </div>
   <div>

<p>
   </p>
       <asp:DataList ID="DataList1" runat="server" RepeatColumns="2">
       <HeaderTemplate>

       </HeaderTemplate>
       <ItemTemplate>
       <div style="width:100%; position:relative; float:left; margin-left:15px;margin-right:15px; text-align:center;">
       
       <div><img width="300px" height="200px" src='<%# Eval("picurl") %>' /></div>
       <br />
      <div style="width:100%; padding:0px; margin:0px; position:inherit; text-align:center; "><%# Eval("title") %></div>
       <br />
        <a target="_blank" href='ProductDetail.aspx?id=<%# Eval("id")%>'>详细信息</a>
       </div>
       
       </ItemTemplate>
       <SeparatorTemplate>
       <hr />
       </SeparatorTemplate>
       <FooterTemplate>
       
       </FooterTemplate>
       </asp:DataList>
      
       
   </div>     
        </div>
            
            </td>
        
        </tr>
        
        </table>
</asp:Content>

