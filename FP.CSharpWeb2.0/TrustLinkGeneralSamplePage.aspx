<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrustLinkGeneralSamplePage.aspx.cs" Inherits="TrustLinkGeneralSamplePage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_TITLE",System.Globalization.CultureInfo.CurrentCulture)%></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table borderColor="black" cellSpacing="0" borderColorDark="white" cellPadding="0" width="690"
				align="center" bgColor="activeborder" borderColorLight="blue" border="0">
				<tr>
					<td>
						<table width="680" align="center" border="0">
							<tr>
								<td align="center" colSpan="4"><br>
									<asp:label id="lblTitle" runat="server" Font-Bold="True" Font-Size="Large">TrustLink 3.1 Sample Code</asp:label></td>
							</tr>
							<tr>
								<td width="50%" colSpan="2" style="HEIGHT: 24px">&nbsp;
                                    <asp:Button ID="btnSetDefaultParas" runat="server" OnClick="btnSetDefaultParas_Click"
                                        Text="Use INI file  set default parameters" /></td>
								<td align="right" width="50%" colSpan="2" style="HEIGHT: 24px"><asp:label id="lblFingerprintType" runat="server">Fingerprint type:</asp:label><asp:dropdownlist id="cboProductType" runat="server" Width="200px">
										<asp:ListItem Value="ATW100" Selected="True">ATW100</asp:ListItem>
										<asp:ListItem Value="AES3500">AES3500</asp:ListItem>
										<asp:ListItem Value="U.are.U 4000B">U.are.U 4000B</asp:ListItem>
										<asp:ListItem Value="LTTS500">LTTS500</asp:ListItem>
										<asp:ListItem Value="WUSB106">WUSB106</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colSpan="4" height="5"></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="grpSetParameters" runat="server">Set system parameters</asp:label></td>
							</tr>
							<tr>
								<td colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="1" borderColorLight="black"
										borderColorDark="white">
										<tr>
											<td>
												<table width="100%">
													<tr>
														<td colSpan="2" height="5"></td>
													</tr>
													<tr>
														<td align="right" width="35%"><asp:label id="lblHostName" runat="server">Host Name:</asp:label>&nbsp;</td>
														<td width="65%"><asp:textbox id="txtHostName" runat="server" Width="400px"></asp:textbox></td>
													</tr>
													<tr>
														<td align="right"><asp:label id="lblProductID" runat="server">Product ID:</asp:label>&nbsp;</td>
														<td><asp:textbox id="txtProductID" runat="server" Width="400px"></asp:textbox></td>
													</tr>
													<tr>
														<td align="right"><asp:label id="lblPort" runat="server">Use Port:</asp:label>&nbsp;</td>
														<td><asp:textbox id="txtPort" runat="server" Width="400px"></asp:textbox></td>
													</tr>
													<tr>
														<td align="right"><asp:label id="lblAdminName" runat="server">Admin Name:</asp:label>&nbsp;</td>
														<td><asp:textbox id="txtAuthenId" runat="server" Width="400px"></asp:textbox></td>
													</tr>
													<tr>
														<td align="right"><asp:label id="lblAdminPassword" runat="server">Admin Password:</asp:label>&nbsp;</td>
														<td><asp:textbox id="txtAdminPassword" runat="server" Width="400px"></asp:textbox></td>
													</tr>
													<tr>
														<td colSpan="2" height="5"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="4" height="20"></td>
							</tr>
							<tr>
								<td width="25%">&nbsp;&nbsp;
									<asp:label id="grpRegister" runat="server">Register finger user</asp:label></td>
								<td width="25%">&nbsp;&nbsp;
									<asp:label id="grpVerify" runat="server">Verify fingerprint</asp:label></td>
								<td width="25%">&nbsp;&nbsp;
									<asp:label id="grpIdentify" runat="server">Identify fingerprint</asp:label></td>
								<td width="25%">&nbsp;&nbsp;
									<asp:label id="grpDelete" runat="server">Delete user</asp:label></td>
							</tr>
							<tr>
								<td>
									<table height="100" cellSpacing="0" borderColorDark="white" cellPadding="0" width="100%"
										align="center" borderColorLight="black" border="1">
										<tr>
											<td>
												<table width="98%" align="center">
												    <tr>
												        <td>
                                                            <asp:CheckBox ID="cbDisapproveUpdateFP" runat="server" Text="DisapproveUpdateFP" /></td>
												    </tr>
													<tr>
														<td>
															<asp:label id="lblRegUser" runat="server">User Name:</asp:label></td>
													</tr>
													<tr>
														<td align="center"><asp:textbox id="txtRegUser" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td align="center"><asp:button id="btnNewEnroll" runat="server" Text="NewEnroll" OnClick="btnNewEnroll_Click"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td>
									<table height="100" cellSpacing="0" borderColorDark="white" cellPadding="0" width="100%"
										align="center" borderColorLight="black" border="1">
										<tr>
											<td>
												<table width="98%" align="center">
												    <tr>
												        <td></td>
												    </tr>
													<tr>
														<td>
															<asp:label id="lblVerifyUser" runat="server">User Name:</asp:label></td>
													</tr>
													<tr>
														<td align="center"><asp:textbox id="txtVerifyUser" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td align="center"><asp:button id="btnFPUserVerify" runat="server" Text="FPUserVerify" OnClick="btnFPUserVerify_Click"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td>
									<table height="100" cellSpacing="0" borderColorDark="white" cellPadding="0" width="100%"
										align="center" borderColorLight="black" border="1">
										<tr>
											<td>
												<table width="98%" align="center">
												    <tr>
												        <td></td>
												    </tr>
													<tr>
														<td height="100%">&nbsp;</td>
													</tr>
													<tr>
														<td height="100%">&nbsp;</td>
													</tr>
													<tr>
														<td align="center">
															<asp:Button id="btnFPUserIdentify" runat="server" Text="FPUserIdentify" OnClick="btnFPUserIdentify_Click"></asp:Button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td>
									<table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" bordercolordark="white"
										bordercolorlight="black" height="100">
										<tr>
											<td>
												<table width="98%" align="center">
												    <tr>
												        <td></td>
												    </tr>
													<tr>
														<td>
															<asp:Label id="lblDeleteUser" runat="server">User Name:</asp:Label></td>
													</tr>
													<tr>
														<td align="center">
															<asp:TextBox id="txtDeleteUser" runat="server"></asp:TextBox></td>
													</tr>
													<tr>
														<td align="center">
															<asp:Button id="btnDeleteUser" runat="server" Text="DeleteUser" OnClick="btnDeleteUser_Click"></asp:Button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="4" height="5"></td>
							</tr>
							<tr>
								<td colspan="4" align="right">
                                    &nbsp;<asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="  Exit  " /></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
