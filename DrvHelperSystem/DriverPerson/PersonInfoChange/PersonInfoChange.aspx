<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonInfoChange.aspx.cs" Inherits="DriverPerson_PersonInfoChange_PersonInfoChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>驾驶人联系方式变更备案</title>
    <style type="text/css">


td {font-size:12px; line-height: 150%; text-decoration: none} 
        .style1
        {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table border="0" cellpadding="0" cellspacing="0" width="98%">
            <tr>
                <td class="font5">
                    <img height="12" src="http://www.gdgajj.com/gdgajjwsbl/%20%20images/icon_2.gif" 
                        width="9" />驾驶人联系方式变更备案 
                </td>
            </tr>
            <tr>
                <td class="font5">
                    以下项目均为必填（选）项：</td>
            </tr>
            <tr>
                <td>
                    请选择证件核发地:
                    <select class="style1" name="city">
                        <option value="">请选择</option>
                        <option selected="" value="A">广州</option>
                        <option value="B">深圳</option>
                        <option value="S">东莞</option>
                        <option value="E">佛山</option>
                        <option value="Y">南海</option>
                        <option value="X">顺德</option>
                        <option value="G">湛江</option>
                        <option value="C">珠海</option>
                        <option value="D">汕头</option>
                        <option value="F">韶关</option>
                        <option value="H">肇庆</option>
                        <option value="J">江门</option>
                        <option value="K">茂名</option>
                        <option value="L">惠州</option>
                        <option value="M">梅州</option>
                        <option value="N">汕尾</option>
                        <option value="P">河源</option>
                        <option value="Q">阳江</option>
                        <option value="R">清远</option>
                        <option value="T">中山</option>
                        <option value="U">潮州</option>
                        <option value="V">揭阳</option>
                        <option value="W">云浮</option>
                    </select>
                    <br />
                    驾驶人姓名: &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="xm" class="style1" name="xm" />
                    <br />
                    身份证明种类 &nbsp;
                    <select class="style1" name="sfzmmc">
                        <option selected="" value="A">身份证</option>
                        <option value="C">军官证</option>
                        <option value="D">士兵证</option>
                        <option value="E">军官离退休证</option>
                        <option value="F">境外人员身份证明</option>
                        <option value="G">外交人员身份证明</option>
                    </select>
                    <br />
                    身份证明号码&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="sfzmhm" class="style1" name="sfzmhm" />(身份证号码要求18位)
                    <br />
                    档 案 编号:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="dabh" class="style1" name="dabh" />
                    <br />
                    手 机 号码:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="mobile" class="style1" maxlength="11" name="mobile" 
                        onchange="mobilechange();" /><span style="COLOR: red">*</span>
                </td>
            </tr>
            <tr>
                <td class="font5">
                    请填写变更后的联系方式，三项都必须输入。 
                </td>
            </tr>
            <tr>
                <td class="font5">
                    联 系 地址:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="lxzsxxdz" class="style1" name="lxzsxxdz" />(必须包含省、直辖市、自治区的名字)
                    <br />
                    邮 政 编码:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="postcode" class="style1" name="postcode" />
                    <br />
                    联 系 电话:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="lxdh" class="style1" name="lxdh" />
                    <br />
                    <img height="20" onclick="submitJszForm();" 
                        src="http://www.gdgajj.com/gdgajjwsbl/%20images/btn_enter.gif" 
                        style="CURSOR: pointer" width="67" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
