<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpVerify.master" AutoEventWireup="true" CodeFile="FpViewExamRecord.aspx.cs" Inherits="FpSystem_FpHelper_FpViewExamRecord" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="contextMsg"   ContentPlaceHolderID="ContentPlaceHolderMsg"  runat="server">
     <asp:Label ID="lbStudentAlertMsg" runat="server" CssClass="msgAlert"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <FpUCL:viewStudentInfo ID="ucStudentInfo"   runat="server"></FpUCL:viewStudentInfo>
  

  
</asp:Content>

