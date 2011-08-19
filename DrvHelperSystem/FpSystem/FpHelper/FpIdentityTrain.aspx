<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpIdentityTrain.aspx.cs" Inherits="FpSystem_FpHelper_FpIdentityTrain" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style=" width:1250px; height:820px;float:left" class="b">
  <div style=" height:10%">
     <FpUCL:viewSiteInfo ID="ViewSiteInfo1" runat="server" />
  </div>
  <div style=" height:70%">
    <iframe id="frameViewTrainRecord" name="frameViewTrainRecord" src="FpViewTrainRecord.aspx" scrolling="no" frameborder="0" style="width:100%; height:100%; border-width:0px">
    </iframe>
  </div>
</div>
<div style=" width:600px; height:820px; float:right">
     <div style=" height:500px; width:100%" class="b" >
            <iframe id="frameFpViewCheckinList" name="frameFpViewCheckinList" src="FpViewCheckinList.aspx" scrolling="no" frameborder="0" style="width:100%; height:100%; border-width:0px">
    </iframe>
      </div>
        <div style=" height:300px; width:100%; overflow:hidden;" class="b" >
        <iframe src="FpIdentity_TL.aspx?targetframe=frameViewTrainRecord&checkinLogFrame=frameFpViewCheckinList" style="width:100%; height:100%; border-width:0px" frameborder="0" scrolling="no"></iframe>
     </div>
</div>

</asp:Content>

