<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpIdentityLesson.aspx.cs" Inherits="FpSystem_FpHelper_FpIdentityLesson" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="msg" >
    
</div>
<div style=" width:70%; height:820px;float:left; vertical-align:bottom" class="b">
  <div style=" height:10%">
     <FpUCL:viewSiteInfo runat="server" />
  </div>
  <div style=" height:70%">
    <iframe id="frameViewLessonRecord" name="frameViewLessonRecord" src="FpViewLessonRecord.aspx" scrolling="no" frameborder="0" style="width:100%; height:100%; border-width:0px">
    </iframe>
  </div>
</div>
<div style=" width:29%; height:820px; float:right">
     <div style=" height:80px; width:100%; overflow:hidden;" class="b" >
        <iframe src="FpVerify_Idcard.aspx?targetframe=frameViewLessonRecord&checkinLogFrame=frameFpViewCheckinList" style="width:100%; height:100%; border-width:0px" frameborder="0" scrolling="no"></iframe>
     </div>
     <div style=" height:520px; width:100%" class="b" >
            <iframe id="frameFpViewCheckinList" name="frameFpViewCheckinList" src="FpViewCheckinList.aspx" scrolling="yes" frameborder="1"  style="width:100%; height:515px;">
    </iframe>
      </div>

</div>
</asp:Content>

