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

//ʹ�ü�س����ȡ���룬��ʱ��ȡ���Ƿ���������Ϣ
function readQrtext(){
	  if (checkDy()){
  			var barcodetemp ="";
  			var strbarcode=vehPrinter.GetQrText();
    		if (strbarcode=="" ){
        			return 0;
    		}
    		if (strbarcode=="-1"){
        		setPrompt("��ȡ����֤��Ϣʱ�������������豸�Ƿ���ȷ����!");
       			 return 0;
    		}
    		setPrompt("�ɹ���ȡ��Ϣ��");
   			parseCardInfo(strbarcode);
    	}
}


