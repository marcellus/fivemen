//add by zou �жϼ��������Ƿ�һ�µĺ��� 2006-03-01
function strequal(rq1, rq2)
{
  if (rq1 == rq2) return true; //������ͬ
  if (rq1 == "02-28" || rq1 == "02-29")  //���߲�ͬ�������Ƿ���2��28�յ����
  {
    if ((rq1 == "02-28" && rq2 == "02-29" ) || (rq1 == "02-29" && rq2 == "02-28"))
    {
      return true;
    }
    if ((rq1 == "02-28" && rq2 == "03-01") || (rq1 == "03-01" && rq2 == "02-28"))
    {
      return true;
    }
    if ((rq1 == "02-29" && rq2 == "03-01") || (rq1 == "03-01" && rq2 == "02-29"))
    {
      return true;
    }
    return false;
  }else{
    return false;
  }
}
function check_zr_record(_prefix)  //����ǰ����У��
{
     var o_ly;
     var o_zt;
     var o_xzqh;
     var o_ydabh;
     var o_dabh;
     var o_yzjcx;
     var o_zjcx;
     var o_cclzrq;
     var o_yxqs;
     var o_yxqz;
     var o_csrq;
     var o_ljjf;
     var o_djzsxzqh;
     var o_lxzsxzqh;
     var o_djzsxxdz;
     var o_lxzsxxdz;    
     var o_sqdm;
     
     if(_prefix=="ps_")
     {
        o_ly=document.all["ec_ly"];
        o_zt=document.all["ec_zt"];
        o_xzqh=document.all["ec_xzqh"];
        o_ydabh=document.all["ec_ydabh"];
        o_dabh=document.all["ec_dabh"];
        o_zjcx=document.all["ec_zjcx"];
        o_yzjcx=document.all["ec_yzjcx"];
        o_yxqs=document.all["ec_yxqs"];
        o_yxqz=document.all["ec_yxqz"];
        o_csrq=document.all["ps_csrq"];
        o_cclzrq=document.all["ec_cclzrq"];
        o_ljjf=document.all["ec_ljjf"];
        
        o_lxzsxzqh=document.all["ps_lxzsxzqh"];
        o_lxzsxxdz=document.all["ps_lxzsxxdz"];
        o_djzsxzqh=document.all["ps_djzsxzqh"];
        o_djzsxxdz=document.all["ps_djzsxxdz"];    
        o_sqdm=document.all["ps_sqdm"]; 
     }
     else if(_prefix=="tp_")
     {
        o_ly=document.all["tp_ly"];
        o_zt=document.all["tp_zt"];
        o_xzqh=document.all["tp_xzqh"];
        o_ydabh=document.all["tp_ydabh"];
        o_dabh=document.all["tp_dabh"];
        o_zjcx=document.all["tp_zjcx"];
        o_yzjcx=document.all["tp_yzjcx"];
        o_yxqs=document.all["tp_yxqs"];
        o_yxqz=document.all["tp_yxqz"];   
        o_csrq=document.all["tp_csrq"];
        o_cclzrq=document.all["tp_cclzrq"];  
        o_ljjf=document.all["tp_ljjf"]; 
        
        o_lxzsxzqh=document.all["tp_lxzsxzqh"];
        o_lxzsxxdz=document.all["tp_lxzsxxdz"];        
        o_djzsxzqh=document.all["tp_djzsxzqh"];
        o_djzsxxdz=document.all["tp_djzsxxdz"];   
        o_sqdm=document.all["tp_sqdm"]; 
     }     
     else if(_prefix=="li_")
     {
        o_ly=document.all["li_ly"];
        o_zt=document.all["li_zt"];
        o_xzqh=document.all["li_xzqh"];
        o_ydabh=document.all["li_ydabh"];
        o_dabh=document.all["li_dabh"];
        o_zjcx=document.all["li_zjcx"];
        o_yzjcx=document.all["li_yzjcx"];
        o_yxqs=document.all["li_yxqs"];
        o_yxqz=document.all["li_yxqz"]; 
        o_csrq=document.all["li_csrq"];   
        o_cclzrq=document.all["li_cclzrq"];
        o_ljjf=document.all["li_ljjf"];  
        
        o_lxzsxzqh=document.all["li_lxzsxzqh"];
        o_lxzsxxdz=document.all["li_lxzsxxdz"];        
        o_djzsxzqh=document.all["li_djzsxzqh"];
        o_djzsxxdz=document.all["li_djzsxxdz"];   
        o_sqdm=document.all["li_sqdm"]; 
     }
     else if(_prefix=="lo_")
     {
        o_ly=document.all["lo_ly"];
        o_zt=document.all["lo_zt"];
        o_xzqh=document.all["lo_xzqh"];
        o_ydabh=document.all["lo_ydabh"];
        o_dabh=document.all["lo_dabh"];
        o_zjcx=document.all["lo_zjcx"];
        o_yzjcx=document.all["lo_yzjcx"];
        o_yxqs=document.all["lo_yxqs"];
        o_yxqz=document.all["lo_yxqz"]; 
        o_csrq=document.all["lo_csrq"]; 
        o_cclzrq=document.all["lo_cclzrq"];   
        o_ljjf=document.all["lo_ljjf"];  
        
        o_lxzsxzqh=document.all["lo_lxzsxzqh"];
        o_lxzsxxdz=document.all["lo_lxzsxxdz"];        
        o_djzsxzqh=document.all["lo_djzsxzqh"];
        o_djzsxxdz=document.all["lo_djzsxxdz"];   
        o_sqdm=document.all["lo_sqdm"]; 
     }    
      	o_ly.value="C"
      	trimall();	//ȥ������Text�����˿ո�
      	/*
		if (o_zt.value!="A")
		{
			alert("��ʻԱ״̬������������ת�롣");
			return false;
		}
        if(cal_days(o_yxqz.value,"")>0)
        {
            alert("�ü�ʻ֤�Ѿ����ڣ�����ת�롣")
            return false;
        }
		*/
        /*
      	//׼�ݳ��Ͳ���Ϊ��,�ұ�������߼�
      	if(check_sqcx(o_zjcx.value,"C")==0)
      	{
        	alert("׼�ݳ��Ͱ����Ƿ��ַ���");
        	return false;
      	}
        if (yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0 )
        {
          		o_zjcx.focus();
          		alert("ԭ׼�ݳ��ͱ���������복�ͣ�");
          		return false;
        }
      	if(cal_days(o_yxqs.value,"")<0)
      	{
        	o_yxqs.focus();
        	alert("��Ч��ʼ�����ڽ�����ǰ")
        	return false;
      	}
      	if(cal_days(o_yxqz.value,"")>0)
      	{
        	o_yxqs.focus();
        	alert("��Ч��ֹΪ"+o_yxqz.value+",����ת�룡")
       	 	return false;
      	}
      	if(cal_days(o_cclzrq.value,o_yxqs.value)<0)
      	{
        	o_cclzrq.focus();
        	alert("������֤���ڱ�������Ч��ʼǰ")
        	return false;
      	}
      	//
      	if (!strequal(o_cclzrq.value.substr(5,10),o_yxqs.value.substr(5,10)))
      	{
        	o_yxqs.focus();
        	alert("��Ч��ʼ�ͳ������ڵ��º��ձ�����ͬ��");
        	return false;
      	}
      	
      	//�ۻ��������Ϊ�գ��Զ�����0�����ֲ��ܴ���12��
      	if(o_ljjf.value=="")
      	{
      		o_ljjf.value="0";
      	}
      	else
      	{
        	if(isNum("�ۻ��Ƿ�",o_ljjf.value)==0)
        	{
          		o_ljjf.focus();
          		return false;
        	}
        	if(parseInt(o_ljjf.value)>11)
        	{
          		o_ljjf.focus();
          		alert("�ۻ��Ƿֳ���11�֣�\n���Ƚ��д����ٰ���ת�롣");
          		return false;
        	}
      	}
      	o_ljjf.value=parseInt(o_ljjf.value);
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

  		if (o_dabh.value=="#")
        {
        }
        else
        {
        	var o_bh2=document.all["dabh2"];       
        	if(o_bh2!=undefined){
	        	if(isLength("�������","8",o_bh2)==0 )   
	            {
	                return false;
	            }
	            if(isNum("�������",o_bh2.value)==0 )   
	            {
	                return false;
	            }
        	
        	} 	
        }
  		/*
        nl=cal_years(o_csrq.value);//������
        if (nl<18)
        {
            alert("������볬��18��")
            return false
        }
        else if (nl>=60)
        {
            if (o_zjcx.value.indexOf("A")>-1)
            {
                alert("��ǰ���䳬��60�꣬����ת��A1A2A3����");
                return false;
            }
            if (o_zjcx.value.indexOf("B")>-1)
            {
                alert("��ǰ���䳬��60�꣬����ת��B1B2����");
                return false;
            }
            if (o_zjcx.value.indexOf("N")>-1)
            {
                alert("��ǰ���䳬��60�꣬����ת��N����");
                return false;
            }
            if (o_zjcx.value.indexOf("P")>-1)
            {
                alert("��ǰ���䳬��60�꣬����ת��P����");
                return false;
            }
         }
         else if (nl>=70)
         {
            if (o_zjcx.value.indexOf("C3")>-1)
            {
               alert("��ǰ���䳬��70�꣬����ת��C3����");
               return false;
            }
            if (o_zjcx.value.indexOf("C4")>-1)
            {
                alert("��ǰ���䳬��70�꣬����ת��C4����");
                return false;
            }
            if (o_zjcx.value.indexOf("D")>-1)
            {
                alert("��ǰ���䳬��70�꣬����ת��D����");
                return false;
            }
            if (o_zjcx.value.indexOf("E")>-1)
            {
                alert("��ǰ���䳬��70�꣬����ת��E����");
                return false;
            }
            if (o_zjcx.value.indexOf("M")>-1)
            {
                alert("��ǰ���䳬��70�꣬����ת��M����");
                return false;
            }
         }
         */
 
    //�������Ϸ����ж�
    if(document.all["ec_sftj"]!=undefined&&document.all["ec_sftj"].value=="1"){
	    if(check_tjxx(o_zjcx.value)==0)
	    {
	    		return false;
	    }
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
    return true;
}
