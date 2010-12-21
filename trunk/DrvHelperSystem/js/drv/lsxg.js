 
  function resultLsxg(strResult,strMessage,strLsh) {
     var o_sqbBtn=document.all["sqbbutton"];
     var o_slpzBtn=document.all["slpzbutton"];
     if(strResult=="1") 
	   {
	      document.formedit.lsh.value=strLsh;
	      if(o_sqbBtn!=undefined)
	      {
	      	 o_sqbBtn.disabled=false;
	      }
	      if(o_slpzBtn!=undefined)
	      {
	      	o_slpzBtn.disabled=false;
	      }
	      alert(strMessage); 
	      parent.clearQueryConditon();
        }
        else
        {
           alert(strMessage);
           document.all["save_data_button"].disabled=false;
        }
  }	
 
//打印准考证明
 function lsxg_print_zkzm(){
	 var prefix =document.all["prefix"].value;
 	 var lsh=document.all["lsh"].value;
 	 var sfzmhm=document.all[prefix+"sfzmhm"].value;
 	 var xmlUrl="byte.do?method=showPicByXml&sfzmhm="+sfzmhm;
 	 print_zkzmdddd(lsh,xmlUrl);
        
 } 