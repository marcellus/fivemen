function check_zjsq_record(_prefix)  //���ݱ���ǰ����У��
{
    var o_ly;
    var o_djzsxzqh;
    var o_djzsxxdz;
    var o_sfbd;
    var o_xzqh;
    var o_sqdm;
    var o_sqcx;
    var o_lxdh;
    var o_sjhm;
    var o_zkcx;
    var o_yzjcx;
    if(_prefix=="ps_")
    {
       o_ly=document.all["ec_ly"];
       o_djzsxzqh=document.all["ps_djzsxzqh"];
       o_djzsxxdz=document.all["ps_djzsxxdz"];
       o_xzqh=document.all["ec_xzqh"];
       o_sqdm=document.all["ec_sqdm"];
       o_sfbd=document.all["ps_sfbd"];
       o_sqcx=document.all["ec_zkcx"];
       o_lxdh=document.all["ps_lxdh"];
       o_sjhm=document.all["ps_sjhm"];
       o_zkcx=document.all["ec_zkcx"];
       o_yzjcx=document.all["ec_yzjcx"];
    }
    else if(_prefix=="tp_")
    {
       o_ly=document.all["tp_ly"];
       o_djzsxzqh=document.all["tp_djzsxzqh"];
       o_djzsxxdz=document.all["tp_djzsxxdz"];
       o_xzqh=document.all["tp_xzqh"];
       o_sqdm=document.all["tp_sqdm"];
       o_sfbd=document.all["tp_sfbd"];
       o_sqcx=document.all["tp_zkcx"];
       o_lxdh=document.all["tp_lxdh"];
       o_sjhm=document.all["tp_sjhm"]; 
       o_zkcx=document.all["tp_zkcx"];
       o_yzjcx=document.all["tp_yzjcx"];       
    }     
    else if(_prefix=="li_")
    {
       o_ly=document.all["li_ly"];
       o_djzsxzqh=document.all["li_djzsxzqh"];
       o_djzsxxdz=document.all["li_djzsxxdz"];
       o_xzqh=document.all["li_xzqh"];
       o_sqdm=document.all["li_sqdm"];
       o_sfbd=document.all["li_sfbd"];
       o_sqcx=document.all["li_zkcx"];
       o_lxdh=document.all["li_lxdh"];
       o_sjhm=document.all["li_sjhm"];
       o_zkcx=document.all["li_zkcx"];
       o_yzjcx=document.all["li_yzjcx"];       
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
       o_lxdh=document.all["lo_lxdh"];
       o_sjhm=document.all["lo_sjhm"];  
       o_zkcx=document.all["lo_zkcx"];
       o_yzjcx=document.all["lo_yzjcx"];       
    }     
    var o_gnid=document.all["gnid"];
 	var gnid="";
 	if(o_gnid!=undefined)
 	{
 	   gnid=o_gnid.value;
 	}
 	 
 	if (yzjcx_sqcx(o_yzjcx.value,o_zkcx.value)==1 )
 	{
 	    alert("ԭ׼�ݳ����Ѱ������복�ͣ�");
 	    o_zkcx.focus();
 		return false;
 	}

 	//add by zou 20080724 �ж��Ƿ��Ǳ��ص�ַ
 	var djzsxxdz = o_djzsxxdz.value;
 	var bddzxx = document.all.bddzxx.value;
 	var isLocal = checkIsLocal(bddzxx,djzsxxdz);
 	
 	if (isLocal)
 	{
 		o_sfbd.value = "1";
 	}
 	else
 	{
 		o_sfbd.value = "0";
 	}
 	if (o_ly.value=="B")
 	{
        if(!check_zzzm(_prefix))
        {
            return false;
        }
 	}
 	//�������Ϸ����ж�
  	if(check_tjxx(o_sqcx.value)==0)
  	{
		return false;
    }
 	 //�ж���ϵ��ַ��Ϣ�Ƿ������ʡ������
  	if (o_ly.value=="A" ||o_ly.value=="B")
  	{
    	var ls_ret ;

  		ls_ret = check_dzxx(_prefix);
      	if (ls_ret != "1")
      	{
        	alert(ls_ret);
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
    //�ж�
    if(o_lxdh.value=="" && o_sjhm.value==""){
        alert("�̶��绰���ƶ��绰����ͬʱΪ�ա�");
        return false;    	
    }
    return true;   

 	 
 	 
}
