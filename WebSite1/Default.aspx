<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataGrid ID="GridView1" runat="server" AutoGenerateColumns="False" 
                Width="100%" CellPadding="1" CellSpacing="1" DataKeyField="id">
            <Columns>
                 <asp:BoundColumn DataField="id" HeaderText="id"></asp:BoundColumn>
               <asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
  <asp:TemplateColumn HeaderText="选择">
                       
                        <itemtemplate>
                    <%#Helper.Convert(DataBinder.Eval(Container.DataItem,"id")) %>
                                
   
                        </itemtemplate>
 </asp:TemplateColumn> 
                       
                      
            </Columns>
        </asp:DataGrid>
    </div>
    </form>
</body>
</html>
