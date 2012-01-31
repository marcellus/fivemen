<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ApplyInfoAdd.aspx.cs"
    Inherits="DriverPerson_Apply_ApplyInfoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>初学+增驾申请详细信息</title>
    <meta content="no-cache" http-equiv="pragma">
    <base target="_self"></base>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
        	  vertical-align:top;
        }
       
       
        input
        {
            width: 80px;
            font-size: 9pt;
            height: 20px;
        }
    </style>
    <script> 
var   i   =   0 
function   tb() 
{ 
if(event.keyCode   ==   13){ 
if(i+1==document.getElementById("form1").elements.length) 
{ 
i=0 
document.getElementById("form1").elements[i].focus() 
} 
else 
alert("hah");
document.getElementById("form1").elements[++i].focus() 
} 

}

</script> 

    <script type="text/javascript" src="../../js/calendar.js"></script>
    <script src="../../js/validate-helper.js" type="text/javascript" ></script>
    <script type="text/javascript">
     var idTmr = "";
    var selectObj;
    var str = "";
    
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
        catch (e) {
            alert(e);
        alert("要打印该表，您必须安装Excel电子表格软件，同时浏览器须使用“ActiveX控件”，您的浏览器须允许执行控件。请【帮助】了解浏览器设置方法");
        return;
        }
       xls.visible=true;
        //alert("xls->"+xls);
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
       var xlBook=xls.Workbooks.Open

("http://"+window.location.host+"/Templates/驾驶证申请表-初学.xlt");
       // var xlBook=xls.Workbooks.Open("c:\驾驶证申请表-初学.xlt");+"/"+"DrvHelperSystem"
       // alert("xls.Workbooks.count->"+xls.Workbooks.Count)
         //alert("xlBook->"+xlBook);
         //xlBook.Save();
        //var xlsheet=xlBook.Worksheets(1);
       alert("xlsheet->"+xlsheet);
      // alert();
        
        
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
       idTmr = window.setInterval("Cleanup();", 1);



   }
    
    
    function Cleanup() {
    window.clearInterval(idTmr);
    CollectGarbage();
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


function searchArea() {

    var retval = window.showModalDialog('AreaSearch.aspx', '', 'dialogWidth:600px; dialogHeight:300px;');
    if (retval) {
        var arr = retval.split("|");
        document.getElementById("cbDjzsxzqhValue").options.length = 0;
        document.getElementById("cbDjzsxzqhValue").options[0] = new Option(arr[0], arr[1]);
        document.getElementById('txtLxzsxxdz').value = document.getElementById('txtDjzsxxdz').value = arr[2];
    }
}
  
  
    </script>

   
</head>
<body  onkeydown="if(event.keyCode==13) event.keyCode=9">
    <form id="form1" runat="server"  style=" padding-top:0px; margin-top:0px">
    <div>
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="poptable-title">
                <td colspan="8">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    驾驶人详细信息：&nbsp;
                    <asp:DropDownList ID="cbBustype" runat="server" TabIndex="1"></asp:DropDownList>
                  
                    <br />
                    <asp:Label ID="lbCheckResult" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="width: 80px">
                    证件名称
                </td>
                <td style="width: 600px">
                    <asp:DropDownList ID="cbSfzmmcValue" runat="server" Width="110px" 
                        Font-Size="9pt" TabIndex="2">
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="width: 90px">
                    证件号码
                </td>
                <td>
                    <asp:TextBox ID="txtSfzmhm" runat="server" Width="110px"  AutoPostBack="true"
                        ontextchanged="txtSfzmhm_TextChanged" TabIndex="3"></asp:TextBox>
                </td>
                <td class="table-title" style="width: 90px">
                    国籍
                </td>
                <td>
                    <asp:DropDownList ID="cbGjValue" runat="server"  Width="110px" Font-Size="12pt" TabIndex="4"
                        >
                    </asp:DropDownList>
                </td>
                <td colspan="2" rowspan="6">
                    <asp:ImageButton ID="imgPhoto" runat="server"  OnClick="imgPhoto_Click"
                        BorderStyle="Solid" BorderWidth="1px" Height="160px" Width="133px" TabIndex="116"/>
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="200px" TabIndex="117" />
                    <br />
                    <asp:Button ID="btnImgUpdate"  runat="server" OnClick="btnImgUpdate_Click" Text="上传照片" TabIndex="118"/>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    姓名
                </td>
                <td>
                    <asp:TextBox ID="txtXm" runat="server" Width="110px" TabIndex="5"></asp:TextBox>
                </td>
                <td class="table-title">
                    性别
                </td>
                <td>
                    <asp:DropDownList ID="cbXbValue" runat="server"  Width="110px" Font-Size="12pt" TabIndex="6">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title">
                    出生年月
                </td>
                <td>
                    <input onclick="calendar.show(this);" style="width: 110px" id="txtCsrq" runat="server" TabIndex="7"/>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    登记住所
                </td>
                <td colspan="5">
                                    <asp:DropDownList ID="cbDjzsxzqhP" runat="server"  Font-Size="9pt" 
                                        AutoPostBack="true" onselectedindexchanged="cbDjzsxzqhP_SelectedIndexChanged" TabIndex="8"
                         ></asp:DropDownList>
                   <asp:DropDownList ID="cbDjzsxzqhC" runat="server"  Font-Size="9pt" 
                        AutoPostBack="true" onselectedindexchanged="cbDjzsxzqhC_SelectedIndexChanged" TabIndex="9"
                         ></asp:DropDownList>
                    <asp:DropDownList ID="cbDjzsxzqhValue" runat="server"   AutoPostBack="true" 
                        Font-Size="9pt" TabIndex="10"
                        >
                    </asp:DropDownList>
                    <br />
               <!--
                    <a href="#" onclick="javascript:searchArea();">查询</a>&nbsp;
                     -->
                    <asp:TextBox
                        ID="txtDjzsxxdz" onkeyup="SynText()" runat="server" Width="500px" TabIndex="11"></asp:TextBox>
                       
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    联系住所
                </td>
                <td colspan="5">
                    <asp:DropDownList ID="cbLxzsxzqhP" runat="server"  Font-Size="9pt" AutoPostBack="true"
                        onselectedindexchanged="cbLxzsxzqhP_SelectedIndexChanged" TabIndex="12" ></asp:DropDownList>
                   <asp:DropDownList ID="cbLxzsxzqhC" runat="server"  Font-Size="9pt" 
                        AutoPostBack="true" onselectedindexchanged="cbLxzsxzqhC_SelectedIndexChanged" TabIndex="13"
                         ></asp:DropDownList>
                    <asp:DropDownList ID="cbLxzsxzqhValue" runat="server"  
                        Font-Size="9pt" TabIndex="14">
                    </asp:DropDownList>
                     <br />
                    <asp:TextBox ID="txtLxzsxxdz" runat="server" Width="500px" TabIndex="15"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    邮政编码
                </td>
                <td>
                    <asp:TextBox ID="txtLxzsyzbm" runat="server" Width="110px" TabIndex="16"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    联系电话
                </td>
                <td>
                    <asp:TextBox ID="txtLxdh" runat="server" Width="110px" TabIndex="17"></asp:TextBox>
                </td>
                <td class="table-title">行政规划</td>
                <td><asp:DropDownList ID="cbXzqhValue" runat="server"   Width="110px" 
                        Font-Size="9pt" TabIndex="18">
                    </asp:DropDownList></td>
                                    

            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    申请车型
                </td>
                <td>
                    <asp:DropDownList ID="cbZkcxValue" runat="server"  Width="110px" 
                        Font-Size="9pt" TabIndex="19">
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    驾驶人来源
                </td>
                <td>
                    <asp:DropDownList ID="cbLyValue" runat="server"  Width="110px" 
                        Font-Size="9pt" TabIndex="20">
                    </asp:DropDownList>
                </td>
                              <td class="table-title" style="">
                    体检日期
                </td>
                <td>
                    <input onclick="calendar.show(this);" style="width: 110px" id="txtTjrq" runat="server" TabIndex="21"/>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    准考证编号
                </td>
                <td>
                    <asp:Label ID="lbZkzmbh" runat="server" ></asp:Label>
                </td>
                <td class="table-title" style="">
                    暂住证号
                </td>
                <td>
                    <asp:TextBox ID="txtZzzm" runat="server" Width="110px" TabIndex="22"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    驾校名称
                </td>
                <td colspan="3">
                    <asp:Label ID="lbJxmc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="">
                    身高
                </td>
                <td>
                    <asp:TextBox ID="txtSg" runat="server" Width="60px" TabIndex="23"></asp:TextBox>
                    CM
                </td>
                <td class="table-title" style="">
                    视力
                </td>
                <td>
                    左<asp:TextBox ID="txtZsl" runat="server" Width="30px" TabIndex="24"></asp:TextBox>右<asp:TextBox
                        ID="txtYsl" runat="server" Width="30px" TabIndex="25"></asp:TextBox>
                </td>
                <td class="table-title" style="">
                    辨色力
                </td>
                <td>
                    <asp:DropDownList ID="cbBslValue" runat="server"  Font-Size="12pt" TabIndex="26">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    听力
                </td>
                <td>
                    <asp:DropDownList ID="cbTlValue" runat="server"  Font-Size="12pt" TabIndex="27">
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
                    <asp:DropDownList ID="cbSz" runat="server"  Font-Size="12pt" TabIndex="28">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    左下肢
                </td>
                <td>
                    <asp:DropDownList ID="cbZxz" runat="server"  Font-Size="12pt" TabIndex="29">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    右下肢
                </td>
                <td>
                    <asp:DropDownList ID="cbYxz" runat="server"  Font-Size="12pt" TabIndex="30">
                        <asp:ListItem Value="1">1：合格</asp:ListItem>
                        <asp:ListItem Value="0">0：不合格</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="table-title" style="">
                    躯干颈部
                </td>
                <td>
                    <asp:DropDownList ID="cbQgjb" runat="server"  Font-Size="12pt" TabIndex="31">
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
                    <asp:DropDownList ID="cbTjyy" runat="server"  Width="220px" Font-Size="12pt"
                        AutoPostBack="True" OnSelectedIndexChanged="cbTjyy_SelectedIndexChanged" TabIndex="32">
                    </asp:DropDownList>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtTjyymc" runat="server" Width="300px" TabIndex="33"></asp:TextBox>
                </td>

            </tr>
            <tr class="table-content">
                <td class="table-content" colspan="8" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" 
                        Text="保存" TabIndex="34"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCheckImage" runat="server" Text="审核图片" 
                        onclick="btnCheckImage_Click" TabIndex="35"/>&nbsp;&nbsp;
                    <asp:Button ID="btnCheck" runat="server" Text="审核资料" OnClick="btnCheck_Click" TabIndex="36"/>&nbsp;&nbsp;
                    <input id="Button2" style="width: 140px" class="button" onclick="printExcel();"
                        type="button" value="打印申请表" TabIndex="37"/>
                    &nbsp;&nbsp;
                    <input id="Button1" class="button" onclick="javascript:window.opener=null;window.close();"
                        type="button" value="关闭" TabIndex="38"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html> 