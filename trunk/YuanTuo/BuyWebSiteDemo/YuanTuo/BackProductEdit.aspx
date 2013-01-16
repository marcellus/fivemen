<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerDetail.master" AutoEventWireup="true" CodeFile="BackProductEdit.aspx.cs" Inherits="YuanTuo_BackProductEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../css/sample.css" type="text/css" />
<style type="text/css">
body
{
	overflow:scroll;
}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="text-align:center;width:1000px">
<table class="table-border-pop" border="0" cellspacing="1" cellpadding="4" style="width:100%">
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    产品详细信息：</td>
            </tr>
           
            <tr class="table-content">
             <td  class="table-title-right" style="width:10%">类别：</td>
                <td style="width:30%"> 
                   <asp:DropDownList ID="cbProductTypeIdValue" runat="server"  Width="195px"></asp:DropDownList>
                </td>
                <td  class="table-title-right" style="width:10%">
                    编码：</td>
                <td style="width:50%">
                    <asp:TextBox ID="txtNo" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            
            
             <tr class="table-content">
             <td  class="table-title-right" >
                     名称：</td>
                <td >
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                   
                </td>
                <td  class="table-title-right">
                    价格：</td>
                <td >
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                  
                </td>
                
                
            </tr>
             <tr class="table-content">
             <td  class="table-title-right" >
                    品牌：</td>
                <td >
                    <asp:TextBox ID="txtPinPai" runat="server"></asp:TextBox>
                </td>
                <td  class="table-title-right" >
                  规格： </td>
                <td >
                   <asp:TextBox ID="txtGuiGe" runat="server"></asp:TextBox> 
                  
                </td>
                
            </tr>
            <tr class="table-content">
             <td  class="table-title-right" >
                   取货天数：</td>
                <td >
                    <asp:TextBox ID="txtGetProductDays" runat="server"></asp:TextBox>
                </td>
                <td  class="table-title-right" >
                  浏览次数： </td>
                <td >
                  <asp:Label ID="lbSeeTimes" runat="server"></asp:Label>
                  
                </td>
                
            </tr>
             <tr class="table-content">
            <td  class="table-title-right" >
                    产地：</td>
                <td >
                    <asp:TextBox ID="txtChanDi" runat="server"></asp:TextBox>
                  
                </td>
                <td  class="table-title-right">
                    产品状态：</td>
                <td >
                    <asp:DropDownList ID="cbStatusValue" runat="server">
                    <asp:ListItem Value="1" Text="上架中" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="0" Text="已下架"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
             <tr class="table-content">
             <td  class="table-title-right" >
                    排序：</td>
                <td  colspan="3">
                    <asp:TextBox ID="txtOrderNum" runat="server"></asp:TextBox>
                    
                </td>
           
               
                
            </tr>
            <tr class="table-content">
             <td  class="table-title-right">
                    介绍图：</td>
                <td  colspan="3">
                    
                  
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                   &nbsp; 
                    <asp:Button ID="btnMainImgUpload" runat="server" Text="上传图片" onclick="btnMainImgUpload_Click" 
                         />
                    
                  
                &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                    
                  
                </td>
           
               
                
            </tr>
             <tr class="table-content">
             <td  class="table-title-right">
                    介绍图结果：</td>
                <td  colspan="3">
                    <asp:Image ID="imgMainImgShow" runat="server" Width="60px" Height="60px" />
                </td>  
            </tr>
            <tr class="table-content">
             <td  class="table-title-right">
                    轮播图：</td>
                <td  colspan="3">
                    
                  
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                   &nbsp; <asp:Button ID="btnUpload" runat="server" Text="上传图片" 
                        onclick="btnUpload_Click" />
                      &nbsp;      
                    <asp:Button ID="btnCycleImgClear" runat="server" Text="清空轮播图" onclick="btnCycleImgClear_Click" 
                         />
                    
                  
                &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                    
                  
                </td>
           
               
                
            </tr>
            
            
            <tr class="table-content">
             <td  class="table-title-right">
                    轮播组图结果：</td>
                <td  colspan="3">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> 
                </td>  
            </tr>
            
             
            
            <tr class="table-content">
                  <td class="table-title-right" >
                  介绍HTML：</td>
                <td  class="style7" colspan="3">
                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" 
                        ></CKEditor:CKEditorControl></td>
                    </tr>
           
            <tr  class="table-bottom-buttons">
                <td  colspan="4" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" Width="120px" Text="确定" onclick="btnSure_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                         <input id="Button2" class="button"  type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    </td>
            </tr>
        </table>
        </div>
</asp:Content>

