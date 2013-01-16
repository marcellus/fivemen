<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="ReportCounter.aspx.cs" Inherits="YuanTuo_ReportCounter" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div>
 <fieldset>
    <legend>查询条件</legend>
     <div>
    分组：<asp:DropDownList ID="ddlGroups" runat="server"  Width="195px" 
             AutoPostBack="True" onselectedindexchanged="ddlGroups_SelectedIndexChanged">
    </asp:DropDownList>&nbsp;&nbsp;
    终端机：<asp:DropDownList ID="ddlTerminals" runat="server"  Width="320px">
    </asp:DropDownList>&nbsp;&nbsp;
    </div>
    <div>
    开始时间：<input type="text" id="txtBeginDate" runat="server"  
         onclick="setday(this);" style="width:157px; "/>&nbsp;&nbsp;
    结束时间：<input type="text" id="txtEndDate" runat="server"  onclick="setday(this);" 
         style="width:152px; "/>
    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click1" />&nbsp;
     <asp:Button ID="btnExport" runat="server" Text="导出excel" 
            onclick="btnExport_Click" />&nbsp;<asp:Label ID="lbMsg"
         runat="server" Text="" ForeColor="Red"></asp:Label>
     </div>
  </fieldset>
  <br />
</div>
<div>
 <asp:DataGrid ID="dgLists" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
            Width="100%" 
           >
         <Columns>
             <asp:BoundColumn DataField="订购日期" HeaderText="订购日期"  ItemStyle-Width="120"></asp:BoundColumn>
              <asp:BoundColumn DataField="订购时间" HeaderText="订购时间" ></asp:BoundColumn>
            <asp:BoundColumn DataField="单据号" HeaderText="单据号" ItemStyle-Width="350"></asp:BoundColumn>
           
            <asp:BoundColumn DataField="网点编码" HeaderText="网点编码" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="网点名称"  HeaderText="网点名称" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="商品编码" HeaderText="商品编码" ></asp:BoundColumn>
             <asp:BoundColumn DataField="商品名称" HeaderText="商品名称" ></asp:BoundColumn>
               <asp:BoundColumn DataField="配送数量" HeaderText="配送数量" ></asp:BoundColumn>
             <asp:BoundColumn DataField="备注" HeaderText="备注" ></asp:BoundColumn>
              
         </Columns>
         
         <HeaderStyle CssClass="table-title-grid" />
          <ItemStyle CssClass="table-content-grid" />
          <AlternatingItemStyle  CssClass="table-content-grid-alter"/>
       </asp:DataGrid>
    
    </div>
</asp:Content>

