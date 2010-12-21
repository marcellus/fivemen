//add by zou 判断几个日期是否一致的函数 2006-03-01
function strequal(rq1, rq2)
{
  if (rq1 == rq2) return true; //两者相同
  if (rq1 == "02-28" || rq1 == "02-29")  //两者不同，则检查是否是2月28日的情况
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
function check_zr_record(_prefix)  //保存前数据校验
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
      	trimall();	//去掉所有Text的两端空格
      	/*
		if (o_zt.value!="A")
		{
			alert("驾驶员状态不正常，不能转入。");
			return false;
		}
        if(cal_days(o_yxqz.value,"")>0)
        {
            alert("该驾驶证已经过期，不能转入。")
            return false;
        }
		*/
        /*
      	//准驾车型不能为空,且必须符合逻辑
      	if(check_sqcx(o_zjcx.value,"C")==0)
      	{
        	alert("准驾车型包含非法字符！");
        	return false;
      	}
        if (yzjcx_sqcx(o_yzjcx.value,o_zjcx.value)==0 )
        {
          		o_zjcx.focus();
          		alert("原准驾车型必须包含申请车型！");
          		return false;
        }
      	if(cal_days(o_yxqs.value,"")<0)
      	{
        	o_yxqs.focus();
        	alert("有效期始必须在今天以前")
        	return false;
      	}
      	if(cal_days(o_yxqz.value,"")>0)
      	{
        	o_yxqs.focus();
        	alert("有效期止为"+o_yxqz.value+",不能转入！")
       	 	return false;
      	}
      	if(cal_days(o_cclzrq.value,o_yxqs.value)<0)
      	{
        	o_cclzrq.focus();
        	alert("初次领证日期必须在有效期始前")
        	return false;
      	}
      	//
      	if (!strequal(o_cclzrq.value.substr(5,10),o_yxqs.value.substr(5,10)))
      	{
        	o_yxqs.focus();
        	alert("有效期始和初领日期的月和日必须相同！");
        	return false;
      	}
      	
      	//累积积分如果为空，自动填入0，积分不能大于12分
      	if(o_ljjf.value=="")
      	{
      		o_ljjf.value="0";
      	}
      	else
      	{
        	if(isNum("累积记分",o_ljjf.value)==0)
        	{
          		o_ljjf.focus();
          		return false;
        	}
        	if(parseInt(o_ljjf.value)>11)
        	{
          		o_ljjf.focus();
          		alert("累积记分超过11分！\n请先进行处理再办理转入。");
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
	        	if(isLength("档案编号","8",o_bh2)==0 )   
	            {
	                return false;
	            }
	            if(isNum("档案编号",o_bh2.value)==0 )   
	            {
	                return false;
	            }
        	
        	} 	
        }
  		/*
        nl=cal_years(o_csrq.value);//求年龄
        if (nl<18)
        {
            alert("年龄必须超过18！")
            return false
        }
        else if (nl>=60)
        {
            if (o_zjcx.value.indexOf("A")>-1)
            {
                alert("当前年龄超过60岁，不能转入A1A2A3车型");
                return false;
            }
            if (o_zjcx.value.indexOf("B")>-1)
            {
                alert("当前年龄超过60岁，不能转入B1B2车型");
                return false;
            }
            if (o_zjcx.value.indexOf("N")>-1)
            {
                alert("当前年龄超过60岁，不能转入N车型");
                return false;
            }
            if (o_zjcx.value.indexOf("P")>-1)
            {
                alert("当前年龄超过60岁，不能转入P车型");
                return false;
            }
         }
         else if (nl>=70)
         {
            if (o_zjcx.value.indexOf("C3")>-1)
            {
               alert("当前年龄超过70岁，不能转入C3车型");
               return false;
            }
            if (o_zjcx.value.indexOf("C4")>-1)
            {
                alert("当前年龄超过70岁，不能转入C4车型");
                return false;
            }
            if (o_zjcx.value.indexOf("D")>-1)
            {
                alert("当前年龄超过70岁，不能转入D车型");
                return false;
            }
            if (o_zjcx.value.indexOf("E")>-1)
            {
                alert("当前年龄超过70岁，不能转入E车型");
                return false;
            }
            if (o_zjcx.value.indexOf("M")>-1)
            {
                alert("当前年龄超过70岁，不能转入M车型");
                return false;
            }
         }
         */
 
    //体检基本合法性判断
    if(document.all["ec_sftj"]!=undefined&&document.all["ec_sftj"].value=="1"){
	    if(check_tjxx(o_zjcx.value)==0)
	    {
	    		return false;
	    }
    }
    //生成社区代码
  	var o_xiangzhen=document.all["xiangzhen"];
    var o_cun=document.all["cun"];
    if(o_xiangzhen!=undefined&&o_cun!=undefined)
    {
    	var ls_xzqh = o_xzqh.value; //行政区划
    	var ls_xz   = o_xiangzhen.value;   //镇
    	if (ls_xz == "") ls_xz = "000";
    	var ls_cun  = o_cun.value;       //村
    	if (ls_cun == "") ls_cun = "000";
    	o_sqdm.value = ls_xzqh + ls_xz + ls_cun; //社区代码
    }
    return true;
}
