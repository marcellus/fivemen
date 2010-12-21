//临时驾驶证受理：根据签证和居留有效期止计算临时驾驶证的有效期止
function setLsjszYxq(_prefix)
{
	var o_qzyxqx;//签证或居留许可有效期止
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
	//计算签证的有效时间	
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
   //年龄必须大于等于18周岁
   if(cal_years(o_csrq.value,"")<18)
   {
	   alert("申请人年龄必须满18周岁！");
	   o_csrq.focus();
	   return false;
   }
   //检测准驾车型包含关系
   if(check_sqcx(o_zjcx.value,"C")==0)
   {
	   //按来源为转入（C）的检测	   
	   alert("申请车型包含非法字符或者申请条件不满足的车型！");
	   o_zjcx.focus();
	   return false;	   
   }
   if(cal_days("",o_yxqs.value)<0 )
   {
         alert("'有效期始'不应早于今天！");
         o_yxqs.focus();
         return false;
   }
   if (cal_days(o_yxqs.value,o_yxqz.value)<0)
   {
	   alert("'有效期止'必须在'有效期始'之前！");
	   return false;
   }
   if (cal_days(o_yxqz.value,o_qzyxqx.value)<0)
   {
	   alert("'有效期止'必须在'签证有效期止'之前！");
	   return false;
   }      
   if (cal_days(DateAddMonth(o_yxqs.value,3),o_yxqz.value)>0)
   {
	   alert("临时证有效期最长不能超过3个月！");
	   return false;
   }

   return true;
}