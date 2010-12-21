function jstrim(s_value)
{
		var i;
		var ibegin;
		for(i=0;i<s_value.length;i++)
		{
				if(s_value.charAt(i)!=' ')
					break;
		}

		if(i==s_value.length)
				return "";
		else
				ibegin=i;
				
		for(i=s_value.length-1;i>=0;i--)
		{
				if(s_value.charAt(i)!=' ')
				break;
		}
		return s_value.substr(ibegin,i-ibegin+1);
}

//使用监控程序读取条码，定时读取看是否有条码信息
function readQrtext(){
	  if (checkDy()){
  			var barcodetemp ="";
  			var strbarcode=vehPrinter.GetQrText();
    		if (strbarcode=="" ){
        			return 0;
    		}
    		if (strbarcode=="-1"){
        		setPrompt("读取二代证信息时发生错误，请检查设备是否正确连接!");
       			 return 0;
    		}
    		setPrompt("成功读取信息！");
   			parseCardInfo(strbarcode);
    	}
}


