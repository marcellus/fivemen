<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpVerify_Idcard.aspx.cs" Inherits="FpSystem_FpHelper_FpVerify_Idcard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:Label Text="请刷二代身份证" runat="server" ID="lbInfo"></asp:Label><br />
  <asp:TextBox  runat="server" ID="txtIdCard" ReadOnly="true" Width="200" 
        ontextchanged="txtIdCard_TextChanged"></asp:TextBox>
</asp:Content>

