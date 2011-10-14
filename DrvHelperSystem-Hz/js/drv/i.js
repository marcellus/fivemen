var _REG_REDIRECT_ = /^http:\/\/([^\/\.]+\.)*(xunlei\.com|gougou\.com|sandai\.net)\/?/i;

is_text_input = function(inputObj)
{
	return  inputObj&&
		inputObj.type&&
		("TEXT"==inputObj.type.toUpperCase()||"PASSWORD"==inputObj.type.toUpperCase());
}

input_focus = function(inputObj)
{
	if( is_text_input(inputObj))
		inputObj.className = "ipt_tx2";
}

input_blur = function(inputObj)
{
	if( is_text_input(inputObj))
		inputObj.className = "ipt_tx";
}

setVerifyCode = function(imgObj)
{
	imgObj = $(imgObj);
	if(imgObj)
		imgObj.src =  "http://verify.xunlei.com/image?cachetime=" + new Date().getTime();
}

/******************************************************************************************
 * �������ǿ��
 ******************************************************************************************/
checkPasswordLevel = function(strPassword)
{

	//alert("enter ");
	//check length
	var result = 0;
	if ( strPassword.length == 0)
		result += 0;
	else if ( strPassword.length<8 && strPassword.length >0 )
		result += 5;
	else if (strPassword.length>10)
		result += 25;
	else
		result += 10;
	//alert("��鳤��:"+strPassword.length+"-"+result);
	
	//check letter
	var bHave = false;
	var bAll = false;
	var capital = strPassword.match(/[A-Z]{1}/);//�Ҵ�д��ĸ
	var small = strPassword.match(/[a-z]{1}/);//��Сд��ĸ
	if ( capital == null && small == null )
	{
		result += 0; //û����ĸ
		bHave = false;
	}
	else if ( capital != null && small != null )
	{
		result += 20;
		bAll = true;
	}
	else
	{	
		result += 10;
		bAll = true;
	}
	//alert("�����ĸ��"+result);
	
	//�������
	var bDigi = false;
	var digitalLen = 0;
	for ( var i=0; i<strPassword.length; i++)
	{
	
		if ( strPassword.charAt(i) <= '9' && strPassword.charAt(i) >= '0' )
		{
			bDigi = true;
			digitalLen += 1;
			//alert(strPassword[i]);
		}
		
	}
	if ( digitalLen==0 )//û������
	{
		result += 0;
		bDigi = false;
	}
	else if (digitalLen>2)//2����������
	{
		result += 20 ;
		bDigi = true;
	}
	else
	{
		result += 10;
		bDigi = true;
	}
	//alert("���ָ�����" + digitalLen);
	//alert("������֣�"+result);
	
	//���ǵ����ַ�
	var bOther = false;
	var otherLen = 0;
	for (var i=0; i<strPassword.length; i++)
	{
		if ( (strPassword.charAt(i)>='0' && strPassword.charAt(i)<='9') ||  
			(strPassword.charAt(i)>='A' && strPassword.charAt(i)<='Z') ||
			(strPassword.charAt(i)>='a' && strPassword.charAt(i)<='z'))
			continue;
		otherLen += 1;
		bOther = true;
	}
	if ( otherLen == 0 )//û�зǵ����ַ�
	{
		result += 0;
		bOther = false;
	}
	else if ( otherLen >1)//1�����Ϸǵ����ַ�
	{
		result +=25 ;
		bOther = true;
	}
	else
	{
		result +=10;
		bOther = true;
	}
	//alert("���ǵ��ʣ�"+result);
	
	//�����⽱��
	if ( bAll && bDigi && bOther)
		result += 5;
	else if (bHave && bDigi && bOther)
		result += 3;
	else if (bHave && bDigi )
		result += 2;
	//alert("�����⽱����"+result);

	var level = "";
	//���ݷ�����������ǿ�ȵĵȼ�
	if ( result >=90 )
		level = "rank r7";
	else if ( result>=80)
		level = "rank r6";
	else if ( result>=70)
		level = "rank r5";
	else if ( result>=60)
		level = "rank r4";
	else if ( result>=50)
		level = "rank r3";
	else if ( result>25)
		level = "rank r2";
	else if ( result>0)
		level = "rank r1";
	else
		level = "rank r0";

//		alert("return:"+level);
	return level.toString();
}	


/******************************************************************************************
 * ��������ǿ����ʽ
 ******************************************************************************************/
setPasswordLevel = function(passwordObj, levelObj)
{
var level = "rank r0";
level = checkPasswordLevel(passwordObj.value.trim());
levelObj.className = level;
//alert("level"+level);
}


/******************************************************************************************
 * �������
 ******************************************************************************************/
checkDate = function(dateStr)
{
	var year;
	var month;
	var day;
	if (dateStr.length==6)
	{
		year = dateStr.substr(0,2);
		month = dateStr.substr(2,2);
		day=dateStr.substr(4,2);
	}
	else if (dateStr.length==8)
	{
		year = dateStr.substr(0,4);
		month = dateStr.substr(4,2);
		day=dateStr.substr(6,2);
	}	
	else
		return false;

  //У�����λ
	if (year.length==2)
	{
		if( parseInt(year) < 0 || parseInt(year) > 99 )
			return false;
	}
	else
	{ 
		if( (year.substr(0,2)!='19'||year.substr(0,2)!='20') && (parseInt(year.substr(2,2)) < 0 || parseInt(year.substr(2,2))>99) )
			return false;
	}
	
	//У���·�
	if(month<'01'||month >'12')
		return false;
	
	//У����
	if(day<'01'||day >'31')
		return false;
		
	//alert("������ȷ");	
	return true;
}

/******************************************************************************************
 * ������֤
 ******************************************************************************************/
validId = function (obj)
{
  var _id=obj.value;
  _id=_id+"";
  
  //���������һλ�������λ�Ƿ�������
  for(var i=0;i<_id.length-1;i++)
  {
	//У��ÿһλ�ĺϷ���
	if(_id.charAt(i)<'0'||_id.charAt(i)>'9')
		return false;
  }
  //alert("ÿһλ���ϸ�");
	if (_id.length == 15)
	{
		if (_id.charAt(_id.length-1)<'0'||_id.charAt(_id.length-1)>'9')
			return false;
		return checkDate(_id.substr(6,6));
	}
	else if( _id.length == 18)
	{
		var lastBit = _id.charAt(_id.length-1);
		if ( ( parseInt(lastBit)>= 0 && parseInt(lastBit) <= 9)||lastBit=='X')
		{	
			//alert(_id.substr(6,8));
			return checkDate(_id.substr(6,8));
		}
		//alert("���һλ����ȷ");
		return false;
	}
	else
	{
		//id card wrong
		return false;
	}
}    

checkIdcardNo = function(cardNoObjId, infoObj)
{
	if (!validId($(cardNoObjId)))
	{
		$(cardNoObjId+"_msg").innerHTML = "����ȷ��д���֤����!";
		$(cardNoObjId).parentNode.className = "fail";
		infoObj._exceptions.push({ctrl_id:cardNoObjId, msg:'����ȷ��д���֤����!'});
	}
	else
	{
		$(cardNoObjId).parentNode.className = "";
	}
}


/******************************************************************************************
 * ������뱣��������������ͺʹ𰸵ĺϷ���
 ******************************************************************************************/
checkAnswerFormat = function(ansObjId, qObjId, infoObj)
{
	//g_objPasswordProtect.BackToNormal();
	var strData = $(ansObjId).value;
	var selectLabel;
	//alert("call checkAnswerFormat");
	
	selectLabel = $(qObjId).options[$(qObjId).selectedIndex].parentNode.label;
	
	//alert(strData);
	//alert(selectLabel);
	if ( selectLabel == "����" )//ѡ��������
	{ 
		if (strData.length != 8 )
		{

			$(ansObjId).parentNode.className = "fail";
			$(ansObjId+'_msg').innerHTML = "���ո�ʽ��������(YYYYMMDD)������20050705";
			infoObj._exceptions.push({ctrl_id:ansObjId, msg:'���ո�ʽ��������(YYYYMMDD)������20050705'});
		}
		else
		{
			//alert(strData);
			if ( !checkDate(strData) )		
			{
				$(ansObjId).parentNode.className = "fail";
				$(ansObjId+'_msg').innerHTML = "���ո�ʽ��������(YYYYMMDD)������20050705";
				infoObj._exceptions.push({ctrl_id:ansObjId,msg:'���ո�ʽ��������(YYYYMMDD)������20050705 '});
			}
			else
				$(ansObjId).parentNode.className = "";
		}
	}
	else//ѡ��������
	{
		if ( strData.length < 1 || strData.length > 38 )
		{
			$(ansObjId).parentNode.className = "fail";
			$(ansObjId+'_msg').innerHTML = "�����룺1-19λ���Ļ���1-38λӢ�ġ�";						
		}
		else
			$(ansObjId).parentNode.className = "";
	}
}


cutLen = function( obj, length)
{
	if ( obj.value.bytes() > length )
		obj.value = obj.value.truncate(length);//��ȡlength���ֽ�
}	
		