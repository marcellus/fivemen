
//��ȡ���׼�ݳ���
function getBigZjcx(ycx) {
	    if (ycx.indexOf("A1") >= 0) {
	      return "A1";
	    }
	    if (ycx.indexOf("A2") >= 0) {
	      return "A2";
	    }
	    if (ycx.indexOf("A3") >= 0) {
	      return "A3";
	    }
	    if (ycx.indexOf("B1") >= 0) {
	      return "B1";
	    }
	    if (ycx.indexOf("B2") >= 0) {
	      return "B2";
	    }
	    if (ycx.indexOf("C1") >= 0) {
	      return "C1";
	    }
	    if (ycx.indexOf("C2") >= 0) {
	      return "C2";
	    }
	    if (ycx.indexOf("C3") >= 0) {
	      return "C3";
	    }
	    if (ycx.indexOf("C4") >= 0) {
	      return "C4";
	    }
	    if (ycx.indexOf("C5") >= 0) {
		      return "C5";
		}
	    if (ycx.indexOf("D") >= 0) {
	      return "D";
	    }
	    if (ycx.indexOf("E") >= 0) {
	      return "E";
	    }
	    if (ycx.indexOf("F") >= 0) {
	      return "F";
	    }
	    if (ycx.indexOf("M") >= 0) {
	      return "M";
	    }
	    if (ycx.indexOf("N") >= 0) {
	      return "N";
	    }
	    if (ycx.indexOf("P") >= 0) {
	      return "P";
	    }
	    return "";
}
  
//�೵��ʱ���ص�һ������
function first_zjcx(yzjcx)
{
   var zjcx=yzjcx;
   if (yzjcx.length>1)
   { 
      var str_2=yzjcx.substr(1,1);
      zjcx=yzjcx.substr(0,1);
      if (str_2=="1" || str_2=="2" || str_2=="3" || str_2=="4" || str_2=="5" )
      { 
         zjcx=zjcx+str_2;
      }
   }
   return zjcx;
}
//-------------------------------
//  ��������yzjcx_sqcx(yzjcx,sqcx)
//  ���ܽ��ܣ����복���Ƿ�ԭ���Ͱ���
//  ����˵����ԭ���ͣ����복��
//  ����ֵ  ��1-������0-������
//-------------------------------

function yzjcx_sqcx(yzjcx,sqcx)
{
  	var a_temp=new Array();
    //���ʹ����
	var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","C5","D","E","F","M","N","P");
    //���Ͱ����б�
	var a_bhcx=new Array(
		new Array("A1","A3","B1","B2","C1","C2","C3","C4","M"),
		new Array("A2","B1","B2","C1","C2","C3","C4","M"),
		new Array("A3","C1","C2","C3","C4"),
		new Array("B1","C1","C2","C3","C4","M"),
		new Array("B2","C1","C2","C3","C4","M"),
		new Array("C1","C2","C3","C4"),
		new Array("C2"),
		new Array("C3","C4"),
		new Array("C4"),
		new Array("C5"),
		new Array("D","E","F"),
		new Array("E","F"),
		new Array("F"),
		new Array("M"),
		new Array("N"),
		new Array("P")
    );
	var i;	//������

  	if(yzjcx==null || sqcx==null)
        	return 0;

	//�����Ƿ�ֱ�ӱ�����
    if(yzjcx.indexOf(sqcx)!=-1)
        	return 1;

	//û��ֱ�Ӱ���
	//��ԭ׼�ݳ����ַ�����չΪ
	for(i in s_cx_dm)
	{
		if(yzjcx.indexOf(s_cx_dm[i])!=-1)
		{
	          a_temp=a_temp.concat(a_bhcx[i]);
		}
	}
	return checkZjcxInList(sqcx,a_temp);
}

//-------------------------------
//������  ��checkZjcxInList(s_value��s_cx_dm)
//�ж�׼�ݳ����Ƿ����б���
//-------------------------------
function checkZjcxInList(s_value,s_cx_dm)
{
		//�Ϸ���׼�ݳ����ַ�������
	//var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P");
	//�ַ�������ĳ���
	var s_cx_input;	//�����Ҫ������ַ���
	var i_pos;	//�����Ӵ���λ
	var i;
	s_cx_input=s_value;
	for(i in s_cx_dm)	//�ԺϷ�׼�ݳ����ַ���������ѭ
	{
		do
		{
			i_pos=s_cx_input.indexOf(s_cx_dm[i]);	//�Ƿ������ǰ����
			if(i_pos!=-1)	//����
			{
	             //ȥ���ҵ����Ӵ�
				s_cx_input=s_cx_input.slice(0,i_pos)+s_cx_input.slice(i_pos+s_cx_dm[i].length);
			}
		}
		while(i_pos!=-1);	//�Ҳ�����ǰ�����Ӵ���������һ�����Ӵ�����
	}
	if(s_cx_input.length==0)
	{
		//�����ַ��������Ķ��ǺϷ��ĳ����Ӵ���ȫ����ȥ���ˣ�
		return 1;
	}
	else
	{
		return 0;
	}
}

//-------------------------------
//  ������  ��check_zjcx(s_value��s_cx_dm)
//  ����˵����׼�ݳ����ַ������Ϸ���׼�ݳ����ַ������顣
//  ���ܽ��ܣ���鳵�������Ƿ���ȷ��ֻ����Ƿ�����Ϸ���׼�ݳ����ַ������ظ�������ߵ�����Ϊ�Ǵ���
//  ����ֵ  ��1-�����Ϸ���׼�ݳ��У�0-���Ϸ�
//
//  ���� 2004.05.12
//-------------------------------
function check_zjcx(s_value,s_cx_dm)
{
  	//�Ϸ���׼�ݳ����ַ�������
	//var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P");
    //�ַ�������ĳ���
    var s_cx_input;	//�����Ҫ������ַ���
	var i_pos;	//�����Ӵ���λ
    var i;
    s_cx_input=s_value;
	for(i in s_cx_dm)	//�ԺϷ�׼�ݳ����ַ���������ѭ
	{
		do
		{
			i_pos=s_cx_input.indexOf(s_cx_dm[i]);	//�Ƿ������ǰ����
			if(i_pos!=-1)	//����
			{
                 //ȥ���ҵ����Ӵ�
				s_cx_input=s_cx_input.slice(0,i_pos)+s_cx_input.slice(i_pos+s_cx_dm[i].length);
			}
		}
		while(i_pos!=-1);	//�Ҳ�����ǰ�����Ӵ���������һ�����Ӵ�����
	}
	if(s_cx_input.length==0)
	{
		//�����ַ��������Ķ��ǺϷ��ĳ����Ӵ���ȫ����ȥ���ˣ�
		return 1;
    }
	else
	{
		//�����ַ����������зǷ����ַ���
		alert("���복�Ͳ����Ϲ淶Ҫ��");
		return 0;
    }
}

//-------------------------------
//  ������  ��check_sg(i_value)
//  ����˵������ߡ�
//  ���ܽ��ܣ��������Ƿ�Ϊ���֣��Ƿ�>=100,<=250
//  ����ֵ  ��1-�ǣ�0-����
//-------------------------------

function check_sg(i_value)
{
    if(isNum("���",i_value)==0)  //�������Ƿ�Ϊ����
    {
        return 0;
    }
    else
    {
	    if ((i_value-0)<100 ||(i_value-0)>250)
	    {
	        alert("'���'����ΧӦ�� 100--250 ��");
	        document.all["ec_sg"].focus();
            return 0;
	    }
    }
    return 1;
}

//-------------------------------
//  ��������isHg(bsl,tl,sz,qgjb,yxz)
//  ���ܽ��ܣ���ɫ��,����,��֫,���ɾ����Ƿ�ϸ�
//  ����˵������ɫ��,����,��֫,���ɾ���
//  ����ֵ  ��1-��������,0-������
//-------------------------------

function isHg(bsl,tl,sz,qgjb,yxz)
{
    if (!(bsl==1))
    {
       alert("'��ɫ��'���ϸ��߲������룡");
       return 0;
    }
    if (!(tl==1))
    {
       	alert("'����'���ϸ��߲������룡");
        return 0;
    }
    if (!(sz==1))
    {
       	alert("'��֫'���ϸ��߲������룡");
        return 0;
    }
    if (!(qgjb==1))
    {
       	alert("'���ɾ���'���ϸ��߲������룡");
        return 0;
    }
    return 1;
}
//-------------------------------
//  ��������zjcx_zxz(sqcx,zxz)
//  ���ܽ��ܣ�����֫�Ƿ�������복��Ҫ��
//  ����˵�������복�ͣ�����֫
//  ����ֵ  ��1-����,0-������
//-------------------------------

function zjcx_zxz(sqcx,zxz)
{
   if (zxz==1){return 1;}
   if (sqcx=="C2" )
    {
    	return 1;
    }
   else
   {
    alert("'����֫'���ϸ���ֻ������'C2-�Զ�������'��");
    return 0;
   }
}

//-------------------------------
//��������jscx_nl(sqcx,csrq)
//���ܽ��ܣ����������Ƿ���ϼ�ʻ�ó���Ҫ��
//����˵�������복�ͣ���������
//����ֵ  ��1-����,0-������
//Jamse 2010-01-30�޸ļ�ʻ�������ƣ�60�������ϰ���60��������
//todo����cal_years����
//-------------------------------

function jscx_nl(sqcx,csrq)
{ 
	//alert("csrq:"+csrq+" sqcx:"+sqcx);
	sqcx=first_zjcx(sqcx);
	
	var nl;
	nl=cal_years(csrq);//������
	if (sqcx=="C1" ||sqcx=="C2" || sqcx=="C5" ||sqcx=="F" ) //1	
	{
		if (nl-0<18)
		{
			alert("��ʻ��׼�ݳ�������Ҫ�� 18���� ,��ǰ "+nl+" �꣡");
			return 0;
		}
	}
	if (sqcx=="C3" ||sqcx=="C4" ||sqcx=="D" ||sqcx=="E"||sqcx=="M") //2
	{
		if (nl-0<18 || nl>=70)
		{
			alert("��ʻ��׼�ݳ�������Ҫ�� 18--70 ,��ǰ "+nl+" ��");
			return 0;
		}
	}
	if (sqcx=="B1" ||sqcx=="B2" ||sqcx=="A3" ||sqcx=="N"||sqcx=="P") //3
	{
		if (nl-0<21 || nl>=60)
		{
			alert("��ʻ��׼�ݳ�������Ҫ�� 21--60 ,��ǰ "+nl+" ��");
			return 0;
		}
	}
	if (sqcx=="A2" ) //4
	{
		if (nl-0<24 || nl>=60)
		{
			alert("��ʻ��׼�ݳ�������Ҫ�� 24--60 ,��ǰ "+nl+" ��");
			return 0;
		}
	}
	if (sqcx=="A1" ) //5
	{
		if (nl-0<26 || nl>=60)
		{
			alert("��ʻ��׼�ݳ�������Ҫ�� 26--60 ,��ǰ "+nl+" ��");
			return 0;
		}
	}
	return 1;
}


//-------------------------------
//  ��������zjcx_sg(sqcx,sg)
//  ���ܽ��ܣ�����Ƿ�������복��Ҫ��
//  ����˵�������복�ͣ����
//  ����ֵ  ��1-����,0-������
//-------------------------------

function zjcx_sg(sqcx,sg)
{  
    sqcx=first_zjcx(sqcx);
    if (check_sg(sg)==0) //����߷�Χ���
    {
  		return 0;
 	}
 	if (sqcx=="A1" ||sqcx=="A2" ||sqcx=="A3" ||sqcx=="B2"||sqcx=="N")
 	{
 		if (sg-0<155)
 		{
          	alert("������������ʻ֤�����ʹ�ù涨��(������91����)��ʮһ���ڣ�������涨�����복��"+sqcx+"ʱ��߱�����155cm���ϣ�");
         	return 0;
        }
 	}
 	if (sqcx=="B1" )
 	{
 		if (sg-0<150)
 		{
          	alert("������������ʻ֤�����ʹ�ù涨��(������91����)��ʮһ���ڣ�������涨�����복��"+sqcx+"ʱ��߱�����150cm���ϣ�");
           	return 0;
        }
 	}
 	return 1;
}

//-------------------------------
//  ������  ��h(i_value)
//  ����˵����������
//  ���ܽ��ܣ���������Ƿ�Ϊ���֣��Ƿ�>=4.9,<=5.5
//  ����ֵ  ��1-�ǣ�false-����
//-------------------------------

function check_sl(i_value)
{
    var reg = /^(\d{1,1})(\.)(\d{1,1})$/;
    var vSl=i_value;
    var r = vSl.match(reg);
    if(r==null)
    {
         alert("�����ĸ�ʽӦΪ��x.x ��")
         return 0;
    }

    if ((vSl-0)<4.9 || (vSl-0)>5.5)
    {
         alert("'����'Ӧ�� 4.9--5.5 ��Χ��");
         return 0;
    }

 	return 1;
}


//-------------------------------
//  ��������zjcx_sl(sqcx,zsl,ysl)
//  ���ܽ��ܣ������Ƿ�������복��Ҫ��
//  ����˵�������복�ͣ���������������
//  ����ֵ  ��1-����,0-������
//  ����by���� 2004-08-06
//-------------------------------

function zjcx_sl(sqcx,zsl,ysl)
{ 
 	sqcx=first_zjcx(sqcx);
	if (zsl.length==2)
 	{ 
 		zsl = zsl.substr(0,1)+"."+zsl.substr(1,1);
 		document.all["ec_zsl"].value=zsl;
 	}
	else if(zsl.length==1)
	{
		zsl=zsl+".0";
		document.all["ec_zsl"].value=zsl;
	}
 	if (ysl.length==2)
 	{
 		ysl= ysl.substr(0,1)+"."+ysl.substr(1,1);
  		document.all["ec_ysl"].value=ysl;
 	}
 	else if(ysl.length==1)
 	{
 		ysl=ysl+".0";
 		document.all["ec_ysl"].value=ysl;
 	}
  	if (check_sl(zsl)==0) //��������Χ���
 	{
        document.all["ec_zsl"].focus();
  		return 0;
 	}
  	if (check_sl(ysl)==0) //��������Χ���
 	{
   		document.all["ec_ysl"].focus();
   		return 0;
 	}
	/* 
	if (sqcx=="A1" ||sqcx=="A2" ||sqcx=="A3" ||sqcx=="B1"||sqcx=="B2" ||sqcx=="N"||sqcx=="P")
 	{
 		if (zsl-0<5.0)
 		{
        	alert("������������ʻ֤�����ʹ�ù涨��(������91����)��ʮһ���ڣ�������涨�����복��"+sqcx+"ʱ����Ҫ����5.0���ϣ�");
          	document.all["ec_zsl"].focus();
         	return 0;
        }
        if (ysl-0<5.0)
 		{
          	alert("������������ʻ֤�����ʹ�ù涨��(������91����)��ʮһ���ڣ�������涨�����복��"+sqcx+"ʱ����Ҫ����5.0���ϣ�");
          	document.all["ec_ysl"].focus();
         	return 0;
        }
 	}
 	*/
  	return 1;
}

//-------------------------------
//  ��������zjcx_sl(sqcx,zsl,ysl)
//  ���ܽ��ܣ������Ƿ�������복��Ҫ��
//  ����˵�������복�ͣ���������������
//  ����ֵ  ��1-����,0-������
//  ����by���� 2004-08-06
//-------------------------------
function zjcx_tjyy(sqcx,tjyy)
{
    return "1";
}

//-------------------------------
//  ��������zjcx_nl(sqcx,csrq)
//  ���ܽ��ܣ����������Ƿ�������복��Ҫ��
//  ����˵�������복�ͣ���������
//  ����ֵ  ��1-����,0-������
//-------------------------------

function zjcx_nl(sqcx,csrq)
{
	var nl;
	sqcx=first_zjcx(sqcx)
	
	
	nl=cal_years(csrq);//������
 	if (sqcx=="C1" ||sqcx=="C2" ||sqcx=="C5" ||sqcx=="F" ) //1
 	{
 		if (nl-0<18 || nl>70)
 		{
          	alert("������������ʻ֤�����ʹ�ù涨��(������111����)��ʮһ���ڣ�һ����涨�����복��"+sqcx+"ʱ���������18�������ϣ�70�������� ,��ǰ "+nl+" �꣡");
        	return 0;
        }
 	}
 	if (sqcx=="C3" ||sqcx=="C4" ||sqcx=="D" ||sqcx=="E"||sqcx=="M") //2
 	{
 		if (nl-0<18 || nl>60)
 		{
         	alert("������������ʻ֤�����ʹ�ù涨��(������111����)��ʮһ���ڣ�һ����涨�����복��"+sqcx+"ʱ���������18�������ϣ�60�������� ,��ǰ "+nl+" �꣡");
         	return 0;
        }
 	}
 	if (sqcx=="B1" ||sqcx=="B2" ||sqcx=="A3" ||sqcx=="N"||sqcx=="P") //3
 	{
 		if (nl-0<21 || nl>50)
 		{
        	alert("������������ʻ֤�����ʹ�ù涨��(������111����)��ʮһ���ڣ�һ����涨�����복��"+sqcx+"ʱ���������21�������ϣ�50�������� ,��ǰ "+nl+" �꣡");
        	return 0;
        }
 	}
 	if (sqcx=="A2" ) //4
 	{
 		if (nl-0<24 || nl>50)
 		{
            alert("������������ʻ֤�����ʹ�ù涨��(������111����)��ʮһ���ڣ�һ����涨�����복��"+sqcx+"ʱ���������24�������ϣ�50�������� ,��ǰ "+nl+" �꣡");
          	return 0;
        }
 	}
 	if (sqcx=="A1" ) //5
 	{
 		if (nl-0<26 || nl>50)
 		{
           alert("������������ʻ֤�����ʹ�ù涨��(������111����)��ʮһ���ڣ�һ����涨�����복��"+sqcx+"ʱ���������26�������ϣ�50�������� ,��ǰ "+nl+" �꣡");
           return 0;
        }
 	}
	return 1;
}

//-------------------------------
//  ��������check_sqcx(sqcx,xyly)
//  ���ܽ��ܣ�����ҵ�񣬶����복�͵����ƣ���13����
//  ����˵�������복�ͣ�ѧԱ��Դ
//  ����ֵ  ��1-�����룬0-��������
//-------------------------------

function check_sqcx(sqcx,xyly)
{
 
    if (yzjcx_sqcx("A1A2A3B1B2C1C2C3C4C5DEFMNP",sqcx)==0)
    {
		alert("���복���к��Ƿ��ַ���");
		return 0;
	}
	sqcx=first_zjcx(sqcx);
	var s_cx_dm=new Array;	//��������ĳ����ַ�������
	if(sqcx==null || xyly==null)
	{
	    alert("���복�ͺͼ�ʻ����Դ����Ϊ�գ�");
		return 0;
	}

	if (xyly=="A")	//���س�������
	{
        //��������ĳ���
		s_cx_dm=new Array("A3","B2","C1","C2","C3","C4","C5","D","E","F","M","N","P");
	}
	else if (xyly=="B")	//��س�������
	{
        //��������ĳ���
		s_cx_dm=new Array("C1","C2","C3","C4","C5","D","E","F");
	}
	else
	{
		s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","C5","D","E","F","M","N","P");
	}
    return check_zjcx(sqcx,s_cx_dm);
}




//��������Ϣ¼���Ƿ�Ϸ�
function check_tjxx(sqcx)
{
   var _result=1;
   var sg=document.all.ec_sg.value;
   var bsl=document.all.ec_bsl.value;
   var tl=document.all.ec_tl.value;
   var sz=document.all.ec_sz.value; 
   var qgjb=document.all.ec_qgjb.value; 
   var yxz=document.all.ec_yxz.value; 
   var zxz=document.all.ec_zxz.value; 
   var zsl=document.all.ec_zsl.value;
   var ysl=document.all.ec_ysl.value;
   //�ж�����Ƿ��ں���Χ��
   if(_result==1)
   {
       _result=check_sg(sg);
   }
   /*
   //�жϱ�ɫ������������֫�����ɾ����Ƿ�ϸ�
   if(_result==1)
   {
       _result=isHg(bsl,tl,sz,qgjb,yxz);
   }
   //�ж����복�ͺ�����֫�Ƿ���Ϲ淶Ҫ��
   if(_result==1)
   {
       _result=zjcx_zxz(sqcx,zxz);
   }
     
   if((yxz=="0" || yxz=="2") && sqcx!="C5")
   {
  		alert("����֫����ϸ�");
  		return 0;
   }
   if(yxz!="2" && sqcx=="C5"){
 		alert("C5֤����֫�����ǲ��ϸ񵫿�������վ����");
  		return 0;	   
   }
   
   //�ж����복�ͺ�����������Ƿ���Ϲ淶Ҫ��
   if(_result==1)
   {
       _result=zjcx_sg(sqcx,sg);
       if(_result==0){
    	   return 0;
       }
   }  
   */
   //�ж����복�ͺ������Ƿ���Ϲ淶Ҫ��
   if(_result==1)
   {
       _result=zjcx_sl(sqcx,zsl,ysl);
       if(_result==0){
    	   return 0;
       }       
   }   
   
   return _result;
}
//��������Ϣ�Ƿ�Ϸ�
function check_sqxx(sqcx,csrq,xyly)
{
   var _result=1;
   //�ж����복�ͺ������������Ƿ���Ϲ淶Ҫ��
   if(_result==1)
   {
       _result=zjcx_nl(sqcx,csrq);
   } 
   
   //�ж����복�ͺ���������Դ�Ƿ���Ϲ淶Ҫ��
   if(_result==1)
   {	 
       _result=check_sqcx(sqcx,xyly);
   }  
   return _result;
}

//��ʻ֤֤о���У��λ�ж�
function zxbhCheck(hm,obj)
{
  try
  {
  	var w=new Array();
  	var ll_sum;
  	var ll_i;
  	var ls_check;
  	w[0]=9;
  	w[1]=8;
  	w[2]=0;
  	w[3]=8;
  	w[4]=7;
  	w[5]=3;
  	w[6]=2;
  	w[7]=3;
  	w[8]=5;
  	w[9]=6;
  	w[10]=7;
  	w[11]=8;
  	w[12]=9;
  	ll_sum=0;
  	hm = hm.substr(0,2).replace(/4/g,"8") + hm.substr(2,1) + hm.substr(3).replace(/4/g,"8");

  	if (hm.length < 13)
  	{
  		alert("��ʻ֤֤о���¼��������˶ԣ�");
  		obj.focus();
  		return 0;
  	}
  	for (ll_i=0;ll_i<=12;ll_i++)
  	{
  		if (ll_i != 2)
  		{
  			if (hm.substr(ll_i,1) < "0" || hm.substr(ll_i,1) > "9")
  			{
  				alert("��ʻ֤֤о���¼��������˶ԣ�");
  				obj.focus();
  				return 0;
  			}
  			ll_sum=ll_sum+(hm.substr(ll_i,1)-0)*w[ll_i];
  		}
  		else
  		{
  			if ((hm.substr(ll_i,1) < "0" || hm.substr(ll_i,1) > "9") && hm.substr(ll_i,1) != "X")
  			{
  				alert("��ʻ֤֤о���¼��������˶ԣ�");
  				obj.focus();
  				return 0;
  			}
  		}
  	 }
     ll_sum=ll_sum % 11;
  	 if (ll_sum == 10) ls_check = "X";
  		else ls_check = ll_sum;
  
  	 if (hm.substr(2,1) != ls_check)
  	 {
	 	 alert("��ʻ֤֤о���¼��������˶ԣ�");
	  	 obj.focus();
	  	 return 0;
     }
  	 return 1;
   }
   catch(err)
   {
  	  alert(err.description);
  	  return 0;
   }
}


function check_dzxx(_prefix)
{
     var i=0;
     var o_djzsxzqh ;
     var o_djzsxxdz;
     var o_lxzsxxdz;
     var o_lxzsxzqh;
     if(_prefix=="ps_")
     {
    	 o_djzsxzqh =  document.all["ps_djzsxzqh"];
     	 o_djzsxxdz = document.all["ps_djzsxxdz"];
     	 o_lxzsxxdz = document.all["ps_lxzsxxdz"];
     	 o_lxzsxzqh = document.all["ps_lxzsxzqh"];
     }    
     else if(_prefix=="tp_")
     {
    	 o_djzsxzqh =  document.all["tp_djzsxzqh"];
     	 o_djzsxxdz = document.all["tp_djzsxxdz"];
     	 o_lxzsxxdz = document.all["tp_lxzsxxdz"];  
     	 o_lxzsxzqh = document.all["tp_lxzsxzqh"];
     }     
     else if(_prefix=="li_")
     {
    	 o_djzsxzqh =  document.all["li_djzsxzqh"];
     	 o_djzsxxdz = document.all["li_djzsxxdz"];
     	 o_lxzsxxdz = document.all["li_lxzsxxdz"];   
     	 o_lxzsxzqh = document.all["li_lxzsxzqh"];
     }
     else if(_prefix=="lo_")
     {
    	 o_djzsxzqh =  document.all["lo_djzsxzqh"];
     	 o_djzsxxdz = document.all["lo_djzsxxdz"];
     	 o_lxzsxxdz = document.all["lo_lxzsxxdz"];
     	 o_lxzsxzqh = document.all["lo_lxzsxzqh"];
     }     
     var ls_strxzqh  = o_djzsxzqh.value;
     var ls_djzsxxdz = o_djzsxxdz.value;
     var ls_lxzsxxdz = o_lxzsxxdz.value;
     var ywlx="";
     var o_ywlx=document.all["ywlx"];
     if(o_ywlx!=undefined)
     {
    	 ywlx=o_ywlx.value;
     }
    if(ywlx=="A")
    {
    	if (ls_djzsxxdz!="" && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("���") == -1 && ls_djzsxxdz.indexOf("�ӱ�") == -1
           && ls_djzsxxdz.indexOf("ɽ��") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1
           && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("������") == -1 && ls_djzsxxdz.indexOf("�Ϻ�") == -1
           && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("�㽭") == -1
           && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("ɽ��") == -1
           && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1
           && ls_djzsxxdz.indexOf("�㶫") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1
           && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("�Ĵ�") == -1 && ls_djzsxxdz.indexOf("����") == -1
           && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("����") == -1
           && ls_djzsxxdz.indexOf("�ຣ") == -1 && ls_djzsxxdz.indexOf("����") == -1 && ls_djzsxxdz.indexOf("�½�") == -1
           && ls_djzsxxdz.indexOf("����") == -1)
    	{
    			o_djzsxxdz.focus();
    			return "�Ǽ�ס����ϸ��ַ�������ʡ����Ϣ��";
    	}
    }
    if (ls_lxzsxxdz!="" && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("���") == -1 && ls_lxzsxxdz.indexOf("�ӱ�") == -1
           && ls_lxzsxxdz.indexOf("ɽ��") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1
           && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("������") == -1 && ls_lxzsxxdz.indexOf("�Ϻ�") == -1
           && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("�㽭") == -1
           && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("ɽ��") == -1
           && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1
           && ls_lxzsxxdz.indexOf("�㶫") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1
           && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("�Ĵ�") == -1 && ls_lxzsxxdz.indexOf("����") == -1
           && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("����") == -1
           && ls_lxzsxxdz.indexOf("�ຣ") == -1 && ls_lxzsxxdz.indexOf("����") == -1 && ls_lxzsxxdz.indexOf("�½�") == -1
           && ls_lxzsxxdz.indexOf("����") == -1){
    	   o_lxzsxxdz.focus();
           return "��ϵס����ϸ��ַ�������ʡ����Ϣ��";
     }
     var currSelectIndex="";
     var str="";

     if(ywlx=="A")//������ҵ���жϵǼ�ס����ϸ��ַ����ϵס����ϸ��ַ�ɼ��Ƿ���Ϲ淶Ҫ��
     {
    	 if(o_djzsxzqh.tagName=="SELECT")//�жϵǼ�ס����ϸ��ַ��������Ǽ�ס������������Text
    	 {
    		 currSelectIndex = o_djzsxzqh.selectedIndex;
    		 str=o_djzsxzqh[currSelectIndex].text;
    		 if(str!="���"&&ls_djzsxxdz.indexOf(str)==-1)
    		 {
    			 return "�Ǽ�ס������������Ǽ�ס����ϸ��ַ������";
    		 }
    	 }
    	 if(o_lxzsxzqh.tagName=="SELECT")//�жϵǼ�ס����ϸ��ַ��������Ǽ�ס������������Text
    	 {
    		 currSelectIndex = o_lxzsxzqh.selectedIndex;
    		 str=o_lxzsxzqh[currSelectIndex].text;		
    		 if(ls_lxzsxxdz.indexOf(str)==-1)
    		 {
    			 return "��ϵס��������������ϵס����ϸ��ַ������";
    		 }
    	 }  
     }
     if(o_djzsxzqh.tagName=="SELECT")
     {
    	 if (ls_djzsxxdz.length < 10){
    		 o_djzsxxdz.focus();
    		 return "�Ǽ�ס����ϸ��ַ���Ȳ���С��10λ��"
    	 }
     }
     if(o_lxzsxzqh.tagName=="SELECT")
     {
    	 if (ls_lxzsxxdz.length < 10){
    		 o_lxzsxxdz.focus();
    		 return "��ϵס����ϸ��ַ���Ȳ���С��10λ��"
    	 }
    	 return "1";
     }
}

function check_zzzm(_prefix)
{
   var o_ly;
   var o_zzzm;
   if(_prefix=="ps_")
   {
      o_ly=document.all["ec_ly"];
      o_zzzm=document.all["ec_zzzm"];
   }
   else if(_prefix=="tp_")
   {
      o_ly=document.all["tp_ly"];
      o_zzzm=document.all["tp_zzzm"];
   }     
   else if(_prefix=="li_")
   {
      o_ly=document.all["li_ly"];
      o_zzzm=document.all["li_zzzm"];
   }
   else if(_prefix=="lo_")
   {
      o_ly=document.all["lo_ly"];
      o_zzzm=document.all["lo_zzzm"];
   }        
  
   //������Ǳ����ˣ�������ס֤�š���֤���غ���Ч���Ƿ�¼��
   if (o_zzzm.value=="" )
   {
       alert('��ǰ�����˵Ǽ�ס����ַ����ص�ַ������¼����ס֤����ţ�');
       o_zzzm.focus();
       return false;
   }
   
   var zzzm=o_zzzm.value;
   o_zzzm.value=zzzm.trim();
   
   
   switch(o_ly.value.charAt(0))
   {
       case 'A':
             if(o_zzzm.value!="")
             {
                 alert('��ʻ����ԴΪ���أ�����������ס֤��Ϣ��\n����ס֤�ţ�');
                 document.all.zzzm.focus();
                                return false;
             }
             break;
        case 'B':
             if(o_zzzm.value=="")
             {
                 alert('��������������ס��Ϣ��\n����ס֤�ţ�');
                 o_zzzm.focus();
                 return false;
             }
             break;
		case 'C':
             break;
	} 
	return true;       
}

function setFocus(obj)
{
	 if(obj!=undefined)
	 {
		 obj.focus();
	 }
}
