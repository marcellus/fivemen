//扣留收缴物品处理


var klwps=new Array(100);
var sjwps=new Array(100);
var klwp_len=0;
var sjwp_len=0;
var klwp_index=0;
var klwpcurrRowIndex = 0;
var sjwpcurrRowIndex = 0;

function add_row(val,wpmc)
{
  var tablename;
  var v_len;
  if(val=="1"){
  	//扣留物品
  	tablename="klwptable";
  	v_len=klwp_len;
  	for(i=0;i<document.all["cqzcslx"].item.length;i++){
  		if(document.all["cqzcslx"].item(i).value=="9"){
  			if(document.all["cqzcslx"].item(i).checked==false){
  				alert("没有选择采取“其他”强制措施类型，不能输入其他扣留物品名称！");
  				return;
  			}
  		}
  	}
  }else{
  	//收缴物品
  	tablename="sjwptable";
  	v_len=sjwp_len;
  	for(i=0;i<document.all["cqzcslx"].item.length;i++){
  		if(document.all["cqzcslx"].item(i).value=="5"){
  			if(document.all["cqzcslx"].item(i).checked==false){
  				alert("没有选择采取“收缴物品”强制措施类型，不能输入收缴物品名称！");
  				return;
  			}
  		}
  	}
  }
  var oTable;
  var arrCell;
  oTable=document.getElementById(tablename);
  for(var i=1;i<oTable.rows.length;i++){
  	arrCell = oTable.rows[i].cells;
  	if(arrCell[1].firstChild.firstChild.value==""){
  		alert("当前的其他物品名称输入框为空时，不能继续增加！");
  		return;
  	}
  }
  oTr=oTable.insertRow(oTable.rows.length);
  oTd = oTr.insertCell(0);  
  oTd.onclick=function(){findCodelist(this,val);} ;
  oTd.className="list_head";
  oTd.align="center";
  oEmlement=document.createElement("div");
  oEmlement.innerHTML = ""+(v_len+1);
  oTd.appendChild(oEmlement);
  oTd = oTr.insertCell(1);
  oTd.onclick=function(){findCodelist(this,val);} ;
  oEmlement=document.createElement("div");
  var curvalue;
  if(wpmc){
  	curvalue=wpmc;
  }else{
  	curvalue='';
  }
  oEmlement.innerHTML = "<input type='text' class='god6' maxlength='64' value='"+curvalue+"' style='width:100%' >";
  oTd.appendChild(oEmlement);
  if(val=="1"){
  	//扣留物品
  	klwp_len=parseInt(klwp_len)+1;
  	klwpcurrRowIndex=klwp_len;
  	//oTable.rows[klwp_len].cells[1].focus();
  }else{
  	//收缴物品
  	sjwp_len=parseInt(sjwp_len)+1;
  	sjwpcurrRowIndex=sjwp_len;
  	//oTable.rows[sjwp_len].cells[1].focus();
  }
  showcolor(val);
}

function showcolor(val)
{
  var tablename = (val==1)?"klwptable":"sjwptable";
  var currindex = (val==1)?klwpcurrRowIndex:sjwpcurrRowIndex;
  var objTable =document.getElementById(tablename);
  for(var i=1;i<objTable.rows.length;i++)
  {
    if(i==currindex)
    {
      objTable.rows[i].cells[0].className="list_body_over";
      //objTable.rows[i].cells[0].bgColor = "#cdcdcd";      
    }else{
    //objTable.rows[i].cells[0].bgColor = "white";
          objTable.rows[i].cells[0].className="list_head";
    }
  }
}

function findCodelist(oTd,val)
{
  var oTr=oTd.parentElement;
  var objTable = oTr.parentElement;
  refreshArr(val);
  for(var i=1;i<objTable.rows.length;i++)
  	objTable.rows[i].cells[0].className="list_head";
    oTr.style.cursor = "hand"; 
    oTr.cells[0].className="list_body_over";
  if(val=="1"){
  	klwpcurrRowIndex = oTr.rowIndex;
  }else{
  	sjwpcurrRowIndex = oTr.rowIndex;
  }
}

function refreshArr(val)
{
  var tablename = (val==1)?"klwptable":"sjwptable";
  var oTable,arrCell;
  oTable=document.getElementById(tablename);
  for(i=1;i<=oTable.rows.length-1;i++)
  {
    arrCell = oTable.rows[i].cells;
    if(val=="1"){
    	klwps[i-1]=new Array(2);
	    klwps[i-1][0]=i;;
	    klwps[i-1][1]=arrCell[1].firstChild.firstChild.value;
    }else{
    	sjwps[i-1]=new Array(2);
	    sjwps[i-1][0]=i;;
	    sjwps[i-1][1]=arrCell[1].firstChild.firstChild.value;
    }
  }
  if(val=="1"){
  	klwp_len=oTable.rows.length-1;
  }else{
  	sjwp_len=oTable.rows.length-1;
  }
}

function del_row(val)
{
  var tablename = (val==1)?"klwptable":"sjwptable";
  var objTable = document.getElementById(tablename);
  var currRowIndex=(val=="1"?klwpcurrRowIndex:sjwpcurrRowIndex);
  if(objTable.rows.length==1 || currRowIndex==0)
  {
    alert("请选择你想要删除的行!!!");
    return;
  }
  if(confirm("确定删除?"))
  {
    objTable.deleteRow(currRowIndex);
    if(val=="1"){
    	klwpcurrRowIndex=0;
    }else{
    	sjwpcurrRowIndex=0;
    }
  }else{
    return;
  }
  refreshArr(val);
  refreshTable(val);
}

function refreshTable(val){
  //表格
  var tablename = (val==1)?"klwptable":"sjwptable";
  oTable=document.getElementById(tablename);
  while(oTable.rows.length>1){
  	oTable.deleteRow(1);
  }
  var len=val=="1"?klwp_len:sjwp_len;
  var htmlstr="";
  for(var i=0;i<len;i++){
    oTr=oTable.insertRow(oTable.rows.length);
    oTd = oTr.insertCell(0);
  oTd.className="list_head";
  oTd.align="center";
    oTd.onclick=function(){findCodelist(this,val);} ;
    oEmlement=document.createElement("div");
    oEmlement.innerHTML =""+(i+1);
    oTd.appendChild(oEmlement);
    oTd = oTr.insertCell(1);
    //oTd.bgColor = "white";
  oTd.className="list_head";
  oTd.align="center"; 
    oTd.onclick=function(){findCodelist(this,val);};
    oEmlement=document.createElement("div");
    if(val=="1"){
    	htmlstr= "<input type='text' class='text_12' maxlength='64' value='"+klwps[i][1]+"' style='width:98%' >";
    }else{
    	htmlstr= "<input type='text' class='text_12' maxlength='64' value='"+sjwps[i][1]+"' style='width:98%' >";
    }
    oEmlement.innerHTML = htmlstr;
    oTd.appendChild(oEmlement);
  }
}
function test_row(){
	refreshArr("1");
	refreshArr("2");
	if(getklqtwp()==1){
		var klwpstr=document.all["klqtwpmc"].value;
		alert("klwpstr="+klwpstr);
	}
	if(getsjqtwp()==1){
		var sjwpstr=document.all["sjqtwpmc"].value;
		alert("sjwpstr="+sjwpstr);
	}
}
var delimiter1 = "|";
var delimiter2 = "~";
var delimiter3 = "#";

function getklwp(){
	refreshArr("1");
	var strklwp="";
	for(i=0;i<klwp_len;i++){
		if(klwps[i][1].indexOf(delimiter3)>=0){
			alert("输入的其他扣留物品名称中包括非法字符“"+delimiter3+"”！");
			return 0;
		}
		strklwp=strklwp+delimiter3+klwps[i][1];
	}
	if(strklwp.length>0){
		document.all["klqtwpmc"].value=strklwp.substr(1);
	}
	return 1;
}

function getsjwp(){
	refreshArr("2");
	var strsjwp="";
	var hasqtsjxm="0";
	for(i=0;i<sjwp_len;i++){
		if(sjwps[i][1].indexOf(delimiter3)>=0){
			alert("输入的其他收缴物品名称中包括非法字符“"+delimiter3+"”！");
			return 0;
		}
		if(sjwps[i][1].indexOf(delimiter2)>=0){
			alert("输入的其他收缴物品名称中包括非法字符“"+delimiter2+"”！");
			return 0;
		}
		strsjwp=strsjwp+delimiter1+"9"+delimiter2+sjwps[i][1];
	}
	if(strsjwp.length>0){
		document.all["sjqtwpmc"].value=strsjwp.substr(1);
		hasqtsjxm="1";
	}
	var sjxmmcstr="";
	var sjxmstr="";
	//组合收缴项目和其后的物品名称
	for(i=0;i<document.all["csjxm"].item.length;i++){
		if(document.all["csjxm"].item(i)&&document.all["csjxm"].item(i).checked==true){
			sjxmstr=sjxmstr+document.all["csjxm"].item(i).value;
			if(document.all["csjxmmc"+i].value!=""){
				sjxmmcstr=sjxmmcstr+delimiter1+document.all["csjxm"].item(i).value+delimiter2+document.all["csjxmmc"+i].value;
			}
		}
	}
	if(hasqtsjxm=="1"){
		sjxmstr=sjxmstr+"9";
		document.all["sjqtwpmc"].value=document.all["sjqtwpmc"].value+sjxmmcstr;
	}else{
		if(sjxmmcstr.length>0){
			document.all["sjqtwpmc"].value=sjxmmcstr.substr(1);
		}
	}
	document.all["sjxm"].value=sjxmstr;
	return 1;
}
function changesjxm(v){
	for(i=0;i<document.all["cqzcslx"].item.length;i++){
  		if(document.all["cqzcslx"].item(i).value=="5"){
  			if(document.all["cqzcslx"].item(i).checked==false){
  				for(j=0;j<document.all["csjxm"].item.length;j++){
  					if(document.all["csjxm"].item(j)){
	  					document.all["csjxm"].item(j).checked=false;
	  					document.all["csjxmmc"+j].readOnly=true;
						document.all["csjxmmc"+j].value="";
					}
  				}
  				alert("没有选择采取“收缴物品”强制措施类型，不能选择收缴项目！");
  				return;
  			}
  		}
  	}
	if(document.all["csjxm"].item(v).checked==true){
		document.all["csjxmmc"+v].readOnly=false;
	}
	else{
		document.all["csjxmmc"+v].readOnly=true;
		document.all["csjxmmc"+v].value="";
	}
}

function setKlsj(val){
	var temstr="";
	if(val=="1"){
		//扣留物品
		temstr=document.all["klqtwpmc"].value;
	}else{
		temstr=document.all["sjqtwpmc"].value;
	}
	var temArr=temstr.split('|');
	var temsubArr;
	for(var i=0;i<temArr.length;i++){
		temsubArr=temArr[i].split('~');
		if(temsubArr.length==2){
			if(temsubArr[0]=="9"){
				//其他物品名称，直接增加行
				add_row(val,temsubArr[1]);
			}else{
				if(val=="2"){
					//属于收缴项目
					for(var j=0;j<document.all["csjxm"].item.length;j++){
						if(document.all["csjxm"].item(j)){
							if(document.all["csjxm"].item(j).value==temsubArr[0]){
								document.all["csjxm"].item(j).checked=true;
								document.all["csjxmmc"+j].readOnly=false;
								document.all["csjxmmc"+j].value=temsubArr[1];
							}
						}
					}
				}
			}
		}
	}
}