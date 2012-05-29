<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpVerify52_Idcard.aspx.cs" Inherits="FpSystem_FpHelper_FpVerify52_Idcard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
    <asp:TextBox runat="server" ID="txtIdcard" Width="300"></asp:TextBox> 
    <asp:Button runat="server" ID="btnVerify" Text="指纹验证" 
        onclick="btnVerify_Click" />

</asp:Content>

