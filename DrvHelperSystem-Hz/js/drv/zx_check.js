function do_change_zxyy() {
var zxyy=document.all["lm_zxyy"].value;
	if(zxyy=="G"){
	    document.all["lm_xznx"].value="2";
		document.all["dx1"].checked=true;
	    dx.style.display="";
	}else{
	    dx.style.display="none";
	}
    if(zxyy=="G"||zxyy=="H"){
    	  if (document.all["lm_sxrq"].value.length==0)
    	  {
    	     document.all["lm_sxrq"].value=sysnowdate;
    	  }
    	  if(newisDate("��Ч����",document.all["lm_sxrq"].value)==0 ){
    	     document.all["sxrq"].focus();
    	     return false;
    	  }else{
    		 str1=changeDate(document.all["lm_sxrq"].value);
    	  }
    	  if(cal_days(document.all["lm_sxrq"].value,"")<0 ){ 
    		alert("'��Ч����'��Ӧ���ڽ��죡");
    	    document.all["sxrq"].focus;
    	    return false;
    	   }
    	   if(zxyy=="H"){
    		   document.all["lm_xznx"].value="3";
    	       document.all["lm_sxrq"].value=str1;
    	   }
    	    if(zxyy=="G" || zxyy=="H"){
    	       document.all["lm_xzqz"].value=rqaddyears(str1,parseInt(document.all["lm_xznx"].value));
    	       cEditable(document.all["lm_cjwsbh"]);
    	       cEditable(document.all["lm_sxrq"]);
    	       document.all["lm_pro"].style.display="";
    	       document.all["lm_city"].style.display="";
    	       document.all["lm_pro"].disabled=false; //this line add by whb
    	       document.all["lm_city"].disabled=false; //this line add by whb
    	    }
    }else{
    	 cReadonly(document.all["lm_cjwsbh"])
    	 cReadonly(document.all["lm_sxrq"])

    	 document.all["lm_pro"].disabled=true; //this line add by whb
    	 document.all["lm_city"].disabled=true; //this line add by whb
    	 document.all["lm_pro"].style.display="none";
    	 document.all["lm_city"].style.display="none";
    	 document.all["lm_cjwsbh"].value="";
    	 document.all["lm_xznx"].value="";
    	 document.all["lm_xzqz"].value="";
    	 document.all["lm_sxrq"].value="";
    }
}

function clickdx()
{
  if (document.all["dx1"].checked==true){
    document.all["lm_xznx"].value="2"
  }else{
    document.all["lm_xznx"].value="60"
  }
  if (document.all["lm_sxrq"].value.length==0)
  {
   document.all["lm_sxrq"].value=sysnowdate;
  }
  document.all["lm_xzqz"].value=rqaddyears(document.all["lm_sxrq"].value,parseInt(document.all["lm_xznx"].value));
}

//--------------------�ı���Ч����ʱ��Ӧ�ı�-----------------------
function changesxrq() {

 var str1="";
    var zxyy=document.all["lm_zxyy"].value;
    if (zxyy=="G" || zxyy=="H"){
    if (document.all["lm_sxrq"].value.length==0)
    {
     document.all["lm_sxrq"].value=sysnowdate;
    }

    if(newisDate("��Ч����",document.all["lm_sxrq"].value)==0 ){
    	document.all["lm_sxrq"].focus(); 
    	return false;
    }
    else{str1=changeDate(document.all["lm_sxrq"].value);}
    if(cal_days(document.all["lm_sxrq"].value,"")<0 )
   { alert("'��Ч����'��Ӧ���ڽ��죡");
     document.all["lm_sxrq"].focus();
     return false;
   }

    if (zxyy=="G" || zxyy=="H"){
       document.all["lm_xzqz"].value=rqaddyears(str1,parseInt(document.all["lm_xznx"].value));
    }
    }
}

//��ʻ֤ע��ҵ��ʱ��⺯��
function check_jzzx()  //����ǰ����У��
{
         var zxyy=document.all["lm_zxyy"].value;
         if(zxyy==""){
           alert("ע��ԭ��δѡ��");
           return false;}

if (zxyy=="G" ||zxyy=="H")
{
 //do_change();
         if (zxyy=="G") {  document.all["xzyy"].value=="C";} //����ԭ��
         if (zxyy=="H") {  document.all["xzyy"].value=="E";} //����ԭ��
         if (checkNull(document.all["lm_cjwsbh"],"�þ������")==0 )   {document.all["lm_cjwsbh"].focus(); return false;  }
         if (zxyy=="H")
         {document.all["lm_xznx"].value="3";
         }
          if(newisDate("������ֹ",document.all["lm_xzqz"].value)==0 )
           {
            return false;
            }
           else
          {document.all["lm_xzqz"].value=changeDate(document.all["lm_xzqz"].value);
          }
          
          if(cal_days(document.all["lm_xzqz"].value,"")>0 )
           { alert("'������ֹ'��Ӧ���ڽ��죡");
             document.all["sxrq"].focus();
            return false;}

          if(newisDate("��Ч����",document.all["lm_sxrq"].value)==0 )
           {
             document.all["lm_sxrq"].focus();
            return false;
            }
           else
          {
          document.all["lm_sxrq"].value=changeDate(document.all["lm_sxrq"].value);
          }
          if(cal_days(document.all["lm_sxrq"].value,"")<0 )
           { alert("'��Ч����'��Ӧ���ڽ��죡");
             document.all["lm_sxrq"].focus();
            return false;
            }
         if (document.all.lm_xzqz.value.substr(4,6)!=document.all.lm_sxrq.value.substr(4,6))
             {
             alert("'��Ч����'��'������ֹ'���ղ�����");
             document.all["sxrq"].focus();
             return false;
             }

         if (document.all.lm_xzqz.value.substr(0,4).valueOf()-document.all.lm_sxrq.value.substr(0,4).valueOf() != document.all["lm_xznx"].value.valueOf())
             {
             alert("'��������'��'��Ч����'��'������ֹ'���������");
             document.all["lm_sxrq"].focus();
             return false;
             }
}
if (checkNull(document.all["lm_bz"],"��ע")==0){document.all["lm_bz"].focus();return false;}
   return true;
}

//��ʻ֤ע��ҵ��ʱ��⺯��
function check_kz()
{
  if(checkNull(document.all["lm_cjwsbh"],"�þ�����")==0 )
  { document.all["lm_cjwsbh"].focus() ;return false;}
  if(newisDate("�ݿ�����",document.all["lm_zkrq"].value)==0 ){
	  document.all["lm_zkrq"].focus(); return false;}
  else{
	  document.all["lm_zkrq"].value=changeDate(document.all["lm_zkrq"].value);
  }
  if(checkNull(document.all["lm_zkqx"],"�ݿ�����")==0 )
  { document.all["lm_zkqx"].focus() ;return false;}
  if(checknum(document.all["lm_zkqx"],"�ݿ�����",true)!="1")
  {return false;}
  if(parseInt(document.all.zkqx.value)<=0){
	  alert("'�ݿ�����'Ӧ�ô���0 ��");
      document.all["lm_zkqx"].value = "";
      document.all["lm_zkqx"].focus();
      return false;
  }

  if(checkNull(document.all["lm_zkjbr"],"�ݿ۾�����")==0)
  {document.all["lm_zkjbr"].focus(); return false;}
  if(cal_days(document.all["lm_zkrq"].value,"")<0 )
   {alert("'�ݿ�����'��Ӧ���ڽ��죡");
    return false;}
  if(DateAddMonth(document.all["lm_zkrq"].value,document.all.zkqx.value)<=sysnowdate){
	  alert("'�ݿ�����'+����Ӧ���ڽ���֮��");
	  return false;
  }
 return true;
}
