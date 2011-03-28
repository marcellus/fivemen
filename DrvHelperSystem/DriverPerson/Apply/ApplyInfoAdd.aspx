<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="ApplyInfoAdd.aspx.cs" Inherits="DriverPerson_Apply_ApplyInfoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>初学+增驾申请详细信息</title>
    <meta content="no-cache" http-equiv="pragma">
    
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    
    <style type="text/css">
        input
        {
            width: 80px;
            font-size: 12pt;
            height: 28px;
        }
    </style>

    <script type="text/javascript" src="../../js/calendar.js"></script>
<script src="../../js/validate-helper.js" type="text/javascript" />
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
       var xlBook=xls.Workbooks.Open("http://"+window.location.host+"/"+"DrvHelperSystem"+"/Templates/驾驶证申请表-初学.xlt");
       // var xlBook=xls.Workbooks.Open("c:\驾驶证申请表-初学.xlt");
       // alert("xls.Workbooks.count->"+xls.Workbooks.Count)
         //alert("xlBook->"+xlBook);
         //xlBook.Save();
        //var xlsheet=xlBook.Worksheets(1);
        //alert("xlsheet->"+xlsheet);
        
        
         var xlsheet2=xls.Workbooks(1).Worksheets(1);
         
         xlsheet2.Cells(4,3).Value=document.getElementById("txtXm").value;
         
         xlsheet2.Cells(4,14).Value=getSelectText("cbXbValue");
         //alert("csrq"+document.getElementById("txtCsrq").value);
          xlsheet2.Cells(4,19).Value=document.getElementById("txtCsrq").value;
          
         //alert("cbGjValue"+getText("cbGjValue"));
          xlsheet2.Cells(4,27).Value=getText("cbGjValue");
          
          
         
          
          var strtmp2=document.getElementById("txtSfzmhm").value;
          
          
          
          xlsheet2.Cells(5,3).Value=getText("cbSfzmmcValue");
          var i=7;
          var len=strtmp2.length;
          for(var j=0;j<len;j++)
          {
             xlsheet2.Cells(5,i+j).Value=strtmp2.charAt(j);
          }
          
           var oSheet = xls.Workbooks(1).ActiveSheet; 
           //alert(oSheet);
          oSheet.Cells(5,25).Select();//选中Excel中的单元格 
          var url="http://"+window.location.host+"/"+"DrvHelperSystem/DriverPerson/Apply"+"/ApplyInfoPhoto.aspx?idcard="+strtmp2;
          //document.write(url);
          oSheet.Pictures.Insert(url);//插入图片
          
          //alert("zzz");
          var tmp=document.getElementById("txtZzzm").value;
         // alert(tmp);
          if(tmp&&tmp.length>0)
          {
            xlsheet2.Cells(6,3).Value="暂住证";
            len=tmp.length;
            for(var j=0;j<len;j++)
            {
                xlsheet2.Cells(6,i+j).Value=tmp.charAt(j);
            }
          }
          
            xlsheet2.Cells(7,3).Value=document.getElementById("txtDjzsxxdz").value;
            
            xlsheet2.Cells(8,3).Value=document.getElementById("txtLxzsxxdz").value;
            xlsheet2.Cells(9,3).Value=document.getElementById("txtLxdh").value;
            
             //alert("txtLxzsyzbm"+document.getElementById("txtLxzsyzbm").value);
            xlsheet2.Cells(9,18).Value=document.getElementById("txtLxzsyzbm").value;
            xlsheet2.Cells(10,11).Value=document.getElementById("cbZkcxValue").value;
         
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
  
  function SearchArea()
  {
  var retval = window.showModalDialog('AreaSearch.aspx', '','dialogWidth:500px; dialogHeight:400px;');
  if(retval)
  {
    var arr=retval.split("|");
    document.getElementById("cbDjzsxzqhValue").options.length=0;
    document.getElementById("cbDjzsxzqhValue").options[0]=new Option(arr[0],arr[1]);
    
    document.getElementById('txtLxzsxxdz').value=document.getElementById('txtDjzsxxdz').value=arr[2];
  }

  }
  function SynText()
  {
     document.getElementById('txtLxzsxxdz').value=document.getElementById('txtDjzsxxdz').value;
  }
  function ValidateText()
  {
  
   var idcard=checkIdCardNo(document.getElementById('txtSfzmhm').value);
   var phone=CheckPhone(document.getElementById('txtLxdh').value);
     var postcode=CheckPostCode(document.getElementById('txtLxzsyzbm').value);
 return idcard&&phone&&postcode;
  
  }
    
    </script>

    <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="poptable-title">
                <td colspan="8">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    驾驶人详细信息：&nbsp;
                    <br />
                    <asp:Label ID="lbCheckResult" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="width: 90px">
                    证件名称
                </td>
                <td style="width: 600px">
                    <asp:DropDownList ID="cbSfzmmcValue" runat="server" Width="110px" Height="16px" Font-Size="12pt">
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="width: 90px">
                    证件号码
                </td>
                <td>
                    <asp:TextBox ID="txtSfzmhm" runat="server" Width="110px"></asp:TextBox>
                </td>
                <td class="table-title" style="width: 90px">
                    国籍
                </td>
                <td>
                    <asp:DropDownList ID="cbGjValue" runat="server" Height="16px" Width="110px" Font-Size="12pt">
                    </asp:DropDownList>
                </td>
                <td colspan="2" rowspan="6">
                    <asp:ImageButton ID="imgPhoto" runat="server" ImageUrl="~/images/no_photo.jpg" OnClick="imgPhoto_Click"
                        BorderStyle="Solid" BorderWidth="1px" Height="160px" Width="133px" />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="200px" />
                    <br />
                    <asp:Button ID="btnImgUpdate" runat="server" OnClick="btnImgUpdate_Click" Text="上传照片" />
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    姓名
                </td>
                <td>
                    <asp:TextBox ID="txtXm" runat="server" Width="110px"></asp:TextBox>
                </td>
                <td class="table-title">
                    性别
                </td>
                <td>
                    <asp:DropDownList ID="cbXbValue" runat="server" Height="16px" Width="110px" Font-Size="12pt">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title">
                    出生年月
                </td>
                <td>
                    <input onclick="calendar.show(this);" style="width: 110px" id="txtCsrq" runat="server" />
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    登记住所
                </td>
                <td>
                    <asp:DropDownList ID="cbDjzsxzqhValue" runat="server" Height="16px" Width="110px"
                        Font-Size="12pt">
                    </asp:DropDownList>
                    
                </td>
                <td colspan="4">
                    <a href="#" onclick="SearchArea();">查询</a>&nbsp;<asp:TextBox ID="txtDjzsxxdz"  onkeyup="SynText()" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    联系住所
                </td>
                <td>
                    <asp:DropDownList ID="cbLxzsxzqhValue" runat="server" Height="16px" Width="110px"
                        Font-Size="12pt">
                    </asp:DropDownList>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtLxzsxxdz" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    邮政编码
                </td>
                <td>
                    <asp:TextBox ID="txtLxzsyzbm" runat="server" Width="110px"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    联系电话
                </td>
                <td>
                    <asp:TextBox ID="txtLxdh" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    行政区划
                </td>
                <td>
                    <asp:DropDownList ID="cbXzqhValue" runat="server" Height="16px" Width="110px" Font-Size="12pt">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    申请车型
                </td>
                <td>
                    <asp:DropDownList ID="cbZkcxValue" runat="server" Height="16px" Width="110px" Font-Size="12pt">
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    驾驶人来源
                </td>
                <td>
                    <asp:DropDownList ID="cbLyValue" runat="server" Height="16px" Width="110px" Font-Size="12pt">
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    暂住证号
                </td>
                <td>
                    <asp:TextBox ID="txtZzzm" runat="server" Width="110px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    准考证编号
                </td>
                <td>
                    <asp:Label ID="lbZkzmbh" runat="server"></asp:Label>
                </td>
                <td class="table-title" style="">
                    驾校名称
                </td>
                <td colspan="5">
                    <asp:Label ID="lbJxmc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    身高
                </td>
                <td>
                    <asp:TextBox ID="txtSg" runat="server" Width="60px"></asp:TextBox>
                    CM
                </td>
                <td class="table-title" style="">
                    视力
                </td>
                <td>
                    左<asp:TextBox ID="txtZsl" runat="server" Width="30px"></asp:TextBox>右<asp:TextBox
                        ID="txtYsl" runat="server" Width="30px"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    辨色力
                </td>
                <td>
                    <asp:DropDownList ID="cbBslValue" runat="server" Height="16px" Font-Size="12pt">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    听力
                </td>
                <td>
                    <asp:DropDownList ID="cbTlValue" runat="server" Height="16px" Font-Size="12pt">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    上肢
                </td>
                <td>
                    <asp:DropDownList ID="cbSz" runat="server" Height="16px" Font-Size="12pt">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    左下肢
                </td>
                <td>
                    <asp:DropDownList ID="cbZxz" runat="server" Height="16px" Font-Size="12pt">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    右下肢
                </td>
                <td>
                    <asp:DropDownList ID="cbYxz" runat="server" Height="16px" Font-Size="12pt">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    躯干颈部
                </td>
                <td>
                    <asp:DropDownList ID="cbQgjb" runat="server" Height="16px" Font-Size="12pt">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    体检医院
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="cbTjyy" runat="server" Height="16px" Width="220px" Font-Size="12pt"
                        AutoPostBack="True" OnSelectedIndexChanged="cbTjyy_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtTjyymc" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    体检日期
                </td>
                <td>
                    <input onclick="calendar.show(this);" style="width: 110px" id="txtTjrq" runat="server" />
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-content" colspan="8" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" OnClientClick="javascript:return ValidateText();" Text="保存" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCheck" runat="server" Text="审核" OnClick="btnCheck_Click" />&nbsp;&nbsp;
                    <input id="Button2" style="width: 140px" class="button" onclick="javascript:printExcel();"
                        type="button" value="打印申请表" />
                    &nbsp;&nbsp;
                    <input id="Button1" class="button" onclick="javascript:window.opener=null;window.close();"
                        type="button" value="关闭" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</htwml> 