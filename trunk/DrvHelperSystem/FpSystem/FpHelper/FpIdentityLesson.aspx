<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpIdentityLesson.aspx.cs" Inherits="FpSystem_FpHelper_FpIdentityLesson" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<iframe id="frameViewStudent" name="frameViewStudent" src="FpViewStudentRecord.aspx" style="width:100%; height:80%; border-width:0px">
</iframe>
<iframe src="FpIdentityLesson_TL.aspx"style="width:100%; height:20%; border-width:0px">
</iframe>
</asp:Content>

