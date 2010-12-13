<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationTest2.aspx.cs" Inherits="ValidationTest2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
  <head>
    <title>ValidationTest</title>
    <link href="css/styles.css" type="text/css" rel="stylesheet" />
  </head>
  <body MS_POSITIONING="GridLayout">
	
    <form id="Form1" method="post" runat="server">
<table align="center" style="width:96%; border:1px; border-color:blue">
 
    <tr>
   <td>真实姓名：</td><td><input name="name" value="myname" id="name" class=" validate-chinese" />
  
   
   </td>
  </tr>
  <tr>
   <td>英文名：</td><td><input  name="english" id="english" class='required validate-alpha' /></td>
  </tr>
  <tr>
   <td>IP：</td><td><input  name="ip" id="ip" class='required validate-alpha' /></td>
  </tr>
   <tr>
   <td>中文名：</td><td><input  name="chinese" id="chinese" class='required validate-alpha' /></td>
  </tr>
    <tr>
   <td>主页：</td><td><input name="personPage" id="personPage" class='required validate-url' /></td>
  </tr>
  <tr>
   <td>密码：</td><td><input name="password" id="password" class='required' ></td>
  </tr>
  <tr>
   <td>重复：</td><td><input name="passwordRepeat" id="passwordRepeat" class='required validate-equals-password' ></td>
  </tr>
  <tr>
   <td>邮箱：</td><td><input name="email" id="email"  class='required validate-email'></td>
  </tr>
  <tr><td>alphanum</td><td>
  <input name="alphanum" id="alphanum"  class='required validate-email'></td></tr>
  <tr>
   <td>QQ：</td><td><input name="qq"  id="qq" class='required  validate-pattern-/^[1-9]\d{4,11}$/'></td>
  </tr>
    <tr>
   <td>身份证：</td><td><input name="card" id="card" class='required validate-pattern-/^\d{15}(\d{2}[A-Za-z0-9])?$/'></td>
  </tr>
  <tr>
   <td>电话 或者手机 </td>
   <td><input name="year1" id="year1" class='required  validate-number' ></td>
  </tr>
   <tr>
   <td>年龄1：</td><td><input name="year2" id="year2" class='required  validate-int-range-18-25'></td>
  </tr>
   <tr>
   <td>电话：</td><td><input name="phone" id="phone" class='required validate-phone'></td>
  </tr>
   <tr>
   <td>手机：</td><td><input name="mobile" id="mobile" class='required validate-mobile-phone'></td>
  </tr>
     <tr>
   <td>生日：</td><td><input  name="birthday" id="birthday" class='required validate-date-cn' ></td>
  </tr>
   <tr>
   <td>邮政编码：</td><td><input name="zip" id="zip" class="required validate-pattern-/^[1-9]\d{5}$/"></td>
  </tr>
  <tr>
   <td>操作系统：</td><td>
   <select name="operation"  id="operationId" class="select-range-1-2" multiple>
   <option value="">选择您所用的操作系统</option>
   <option value="Win98">Win98</option>
   <option value="Win2k">Win2k</option>
   <option value="WinXP">WinXP</option>
   </select>
   </td>
  </tr>
    <tr>
   <td>请选择所在地区：</td><td>
   <select class="select-one-required" >
   <option value="">请选择所在地区</option>
   <option value="1">大陆</option>
   <option value="2">台湾</option>
   <option value="3">国外</option>
   <option value="4">地球外</option>
   </select>
   </td>
  </tr>
  <tr>
   <td>所在省份：</td><td>广东
   <input name="province" value="1" type="radio">陕西
   <input name="province" value="2" type="radio">浙江
   <input name="province" value="3" type="radio">江西
   <input name="province" value="4" type="radio"  id="provinceId" class="validate-one-required"></td>
  </tr>
  <tr>
   <td>爱好：</td><td>运动
   <input name="favorite" value="1" type="checkbox" class="validate-one-required">上网
   <input name="favorite" value="2" type="checkbox" class="validate-one-required">听音乐
   <input name="favorite" value="3" type="checkbox" class="validate-one-required">看书
   <input name="favorite" value="4" type="checkbox""  class="validate-one-required">
   </td>
  </tr>
    <tr>
   <td>关注ing：</td><td>汽车
   <input name="attion" value="1" type="checkbox">房价
   <input name="attion" value="2" type="checkbox">美女
   <input name="attion" value="3" type="checkbox">旅游
   <input name="attion" value="4" type="checkbox""  class="checkbox-range-1-2">
   </td>
  </tr>
   <td>自我介绍：</td><td>
   <textarea name="description" id="description" class="validate-length-range-2-5">中文是一个字</textarea></td>
  </tr>
     <td>自传：</td><td>
	 <textarea name="history" id="history"  msg="自传内容必须在[3,10]个字节之内" class="validate-lengthB-range-2-5">中文是两个字节t</textarea></td>
  </tr>
  <tr>
   <td colspan="2">
   <input value="提交" type="submit">
   <input value="重置" type="reset">
   </td>
  </tr> </table>
 <div>
 <table>
 <tr><td>listbox：</td><td><select name="ListBox1" size="4" multiple="multiple" id="ListBox1" style="height:88px;width:80px;Z-INDEX: 101;">
	<option selected="selected" value="7">7</option>
	<option selected="selected" value="8">8</option>
	<option value="9">9</option>

</select></td></tr>
 <tr><td>checkbox：</td><td><table id="CheckBoxList1" border="0" style="Z-INDEX: 102; ">
	<tr>
		<td><input id="CheckBoxList1_0" type="checkbox" name="CheckBoxList1:0" /><label for="CheckBoxList1_0">4</label></td>
	</tr><tr>
		<td><input id="CheckBoxList1_1" type="checkbox" name="CheckBoxList1:1" /><label for="CheckBoxList1_1">5</label></td>
	</tr><tr>
		<td><input id="CheckBoxList1_2" type="checkbox" name="CheckBoxList1:2" /><label for="CheckBoxList1_2">6</label></td>
	</tr>
</table></td></tr>
<tr><td>RadioButtonList</td><td><table id="RadioButtonList1" border="0" style="Z-INDEX: 103;">
	<tr>
		<td><input id="RadioButtonList1_0" type="radio" name="RadioButtonList1" value="1" /><label for="RadioButtonList1_0">1</label></td>
	</tr><tr>
		<td><input id="RadioButtonList1_1" type="radio" name="RadioButtonList1" value="2" /><label for="RadioButtonList1_1">2</label></td>
	</tr><tr>
		<td><input id="RadioButtonList1_2" type="radio" name="RadioButtonList1" value="3" /><label for="RadioButtonList1_2">3</label></td>
	</tr>
</table></td></tr>
<tr><td>DropDownList</td><td><select name="DropDownList1" id="DropDownList1" style="Z-INDEX: 104;">
	<option value="请选择">请选择</option>
	<option value="请选择">1</option>
	<option value="请选择">2</option>

</select></td></tr>
 
 </table>
     </form>
     <script src="js/prototype.js" language="javascript"></script>
       <script src="js/commonRules.js" language="javascript"></script>
<script src="js/simpleValidation.js" language="javascript"></script>
  <script src="js/simple.js" language="javascript"></script>
	
  </body>
</html>
