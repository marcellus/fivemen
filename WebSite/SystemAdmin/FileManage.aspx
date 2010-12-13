<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileManage.aspx.cs" Inherits="SystemAdmin_FileManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>web文件管理器</title>
    <link href="../css/styles.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="table-border" cellpadding="4" cellspacing="1" border="0">
					<thead class="table-content">
						<tr>
							<th colspan="5" style="text-align:center;">
								当前目录为：<asp:Label Runat="server" ID="lbDir"></asp:Label></th>
						</tr>
						<tr>
							<TH width="30">
								&nbsp;</TH>
							<TH align="left" width="450">
								名字</TH>
							<TH width="80">
								大小
							</TH>
							<TH width="200">
								最后修改时间
							</TH>
							<TH width="50">
								删除
							</TH>
						</tr>
					</thead>
					<tbody class="table-content">
					
					<asp:PlaceHolder Runat="server" ID="phContent"></asp:PlaceHolder>
					</tbody>
				</table>
    </div>
    </form>
</body>
</html>
