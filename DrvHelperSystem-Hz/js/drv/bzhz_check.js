
function check_bzhz_record(_prefix)  //����ǰ����У��
{
     var o_ly;
     var o_djzsxzqh;
     var o_lxzsxzqh;
     var o_djzsxxdz;
     var o_lxzsxxdz;
     var o_sfbd;
     var o_xzqh;
     var o_sqdm;
     var o_csrq;
     var o_zjcx;
     var o_yzjcx;
     var o_lxdh;
     var o_sjhm; 
     var o_sfzmmc;
     var o_sfzmhm;
     var o_gj;
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
        o_csrq=document.all["ps_csrq"];
        o_zjcx=document.all["ec_zjcx"];
        o_yzjcx=document.all["ec_yzjcx"];
        o_lxdh=document.all["ps_lxdh"];
        o_sjhm=document.all["ps_sjhm"];  
        o_sfzmmc=document.all["ps_sfzmmc"];
        o_sfzmhm=document.all["ps_sfzmhm"];
        o_gj=document.all["ps_gj"];
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
        o_csrq=document.all["tp_csrq"];  
        o_zjcx=document.all["tp_zjcx"];
        o_yzjcx=document.all["tp_yzjcx"];  
        o_lxdh=document.all["tp_lxdh"];
        o_sjhm=document.all["tp_sjhm"]; 
        o_sfzmmc=document.all["tp_sfzmmc"];
        o_sfzmhm=document.all["tp_sfzmhm"]; 
        o_gj=document.all["tp_gj"]; 
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
        o_csrq=document.all["li_csrq"];
        o_zjcx=document.all["li_zjcx"];
        o_yzjcx=document.all["li_yzjcx"];  
        o_lxdh=document.all["li_lxdh"];
        o_sjhm=document.all["li_sjhm"]; 
        o_sfzmmc=document.all["li_sfzmmc"];
        o_sfzmhm=document.all["li_sfzmhm"]; 
        o_gj=document.all["li_gj"];
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
        o_csrq=document.all["lo_csrq"];
        o_zjcx=document.all["lo_zjcx"];
        o_yzjcx=document.all["lo_yzjcx"];   
        o_lxdh=document.all["lo_lxdh"];
        o_sjhm=document.all["lo_sjhm"];   
        o_sfzmmc=document.all["lo_sfzmmc"];
        o_sfzmhm=document.all["lo_sfzmhm"];  
        o_gj=document.all["lo_gj"];
    }     

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
  	     
    //�ж�
    if(o_lxdh.value=="" && o_sjhm.value==""){
        alert("�̶��绰���ƶ��绰����ͬʱΪ�ա�");
        return false;    	
    }
    
	var ywyy=document.all["ywyy"].value;
	
	if (ywyy.indexOf("D")!=-1 )  //����
	{
  		o_zjcx.value=jstrim(o_zjcx.value);
  		o_zjcx.value=o_zjcx.value.toUpperCase();
  		if(o_zjcx.value.length==0)
  		{
       		o_zjcx.focus();
    		alert("���복�Ͳ���Ϊ�գ�");
    		return false;
 		}
  		/*
    	if (o_yzjcx.value==o_zjcx.value)
   		{
        	o_zjcx.focus();
     		alert("ԭ׼�ݳ��������복��һ�£����轵����");
			return false;
   		}
    	if (yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0 )
   		{
        	o_zjcx.focus();
     		alert("ԭ׼�ݳ��ͱ���������복�ͣ�");
			return false;
   		}   
  		var bigZjcx = getBigZjcx(o_zjcx.value);
   		if (jscx_nl(bigZjcx,o_csrq.value) == 0)
   		{
       		o_zjcx.focus();
       		//alert("��ǰ��ʻ�˵����䲻��������" + o_zjcx.value + "��");
       		return false;
   		}  */
	}

	//����ַ�Ƿ�������ȷ
  	if (o_ly.value=="A" ||o_ly.value=="B")
  	{
    	var ls_ret ;
  		try
  		{
  			ls_ret = check_dzxx(_prefix);
      		if (ls_ret != "1")
      		{
        		alert(ls_ret);
        		return false;
      		}
    	}
    	catch(err)
    	{
      		document.writeln("��������: " + err.name+" ---> ");
���� ��		document.writeln("������Ϣ: " + err.message+" ---> ");
    	}
    	finally
    	{

    	}
  	}
  	
	if (ywyy.indexOf("A")>=0 ||  ywyy.indexOf("C")>=0 || ywyy.indexOf("H")>=0 )  //���������䡢������
	{
		/*
  		//����ǳ��䣬�ж��³����Ƿ������ԭ�����ڲ�
  		if (ywyy.indexOf("C")>=0 && yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0)
  		{
    		if (o_yzjcx.value == o_zjcx.value)
    		{
      			alert("��׼�ݳ��Ͳ�����Ҫ��");
    		}
    		alert("��׼�ݳ��ͱ��������ԭ׼�ݳ����У�");
    		return false;
  		}
  		*/
  		//�������Ϸ����ж�
  		if(check_tjxx(o_zjcx.value)==0)
  		{
			return false;
    	}  		
  	}
	
	if(ywyy.indexOf("E")>=0 && o_sfzmmc.value=="A"){
		//�ж����֤������ͳ��������Ƿ�һ��
		var sCsrq = o_csrq.value.replace("-","");
		sCsrq = sCsrq.replace("-","");
		sCsrq = sCsrq.substr(0,8);
		var sSfzmhmRq;
		if(o_sfzmhm.value.length==18){
			sSfzmhmRq = o_sfzmhm.value.substr(6,8);
		}else{
			sSfzmhmRq = o_sfzmhm.value.substr(6,6);
			sCsrq = sCsrq.substr(2,6);
		}
		if(sCsrq!=sSfzmhmRq){
			alert("����������������֤���벻����");
			o_sfzmhm.focus();
			return false;
		}
	}	
	if(ywyy.indexOf("E")>=0){
		if((o_sfzmmc.value=="A" || o_sfzmmc.value=="C"
			|| o_sfzmmc.value=="D" || o_sfzmmc.value=="E") && o_gj.value!="156"){
			alert("���������֤��������");
			o_gj.focus();
			return false;
		}
	}
	
	/*
  	if (ywyy.indexOf("E")>=0)  //���
  	{
   		//����������ں��ж������Ƿ����Ҫ��
   		var vCsrq = "";
   		if(_prefix=="tp_"){
   			vCsrq = document.all["tp_csrq"].value;
   		}else{
   			vCsrq = document.all["li_ycsrq"].value;
   		}   		  		
  		if(vCsrq!=o_zjcx.value){
	  		var bigZjcx = getBigZjcx(o_zjcx.value);
	   		if (jscx_nl(bigZjcx,o_csrq.value) == 0)
	   		{
	       		//o_zjcx.focus();
	       		//alert("��ǰ��ʻ�˵����䲻��������" + o_zjcx.value + "��");
	       		return false;
	   		}  	
  		} 		
	}
	*/
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
        o_sfbd = "0";
    }  
    /*
  	if (ywyy.indexOf("E")>=0)  //���
  	{    
		if(!isLocal){
	        if(document.all["li_zzzm"].value=="")
	        {
	        	alert("��ǰ�����˵Ǽ�ס����ַ����ص�ַ����������ס֤�ţ�");
	        	document.all["li_zzzm"].focus();
	            return false;
	        }
		}else{
	        if(document.all["li_zzzm"].value!="")
	        {
	        	alert("��ǰ�����˵Ǽ�ס����ַ�Ǳ��صص�ַ������������ס֤�ţ�");
	        	document.all["li_zzzm"].focus();
	            return false;	        	
	        }
		}
  	}
  	*/
  	//������������
    var ls_xzqh = o_xzqh.value; //��������
    var ls_xz   = document.all["xiangzhen"].value;   //��
    if (ls_xz == "") ls_xz = "000";
    var ls_cun  = document.all["cun"].value;       //��
    if (ls_cun == "") ls_cun = "000";
    o_sqdm.value = ls_xzqh + ls_xz + ls_cun; //��������
    return true;
}
//������ģ����
function check_ndtj_record(_prefix)
{
    var o_zjcx;   
    if(_prefix=="ps_")
    {
       o_zjcx=document.all["ec_zjcx"];
    }
    else if(_prefix=="tp_")
    {
       o_zjcx=document.all["tp_zjcx"];
    }     
    else if(_prefix=="li_")
    {
       o_zjcx=document.all["li_zjcx"];
    }
    else if(_prefix=="lo_")
    {
       o_zjcx=document.all["lo_zjcx"];
    }   	
	//�������Ϸ����ж�
	if(check_tjxx(o_zjcx.value)==0)
	{
		return false;
	}
	return true;
}

//����Ƿ����������
function checkDy()
{
   if(document.formedit.newsfzmhm.value=="")
   {
      document.formedit.isRead.value="0";
   }
   var isRead=document.formedit.isRead.value;
   if(isRead=="0")//δ��ȡ����Ϣ���ɶ�
   {
       return true;
   }
   else
   {
      return false;
   }
}
//��ʾ������Ϣ
function setPrompt(prompt){
	  var pp = document.getElementById("tdReadResult");
	  pp.innerHTML = "<font color=\"#FF0000\">"+prompt+"</font>";
}

function parseCardInfo(sss){ 
  	//����ʱ��ȡ����
	document.formedit.isRead.value="1";
	document.all.autoEquSfzmInfo.value=sss;
	sfzxx = sss.split("|");
	ls_xm = sfzxx[1];
	ls_sfzmhm = sfzxx[6];//ȡ���֤��
	document.formedit.newsfzmhm.value = ls_sfzmhm;
	document.formedit.newxm.value = ls_xm;
	ls_xb = ls_sfzmhm.substring(16,17); //ȡ�Ա�
	if (Number(ls_xb)%2 == 1) ls_xb = "1";
	else ls_xb = "2";
	document.all["newxb"].value = ls_xb;
    document.all["newcsrq"].value = ls_sfzmhm.substring(6,14);
    var ls_tmp = new Array();
    ls_tmp = sss.split("|");
    document.all["newzsdz"].value = ls_tmp[5];
}

function alterSfzmhm(){
    if (jstrim(document.all["newxm"].value) == ''){
      alert("δ�����������֤��Ϣ��");
    }else if (jstrim(document.all["yxm"].value) == jstrim(document.all["newxm"].value)){
      document.all["li_sfzmhm"].value = document.all["newsfzmhm"].value;
      document.all["li_sfzmmc"].value="A";
      document.all["li_xm"].value = document.all["newxm"].value;
      document.all["li_xb"].value = document.all["newxb"].value;
	  //document.all["span_li_sfzmhm"].innerText=document.all["newsfzmhm"].value;
	  //document.all["span_li_sfzmmc"].innerText="�������֤";
	  
      var ls_csrq = document.all["newcsrq"].value;
      if(ls_csrq.length == 8)
      document.all["li_csrq"].value = ls_csrq.substring(0,4)+"-"+ls_csrq.substring(4,6)+"-"+ls_csrq.substring(6,8);
      document.all["li_djzsxxdz"].value = document.all["newzsdz"].value;
    }else
         alert("�������֤��������ԭ������һ�£�����ֱ�ӱ�����֤�ţ�");
  }






