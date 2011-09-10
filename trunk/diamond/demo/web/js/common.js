var _popUp; 
var _controlPrm1;
var _controlPrm2;
var _mouseScreenX;
var _mouseScreenY;
//writer:piwx
//begin
function ClearTextBox()
{
	for(i=0;i<document.all.length;i++)
	{
		if(document.all(i).type == "text" || document.all(i).type == "textarea" && document.all(i).value != "")
		{
			document.all(i).value = "";					
		}
	}
}

//document.oncontextmenu=function() {window.event.returnValue=false;}

function Jtrim(str)
{

        var i = 0;
        var len = str.length;
        if ( str == "" ) return( str );
        j = len -1;
        flagbegin = true;
        flagend = true;
        while (( flagbegin == true) && (i< len))
        {
           if ( str.charAt(i) == " " )
                {
                  i=i+1;
                  flagbegin=true;
                }
                else
                {
                        flagbegin=false;
                }
        }

        while  ((flagend== true) && (j>=0))
        {
            if (str.charAt(j)==" ")
                {
                        j=j-1;
                        flagend=true;
                }
                else
                {
                        flagend=false;
                }
        }

        if ( i > j ) return ("");

        trimstr = str.substring(i,j+1);
        return trimstr;
}

function OpenModalDialog(path,width,height,ObjName,ObjID,cSplit)
{
	var returnValue=window.showModalDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	if(returnValue != null)
	{
		var arr = returnValue.split(cSplit);
		ObjName.value = arr[0];
		ObjID.value = arr[1];
	}
}

function AskConfirm(msg)
{
	if(!confirm(msg))
	{
		return false;
	}
}
//end
function MouseClickHandler()
{
	_mouseScreenX = window.event.screenX;
	_mouseScreenY = window.event.screenY;
}

function OpenCalendar(pathName, id, postBack)
{
	var left = _mouseScreenX;
	var top = _mouseScreenY;
	var width = 170;
	var height = 240;
	var toleranceX = 10;
	var toleranceY = 20;
	var maxRight = window.screen.width - width - toleranceX;
	var maxBottom = window.screen.height - height - toleranceY;
	
	if (left >= maxRight)
		left = maxRight;

	if (top >= maxBottom)
		top = maxBottom;

	eval('var theForm = document.forms[0]' + ';');
	_popUp = window.open(pathName + '../Common/Calendar.aspx?formName=' + theForm.name +
		'&id=' + id + '&selected=' + theForm.elements[id].value + '&postBack=' + postBack,
		'opencal', 
		'width=' + width + ',height=' + height + ',left=' + left + ',top=' + top);
}

function OpenCombinSearchDialog(path)
{
	var win;
	if (window.showModelessDialog){
	win=window.showModelessDialog(path,this,"dialogwidth:580px;dialogheight:230px;center:1;help:0;status:0;"); 
	//win=window.showModelessDialog("/common/printManager.htm",arrArgus,"dialogwidth:7;dialogtop:100;dialogleft:"+(window.screen.width-150)+";dialogheight:230px;help:0;status:0;"); 
	}
	else{
	win=window.open(path,"dialog","height=250px,width=580px,top=" + (window.screen.height-180)/2 + ",left="+(window.screen.width-580)/2+",scrollbars=no,resizable=no");
	}
}

function NumericValidate(itemfield){
	if (document.all){
  		k=window.event.keyCode
        if ((k>57) || (k<48 && (k!=45 && k!=46))){
		  return false;
		  }
  }
	if (document.layers){
		k=DownEvents.which
        if ((k>57) || (k<48 && (k!=45 && k!=46))){
		  return false;
		  }
		}		
}

function TelNumValidate()  //数字和"-"
{
	if (document.all){
  		k=window.event.keyCode
  		if ((k>57 && k!=95) || (k<48 && k!=45)){
		  return false;
		  }
  }
	if (document.layers){
		k=DownEvents.which
  		if ((k>57 && k!=95) || (k<48 && k!=45)){
		  return false;
		  }
		}	
}

function OpenSizeDialog(path,width,height)
{
	var win;
	if (window.showModelessDialog){
	win=window.showModelessDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	//win=window.showModelessDialog("/common/printManager.htm",arrArgus,"dialogwidth:7;dialogtop:100;dialogleft:"+(window.screen.width-150)+";dialogheight:230px;help:0;status:0;"); 
	}
	else{
	win=window.open(path,"dialog","height=" + height + "px,width=" + width + "px,top=" + (window.screen.height-height)/2 + ",left="+(window.screen.width-width)/2+",scrollbars=no,resizable=no");
	}
}

function OpenRefreshSizeDialog(path,width,height)
{
	var win;
	if (window.showModalDialog){
	win=window.showModalDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	//win=window.showModelessDialog("/common/printManager.htm",arrArgus,"dialogwidth:7;dialogtop:100;dialogleft:"+(window.screen.width-150)+";dialogheight:230px;help:0;status:0;"); 
	window.execScript("__doPostBack('DialogRefresh', '')","JavaScript");
	}
	else{
	win=window.open(path,"dialog","height=" + height + "px,width=" + width + "px,top=" + (window.screen.height-height)/2 + ",left="+(window.screen.width-width)/2+",scrollbars=no,resizable=no");
	}
}

function OpenNoReturnDialog(path,width,height,isPostback,postCtlName)
{
	//var win;
	if (window.showModalDialog){
	var retval=window.showModalDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	
	if(retval!="" && retval!=null )
	 {
		if(isPostback == true)		
		window.execScript("__doPostBack('" + postCtlName + "', '" + retval + "')","JavaScript");
	 } 
	 else
	 {
		//if(isPostback == true && oldID!=idCtl.value)		
		//window.execScript("__doPostBack('DialogUpdate', '" + retval + "')","JavaScript");
	 }
	}
	else{
	alert("please update your IE version");
	//win=window.open(path,"dialog","height=" + height + "px,width=" + width + "px,top=" + (window.screen.height-height)/2 + ",left="+(window.screen.width-width)/2+",scrollbars=no,resizable=no");
	}
}

function OpenReturnNameIDSizeDialog(path,width,height,nameCtl,idCtl,isPostback)
{
	//var win;
	if (window.showModalDialog){
	var retval=window.showModalDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	
	if(retval!="" && retval!=null )
	 {
		var val_array=retval.split("^");
		nameCtl.value = val_array[0];
		var oldID = idCtl.value;
		idCtl.value = val_array[1];
		if(isPostback == true && oldID!=idCtl.value)		
		window.execScript("__doPostBack('DialogUpdate', '" + retval + "')","JavaScript");
	 } 
	 else
	 {
		nameCtl.value = "";
		var oldID = idCtl.value;
		idCtl.value = "";
		if(isPostback == true && oldID!=idCtl.value)		
		window.execScript("__doPostBack('DialogUpdate', '" + retval + "')","JavaScript");
	 }
	}
	else{
	alert("please update your IE version");
	//win=window.open(path,"dialog","height=" + height + "px,width=" + width + "px,top=" + (window.screen.height-height)/2 + ",left="+(window.screen.width-width)/2+",scrollbars=no,resizable=no");
	}
}

function OpenReturnNameIDDataSizeDialog(path,width,height,nameCtl,idCtl,dataCtl,isPostback)
{
	//var win;
	if (window.showModalDialog){
	var retval=window.showModalDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	//alert(retval);
	
	if(retval!="" && retval!=null && retval!="undefined")
	 {
		var val_array=retval.split("^");
		
		if(nameCtl != "" && nameCtl!=null && nameCtl != "undefined")
		nameCtl.value = val_array[0];
		
		var oldID = "";
		var newID = val_array[1];
		if(idCtl != "" && idCtl!=null && idCtl != "undefined")
		{
			oldID = idCtl.value;
			idCtl.value = val_array[1];
		}
		
		if(dataCtl != "" && dataCtl!=null && dataCtl != "undefined")
		{
			if(val_array.length>2)
			{
			dataCtl.value = val_array[2];
			}
			else
			{
			dataCtl.value = "";
			}
		}
		if(isPostback == true && oldID!=newID)		
		window.execScript("__doPostBack('DialogUpdate', '" + retval + "')","JavaScript");
	 }
	 else
	 {
 		if(nameCtl != "" && nameCtl!=null && nameCtl != "undefined")
		nameCtl.value = "";
		
		var oldID = "";
		var newID = "";
		if(idCtl != "" && idCtl!=null && idCtl != "undefined")
		{
			oldID = idCtl.value;
			idCtl.value = "";
		}
	
		if(dataCtl != "" && dataCtl!=null && dataCtl != "undefined")
		dataCtl.value = "";
		if(isPostback == true && oldID!=newID)		
		window.execScript("__doPostBack('DialogUpdate', '" + retval + "')","JavaScript");
	 }
	}
	else{
	alert("please update your IE version");
	//win=window.open(path,"dialog","height=" + height + "px,width=" + width + "px,top=" + (window.screen.height-height)/2 + ",left="+(window.screen.width-width)/2+",scrollbars=no,resizable=no");
	}
}

function OpenSizeModelDialog(path,width,height)
{
	var win;
	if (window.showModalDialog){
	win=window.showModalDialog(path,'dialog',"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 
	//win=window.showModelessDialog("/common/printManager.htm",arrArgus,"dialogwidth:7;dialogtop:100;dialogleft:"+(window.screen.width-150)+";dialogheight:230px;help:0;status:0;"); 
	}
	else{
	win=window.open(path,"dialog","height=" + height + "px,width=" + width + "px,top=" + (window.screen.height-height)/2 + ",left="+(window.screen.width-width)/2+",scrollbars=no,resizable=no");
	}
}

function SetValue(formName, id, newValue, postBack)
{
	eval('var theForm = document.' + formName + ';');
	_popUp.close();
	
	theForm.elements[id].value = newValue;
	
	if (postBack)
		__doPostBack(id,'');
}		

function SetValueWithPostBackID(formName, id, newValue, postBack)
{
	eval('var theForm = window.opener.document.' + formName + ';');
	
	theForm.elements[id].value = newValue;
	
	if (postBack)
		window.opener.__doPostBack(id,'');

	window.self.close();
}		

function SetValueWithConfirm(confirmMessage, formName, id, postBack)
{
	eval('var theForm = window.opener.document.' + formName + ';');
	
	var confirmValue = window.self.confirm(confirmMessage);
	
	if (confirmValue)
		theForm.elements[id].value = '1';
	else
		theForm.elements[id].value = '0';
		
	window.self.close();
	
	if (postBack)
		window.opener.__doPostBack(id,'');
}		

function document.onkeydown(){
    var k=event.keyCode;
    if(((event.ctrlKey)&&(k==82))||(k==116)) //78=N, 82=R,116=F5
    {
        event.keyCode=0;
        event.returnValue=false;
    }
    
    if((event.ctrlKey)&&(k==78))
    {
		event.keyCode=0;
        event.returnValue=false;

        try
        {
			//alert(window.location.href);
			openUrl("",window.location.href);
        }
        catch(e)
        {
        }
    }
    
    if((event.ctrlKey)&&k==75)
    {
        try{
            DoCtrlK();
        }catch(e) { }
    }
}


function RefreshWindowOpener() 
{
	window.opener.location = window.opener.location;
}

function CloseWindow()
{
	self.close();
}

function CloseWindowPostBack()
{
	window.opener.__doPostBack('','');
	self.close();
}


function TextCounter(field, maxlimit) 
{
	// if too long...trim it!
	if (field.value.length > maxlimit) 
	field.value = field.value.substring(0, maxlimit);
}

function areaLength(areaCtl,length){
	if (areaCtl.value.length>=length)
	{
		//alert("超出最大长度" + length + "字符");
		return false;
	}
	else
	{
		return true;
	}
}

function FormatNumber(t) 
{
	t = t.replace(/[^0-9\.\-]/g,"");
	var n = t;
	return n;
}

function FormatPositiveNumber(t) 
{
	t = t.replace(/[^0-9\.]/g,"");
	var n = t;
	return n;
}

function FormatInteger(t) 
{
	t = t.replace(/[^0-9]/g,"");
	var n = t;
	return n;
}

function FormatCurrency(t) 
{
	t = t.replace(/[^0-9\.\$]/g,"");
	var n = t;
	return n;
}

function FormatTelNo(t) 
{
	t = t.replace(/[^0-9\+\-]/g,"");
	var n = t;
	return n;
}

function FormatDate(e,inp) 
{
	var k = e.keyCode
	if ((k>=37)&&(k<=40)) return;
	if ((k==8)||(k==46)) return;
	var d = inp.value;
	d = d.replace(/[^0-9]/g,"");
	var n = d;
	if (d.length>=2) n = d.substr(0,2)+"/"+d.substr(2,2);
	if (d.length>=4) n+= "/"+d.substr(4,4);
	inp.value = n;
}

function FormatGrade(e,inp) 
{
	var i = inp.value;
	if (i.length<=3)
	{
		var k = e.keyCode
		if ((k>=37)&&(k<=40)) return;
		if ((k==8)||(k==46)) return;
		var d = inp.value;
		d = d.replace(/[^0-9]/g,"");
		var n = d;
		if (d.length>=2) n = d.substr(0,2)+"/"+d.substr(2,2);
		inp.value = n;
	}
}


function ValidDecimal(d) 
{
	var re = /^([0-9]*|\d*\.\d{1}?\d*)$/
	return re.test(d)  
}

function CheckDecimal(inp) 
{
	if ((ValidDecimal(inp.value)) || (inp.value == '')) return;
	alert("Value entered invalid - " +inp.value);
	inp.focus();
	inp.select();
	inp.value = "";
}

function ValidGrade(inp) 
{
	var d = inp.substr(0,2);
	var re = /^[1-9]+[0-9]*$/
	return re.test(d)  
}

function CheckGrade(inp) 
{
	if ((ValidGrade(inp.value)) || (inp.value == '')) return;
	alert("Grade should be between 10 and 99 - " +inp.value);
	inp.focus();
	inp.select();
	inp.value = "";
}


function ValidDate(d) 
{
	var re = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/ 
	return re.test(d)  
}

function CheckDate(inp) 
{
	if ((ValidDate(inp.value)) || (inp.value == '')) return;
	alert("Date is not valid - " +inp.value);
	inp.focus();
	inp.select();
	inp.value = "";
}

function CleanString(e, inp) 
{
/*
	// Clean off string < > \ | " '
	var isNS4 = (navigator.appName=="Netscape")?1:0;
	
	if(!isNS4)
	{
		if (e.keyCode == 34 || e.keyCode == 39 || e.keyCode == 60 || e.keyCode == 62 || e.keyCode == 92 || e.keyCode == 124) 
			e.returnValue = false;
	}
	else
	{
		if (e.which == 34 || e.which == 39 || e.which == 60 || e.which == 62 || e.which == 92 || e.which == 124) 
			return false;
	}
*/
  return true;
}

function ProcessCheckBoxSelection(chkVal, idVal, cbxAll, cbxItem, hdnAll, hdnItem, hdnList)
{
	var cbxAllIndex;
	var hdnAllIndex;
	var hdnListIndex;
	var frm = document.forms[0];
	var list;

	for (i=0; i<frm.length; i++)
	{
		if (frm.elements[i].id.indexOf(cbxAll) != -1)
			cbxAllIndex = i;

		if (frm.elements[i].id == hdnAll)
			hdnAllIndex = i;

		if (frm.elements[i].id == hdnList)
		{
			frm.elements[i].value = '';
			hdnListIndex = i;
			list = frm.elements[i];
		}
	}
	
	// Loop through all elements
	for (i=0; i<frm.length; i++)
	{
		// Look for header template checkbox
		if (idVal.indexOf(cbxAll) != -1)
		{
			if (frm.elements[i].id == hdnAll)
			{
				if (chkVal == true)
					frm.elements[i].value = 'All';
				else
					frm.elements[i].value = '';
			}
						
			// Check if main checkbox is checked, then select or deselect datagrid checkboxes
			if (frm.elements[i].id.indexOf(cbxItem) != -1)
			{
				if (chkVal == true)
				{
					frm.elements[i].checked = true;
					if (list == '')
						list += frm.elements[i+1].value;
					else
						list += "|" + frm.elements[i+1].value; 
				}
				else
					frm.elements[i].checked = false;
			}
		}
		else
		// Look for item template multiple checkbox
		if (idVal.indexOf(cbxItem) != -1)
		{
			// Check if any of the checkboxes are not checked
			// Uncheck top select all checkbox
			if (frm.elements[i].checked == false)
			{
				frm.elements[hdnAllIndex].value = '';
				frm.elements[cbxAllIndex].checked = false;
			}
			else
			{
				if (list == '')
					list += frm.elements[i+1].value;
				else
					list += "|" + frm.elements[i+1].value; 
			}
		}
	}
}

function ProcessCheckBoxConfirm(frm, cbxItem, msg1, msg2)
{
	var message = msg2;
	// Loop through all elements
	for (i=0; i<frm.length; i++)
	{
		if (frm.elements[i].name.indexOf(cbxItem) != -1)
		{
			// If any are checked, then confirm alert, otherwise non-confirm alert
			if (frm.elements[i].checked)
				message = msg1;
		}
	}
	
	return confirm(message);
}


function displayPageControl(oTB,oLab){
  var i = parseInt(oTB.rows(1).cells.length/2);

  oTB.rows(0).insertCell(0);
  oTB.rows(0).cells(0).noWrap    = true;
  oTB.rows(0).cells(0).colSpan   = i;
  oTB.rows(0).cells(0).align     = "left";
  oTB.rows(0).cells(0).innerHTML = oLab.innerHTML;
  oLab.style.display             = "none";
  oTB.rows(0).cells(1).colSpan   = oTB.rows(1).cells.length - i;
}	

/*
  PathName : Virtual Dirctory
  TextBox  : dispaly date's textbox
  Refresh  : Yes or No
  All      : Yes or no
  Left     : the form left position
  Top      : the form top postion
*/
function validateDate(oText){
   var sDate = BASEtrim(oText.value.toUpperCase());
   sDate = sDate.replace(".","-").replace(".","-");
	      
   if(sDate!="" && sDate!="ALL"){
      var t = Date.parse(sDate);	      
      if(isNaN(t)){
         alert("The date is invalid!");
         oText.focus();
         oText.select();
      }
   }   
}
	   	

function BASEtrim(str){ //去掉字符串两边的空格(不取掉字符串中间的空格)
	  str=str.toString()
	  lIdx=0;rIdx=str.length;
	  if (BASEtrim.arguments.length==2)
	    act=BASEtrim.arguments[1].toLowerCase();
	  else
	    act="all";
      for(var i=0;i<str.length;i++){
	  	thelStr=str.substring(lIdx,lIdx+1);
		therStr=str.substring(rIdx,rIdx-1);
        if ((act=="all" || act=="left") && thelStr==" "){
			lIdx++;
        }
        if ((act=="all" || act=="right") && therStr==" "){
			rIdx--;
        }
      }
	  str=str.slice(lIdx,rIdx);
      return str;
}

//BASE_GetRoot:通用客户端函数，获得本应用的根目录,全路径！。比如 http:\\appserver\ggms
function BASE_GetRoot(){
	var strFullPath=window.document.location.href;
	var strPath=window.document.location.pathname;
	var pos=strFullPath.indexOf(strPath);
	var prePath=strFullPath.substring(0,pos);
	var postPath=strPath.substring(0,strPath.substr(1).indexOf('\/')+1);
		
	return(prePath+postPath);
}

function BASEselectItems(objSelectSwitch ,strObjSelectItem)
{
	var blnSwitch=objSelectSwitch.checked;
	with(objSelectSwitch.form){
		if (eval("typeof(" + strObjSelectItem + ")")=="undefined") return false;
		var objSelectItem = eval(strObjSelectItem);
		if (typeof(objSelectItem.length)=="undefined"){
		    if(!objSelectItem.disabled) objSelectItem.checked = blnSwitch;
		}//if
		else{
			for(var i=0;i<objSelectItem.length;i++){
				if(!objSelectItem[i].disabled) objSelectItem[i].checked = blnSwitch;
			}//for
		}//else
	}//with
	return true;
}//func
function keySubmit(strCallFunction){
	if (document.all){
  		k=window.event.keyCode
  		if (k==13){
  		  eval(strCallFunction);
          event.keyCode=0;
          event.returnValue=false;
  		  }
  }
	if (document.layers){
		k=DownEvents.which
		if (k==13){
		  eval(strCallFunction);
          event.keyCode=0;
          event.returnValue=false;
	  	  }
		}		
}

/*
function openUrl(url)
{
	var vWidth = screen.width-10;
	var vHeight = screen.height-40 
	window.open(url,"","width=" + vWidth + ",height=" + vHeight + "top=1,left=1,scrollbars=yes,resizable=no");
}
*/
function openUrl(winName,url)
{
	var vWidth = screen.width-10;
	var vHeight = screen.height-80 
//	var vWidth = 640-10;
//	var vHeight = 480-60;
	var win = window.open(url,winName,"width=" + vWidth + ",height=" + vHeight + ",top=0,left=0,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes,status=yes"); 
	//win.focus();
}

function openUrlReturnWin(winName,url)
{
	var vWidth = screen.width-10;
	var vHeight = screen.height-80 
//	var vWidth = 640-10;
//	var vHeight = 480-60;
	var win = window.open(url,winName,"width=" + vWidth + ",height=" + vHeight + ",top=0,left=0,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes,status=yes"); 
	return win;
	//win.focus();
}


function ExitSystem(url)
{
	if(window.confirm('您确定要退出本系统吗?'))
	{
		window.location.href = url;
	}
}

function isNumeric(stringContent) 
{

  var StringContent = new String(stringContent);
  var stringLength = StringContent.length;

  if (StringContent.length == 0)
    return false;
	  
  if (isNaN(stringContent))
    return false;
  return true;	   
} 

function FixGridTitle(id)
{ 
try
{
	var scrollPos = document.body.scrollTop; 
	//obj.style.top = scrollPos;
	if(document.getElementsByTagName)
	{  
		var table = document.getElementById(id);  
		var rows = table.getElementsByTagName("tr");
		var offsetTop = table.offsetParent.offsetTop+rows[0].clientHeight+2;
		
		rows[2].style.position="relative";
		//alert(scrollPos);
		if(scrollPos>offsetTop)
		{
			rows[2].style.top = scrollPos-offsetTop;
		}
		else
		{
			rows[2].style.top = rows[0].style.bottom;
		}
	}
	}
	catch(ex)
	{
		try
		{
			window.clearTimeout(timeId);
		}
		catch(e)
		{}
	}
} 

var oldItem;
var oldStyle;

function selectGridItem(item)
{
	if(oldItem == item) return;
	
	if(item.className!='SelectRowBgColor')
	{
	    if(oldItem!=null)  
	    {
	        oldItem.className=oldStyle;
	    }
	    oldStyle=item.className;
		item.className='SelectRowBgColor';
	}
	else
	{
		item.className='';
	}
//	try
//	{
//		oldItem.className='';
//	}
//	catch(e) { }
	oldItem = item;
	
}

function selectedGridItem(item)
{
	if(item == oldItem) return;
	
	if(oldItem!=null)  
	    {
	        oldItem.className=oldStyle;
	    }
	    oldStyle=item.className;
	item.className='SelectRowBgColor';
	
	
//	try
//	{
//		oldItem.className='';
//	}
//	catch(e) { }
	oldItem = item;
}

function doHighLine(id)
{
	//alert("ok");
	try{
	var tr= eval("document.getElementById('TR" + id + "')");
	selectedGridItem(tr);
	} catch(e)
	{ //alert(e.message);
	}
}

function data_save(id,value)
{
    var objud;
    objud=document.all.objUserData;
    objud.setAttribute(id,value);
    objud.save("CIRNET");
}

function data_load(id)
{
    var objud;
    objud=document.all.objUserData;
    objud.load("CIRNET");
    objud.value=objud.getAttribute(id);
    if ((objud.value!="") && (objud.value!=null))
        return objud.value;
}
/*
document.open();
document.writeln("<IE:userData id='objUserData' style='behavior:url(#default#userData)' />");
document.close();
*/

function openPictureViewer(picPath)
{
   
    picPath=picPath.replace("&", "|");
    window.open('../Common/ViewPicture.aspx?picPath=' + picPath,'img','scrollbars=1,resizable=1');
}

function OpenColorSelector(txtID,tdCtl)
{
    /*    alert("ok");    */


    var path = "../Common/ColorPicker.htm";
    var width = "390";
    var height = "485";
    var txtCtl = document.getElementById(txtID);
    var color = txtCtl.value;
    
    var retval = window.showModalDialog(path,color,"dialogwidth:" + width + "px;dialogheight:"+ height + "px;center:1;help:0;status:0;"); 

   	if(retval!="" && retval!=null )
   	{
		txtCtl.value = retval;
        //var tdCtl = document.getElementById(tdID);
        tdCtl.bgColor= retval;
    }
}
function DecimalValid(source,value)
 {
         var   clientID,ob;  
         clientID=source.controltovalidate ;
         ob=eval("document.all."   +   clientID);
         var   re   =   /^[\-\+]?([0-9]\d*|0|[1-9]\d{0,2}(,\d{3})*)(\.\d+)?$/; 
         if(!re.test(value.Value))
         {
           //ob.className="TextBoxFlatError";
             value.IsValid = false;
             alert(source.errormessage);
             return false;
         }
         else 
         {
          // eval("document.all."   +   clientID).className="TextBoxFlat";
             value.IsValid = true;
             return true;
         }
}
function IntValid(source,value)
 {
         var   clientID,ob;  
         clientID=source.controltovalidate ;
         ob=eval("document.all."   +   clientID);
         var   re   =   /^[\-\+]?([0-9]\d*|0)$/; 
         if(!re.test(value.Value))
         {
           //ob.className="TextBoxFlatError";
             value.IsValid = false;
             alert(source.errormessage);
             return false;
         }
         else 
         {
          // eval("document.all."   +   clientID).className="TextBoxFlat";
             value.IsValid = true;
             return true;
         }
}
function UrlValid(source,value)
 {
         var   clientID,ob;  
         clientID=source.controltovalidate ;
         var   re   =  /(http[s]?|ftp):\/\/[^\/\.]+?\..+\w$/i;
         if(!re.test(value.Value))
         {
             alert(source.errormessage);
             value.IsValid = false;
         }
         else 
         {
             value.IsValid = true;
         }
}

function SetCookie(name,value) //创建cookies 
{
var Days = 30; //定义过期时间 单位：天
    var exp  = new Date();
    exp.setTime(exp.getTime() + Days*24*60*60*1000);
    document.cookie = name + "="+ escape (value) + ";expires=" + exp.toGMTString()+";path=/;"
}


function getCookie(name)    //读取cookies 
{
var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
     if(arr != null) return unescape(arr[2]); return null;}

function delCookie(name) //删除cookies
{
var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval=getCookie(name);
    if(cval!=null) document.cookie= name + "="+cval+";expires="+exp.toGMTString()+";path=/;"
}

function getXMLRequester( )
  {
    var xmlhttp_request = false;
    try
      {
        if( window.ActiveXObject )
        {
            for( var i = 5; i; i-- )
            {
                try
                {
                    if( i == 2 )
                    {
			            xmlhttp_request = new ActiveXObject( "Microsoft.XMLHTTP" );    
                    }
                    else
                    {
			            xmlhttp_request = new ActiveXObject( "Msxml2.XMLHTTP." + i + ".0" );    
			            xmlhttp_request.setRequestHeader("Content-Type","text/xml");
			            xmlhttp_request.setRequestHeader("Content-Type","gb2312");
                    }
		            break;
		        }
                catch(e)
                {                        
                    xmlhttp_request = false;
                }
            }
         }
         else if( window.XMLHttpRequest )
         {
            xmlhttp_request = new XMLHttpRequest();
            if (xmlhttp_request.overrideMimeType)
             {
                xmlhttp_request.overrideMimeType('text/xml');
             }
         }
     }
     catch(e)
     {
        xmlhttp_request = false;
     }
     return xmlhttp_request ;
    }

    function IDRequest(url) {
        xmlhttp_request=getXMLRequester();//调用创建XMLHttpRequest的函数
        xmlhttp_request.open('GET', url, true);
        xmlhttp_request.send(null);       
    } 
    function ResizeFullScreen()
    {
        window.moveTo(0,0);	
        window.resizeTo(screen.availWidth,screen.availHeight);
    }
    function EnsureConfirm()
    {
         return WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(event.srcElement.id, '', true, '','', false, false));
    }
 //千分位处理 
function sourceToN2(source)
{
try{
    if(typeof(source)!="undefined" && source.value!=""){
        source.value=ConvertToN2(ReplaceN2(source.value));
    }  
}
catch (Exception){alert("error");} 
}
//eg. "123456.236" -> "123,456.24".
function ConvertToN2(str)
{
    str = str.toString();
    var num = str;
    var dec = "";
    var left = num.length;
    var tmp = "";
	if(isNaN(str))
	{
	    return str;
	}
    if(str.indexOf(".")>0)
    {
	    num = str.substring(0,str.indexOf("."));
	    if(Number(str.substring(str.indexOf(".")+1,str.length))>0)
	    { 
	        dec = Number(str).toFixed(2);
	        dec = "."+dec.substring(dec.indexOf(".")+1,dec.length);
	    }
    }

    for(i=num.length-3;i>0;i-=3)
    {
	    tmp = "," + num.substring(i,i+3) + tmp;
	    left = i;
    }
    tmp = num.substring(0,left)+tmp;
    return tmp+dec;
	
}

function ConvertToN0(str)
{
    str = str.toString();
    var num = str;
    var dec = "";
    var left = num.length;
    var tmp = "";
	if(isNaN(str))
	{
	    return str;
	}
    if(str.indexOf(".")>0)
    {
	    num = str.substring(0,str.indexOf("."));
//	    if(Number(str.substring(str.indexOf(".")+1,str.length))>0)
//	    { 
//	        dec = Number(str).toFixed(2);
//	        dec = "."+dec.substring(dec.indexOf(".")+1,dec.length);
//	    }
    }

    for(i=num.length-3;i>0;i-=3)
    {
	    tmp = "," + num.substring(i,i+3) + tmp;
	    left = i;
    }
    tmp = num.substring(0,left)+tmp;
    return tmp;
	
}
//eg. "123,456.24" -> "123456.236".
function ReplaceN2(str)
{
    str = str.toString();
    return str.replace(/,/g,""); 	
}

function OpenEx(url){
	var id='link';
	document.write('<a id=\''+id+'\' target=blank href=# style=\'display:none;\'>link<\a>');	
	eval('var o = document.getElementById(\'link\');o.href=\''+url+'\'; o.click();');
}

function GetDateForCompare(str)
{
    var restr;
    var str1=str.toString();
    if(str1!="" && str1.length==10)
    {
        restr=str1.substring(7,11)+str1.substring(3,5)+str1.substring(0,2);
        return restr;
    }
    else
    {
        return "";
    }
}
///读取查询字符串相应参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}