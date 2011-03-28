<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusAccept.aspx.cs" Inherits="DriverPreson_Hospital_BusAccept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>体检受理</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
    var idTmr = "";
    var selectObj;
    var str="";
    function getSelectText(id)
    {
        selectObj=document.getElementById(id);
        return selectObj.options[selectObj.selectedIndex].text;
    }
    
    function getText(id)
    {
        str=getSelectText(id);
        return str.substring(str.indexOf("：")+1);
    }

    function printExcel()
    {
    //alert("exe the method->printExcel");
       var xls;
       try
       {
          xls=new ActiveXObject("Excel.Application");
        }
        catch(e)
        {
        alert("要打印该表，您必须安装Excel电子表格软件，同时浏览器须使用“ActiveX控件”，您的浏览器须允许执行控件。请【帮助】了解浏览器设置方法");
        return;
        }
       xls.visible=true;
       // alert("xls->"+xls);
       //var objBook=excelapp.Workbooks.Add(); 
      // var xlBook=xls.Workbooks.Add;
       //alert("xlBook->"+xlBook);
       /*var MissingValue=null;
        var xlBook=xls.Workbooks.Open("c:\驾驶证申请表-初学.xlt",MissingValue,
  MissingValue,MissingValue,MissingValue,
  MissingValue,MissingValue,MissingValue,
  MissingValue,MissingValue,MissingValue,
  MissingValue,MissingValue,MissingValue,
  MissingValue);
  */
       var xlBook=xls.Workbooks.Open("http://"+window.location.host+"/"+"DrvHelperSystem"+"/Templates/身体证明.xlt");
       // var xlBook=xls.Workbooks.Open("c:\驾驶证申请表-初学.xlt");
       // alert("xls.Workbooks.count->"+xls.Workbooks.Count)
         //alert("xlBook->"+xlBook);
         //xlBook.Save();
        //var xlsheet=xlBook.Worksheets(1);
        //alert("xlsheet->"+xlsheet);
        
        
         var xlsheet2=xls.Workbooks(1).Worksheets(1);
         
         xlsheet2.Cells(4,4).Value=document.getElementById("lbXm").innerText;
         
         xlsheet2.Cells(4,8).Value=document.getElementById("lbSex").innerText;
         //alert("csrq"+document.getElementById("txtCsrq").value);
          xlsheet2.Cells(4,14).Value=document.getElementById("lbBrithday").innerText;
          
         //alert("cbGjValue"+getText("cbGjValue"));
          xlsheet2.Cells(4,24).Value=document.getElementById("lbNation").innerText;
          
          
          
         
          
          var strtmp2=document.getElementById("lbIdCard").innerText;
          
          //alert(strtmp2);
          
          xlsheet2.Cells(5,4).Value=document.getElementById("lbIdCardType").innerText
          var i=11;
          var len=strtmp2.length;
          for(var j=0;j<len;j++)
          {
             xlsheet2.Cells(5,i+j).Value=strtmp2.charAt(j);
          }
          
           var oSheet = xls.Workbooks(1).ActiveSheet; 
           //alert(oSheet);
          oSheet.Cells(7,24).Select();//选中Excel中的单元格 
          var url="http://"+window.location.host+"/"+"DrvHelperSystem/DriverPerson/Apply"+"/ApplyInfoPhoto.aspx?idcard="+strtmp2;
          //document.write(url);
          oSheet.Pictures.Insert(url);//插入图片
          
            xlsheet2.Cells(6,5).Value=document.getElementById("lbLearnCar").innerText;
        
            xlsheet2.Cells(6,14).Value=document.getElementById("lbDabh").innerText;
         
        //alert("xlsheet2->"+xlsheet2);
       
       xlsheet2=null;
       xlsheet=null;
       xlBook=null;
        xls.Quit();
       xls=null;
       xlsheet2.Printout;
       idTmr = window.setInterval("Cleanup();",1)
       
      
       
    
    }
    function Cleanup() {
    window.clearInterval(idTmr);
    CollectGarbage();
  }

    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    体检受理
                </td>
            </tr>
            <tr class="table-title" style=" text-align:left">
            <td>查询条件</td>
            </tr>
            <tr class="table-content"><td>
    
        <table style="width:100%;"  border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-content">
                <td >
                    证件名称：<asp:DropDownList ID="cbIdCardType" runat="server" 
                Width="165px" CssClass="ddl" Font-Size="15pt">
                    </asp:DropDownList>
                </td>
                <td>
                    证件号码：<asp:TextBox ID="txtIdCard" runat="server" 
                Width="173px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td >
                    档案编号：<asp:TextBox ID="txtDabh1" runat="server" 
                Width="41px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtDabh2" runat="server" Width="114px"></asp:TextBox>
                </td>
                <td>
                    业务类型：<asp:DropDownList ID="cbBusType" runat="server" 
                Width="170px" CssClass="ddl" Font-Size="15pt">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
       
  
</td></tr>
 <tr class="table-title" style=" text-align:left">
            <td>体检详细信息</td>
            </tr>
    <tr  class="table-content"><td>
       
        
            <table style="width:100%;"  border="0" cellpadding="4" cellspacing="1" class="table-border">
                <tr class="table-content">
                    <td  class="table-title">
                        证件名称</td>
                    <td width="120px">
                        <asp:Label ID="lbIDCardType" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        证件号码</td>
                    <td width="120px">
                        <asp:Label ID="lbIdCard" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        档案编号</td>
                    <td width="160px">
                        <asp:Label ID="lbDabh" runat="server"></asp:Label>
                    </td>
                    <td rowspan="4">
                        <asp:Image ID="imgPerson" runat="server" Height="160px" Width="133px" 
                            BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        姓名</td>
                    <td>
                        <asp:Label ID="lbXm" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        性别</td>
                    <td>
                        <asp:Label ID="lbSex" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        出生日期</td>
                    <td>
                        <asp:Label ID="lbBrithday" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        国籍</td>
                    <td>
                        <asp:Label ID="lbNation" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        准驾车型</td>
                    <td>
                        <asp:Label ID="lbLearnCar" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        体检日期</td>
                    <td>
                        <asp:Label ID="lbCheckDay" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidLsh" runat="server" />
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        备注</td>
                    <td colspan="5">
                        <asp:Label ID="lbDescription" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    
                    <td colspan="7" style="text-align:right">
                        <asp:Button ID="btnPrint" runat="server" Text="打印" onclick="btnPrint_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnQuitBus" runat="server" Text="退办" 
                            onclick="btnQuitBus_Click" Enabled="False" />
                    </td>
                   
                </tr>
            </table>
        
        <table></table>
        
        </td></tr></table>

    </form>
</body>
</html>
