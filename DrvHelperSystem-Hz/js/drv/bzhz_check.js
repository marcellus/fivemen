
function check_bzhz_record(_prefix)  //保存前数据校验
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
  	     
    //判断
    if(o_lxdh.value=="" && o_sjhm.value==""){
        alert("固定电话和移动电话不能同时为空。");
        return false;    	
    }
    
	var ywyy=document.all["ywyy"].value;
	
	if (ywyy.indexOf("D")!=-1 )  //降级
	{
  		o_zjcx.value=jstrim(o_zjcx.value);
  		o_zjcx.value=o_zjcx.value.toUpperCase();
  		if(o_zjcx.value.length==0)
  		{
       		o_zjcx.focus();
    		alert("申请车型不能为空！");
    		return false;
 		}
  		/*
    	if (o_yzjcx.value==o_zjcx.value)
   		{
        	o_zjcx.focus();
     		alert("原准驾车型与申请车型一致，无需降级！");
			return false;
   		}
    	if (yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0 )
   		{
        	o_zjcx.focus();
     		alert("原准驾车型必须包含申请车型！");
			return false;
   		}   
  		var bigZjcx = getBigZjcx(o_zjcx.value);
   		if (jscx_nl(bigZjcx,o_csrq.value) == 0)
   		{
       		o_zjcx.focus();
       		//alert("当前驾驶人的年龄不允许申请" + o_zjcx.value + "！");
       		return false;
   		}  */
	}

	//检测地址是否输入正确
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
      		document.writeln("错误名称: " + err.name+" ---> ");
　　 　		document.writeln("错误信息: " + err.message+" ---> ");
    	}
    	finally
    	{

    	}
  	}
  	
	if (ywyy.indexOf("A")>=0 ||  ywyy.indexOf("C")>=0 || ywyy.indexOf("H")>=0 )  //期满、超龄、年度体检
	{
		/*
  		//如果是超龄，判断新车型是否包含在原车型内部
  		if (ywyy.indexOf("C")>=0 && yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0)
  		{
    		if (o_yzjcx.value == o_zjcx.value)
    		{
      			alert("新准驾车型不符合要求！");
    		}
    		alert("新准驾车型必须包含在原准驾车型中！");
    		return false;
  		}
  		*/
  		//体检基本合法性判断
  		if(check_tjxx(o_zjcx.value)==0)
  		{
			return false;
    	}  		
  	}
	
	if(ywyy.indexOf("E")>=0 && o_sfzmmc.value=="A"){
		//判断身份证明号码和出生日期是否一致
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
			alert("出生日期与居民身份证号码不符。");
			o_sfzmhm.focus();
			return false;
		}
	}	
	if(ywyy.indexOf("E")>=0){
		if((o_sfzmmc.value=="A" || o_sfzmmc.value=="C"
			|| o_sfzmmc.value=="D" || o_sfzmmc.value=="E") && o_gj.value!="156"){
			alert("国籍与身份证明不符。");
			o_gj.focus();
			return false;
		}
	}
	
	/*
  	if (ywyy.indexOf("E")>=0)  //变更
  	{
   		//变更出生日期后判断年龄是否符合要求
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
	       		//alert("当前驾驶人的年龄不允许申请" + o_zjcx.value + "！");
	       		return false;
	   		}  	
  		} 		
	}
	*/
    //add by zou 20080724 判断是否是本地地址
    var djzsxxdz = o_djzsxxdz.value;
    var bddzxx = document.all["bddzxx"].value;
    var isLocal = checkIsLocal(bddzxx,djzsxxdz);
    if(o_djzsxzqh!=undefined&&o_djzsxzqh.tagName=="SELECT")
    {
    	if(!isLocal && o_djzsxzqh.options(o_djzsxzqh.selectedIndex).text!="外地")
    	{
    		alert("住所地址是外地，住所行政区划为本地，请检查信息录入是否正确。");
    		return false;
    	}
    	if(isLocal&& o_djzsxzqh.options(o_djzsxzqh.selectedIndex).text=="外地")
    	{
    		alert("住所地址是本地，住所行政区划为外地，请检查信息录入是否正确。");
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
  	if (ywyy.indexOf("E")>=0)  //变更
  	{    
		if(!isLocal){
	        if(document.all["li_zzzm"].value=="")
	        {
	        	alert("当前申请人登记住所地址是外地地址，请输入暂住证号！");
	        	document.all["li_zzzm"].focus();
	            return false;
	        }
		}else{
	        if(document.all["li_zzzm"].value!="")
	        {
	        	alert("当前申请人登记住所地址是本地地地址，无需输入暂住证号！");
	        	document.all["li_zzzm"].focus();
	            return false;	        	
	        }
		}
  	}
  	*/
  	//生成社区代码
    var ls_xzqh = o_xzqh.value; //行政区划
    var ls_xz   = document.all["xiangzhen"].value;   //镇
    if (ls_xz == "") ls_xz = "000";
    var ls_cun  = document.all["cun"].value;       //村
    if (ls_cun == "") ls_cun = "000";
    o_sqdm.value = ls_xzqh + ls_xz + ls_cun; //社区代码
    return true;
}
//年度体检模块检测
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
	//体检基本合法性判断
	if(check_tjxx(o_zjcx.value)==0)
	{
		return false;
	}
	return true;
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
	  //document.all["span_li_sfzmhm"].innerText=document.all["newsfzmhm"].value;
	  //document.all["span_li_sfzmmc"].innerText="居民身份证";
	  
      var ls_csrq = document.all["newcsrq"].value;
      if(ls_csrq.length == 8)
      document.all["li_csrq"].value = ls_csrq.substring(0,4)+"-"+ls_csrq.substring(4,6)+"-"+ls_csrq.substring(6,8);
      document.all["li_djzsxxdz"].value = document.all["newzsdz"].value;
    }else
         alert("二代身份证上姓名与原姓名不一致，不可直接变更身份证号！");
  }






