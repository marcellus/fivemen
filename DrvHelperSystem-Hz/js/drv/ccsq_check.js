function check_ccsq_record(_prefix)  //����ǰ����У��
{
     var o_ly;
     var o_djzsxzqh;
     var o_lxzsxzqh;
     var o_djzsxxdz;
     var o_lxzsxxdz;
     var o_sfbd;
     var o_xzqh;
     var o_sqdm;
     var o_sqcx;
     var o_csrq;
     var o_lxdh;
     var o_sjhm;
     if(_prefix=="ps_")
     {
        o_ly=document.all["ec_ly"];
        o_lxzsxzqh=document.all["ps_lxzsxzqh"];
        o_lxzsxxdz=document.all["ps_lxzsxxdz"];
        o_djzsxzqh=document.all["ps_djzsxzqh"];
        o_djzsxxdz=document.all["ps_djzsxxdz"];
        o_xzqh=document.all["ec_xzqh"];
        o_sqdm=document.all["ec_sqdm"];
        o_sfbd=document.all["ps_sfbd"];
        o_sqcx=document.all["ec_zkcx"];
        o_csrq=document.all["ps_csrq"];
        o_lxdh=document.all["ps_lxdh"];
        o_sjhm=document.all["ps_sjhm"];
     }
     else if(_prefix=="tp_")
     {
        o_ly=document.all["tp_ly"];
        o_lxzsxzqh=document.all["tp_lxzsxzqh"];
        o_lxzsxxdz=document.all["tp_lxzsxxdz"];        
        o_djzsxzqh=document.all["tp_djzsxzqh"];
        o_djzsxxdz=document.all["tp_djzsxxdz"];
        o_xzqh=document.all["tp_xzqh"];
        o_sqdm=document.all["tp_sqdm"];
        o_sfbd=document.all["tp_sfbd"];
        o_sqcx=document.all["tp_zkcx"];
        o_csrq=document.all["tp_csrq"]; 
        o_lxdh=document.all["tp_lxdh"];
        o_sjhm=document.all["tp_sjhm"];        
     }     
     else if(_prefix=="li_")
     {
        o_ly=document.all["li_ly"];
        o_lxzsxzqh=document.all["li_lxzsxzqh"];
        o_lxzsxxdz=document.all["li_lxzsxxdz"];        
        o_djzsxzqh=document.all["li_djzsxzqh"];
        o_djzsxxdz=document.all["li_djzsxxdz"];
        o_xzqh=document.all["li_xzqh"];
        o_sqdm=document.all["li_sqdm"];
        o_sfbd=document.all["li_sfbd"];
        o_sqcx=document.all["li_zkcx"];
        o_csrq=document.all["li_csrq"]; 
        o_lxdh=document.all["li_lxdh"];
        o_sjhm=document.all["li_sjhm"];        
     }
     else if(_prefix=="lo_")
     {
        o_ly=document.all["lo_ly"];
        o_lxzsxzqh=document.all["lo_lxzsxzqh"];
        o_lxzsxxdz=document.all["lo_lxzsxxdz"];        
        o_djzsxzqh=document.all["lo_djzsxzqh"];
        o_djzsxxdz=document.all["lo_djzsxxdz"];
        o_xzqh=document.all["lo_xzqh"];
        o_sqdm=document.all["lo_sqdm"];
        o_sfbd=document.all["lo_sfbd"];
        o_sqcx=document.all["lo_zkcx"];
        o_csrq=document.all["lo_csrq"];
        o_lxdh=document.all["lo_lxdh"];
        o_sjhm=document.all["lo_sjhm"];        
     }     
     var o_gnid=document.all["gnid"];
  	 var gnid="";
  	 if(o_gnid!=undefined)
  	 {
  		 gnid=o_gnid.value;
  	 }
  	 
  	 if(gnid=="0101")
  	 {		
     	if(!(o_ly.value=="A" ||o_ly.value=="B" ))
     	{
      		alert("��ʻ����Դֻ��Ϊ���ػ����!");
      		//setFocus(o_ly);
      		return false;
  		}
     	if(o_djzsxzqh!=undefined&&o_djzsxzqh.tagName=="SELECT")
     	{
     		//�����ʻ����Դ�͵Ǽ�ס���Ƿ�һ�£����ء���أ�
     		if(o_djzsxzqh.options(o_djzsxzqh.selectedIndex).text=="���")
     		{
     			if(o_ly.value=="A")
     			{
     				alert("ס����ַΪ��أ���ԴΪ���أ�������Ϣ¼���Ƿ���ȷ!");
     				//setFocus(o_ly);
     				return false;
     			}
     		}
     		else
     		{
     			if(o_ly.value=="B")
     			{
     				alert("ס����ַΪ���أ���ԴΪ��أ�������Ϣ¼���Ƿ���ȷ!");
     				//setFocus(o_ly);
     				return false;
     			}
     		}
     	}
  	}
  	if(gnid=="0104")
  	{
  		var zjcx = o_sqcx.value;
  		if(document.all["ec_dabh"].value!="#"){
	  		if(zjcx.indexOf("A1")>=0 || zjcx.indexOf("A2")>=0 ||zjcx.indexOf("B1")>=0||zjcx.indexOf("B2")>=0){
	  	  		if(document.all["dabh2"]!=undefined&&document.all["dabh2"].value!=""){
	  	  			alert("���쳵��ΪA1��A2��B1��B2�ģ�����ʱ������д������š�");
	  	  			document.all["dabh2"].focus();
	  	  			return false;
	  	  		}
	  		}else{
	  	  		if(document.all["dabh2"]!=undefined&&document.all["dabh2"].value==""){
	  	  			alert("������Ų���Ϊ��!");
	  	  			document.all["dabh2"].focus();
	  	  			return false;
	  	  		}  			
	  		}
  		}
  	}
  	if(gnid=="0106")
  	{
  		var zjcx = o_sqcx.value;
  		if(document.all["ck_sfmk"]!=undefined){
	  		var bSfmk = document.all["ck_sfmk"].checked;
	  		if(document.all["ec_dabh"].value!="#"){
		  		if(bSfmk==false){
		  	  		if(document.all["dabh2"]!=undefined&&document.all["dabh2"].value!=""){
		  	  			alert("���⿼�ģ�����ʱ������д������š�");
		  	  			document.all["dabh2"].focus();
		  	  			return false;
		  	  		}
		  		}else{
		  	  		if(document.all["dabh2"]!=undefined&&document.all["dabh2"].value==""){
		  	  			alert("������Ų���Ϊ��!");
		  	  			document.all["dabh2"].focus();
		  	  			return false;
		  	  		}  			
		  		}
	  		}
  		}
  	}  	
    if(o_ly.value=="C")
    {
      alert("��ʻ��ת������ת�뻻֤ģ������!");
      //o_ly.focus();
      return false;
    }
    
    
    //add by zou 20080724 �ж��Ƿ��Ǳ��ص�ַ
    var djzsxxdz = o_djzsxxdz.value;
    var bddzxx = document.all["bddzxx"].value;
    var isLocal = checkIsLocal(bddzxx,djzsxxdz);
    if(o_djzsxzqh!=undefined&&o_djzsxzqh.tagName=="SELECT")
    {
    	if(!isLocal && o_djzsxzqh.options(o_djzsxzqh.selectedIndex).text!="���")
    	{
    		alert("ס����ַ����أ�ס����������Ϊ���أ�������Ϣ¼���Ƿ���ȷ��");
    		return false;
    	}
    	if(isLocal&& o_djzsxzqh.options(o_djzsxzqh.selectedIndex).text=="���")
    	{
    		alert("ס����ַ�Ǳ��أ�ס����������Ϊ��أ�������Ϣ¼���Ƿ���ȷ��");
    		return false;   		
    	}
    }
    if (isLocal)
    {
        o_sfbd.value = "1";
    }
    else
    {
    	o_sfbd.value = "0";
    }
  	//���졢�������⼮,�Ǽ�ס������أ�����������ס֤��   
    /*
    if (gnid=="0101" || gnid=="0104" || gnid=="0106")
    {
    	if(!isLocal){
	        if(document.all["ec_zzzm"].value=="")
	        {
	        	alert("��ǰ�����˵Ǽ�ס����ַ����ص�ַ����������ס֤�ţ�");
	        	document.all["ec_zzzm"].focus();
	            return false;
	        }
    	}else{
	        if(document.all["ec_zzzm"].value!="")
	        {
	        	alert("��ǰ�����˵Ǽ�ס����ַ�Ǳ��صص�ַ������������ס֤�ţ�");
	        	document.all["ec_zzzm"].focus();
	            return false;	        	
	        }
    	}
    }
*/
  	if(o_lxzsxxdz.value.length==0)
  	{
  		for (i=0;i<o_lxzsxzqh.length; i++)
  		{
  			if (o_lxzsxzqh.options(i).value==o_djzsxzqh.value)
  			{
  				o_lxzsxzqh.value=o_djzsxzqh.value
      		}
    	}
    	o_lxzsxxdz.value=o_djzsxxdz.value;
  	}
  
  	//if (o_ly.value=="A" ||o_ly.value=="B")
  	//{
    	var ls_ret ;

  		ls_ret = check_dzxx(_prefix);
      	if (ls_ret != "1")
      	{
        	alert(ls_ret);
        	return false;
      	}
  	//}
  	
  	//�������Ϸ����ж�
  	if(check_tjxx(o_sqcx.value)==0)
  	{
		return false;
    }	
  	
  	//������������
  	var o_xiangzhen=document.all["xiangzhen"];
    var o_cun=document.all["cun"];
    if(o_xiangzhen!=undefined&&o_cun!=undefined)
    {
    	var ls_xzqh = o_xzqh.value; //��������
    	var ls_xz   = o_xiangzhen.value;   //��
    	if (ls_xz == "") ls_xz = "000";
    	var ls_cun  = o_cun.value;       //��
    	if (ls_cun == "") ls_cun = "000";
    	o_sqdm.value = ls_xzqh + ls_xz + ls_cun; //��������
    }
    //�ж�
    if(o_lxdh.value=="" && o_sjhm.value==""){
        alert("�̶��绰���ƶ��绰����ͬʱΪ�ա�");
        return false;    	
    }
    return true;    	
}








