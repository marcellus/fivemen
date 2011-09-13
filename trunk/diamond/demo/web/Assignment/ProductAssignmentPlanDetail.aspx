<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="调拨单详情" AutoEventWireup="true"
    CodeFile="ProductAssignmentPlanDetail.aspx.cs" Inherits="Assignment_ProductAssignmentPlanDetail"
     %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left: 10px" class="noPrint">
        <object id="WebBrowser" height="0" width="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"
            viewastext>
        </object>
    </div>

    <script type="text/javascript">
        //注册表的网页打印路径 
var hkey_root="HKEY_CURRENT_USER" ; 
var hkey_path="\\Software\\Microsoft\\Internet Explorer\\PageSetup\\"; 
var hkey_key;     
     
        //打印指定区域 
        function DoPrint() 
        {    
     //直接调用WebBrowser的打印，要打印预览的话是ExecWB(7,1) 
     document.all.WebBrowser.ExecWB(6,1); 
        } 
      
//设置纸张方向 
function SetupLandscape() 
{ 
     try{ 
   var wsShell= new ActiveXObject("WScript.Shell"); 
   //打印页面的Menubar必须可见，此操作类似按键盘上的Alt+F+U也就是 调出页面设置对话框 
   wsShell.sendKeys('%fu'); 
   //此操作类似按键盘上的Alt+A也就是 设置横向打印 
   wsShell.sendKeys('%a'); 
   //此操作类似按键盘上的回车 页面设置对话框的默认焦点在 确定上 所以直接确定 
   wsShell.sendKeys('{ENTER}'); 
     } 
     catch(e){} 
} 

//设置默认的页眉页脚 
function SetupPage() 
{ 
     try{ 
   var RegWsh = new ActiveXObject("WScript.Shell"); 
   hkey_key="header" 
   RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"&b页码，&p/&P") 
   hkey_key="footer" 
   RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"") //去掉了&u 因为我不想显示当前打印页的网址 
   hkey_key="margin_bottom"; 
   RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"0.39"); //0.39相当于把页面设置里面的边距设置为10 
   hkey_key="margin_left"; 
   RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"0.39"); 
   hkey_key="margin_right"; 
   RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"0.39"); 
   hkey_key="margin_top"; 
   RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"0.39"); 
     } 
     catch(e){} 
} 

setTimeout("SetupLandscape()",1000); 
setTimeout("SetupPage()",2000); 

    </script>

    <div style="">
        <table border="0px" style="text-align:left" cellspacing="0" cellpadding="0">
            <tr style="height:30px;line-height:30px;text-align: left; vertical-align:middle">

                <td colspan="2" style="text-align: left; vertical-align:middle">
                   调 拨 单 号 &nbsp;&nbsp;<asp:Label ID="lbPlanName" runat="server" Text="JSAssignment001"></asp:Label>
                     &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<input name="button2" type="button" onclick="document.all.WebBrowser.ExecWB(6,1)"
                        class="ButtonFlat noPrint" value="打印" />
                    <input name="button5" type="button" onclick="document.all.WebBrowser.ExecWB(7,1)"
                        class="ButtonFlat noPrint" value="打印预览" />
                </td>
            </tr>
            <tr>
                <td>
                    调拨单发起
               
                    &nbsp;&nbsp;<asp:Label ID="lbCreator" runat="server" Text="贾名"></asp:Label>
                </td>
                <td>
                    调拨单发起时间
                
                    &nbsp;&nbsp;
                    <asp:Label ID="lbCreateTime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    目 标 门 店
                
                    <asp:Label ID="lbPlanShopName" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    调拨货物总数
                
                    <asp:Label ID="lbProductCount" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="gvStyle" cellspacing="0" rules="rows" border="0" id="table_assignment_list"
            style="width: 100%; border-collapse: collapse;">
            <thead style="display: table-header-group; font-weight: bold">
                <tr>
                    <td colspan="8" align="center" style="font-weight: bold;">
                        金鑫珠宝有限公司调拨单号<asp:Label ID="lbPlanName1" runat="server" Text="JSAssignment001"></asp:Label>产品列表
                    </td>
                </tr>
            </thead>
            <tr>
              <td colspan="8">
              <ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridview" 
            AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false"
                                    >
                                   <Columns>
                                      
                                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <%#String.Format("{0}", (((GridViewRow)Container).RowIndex + 1) )%>
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
                                        <asp:BoundField HeaderText="品名" DataField="Product_Name" 
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                        <asp:BoundField HeaderText="条码" DataField="Barcode"
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="款号" DataField="Style"
                                            ReadOnly="true" HeaderStyle-Width="160px" ItemStyle-Width="160px" >
<HeaderStyle Width="160px"></HeaderStyle>

<ItemStyle Width="160px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="材质" DataField="Cailiao" 
                                             ReadOnly="true"
                                            HeaderStyle-Width="80px" ItemStyle-Width="80px" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="供货商" DataField="Factory_Name" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="工厂货重" DataField="Factory_Weight" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="净金重" DataField="Gold_NetWeight" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>

                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="零售价" DataField="Price" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                  
                                    </Columns>
                           
</ft:GridViewEx>
              
              </td> 
            </tr>
            
        </table>
    </div>
</asp:Content>
