function do_change_zxyy() {
var zxyy=document.all["zxyy"].value;
	if(zxyy=="G"){
	    document.all["xznx"].value="2";
		document.all["dx1"].checked=true;
	    dx.style.display="";
	}else{
	    dx.style.display="none";
	}
    if(zxyy=="G"||zxyy=="H"){
    	  if (document.all["sxrq"].value.length==0)
    	  {
    	     document.all["sxrq"].value=sysnowdate;
    	  }
    	  if(newisDate("��Ч����",document.all["sxrq"].value)==0 ){
    	     document.all["sxrq"].focus();
    	     return false;
    	  }else{
    		 str1=changeDate(document.all["sxrq"].value);
    	  }
    	  if(cal_days(document.all["sxrq"].value,"")<0 ){ 
    		alert("'��Ч����'��Ӧ���ڽ��죡");
    	    document.all["sxrq"].focus;
    	    return false;
    	   }
    	   if(zxyy=="H"){
    		   document.all["xznx"].value="3";
    	       document.all["sxrq"].value=str1;
    	   }
    	   
    	   document.all["xzqz"].value=rqaddyears(str1,parseInt(document.all["xznx"].value));
	       cEditable(document.all["cjwsbh"]);
	       cEditable(document.all["sxrq"]);
	       cEditable(document.all["cfjg"]);
	       
    }else{
    	 cReadonly(document.all["cjwsbh"]);
    	 cReadonly(document.all["sxrq"]);
    	 cReadonly(document.all["cfjg"]);
    	 document.all["cjwsbh"].value="";
    	 document.all["xznx"].value="";
    	 document.all["xzqz"].value="";
    	 document.all["sxrq"].value="";
    	 document.all["cfjg"].value="";
    }
}

function clickdx()
{
  if (document.all["dx1"].checked==true){
    document.all["xznx"].value="2"
  }else{
    document.all["xznx"].value="60"
  }
  if (document.all["sxrq"].value.length==0)
  {
   document.all["sxrq"].value=sysnowdate;
  }
  document.all["xzqz"].value=rqaddyears(document.all["sxrq"].value,parseInt(document.all["xznx"].value));
}

//--------------------�ı���Ч����ʱ��Ӧ�ı�-----------------------
function changesxrq() {

 var str1="";
    var zxyy=document.all["zxyy"].value;
    if (zxyy=="G" || zxyy=="H"){
    if (document.all["sxrq"].value.length==0)
    {
     document.all["sxrq"].value=sysnowdate;
    }

    if(newisDate("��Ч����",document.all["sxrq"].value)==0 ){
    	document.all["sxrq"].focus(); 
    	return false;
    }
    else{str1=changeDate(document.all["sxrq"].value);}
    if(cal_days(document.all["sxrq"].value,"")<0 )
   { alert("'��Ч����'��Ӧ���ڽ��죡");
     document.all["sxrq"].focus();
     return false;
   }

    if (zxyy=="G" || zxyy=="H"){
       document.all["xzqz"].value=rqaddyears(str1,parseInt(document.all["xznx"].value));
    }
    }
}

	//��ʻ֤ע��ҵ��ʱ��⺯��
	function check_jzzx()  //����ǰ����У��
	{
	         var zxyy=document.all["zxyy"].value;
	         if(zxyy==""){
	           alert("ע��ԭ��δѡ��");
	           return false;}
	
	if (zxyy=="G" ||zxyy=="H")
	{
	 //do_change();
	         if (zxyy=="G") {  document.all["xzyy"].value=="C";} //����ԭ��
	         if (zxyy=="H") {  document.all["xzyy"].value=="E";} //����ԭ��
	         if (checkNull(document.all["cjwsbh"],"�þ������")==0 )   {document.all["cjwsbh"].focus(); return false;  }
	         if (zxyy=="H")
	         {document.all["xznx"].value="3";
	         }
	          if(newisDate("������ֹ",document.all["xzqz"].value)==0 )
	           {
	            return false;
	            }
	           else
	          {document.all["xzqz"].value=changeDate(document.all["xzqz"].value);
	          }
	          if(cal_days(document.all["xzqz"].value,"")>0 )
	           { alert("'������ֹ'��Ӧ���ڽ��죡");
	             document.all["sxrq"].focus();
	            return false;}
	
	          if(newisDate("��Ч����",document.all["sxrq"].value)==0 )
	           {
	             document.all["sxrq"].focus();
	            return false;
	            }
	           else
	          {
	          document.all["sxrq"].value=changeDate(document.all["sxrq"].value);
	          }
	          if(cal_days(document.all["sxrq"].value,"")<0 )
	           { alert("'��Ч����'��Ӧ���ڽ��죡");
	             document.all["sxrq"].focus();
	            return false;
	            }
	         if (document.all.xzqz.value.substr(4,6)!=document.all.sxrq.value.substr(4,6))
	             {
	             alert("'��Ч����'��'������ֹ'���ղ�����");
	             document.all["sxrq"].focus();
	             return false;
	             }
	
	         if (document.all.xzqz.value.substr(0,4).valueOf()-document.all.sxrq.value.substr(0,4).valueOf() != document.all["xznx"].value.valueOf())
	             {
	             alert("'��������'��'��Ч����'��'������ֹ'���������");
	             document.all["sxrq"].focus();
	             return false;
	             }
	}
	if (checkNull(document.all["bz"],"��ע")==0){document.all["bz"].focus();return false;}
	   return true;
	}

	//��ʻ֤ע��ҵ��ʱ��⺯��
	function check_kz()
	{
	  if(checkNull(document.all["cjwsbh"],"�þ�����")==0 )
	  { document.all["cjwsbh"].focus() ;return false;}
	  if(newisDate("�ݿ�����",document.all["zkrq"].value)==0 ){
		  document.all["zkrq"].focus(); return false;}
	  else{
		  document.all["zkrq"].value=changeDate(document.all["zkrq"].value);
	  }
	  if(checkNull(document.all["zkqx"],"�ݿ�����")==0 )
	  { document.all["zkqx"].focus() ;return false;}
	  if(checknum(document.all["zkqx"],"�ݿ�����",true)!="1")
	  {return false;}
	  if(parseInt(document.all.zkqx.value)<=0){
		  alert("'�ݿ�����'Ӧ�ô���0 ��");
	      document.all["zkqx"].value = "";
	      document.all["zkqx"].focus();
	      return false;
	  }
	
	  if(parseInt(document.all.zkqx.value)>6){
		  alert("'�ݿ�����'��Ӧ����6���� ��");
	      document.all["zkqx"].value = "";
	      document.all["zkqx"].focus();
	      return false;
	  }
	  
	  if(checkNull(document.all["zkjbr"],"�ݿ۾�����")==0)
	  {document.all["zkjbr"].focus(); return false;}
	  if(cal_days(document.all["zkrq"].value,"")<0 )
	   {alert("'�ݿ�����'��Ӧ���ڽ��죡");
	    return false;}
	  if(DateAddMonth(document.all["zkrq"].value,document.all.zkqx.value)<=sysnowdate){
		  alert("'�ݿ�����'+����Ӧ���ڽ���֮��");
		  return false;
	  }
	 return true;
	}
	
	//��ʻ֤��֤ʱ���
	function check_hz(){
		if(document.all["hzrq"].value>sysnowdate){
			return confirm("�ݿ�����δ�����Ƿ�ȷ��Ҫ��֤��");
		}
		return true;
	}
	
	//��ʻ֤�������
	function check_sd()  //����ǰ����У��
	{
	  if(checkNull(document.all["sddw"],"������λ")==0 ){
	      document.all["sddw"].focus() ;
		  return false;  
	  }
	  if(checkNull(document.all["sdlx"],"��������")==0 )
	  {
	    document.all["sdlx"].focus() ;
	    return false;
	  }
	  if(checkNull(document.all["sdyy"],"����ԭ��")==0)
	  {
	    document.all["sdyy"].focus();
	    return false;
	  }
	  return true;
	}

	//��ʼ��Ҫ�жϵĵ�������
	function init_check_dagz(lxdhcd){
		var k=0;
		try{
			checkfields_dagz[k++] = new CheckObj("li_xm","����",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_xm","����",FRM_CHECK_CHINESE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_csrq","��������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_csrq","��������",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_syrq","�������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_syrq","�������",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_qfrq","�������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_qfrq","�������",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqs","��Ч��ʼ",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqs","��Ч��ʼ",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqz","��Ч��ֹ",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqz","��Ч��ֹ",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_cclzrq","������֤����",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_cclzrq","������֤����",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_djzsxzqh","�Ǽ�ס����������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_djzsxxdz","�Ǽ�ס����ϸ��ַ",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_djzsxxdz","�Ǽ�ס����ϸ��ַ",FRM_CHECK_MINLENGTH,10);
			
			checkfields_dagz[k++] = new CheckObj("li_lxzsxzqh","��ϵס����������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsxxdz","��ϵס����ϸ��ַ",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsxxdz","��ϵס����ϸ��ַ",FRM_CHECK_MINLENGTH,10);
			checkfields_dagz[k++] = new CheckObj("li_lxzsyzbm","��ϵס����������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsyzbm","��ϵס����������",FRM_CHECK_NUMBER,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsyzbm","��ϵס����������",FRM_CHECK_LENGTH,6);
			
			checkfields_dagz[k++] = new CheckObj("li_lxdh","�̶��绰",FRM_CHECK_LXDH,lxdhcd,1);
			checkfields_dagz[k++] = new CheckObj("li_sjhm","�ֻ�����",FRM_CHECK_SJHM,0,1);
			checkfields_dagz[k++] = new CheckObj("li_dzyx","��������",FRM_CHECK_EMAIL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_ljjf","�ۻ��Ƿ�",FRM_CHECK_NUMBER,0,1);
			
			checkfields_dagz[k++] = new CheckObj("ec_tjrq","�������",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("ec_tjrq","�������",FRM_CHECK_DATE,0,1);
			
			checklen_dagz = k;	
		}catch(e){
			
		}
	}

	//��ʼ��Ҫ�жϵĵ�������
	function init_check_dabj(lxdhcd){
		var k=0;
		try{
			checkfields_dabj[k++] = new CheckObj("li_dabhw","�������β",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_dabhw","�������β",FRM_CHECK_NUMBER,0,1);
			checkfields_dabj[k++] = new CheckObj("li_dabhw","�������β",FRM_CHECK_LENGTH,8,1);
			checkfields_dabj[k++] = new CheckObj("li_xm","����",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_xm","����",FRM_CHECK_CHINESE,0,1);
			checkfields_dabj[k++] = new CheckObj("li_csrq","��������",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_csrq","��������",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_djzsxzqh","�Ǽ�ס����������",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_djzsxxdz","�Ǽ�ס����ϸ��ַ",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_djzsxxdz","�Ǽ�ס����ϸ��ַ",FRM_CHECK_MINLENGTH,10);
			checkfields_dabj[k++] = new CheckObj("li_lxzsxzqh","��ϵס����������",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsxxdz","��ϵס����ϸ��ַ",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsxxdz","��ϵס����ϸ��ַ",FRM_CHECK_MINLENGTH,10);
			checkfields_dabj[k++] = new CheckObj("li_lxzsyzbm","��������",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsyzbm","��������",FRM_CHECK_NUMBER,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsyzbm","��������",FRM_CHECK_LENGTH,6);
			checkfields_dabj[k++] = new CheckObj("li_lxdh","�̶��绰",FRM_CHECK_LXDH,lxdhcd,1);
			checkfields_dabj[k++] = new CheckObj("li_sjhm","�ֻ�����",FRM_CHECK_SJHM,0,1);
			checkfields_dabj[k++] = new CheckObj("li_dzyx","��������",FRM_CHECK_EMAIL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_cclzrq","������֤����",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_cclzrq","������֤����",FRM_CHECK_DATE,0,1);
			checkfields_dabj[k++] = new CheckObj("li_yxqs","��Ч��ʼ",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_yxqs","��Ч��ʼ",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_yxqz","��Ч��ֹ",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_yxqz","��Ч��ֹ",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_syrq","�������",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_syrq","�������",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_qfrq","�������",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_qfrq","�������",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_ljjf","�ۻ��Ƿ�",FRM_CHECK_NUMBER,0,1);
			checklen_dabj = k;
		}catch(e){
			
		}
	}

	function check_dagz(){
		
		document.all.li_zjcx.value=document.all.li_zjcx.value.toUpperCase();
		if(checkallfields(checkfields_dagz,1,checklen_dagz)==0){
			return 0;
	    }
	  	
	    if(check_sqcx(document.all["li_zjcx"].value,"C")==0){
	      alert("׼�ݳ��Ͱ����Ƿ��ַ���");
	      return false;
	    }
	    
	    if(_checksfzmhmlogic_bxr(document.all["li_sfzmmc"],document.all["li_sfzmhm"],document.all["li_csrq"],document.all["li_xb"])==false){
	    	return false;
	    }
	    
	    if(document.all.li_ljjf.value==""){
			document.all.li_ljjf.value="0";
	    }
	    //�����Ч�ڲ�Ϊ���ڣ�������Ч��ֹΪ�գ��Զ�������Ӧ����Ч��ֹ
	    if(document.all.li_jzqx.value=="1" && document.all.li_yxqz.value==""){
			document.all.li_yxqz.value=(new Number(document.all.li_yxqs.value.substr(0,4))+6)+document.all.li_yxqs.value.substr(4,6);
		}
		if(document.all.li_jzqx.value=="2" && document.all.li_yxqz.value==""){
			document.all.li_yxqz.value=(new Number(document.all.li_yxqs.value.substr(0,4))+10)+document.all.li_yxqs.value.substr(4,6);
		}
		if (document.all.li_jzqx.value!="4"){
		//�����������Ч��ֹ��������ڵ����ձ�����ͬ
	    if (document.all.li_cclzrq.value.substr(4,6)=="-02-29"){
		if(document.all.li_syrq.value.substr(4,6)!="-02-29" && document.all.li_syrq.value.substr(4,6)!="-02-28")
		{
			alert("��һ������ڡ�������ڡ���Ч��ʼ����Ч��ֹ\n�ͳ������ڵ��º��ձ�����ͬ��");
			return 0;
		}
		if(document.all.li_yxqs.value.substr(4,6)!="-02-29" && document.all.li_yxqs.value.substr(4,6)!="-02-28")
		{
			alert("��һ������ڡ�������ڡ���Ч��ʼ����Ч��ֹ\n�ͳ������ڵ��º��ձ�����ͬ��");
			return 0;
		}
		if(document.all.li_yxqz.value.substr(4,6)!="-02-29" && document.all.li_yxqz.value.substr(4,6)!="-02-28")
		{
			alert("��һ������ڡ�������ڡ���Ч��ʼ����Ч��ֹ\n�ͳ������ڵ��º��ձ�����ͬ��");
			return 0;
		}
		if(document.all.li_qfrq.value.substr(4,6)!="-02-29" && document.all.li_qfrq.value.substr(4,6)!="-02-28")
		{
			alert("��һ������ڡ�������ڡ���Ч��ʼ����Ч��ֹ\n�ͳ������ڵ��º��ձ�����ͬ��");
			return 0;
		}
	    }else{
				if(document.all.li_syrq.value.substr(4,6)!=document.all.li_yxqs.value.substr(4,6) ||
					document.all.li_yxqs.value.substr(4,6)!=document.all.li_yxqz.value.substr(4,6) ||
					document.all.li_yxqs.value.substr(4,6)!=document.all.li_qfrq.value.substr(4,6) ||
			  		document.all.li_yxqz.value.substr(4,6)!=document.all.li_cclzrq.value.substr(4,6))
				{
					alert("��һ������ڡ�������ڡ���Ч��ʼ����Ч��ֹ\n�ͳ������ڵ��º��ձ�����ͬ��");
					return 0;
				}
	         }
	    }
		
		//������֤���ڱ������ڻ��ߵ�����Ч��ʼ
		if(cal_days(document.all.li_yxqs.value,document.all.li_cclzrq.value)>0){
			alert("������֤���ڱ������ڻ��ߵ�����Ч��ʼ��");
			return 0;
		}
		
		//��Ч��ʼ����Ч��ֹ��ʱ��������ͼ�ʻ�������
		if(document.all.li_jzqx.value=="1" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=6){
			alert("��Ч��ʼ����Ч��ֹ��ʱ�������ʻ���޲�����");
			return 0;
		}
		if(document.all.li_jzqx.value=="4" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=6){
			alert("��Ч��ʼ����Ч��ֹ��ʱ�������ʻ���޲�����");
			return 0;
		}
		if(document.all.li_jzqx.value=="5" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=6){
			alert("��Ч��ʼ����Ч��ֹ��ʱ�������ʻ���޲�����");
			return 0;
		}
		if(document.all.li_jzqx.value=="2" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=10){
			alert("��Ч��ʼ����Ч��ֹ��ʱ�������ʻ���޲�����");
			return 0;
		}
		if(document.all.li_jzqx.value=="3" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=60){
			alert("����֤��Ч��ʼ����Ч��ֹӦ���60�꣡");
			return 0;
		}
		
		if(document.all.li_qfrq.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()<1){
			alert("'�������'��Ӧ������Ч��ʼ��1�꣡");
			document.all["li_qfrq"].focus();
		    return 0;
		}
		
		if(document.all.li_qfrq.value.substr(0,4).valueOf()-sysnowdate.substr(0,4).valueOf()>1){
			alert("'�������'��Ӧ���ڵ�ǰ���ڼ�1�꣡");
			document.all["li_qfrq"].focus();
		    return 0;
		}
		
		if(cal_days(document.all["li_syrq"].value,"")>=0 ){
			alert("'��һ�������'��Ӧ���ڽ��죡");
			document.all["li_syrq"].focus();
		    return 0;
		}
	
		if(cal_days(document.all["li_yxqs"].value,"")<0){
			alert("��Ч��ʼ'��Ӧ���ڽ��죡");
			document.all["li_yxqs"].focus();
			return 0;
		}
		
		if(cal_days(document.all.li_yxqz.value,"")>0){
			alert("��Ч�����������ڵ�ǰ���ڣ�");
			document.all["li_yxqz"].focus();
			return 0;
		}
		
		if(cal_days(document.all["ec_tjrq"].value,"")<0 ){
			alert("'�������'��Ӧ���ڽ��죡");
			document.all["ec_tjrq"].focus();
		    return 0;
		}
		
		if (document.all["li_ly"].value=="B"){
		   //if(checknull(document.all["li_zzzm"],"����ס֤��",1)!="1" ) { return 0;}
		   if(checknull(document.all["li_lxzsxxdz"],"��ϵס��",1)!="1") { return 0;}
		}else{
			//if((document.all["li_zzzm"].value!="")&&(document.all["li_ly"].value!="C") ){
		      //  alert("���ؼ�ʻԱ����Ҫ������ס֤�ţ�");
		      // document.all.zzzm.focus();
		      //  return 0;
		    // }
		}
		if (document.all["li_sfzmmc"].value=="A"&&document.all["li_gj"].value!="156"){
			alert("��������Ϊ�й���");
			return 0;
		}
		if (document.all["li_sfzmmc"].value=="C"&&document.all["li_gj"].value!="156"){
			alert("��������Ϊ�й���");
			return 0;
		}
		if (document.all["li_sfzmmc"].value=="D"&&document.all["li_gj"].value!="156"){
			alert("��������Ϊ�й���");
			return 0;
		}
		if (document.all["li_sfzmmc"].value=="E"&&document.all["li_gj"].value!="156"){
			alert("��������Ϊ�й���");
			return 0;
		}
		if (document.all["li_jzqx"].value=="2"&&document.all["li_yxqz"].value<"2018-05-01"){
			alert("��ʻ֤���޲���Ϊʮ�꣡");
			return 0;
		}
		if (document.all["li_jzqx"].value=="3"&&document.all["li_yxqz"].value<"2018-05-01"){
			alert("��ʻ֤���޲���Ϊ���ڣ�");
			return 0;
		}
		
		//֤о��ż��
	    var bh = document.all.li_zxbh.value;
	    if (document.all.li_zxbh.type=="text"){
		    if(bh!=""){
		    	if(zxbhCheck(bh, document.all.li_zxbh)!="1"){
		    		return 0;
		    	}
		    }
	    }
	}

	function getYdxzData(){
		if (iddagzxx.XMLDocument.documentElement.childNodes.length==0){
			alert("δ���ص��ü�ʻԱ��Ϣ��");
		    return;
		}
		for (var i=0;i<iddagzxx.XMLDocument.documentElement.childNodes.length;i++){
		    if(iddagzxx.XMLDocument.documentElement.childNodes(i).nodeName=="err"){
		    	alert(iddagzxx.XMLDocument.documentElement.childNodes(i).text);
		        return;
		    }else{
		      var tnodename=iddagzxx.XMLDocument.documentElement.childNodes(i).nodeName;
		      if(tnodename=="sfzmhm"){
		    	  var sfzmhm=iddagzxx.XMLDocument.documentElement.childNodes(i).text;
		    	  if ("CDEFG".indexOf(sfzmhm.substring(0,1))>-1){
		    		  document.all["li_sfzmmc"].value=sfzmhm.substr(0,1);
		    		  document.all["li_sfzmhm"].value=sfzmhm.substr(1);
		    		  document.all["span_li_sfzmhm"].innerText=sfzmhm.substr(1);
		    		  document.all["span_li_sfzmmc"].innerText=transzjmc(sfzmhm.substr(0,1));
		    	  }else{
		    		  document.all["li_sfzmmc"].value="A";
		    		  document.all["li_sfzmhm"].value=sfzmhm;
		    		  document.all["span_li_sfzmhm"].innerText=sfzmhm;
		    		  document.all["span_li_sfzmmc"].innerText="�������֤";
		    	  }
		      }else{
		    	  try{
		    		 if(tnodename=="zjcx"){
		    			 document.all["span_li_"+tnodename].innerText=iddagzxx.XMLDocument.documentElement.childNodes(i).text;
		    		 }
		    		 document.all["li_"+tnodename].value=iddagzxx.XMLDocument.documentElement.childNodes(i).text;
			    	 document.all["span_li_"+tnodename].innerText=iddagzxx.XMLDocument.documentElement.childNodes(i).text;
		  		}catch(e){
		  		}
		      }
		    }
		}
	}

	function transzjmc(zjmc){
	var tmpzjmc="";
	tmpzjmc=zjmc;
		if(zjmc=="A"){
			tmpzjmc="�������֤";
		}
		if(zjmc=="C"){
			tmpzjmc="����֤";
		}
		if(zjmc=="D"){
			tmpzjmc="ʿ��֤";
		}
		if(zjmc=="E"){
			tmpzjmc="����������֤";
		}
		if(zjmc=="F"){
			tmpzjmc="������Ա���֤��";
		}
		if(zjmc=="G"){
			tmpzjmc="�⽻��Ա���֤��";
		}
		return tmpzjmc;
	}


function sjxzclick(vgnid){
	if(vgnid=="0310"){	//���ص���������Ϣ
		var ndabh;
		ndabh=document.all["li_dabh"].value;
		var oXmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		oXmlHttp.Open("POST", "dagl.do?method=getDagzXmlInfo&dabh="+ndabh, false);
		oXmlHttp.setRequestHeader("Content-Type","text/xml;charset=GB2312") ;
		oXmlHttp.Send();
		if(oXmlHttp.status!="200")
		{alert("û�з�����ȷ���������͡�");
		return "";
		}
		iddagzxx.loadXML(oXmlHttp.responseXML.xml);
		iddagzxx.async=false;		
		//alert(oXmlHttp.responseXML.xml);

		var bsfjz=true;
		try{
			var msg_node=iddagzxx.getElementsByTagName("rtnmsg");
			var msg=msg_node.item(0).text;
			if(msg!=""){
				alert(msg);
				bsfjz=false;
			}
		}catch(e){
		}
		if(bsfjz==true){
			
			getYdxzData();
		}
	}
	
	if(vgnid=="0313"){  //���ص�����¼��Ϣ
		var nsfzmmc,nsfzmhm;
		nsfzmmc=document.all["li_sfzmmc"].value;
		nsfzmhm=document.all["li_sfzmhm"].value;
		if(nsfzmmc!="A"){
			nsfzmhm=nsfzmmc+nsfzmhm;
		}
		document.formedit.action="dagl.do?method=getDabjXmlInfo&sfzmhm="+nsfzmhm;
        document.formedit.submit();
	}

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
	  document.all["span_li_sfzmhm"].innerText=document.all["newsfzmhm"].value;
	  document.all["span_li_sfzmmc"].innerText="�������֤";
	  
      var ls_csrq = document.all["newcsrq"].value;
      if(ls_csrq.length == 8)
      document.all["li_csrq"].value = ls_csrq.substring(0,4)+"-"+ls_csrq.substring(4,6)+"-"+ls_csrq.substring(6,8);
      document.all["li_djzsxxdz"].value = document.all["newzsdz"].value;
    }else
         alert("�������֤��������ԭ������һ�£�����ֱ�ӱ�����֤�ţ�");
  }

//�����������
function check_dabj(){
	
	if(document.all["dabjdown"].value==0){
		alert("δ���ܶ���ȷ���ص�������Ϣ�����������ҵ��");
		return 0;
	}
	
	if(document.all.li_ljjf.value.length==0){
		document.all.li_ljjf.value="0";
	}
	document.all.li_zjcx.value=document.all.li_zjcx.value.toUpperCase();
	document.all.li_dabh.value=document.all.li_dabht.value+document.all.li_dabhw.value;
	if(document.all.li_dabh.value.length!=12){
		alert("������ų��Ȳ�����");
		return 0;
	}
	if(checkallfields(checkfields_dabj,1,checklen_dabj)==0){
		return 0;
    }
    var djzsxxdz = document.all.li_djzsxxdz.value;
    var bddzxx = document.all.bddzxx.value;
	var isLocal = checkIsLocal(bddzxx,djzsxxdz);
	if(!isLocal && document.all.li_djzsxzqh.options(document.all.li_djzsxzqh.selectedIndex).text!="���"){
		alert("��ǰ�����˵Ǽ�ס����ַ����ص�ַ����ѡ��ĵǼ�ס�����������Ǳ�������������");
        return false;
    }
    if (isLocal){
    	if(document.all["li_zzzm"].value.length!=0){
    		alert("���ؼ�ʻ����ס֤���ű���Ϊ�գ�");
    		return 0;
    	}
        document.all.li_sfbd.value ="1";
        document.all.li_ly.value = "A";
    }else{
        document.all.li_sfbd.value ="0";
        document.all.li_ly.value ="B";
    }
    
    if(check_sqcx(document.all["li_zjcx"].value,"C")==0){
      alert("׼�ݳ��Ͱ����Ƿ��ַ���");
      return false;
    }
}

//ũ����¼���
function check_njbl(){
	
	if(document.all.li_ljjf.value.length==0){
		document.all.li_ljjf.value="0";
	}
		
	if(checkallfields(checkfields_dabj,1,checklen_dabj)==0){
		return 0;
    }
	
	document.all.li_zjcx.value=document.all.li_zjcx.value.toUpperCase();
	document.all.li_dabh.value=document.all.li_dabht.value+document.all.li_dabhw.value;

    var djzsxxdz = document.all.li_djzsxxdz.value;
    var bddzxx = document.all.bddzxx.value;
	var isLocal = checkIsLocal(bddzxx,djzsxxdz);
	if(!isLocal && document.all.li_djzsxzqh.options(document.all.li_djzsxzqh.selectedIndex).text!="���"){
		alert("��ǰ�����˵Ǽ�ס����ַ����ص�ַ����ѡ��ĵǼ�ס�����������Ǳ�������������");
        return false;
    }
    if (isLocal){
    	if(document.all["li_zzzm"].value.length!=0){
    		alert("���ؼ�ʻ����ס֤���ű���Ϊ�գ�");
    		return 0;
    	}
        document.all.li_sfbd.value ="1";
        document.all.li_ly.value = "A";
    }else{
        document.all.li_sfbd.value ="0";
        document.all.li_ly.value ="B";
    }
    
    if(check_sqcx(document.all["li_zjcx"].value,"C")==0){
      alert("׼�ݳ��Ͱ����Ƿ��ַ���");
      return false;
    }
}

//������Ч��ֹ
function setyxqz(){
	var syrq;
	var months;
	  if(newisDate("��Ч��ʼ",document.all["li_yxqs"].value)==0){
	    return false;
	  }
	  else{
	    document.all["li_yxqs"].value=changeDate(document.all["li_yxqs"].value);
	  }
	  if (document.all["li_jzqx"].value=="1"){
	    months=12*6;
	  }else if(document.all["li_jzqx"].value=="5")
	  {
	     months=12*6;
	  }
	  else if(document.all["li_jzqx"].value=="2")
	  {
	     months=12*10;
	  }
	  else
	  {
	     months=12*60;
	  }
	document.all["li_yxqz"].value=DateAddMonth(document.all["li_yxqs"].value,months);
	//alert(document.all["li_yxqs"].value.substring(4,10))
	syrq=b[0]+ document.all["li_yxqs"].value.substring(4,10);
	if (cal_days(syrq,"")<0)
	{
	}else
	{
	  syrq=(parseInt(b[0])+1)+ document.all["li_yxqs"].value.substr(4,10);
	}
	  document.all["li_syrq"].value=syrq;
	  document.all["span_li_syrq"].innerText=syrq;
	  document.all["li_qfrq"].value=document.all["li_syrq"].value;
	  document.all["span_li_qfrq"].innerText=document.all["li_syrq"].value;
}

function _checksfzmhmlogic(sfzmmcobj,sfzmhmobj,csrqobj,xbobj){
	var ret="";
	var result=true;
	if(sfzmmcobj.value=='A'){
		var csrq=getcsrqbysfzmhm(sfzmhmobj.value);
		var xb=getxbbysfzmhm(sfzmhmobj.value);
		if(csrqobj.value!=csrq){
			ret="���֤��������������ڲ���Ӧ��";
			result=false;
		}	
		if(xbobj.value!=xb){
			ret=ret+"���֤���������Ա𲻶�Ӧ��";
			result=false;
		}
	}
	if(result==false){
		alert(ret);
	}
	return result;
}

//�Ա�ǿ�Ƽ�⣬����ʾ���ݳɶ�Ҫ���Ǳ����˵�����
function _checksfzmhmlogic_bxr(sfzmmcobj,sfzmhmobj,csrqobj,xbobj){
	var ret="";
	var result=true;
	if(sfzmmcobj.value=='A'){
		var csrq=getcsrqbysfzmhm(sfzmhmobj.value);
		var xb=getxbbysfzmhm(sfzmhmobj.value);
		if(csrqobj.value!=csrq){
			alert("���֤��������������ڲ���Ӧ��");
			result=false;
		}	
		if(xbobj.value!=xb){
			result=confirm("���֤���������Ա𲻶�Ӧ���Ƿ�ȷ���޸ģ�");
		}
	}
	return result;
}

function changedaglyxqz(){
	if(checkdate(document.all["li_yxqs"],"��Ч��ʼ",1)!="1"){
		return;
	}
	
	if(checkdate(document.all["li_yxqz"],"��Ч����",1)!="1"){
		return;
	}
	
	if(checkdate(document.all["li_syrq"],"��һ�������",1)!="1"){
		return;
	}
	
	if(checkdate(document.all["li_qfrq"],"�������",1)!="1"){
		return;
	}
		
	document.all.li_yxqz.value=document.all.li_yxqz.value.substr(0,4)+document.all.li_yxqs.value.substr(4,6);
	document.all.li_syrq.value=document.all.li_syrq.value.substr(0,4)+document.all.li_yxqs.value.substr(4,6);
	document.all.li_qfrq.value=document.all.li_qfrq.value.substr(0,4)+document.all.li_yxqs.value.substr(4,6);
}