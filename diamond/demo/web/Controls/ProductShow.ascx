<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductShow.ascx.cs" Inherits="Controls_ProductShow" %>

<table style="width: 300px;">
    <tr>
        <td>
            条&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码
        </td>
        <td colspan="3">
           
            <asp:TextBox ID="txtBarCode" name="product1_txtBarCode"    Width="225" runat="server"></asp:TextBox>  
            <span  style="display:none">
                <asp:Label ID="lbProductId" runat="server" Text="id"></asp:Label>
            <asp:Button  ID="btnSearch" name="product1__btnSearch" OnClick="btnSearch_Click"  runat="server" Text="查找" />
            </span>
        </td>
        
      
    </tr>
    <tr>
        <td>
            供&nbsp; 货&nbsp; 商
        </td>
        <td class="style1">
            <asp:TextBox ID="txtGhs" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            品&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名
        </td>
        <td>
        <asp:TextBox ID="txtPm" ReadOnly="true" runat="server"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td>
            款&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 号
        </td>
        <td class="style1">
        <asp:TextBox ID="txtKh" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            产品类别
        </td>
        <td>
            <asp:TextBox ID="txtCplb" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            材&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 质
        </td>
        <td class="style1">
            <asp:TextBox ID="txtCz" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            工厂货重
        </td>
        <td>
            <asp:TextBox ID="txtGchz" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            净&nbsp; 金&nbsp; 重
        </td>
        <td class="style1">
            <asp:TextBox ID="txtJjz" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            复&nbsp; 秤&nbsp; 重
        </td>
        <td>
            <asp:TextBox ID="txtFcz" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            原&nbsp; 编&nbsp; 号
        </td>
        <td class="style1">
            <asp:TextBox ID="txtYbh" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            手&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 寸
        </td>
        <td>
            <asp:TextBox ID="txtSc" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            零&nbsp; 售&nbsp; 价
        </td>
        <td class="style1">
            <asp:TextBox ID="txtLsj" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            素金工费
        </td>
        <td>
            <asp:TextBox ID="txtSjgf" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            件&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 数
        </td>
        <td class="style1">
            <asp:TextBox ID="txtJs" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
        <td>
            工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 费
        </td>
        <td>
            <asp:TextBox ID="txtGf" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtBz" ReadOnly="true" Width="230" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            图&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 片
        </td>
        <td colspan="3">
            <asp:Image ID="imgPic" Width="230" Height="223" BorderWidth="1px" runat="server" />
        </td>
    </tr>
</table>


 <script type="text/javascript" language="javascript">
function Self_TestMethod()
{
alert("123");
}
function ShowProductDetail(event)
{

// alert("begin");
//alert(event.keyCode);
 if(event.keyCode==13)
 {
 alert("enter");
  alert( document.getElementsByName("product1__btnSearch")[0]);
  document.getElementsByName("product1__btnSearch")[0].focus();
   document.getElementsByName("product1__btnSearch")[0].click();
 }

 /*
  $.ajax({              
        type: "POST",             
        url: "../Services/ProductDetailShow.aspx",              
        data: "{}",              
        contentType: "application/json; charset=utf-8",              
        dataType: "json",               
        success: function(msg) {               
        //instantiate a template with data 
           // alert("success");              
              //  alert(msg.Ghs);
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
                    if(AfterScanProcess)
                    {
                        AfterScanProcess(msg);
                    }
                },
       error:function(msg)
       { 
       //alert("error");
       //alert(msg.Ghs);
         //alert("error");
       }
                
                }); 
                */
 // alert("end");

}
</script>


