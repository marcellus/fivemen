//��ʱ��ʻ֤��������ǩ֤�;�����Ч��ֹ������ʱ��ʻ֤����Ч��ֹ
function setLsjszYxq(_prefix)
{
	var o_qzyxqx;//ǩ֤����������Ч��ֹ
	var o_yxqs;
	var o_yxqz;
    if(_prefix=="tp_")
    {
        o_qzyxqx=document.all["tp_qzyxqx"];
        o_yxqs=document.all["tp_yxqs"];
        o_yxqz=document.all["tp_yxqz"];
    }     
    else if(_prefix=="li_")
    {
        o_qzyxqx=document.all["li_qzyxqx"];
        o_yxqs=document.all["li_yxqs"];
        o_yxqz=document.all["li_yxqz"];    
    }
    else if(_prefix=="lo_")
    {
        o_qzyxqx=document.all["lo_qzyxqx"];
        o_yxqs=document.all["lo_yxqs"];
        o_yxqz=document.all["lo_yxqz"];
   } 
   else if(_prefix=="lt_")
   {
        o_qzyxqx=document.all["lt_qzyxqx"];
        o_yxqs=document.all["lt_yxqs"];
        o_yxqz=document.all["lt_yxqz"]; 
   } 	
	//����ǩ֤����Чʱ��	
	var yxq=cal_days("",o_qzyxqx.value);
	if(yxq>90)
	{
		o_yxqz.value=DateAddMonth(o_yxqs.value,3);
	}
	else
	{
		o_yxqz.value=o_qzyxqx.value;
	}
}

function check_lsjsz_record(_prefix)
{
	var o_csrq;
	var o_qzyxqx;
	var o_yxqs;
	var o_yxqz;
	var o_zjcx;
    if(_prefix=="tp_")
    {
        o_csrq=document.all["tp_csrq"];
        o_qzyxqx=document.all["tp_qzyxqx"];
        o_yxqs=document.all["tp_yxqs"];
        o_yxqz=document.all["tp_yxqz"];
        o_zjcx=document.all["tp_zjcx"]; 
    }     
    else if(_prefix=="li_")
    {
        o_csrq=document.all["li_csrq"];
        o_qzyxqx=document.all["li_qzyxqx"];
        o_yxqs=document.all["li_yxqs"];
        o_yxqz=document.all["li_yxqz"];    
        o_zjcx=document.all["li_zjcx"]; 
    }
    else if(_prefix=="lo_")
    {
        o_csrq=document.all["lo_csrq"];
        o_qzyxqx=document.all["lo_qzyxqx"];
        o_yxqs=document.all["lo_yxqs"];
        o_yxqz=document.all["lo_yxqz"];
        o_zjcx=document.all["lo_zjcx"]; 
   } 
   else if(_prefix=="lt_")
   {
        o_csrq=document.all["lt_csrq"];
        o_qzyxqx=document.all["lt_qzyxqx"];
        o_yxqs=document.all["lt_yxqs"];
        o_yxqz=document.all["lt_yxqz"]; 
        o_zjcx=document.all["lt_zjcx"]; 
   }    
   //���������ڵ���18����
   if(cal_years(o_csrq.value,"")<18)
   {
	   alert("���������������18���꣡");
	   o_csrq.focus();
	   return false;
   }
   //���׼�ݳ��Ͱ�����ϵ
   if(check_sqcx(o_zjcx.value,"C")==0)
   {
	   //����ԴΪת�루C���ļ��	   
	   alert("���복�Ͱ����Ƿ��ַ�������������������ĳ��ͣ�");
	   o_zjcx.focus();
	   return false;	   
   }
   if(cal_days("",o_yxqs.value)<0 )
   {
         alert("'��Ч��ʼ'��Ӧ���ڽ��죡");
         o_yxqs.focus();
         return false;
   }
   if (cal_days(o_yxqs.value,o_yxqz.value)<0)
   {
	   alert("'��Ч��ֹ'������'��Ч��ʼ'֮ǰ��");
	   return false;
   }
   if (cal_days(o_yxqz.value,o_qzyxqx.value)<0)
   {
	   alert("'��Ч��ֹ'������'ǩ֤��Ч��ֹ'֮ǰ��");
	   return false;
   }      
   if (cal_days(DateAddMonth(o_yxqs.value,3),o_yxqz.value)>0)
   {
	   alert("��ʱ֤��Ч������ܳ���3���£�");
	   return false;
   }

   return true;
}