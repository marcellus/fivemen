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
    	  if(newisDate("生效日期",document.all["sxrq"].value)==0 ){
    	     document.all["sxrq"].focus();
    	     return false;
    	  }else{
    		 str1=changeDate(document.all["sxrq"].value);
    	  }
    	  if(cal_days(document.all["sxrq"].value,"")<0 ){ 
    		alert("'生效日期'不应晚于今天！");
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

//--------------------改变生效日期时相应改变-----------------------
function changesxrq() {

 var str1="";
    var zxyy=document.all["zxyy"].value;
    if (zxyy=="G" || zxyy=="H"){
    if (document.all["sxrq"].value.length==0)
    {
     document.all["sxrq"].value=sysnowdate;
    }

    if(newisDate("生效日期",document.all["sxrq"].value)==0 ){
    	document.all["sxrq"].focus(); 
    	return false;
    }
    else{str1=changeDate(document.all["sxrq"].value);}
    if(cal_days(document.all["sxrq"].value,"")<0 )
   { alert("'生效日期'不应晚于今天！");
     document.all["sxrq"].focus();
     return false;
   }

    if (zxyy=="G" || zxyy=="H"){
       document.all["xzqz"].value=rqaddyears(str1,parseInt(document.all["xznx"].value));
    }
    }
}

	//驾驶证注销业务时检测函数
	function check_jzzx()  //保存前数据校验
	{
	         var zxyy=document.all["zxyy"].value;
	         if(zxyy==""){
	           alert("注销原因未选择！");
	           return false;}
	
	if (zxyy=="G" ||zxyy=="H")
	{
	 //do_change();
	         if (zxyy=="G") {  document.all["xzyy"].value=="C";} //限制原因
	         if (zxyy=="H") {  document.all["xzyy"].value=="E";} //限制原因
	         if (checkNull(document.all["cjwsbh"],"裁决文书号")==0 )   {document.all["cjwsbh"].focus(); return false;  }
	         if (zxyy=="H")
	         {document.all["xznx"].value="3";
	         }
	          if(newisDate("限制期止",document.all["xzqz"].value)==0 )
	           {
	            return false;
	            }
	           else
	          {document.all["xzqz"].value=changeDate(document.all["xzqz"].value);
	          }
	          if(cal_days(document.all["xzqz"].value,"")>0 )
	           { alert("'限制期止'不应早于今天！");
	             document.all["sxrq"].focus();
	            return false;}
	
	          if(newisDate("生效日期",document.all["sxrq"].value)==0 )
	           {
	             document.all["sxrq"].focus();
	            return false;
	            }
	           else
	          {
	          document.all["sxrq"].value=changeDate(document.all["sxrq"].value);
	          }
	          if(cal_days(document.all["sxrq"].value,"")<0 )
	           { alert("'生效日期'不应晚于今天！");
	             document.all["sxrq"].focus();
	            return false;
	            }
	         if (document.all.xzqz.value.substr(4,6)!=document.all.sxrq.value.substr(4,6))
	             {
	             alert("'生效日期'和'限制期止'月日不符！");
	             document.all["sxrq"].focus();
	             return false;
	             }
	
	         if (document.all.xzqz.value.substr(0,4).valueOf()-document.all.sxrq.value.substr(0,4).valueOf() != document.all["xznx"].value.valueOf())
	             {
	             alert("'限制年限'与'生效日期'和'限制期止'间隔不符！");
	             document.all["sxrq"].focus();
	             return false;
	             }
	}
	if (checkNull(document.all["bz"],"备注")==0){document.all["bz"].focus();return false;}
	   return true;
	}

	//驾驶证注销业务时检测函数
	function check_kz()
	{
	  if(checkNull(document.all["cjwsbh"],"裁决书编号")==0 )
	  { document.all["cjwsbh"].focus() ;return false;}
	  if(newisDate("暂扣日期",document.all["zkrq"].value)==0 ){
		  document.all["zkrq"].focus(); return false;}
	  else{
		  document.all["zkrq"].value=changeDate(document.all["zkrq"].value);
	  }
	  if(checkNull(document.all["zkqx"],"暂扣期限")==0 )
	  { document.all["zkqx"].focus() ;return false;}
	  if(checknum(document.all["zkqx"],"暂扣期限",true)!="1")
	  {return false;}
	  if(parseInt(document.all.zkqx.value)<=0){
		  alert("'暂扣期限'应该大于0 ！");
	      document.all["zkqx"].value = "";
	      document.all["zkqx"].focus();
	      return false;
	  }
	
	  if(parseInt(document.all.zkqx.value)>6){
		  alert("'暂扣期限'不应大于6个月 ！");
	      document.all["zkqx"].value = "";
	      document.all["zkqx"].focus();
	      return false;
	  }
	  
	  if(checkNull(document.all["zkjbr"],"暂扣经办人")==0)
	  {document.all["zkjbr"].focus(); return false;}
	  if(cal_days(document.all["zkrq"].value,"")<0 )
	   {alert("'暂扣日期'不应晚于今天！");
	    return false;}
	  if(DateAddMonth(document.all["zkrq"].value,document.all.zkqx.value)<=sysnowdate){
		  alert("'暂扣日期'+月数应该在今天之后！");
		  return false;
	  }
	 return true;
	}
	
	//驾驶证还证时检测
	function check_hz(){
		if(document.all["hzrq"].value>sysnowdate){
			return confirm("暂扣期限未到，是否确定要还证？");
		}
		return true;
	}
	
	//驾驶证锁定检测
	function check_sd()  //保存前数据校验
	{
	  if(checkNull(document.all["sddw"],"锁定单位")==0 ){
	      document.all["sddw"].focus() ;
		  return false;  
	  }
	  if(checkNull(document.all["sdlx"],"锁定类型")==0 )
	  {
	    document.all["sdlx"].focus() ;
	    return false;
	  }
	  if(checkNull(document.all["sdyy"],"锁定原因")==0)
	  {
	    document.all["sdyy"].focus();
	    return false;
	  }
	  return true;
	}

	//初始化要判断的档案更正
	function init_check_dagz(lxdhcd){
		var k=0;
		try{
			checkfields_dagz[k++] = new CheckObj("li_xm","姓名",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_xm","姓名",FRM_CHECK_CHINESE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_csrq","出生日期",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_csrq","出生日期",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_syrq","体检日期",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_syrq","体检日期",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_qfrq","清分日期",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_qfrq","清分日期",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqs","有效期始",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqs","有效期始",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqz","有效期止",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_yxqz","有效期止",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_cclzrq","初次领证日期",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_cclzrq","初次领证日期",FRM_CHECK_DATE,0,1);
			checkfields_dagz[k++] = new CheckObj("li_djzsxzqh","登记住所行政区划",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_djzsxxdz","登记住所详细地址",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_djzsxxdz","登记住所详细地址",FRM_CHECK_MINLENGTH,10);
			
			checkfields_dagz[k++] = new CheckObj("li_lxzsxzqh","联系住所行政区划",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsxxdz","联系住所详细地址",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsxxdz","联系住所详细地址",FRM_CHECK_MINLENGTH,10);
			checkfields_dagz[k++] = new CheckObj("li_lxzsyzbm","联系住所邮政编码",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsyzbm","联系住所邮政编码",FRM_CHECK_NUMBER,0,1);
			checkfields_dagz[k++] = new CheckObj("li_lxzsyzbm","联系住所邮政编码",FRM_CHECK_LENGTH,6);
			
			checkfields_dagz[k++] = new CheckObj("li_lxdh","固定电话",FRM_CHECK_LXDH,lxdhcd,1);
			checkfields_dagz[k++] = new CheckObj("li_sjhm","手机号码",FRM_CHECK_SJHM,0,1);
			checkfields_dagz[k++] = new CheckObj("li_dzyx","电子邮箱",FRM_CHECK_EMAIL,0,1);
			checkfields_dagz[k++] = new CheckObj("li_ljjf","累积记分",FRM_CHECK_NUMBER,0,1);
			
			checkfields_dagz[k++] = new CheckObj("ec_tjrq","体检日期",FRM_CHECK_NULL,0,1);
			checkfields_dagz[k++] = new CheckObj("ec_tjrq","体检日期",FRM_CHECK_DATE,0,1);
			
			checklen_dagz = k;	
		}catch(e){
			
		}
	}

	//初始化要判断的档案补建
	function init_check_dabj(lxdhcd){
		var k=0;
		try{
			checkfields_dabj[k++] = new CheckObj("li_dabhw","档案编号尾",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_dabhw","档案编号尾",FRM_CHECK_NUMBER,0,1);
			checkfields_dabj[k++] = new CheckObj("li_dabhw","档案编号尾",FRM_CHECK_LENGTH,8,1);
			checkfields_dabj[k++] = new CheckObj("li_xm","姓名",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_xm","姓名",FRM_CHECK_CHINESE,0,1);
			checkfields_dabj[k++] = new CheckObj("li_csrq","出生日期",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_csrq","出生日期",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_djzsxzqh","登记住所行政区划",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_djzsxxdz","登记住所详细地址",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_djzsxxdz","登记住所详细地址",FRM_CHECK_MINLENGTH,10);
			checkfields_dabj[k++] = new CheckObj("li_lxzsxzqh","联系住所行政区划",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsxxdz","联系住所详细地址",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsxxdz","联系住所详细地址",FRM_CHECK_MINLENGTH,10);
			checkfields_dabj[k++] = new CheckObj("li_lxzsyzbm","邮政编码",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsyzbm","邮政编码",FRM_CHECK_NUMBER,0,1);
			checkfields_dabj[k++] = new CheckObj("li_lxzsyzbm","邮政编码",FRM_CHECK_LENGTH,6);
			checkfields_dabj[k++] = new CheckObj("li_lxdh","固定电话",FRM_CHECK_LXDH,lxdhcd,1);
			checkfields_dabj[k++] = new CheckObj("li_sjhm","手机号码",FRM_CHECK_SJHM,0,1);
			checkfields_dabj[k++] = new CheckObj("li_dzyx","电子邮箱",FRM_CHECK_EMAIL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_cclzrq","初次领证日期",FRM_CHECK_NULL,0,1);
			checkfields_dabj[k++] = new CheckObj("li_cclzrq","初次领证日期",FRM_CHECK_DATE,0,1);
			checkfields_dabj[k++] = new CheckObj("li_yxqs","有效期始",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_yxqs","有效期始",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_yxqz","有效期止",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_yxqz","有效期止",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_syrq","体检日期",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_syrq","体检日期",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_qfrq","清分日期",FRM_CHECK_NULL,0,0);
			checkfields_dabj[k++] = new CheckObj("li_qfrq","清分日期",FRM_CHECK_DATE,0,0);
			checkfields_dabj[k++] = new CheckObj("li_ljjf","累积记分",FRM_CHECK_NUMBER,0,1);
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
	      alert("准驾车型包含非法字符！");
	      return false;
	    }
	    
	    if(_checksfzmhmlogic_bxr(document.all["li_sfzmmc"],document.all["li_sfzmhm"],document.all["li_csrq"],document.all["li_xb"])==false){
	    	return false;
	    }
	    
	    if(document.all.li_ljjf.value==""){
			document.all.li_ljjf.value="0";
	    }
	    //如果有效期不为长期，并且有效期止为空，自动填入相应的有效期止
	    if(document.all.li_jzqx.value=="1" && document.all.li_yxqz.value==""){
			document.all.li_yxqz.value=(new Number(document.all.li_yxqs.value.substr(0,4))+6)+document.all.li_yxqs.value.substr(4,6);
		}
		if(document.all.li_jzqx.value=="2" && document.all.li_yxqz.value==""){
			document.all.li_yxqz.value=(new Number(document.all.li_yxqs.value.substr(0,4))+10)+document.all.li_yxqs.value.substr(4,6);
		}
		if (document.all.li_jzqx.value!="4"){
		//如果输入了有效期止，五个日期的月日必须相同
	    if (document.all.li_cclzrq.value.substr(4,6)=="-02-29"){
		if(document.all.li_syrq.value.substr(4,6)!="-02-29" && document.all.li_syrq.value.substr(4,6)!="-02-28")
		{
			alert("下一体检日期、清分日期、有效期始、有效期止\n和初领日期的月和日必须相同！");
			return 0;
		}
		if(document.all.li_yxqs.value.substr(4,6)!="-02-29" && document.all.li_yxqs.value.substr(4,6)!="-02-28")
		{
			alert("下一体检日期、清分日期、有效期始、有效期止\n和初领日期的月和日必须相同！");
			return 0;
		}
		if(document.all.li_yxqz.value.substr(4,6)!="-02-29" && document.all.li_yxqz.value.substr(4,6)!="-02-28")
		{
			alert("下一体检日期、清分日期、有效期始、有效期止\n和初领日期的月和日必须相同！");
			return 0;
		}
		if(document.all.li_qfrq.value.substr(4,6)!="-02-29" && document.all.li_qfrq.value.substr(4,6)!="-02-28")
		{
			alert("下一体检日期、清分日期、有效期始、有效期止\n和初领日期的月和日必须相同！");
			return 0;
		}
	    }else{
				if(document.all.li_syrq.value.substr(4,6)!=document.all.li_yxqs.value.substr(4,6) ||
					document.all.li_yxqs.value.substr(4,6)!=document.all.li_yxqz.value.substr(4,6) ||
					document.all.li_yxqs.value.substr(4,6)!=document.all.li_qfrq.value.substr(4,6) ||
			  		document.all.li_yxqz.value.substr(4,6)!=document.all.li_cclzrq.value.substr(4,6))
				{
					alert("下一体检日期、清分日期、有效期始、有效期止\n和初领日期的月和日必须相同！");
					return 0;
				}
	         }
	    }
		
		//初次领证日期必须早于或者等于有效期始
		if(cal_days(document.all.li_yxqs.value,document.all.li_cclzrq.value)>0){
			alert("初次领证日期必须早于或者等于有效期始！");
			return 0;
		}
		
		//有效期始和有效期止的时间间隔必须和驾驶期限相符
		if(document.all.li_jzqx.value=="1" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=6){
			alert("有效期始和有效期止的时间间隔与驾驶期限不符！");
			return 0;
		}
		if(document.all.li_jzqx.value=="4" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=6){
			alert("有效期始和有效期止的时间间隔与驾驶期限不符！");
			return 0;
		}
		if(document.all.li_jzqx.value=="5" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=6){
			alert("有效期始和有效期止的时间间隔与驾驶期限不符！");
			return 0;
		}
		if(document.all.li_jzqx.value=="2" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=10){
			alert("有效期始和有效期止的时间间隔与驾驶期限不符！");
			return 0;
		}
		if(document.all.li_jzqx.value=="3" && document.all.li_yxqz.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()!=60){
			alert("长期证有效期始和有效期止应间隔60年！");
			return 0;
		}
		
		if(document.all.li_qfrq.value.substr(0,4).valueOf()-document.all.li_yxqs.value.substr(0,4).valueOf()<1){
			alert("'清分日期'不应早于有效期始加1年！");
			document.all["li_qfrq"].focus();
		    return 0;
		}
		
		if(document.all.li_qfrq.value.substr(0,4).valueOf()-sysnowdate.substr(0,4).valueOf()>1){
			alert("'清分日期'不应晚于当前日期加1年！");
			document.all["li_qfrq"].focus();
		    return 0;
		}
		
		if(cal_days(document.all["li_syrq"].value,"")>=0 ){
			alert("'下一体检日期'不应早于今天！");
			document.all["li_syrq"].focus();
		    return 0;
		}
	
		if(cal_days(document.all["li_yxqs"].value,"")<0){
			alert("有效起始'不应晚于今天！");
			document.all["li_yxqs"].focus();
			return 0;
		}
		
		if(cal_days(document.all.li_yxqz.value,"")>0){
			alert("有效期至必须晚于当前日期！");
			document.all["li_yxqz"].focus();
			return 0;
		}
		
		if(cal_days(document.all["ec_tjrq"].value,"")<0 ){
			alert("'体检日期'不应晚于今天！");
			document.all["ec_tjrq"].focus();
		    return 0;
		}
		
		if (document.all["li_ly"].value=="B"){
		   //if(checknull(document.all["li_zzzm"],"居暂住证号",1)!="1" ) { return 0;}
		   if(checknull(document.all["li_lxzsxxdz"],"联系住所",1)!="1") { return 0;}
		}else{
			//if((document.all["li_zzzm"].value!="")&&(document.all["li_ly"].value!="C") ){
		      //  alert("本地驾驶员不需要输入暂住证号！");
		      // document.all.zzzm.focus();
		      //  return 0;
		    // }
		}
		if (document.all["li_sfzmmc"].value=="A"&&document.all["li_gj"].value!="156"){
			alert("国籍必须为中国！");
			return 0;
		}
		if (document.all["li_sfzmmc"].value=="C"&&document.all["li_gj"].value!="156"){
			alert("国籍必须为中国！");
			return 0;
		}
		if (document.all["li_sfzmmc"].value=="D"&&document.all["li_gj"].value!="156"){
			alert("国籍必须为中国！");
			return 0;
		}
		if (document.all["li_sfzmmc"].value=="E"&&document.all["li_gj"].value!="156"){
			alert("国籍必须为中国！");
			return 0;
		}
		if (document.all["li_jzqx"].value=="2"&&document.all["li_yxqz"].value<"2018-05-01"){
			alert("驾驶证期限不能为十年！");
			return 0;
		}
		if (document.all["li_jzqx"].value=="3"&&document.all["li_yxqz"].value<"2018-05-01"){
			alert("驾驶证期限不能为长期！");
			return 0;
		}
		
		//证芯编号检测
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
			alert("未下载到该驾驶员信息！");
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
		    		  document.all["span_li_sfzmmc"].innerText="居民身份证";
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
			tmpzjmc="居民身份证";
		}
		if(zjmc=="C"){
			tmpzjmc="军官证";
		}
		if(zjmc=="D"){
			tmpzjmc="士兵证";
		}
		if(zjmc=="E"){
			tmpzjmc="军官离退休证";
		}
		if(zjmc=="F"){
			tmpzjmc="境外人员身份证明";
		}
		if(zjmc=="G"){
			tmpzjmc="外交人员身份证明";
		}
		return tmpzjmc;
	}


function sjxzclick(vgnid){
	if(vgnid=="0310"){	//下载档案更正信息
		var ndabh;
		ndabh=document.all["li_dabh"].value;
		var oXmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		oXmlHttp.Open("POST", "dagl.do?method=getDagzXmlInfo&dabh="+ndabh, false);
		oXmlHttp.setRequestHeader("Content-Type","text/xml;charset=GB2312") ;
		oXmlHttp.Send();
		if(oXmlHttp.status!="200")
		{alert("没有返回正确的数据类型。");
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
	
	if(vgnid=="0313"){  //下载档案补录信息
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

//检查是否发起读卡操作
function checkDy()
{
   if(document.formedit.newsfzmhm.value=="")
   {
      document.formedit.isRead.value="0";
   }
   var isRead=document.formedit.isRead.value;
   if(isRead=="0")//未读取到信息，可读
   {
       return true;
   }
   else
   {
      return false;
   }
}
//显示出错信息
function setPrompt(prompt){
	  var pp = document.getElementById("tdReadResult");
	  pp.innerHTML = "<font color=\"#FF0000\">"+prompt+"</font>";
}

function parseCardInfo(sss){ 
  	//初领时读取数据
	document.formedit.isRead.value="1";
	document.all.autoEquSfzmInfo.value=sss;
	sfzxx = sss.split("|");
	ls_xm = sfzxx[1];
	ls_sfzmhm = sfzxx[6];//取身份证号
	document.formedit.newsfzmhm.value = ls_sfzmhm;
	document.formedit.newxm.value = ls_xm;
	ls_xb = ls_sfzmhm.substring(16,17); //取性别
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
      alert("未读到二代身份证信息！");
    }else if (jstrim(document.all["yxm"].value) == jstrim(document.all["newxm"].value)){
      document.all["li_sfzmhm"].value = document.all["newsfzmhm"].value;
      document.all["li_sfzmmc"].value="A";
      document.all["li_xm"].value = document.all["newxm"].value;
      document.all["li_xb"].value = document.all["newxb"].value;
	  document.all["span_li_sfzmhm"].innerText=document.all["newsfzmhm"].value;
	  document.all["span_li_sfzmmc"].innerText="居民身份证";
	  
      var ls_csrq = document.all["newcsrq"].value;
      if(ls_csrq.length == 8)
      document.all["li_csrq"].value = ls_csrq.substring(0,4)+"-"+ls_csrq.substring(4,6)+"-"+ls_csrq.substring(6,8);
      document.all["li_djzsxxdz"].value = document.all["newzsdz"].value;
    }else
         alert("二代身份证上姓名与原姓名不一致，不可直接变更身份证号！");
  }

//档案补建检测
function check_dabj(){
	
	if(document.all["dabjdown"].value==0){
		alert("未从总队正确下载到补建信息，不允许办理业务！");
		return 0;
	}
	
	if(document.all.li_ljjf.value.length==0){
		document.all.li_ljjf.value="0";
	}
	document.all.li_zjcx.value=document.all.li_zjcx.value.toUpperCase();
	document.all.li_dabh.value=document.all.li_dabht.value+document.all.li_dabhw.value;
	if(document.all.li_dabh.value.length!=12){
		alert("档案编号长度不符！");
		return 0;
	}
	if(checkallfields(checkfields_dabj,1,checklen_dabj)==0){
		return 0;
    }
    var djzsxxdz = document.all.li_djzsxxdz.value;
    var bddzxx = document.all.bddzxx.value;
	var isLocal = checkIsLocal(bddzxx,djzsxxdz);
	if(!isLocal && document.all.li_djzsxzqh.options(document.all.li_djzsxzqh.selectedIndex).text!="外地"){
		alert("当前申请人登记住所地址是外地地址，但选择的登记住所行政区划是本地行政区划！");
        return false;
    }
    if (isLocal){
    	if(document.all["li_zzzm"].value.length!=0){
    		alert("本地驾驶人暂住证明号必须为空！");
    		return 0;
    	}
        document.all.li_sfbd.value ="1";
        document.all.li_ly.value = "A";
    }else{
        document.all.li_sfbd.value ="0";
        document.all.li_ly.value ="B";
    }
    
    if(check_sqcx(document.all["li_zjcx"].value,"C")==0){
      alert("准驾车型包含非法字符！");
      return false;
    }
}

//农机补录检测
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
	if(!isLocal && document.all.li_djzsxzqh.options(document.all.li_djzsxzqh.selectedIndex).text!="外地"){
		alert("当前申请人登记住所地址是外地地址，但选择的登记住所行政区划是本地行政区划！");
        return false;
    }
    if (isLocal){
    	if(document.all["li_zzzm"].value.length!=0){
    		alert("本地驾驶人暂住证明号必须为空！");
    		return 0;
    	}
        document.all.li_sfbd.value ="1";
        document.all.li_ly.value = "A";
    }else{
        document.all.li_sfbd.value ="0";
        document.all.li_ly.value ="B";
    }
    
    if(check_sqcx(document.all["li_zjcx"].value,"C")==0){
      alert("准驾车型包含非法字符！");
      return false;
    }
}

//设置有效期止
function setyxqz(){
	var syrq;
	var months;
	  if(newisDate("有效期始",document.all["li_yxqs"].value)==0){
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
			ret="身份证明号码与出生日期不对应；";
			result=false;
		}	
		if(xbobj.value!=xb){
			ret=ret+"身份证明号码与性别不对应；";
			result=false;
		}
	}
	if(result==false){
		alert(ret);
	}
	return result;
}

//性别不强制检测，但提示根据成都要求考虑变性人的需求
function _checksfzmhmlogic_bxr(sfzmmcobj,sfzmhmobj,csrqobj,xbobj){
	var ret="";
	var result=true;
	if(sfzmmcobj.value=='A'){
		var csrq=getcsrqbysfzmhm(sfzmhmobj.value);
		var xb=getxbbysfzmhm(sfzmhmobj.value);
		if(csrqobj.value!=csrq){
			alert("身份证明号码与出生日期不对应；");
			result=false;
		}	
		if(xbobj.value!=xb){
			result=confirm("身份证明号码与性别不对应，是否确认修改？");
		}
	}
	return result;
}

function changedaglyxqz(){
	if(checkdate(document.all["li_yxqs"],"有效期始",1)!="1"){
		return;
	}
	
	if(checkdate(document.all["li_yxqz"],"有效期至",1)!="1"){
		return;
	}
	
	if(checkdate(document.all["li_syrq"],"下一体检日期",1)!="1"){
		return;
	}
	
	if(checkdate(document.all["li_qfrq"],"清分日期",1)!="1"){
		return;
	}
		
	document.all.li_yxqz.value=document.all.li_yxqz.value.substr(0,4)+document.all.li_yxqs.value.substr(4,6);
	document.all.li_syrq.value=document.all.li_syrq.value.substr(0,4)+document.all.li_yxqs.value.substr(4,6);
	document.all.li_qfrq.value=document.all.li_qfrq.value.substr(0,4)+document.all.li_yxqs.value.substr(4,6);
}