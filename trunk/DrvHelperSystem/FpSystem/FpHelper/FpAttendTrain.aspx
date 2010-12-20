<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpAttendTrain.aspx.cs" Inherits="FpSystem_FpHelper_FpAttendTrain" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>入场训练指纹考勤</h1>
  <asp:Button  runat="server" Text="指纹验证" ID="btnIdentity" 
        onclick="btnIdentity_Click" />
   <br />
   <asp:Label runat="server"  ID="lbUserID" />
</asp:Content>

