<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpIdentityExam.aspx.cs" Inherits="FpSystem_FpHelper_FpIdentityExam" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<iframe id="frameViewExamRecord" name="frameViewExamRecord" src="FpViewExamRecord.aspx"scrolling="no" style="width:100%; height:90%; border-width:0px">
</iframe>
<iframe src="FpIdentity_TL.aspx?targetframe=frameViewExamRecord"style="width:100%; height:10%; border-width:0px" scrolling="no">
</iframe>
</asp:Content>

