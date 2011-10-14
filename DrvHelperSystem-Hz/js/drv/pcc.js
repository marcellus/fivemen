	   //获取外地的行政区划
	   function select_xzqh(spath,_prefix,localXzqh)
	   {
	        var spath="ajax.do?method=showPccMain";
	        
	        var o_select;	//下拉列表对象
	        var o_djzsxxdz;
	        var o_ly;
	        var o_ly_span;
	       
	        var a_result;	//返回值
	        if(_prefix=="ps_")
	        {
	        	o_select=document.all.ps_djzsxzqh;
	        	o_djzsxxdz=document.all.ps_djzsxxdz;
	        	o_ly=document.all.ec_ly;
	        	o_ly_span=document.all.span_ec_ly;
	        }
	        else if(_prefix=="tp_")
	        {
	           o_select=document.all.tp_djzsxzqh;
	           o_djzsxxdz=document.all.tp_djzsxxdz;
	           o_ly=document.all.tp_ly;	 
	           o_ly_span=document.all.span_tp_ly;
	        }
	        else if(_prefix=="li_")
	        {
	           o_select=document.all.li_djzsxzqh;
	           o_djzsxxdz=document.all.li_djzsxxdz;
	           o_ly=document.all.li_ly;
	           o_ly_span=document.all.span_li_ly;
	        }
	        else if(_prefix=="lo_")
	        {
	           o_select=document.all.lo_djzsxzqh;
	           o_djzsxxdz=document.all.lo_djzsxxdz;
	           o_ly=document.all.lo_ly;	   
	           o_ly_span=document.all.span_lo_ly;
	        }
	        else if(_prefix=="lt_")
	        {
	           o_select=document.all.lt_djzsxzqh;
	           o_djzsxxdz=document.all.lt_djzsxxdz;
	           o_ly=document.all.lt_ly;	 
	           o_ly_span=document.all.span_lt_ly;
	        }	        
	        if(o_select==undefined||o_djzsxxdz==undefined)
	        {
	            return false;
	        }
	        if(o_select.tagName!="SELECT")
	        {
	            return false;
	        }
  			var a_result=window.showModalDialog(spath,o_select.value,'dialogwidth:450px;dialogheight:300px;center:yes;resizable:yes'); 
  			var o_gnid=document.all["gnid"];
  			var gnid="";
  			if(o_gnid!=undefined)
  			{
  			    gnid=o_gnid.value;
  			}
 	       var o_auto=document.all["autoEquSfzmLx"];
	       var _auto="";
	       if(o_auto!=undefined)
	       {
	    	   _auto=o_auto.value;
	       }
	       
			if(a_result!=null)	//有返回值
			{
			    if(localXzqh.indexOf(a_result[1])>-1)
			    {
				    o_select.value=a_result[1];
				    if(_auto!="1")//非二代证信息
				    {
				    	o_djzsxxdz.value=a_result[0]+a_result[2];
				    }
				    if(o_ly!=undefined&&(gnid=="0101"||gnid=="0102"||gnid=="0103"))
				    {
				    	o_ly.value="A";
				    	if(o_ly.tagName!="SELECT")
				    	{
				    		o_ly_span.innerText="本地";
				    	}
				    }			    
			    }
			    else
			    {
					//如果下拉列表有内容，且最后一项已经是“外地”
					if(o_select.options.length!=0 && o_select.options(o_select.options.length-1).text=="外地")
					{
						o_select.options(o_select.options.length-1).value=a_result[1];	//修改下拉列表“外地”项目的value
					}
					else	//下拉列表没有内容，或者最后一项不是“外地”
					{
						o_select.options.add(new Option("外地",a_result[1]));	//直接新增“外地”项目
					}
                	o_select.selectedIndex=o_select.options.length-1;
                	if(_auto!="1")//非二代证信息
                	{
                		o_djzsxxdz.value=a_result[0]+a_result[2];
                	}
                	if(o_ly!=undefined&&(gnid=="0101"||gnid=="0102"||gnid=="0103"))
					{
						o_ly.value="B";
				    	if(o_ly.tagName!="SELECT")
				    	{
				    		o_ly_span.innerText="外地";
				    	}
					}
				}	
	   		}
	   	}
	   //设置准考编号	
	   function getZkzmbh(_prefix)
	   {	  
	       var o_zkzmbh;
	       if(_prefix=="ec_")
	       {
	          o_zkzmbh=document.all["ec_zkzmbh"];
	       }
	       else if(_prefix=="tp_")
	       {
	          o_zkzmbh=document.all["tp_zkzmbh"];
	       }
	       else if(_prefix=="li_")
	       {
	          o_zkzmbh=document.all["li_zkzmbh"];
	       }
	       else if(_prefix=="lo_")
	       {
	          o_zkzmbh=document.all["lo_zkzmbh"];
	       }
     	   o_zkzmbh.value=document.all["zkzmbh1"].value+document.all["zkzmbh2"].value;     	   	
   	   }
	   //设置档案编号	
	   function getDabh(_prefix)
	   {	  
	       var o_dabh;
	       if(_prefix=="ec_")
	       {
	    	   o_dabh=document.all["ec_dabh"];
	       }
	       else if(_prefix=="tp_")
	       {
	    	   o_dabh=document.all["tp_dabh"];
	       }
	       else if(_prefix=="li_")
	       {
	    	   o_dabh=document.all["li_dabh"];
	       }
	       else if(_prefix=="lo_")
	       {
	    	   o_dabh=document.all["lo_dabh"];
	       }
	       if(document.all["dabh2"].value==""){
	    	   o_dabh.value="";
	       }else{
	    	   o_dabh.value=document.all["dabh1"].value+document.all["dabh2"].value;  
	       }
   	   }	   	
	   function getXzqhDetail_lxzs(strxzqh,objName,_prefix,localXzqh,localXzqhDetail)
	   {
	       var i=0;
	       //获取行政区划信息
	       var DmzArrary=localXzqh.split(",");
	       var Dmsm2Arrary=localXzqhDetail.split(",");
	       var o_lxszxxdz;
	       var o_djzsxxdz;
	       var o_xzqh;
	       var o_auto=document.all["autoEquSfzmLx"];
	       var _auto="";
	       if(o_auto!=undefined)
	       {
	    	   _auto=o_auto.value;
	       }
	        if(_prefix=="ps_")
	        {
	            o_lxzsxxdz=document.all.ps_lxzsxxdz;
	            o_djzsxxdz=document.all.ps_djzsxxdz;
	            o_xzqh=document.all.ec_xzqh;
	        }
	        else if(_prefix=="tp_")
	        {
	           o_lxzsxxdz=document.all.tp_lxzsxxdz;
	           o_djzsxxdz=document.all.tp_djzsxxdz;
	           o_xzqh=document.all.tp_xzqh;
	        }
	        else if(_prefix=="li_")
	        {
	            o_lxzsxxdz=document.all.li_lxzsxxdz;
	            o_djzsxxdz=document.all.li_djzsxxdz;
	            o_xzqh=document.all.li_xzqh;
	        }
	        else if(_prefix=="lo_")
	        {
	            o_lxzsxxdz=document.all.lo_lxzsxxdz;
	            o_djzsxxdz=document.all.lo_djzsxxdz;
	            o_xzqh=document.all.lo_xzqh;
	        }	
	        else if(_prefix=="lt_")
	        {
	            o_lxzsxxdz=document.all.lt_lxzsxxdz;
	            o_djzsxxdz=document.all.lt_djzsxxdz;
	            o_xzqh=document.all.lt_xzqh;
	        }	                
	        var o_xiangzhen=document.all["xiangzhen"];
	        var o_cun=document.all["cun"];
	        //乡镇代码更新
	        if(o_xiangzhen!=undefined&&o_cun!=undefined)
	        {
	        	getZlist(strxzqh,_prefix);	
	        }
	        if(o_xzqh!=undefined)
	        {
	        	o_xzqh.value=strxzqh;
	        }
	        if(_auto!="1")//非二代证
	        {
	        	for (i=0;i<DmzArrary.length; i++)
	        	{
	        		if (DmzArrary[i]==strxzqh)
	        		{
	        			if(objName.indexOf("_lxzsxxdz")>-1)
	        			{
	        				o_lxzsxxdz.value=Dmsm2Arrary[i];
	        			}
	        			else if(objName.indexOf("_djzsxxdz")>-1)
	        			{
	        				o_djzsxxdz.value=Dmsm2Arrary[i];
	        			}
	        			return true;
	        		}
	        	}
	        }
	   }
	   function getXzqhDetail_djzs(strxzqh,objName,_prefix,localXzqh,localXzqhDetail)
	   {
	        var o_ly;
	        var o_ly_span;
	        if(_prefix=="ps_")
	        {
	            o_ly=document.all.ec_ly;
	            o_ly_span=document.all.span_ec_ly;
	        }
	        else if(_prefix=="tp_")
	        {
	           o_ly=document.all.tp_ly;
	           o_ly_span=document.all.span_tp_ly;
	        }
	        else if(_prefix=="li_")
	        {
	            o_ly=document.all.li_ly;
	            o_ly_span=document.all.span_li_ly;
	        }
	        else if(_prefix=="lo_")
	        {
	            o_ly=document.all.lo_ly;
	            o_ly_span=document.all.span_lo_ly;
	        }	        
			getXzqhDetail_lxzs(strxzqh,objName,_prefix,localXzqh,localXzqhDetail);
			
			var o_gnid=document.all["gnid"];
  			var gnid="";
  			if(o_gnid!=undefined)
  			{
  			    gnid=o_gnid.value;
  			}
  			if(o_ly!=undefined&&(gnid=="0101"||gnid=="0102"||gnid=="0103"))
  			{
				if(localXzqh.indexOf(strxzqh)==-1)
				{
			    	o_ly.value="B";
			    	if(o_ly.tagName!="SELECT")
			    	{
			    		o_ly_span.innerText="外地";
			    	}
				}
				else
				{
			    	o_ly.value="A";
			    	if(o_ly.tagName!="SELECT")
			    	{
			    		o_ly_span.innerText="本地";
			    	}
				}
				
			}
	   }
	   //获取镇列表 	  
	   function getZlist(strxzqh,_prefix)
	   { 
	        var o_sqdm;
	        if(_prefix=="ps_")
	        {
	            o_sqdm=document.all.ec_sqdm;
	        }
	        else if(_prefix=="tp_")
	        {
	           o_sqdm=document.all.tp_sqdm;
	        }
	        else if(_prefix=="li_")
	        {
	           o_sqdm=document.all.li_sqdm;
	        }
	        else if(_prefix=="lo_")
	        {
	           o_sqdm=document.all.lo_sqdm;
	        }	        
	        var zdm;
	        if (o_sqdm != null && o_sqdm.length == 12)
	        {
	            zdm = o_sqdm.substring(6,9);
	        }
	        else
	        {
	            zdm = "";
            }
            var spath="ajax.do?method=querySqdmList&type=1&xzqh="+ strxzqh+"&zdm="+zdm;
	        if(_prefix=="ps_"||_prefix=="_ec")
	        {
	           send_request(spath,"setSqxx1()",false); 
	        }
	        else if(_prefix=="tp_")
	        {
	           send_request(spath,"setSqxx2()",false); 
	        }
	        else if(_prefix=="li_")
	        {
	           send_request(spath,"setSqxx3()",false); 
	        }   
	        else if(_prefix=="lo_")
	        {
	           send_request(spath,"setSqxx4()",false); 
	        }                        
	   }
	   //获取村列表
	   function getClist(strxzqh, zdm,_prefix)
	   {
	        var spath="ajax.do?method=querySqdmList&type=2&xzqh="+ strxzqh+"&zdm="+zdm;
	        if(_prefix=="ps_"||_prefix=="_ec")
	        {
	           send_request(spath,"setSqxx1()",false); 
	        }
	        else if(_prefix=="tp_")
	        {
	           send_request(spath,"setSqxx2()",false); 
	        }
	        else if(_prefix=="li_")
	        {
	           send_request(spath,"setSqxx3()",false); 
	        }    
	        else if(_prefix=="lo_")
	        {
	           send_request(spath,"setSqxx4()",false); 
	        } 	        
	   }
	   
	   //获取社区代码
	   function setSqxx1()
	   {
	       set_sqxx(document.all.ec_sqdm);
	   }
	   function setSqxx2()
	   {
	       set_sqxx(document.all.tp_sqdm);
	   }
	   function setSqxx3()
	   {
	       set_sqxx(document.all.li_sqdm);
	   }
	   function setSqxx4()
	   {
	       set_sqxx(document.all.lo_sqdm);
	   }	   	   	   
	   function set_sqxx(o_sqdm)
	   {
	      	var sqdm=o_sqdm.value;
	        var xiangzhen=document.all["xiangzhen"];
	        var cun=document.all["cun"];	        
	        var xmlDoc = _xmlHttpRequestObj.responseXML;
    		var type=xmlDoc.getElementsByTagName("type")[0].firstChild.data;	
    		var cur;
    		if (type == '1')
    		{  
    		    //返回镇列表的信息
      			clearFieldOptions(xiangzhen);
      			var zlist = xmlDoc.getElementsByTagName("zlist");
      			for (var i=0; i< zlist.length; i++)
      			{
        			var z = zlist[i];  			
        			var zdm = z.getElementsByTagName("zdm")[0].firstChild.nodeValue;
        			var zmc = z.getElementsByTagName("zmc")[0].firstChild.nodeValue;
        			addcomboxitem(xiangzhen,zdm,zmc);
        			if (sqdm.length == 12 && sqdm.substring(6,9) == zdm)
        			{
          				xiangzhen.value=zdm;
        			}
      			}
      			//返回村代码
      			clearFieldOptions(cun);
        		var clist = xmlDoc.getElementsByTagName("clist");
        		for (var i=0; i< clist.length; i++)
        		{
          			var c = clist[i];
          			var cdm = c.getElementsByTagName("cdm")[0].firstChild.nodeValue;
          			var cmc = c.getElementsByTagName("cmc")[0].firstChild.nodeValue;
          			
        			addcomboxitem(cun,cdm,cmc);
        			if (sqdm.length == 12 && sqdm.substring(6,9) == zdm)
        			{
          				cun.value=cdm;
        			}
        		}
      		}
      		else if (type == '2')
      		{
      		    clearFieldOptions(cun);
        		var clist = xmlDoc.getElementsByTagName("clist");
        		for (var i=0; i< clist.length; i++)
        		{
          			var c = clist[i];
          			var cdm = c.getElementsByTagName("cdm")[0].firstChild.nodeValue;
          			var cmc = c.getElementsByTagName("cmc")[0].firstChild.nodeValue;
          			addcomboxitem(cun,cdm,cmc);
        		}
      		}
	   }
	   	
	   
	   
	   //根据gnid更新身份证明种类下拉框
	   function select_sfzmmc(gnid)
	   {
	        var spath="ajax.do?method=querySfzmmcList&gnid="+gnid;
	        send_request(spath,"selectSfzmmc()",false); 
	   }
	   function selectSfzmmc()
	   {
	        var xmlDoc = _xmlHttpRequestObj.responseXML;
	        var items=xmlDoc.getElementsByTagName("item");
            var o_sfzmmc= document.all["sfzmmc"];
            var gnid = xmlDoc.getElementsByTagName("gnid")[0].firstChild.data;
	        clearFieldOptions(o_sfzmmc);
	        for(var i=0;i<items.length;i++)
	        {
	        	var item=items[i];
	 			var dmz=item.getElementsByTagName("dmz")[0].firstChild.nodeValue;
	 			var dmsm1=item.getElementsByTagName("dmsm1")[0].firstChild.nodeValue;
	 			addcomboxitem(o_sfzmmc,dmz,dmz+":"+dmsm1);
  			}
  		    if(gnid=="0106")
	        {
	            o_sfzmmc.value="F";
	        }
	   }

	   
	  //境外换证设置是否免考
	   function  setSfmj()
	   {
		 /*
	   	 var o_gnid=document.all["gnid"];
	   	 var gnid="";
	   	 if(o_gnid!=undefined)
		 {
			    gnid=o_gnid.value;
		 }
	   	 if(gnid=="0106")//外籍
	   	 {
		   	 var o_gj=document.all["ps_gj"];
		   	 var mkgjxx=document.all["mkgjxx"].value;
		   	 if(mkgjxx.indexOf(o_gj.value)>=0)
		   	 {
	   		     document.all["ec_sfmk"].disabled=false;	
		   	 }
		   	 else
		   	 {
		   		document.all["ec_sfmk"].value="0";
		   		document.all["ec_sfmk"].disabled=true;
		   	 }
	   	 }
	   	 */
	   }
	   //设置体检医院名称
	   function change_tjyy()
	   {
			var currSelectIndex = document.all["ec_tjyydm"].selectedIndex;
			var strTjyymc=document.all.ec_tjyydm[currSelectIndex].text;
		    document.all["ec_tjyymc"].value=strTjyymc;
	   }	 
	   //设置注销恢复原因
	   function change_zxhfyy()
	   {
			var currSelectIndex = document.all["selobj"].selectedIndex;
			var strYwyy=document.all.selobj[currSelectIndex].text;
		    document.all["lo_bz"].value=strYwyy;
	   }
	   //设置体检信息为不可编辑或可编辑
	   function change_tjxx()
	   {
		   var o_sftj=document.all["ec_sftj"];
		   o_sftj.value="1";
		   var o_sftj_ck=document.all["ck_sftj"];
		   
		   if(o_sftj_ck.checked)
		   {
			   o_sftj.value="1";
			   document.all["ec_sg"].disabled=false;
			   document.all["ec_zsl"].disabled=false;
			   document.all["ec_ysl"].disabled=false;
			   document.all["ec_bsl"].disabled=false;
			   document.all["ec_tl"].disabled=false;
			   document.all["ec_sz"].disabled=false;
			   document.all["ec_zxz"].disabled=false;
			   document.all["ec_yxz"].disabled=false;
			   document.all["ec_qgjb"].disabled=false;
			   document.all["ec_tjyydm"].disabled=false;
			   document.all["ec_tjyymc"].disabled=false;
			   document.all["ec_tjrq"].disabled=false;
		   }
		   else
		   {
			   o_sftj.value="0";
			   document.all["ec_sg"].disabled=true;
			   document.all["ec_zsl"].disabled=true;
			   document.all["ec_ysl"].disabled=true;
			   document.all["ec_bsl"].disabled=true;
			   document.all["ec_tl"].disabled=true;
			   document.all["ec_sz"].disabled=true;
			   document.all["ec_zxz"].disabled=true;
			   document.all["ec_yxz"].disabled=true;
			   document.all["ec_qgjb"].disabled=true;			   
			   document.all["ec_tjyydm"].disabled=true;
			   document.all["ec_tjyymc"].disabled=true;
			   document.all["ec_tjrq"].disabled=true;			   
		   }
	   }
	   //设置是否免考
	   function change_sfmk()
	   {
		   var o_sfmk=document.all["ec_sfmk"];
		   o_sfmk.value="0";
		   var o_sfmk_ck=document.all["ck_sfmk"];
		   if(o_sfmk_ck.checked)
		   {
			   o_sfmk.value="1";
		   }
		   else
		   {
			   o_sfmk.value="0";
		   }
		   
	   }
	   //设置期满换证checkbox
	   function change_qmhz()
	   {
		   var o_sftj=document.all["ec_sftj"];
		   o_sftj.value="A";
		   var o_sftj_ck=document.all["ck_sftj"];
		   if(o_sftj_ck.checked)
		   {
			   document.all["ec_sg"].disabled=false;
			   document.all["ec_zsl"].disabled=false;
			   document.all["ec_ysl"].disabled=false;
			   document.all["ec_bsl"].disabled=false;
			   document.all["ec_tl"].disabled=false;
			   document.all["ec_sz"].disabled=false;
			   document.all["ec_zxz"].disabled=false;
			   document.all["ec_yxz"].disabled=false;
			   document.all["ec_qgjb"].disabled=false;
			   document.all["ec_tjyydm"].disabled=false;
			   document.all["ec_tjyymc"].disabled=false;
			   document.all["ec_tjrq"].disabled=false;			   
			   o_sftj.value="A";
		   }
		   else
		   {
			   document.all["ec_sg"].disabled=true;
			   document.all["ec_zsl"].disabled=true;
			   document.all["ec_ysl"].disabled=true;
			   document.all["ec_bsl"].disabled=true;
			   document.all["ec_tl"].disabled=true;
			   document.all["ec_sz"].disabled=true;
			   document.all["ec_zxz"].disabled=true;
			   document.all["ec_yxz"].disabled=true;
			   document.all["ec_qgjb"].disabled=true;			   
			   document.all["ec_tjyydm"].disabled=true;
			   document.all["ec_tjyymc"].disabled=true;
			   document.all["ec_tjrq"].disabled=true;				   
			   o_sftj.value="B";
		   }
	   }
	   //补证换证业务中变更身份证明号码自动刷新出生日期和性别
	   function changeSfzmhm(_prefix)
	   {
		   var o_sfzmmc;
		   var o_sfzmhm;
		   var o_xb;
		   var o_csrq;
		   var o_xb_span;
		   var o_csrq_span;
		   if(_prefix=="ps_")
		   {
		        o_sfzmmc=document.all["ps_sfzmmc"];
		        o_sfzmhm=document.all["ps_sfzmhm"];
		        o_xb=document.all["ps_xb"];
		        o_xb_span=document.all["span_ps_xb"];
		        o_csrq=document.all["ps_csrq"];
		        o_csrq_span=document.all["span_ps_csrq"];
		   }
		   else if(_prefix=="tp_")
		   {
		        o_sfzmmc=document.all["tp_sfzmmc"];
		        o_sfzmhm=document.all["tp_sfzmhm"];
		        o_xb=document.all["tp_xb"];
		        o_xb_span=document.all["span_tp_xb"];
		        o_csrq=document.all["tp_csrq"];
		        o_csrq_span=document.all["span_tp_csrq"];   
		   }     
		   else if(_prefix=="li_")
		   {
		        o_sfzmmc=document.all["li_sfzmmc"];
		        o_sfzmhm=document.all["li_sfzmhm"];
		        o_xb=document.all["li_xb"];
		        o_xb_span=document.all["span_li_xb"];
		        o_csrq=document.all["li_csrq"];
		        o_csrq_span=document.all["span_li_csrq"];        
		     }
		     else if(_prefix=="lo_")
		     {
			    o_sfzmmc=document.all["lo_sfzmmc"];
			    o_sfzmhm=document.all["lo_sfzmhm"];
			    o_xb=document.all["lo_xb"];
			    o_xb_span=document.all["span_lo_xb"];
			    o_csrq=document.all["lo_csrq"];
			    o_csrq_span=document.all["span_lo_csrq"];             
		     } 
		   var sfzmmc=o_sfzmmc.value;
		   if(sfzmmc=="A")
		   {
		    	 sfzmhm=o_sfzmhm.value;
		    	 var xb=getxbbysfzmhm(sfzmhm);
		    	 var xb_mc="";
		    	 if(xb=="1")
		    	 {
		    		 xb_mc="男"
		    	 }
		    	 else if(xb=="2")
		    	 {
		    		 xb_mc="女";
		    	 }
		    	 else
		    	 {
		    		 xb_mc="--";
		    	 }
		    	 var csrq=getcsrqbysfzmhm(sfzmhm);
		    	 if(o_xb!=undefined)
		    	 {
		    		 o_xb.value=xb;
		    	 }
		    	 if(o_xb_span!=undefined)
		    	 {
		    		 o_xb_span.innerText=xb_mc;
		    	 }
		    	 if(o_csrq!=undefined)
		    	 {
		    		 o_csrq.value=csrq;
		    	 }	
		    	 if(o_csrq_span!=undefined)
		    	 {
		    		 o_csrq_span.innerText=csrq;
		    	 }		    	 
		     }		   
	   }
	   
	   
       function initXzdm(_prefix)
       {
                var o_xzqh;	        
                       if(_prefix=="ps_")
       	        {
       	            o_xzqh=document.all.ec_xzqh;
       	        }
       	        else if(_prefix=="tp_")
       	        {
       	           o_xzqh=document.all.tp_xzqh;
       	        }
       	        else if(_prefix=="li_")
       	        {
       	            o_xzqh=document.all.li_xzqh;
       	        }
       	        else if(_prefix=="lo_")
       	        {
       	            o_xzqh=document.all.lo_xzqh;
       	        }	
       	        else if(_prefix=="lt_")
       	        {
       	            o_xzqh=document.all.lt_xzqh;
       	        }
       	        var o_xiangzhen=document.all["xiangzhen"];
       	        var o_cun=document.all["cun"];
       	        //乡镇代码更新
       	        if(o_xiangzhen!=undefined&&o_cun!=undefined)
       	        {
       	        	var strxzqh=o_xzqh.value;
       	        	getZlist(strxzqh,_prefix);	
       	        }
       }	   