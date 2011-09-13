<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="新增调拨单" AutoEventWireup="true"
    CodeFile="ProductAssignmentPlan.aspx.cs" Inherits="Assignment_ProductAssignmentPlan"
    StyleSheetTheme="" Theme="DefaultTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<ajax:AjaxPanel>
<div class="noPrint">
    <fieldset class="noPrint">
        <legend>调拨单 </legend>
        <div style="margin-left: 10px" class="noPrint">
            目标门店&nbsp;
            <asp:DropDownList  ID="ddlShop" name="ddlShop" runat="server">
            </asp:DropDownList>
            <script type="text/javascript">
            function changeShop()
            {
             var checkText=$("#ctl00_ContentPlaceHolder1_ddlShop").find("option:selected").text();  //获取Select选择的Text
             if(checkText!='--请选择--')
             {
                var date=new   Date().toLocaleDateString();
                //alert($("spanPlan"));
                var name="JXAssignmentPlan-"+date+"-"+checkText;
                $("#ctl00_ContentPlaceHolder1_txtPlanName").val(name);
                  $("#spanPlan1").text(name);
                $("#spanPlan2").text(name);
                 
                $("#planShop").html("&nbsp;&nbsp;"+checkText);
             }
             //alert();
             //alert(checkText);
           // var checkValue=$("#ctl00_ContentPlaceHolder1_ddlShop").val();  //获取Select选择的Value
           // var checkIndex=$("#ctl00_ContentPlaceHolder1_ddlShop ").get(0).selectedIndex;  
            //var obj2=$("#ctl00_ContentPlaceHolder1_ddlShop").html();
            //alert(obj2);
            //var obj=$("ddlShop").html();
            //alert($("ddlShop"));
            //alert(obj);
            }
            function changePlanName()
            {
            //alert("changePlanName");
                var name=$("#ctl00_ContentPlaceHolder1_txtPlanName").val();
                $("#spanPlan1").text(name);
                $("#spanPlan2").text(name);
            }
            
            </script>
            &nbsp;&nbsp;调拨单号&nbsp;<asp:TextBox Width="300px" CssClass="noPrint"  ID="txtPlanName" runat="server"></asp:TextBox>
            &nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="ButtonFlat noPrint"
                Text="保存调拨计划" />
            <input name="button2" type="button" onclick="document.all.WebBrowser.ExecWB(6,1)"  class="ButtonFlat" value="打印" />

<input name="button5" type="button" onclick="document.all.WebBrowser.ExecWB(7,1)" class="ButtonFlat" value="打印预览" /> 
 
        </div>

        <div style="margin-left: 10px"  class="noPrint">
        
        <OBJECT id="WebBrowser" height="0" width="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"  
       VIEWASTEXT>  
</OBJECT> 
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
        
    </fieldset>
 </div>
    <div style="">
        <table border="0px" cellspacing="3" cellpadding="2" >
        <tr>
        <td >调  拨  单  号</td><td colspan="3" style="text-align:left">&nbsp;&nbsp;<span name="spanPlan" id="spanPlan1">JSAssignment001</span>

        
        </td>
        </tr>
        <tr>
        <td>调拨单发起</td>
        <td>&nbsp;&nbsp;<asp:Label ID="lbCreator" runat="server" Text="贾名"></asp:Label></td>
        <td>     调拨单发起时间</td>
        <td>&nbsp;&nbsp;<asp:Label ID="lbCreateTime" runat="server" Text=""></asp:Label></td>
        
        </tr>
        <tr>
        <td>目  标  门  店</td>
        <td id="planShop">
        
        </td>
        <td>     调拨货物总数</td>
        <td id="planNum">
            <asp:Label ID="lbPlanNum" runat="server" Text="0"></asp:Label></td>
        </tr>
        
        </table>
        
        </div>
   
    <div class="noPrint">
    <div class="noPrint">
        库存产品查询</div>
    <fieldset>
        <legend>调拨单 </legend>
        <div class="noPrint" style="margin-left: 10px">
            &nbsp;&nbsp;产品名称&nbsp; 
            <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
            
            &nbsp;&nbsp;  
            <asp:Button ID="btnSearch" CssClass="ButtonFlat"  OnClick="btnSearch_Click" runat="server" Text="查询" />&nbsp;&nbsp;
            <asp:Button ID="btnAdd" CssClass="ButtonFlat" OnClick="btnAdd_Click"  runat="server" Text="添加" />  
               
            <asp:Button ID="btnDelete" CssClass="ButtonFlat" OnClick="btnDelete_Click"  runat="server" Text="删除" />   
            
            <asp:Button ID="Button1" CssClass="ButtonFlat" OnClick="btnClear_Click"  runat="server" Text="清空" />   
            
            
                <input id="btnAddToList" style="display:none" type="button" value="添加" class="ButtonFlat noPrint" onclick="addRowToList();" />
        </div>
    </fieldset>

    </div>
    <div class="noPrint">
        库存产品查询
        <script type="text/javascript">
        function addRowToList()
        {
        //toLocaleDateString();
       // alert('123');
       // alert($);
       // alert( $('#table_assignment_list'));
     // alert($('#selectrow').html());
      var obj=$('#selectrow').html();
      obj="<tr onmouseover=\"this.style.backgroundColor='#009999';\" onmouseout=\"this.style.backgroundColor='White';\">"+obj+"</tr>";
     // alert(obj);
            $('#table_assignment_list').append(obj);
            var rows=$('#table_assignment_list tr').length-2;
            $("#planNum").html(rows);
            //alert(rows);
            //$('#Up').first('tr').before('
        }
        function searchProduct()
        {
        
        alert("searchProduct");
         $.ajax({              
        type: "POST",  
       // type: "GET",                 
        url: "../Services/ProductOperator.asmx/GetProductInfoByBarCode?barcode=123",     
        //GetProductInfoByBarCode   GetProductInfoByName       
        data: "{name:'"+$("#txtSearchName").val()+"',barcode:123}",
        //contentType: "application/json; charset=utf-8",    
       // contentType: "text/plain; charset=utf-8", 
       contentType: "text/json",            
        dataType: "json",              
        success: function(msg) {               
        //instantiate a template with data 
            alert("success"); 
            //msg=msg.Replace("\r\n", "");
            //var t=msg.replace(/\r/ig, "").replace(/\n/ig,""); 
            var t=msg;
            alert(t); 
            alert(t.d);            
                alert(t.d.Product_Id);
                $('#table_product_select').html($('#table_product_select tr:first').html());
                
                /*
              $("#txtGhs").val(msg.Ghs);
               $("#txtPm").val(msg.Pm);
               
               $("#txtCplb").val(msg.Cplb);
                $("#txtCz").val(msg.Cz);
                 $("#txtKh").val(msg.Kh);
               
                $("#txtJs").val(msg.Js);
               $("#txtLsj").val(msg.Lsj);
               
                $("#txtSjgf").val(msg.Sjgf);
               $("#txtSc").val(msg.Sc);
               
               
                $("#txtYbh").val(msg.Ybh);
               $("#txtJjz").val(msg.Jjz);
                $("#txtFcz").val(msg.Fcz);
                 $("#txtGchz").val(msg.Gchz);
               
                $("#txtGf").val(msg.Gf);
               $("#txtBz").val(msg.Bz);
               
                $("#txtGf").val(msg.Gf);
               $("#txtBz").val(msg.Bz);
               alert(msg.ImgPath);
               $("#imgPic").attr("src",msg.ImgPath);
               */
                },
       error:function(msg)
       { 
       alert("error");
         alert(msg.Product_Id);
       //alert(msg.Ghs);
         //alert("error");
       }
                
                });
        
        }
        
        </script>
    </div>
    <div class="noPrint">
   
    <ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridviewselector" 
            AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false"
            GridLines="Horizontal"  >
            
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                       <asp:TemplateField HeaderText="请选择" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbProductSelector" Checked="true"  ToolTip='<%#Eval("Product_Id")%>' runat="server" />
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
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
                                         <asp:BoundField HeaderText="状    态" DataField="ProductStatus" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                  
                                    </Columns>
                                    
    </ft:GridViewEx>
      
    </div>
    
     <div class="noPrint">
        调拨产品列表</div>
    <div>
     <div>
      <table border="0" cellpadding="0" cellspacing="0" style="width:100%" text-align:center"><tr style=" text-align:center; "><td style=" text-align:center">  金鑫珠宝有限公司调拨单号<span name="spanPlan" id="spanPlan2">JSAssignment001</span>产品列表</td></tr>
    
    <tr><td><ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridviewplan" 
            AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false"
            GridLines="Horizontal"  >
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                       <asp:TemplateField HeaderText="请选择" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbProductPlanSelector" Checked="false"  ToolTip='<%#Eval("Product_Id")%>' runat="server" />
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
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
                                    
    </ft:GridViewEx></td></tr></table>

        
    </div>
    </div>
    </ajax:AjaxPanel>
</asp:Content>
