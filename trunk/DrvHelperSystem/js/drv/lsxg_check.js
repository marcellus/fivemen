//保存前数据校验
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
 var o_zjcx;
 var o_yzjcx;
 var o_lxdh;
 var o_sjhm;
 ///////////
 var o_zt;
 var o_yxqz;
 var o_ydabh;
 var o_dabh;
 var o_cclzrq;
 var o_yxqs;
 var o_yxqz;
 var o_ljjf;
 var o_tjrq;
 //
 var o_sfzmhm;
 var o_sfzmmc;
 var o_xb;
 var o_jxmc;
 
 var o_ywlx;
 var o_ywyy;
 var o_prefix;
     
function _setobj(){
    if(this.o_prefix=="ps_"){
       this.o_ly=document.all["ec_ly"];
       this.o_lxzsxzqh=document.all["ps_lxzsxzqh"];
       this.o_lxzsxxdz=document.all["ps_lxzsxxdz"];
       this.o_djzsxzqh=document.all["ps_djzsxzqh"];
       this.o_djzsxxdz=document.all["ps_djzsxxdz"];
       this.o_xzqh=document.all["ec_xzqh"];
       this.o_sqdm=document.all["ec_sqdm"];
       this.o_sfbd=document.all["ps_sfbd"];
       this.o_sqcx=document.all["ec_zkcx"];
       this.o_csrq=document.all["ps_csrq"];
       this.o_zjcx=document.all["ec_zjcx"];
       this.o_yzjcx=document.all["ec_yzjcx"];
       this.o_lxdh=document.all["ps_lxdh"];
       this.o_sjhm=document.all["ps_sjhm"];   
       //
       this.o_zt=document.all["ec_zt"];
       this.o_yxqz=document.all["ec_yxqz"];
       this.o_ydabh=document.all["ec_ydabh"];
       this.o_dabh=document.all["ec_dabh"];
       this.o_yxqs=document.all["ec_yxqs"];
       this.o_yxqz=document.all["ec_yxqz"];
       this.o_cclzrq=document.all["ec_cclzrq"];
       this.o_ljjf=document.all["ec_ljjf"];
       //体检日期
       this.o_tjrq=document.all["ec_tjrq"];
       this.o_sfzmhm=document.all["ps_sfzmhm"];
       this.o_sfzmmc=document.all["ps_sfzmmc"];
       this.o_xb=document.all["ps_xb"];
       this.o_jxmc=document.all["ec_jxmc"];
    }else if(this.o_prefix=="tp_"){
       this.o_ly=document.all["tp_ly"];
       this.o_lxzsxzqh=document.all["tp_lxzsxzqh"];
       this.o_lxzsxxdz=document.all["tp_lxzsxxdz"];        
       this.o_djzsxzqh=document.all["tp_djzsxzqh"];
       this.o_djzsxxdz=document.all["tp_djzsxxdz"];
       this.o_xzqh=document.all["tp_xzqh"];
       this.o_sqdm=document.all["tp_sqdm"];
       this.o_sfbd=document.all["tp_sfbd"];
       this.o_sqcx=document.all["tp_zjcx"];
       this.o_csrq=document.all["tp_csrq"];  
       this.o_zjcx=document.all["tp_zjcx"];
       this.o_yzjcx=document.all["tp_yzjcx"];   
       this.o_lxdh=document.all["tp_lxdh"];
       this.o_sjhm=document.all["tp_sjhm"];
       //
       this.o_zt=document.all["tp_zt"];
       this.o_yxqz=document.all["tp_yxqz"];
       this.o_ydabh=document.all["tp_ydabh"];
       this.o_dabh=document.all["tp_dabh"];
       this.o_yxqs=document.all["tp_yxqs"];
       this.o_yxqz=document.all["tp_yxqz"];   
       this.o_cclzrq=document.all["tp_cclzrq"];  
       this.o_ljjf=document.all["tp_ljjf"]; 
       
       this.o_tjrq=document.all["tp_tjrq"];       
       this.o_sfzmhm=document.all["tp_sfzmhm"];
       this.o_sfzmmc=document.all["tp_sfzmmc"];
       this.o_xb=document.all["tp_xb"];
       this.o_jxmc=document.all["tp_jxmc"];
    } else if(this.o_prefix=="li_"){
       this.o_ly=document.all["li_ly"];
       this.o_lxzsxzqh=document.all["li_lxzsxzqh"];
       this.o_lxzsxxdz=document.all["li_lxzsxxdz"];        
       this.o_djzsxzqh=document.all["li_djzsxzqh"];
       this.o_djzsxxdz=document.all["li_djzsxxdz"];
       this.o_xzqh=document.all["li_xzqh"];
       this.o_sqdm=document.all["li_sqdm"];
       this.o_sfbd=document.all["li_sfbd"];
       this.o_sqcx=document.all["li_zkcx"];
       this.o_csrq=document.all["li_csrq"];
       this.o_zjcx=document.all["li_zjcx"];
       this.o_yzjcx=document.all["li_yzjcx"];   
       this.o_lxdh=document.all["li_lxdh"];
       this.o_sjhm=document.all["li_sjhm"];
       //
       this.o_zt=document.all["li_zt"];
       this.o_yxqz=document.all["li_yxqz"];
       this.o_ydabh=document.all["li_ydabh"];
       this.o_dabh=document.all["li_dabh"];
       this.o_yxqs=document.all["li_yxqs"];
       this.o_yxqz=document.all["li_yxqz"]; 
       this.o_csrq=document.all["li_csrq"];   
       this.o_cclzrq=document.all["li_cclzrq"];
       this.o_ljjf=document.all["li_ljjf"];  
       
       this.o_tjrq=document.all["li_tjrq"];        
       this.o_sfzmhm=document.all["li_sfzmhm"];
       this.o_sfzmmc=document.all["li_sfzmmc"];
       this.o_xb=document.all["li_xb"];
       this.o_jxmc=document.all["li_jxmc"];
    } else if(this.o_prefix=="lo_"){
       this.o_ly=document.all["lo_ly"];
       this.o_lxzsxzqh=document.all["lo_lxzsxzqh"];
       this.o_lxzsxxdz=document.all["lo_lxzsxxdz"];        
       this.o_djzsxzqh=document.all["lo_djzsxzqh"];
       this.o_djzsxxdz=document.all["lo_djzsxxdz"];
       this.o_xzqh=document.all["lo_xzqh"];
       this.o_sqdm=document.all["lo_sqdm"];
       this.o_sfbd=document.all["lo_sfbd"];
       this.o_sqcx=document.all["lo_zkcx"];
       this.o_csrq=document.all["lo_csrq"];
       this.o_zjcx=document.all["lo_zjcx"];
       this.o_yzjcx=document.all["lo_yzjcx"]; 
       this.o_lxdh=document.all["lo_lxdh"];
       this.o_sjhm=document.all["lo_sjhm"];
       //
       this.o_zt=document.all["lo_zt"];
       this.o_yxqz=document.all["lo_yxqz"];
       this.o_ydabh=document.all["lo_ydabh"];
       this.o_dabh=document.all["lo_dabh"];
       this.o_yxqs=document.all["lo_yxqs"];
       this.o_yxqz=document.all["lo_yxqz"]; 
       this.o_cclzrq=document.all["lo_cclzrq"];   
       this.o_ljjf=document.all["lo_ljjf"];
       
       this.o_tjrq=document.all["lo_tjrq"];        
       this.o_sfzmhm=document.all["lo_sfzmhm"];
       this.o_sfzmmc=document.all["lo_sfzmmc"];
       this.o_xb=document.all["lo_xb"];
       this.o_jxmc=document.all["lo_jxmc"];
   }  	
}
// 检测地址是否输入正确
function _checkdzxx(_ly){
	if (_ly=="A" ||_ly=="B"){
    	var ls_ret ;
  		try{
  			ls_ret = check_dzxx(this.o_prefix);
      		if (ls_ret != "1"){
        		alert(ls_ret);
        		this.o_djzsxxdz.focus();
        		return false;
      		}
    	}catch(err){
      		document.writeln("错误名称: " + err.name+" ---> ");
      		document.writeln("错误信息: " + err.message+" ---> ");
    	}
  	}
	return true;
}
//生成社区代码
function _setsqdm(){
  	// 生成社区代码
  	var o_xiangzhen=document.all["xiangzhen"];
    var o_cun=document.all["cun"];
    if(o_xiangzhen!=undefined)  {
    	var ls_xzqh = o_xzqh.value; // 行政区划
    	var ls_xz   = o_xiangzhen.value;   // 镇
    	if (ls_xz == "") ls_xz = "000";
    	var ls_cun  = o_cun.value;       // 村
    	if (ls_cun == "") ls_cun = "000";
    	this.o_sqdm.value = ls_xzqh + ls_xz + ls_cun; // 社区代码
    }
}

// add by zou 20080724 判断是否是本地地址
function _checkbddzxx(){
	var djzsxxdz = this.o_djzsxxdz.value;
	var bddzxx = document.all["bddzxx"].value;
	var isLocal = checkIsLocal(bddzxx,djzsxxdz);
	
    if(o_djzsxzqh!=undefined&&o_djzsxzqh.tagName=="SELECT"){
    	if(!isLocal && o_djzsxzqh.options(o_djzsxzqh.selectedIndex).text!="外地"){
    		alert("当前申请人登记住所地址是外地地址，但选择的登记住所行政区划是本地行政区划！");
    		return false;
    	}
    }
    
	if (isLocal) {
	    this.o_sfbd.value = "1";
	}  else  {
	    this.o_sfbd = "0";
	}
	if (!isLocal) {
	    if(!check_zzzm(this.o_prefix)) {
	        return false;
	    }
	} 

	if(this.o_lxzsxxdz.value.length==0){
		for (i=0;i<this.o_lxzsxzqh.length; i++){
			if (this.o_lxzsxzqh.options(i).value==this.o_djzsxzqh.value){
				this.o_lxzsxzqh.value=this.o_djzsxzqh.value
			}
		}
	}
	this.o_lxzsxxdz.value=this.o_djzsxxdz.value;
	return true;
}
//检测如果是身份证明名称，需检测出生日期和性别是否正确
function lsxg_checksfzmhm(){
	var ret="";
	var result=true;
	if(this.o_sfzmmc.value=='A'){
		var csrq=getcsrqbysfzmhm(this.o_sfzmhm.value);
		var xb=getxbbysfzmhm(this.o_sfzmhm.value);
		if(this.o_csrq.value!=csrq){
			ret=ret+"身份证明号码与出生日期不对应；";
			result=false;
		}	
		if(this.o_xb.value!=xb){
			ret=ret+"身份证明号码与性别不对应；";
			result=false;
		}
	}
	if(result==false){
		alert(ret);
	}	
	return result;
}


//type 1非持证业务,2持证业务
function lsxg_check(ywlx,ywyy){
	this.o_ywlx=ywlx;
	this.o_ywyy=ywyy;
	this.o_prefix=_prefix;
	//给公共赋值
	_setobj();
	//初领，本地和外地
	if(this.o_ywlx=='A'|| this.o_ywlx=='B'){
		return lsxg_check_ccsq_record();	
	}else if(this.o_ywlx=='C' && this.o_ywyy=='B'){
		return lsxg_check_zr_record();
	}else if(this.o_ywlx=='C' && this.o_ywyy!='B'){
		return lsxg_check_bzhz_record();
	}
	return true;
}


function lsxg_check_ccsq_record(){

    
    // add by zou 20080724 判断是否是本地地址
	if(!_checkbddzxx()){
		return false;
	}	
	
	// 检测地址是否输入正确
	if(!_checkdzxx(this.o_ly.value)){
		return false;
	}
	
	//检测身份证明号码与出生日期、性别
	if(!lsxg_checksfzmhm()){
		return false;
	}	
	
  	// 体检基本合法性判断
  	if(check_tjxx(this.o_sqcx.value)==0) {
		return false;
    }
  	
	var ywlx=document.all["ywlx"].value;
	if(ywlx=="A") {
	    // 申请人申请驾驶证校验
		if(check_sqxx(this.o_sqcx.value,this.o_csrq.value,this.o_ly.value)==0) {
		  	return false;
		}
	}
	//检测电话不能同时为空
	if(!_checklxdh()){
		return false;
	}	
	
	//体检日期
	if(cal_days(o_tjrq.value,"")<0 ){
		alert("'体检日期'不应晚于今天！");
		o_tjrq.focus();
	    return false;
	}	
	
  	// 生成社区代码
    _setsqdm();
    return true;        
}


//持证业务
//保存前数据校验
function lsxg_check_bzhz_record(){


    // add by zou 20080724 判断是否是本地地址
	if(!_checkbddzxx()){
		return false;
	}	
	
	// 检测地址是否输入正确
	if(!_checkdzxx(this.o_ly.value)){
		return false;
	}	
	
	var ywyy=document.all["ywyy"].value;
  	if(ywyy.indexOf("A")>=0||ywyy.indexOf("C")>=0
  			||ywyy.indexOf("H")>=0){
  		// 体检基本合法性判断
  		if(check_tjxx(this.o_sqcx.value)==0){
			return false;
    	}
    }

  	 // 变更
  	if (this.o_ywyy.indexOf("E")!=-1 ) {
  		
	}
  	
  //降级
	if (this.o_ywyy.indexOf("D")!=-1 ) {
  		o_zjcx.value=jstrim(o_zjcx.value);
  		o_zjcx.value=o_zjcx.value.toUpperCase();
  		if(o_zjcx.value.length==0){
       		o_zjcx.focus();
    		alert("申请车型不能为空！");
    		return false;
 		}
  		if (o_yzjcx.value==o_zjcx.value){
        	o_zjcx.focus();
     		alert("原准驾车型与申请车型一致，无需降级！");
			return false;
   		}
    	if (yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0 ){
        	o_zjcx.focus();
     		alert("原准驾车型必须包含申请车型！");
			return false;
   		}   	
	}  	
	
	////期满、超龄、年度体检
	if (this.o_ywyy.indexOf("A")>=0 ||  this.o_ywyy.indexOf("C")>=0 || this.o_ywyy.indexOf("H")>=0 )	{
  		//如果是超龄，判断新车型是否包含在原车型内部
  		if (this.o_ywyy.indexOf("C")>=0 && yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0){
    		if (o_yzjcx.value == o_zjcx.value){
      			alert("新准驾车型不符合要求！");
    		}
    		alert("新准驾车型必须包含在原准驾车型中！");
    		return false;
  		}
  		//体检基本合法性判断
  		if(check_tjxx(o_zjcx.value)==0){
			return false;
    	}  		
  	}
	
	
	//变更
  	if (this.o_ywyy.indexOf("D")>=0 || this.o_ywyy.indexOf("E")>=0)  {
   		//判断是否允许降级相应车型获取最大准驾车型
  		var bigZjcx = getBigZjcx(o_zjcx.value);
   		if (jscx_nl(bigZjcx,o_csrq.value) == 0){
       		//o_zjcx.focus();
       		//alert("当前驾驶人的年龄不允许申请" + o_zjcx.value + "！");
       		return false;
   		}  		
	}	
	//检测电话不能同时为空
	if(!_checklxdh()){
		return false;
	}
	
	if(this.o_ywyy.indexOf("A")>=0||this.o_ywyy.indexOf("C")>=0
			||this.o_ywyy.indexOf("D")>=0){
		//体检日期
		if(cal_days(o_tjrq.value,"")<0 ){
			alert("'体检日期'不应晚于今天！");
			o_tjrq.focus();
		    return false;
		}  			
	}	
	
  	// 生成社区代码
    _setsqdm();
    return true;
}



//转入保存前数据校验
function lsxg_check_zr_record(todayStr)  {
	//检测身份证明号码与出生日期、性别
	if(!lsxg_checksfzmhm()){
		return false;
	}	
  	
  	if(o_lxzsxxdz.value.length==0){
		for (i=0;i<o_lxzsxzqh.length; i++){
			if (o_lxzsxzqh.options(i).value==o_djzsxzqh.value){
				o_lxzsxzqh.value=o_djzsxzqh.value;
  			}
		}
		o_lxzsxxdz.value=o_djzsxxdz.value;
	}
  	
    //生成社区代码
    _setsqdm();
    return true;
}



function _checklxdh(){
    //判断
    if(o_lxdh.value=="" && o_sjhm.value==""){
        alert("必须录入固定电话或移动电话，两者不能同时为空！");
        o_lxdh.focus();
        return false;    	
    }
    return true;
}	

