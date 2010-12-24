<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarOwerInfoChange.aspx.cs" Inherits="DriverPerson_PersonInfoChange_CarOwerInfoChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车主联系方式变更备案</title>
    <style type="text/css">


td {font-size:12px; line-height: 150%; text-decoration: none} 
        .style1
        {
            width: 203px;
            margin: 0;
            padding: 0;
        }
        .style2
        {
            width: 20px;
            margin: 0;
            padding: 0;
        }
        .style3
        {
            width: 177px;
            margin: 0;
            padding: 0;
        }
        .style4
        {
            width: 118px;
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
                    车主联系方式变更备案 
                </td>
            </tr>
            <tr>
                <td class="font5">
                    以下项目均为必填（选）项：</td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                请选择证件核发地:</td>
                            <td>
                                <select class="style1" name="city" onchange="citychange(this);">
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
                                </select> <span style="COLOR: red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                号 牌 号 码:</td>
                            <td>
                                <input id="jc" class="style2" maxlength="1" name="jc" size="1" value="粤" />
                                <input id="hphm" class="style3" name="hphm" 
                                    onkeyup="this.value=this.value.toUpperCase();" value="A" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                号牌种类:</td>
                            <td>
                                <select class="style1" name="hpzl" size="1">
                                    <option selected="" value="01">大型汽车</option>
                                    <option value="02">小型汽车</option>
                                    <option value="05">境外汽车</option>
                                    <option value="06">外籍汽车</option>
                                    <option value="07">两、三轮摩托车</option>
                                    <option value="11">境外摩托车</option>
                                    <option value="12">外籍摩托车</option>
                                    <option value="15">挂车</option>
                                    <option value="20">临时入境汽车</option>
                                    <option value="21">临时入境摩托车</option>
                                    <option value="22">临时行驶汽车</option>
                                    <option value="23">公安警车</option>
                                    <option value="99">其它</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                车架号码后5位:</td>
                            <td>
                                <input id="clsbdh" class="style4" name="clsbdh" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                发动机号码后5位:</td>
                            <td>
                                <input id="fdjh" class="style4" name="fdjh" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                登记证书号码:</td>
                            <td>
                                <input id="djzsbh" class="style4" name="djzsbh" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                手 机 号码:</td>
                            <td>
                                <input id="mobile" class="style1" jquery1293085623687="2" maxlength="11" 
                                    name="mobile" onchange="mobilechange();" /><span style="COLOR: red">*</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="font5">
                    请填写变更后的联系方式，三项都必须输入。 
                </td>
            </tr>
            <tr>
                <td class="font5">
                    联系地址:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="lxzsxxdz" class="style1" name="lxzsxxdz" />
                    <br />
                    邮政编码:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="postcode" class="style1" name="postcode" />
                    <br />
                    联系电话:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="lxdh" class="style1" name="lxdh" />
                    <br />
&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
