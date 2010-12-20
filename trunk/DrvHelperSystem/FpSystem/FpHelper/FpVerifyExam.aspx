<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpVerifyExam.aspx.cs" Inherits="FpSystem_FpHelper_FpVerifyExam" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>科目考试指纹验证</h1>
   <asp:Button  runat="server" Text="指纹验证" ID="btnIdentity" 
        onclick="btnIdentity_Click" />
   <br />
   <asp:Label runat="server"  ID="lbUserID" />
</asp:Content>

