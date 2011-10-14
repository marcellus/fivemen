var commonRules=

{
    message:
	[
	 {
	   method:"Require",//方法名索引0 
	   message:"请输入值！",//默认的消息
	   regex:/^.+/
	 },
	 {
	   method:"NeedNumber",//方法名索引1 验证正整数
	   message:"请输入数字！",//默认的消息
	   regex:/^\d+$/	   
	 },
	 {
	   method:"NeedDate",//方法名索引2 验证日期
	   message:"请输入格式为yyyy-MM-dd的日期！",//默认的消息
	   regex:/^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$/	   
	 },
	 {
		 method:"NeedMobile",//索引3 验证手机号码
		 message:"请输入格式正确的手机号码！", 
		 regex:/(^0?[1][35][0-9]{9}$)/
	 },
	 {
		 method:"NeedIp",//索引4 验证ip
		 message:"请输入正确的ip格式！",
		 regex:/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/
	 },
	 {
		 method:"NeedPhone",//索引5 验证固定电话
		 message:"请输入正确的固定电话格式！", 
		 regex:/^((0[1-9]{3})?(0[12][0-9])?[-])?\d{6,8}$/
	 },
	 {
		 method:"NeedAlpha",//索引6  验证字母
		 message:"请输入字母！",
		 regex:/^[a-zA-Z]+$/
	 },
	 {
		 method:"NeedChinese",//索引7  验证汉字
		 message:"请输入汉字！",
		 regex:/^[\u4e00-\u9fa5]+$/
	 },
	 {
		 method:"NeedAlphaNum",//索引8  验证字母和数字
		 message:"请输入字母或者数字！",
		 regex:/^\w+$/
		 
	 },
	 {
		 method:"NeedEmail",//索引9  验证email
		 message:"请格式正确的Email格式！",
		 regex:/\w{1,}[@][\w\-]{1,}([.]([\w\-]{1,})){1,3}$/
		 
	 },
	 {
		 method:"NeedUrl",//索引10  验证url
		 message:"请输入正确的Url格式！",
		 regex:/^(http|https|ftp):\/\/(([A-Z0-9][A-Z0-9_-]*)(\.[A-Z0-9][A-Z0-9_-]*)+)(:(\d+))?\/?/i
	 },
	  {
		 method:"NeedSelected",//索引11  dropdownlist选择索引必须大于0
		 message:"请选择一个值！"		
	 },
	  {
		 method:"NeedSelectMore",//索引12 listbox使用，
		 message:"请选择{0} {1}个选项！"		
	 },
	  {
		 method:"CheckRange",//索引13 ，checkboxlist使用
		 message:"请选择{0} {1}个选项！"		
	 },
	  {
		 method:"NeedRadio",//索引14  radiobuttonlist使用
		 message:"请选择一个选项！"		
	 },
	 {
		 method:"NeedPhoneOrTel",//索引15  输入手机或者固定电话
		 message:"请输入正确的电话格式，固话以-格开！",
		 regex:/^((0[1-9]{3})?(0[12][0-9])?[-])?\d{6,8}$|(^0?[1][35][0-9]{9}$)/
	 },
	 {
		 method:"NeedFloatOrInt",//索引16 验证数字
		 message:"请输入小数或者正整数！",
		 regex:/^[0-9]+\.?[0-9]*$/
	 }
	 
	]	
}