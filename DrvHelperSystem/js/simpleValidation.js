// JavaScript Document
//添加字符串的原型
String.prototype.trim=function(){
return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.ltrim=function(){
return this.replace(/(^\s*)/g,"");
}
String.prototype.rtrim=function(){
return this.replace(/(\s*$)/g,"");
}


//错误验证消息类
	var validSuccess=0;
	
var ValidationMsg=Class.create();
ValidationMsg.prototype = {
	initialize:function(node)
	{
		this.Id=node.id;
		this.Message=node.message;
		this.ShowType=node.showstyle;
		this.Css=node.css;
	},
	GetErrorHtml:function()
	{
		var tempclass="";
		if(this.Css)
		{
			tempclass="class='"+this.Css+"'";	
		}
		else
		{
			tempclass="class='defaulterrorcss'";	
		}
		if(this.ShowType&&this.ShowType.toUpperCase() =="DIV")
		{
			
			return "<div "+tempclass+" id='"+this.Id+"simpleValid'>"+this.Message+"</div>";
			
		}
		return "<span "+tempclass+" id='"+this.Id+"simpleValid'>"+this.Message+"</span>";	
	}
	
	
	
};
//把错误信息系到id对象上
ValidationMsg.AttachError=function(node)
	{		
		
		 var obj1=$(node.id+"simpleValid");
		if(!obj1)
		{
			var obj=new ValidationMsg(node);
			new Insertion.After(node.id,obj.GetErrorHtml());
			validSuccess++;
		}
	};
//把错误信息从id对象上移开
ValidationMsg.RemoveError=function(node)
	{	
	   var obj=$(node.id+"simpleValid");
	   if(obj)
	   {
			obj.removeNode(true)
			validSuccess--;
	   }
	};


//验证类
var Validation=Class.create();
Validation.prototype=
{
	//validid,method,validmsg
	initialize:function(rules)
	{
		this.validRules=rules;
		
	},
	
	
	
	//自动绑定验证事件
	AutoBind:function()
	{
		var nodes = $A(this.validRules.rules);
		//alert(node[0].method.length);
        //alert(nodes.length);
		nodes.each
		(function(node)
		{
			//alert(node.id);
			//alert(node.method.length);
			//alert(node.method);
		    Validation.BindEvent(node);
		}
		);
		//alert(this.CheckResult);
		var form=$('form1');
		//alert(form.id);
		//alert(nodes.length);
		//alert(CheckResult);
		Event.observe(form,'submit',function(){return CheckResult(nodes,form);},false);
	}
	
	
	
	
	
};

//绑定事件
Validation.BindEvent=function(node)
	{
		//alert("beginbind");
		var tempevent="";
		if(node.callevent)
		{
			tempevent=node.callevent;
		    //alert("");
		}
		else
		{
			tempevent="blur";//默认事件
		}
		//alert("id:"+node.id+"\nevent:"+node.callevent+"\nmessage:"+node.msg+"\nstyle:"+node.style+"\ncss:"+node.css);
		var temp=node.method;
		//alert(temp);
		//temp(node);
		Event.observe(node.id,tempevent,function(){eval('temp(node)');},false);
		//alert(tempevent);
		
		
	};
	MulitMethod=function(node)
	{
		var methods=node.method.split('-');
	}

CheckResult=function(nodes,form)
	{
		
		nodes.each
		(function(node)
		{
			var temp=node.method;
			//alert(temp);
			eval('temp(node)');
		}
		);
		
		if(validSuccess>0)
		{
			
			//alert("begin stop event");
			Event.stop(form);
		}
		//alert(validSuccess);
		//window.document.title=validSuccess;
    	return	validSuccess==0;		
	};
	
	
	Require=function(node)
	{
		CommonRegex(node,0);
		
	};
	NeedNumber=function(node)
	{
		CommonRegex(node,1);	
	};
	NeedDate=function(node)
	{
		CommonRegex(node,2);		
	};
	NeedMobile=function(node)
	{
		CommonRegex(node,3);
	};
	NeedIp=function(node)
	{
		CommonRegex(node,4);
	};
	NeedPhone=function(node)
	{
		CommonRegex(node,5);
	};
	NeedAlpha=function(node)
	{
		CommonRegex(node,6);
	};
	NeedChinese=function(node)
	{
		CommonRegex(node,7);
	};
	NeedAlphaNum=function(node)
	{
		CommonRegex(node,8);
	};
	NeedEmail=function(node)
	{
		CommonRegex(node,9);
	};
	NeedUrl=function(node)
	{
		CommonRegex(node,10);
	};
	NeedPhoneOrTel=function(node)
	{
		CommonRegex(node,15);
	};
	NeedFloatOrInt=function(node)
	{
		CommonRegex(node,16);
	};
	NeedSelected=function(node)
	{
		var index=11;
		var obj=$(node.id);
		if(!node.message)
		{
			node.message=commonRules.message[index].message;
		}
		node.callevent="click";
		var result=!(obj.selectedIndex==0);
		if(result)
		{
		
			ValidationMsg.RemoveError(node);
		}
		else
		{
			ValidationMsg.AttachError(node);
		}
	};
	NeedSelectMore=function(node)
	{
		var index=12;
		var obj=$(node.id);
		if(!node.message)
		{
			node.message=commonRules.message[index].message;
			node.message+="{0}{1}";
		}
		node.callevent="click";
		var hasSelected = 0;			
		for(var i=obj.options.length-1;i>=0;i--)
		{
			var opt =obj[i];
			if(opt.selected) 
			{
				hasSelected++;
			}
		}
		var result=true;
		//alert(node.id);
		if(node.minvalue)
		{		
			node.message=node.message.replace("{0}"," 大于"+minvalue);
			result=result&&(hasSelected>=node.minvalue);
		}
		else
		{
			node.message=node.message.replace("{0}","");
		}
		if(node.maxvalue)
		{
			node.message=node.message.replace("{1}"," 小于"+maxvalue);	
			result=result&&(hasSelected<=node.minvalue);
		}
		else
		{
			node.message=node.message.replace("{1}","");
		}
		if(result)
		{
		
			ValidationMsg.RemoveError(node);
		}
		else
		{
			ValidationMsg.AttachError(node);
		}
		
		
	};
	CheckRange=function(node)
	{
		var index=13;
		var obj=$(node.id);
		if(!node.message)
		{
			node.message=commonRules.message[index].message;
			node.message+="{0}{1}";
		}
		node.callevent="click";
		var hasChecked=0;
		var   l;
		l=obj.length;  
		alert("Check的长度为:"+l);
		for(i=0;i<l-2;i++)
		{
			if(eval('document.all.'+node.id+'_'   +   i).checked)
			{
				hasChecked++;
			}
		}
		node.callevent="click";
		var result=true;
		if(node.minvalue)
		{		
			node.message=node.message.replace("{0}"," 大于"+minvalue);
			result=result&&(hasChecked>=node.minvalue);
		}
		else
		{
			node.message=node.message.replace("{0}","");
		}
		if(node.maxvalue&&result)
		{
			node.message=node.message.replace("{1}"," 小于"+maxvalue);
			result=result&&(hasChecked<=node.minvalue);
		}
		else
		{
			node.message=node.message.replace("{1}","");
		}
		if(result)
		{
		
			ValidationMsg.RemoveError(node);
		}
		else
		{
			ValidationMsg.AttachError(node);
		}
	};
	NeedRadio=function(node)
	{
		var index=14;
		var obj=$(node.id);
		if(!node.message)
		{
			node.message=commonRules.message[index].message;
		}
		node.callevent="click";
		var hasChecked=0;
		var   l;
		l=obj.length;  
		for(i=0;i<l-2;i++)
		{
			if(eval('document.all.'+node.id+'_'   +   i).checked)
			{
				hasChecked++;
				break;
			}
		}
		var result=(hasChecked>0);
		if(result)
		{
		
			ValidationMsg.RemoveError(node);
		}
		else
		{
			ValidationMsg.AttachError(node);
		}
	};
	
	
	CommonRegex=function(node,index)
	{
		var obj=$(node.id);
		//alert(node.message);
		if(!node.message)
		{
			//alert(index);
			node.message=commonRules.message[index].message;
			node.message+="{0}{1}{2}{3}";
		}
		
		//alert(node.message);
		var reg=commonRules.message[index].regex;
		//alert(node.boolnull);
		if(node.boolnull)//允许为空，当为空的时候不进行匹配
		{
			
			if(obj.value.trim()!="")
			{
				LogicRegex(node,obj,reg);			
			}
			else
			{
				ValidationMsg.RemoveError(node);		
			}
		}
		else//不允许为空
		{
			
			LogicRegex(node,obj,reg);
			
		}
	};
	
	LogicRegex=function(node,obj,reg)
	{
		var minvalue=node.minvalue;
		var maxvalue=node.maxvalue;
		var minlength=node.minlength;
		var maxlength=node.maxlength;
		var result=false;
		result=reg.test(obj.value.trim());
		//alert(minvalue);
		if(minvalue)
		{
			var temp=parseInt(obj.value.trim());
			node.message=node.message.replace("{0}"," 必须大于"+minvalue);
			result=result&&(temp>=minvalue);
			//alert(result);
		}
		else
		{
			node.message=node.message.replace("{0}","");
		}
		if(maxvalue)
		{
			var temp=parseInt(obj.value.trim());
			node.message=node.message.replace("{1}"," 必须小于"+maxvalue);
			result=result&&(temp<=maxvalue);
		}
		else
		{
			node.message=node.message.replace("{1}","");
		}
		if(minlength)
		{
			var temp=obj.value.trim().length;
			node.message=node.message.replace("{2}"," 长度大于"+minlength);
			result=result&&(temp>=minlength);
		}
		else
		{
			node.message=node.message.replace("{2}","");
		}
		if(maxlength)
		{
			var temp=obj.value.trim().length;
			node.message=node.message.replace("{3}"," 长度小于"+maxlength);
			result=result&&(temp<=maxlength);
		}
		else
		{
			node.message=node.message.replace("{3}","");
		}
		if(result)
		{
		
			ValidationMsg.RemoveError(node);
		}
		else
		{
			ValidationMsg.AttachError(node);
		}
		
	};

	

	
	