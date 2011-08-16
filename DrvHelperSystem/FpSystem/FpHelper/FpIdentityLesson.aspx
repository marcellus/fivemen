<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpIdentityLesson.aspx.cs" Inherits="FpSystem_FpHelper_FpIdentityLesson" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style=" width:1250px; height:820px;float:left">
<iframe id="frameViewLessonRecord" name="frameViewLessonRecord" src="FpViewLessonRecord.aspx" scrolling="no" style="width:100%; height:100%; border-width:0px">
</iframe>
</div>
<div style=" width:600px; height:820px; float:right">
     <div style=" height:500px; width:100%" class="b">
        学员考情列表
     </div>
     <div style=" height:300px; width:100%" class="b">
        <iframe src="FpIdentity_TL.aspx?targetframe=frameViewLessonRecord"style="width:100%; height:100%; border-width:0px" scrolling="no"></iframe>
     </div>
</div>
</asp:Content>

