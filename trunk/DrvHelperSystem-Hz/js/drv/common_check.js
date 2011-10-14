
//获取最大准驾车型
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
  
//多车型时返回第一个车型
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
//  函数名：yzjcx_sqcx(yzjcx,sqcx)
//  功能介绍：申请车型是否被原车型包含
//  参数说明：原车型，申请车型
//  返回值  ：1-包含，0-不包含
//-------------------------------

function yzjcx_sqcx(yzjcx,sqcx)
{
  	var a_temp=new Array();
    //车型代码表
	var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","C5","D","E","F","M","N","P");
    //车型包含列表
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
	var i;	//计数器

  	if(yzjcx==null || sqcx==null)
        	return 0;

	//检验是否直接被包含
    if(yzjcx.indexOf(sqcx)!=-1)
        	return 1;

	//没有直接包含
	//将原准驾车型字符串扩展为
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
//函数名  ：checkZjcxInList(s_value，s_cx_dm)
//判读准驾车型是否在列表中
//-------------------------------
function checkZjcxInList(s_value,s_cx_dm)
{
		//合法的准驾车行字符串数组
	//var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P");
	//字符串数组的长度
	var s_cx_input;	//存放需要检验的字符串
	var i_pos;	//查找子串定位
	var i;
	s_cx_input=s_value;
	for(i in s_cx_dm)	//对合法准驾车行字符串数组轮循
	{
		do
		{
			i_pos=s_cx_input.indexOf(s_cx_dm[i]);	//是否包含当前车型
			if(i_pos!=-1)	//包含
			{
	             //去掉找到的子串
				s_cx_input=s_cx_input.slice(0,i_pos)+s_cx_input.slice(i_pos+s_cx_dm[i].length);
			}
		}
		while(i_pos!=-1);	//找不到当前车型子串，进入下一车型子串查找
	}
	if(s_cx_input.length==0)
	{
		//输入字符串包含的都是合法的车型子串（全部被去掉了）
		return 1;
	}
	else
	{
		return 0;
	}
}

//-------------------------------
//  函数名  ：check_zjcx(s_value，s_cx_dm)
//  参数说明：准驾车型字符串，合法的准驾车行字符串数组。
//  功能介绍：检查车型输入是否正确，只检查是否包含合法的准驾车行字符串，重复、次序颠倒不认为是错误
//  返回值  ：1-包含合法的准驾车行，0-不合法
//
//  戴嘉 2004.05.12
//-------------------------------
function check_zjcx(s_value,s_cx_dm)
{
  	//合法的准驾车行字符串数组
	//var s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P");
    //字符串数组的长度
    var s_cx_input;	//存放需要检验的字符串
	var i_pos;	//查找子串定位
    var i;
    s_cx_input=s_value;
	for(i in s_cx_dm)	//对合法准驾车行字符串数组轮循
	{
		do
		{
			i_pos=s_cx_input.indexOf(s_cx_dm[i]);	//是否包含当前车型
			if(i_pos!=-1)	//包含
			{
                 //去掉找到的子串
				s_cx_input=s_cx_input.slice(0,i_pos)+s_cx_input.slice(i_pos+s_cx_dm[i].length);
			}
		}
		while(i_pos!=-1);	//找不到当前车型子串，进入下一车型子串查找
	}
	if(s_cx_input.length==0)
	{
		//输入字符串包含的都是合法的车型子串（全部被去掉了）
		return 1;
    }
	else
	{
		//输入字符串还包含有非法的字符串
		alert("申请车型不符合规范要求！");
		return 0;
    }
}

//-------------------------------
//  函数名  ：check_sg(i_value)
//  参数说明：身高。
//  功能介绍：检查身高是否为数字；是否>=100,<=250
//  返回值  ：1-是，0-不是
//-------------------------------

function check_sg(i_value)
{
    if(isNum("身高",i_value)==0)  //检查身高是否为数字
    {
        return 0;
    }
    else
    {
	    if ((i_value-0)<100 ||(i_value-0)>250)
	    {
	        alert("'身高'合理范围应在 100--250 ！");
	        document.all["ec_sg"].focus();
            return 0;
	    }
    }
    return 1;
}

//-------------------------------
//  函数名：isHg(bsl,tl,sz,qgjb,yxz)
//  功能介绍：辨色力,听力,上肢,躯干颈部是否合格
//  参数说明：辨色力,听力,上肢,躯干颈部
//  返回值  ：1-符合申请,0-不符合
//-------------------------------

function isHg(bsl,tl,sz,qgjb,yxz)
{
    if (!(bsl==1))
    {
       alert("'辨色力'不合格者不能申请！");
       return 0;
    }
    if (!(tl==1))
    {
       	alert("'听力'不合格者不能申请！");
        return 0;
    }
    if (!(sz==1))
    {
       	alert("'上肢'不合格者不能申请！");
        return 0;
    }
    if (!(qgjb==1))
    {
       	alert("'躯干颈部'不合格者不能申请！");
        return 0;
    }
    return 1;
}
//-------------------------------
//  函数名：zjcx_zxz(sqcx,zxz)
//  功能介绍：左下肢是否符合申请车型要求
//  参数说明：申请车型，左下肢
//  返回值  ：1-符合,0-不符合
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
    alert("'左下肢'不合格者只能申请'C2-自动挡汽车'！");
    return 0;
   }
}

//-------------------------------
//函数名：jscx_nl(sqcx,csrq)
//功能介绍：出生日期是否符合驾驶该车型要求
//参数说明：申请车型，出生日期
//返回值  ：1-符合,0-不符合
//Jamse 2010-01-30修改驾驶年龄限制，60周岁以上包含60周岁限制
//todo测试cal_years方法
//-------------------------------

function jscx_nl(sqcx,csrq)
{ 
	//alert("csrq:"+csrq+" sqcx:"+sqcx);
	sqcx=first_zjcx(sqcx);
	
	var nl;
	nl=cal_years(csrq);//求年龄
	if (sqcx=="C1" ||sqcx=="C2" || sqcx=="C5" ||sqcx=="F" ) //1	
	{
		if (nl-0<18)
		{
			alert("驾驶本准驾车型年龄要求 18以上 ,当前 "+nl+" 岁！");
			return 0;
		}
	}
	if (sqcx=="C3" ||sqcx=="C4" ||sqcx=="D" ||sqcx=="E"||sqcx=="M") //2
	{
		if (nl-0<18 || nl>=70)
		{
			alert("驾驶本准驾车型年龄要求 18--70 ,当前 "+nl+" ！");
			return 0;
		}
	}
	if (sqcx=="B1" ||sqcx=="B2" ||sqcx=="A3" ||sqcx=="N"||sqcx=="P") //3
	{
		if (nl-0<21 || nl>=60)
		{
			alert("驾驶本准驾车型年龄要求 21--60 ,当前 "+nl+" ！");
			return 0;
		}
	}
	if (sqcx=="A2" ) //4
	{
		if (nl-0<24 || nl>=60)
		{
			alert("驾驶本准驾车型年龄要求 24--60 ,当前 "+nl+" ！");
			return 0;
		}
	}
	if (sqcx=="A1" ) //5
	{
		if (nl-0<26 || nl>=60)
		{
			alert("驾驶本准驾车型年龄要求 26--60 ,当前 "+nl+" ！");
			return 0;
		}
	}
	return 1;
}


//-------------------------------
//  函数名：zjcx_sg(sqcx,sg)
//  功能介绍：身高是否符合申请车型要求
//  参数说明：申请车型，身高
//  返回值  ：1-符合,0-不符合
//-------------------------------

function zjcx_sg(sqcx,sg)
{  
    sqcx=first_zjcx(sqcx);
    if (check_sg(sg)==0) //对身高范围检查
    {
  		return 0;
 	}
 	if (sqcx=="A1" ||sqcx=="A2" ||sqcx=="A3" ||sqcx=="B2"||sqcx=="N")
 	{
 		if (sg-0<155)
 		{
          	alert("按《机动车驾驶证申领和使用规定》(公安部91号令)第十一条第（二）款规定，申请车型"+sqcx+"时身高必须在155cm以上！");
         	return 0;
        }
 	}
 	if (sqcx=="B1" )
 	{
 		if (sg-0<150)
 		{
          	alert("按《机动车驾驶证申领和使用规定》(公安部91号令)第十一条第（二）款规定，申请车型"+sqcx+"时身高必须在150cm以上！");
           	return 0;
        }
 	}
 	return 1;
}

//-------------------------------
//  函数名  ：h(i_value)
//  参数说明：视力。
//  功能介绍：检查视力是否为数字；是否>=4.9,<=5.5
//  返回值  ：1-是，false-不是
//-------------------------------

function check_sl(i_value)
{
    var reg = /^(\d{1,1})(\.)(\d{1,1})$/;
    var vSl=i_value;
    var r = vSl.match(reg);
    if(r==null)
    {
         alert("视力的格式应为：x.x ！")
         return 0;
    }

    if ((vSl-0)<4.9 || (vSl-0)>5.5)
    {
         alert("'视力'应在 4.9--5.5 范围！");
         return 0;
    }

 	return 1;
}


//-------------------------------
//  函数名：zjcx_sl(sqcx,zsl,ysl)
//  功能介绍：视力是否符合申请车型要求
//  参数说明：申请车型，左视力，右视力
//  返回值  ：1-符合,0-不符合
//  更新by季君 2004-08-06
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
  	if (check_sl(zsl)==0) //对视力范围检查
 	{
        document.all["ec_zsl"].focus();
  		return 0;
 	}
  	if (check_sl(ysl)==0) //对视力范围检查
 	{
   		document.all["ec_ysl"].focus();
   		return 0;
 	}
	/* 
	if (sqcx=="A1" ||sqcx=="A2" ||sqcx=="A3" ||sqcx=="B1"||sqcx=="B2" ||sqcx=="N"||sqcx=="P")
 	{
 		if (zsl-0<5.0)
 		{
        	alert("按《机动车驾驶证申领和使用规定》(公安部91号令)第十一条第（二）款规定，申请车型"+sqcx+"时视力要求在5.0以上！");
          	document.all["ec_zsl"].focus();
         	return 0;
        }
        if (ysl-0<5.0)
 		{
          	alert("按《机动车驾驶证申领和使用规定》(公安部91号令)第十一条第（二）款规定，申请车型"+sqcx+"时视力要求在5.0以上！");
          	document.all["ec_ysl"].focus();
         	return 0;
        }
 	}
 	*/
  	return 1;
}

//-------------------------------
//  函数名：zjcx_sl(sqcx,zsl,ysl)
//  功能介绍：视力是否符合申请车型要求
//  参数说明：申请车型，左视力，右视力
//  返回值  ：1-符合,0-不符合
//  更新by季君 2004-08-06
//-------------------------------
function zjcx_tjyy(sqcx,tjyy)
{
    return "1";
}

//-------------------------------
//  函数名：zjcx_nl(sqcx,csrq)
//  功能介绍：出生日期是否符合申请车型要求
//  参数说明：申请车型，出生日期
//  返回值  ：1-符合,0-不符合
//-------------------------------

function zjcx_nl(sqcx,csrq)
{
	var nl;
	sqcx=first_zjcx(sqcx)
	
	
	nl=cal_years(csrq);//求年龄
 	if (sqcx=="C1" ||sqcx=="C2" ||sqcx=="C5" ||sqcx=="F" ) //1
 	{
 		if (nl-0<18 || nl>70)
 		{
          	alert("按《机动车驾驶证申领和使用规定》(公安部111号令)第十一条第（一）款规定，申请车型"+sqcx+"时年龄必须在18周岁以上，70周岁以下 ,当前 "+nl+" 岁！");
        	return 0;
        }
 	}
 	if (sqcx=="C3" ||sqcx=="C4" ||sqcx=="D" ||sqcx=="E"||sqcx=="M") //2
 	{
 		if (nl-0<18 || nl>60)
 		{
         	alert("按《机动车驾驶证申领和使用规定》(公安部111号令)第十一条第（一）款规定，申请车型"+sqcx+"时年龄必须在18周岁以上，60周岁以下 ,当前 "+nl+" 岁！");
         	return 0;
        }
 	}
 	if (sqcx=="B1" ||sqcx=="B2" ||sqcx=="A3" ||sqcx=="N"||sqcx=="P") //3
 	{
 		if (nl-0<21 || nl>50)
 		{
        	alert("按《机动车驾驶证申领和使用规定》(公安部111号令)第十一条第（一）款规定，申请车型"+sqcx+"时年龄必须在21周岁以上，50周岁以下 ,当前 "+nl+" 岁！");
        	return 0;
        }
 	}
 	if (sqcx=="A2" ) //4
 	{
 		if (nl-0<24 || nl>50)
 		{
            alert("按《机动车驾驶证申领和使用规定》(公安部111号令)第十一条第（一）款规定，申请车型"+sqcx+"时年龄必须在24周岁以上，50周岁以下 ,当前 "+nl+" 岁！");
          	return 0;
        }
 	}
 	if (sqcx=="A1" ) //5
 	{
 		if (nl-0<26 || nl>50)
 		{
           alert("按《机动车驾驶证申领和使用规定》(公安部111号令)第十一条第（一）款规定，申请车型"+sqcx+"时年龄必须在26周岁以上，50周岁以下 ,当前 "+nl+" 岁！");
           return 0;
        }
 	}
	return 1;
}

//-------------------------------
//  函数名：check_sqcx(sqcx,xyly)
//  功能介绍：初领业务，对申请车型的限制（第13条）
//  参数说明：申请车型，学员来源
//  返回值  ：1-可申请，0-不可申请
//-------------------------------

function check_sqcx(sqcx,xyly)
{
 
    if (yzjcx_sqcx("A1A2A3B1B2C1C2C3C4C5DEFMNP",sqcx)==0)
    {
		alert("申请车型中含非法字符！");
		return 0;
	}
	sqcx=first_zjcx(sqcx);
	var s_cx_dm=new Array;	//允许申领的车型字符串数组
	if(sqcx==null || xyly==null)
	{
	    alert("申请车型和驾驶人来源不能为空！");
		return 0;
	}

	if (xyly=="A")	//本地初次申领
	{
        //允许申领的车型
		s_cx_dm=new Array("A3","B2","C1","C2","C3","C4","C5","D","E","F","M","N","P");
	}
	else if (xyly=="B")	//外地初次申领
	{
        //允许申领的车型
		s_cx_dm=new Array("C1","C2","C3","C4","C5","D","E","F");
	}
	else
	{
		s_cx_dm=new Array("A1","A2","A3","B1","B2","C1","C2","C3","C4","C5","D","E","F","M","N","P");
	}
    return check_zjcx(sqcx,s_cx_dm);
}




//检查体检信息录入是否合法
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
   //判断身高是否在合理范围内
   if(_result==1)
   {
       _result=check_sg(sg);
   }
   /*
   //判断辨色力、听力、上肢、躯干颈部是否合格
   if(_result==1)
   {
       _result=isHg(bsl,tl,sz,qgjb,yxz);
   }
   //判断申请车型和左下肢是否符合规范要求
   if(_result==1)
   {
       _result=zjcx_zxz(sqcx,zxz);
   }
     
   if((yxz=="0" || yxz=="2") && sqcx!="C5")
   {
  		alert("右下肢必须合格！");
  		return 0;
   }
   if(yxz!="2" && sqcx=="C5"){
 		alert("C5证右下肢必须是不合格但可以自主站立！");
  		return 0;	   
   }
   
   //判断申请车型和申请人身高是否符合规范要求
   if(_result==1)
   {
       _result=zjcx_sg(sqcx,sg);
       if(_result==0){
    	   return 0;
       }
   }  
   */
   //判断申请车型和视力是否符合规范要求
   if(_result==1)
   {
       _result=zjcx_sl(sqcx,zsl,ysl);
       if(_result==0){
    	   return 0;
       }       
   }   
   
   return _result;
}
//检查基本信息是否合法
function check_sqxx(sqcx,csrq,xyly)
{
   var _result=1;
   //判断申请车型和申请人年龄是否符合规范要求
   if(_result==1)
   {
       _result=zjcx_nl(sqcx,csrq);
   } 
   
   //判断申请车型和申请人来源是否符合规范要求
   if(_result==1)
   {	 
       _result=check_sqcx(sqcx,xyly);
   }  
   return _result;
}

//驾驶证证芯编号校验位判断
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
  		alert("驾驶证证芯编号录入有误，请核对！");
  		obj.focus();
  		return 0;
  	}
  	for (ll_i=0;ll_i<=12;ll_i++)
  	{
  		if (ll_i != 2)
  		{
  			if (hm.substr(ll_i,1) < "0" || hm.substr(ll_i,1) > "9")
  			{
  				alert("驾驶证证芯编号录入有误，请核对！");
  				obj.focus();
  				return 0;
  			}
  			ll_sum=ll_sum+(hm.substr(ll_i,1)-0)*w[ll_i];
  		}
  		else
  		{
  			if ((hm.substr(ll_i,1) < "0" || hm.substr(ll_i,1) > "9") && hm.substr(ll_i,1) != "X")
  			{
  				alert("驾驶证证芯编号录入有误，请核对！");
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
	 	 alert("驾驶证证芯编号录入有误，请核对！");
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
    	if (ls_djzsxxdz!="" && ls_djzsxxdz.indexOf("北京") == -1 && ls_djzsxxdz.indexOf("天津") == -1 && ls_djzsxxdz.indexOf("河北") == -1
           && ls_djzsxxdz.indexOf("山西") == -1 && ls_djzsxxdz.indexOf("内蒙") == -1 && ls_djzsxxdz.indexOf("辽宁") == -1
           && ls_djzsxxdz.indexOf("吉林") == -1 && ls_djzsxxdz.indexOf("黑龙江") == -1 && ls_djzsxxdz.indexOf("上海") == -1
           && ls_djzsxxdz.indexOf("安徽") == -1 && ls_djzsxxdz.indexOf("江苏") == -1 && ls_djzsxxdz.indexOf("浙江") == -1
           && ls_djzsxxdz.indexOf("福建") == -1 && ls_djzsxxdz.indexOf("江西") == -1 && ls_djzsxxdz.indexOf("山东") == -1
           && ls_djzsxxdz.indexOf("河南") == -1 && ls_djzsxxdz.indexOf("湖北") == -1 && ls_djzsxxdz.indexOf("湖南") == -1
           && ls_djzsxxdz.indexOf("广东") == -1 && ls_djzsxxdz.indexOf("广西") == -1 && ls_djzsxxdz.indexOf("海南") == -1
           && ls_djzsxxdz.indexOf("重庆") == -1 && ls_djzsxxdz.indexOf("四川") == -1 && ls_djzsxxdz.indexOf("贵州") == -1
           && ls_djzsxxdz.indexOf("云南") == -1 && ls_djzsxxdz.indexOf("陕西") == -1 && ls_djzsxxdz.indexOf("甘肃") == -1
           && ls_djzsxxdz.indexOf("青海") == -1 && ls_djzsxxdz.indexOf("宁夏") == -1 && ls_djzsxxdz.indexOf("新疆") == -1
           && ls_djzsxxdz.indexOf("西藏") == -1)
    	{
    			o_djzsxxdz.focus();
    			return "登记住所详细地址必须包含省份信息！";
    	}
    }
    if (ls_lxzsxxdz!="" && ls_lxzsxxdz.indexOf("北京") == -1 && ls_lxzsxxdz.indexOf("天津") == -1 && ls_lxzsxxdz.indexOf("河北") == -1
           && ls_lxzsxxdz.indexOf("山西") == -1 && ls_lxzsxxdz.indexOf("内蒙") == -1 && ls_lxzsxxdz.indexOf("辽宁") == -1
           && ls_lxzsxxdz.indexOf("吉林") == -1 && ls_lxzsxxdz.indexOf("黑龙江") == -1 && ls_lxzsxxdz.indexOf("上海") == -1
           && ls_lxzsxxdz.indexOf("安徽") == -1 && ls_lxzsxxdz.indexOf("江苏") == -1 && ls_lxzsxxdz.indexOf("浙江") == -1
           && ls_lxzsxxdz.indexOf("福建") == -1 && ls_lxzsxxdz.indexOf("江西") == -1 && ls_lxzsxxdz.indexOf("山东") == -1
           && ls_lxzsxxdz.indexOf("河南") == -1 && ls_lxzsxxdz.indexOf("湖北") == -1 && ls_lxzsxxdz.indexOf("湖南") == -1
           && ls_lxzsxxdz.indexOf("广东") == -1 && ls_lxzsxxdz.indexOf("广西") == -1 && ls_lxzsxxdz.indexOf("海南") == -1
           && ls_lxzsxxdz.indexOf("重庆") == -1 && ls_lxzsxxdz.indexOf("四川") == -1 && ls_lxzsxxdz.indexOf("贵州") == -1
           && ls_lxzsxxdz.indexOf("云南") == -1 && ls_lxzsxxdz.indexOf("陕西") == -1 && ls_lxzsxxdz.indexOf("甘肃") == -1
           && ls_lxzsxxdz.indexOf("青海") == -1 && ls_lxzsxxdz.indexOf("宁夏") == -1 && ls_lxzsxxdz.indexOf("新疆") == -1
           && ls_lxzsxxdz.indexOf("西藏") == -1){
    	   o_lxzsxxdz.focus();
           return "联系住所详细地址必须包含省份信息！";
     }
     var currSelectIndex="";
     var str="";

     if(ywlx=="A")//初领类业务判断登记住所详细地址和联系住所详细地址采集是否符合规范要求
     {
    	 if(o_djzsxzqh.tagName=="SELECT")//判断登记住所详细地址必须包含登记住所行政区划的Text
    	 {
    		 currSelectIndex = o_djzsxzqh.selectedIndex;
    		 str=o_djzsxzqh[currSelectIndex].text;
    		 if(str!="外地"&&ls_djzsxxdz.indexOf(str)==-1)
    		 {
    			 return "登记住所行政区划与登记住所详细地址不符！";
    		 }
    	 }
    	 if(o_lxzsxzqh.tagName=="SELECT")//判断登记住所详细地址必须包含登记住所行政区划的Text
    	 {
    		 currSelectIndex = o_lxzsxzqh.selectedIndex;
    		 str=o_lxzsxzqh[currSelectIndex].text;		
    		 if(ls_lxzsxxdz.indexOf(str)==-1)
    		 {
    			 return "联系住所行政区划与联系住所详细地址不符！";
    		 }
    	 }  
     }
     if(o_djzsxzqh.tagName=="SELECT")
     {
    	 if (ls_djzsxxdz.length < 10){
    		 o_djzsxxdz.focus();
    		 return "登记住所详细地址长度不可小于10位！"
    	 }
     }
     if(o_lxzsxzqh.tagName=="SELECT")
     {
    	 if (ls_lxzsxxdz.length < 10){
    		 o_lxzsxxdz.focus();
    		 return "联系住所详细地址长度不可小于10位！"
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
  
   //如果不是本地人，则检查暂住证号、发证机关和有效期是否录入
   if (o_zzzm.value=="" )
   {
       alert('当前申请人登记住所地址是外地地址，必须录入暂住证明编号！');
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
                 alert('驾驶人来源为本地，无需输入暂住证信息！\n（暂住证号）');
                 document.all.zzzm.focus();
                                return false;
             }
             break;
        case 'B':
             if(o_zzzm.value=="")
             {
                 alert('请输入完整的暂住信息！\n（暂住证号）');
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
