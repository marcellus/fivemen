//��ӡ�����
function print_sqb(lsh,gnid)
{
    var spath="print.do?method=queryPrintSqb&lsh="+lsh+"&gnid="+gnid;
    send_request(spath,"printSqb1()",false); 
}
//��ӡ׼��֤��
function print_zkzmdddd(lsh,ptop1,left1,xmlUrl)
{
  
    var spath="print.do?method=queryPrintZkzm&lsh="+lsh;
    send_request(spath,"printZkzmd('"+xmlUrl+"','"+ptop1+"','"+left1+"')",false); 
}

//ת����¼��
function print_zccd(lsh)
{
    var spath="print.do?method=queryPrintZccd&lsh="+lsh;
    send_request(spath,"printZccddd()",false); 
}


function print_ydmfxx(lsh)
{
	 var spath="print.do?method=queryPrintYdmfxx&lsh="+lsh;
	  send_request(spath,"printYdmfxxpz()",false); 
}
function print_mfxx(lsh)
{
	 var spath="print.do?method=queryPrintMfxx&lsh="+lsh;
	  send_request(spath,"printmfxx()",false); 
}

function printSqb()
{
    var xmlDoc = _xmlHttpRequestObj.responseXML;
    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
    var gnid = xmlDoc.getElementsByTagName("gnid")[0].firstChild.data;
    var msg="";
    if(code=="1")
    {
        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
        var xb=xmlDoc.getElementsByTagName("xb_mc")[0].firstChild.data;
        var csrq=xmlDoc.getElementsByTagName("csrq")[0].firstChild.data;
        var gj=xmlDoc.getElementsByTagName("gj_mc")[0].firstChild.data;
        var sfzmmc=xmlDoc.getElementsByTagName("sfzmmc_mc")[0].firstChild.data;
        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
        var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
        var zzzm=xmlDoc.getElementsByTagName("zzzm")[0].firstChild.data;
        var yb=xmlDoc.getElementsByTagName("lxzsyzbm")[0].firstChild.data;
        var lxdh=xmlDoc.getElementsByTagName("lxdh")[0].firstChild.data;
        var zsdz=xmlDoc.getElementsByTagName("djzsxxdz")[0].firstChild.data;
        var lxdz=xmlDoc.getElementsByTagName("lxzsxxdz")[0].firstChild.data;
        var cx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
        var zzz="";
        var z0="";z1="";z2="";z3="";
        if (zzzm != null && zzzm!="--") 
        {
			zzz = "��ס֤��";
			if(zzzm.length>0)
			{
				z0=zzzm.substring(0,1);
			}
			if(zzzm.length>1)
			{
				z1=zzzm.substring(1,2);
			}
			if(zzzm.length>2)
			{
				z2=zzzm.substring(2,3);
			}		
			if(zzzm.length>3)
			{
				z3=sfzmhm.substring(3,4);
			}
		}
		var ls_ywyy=xmlDoc.getElementsByTagName("ywyy")[0].firstChild.data;
		var ls_yjszh = xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
		var ls_yzjcx = xmlDoc.getElementsByTagName("yzjcx")[0].firstChild.data;
		var ls_yfzrq = xmlDoc.getElementsByTagName("yfzrq")[0].firstChild.data;
		var ls_ly = xmlDoc.getElementsByTagName("ly")[0].firstChild.data;
		var ls_ydabh = xmlDoc.getElementsByTagName("ydabh")[0].firstChild.data;
		
		var b0="";b1="";b2="";b3="";b4="";b5="";b6="";b7="";b8="";b9="";b10="";
		    b11="";b12="";b13="";b14="";b15="";b16="";b17="";
		
		
		if(sfzmhm.length>0)
		{
			b0=sfzmhm.substring(0,1);
		}
		if(sfzmhm.length>1)
		{
			b1=sfzmhm.substring(1,2);
		}
		if(sfzmhm.length>2)
		{
			b2=sfzmhm.substring(2,3);
		}		
		if(sfzmhm.length>3)
		{
			b3=sfzmhm.substring(3,4);
		}
		if(sfzmhm.length>4)
		{
			b4=sfzmhm.substring(4,5);
		}
		if(sfzmhm.length>5)
		{
			b5=sfzmhm.substring(5,6);
		}
		if(sfzmhm.length>6)
		{
			b6=sfzmhm.substring(6,7);
		}
		if(sfzmhm.length>7)
		{
			b7=sfzmhm.substring(7,8);
		}
		if(sfzmhm.length>8)
		{
			b8=sfzmhm.substring(8,9);
		}
		if(sfzmhm.length>9)
		{
			b9=sfzmhm.substring(9,10);
		}
		if(sfzmhm.length>10)
		{
			b10=sfzmhm.substring(10,11);
		}
		if(sfzmhm.length>11)
		{
			b11=sfzmhm.substring(11,12);
		}
		if(sfzmhm.length>12)
		{
			b12=sfzmhm.substring(12,13);
		}
		if(sfzmhm.length>13)
		{
			b13=sfzmhm.substring(13,14);
		}
		if(sfzmhm.length>14)
		{
			b14=sfzmhm.substring(14,15);
		}
		if(sfzmhm.length>15)
		{
			b15=sfzmhm.substring(15,16);
		}
		if(sfzmhm.length>16)
		{
			b16=sfzmhm.substring(16,17);
		}
		if(sfzmhm.length>17)
		{
			b17=sfzmhm.substring(17,18);
		}		
		
        try
        {
    		drvprint.posX="10"
    		drvprint.posY="0"
    		var cs = "";
    		cs = "Text,sfzmhm,7.40834,28.04586,C39HrP24DhTt,24,False,*"+sfzmhm+"*,-2147483640|";
    		cs = cs + "Text,dabh,148.5876,32.80836,����,11.25,False,"+dabh+",-2147483640|";
    		cs = cs + "Text,cx,97.89593,93.39801,����,11.25,False,"+cx+",-2147483640|"
    		
    		cs = cs + "Text,zzz4,88.37092,58.50825,����,9,False,"+z3+",-2147483640|"
    		cs = cs + "Text,zzz3,84.13758,58.50825,����,9,False,"+z2+",-2147483640|"
    		cs = cs + "Text,zzz2,80.16883,58.50825,����,9,False,"+z1+",-2147483640|"
    		cs = cs + "Text,zzz1,76.20007,58.50825,����,9,False,"+z0+",-2147483640|"
    		cs = cs + "Text,sfzmhm9,108.2147,50.99408,����,9,False,"+b8+",-2147483640|"
    		cs = cs + "Text,sfzmhm18,143.1397,50.99408,����,9,False,"+b17+",-2147483640|"
    		cs = cs + "Text,sfzmhm17,139.4356,50.99408,����,9,False,"+b15+",-2147483640|"
    		cs = cs + "Text,sfzmhm16,135.7314,50.99408,����,9,False,"+b14+",-2147483640|"
    		cs = cs + "Text,sfzmhm15,131.7626,50.99408,����,9,False,"+b13+",-2147483640|"
    		cs = cs + "Text,sfzmhm14,127.7939,50.99408,����,9,False,"+b12+",-2147483640|"
    		cs = cs + "Text,sfzmhm13,123.8251,50.99408,����,9,False,"+b16+",-2147483640|"
    		cs = cs + "Text,sfzmhm12,119.8564,50.99408,����,9,False,"+b11+",-2147483640|"
    		cs = cs + "Text,sfzmhm11,115.623,50.99408,����,9,False,"+b10+",-2147483640|"
    		cs = cs + "Text,sfzmhm10,111.6543,50.99408,����,9,False,"+b9+",-2147483640|"
    		cs = cs + "Text,sfzmhm8,104.2459,50.99408,����,9,False,"+b7+",-2147483640|"
    		cs = cs + "Text,sfzmhm7,100.2772,50.99408,����,9,False,"+b6+",-2147483640|"
    		cs = cs + "Text,sfzmhm6,96.30843,50.99408,����,9,False,"+b5+",-2147483640|"
    		cs = cs + "Text,sfzmhm5,92.33968,50.99408,����,9,False,"+b4+",-2147483640|"
    		cs = cs + "Text,sfzmhm4,88.37092,50.99408,����,9,False,"+b3+",-2147483640|"
    		cs = cs + "Text,sfzmhm3,84.13758,50.99408,����,9,False,"+b2+",-2147483640|"
    		cs = cs + "Text,sfzmhm2,80.16883,50.99408,����,9,False,"+b1+",-2147483640|"
    		cs = cs + "Text,sfzmhm1,76.20007,50.99408,����,9,False,"+b0+",-2147483640|"
    		cs = cs + "Text,yb,129.646,85.4605,����,11.25,False,"+yb+",-2147483640|"
   		 	cs = cs + "Text,lxdh,27.78128,85.98967,����,11.25,False,"+lxdh+",-2147483640|"
    		cs = cs + "Text,lxdz,27.78128,76.99383,����,11.25,False,"+lxdz+",-2147483640|"
    		cs = cs + "Text,zsdz,27.78128,66.99257,����,11.25,False,"+zsdz+",-2147483640|"
    		cs = cs + "Text,zzz,28.04586,58.50825,����,11.25,False,"+zzz+",-2147483640|"
    		cs = cs + "Text,sfzmmc,28.04586,50.80005,����,11.25,False,"+sfzmmc+",-2147483640|"
    		cs = cs + "Text,xb,92.60426,41.53962,����,11.25,False,"+xb+",-2147483640|"
    		cs = cs + "Text,xm,28.04586,41.99824,����,11.25,False,"+xm+",-2147483640|"
    		cs = cs + "Text,gj,156.6335,41.53962,����,11.25,False,"+gj+",-2147483640|"
    		cs = cs + "Text,csrq,117.4751,41.53962,����,11.25,False,"+csrq+",-2147483640|"
    		cs = cs + "Text,Text94,159.2793,106.8918,����,9,False,�����ʻ֤,-2147483640|"

    		if (gnid=="0106" && (ls_ly=="E" || ls_ly=="I")){
    		    cs = cs + "Text,Text137,155.30843,106.8918,����,9,False,��,-2147483640|"
   	 		}
    		cs = cs + "Text,Text95,76.20007,106.8918,����,9,False,�侯��ʻ֤,-2147483640|"
    		cs = cs + "Text,Text96,96.30843,106.8918,����,9,False,��ۼ�ʻ֤,-2147483640|"
    		if (gnid=="0106" && ls_ly=="F"){
    		   	cs = cs + "Text,Text136,92.30843,106.8918,����,9,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text97,117.4751,106.8918,����,9,False,���ż�ʻ֤,-2147483640|"
    		if(gnid=="0106" && ls_ly=="G"){
    		   	cs = cs + "Text,Text139,113.30843,106.8918,����,9,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text98,96.30843,129.1168,����,9,False,�����ؾ�ס,-2147483640|"
    		cs = cs + "Text,Text99,138.1126,106.8918,����,9,False,̨���ʻ֤,-2147483640|"
    		if (gnid=="0106" && ls_ly=="H"){
    			cs = cs + "Text,Text138,134.30843,106.8918,����,9,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text100,76.20007,129.1168,����,9,False,����Ǩ��,-2147483640|"
    		cs = cs + "Text,Text101,55.56255,106.8918,����,9,False,���Ӽ�ʻ֤,-2147483640|"
    		cs = cs + "Text,Text102,105.8334,175.6835,����,9,False,�໤������,-2147483640|"
    		cs = cs + "Text,Text103,40.21671,182.0335,����,9,False,ί��,-2147483640|"
    		cs = cs + "Text,Text104,40.21671,175.6835,����,9,False,��������,-2147483640|"
    		cs = cs + "Text,Text105,28.57503,168.2752,����,9,False,ע��,-2147483640|"
    		if (gnid=="0105"){
    			cs = cs + "Text,Text131,24.2,168.27,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text106,28.57503,161.9252,����,9,False,��֤,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("F")>=0){
    			cs = cs + "Text,Text130,24.2,161.92,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text107,28.57503,154.5168,����,9,False,֤�����,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("G")>=0){
    			cs = cs + "Text,Text129,24.2,154.51,����,10,False,��,-2147483640|"
    		}
   	 		cs = cs + "Text,Text108,28.57503,148.1668,����,9,False,�����Ϣ�仯,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("E")>=0){
    			cs = cs + "Text,Text128,24.2,148.16,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text109,28.57503,141.2876,����,9,False,��Ը����׼��,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("D")>=0){
    			cs = cs + "Text,Text127,24.2,141.28,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text110,28.57503,135.4668,����,9,False,�ﵽ�涨����,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("C")>=0){
    			cs = cs + "Text,Text126,24.2,135.46,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text111,28.57503,129.1168,����,9,False,ת��,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("B")>=0){
    			cs = cs + "Text,Text125,24.2,129.11,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text112,28.57503,122.7668,����,9,False,��Ч����,-2147483640|"
    		if(gnid=="0103" && ls_ywyy.indexOf("A")>=0){
    			cs = cs + "Text,Text124,24.2,122.76,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text93,28.57503,113.2418,����,9,False,�־����ʻ֤,-2147483640|"
    		if(gnid=="0106"){
    			cs = cs + "Text,Text123,24.2,113.24,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text92,28.57503,106.8918,����,9,False,�־�����ʻ֤,-2147483640|"
    		if(gnid=="0104"){
    			cs = cs + "Text,Text122,24.2,106.89,����,10,False,��,-2147483640|"
     		}
    		cs = cs + "Text,Text91,28.57503,100.5418,����,9,False,����׼�ݳ���,-2147483640|"
    		if(gnid=="0102"){
    			cs = cs + "Text,Text121,24.2,100.54,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text90,28.57503,94.19176,����,9,False,��������,-2147483640|"
    		if(gnid=="0101"){
    			cs = cs + "Text,Text120,24.2,94.19,����,10,False,��,-2147483640|"
    		}
    		cs = cs + "Text,Text89,21.96044,261.0029,����,9,False,�������ݱ����������Ķ������˲��������еĲ�׼��������Ρ�,-2147483640|"
    		cs = cs + "Text,Text88,23.01877,249.9962,����,9,False,�ˡ����ɺ���������涨��������׼��������Ρ�,-2147483640|"
    		cs = cs + "Text,Text87,23.01877,245.0044,����,9,False,�ߡ���������ʻ֤���ݿۣ�,-2147483640|"
    		cs = cs + "Text,Text86,23.01877,239.995,����,9,False,������ʻ�������������δ������,-2147483640|"
    		cs = cs + "Text,Text85,23.01877,235.0031,����,9,False,�塢��ɽ�ͨ�¹ʺ����ݱ�������������ʻ֤��,-2147483640|"
    		cs = cs + "Text,Text84,23.01877,229.9937,����,9,False,�ġ���������������ʻ֤δ�����ꣻ,-2147483640|"
    		cs = cs + "Text,Text83,23.01877,225.0019,����,9,False,�����ṩ���������ϣ�����ƭ�Ȳ������ֶ������������ʻ֤��,-2147483640|"
    		cs = cs + "Text,Text82,23.01877,219.9924,����,9,False,������ʳ��ע�䶾Ʒ�����ڷ��������Ծ���ҩƷ�����δ�����,-2147483640|"
    		cs = cs + "Text,Text81,29.10419,215.0006,����,9,False,��ϵͳ�����ȷ�����ȫ��ʻ������,-2147483640|"
    		cs = cs + "Text,Text80,23.01877,210.0088,����,9,False,һ�����������ಡ����ﲡ���������֢��ѣ��֢��񯲡�������ԡ����񲡡��մ��Լ�Ӱ��֫����,-2147483640|"
    		cs = cs + "Text,Text79,21.96044,203.0062,����,9,False,��������ʻ֤������Ӧ����ʵ����Ƿ�������в�׼��������Σ�,-2147483640|"
    		cs = cs + "Text,Text78,139.9647,262.0083,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text77,139.9647,258.4982,����,9,False,ǩ,-2147483640|"
    		cs = cs + "Text,Text76,139.9647,255.0057,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text75,139.9647,251.4955,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text74,139.9647,248.003,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text73,8.995842,246.5037,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text72,8.995842,242.9936,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text71,8.995842,239.5011,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text70,8.995842,236.0086,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text69,8.995842,232.4984,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text68,8.995842,229.0059,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text67,8.995842,225.4958,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text66,8.995842,222.0033,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text65,153.9877,262.5022,����,9,False,��  ��  ��,-2147483640|"
    		cs = cs + "Text,Text64,25.13544,193.9927,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text63,25.13544,190.5002,����,9,False,ί��,-2147483640|"
    		cs = cs + "Text,Text62,35.18962,189.4418,����,9,False,������/�໤������,-2147483640|"
    		cs = cs + "Text,Text29,91.01675,189.4418,����,9,False,���֤��,-2147483640|"
    		cs = cs + "Text,Text27,126.471,189.4418,����,9,False,��  ��,-2147483640|"
    		cs = cs + "Text,Text61,171.9793,181.9982,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text60,163.5127,181.9982,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text59,155.046,181.9982,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text58,139.171,176.7418,����,9,False,����ǩ�֣�,-2147483640|"
    		cs = cs + "Text,Text57,91.54592,181.9982,����,9,False,��������,-2147483640|"
    		cs = cs + "Text,Text56,25.13544,180.446,����,9,False,��ʽ,-2147483640|"
    		cs = cs + "Text,Text55,25.13544,176.4773,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text54,57.67922,160.8668,����,9,False,ԭ��,-2147483640|"
    		cs = cs + "Text,Text53,104.2459,148.4314,����,9,False,�仯������,-2147483640|"
    		cs = cs + "Text,Text52,53.1813,148.9958,����,9,False,�仯����,-2147483640|"
    		cs = cs + "Text,Text51,124.3543,140.2293,����,9,False,���ʹ���,-2147483640|"
    		cs = cs + "Text,Text50,124.3543,136.5251,����,9,False,�����׼��,-2147483640|"
    		cs = cs + "Text,Text49,52.65213,140.7585,����,9,False,��      ��,-2147483640|"
    		cs = cs + "Text,Text48,52.65213,136.5251,����,9,False,��׼�ݳ���,-2147483640|"
    		if (gnid=="0103"){
    			cs = cs + "Text,Text138,72.65213,136.5251,����,9,False,"+ls_yzjcx+",-2147483640|"
    			cs = cs + "Text,Text139,150.65213,136.5251,����,9,False,"+cx+",-2147483640|"
   			}
    		cs = cs + "Text,Text140,149.8293,129.5049,����,9,False,"+ls_ydabh+",-2147483640|"
    		cs = cs + "Text,Text47,114.8293,129.5049,����,9,False,ԭ��ʻ֤�������,-2147483640|"
    		cs = cs + "Text,Text46,52.12297,122.9961,����,9,False,��Ч�ڽ�ֹ����,-2147483640|"
    		cs = cs + "Text,Text45,136.5251,122.9961,����,9,False,��Ч����,-2147483640|"
    		cs = cs + "Text,Text44,52.12297,129.5049,����,9,False,ת��ԭ��,-2147483640|"
   		 	cs = cs + "Text,Text43,15.34585,176.001,����,9,False,ע��,-2147483640|"
    		cs = cs + "Text,Text42,15.34585,157.9917,����,9,False,��֤,-2147483640|"
    		cs = cs + "Text,Text41,15.34585,141.0054,����,9,False,��֤,-2147483640|"
    		cs = cs + "Text,Text40,8.995842,173.5668,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text39,8.995842,169.3335,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text38,8.995842,165.1002,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text37,8.995842,160.8668,����,9,False,ҵ,-2147483640|"
    		cs = cs + "Text,Text36,8.995842,156.6335,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text35,8.995842,152.9999,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text34,112.7126,116.505,����,9,False,��Ч�ڽ�ֹ����,-2147483640|"
    		cs = cs + "Text,Text33,52.12297,116.505,����,9,False,������֤����,-2147483640|"
    		cs = cs + "Text,Text32,116.9459,112.0071,����,9,False,ǩע��׼�ݳ��ʹ���,-2147483640|"
    		cs = cs + "Text,Text31,52.12297,112.0071,����,9,False,���ּ�ʻ֤��֤��,-2147483640|"
   			if (gnid=="0104" || gnid=="0106"){
    			cs = cs + "Text,Text133,80.12297,111.0071,����,10,False,"+ls_yjszh+",-2147483640|"
    			cs = cs + "Text,Text134,150.9459,111.0071,����,10,False,"+ls_yzjcx+",-2147483640|"
    			cs = cs + "Text,Text135,80.12297,116.505,����,10,False,"+ls_yfzrq+",-2147483640|"
    		}
    		cs = cs + "Text,Text30,69.05632,100.5418,����,9,False,���ڳ־�����ʻ֤�������ʻ֤����ģ���Ӧ��д��������,-2147483640|"
    		cs = cs + "Text,Text28,119.0626,93.92718,����,9,False,��׼�ݳ��ʹ���,-2147483640|"
    		if (gnid=="0102"){//����ʱ��ӡ��׼�ݳ��ʹ���
    			cs = cs + "Text,Text132,160.65213,93.92718,����,11.25,False,"+ls_yzjcx+",-2147483640|"
    		}
    		cs = cs + "Text,Text26,57.67922,93.92718,����,9,False,�����׼�ݳ��ʹ���,-2147483640|"
    		cs = cs + "Text,Text25,15.34585,103.7168,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text24,111.6543,85.4605,����,9,False,��������,-2147483640|"
    		cs = cs + "Text,Text23,15.61043,87.50661,����,9,False,�绰,-2147483640|"
    		cs = cs + "Text,Text22,15.61043,83.99648,����,9,False,��ϵ,-2147483640|"
    		cs = cs + "Text,Text21,15.61043,79.19869,����,9,False,��ַ,-2147483640|"
    		cs = cs + "Text,Text20,15.61043,75.19466,����,9,False,��ϵ,-2147483640|"
    		cs = cs + "Text,Text19,15.61043,69.3209,����,9,False,��ַ,-2147483640|"
    		cs = cs + "Text,Text18,15.61043,65.35215,����,9,False,ס��,-2147483640|"
    		cs = cs + "Text,Text17,65.61673,58.50825,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text16,65.61673,50.50019,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text15,15.61043,59.26672,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text14,15.61043,55.03339,����,9,False,֤��,-2147483640|"
    		cs = cs + "Text,Text13,15.61043,50.50019,����,9,False,���,-2147483640|"
    		cs = cs + "Text,Text12,8.995842,74.0834,����,9,False,Ϣ,-2147483640|"
    		cs = cs + "Text,Text11,8.995842,69.85007,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text10,8.995842,65.61673,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text9,8.995842,61.38339,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text8,8.995842,56.99131,����,9,False,��,-2147483640|"
    		cs = cs + "Text,Text7,147.1085,42.06879,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text6,100.0126,42.06879,����,9,False,��������,-2147483640|"
    		cs = cs + "Text,Text5,81.49174,42.06879,����,9,False,�Ա�,-2147483640|"
    		cs = cs + "Text,Text4,15.61043,42.49213,����,9,False,����,-2147483640|"
    		cs = cs + "Text,Text3,128.5876,32.80836,����,9,False,�������,-2147483640|"
    		cs = cs + "Text,Text2,74.61257,32.80836,����,9,False,�����ǩ��,-2147483640|"
    		cs = cs + "Text,Text1,50.0063,18.9971,����,18,True,�� �� �� �� ʻ ֤ �� �� ��,-2147483640|"
    		cs = cs + "Line,Line106,1,1,155.5751,155.5751,107.4209,110.0668|"
    		cs = cs + "Line,Line105,1,1,158.221,158.221,107.4209,110.0668|"
    		cs = cs + "Line,Line104,1,1,155.5751,158.221,110.0668,110.0668|"
    		cs = cs + "Line,Line103,1,1,155.5751,158.221,107.4209,107.4209|"
    		cs = cs + "Line,Line107,1,1,72.4959,72.4959,107.4209,110.0668|"
    		cs = cs + "Line,Line125,1,1,75.14174,75.14174,107.4209,110.0668|"
    		cs = cs + "Line,Line143,1,1,72.4959,75.14174,110.0668,110.0668|"
    		cs = cs + "Line,Line161,1,1,72.4959,75.14174,107.4209,107.4209|"
    		cs = cs + "Line,Line108,1,1,92.60426,92.60426,107.4209,110.0668|"
    		cs = cs + "Line,Line126,1,1,95.25009,95.25009,107.4209,110.0668|"
    		cs = cs + "Line,Line144,1,1,92.60426,95.25009,110.0668,110.0668|"
    		cs = cs + "Line,Line162,1,1,92.60426,95.25009,107.4209,107.4209|"
    		cs = cs + "Line,Line109,1,1,113.7709,113.7709,107.4209,110.0668|"
    		cs = cs + "Line,Line127,1,1,116.4168,116.4168,107.4209,110.0668|"
    		cs = cs + "Line,Line145,1,1,113.7709,116.4168,110.0668,110.0668|"
    		cs = cs + "Line,Line163,1,1,113.7709,116.4168,107.4209,107.4209|"
    		cs = cs + "Line,Line110,1,1,92.60426,92.60426,129.646,132.2918|"
    		cs = cs + "Line,Line128,1,1,95.25009,95.25009,129.646,132.2918|"
    		cs = cs + "Line,Line146,1,1,92.60426,95.25009,132.2918,132.2918|"
    		cs = cs + "Line,Line164,1,1,92.60426,95.25009,129.646,129.646|"
    		cs = cs + "Line,Line111,1,1,134.4085,134.4085,107.4209,110.0668|"
    		cs = cs + "Line,Line129,1,1,137.0543,137.0543,107.4209,110.0668|"
    		cs = cs + "Line,Line147,1,1,134.4085,137.0543,110.0668,110.0668|"
    		cs = cs + "Line,Line165,1,1,134.4085,137.0543,107.4209,107.4209|"
    		cs = cs + "Line,Line112,1,1,72.4959,72.4959,129.646,132.2918|"
    		cs = cs + "Line,Line130,1,1,75.14174,75.14174,129.646,132.2918|"
    		cs = cs + "Line,Line148,1,1,72.4959,75.14174,132.2918,132.2918|"
    		cs = cs + "Line,Line166,1,1,72.4959,75.14174,129.646,129.646|"
    		cs = cs + "Line,Line113,1,1,51.85838,51.85838,107.4209,110.0668|"
    		cs = cs + "Line,Line131,1,1,54.50422,54.50422,107.4209,110.0668|"
    		cs = cs + "Line,Line149,1,1,51.85838,54.50422,110.0668,110.0668|"
    		cs = cs + "Line,Line167,1,1,51.85838,54.50422,107.4209,107.4209|"
    		cs = cs + "Line,Line114,1,1,102.1293,102.1293,176.2127,178.8585|"
    		cs = cs + "Line,Line132,1,1,104.7751,104.7751,176.2127,178.8585|"
    		cs = cs + "Line,Line150,1,1,102.1293,104.7751,178.8585,178.8585|"
    		cs = cs + "Line,Line168,1,1,102.1293,104.7751,176.2127,176.2127|"
    		cs = cs + "Line,Line115,1,1,24.87086,24.87086,155.046,157.6918|"
    		cs = cs + "Line,Line116,1,1,36.51254,36.51254,182.5627,185.2085|"
    		cs = cs + "Line,Line133,1,1,39.15837,39.15837,182.5627,185.2085|"
    		cs = cs + "Line,Line151,1,1,36.51254,39.15837,185.2085,185.2085|"
    		cs = cs + "Line,Line169,1,1,36.51254,39.15837,182.5627,182.5627|"
    		cs = cs + "Line,Line117,1,1,36.51254,36.51254,176.2127,178.8585|"
    		cs = cs + "Line,Line134,1,1,39.15837,39.15837,176.2127,178.8585|"
    		cs = cs + "Line,Line152,1,1,36.51254,39.15837,178.8585,178.8585|"
    		cs = cs + "Line,Line170,1,1,36.51254,39.15837,176.2127,176.2127|"
    		cs = cs + "Line,Line118,1,1,24.87086,24.87086,168.8043,171.4502|"
    		cs = cs + "Line,Line135,1,1,27.51669,27.51669,168.8043,171.4502|"
    		cs = cs + "Line,Line153,1,1,24.87086,27.51669,171.4502,171.4502|"
    		cs = cs + "Line,Line171,1,1,24.87086,27.51669,168.8043,168.8043|"
    		cs = cs + "Line,Line119,1,1,24.87086,24.87086,162.4543,165.1002|"
    		cs = cs + "Line,Line136,1,1,27.51669,27.51669,162.4543,165.1002|"
    		cs = cs + "Line,Line154,1,1,24.87086,27.51669,165.1002,165.1002|"
    		cs = cs + "Line,Line172,1,1,24.87086,27.51669,162.4543,162.4543|"
    		cs = cs + "Line,Line137,1,1,27.51669,27.51669,155.046,157.6918|"
    		cs = cs + "Line,Line155,1,1,24.87086,27.51669,157.6918,157.6918|"
    		cs = cs + "Line,Line173,1,1,24.87086,27.51669,155.046,155.046|"
    		cs = cs + "Line,Line120,1,1,24.87086,24.87086,148.696,151.3418|"
    		cs = cs + "Line,Line138,1,1,27.51669,27.51669,148.696,151.3418|"
    		cs = cs + "Line,Line156,1,1,24.87086,27.51669,151.3418,151.3418|"
    		cs = cs + "Line,Line174,1,1,24.87086,27.51669,148.696,148.696|"
    		cs = cs + "Line,Line121,1,1,24.87086,24.87086,141.8168,144.4626|"
    		cs = cs + "Line,Line139,1,1,27.51669,27.51669,141.8168,144.4626|"
    		cs = cs + "Line,Line157,1,1,24.87086,27.51669,144.4626,144.4626|"
    		cs = cs + "Line,Line175,1,1,24.87086,27.51669,141.8168,141.8168|"
    		cs = cs + "Line,Line122,1,1,24.87086,24.87086,135.996,138.6418|"
    		cs = cs + "Line,Line140,1,1,27.51669,27.51669,135.996,138.6418|"
    		cs = cs + "Line,Line158,1,1,24.87086,27.51669,138.6418,138.6418|"
    		cs = cs + "Line,Line176,1,1,24.87086,27.51669,135.996,135.996|"
    		cs = cs + "Line,Line123,1,1,24.87086,24.87086,129.646,132.2918|"
    		cs = cs + "Line,Line141,1,1,27.51669,27.51669,129.646,132.2918|"
    		cs = cs + "Line,Line159,1,1,24.87086,27.51669,132.2918,132.2918|"
    		cs = cs + "Line,Line177,1,1,24.87086,27.51669,129.646,129.646|"
    		cs = cs + "Line,Line124,1,1,24.87086,24.87086,123.296,125.9418|"
    		cs = cs + "Line,Line142,1,1,27.51669,27.51669,123.296,125.9418|"
    		cs = cs + "Line,Line160,1,1,24.87086,27.51669,125.9418,125.9418|"
    		cs = cs + "Line,Line178,1,1,24.87086,27.51669,123.296,123.296|"
    		cs = cs + "Line,Line102,1,1,24.87086,24.87086,113.7709,116.4168|"
    		cs = cs + "Line,Line101,1,1,27.51669,27.51669,113.7709,116.4168|"
    		cs = cs + "Line,Line100,1,1,24.87086,27.51669,116.4168,116.4168|"
    		cs = cs + "Line,Line99,1,1,24.87086,27.51669,113.7709,113.7709|"
    		cs = cs + "Line,Line98,1,1,24.87086,24.87086,107.4209,110.0668|"
    		cs = cs + "Line,Line97,1,1,27.51669,27.51669,107.4209,110.0668|"
    		cs = cs + "Line,Line96,1,1,24.87086,27.51669,110.0668,110.0668|"
    		cs = cs + "Line,Line95,1,1,24.87086,27.51669,107.4209,107.4209|"
    		cs = cs + "Line,Line94,1,1,24.87086,24.87086,101.0709,103.7168|"
    		cs = cs + "Line,Line93,1,1,27.51669,27.51669,101.0709,103.7168|"
    		cs = cs + "Line,Line92,1,1,24.87086,27.51669,103.7168,103.7168|"
    		cs = cs + "Line,Line91,1,1,24.87086,27.51669,101.0709,101.0709|"
    		cs = cs + "Line,Line79,1,1,24.87086,24.87086,94.72092,97.36676|"
    		cs = cs + "Line,Line90,1,1,27.51669,27.51669,94.72092,97.36676|"
    		cs = cs + "Line,Line89,1,1,24.87086,27.51669,97.36676,97.36676|"
    		cs = cs + "Line,Line82,1,1,24.87086,27.51669,94.72092,94.72092|"
    		cs = cs + "Line,Line78,1,1,74.0834,126.471,30.16253,30.16253|"
    		cs = cs + "Line,Line88,1,1,47.09588,91.5812,185.4731,185.4731|"
    		cs = cs + "Line,Line87,1,1,33.60212,33.60212,174.096,201.0835|"
    		cs = cs + "Line,Line86,1,1,135.996,170.0567,120.1209,120.1209|"
    		cs = cs + "Line,Line85,1,1,72.4959,102.1293,119.5918,119.5918|"
    		cs = cs + "Line,Line84,1,1,146.5793,174.0607,115.0939,115.0939|"
    		cs = cs + "Line,Line83,1,1,76.72924,104.2459,115.0939,115.0939|"
    		cs = cs + "Line,Line81,1,1,91.01675,91.01675,29.89795,39.89921|"
    		cs = cs + "Line,Line80,1,1,74.0834,74.0834,29.89795,39.89921|"
    		cs = cs + "Line,Line77,1,1,138.1126,138.1126,174.096,194.5924|"
    		cs = cs + "Line,Line76,1,1,125.148,125.148,187.5898,194.5924|"
    		cs = cs + "Line,Line75,1,1,105.0397,105.0397,187.5898,194.5924|"
    		cs = cs + "Line,Line74,1,1,89.95842,89.95842,187.5898,194.5924|"
    		cs = cs + "Line,Line73,1,1,64.5584,64.5584,187.5898,194.5924|"
    		cs = cs + "Line,Line72,1,1,33.60212,176.0892,194.4689,194.4689|"
    		cs = cs + "Line,Line71,1,1,24.07711,176.0716,187.5898,187.5898|"
    		cs = cs + "Line,Line70,1,1,71.17299,176.1598,166.9523,166.9523|"
    		cs = cs + "Line,Line69,1,1,24.07711,51.08227,166.9523,166.9523|"
    		cs = cs + "Line,Line68,1,1,71.17299,176.1598,160.0731,160.0731|"
    		cs = cs + "Line,Line67,1,1,24.07711,51.08227,160.0731,160.0731|"
    		cs = cs + "Line,Line66,1,1,121.973,121.973,133.8793,153.3703|"
    		cs = cs + "Line,Line65,1,1,103.1876,103.1876,147.1085,153.5996|"
    		cs = cs + "Line,Line64,1,1,24.07711,176.0716,153.4585,153.4585|"
    		cs = cs + "Line,Line63,1,1,24.07711,176.0716,147.1085,147.1085|"
    		cs = cs + "Line,Line62,1,1,24.07711,51.08227,140.4939,140.4939|"
    		cs = cs + "Line,Line61,1,1,143.1397,143.1397,128.0585,147.0556|"
    		cs = cs + "Line,Line60,1,1,113.5064,113.5064,128.0585,134.0557|"
    		cs = cs + "Line,Line59,1,1,151.0772,151.0772,120.9147,127.9174|"
    		cs = cs + "Line,Line58,1,1,135.996,135.996,120.9147,127.9174|"
    		cs = cs + "Line,Line57,1,1,78.05216,78.05216,120.9147,127.9174|"
    		cs = cs + "Line,Line56,1,1,71.17299,71.17299,128.0585,174.0607|"
    		cs = cs + "Line,Line55,1,1,24.07711,176.0716,133.8793,133.8793|"
    		cs = cs + "Line,Line54,1,1,24.07711,176.0716,128.0585,128.0585|"
    		cs = cs + "Line,Line53,1,1,152.6647,152.6647,92.07509,99.57162|"
    		cs = cs + "Line,Line52,1,1,114.5647,114.5647,92.07509,99.57162|"
    		cs = cs + "Line,Line51,1,1,94.19176,94.19176,92.07509,99.57162|"
    		cs = cs + "Line,Line50,1,1,51.06463,176.0539,99.48343,99.48343|"
    		cs = cs + "Line,Line49,1,1,24.07711,176.0716,174.096,174.096|"
    		cs = cs + "Line,Line48,1,1,51.06463,51.06463,92.07509,174.0784|"
    		cs = cs + "Line,Line47,1,1,127.0001,127.0001,83.07925,92.07509|"
    		cs = cs + "Line,Line46,1,1,110.0668,110.0668,83.07925,92.07509|"
    		cs = cs + "Line,Line45,1,1,138.6418,176.1245,247.1211,247.1211|"
    		cs = cs + "Line,Line44,1,1,143.9335,143.9335,247.1211,267.1236|"
    		cs = cs + "Line,Line43,1,1,138.6418,138.6418,247.1211,267.1236|"
    		cs = cs + "Line,Line42,1,1,7.937508,175.9305,266.9648,266.9648|"
    		cs = cs + "Line,Line41,1,1,7.937508,175.9305,201.0835,201.0835|"
    		cs = cs + "Line,Line40,1,1,7.937508,175.9305,120.9147,120.9147|"
    		cs = cs + "Line,Line39,1,1,14.02293,146.0325,83.07925,83.07925|"
    		cs = cs + "Line,Line38,1,1,14.02293,146.0325,74.0834,74.0834|"
    		cs = cs + "Line,Line37,1,1,142.6106,142.6106,47.88963,63.88812|"
    		cs = cs + "Line,Line36,1,1,138.9064,138.9064,47.88963,63.88812|"
    		cs = cs + "Line,Line35,1,1,134.9376,134.9376,47.88963,63.88812|"
    		cs = cs + "Line,Line34,1,1,130.9689,130.9689,47.88963,63.88812|"
    		cs = cs + "Line,Line33,1,1,127.0001,127.0001,47.88963,63.88812|"
    		cs = cs + "Line,Line32,1,1,123.0314,123.0314,47.88963,63.88812|"
    		cs = cs + "Line,Line31,1,1,119.0626,119.0626,47.88963,63.88812|"
    		cs = cs + "Line,Line30,1,1,115.0939,115.0939,47.88963,63.88812|"
    		cs = cs + "Line,Line29,1,1,111.1251,111.1251,47.88963,63.88812|"
    		cs = cs + "Line,Line28,1,1,107.1564,107.1564,47.88963,63.88812|"
    		cs = cs + "Line,Line27,1,1,103.1876,103.1876,47.88963,63.88812|"
    		cs = cs + "Line,Line26,1,1,98.95426,98.95426,47.88963,63.88812|"
    		cs = cs + "Line,Line25,1,1,94.98551,94.98551,47.88963,63.88812|"
    		cs = cs + "Line,Line24,1,1,91.01675,91.01675,47.88963,63.88812|"
    		cs = cs + "Line,Line23,1,1,87.048,87.048,47.88963,63.88812|"
    		cs = cs + "Line,Line22,1,1,83.07925,83.07925,47.88963,63.88812|"
    		cs = cs + "Line,Line21,1,1,79.1105,79.1105,47.88963,63.88812|"
    		cs = cs + "Line,Line20,1,1,75.14174,75.14174,47.88963,63.88812|"
    		cs = cs + "Line,Line19,1,1,63.50006,63.50006,47.88963,63.88812|"
    		cs = cs + "Line,Line18,1,1,23.54794,146.0501,56.62089,56.62089|"
    		cs = cs + "Line,Line17,1,1,14.02293,146.0325,64.02923,64.02923|"
    		cs = cs + "Line,Line16,1,1,115.3584,115.3584,39.95212,47.94255|"
    		cs = cs + "Line,Line15,1,1,98.95426,98.95426,39.95212,47.94255|"
    		cs = cs + "Line,Line14,1,1,91.01675,91.01675,39.95212,47.94255|"
    		cs = cs + "Line,Line13,1,1,79.37508,79.37508,39.95212,47.94255|"
    		cs = cs + "Line,Line12,1,1,24.07711,24.07711,39.95212,200.9424|"
    		cs = cs + "Line,Line11,1,1,155.046,155.046,39.95212,47.94255|"
    		cs = cs + "Line,Line10,1,1,146.0501,146.0501,29.89795,91.8987|"
    		cs = cs + "Line,Line9,1,1,7.937508,175.9305,92.07509,92.07509|"
    		cs = cs + "Line,Line8,1,1,14.02293,176.0186,47.88963,47.88963|"
    		cs = cs + "Line,Line7,1,1,14.02293,14.02293,39.95212,266.9472|"
    		cs = cs + "Line,Line6,1,1,7.937508,175.9305,266.9648,266.9648|"
    		cs = cs + "Line,Line5,1,1,126.471,126.471,29.89795,39.89921|"
    		cs = cs + "Line,Line4,1,1,175.9481,175.9481,29.89795,266.8943|"
    		cs = cs + "Line,Line3,1,1,7.937508,7.937508,39.95212,266.9472|"
    		cs = cs + "Line,Line2,1,1,7.937508,175.9305,39.95212,39.95212|"
    		cs = cs + "Line,Line1,1,1,126.471,175.9657,29.89795,29.89795"
    		drvprint.printData=cs;
    		drvprint.data_print();
    	}
    	catch(err)
    	{
    	    alert(err.description);
  		}       
    }
    else if(code=="0")
    {
         msg="δ�ҵ���Ӧ����ˮ��¼��";
         alert(msg);
    }
    else if(code=="-1")
    {
         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
         msg="��ȡ���ݹ����г����쳣��"+msg;
         alert(msg);
    }
}
function printSqb1()
{
    var xmlDoc = _xmlHttpRequestObj.responseXML;
    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
    var gnid = xmlDoc.getElementsByTagName("gnid")[0].firstChild.data;
    var ywyy= xmlDoc.getElementsByTagName("ywyy")[0].firstChild.data;
    var sftd=xmlDoc.getElementsByTagName("sftd")[0].firstChild.data;
    var msg="";
    if(code=="1")
    {
        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
        var xb=xmlDoc.getElementsByTagName("xb_mc")[0].firstChild.data;
        var csrq=xmlDoc.getElementsByTagName("csrq")[0].firstChild.data;
        var gj=xmlDoc.getElementsByTagName("gj_mc")[0].firstChild.data;
        var sfzmmc=xmlDoc.getElementsByTagName("sfzmmc_mc")[0].firstChild.data;
        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
        var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
        var zzzm=xmlDoc.getElementsByTagName("zzzm")[0].firstChild.data;
        var yb=xmlDoc.getElementsByTagName("lxzsyzbm")[0].firstChild.data;
        var lxdh=xmlDoc.getElementsByTagName("lxdh")[0].firstChild.data;
        var zsdz=xmlDoc.getElementsByTagName("djzsxxdz")[0].firstChild.data;
        var lxdz=xmlDoc.getElementsByTagName("lxzsxxdz")[0].firstChild.data;
        var cx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
        var sjhm=xmlDoc.getElementsByTagName("sjhm")[0].firstChild.data;
        var dzyx=xmlDoc.getElementsByTagName("dzyx")[0].firstChild.data;
        var zzz="";
        var z0="";z1="";z2="";z3="";z4="";z5="";z6="";z7="";z8="";z9="";z10="";z11="";
            z12="";z13="";z14="";z15="";z16="";z17="";z18="";
        if (zzzm != null && zzzm!="--") 
        {
			zzz = "��ס֤��";
			if(zzzm.length>0)
			{
				z0=zzzm.substring(0,1);
			}
			if(zzzm.length>1)
			{
				z1=zzzm.substring(1,2);
			}
			if(zzzm.length>2)
			{
				z2=zzzm.substring(2,3);
			}		
			if(zzzm.length>3)
			{
				z3=sfzmhm.substring(3,4);
			}
			if(zzzm.length>4)
			{
				z4=sfzmhm.substring(4,5);
			}
			if(zzzm.length>5)
			{
				z5=sfzmhm.substring(5,6);
			}
			if(zzzm.length>6)
			{
				z6=sfzmhm.substring(6,7);
			}
			if(zzzm.length>7)
			{
				z7=sfzmhm.substring(7,8);
			}
			if(zzzm.length>8)
			{
				z8=sfzmhm.substring(8,9);
			}
			if(zzzm.length>9)
			{
				z9=sfzmhm.substring(9,10);
			}
			if(zzzm.length>10)
			{
				z10=sfzmhm.substring(10,11);
			}
			if(zzzm.length>11)
			{
				z11=sfzmhm.substring(11,12);
			}
			if(zzzm.length>12)
			{
				z12=sfzmhm.substring(12,13);
			}
			if(zzzm.length>13)
			{
				z13=sfzmhm.substring(13,14);
			}
			if(zzzm.length>14)
			{
				z14=sfzmhm.substring(14,15);
			}
			if(zzzm.length>15)
			{
				z15=sfzmhm.substring(15,16);
			}
			if(zzzm.length>16)
			{
				z16=sfzmhm.substring(16,17);
			}
			if(zzzm.length>17)
			{
				z17=sfzmhm.substring(17,18);
			}
		}
		var ls_ywyy=xmlDoc.getElementsByTagName("ywyy")[0].firstChild.data;
		var ls_yjszh = xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
		var ls_yzjcx = xmlDoc.getElementsByTagName("yzjcx")[0].firstChild.data;
		var ls_yfzrq = xmlDoc.getElementsByTagName("yfzrq")[0].firstChild.data;
		var ls_ly = xmlDoc.getElementsByTagName("ly")[0].firstChild.data;
		var ls_ydabh = xmlDoc.getElementsByTagName("ydabh")[0].firstChild.data;
		var b0="";b1="";b2="";b3="";b4="";b5="";b6="";b7="";b8="";b9="";b10="";
		    b11="";b12="";b13="";b14="";b15="";b16="";b17="";
		
		
		if(sfzmhm.length>0)
		{
			b0=sfzmhm.substring(0,1);
		}
		if(sfzmhm.length>1)
		{
			b1=sfzmhm.substring(1,2);
		}
		if(sfzmhm.length>2)
		{
			b2=sfzmhm.substring(2,3);
		}		
		if(sfzmhm.length>3)
		{
			b3=sfzmhm.substring(3,4);
		}
		if(sfzmhm.length>4)
		{
			b4=sfzmhm.substring(4,5);
		}
		if(sfzmhm.length>5)
		{
			b5=sfzmhm.substring(5,6);
		}
		if(sfzmhm.length>6)
		{
			b6=sfzmhm.substring(6,7);
		}
		if(sfzmhm.length>7)
		{
			b7=sfzmhm.substring(7,8);
		}
		if(sfzmhm.length>8)
		{
			b8=sfzmhm.substring(8,9);
		}
		if(sfzmhm.length>9)
		{
			b9=sfzmhm.substring(9,10);
		}
		if(sfzmhm.length>10)
		{
			b10=sfzmhm.substring(10,11);
		}
		if(sfzmhm.length>11)
		{
			b11=sfzmhm.substring(11,12);
		}
		if(sfzmhm.length>12)
		{
			b12=sfzmhm.substring(12,13);
		}
		if(sfzmhm.length>13)
		{
			b13=sfzmhm.substring(13,14);
		}
		if(sfzmhm.length>14)
		{
			b14=sfzmhm.substring(14,15);
		}
		if(sfzmhm.length>15)
		{
			b15=sfzmhm.substring(15,16);
		}
		if(sfzmhm.length>16)
		{
			b16=sfzmhm.substring(16,17);
		}
		if(sfzmhm.length>17)
		{
			b17=sfzmhm.substring(17,18);
		}		
		
        try
        {	
	        drvprint.posX="0"
		    drvprint.posY="0"
			var cs="";
	        if(sftd=='0'){
	        cs=cs+"Text,Text170,71.96674,149.2251,����,9.75,False,����ʧ,-2147483640|"
	        cs=cs+"Text,Text169,94.72092,149.2251,����,9.75,False,������,-2147483640|"
	        cs=cs+"Text,Text168,39.15837,168.8043,����,9.75,False,����,-2147483640|"
	        cs=cs+"Text,Text167,35.98337,165.6293,����,9.75,False,׼�ݳ���,-2147483640|"
	        cs=cs+"Text,Text166,66.1459,167.2168,����,9.75,False,��,-2147483640|"
	        cs=cs+"Text,Text165,95.25009,116.4168,����,9.75,False,��֤ʱ�޷��ύ��ס����ס֤��ԭ��,-2147483640|"
	        cs=cs+"Text,Text164,51.85838,94.19176,����,9.75,False,׼�ݳ�,-2147483640|"
	        cs=cs+"Text,Text163,51.85838,97.89593,����,9.75,False,�ʹ���,-2147483640|"
	        cs=cs+"Text,Text162,2.645836,122.2376,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text161,2.645836,125.9418,����,9.75,True,ҵ,-2147483640|"
	        cs=cs+"Text,Text160,2.645836,129.646,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text159,2.645836,133.8793,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text147,2.645836,138.1126,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text145,8.466675,65.08756,����,9.75,False,�绰,-2147483640|"
	        cs=cs+"Text,Text143,129.1168,201.6127,����,9.75,False,��  ��,-2147483640|"
	        cs=cs+"Text,Text141,85.72508,201.6127,����,9.75,False,�� ��,-2147483640|"
	        cs=cs+"Text,Text139,8.466675,206.3752,����,9.75,False,�໤����Ϣ,-2147483640|"
	        cs=cs+"Text,Text124,41.80421,202.1419,����,9.75,False,������,-2147483640|"
	        cs=cs+"Text,Text119,153.9877,220.6627,����,9.75,False,���ϵ���ʵ��Ч�Ը���,-2147483640|"
	        cs=cs+"Text,Text79,82.02091,197.9085,����,9.75,False,���֤��,-2147483640|"
			if(gnid=='C')//��֤
			{
				if(ls_ywyy.indexOf("C")>=0)//����
					cs=cs+"Text,Text600,143.9335,123.8251,����,9.75,False,"+cx+",-2147483640|"		
				if(ls_ywyy.indexOf("D")>=0)//����
					cs=cs+"Text,Text601,143.9335,123.8251,����,9.75,False,"+cx+",-2147483640|"					
			}
	       
	        //cs=cs+"Text,Text16,143.9335,123.8251,����,9.75,False,A2,-2147483640|"
	        cs=cs+"Text,Text158,2.645836,260.8794,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text157,2.645836,256.6461,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text156,2.645836,252.4128,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text153,2.645836,248.1794,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text151,2.645836,243.9461,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text150,2.645836,239.7127,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text149,2.645836,235.4794,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text131,2.645836,231.2461,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text137,2.645836,118.5334,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text135,2.645836,61.91256,����,9.75,True,Ϣ,-2147483640|"
	        cs=cs+"Text,Text133,2.645836,57.67922,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text128,2.645836,53.44588,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text121,2.645836,49.21255,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text120,2.645836,44.97921,����,9.75,True,��,-2147483640|"
	        cs=cs+"Text,Text118,173.0377,277.2836,����,9.75,False,��   ��   ��,-2147483640|"
	        cs=cs+"Text,Text117,173.0377,249.7669,����,9.75,False,��   ��   ��,-2147483640|"
	        cs=cs+"Text,Text116,153.4585,255.0586,����,9.75,False,������/�໤��ǩ��:,-2147483640|"
	        cs=cs+"Text,Text114,14.28751,265.1128,����,9.75,False,�ˡ����ɺ���������涨��������׼��������Ρ�,-2147483640|"
	        cs=cs+"Text,Text112,14.28751,259.8211,����,9.75,False,�ߡ���������ʻ֤���ݿۣ�,-2147483640|"
	        cs=cs+"Text,Text110,14.28751,254.5294,����,9.75,False,������ʻ�������������δ�����ꣻ,-2147483640|"
	        cs=cs+"Text,Text108,14.28751,249.2377,����,9.75,False,�塢��ɽ�ͨ�¹ʺ����ݱ�������������ʻ֤��,-2147483640|"
	        cs=cs+"Text,Text106,14.28751,243.9461,����,9.75,False,�ġ���������������ʻ֤δ�����ꣻ,-2147483640|"
	        cs=cs+"Text,Text104,14.28751,238.6544,����,9,False,�����ṩ���������ϣ�����ƭ�Ȳ������ֶ������������ʻ֤��,-2147483640|"
	        cs=cs+"Text,Text102,14.28751,232.8336,����,9,False,������ʳ��ע�䶾Ʒ�����ڷ��������Ծ���ҩƷ�����δ�����,-2147483640|"
	        cs=cs+"Text,Text100,20.63752,225.9544,����,9,False,֫������ϵͳ�����ȷ�����ȫ��ʻ������,-2147483640|"
	        cs=cs+"Text,Text97,14.28751,221.1919,����,9,False,һ�����������ಡ����ﲡ���������֢��ѣ��֢��񯲡�������ԡ����񲡡��մ��Լ�Ӱ��,-2147483640|"
	        cs=cs+"Text,Text95,142.8751,208.4919,����,9.75,False,,-2147483640|"
	        cs=cs+"Text,Text93,58.73756,208.4919,����,9.75,False,,-2147483640|"
	        cs=cs+"Text,Text91,142.8751,200.0252,����,9.75,False,,-2147483640|"
	        cs=cs+"Text,Text89,98.42509,200.0252,����,9.75,False,,-2147483640|"
	        cs=cs+"Text,Text87,58.73756,200.0252,����,9.75,False,,-2147483640|"
	        cs=cs+"Text,Text85,126.471,208.4919,����,9.75,False,��ϵ�绰,-2147483640|"
	        cs=cs+"Text,Text83,37.0417,208.4919,����,9.75,False,��ϵ��ַ,-2147483640|"
	        cs=cs+"Text,Text81,125.9418,197.9085,����,9.75,False,���֤��,-2147483640|"
	        cs=cs+"Text,Text77,36.51254,198.9669,����,9.75,False,������/�໤,-2147483640|"
	        cs=cs+"Text,Text75,8.466675,202.1419,����,9.75,False,ί�д�����,-2147483640|"
	        cs=cs+"Text,Text73,168.2752,188.3835,����,9.75,False,��������,-2147483640|"
	        cs=cs+"Text,Text71,58.20839,188.3835,����,9.75,False,����������  ���໤������  ��ί��,-2147483640|"
	        cs=cs+"Text,Text69,10.05418,188.9127,����,9.75,False,���뷽ʽ,-2147483640|"
	        cs=cs+"Text,Text155,134.4085,177.271,����,9.75,False,������,-2147483640|"
	        cs=cs+"Text,Text154,99.48343,177.271,����,9.75,False,������������,-2147483640|"
	        cs=cs+"Text,Text152,71.96674,177.271,����,9.75,False,��������,-2147483640|"
	        cs=cs+"Text,Text148,71.96674,169.3335,����,9.75,False,��δ���涨�ύ���֤����ע��δ������,-2147483640|"
	        cs=cs+"Text,Text146,71.96674,165.1002,����,9.75,False,��������Ч��һ������δ��֤��ע��δ������,-2147483640|"
	        cs=cs+"Text,Text144,182.0335,157.1627,����,9.75,False,������,-2147483640|"
	        cs=cs+"Text,Text142,146.0501,157.1627,����,9.75,False,��ɥʧ������Ϊ����,-2147483640|"
	        cs=cs+"Text,Text140,112.1834,157.1627,����,9.75,False,�������������ʺ�,-2147483640|"
	        cs=cs+"Text,Text138,94.72092,157.1627,����,9.75,False,������,-2147483640|"
	        cs=cs+"Text,Text136,71.96674,157.1627,����,9.75,False,����������,-2147483640|"
	        cs=cs+"Text,Text134,66.1459,162.4543,����,9.75,False,ԭ,-2147483640|"
	        cs=cs+"Text,Text132,153.9877,215.9002,����,9.75,False,�����˼������˶�����,-2147483640|"
	        cs=cs+"Text,Text129,153.9877,227.5419,����,9.75,False,������ǩ�֣�,-2147483640|"
	        cs=cs+"Text,Text130,13.22918,272.5211,����,9.75,False,�������ݱ����������Ķ������˲��������еĲ�׼��������Ρ�,-2147483640|"
	        cs=cs+"Text,Text127,14.28751,215.9002,����,9.75,False,��������ʻ֤������Ӧ����ʵ����Ƿ�������в�׼��������Σ�,-2147483640|"
	        cs=cs+"Text,Text126,110.5959,135.996,����,9.75,False,�仯������,-2147483640|"
	        cs=cs+"Text,Text125,52.91672,135.996,����,9.75,False,�仯����,-2147483640|"
	        cs=cs+"Text,Text123,115.8876,188.3835,����,9.75,False,,-2147483640|"
	        cs=cs+"Text,Text122,96.30843,123.8251,����,9.75,False,�����׼�ݳ��ʹ���,-2147483640|"
	        cs=cs+"Text,Text115,173.0377,106.3626,����,9.75,False,�������ʻ֤,-2147483640|"
	        cs=cs+"Text,Text113,148.1668,106.3626,����,9.75,False,��̨���ʻ֤,-2147483640|"
	        cs=cs+"Text,Text111,121.7085,106.3626,����,9.75,False,�����ż�ʻ֤,-2147483640|"
	        cs=cs+"Text,Text109,96.30843,106.3626,����,9.75,False,����ۼ�ʻ֤,-2147483640|"
			if(gnid=='A')
			{
				if(ls_ly=='E')//�����ʻ֤
					cs=cs+"Text,Text602,173.0377,106.3626,����,9.75,False,��,-2147483640|"
				if(ls_ly=='F')//���
				    cs=cs+"Text,Text603,96.30843,106.3626,����,9.75,False,��,-2147483640|"
				if(ls_ly=='G')//����
				    cs=cs+"Text,Text604,121.7085,106.3626,����,9.75,False,��,-2147483640|"		
				if(ls_ly=='H')//̨��
					cs=cs+"Text,Text605,148.1668,106.3626,����,9.75,False,��,-2147483640|"				    
			}
	        
	        
	        cs=cs+"Text,Text107,148.696,98.95426,����,9.75,False,���侯��ʻ֤,-2147483640|"
	        cs=cs+"Text,Text105,121.7085,98.95426,����,9.75,False,�����Ӽ�ʻ֤,-2147483640|"
	        cs=cs+"Text,Text103,95.77926,83.07925,����,9,False,���ڳ־�����ʻ֤�������ʻ֤����ģ���Ӧ��д���ּ�ʻ֤���ࣺ,-2147483640|"
	        //cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,A1,-2147483640|"
	        cs=cs+"Text,Text99,51.85838,90.48759,����,9.75,False,�����,-2147483640|"
	        cs=cs+"Text,Text98,8.466675,179.3877,����,9.75,False,�������ύ��������֤��,-2147483640|"
			if(gnid=='T')
				cs=cs+"Text,Text606,8.466675,175.1543,����,9.75,False,��,-2147483640|"	
			cs=cs+"Text,Text96,8.466675,175.1543,����,9.75,False,�����ڻ�֤,-2147483640|"
			if(gnid=='S')
				cs=cs+"Text,Text607,8.466675,167.2168,����,9.75,False,��,-2147483640|"
				
			cs=cs+"Text,Text94,8.466675,167.2168,����,9.75,False,��ע���ָ�,-2147483640|"
			if(gnid=='N')
				cs=cs+"Text,Text608,8.466675,157.1627,����,9.75,False,��,-2147483640|"
				
			cs=cs+"Text,Text92,8.466675,157.1627,����,9.75,False,��ע��,-2147483640|"
			if(gnid=='G')
				cs=cs+"Text,Text609,8.466675,149.2251,����,9.75,False,��,-2147483640|"
	        cs=cs+"Text,Text90,8.466675,149.2251,����,9.75,False,����֤,-2147483640|"
	        
	        cs=cs+"Text,Text88,8.466675,116.4168,����,9.75,False,��֤����ٻ�֤,-2147483640|"
	        cs=cs+"Text,Text86,8.466675,135.996,����,9.75,False,�������Ϣ�仯��֤,-2147483640|"
	        
	        cs=cs+"Text,Text84,46.03754,123.8251,����,9.75,False,����Ը����׼�ݳ��ͻ�֤,-2147483640|"
			if(gnid=='C'&&ls_ywyy=='D')
				cs=cs+"Text,Text700,46.03754,123.8251,����,9.75,False,��,-2147483640|"
				
	        cs=cs+"Text,Text82,8.466675,123.8251,����,9.75,False,���ﵽ�涨���任֤,-2147483640|"
	        cs=cs+"Text,Text80,38.6292,116.4168,����,9.75,False,��ת�뻻֤,-2147483640|"
	        cs=cs+"Text,Text78,61.38339,116.4168,����,9.75,False,����Ч������֤,-2147483640|"
			if(gnid=='C')//��֤
			{
				if(ls_ywyy.indexOf("A")>=0)//����
					cs=cs+"Text,Text610,61.38339,116.4168,����,9.75,False,��,-2147483640|"
				if(ls_ywyy.indexOf("B")>=0)//ת��
					cs=cs+"Text,Text611,38.6292,116.4168,����,9.75,False,��,-2147483640|"		
				if(ls_ywyy.indexOf("G")>=0)//���
					cs=cs+"Text,Text612,8.466675,116.4168,����,9.75,False,��,-2147483640|"	
				if(ls_ywyy.indexOf("B")>=0)//����
					cs=cs+"Text,Text613,8.466675,123.8251,����,9.75,False,��,-2147483640|"		
				if(ls_ywyy.indexOf("G")>=0)//����
					cs=cs+"Text,Text614,46.03754,123.8251,����,9.75,False,��,-2147483640|"		
				if(ls_ywyy.indexOf("E")>=0)//���
					cs=cs+"Text,Text615,8.466675,135.996,����,9.75,False,��,-2147483640|"		
				if(ls_ywyy.indexOf("F")>=0)//��ʧ��֤
					cs=cs+"Text,Text616,8.466675,149.2251,����,9.75,False,��,-2147483640|"							
			}
	        
	        
	        cs=cs+"Text,Text76,8.466675,106.3626,����,9.75,False,���־����ʻ֤,-2147483640|"
			if(gnid=='A'&&(ls_ly=='E'||ls_ly=='F'||ls_ly=='G'||ls_ly=='H'))
			{
			    cs=cs+"Text,Text617,8.466675,106.3626,����,9.75,False,��,-2147483640|"
			    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
			}
	        
	        cs=cs+"Text,Text74,8.466675,98.42509,����,9.75,False,���־�����ʻ֤,-2147483640|"
			if(gnid=='A'&&ls_ly=='D')
			{
			    cs=cs+"Text,Text618,8.466675,98.42509,����,9.75,False,��,-2147483640|"
			    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
			}
	        
	        cs=cs+"Text,Text72,8.466675,91.01675,����,9.75,False,������׼�ݳ���,-2147483640|"
			if(gnid=='B')
			{
			    cs=cs+"Text,Text619,8.466675,91.01675,����,9.75,False,��,-2147483640|"
			    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
			}
	        
	        cs=cs+"Text,Text70,8.466675,83.07925,����,9.75,False,����������,-2147483640|"
			if(gnid=='A'&&(ls_ly=='A'||ls_ly=='B'))
			{
			    cs=cs+"Text,Text620,8.466675,83.07925,����,9.75,False,��,-2147483640|"
			    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
			}
			if(yb=="--")
				cs=cs+"Text,Text68,115.8876,73.02507,����,9.75,False,,-2147483640|"
			else
			    cs=cs+"Text,Text68,115.8876,73.02507,����,9.75,False,"+yb+",-2147483640|"
			if(dzyx=="--")
				cs=cs+"Text,Text67,115.8876,62.9709,����,9.75,False,,-2147483640|"
			else
			    cs=cs+"Text,Text67,115.8876,62.9709,����,9.75,False,"+dzyx+",-2147483640|"
			if(sjhm=="--")
				cs=cs+"Text,Text66,16.93335,73.02507,����,9.75,False,,-2147483640|"
			else
			    cs=cs+"Text,Text66,16.93335,73.02507,����,9.75,False,"+sjhm+",-2147483640|"
			if (lxdh=="--")
				cs=cs+"Text,Text65,16.93335,62.9709,����,9.75,False,,-2147483640|"
			else
			    cs=cs+"Text,Text65,16.93335,62.9709,����,9.75,False,"+lxdh+",-2147483640|"
	        
	        cs=cs+"Text,Text64,16.93335,53.44588,����,9.75,False,"+lxdz+",-2147483640|"
	        
	        cs=cs+"Text,Text63,160.3377,44.45004,����,9.75,False,"+z17+",-2147483640|"
	        cs=cs+"Text,Text61,155.046,44.45004,����,9.75,False,"+z16+",-2147483640|"
	        cs=cs+"Text,Text60,149.2251,44.45004,����,9.75,False,"+z15+",-2147483640|"
	        cs=cs+"Text,Text59,143.9335,44.45004,����,9.75,False,"+z14+",-2147483640|"
	        cs=cs+"Text,Text58,138.6418,44.45004,����,9.75,False,"+z13+",-2147483640|"
	        cs=cs+"Text,Text62,133.3501,44.45004,����,9.75,False,"+z12+",-2147483640|"
	        cs=cs+"Text,Text57,127.5293,44.45004,����,9.75,False,"+z11+",-2147483640|"
	        cs=cs+"Text,Text56,121.1793,44.45004,����,9.75,False,"+z10+",-2147483640|"
	        cs=cs+"Text,Text55,116.4168,44.45004,����,9.75,False,"+z9+",-2147483640|"
	        cs=cs+"Text,Text54,111.1251,44.45004,����,9.75,False,"+z8+",-2147483640|"
	        cs=cs+"Text,Text53,105.3043,44.45004,����,9.75,False,"+z7+",-2147483640|"
	        cs=cs+"Text,Text52,100.0126,44.45004,����,9.75,False,"+z6+",-2147483640|"
	        cs=cs+"Text,Text51,94.19176,44.45004,����,9.75,False,"+z5+",-2147483640|"
	        cs=cs+"Text,Text50,89.95842,44.45004,����,9.75,False,"+z4+",-2147483640|"
	        cs=cs+"Text,Text49,83.60841,44.45004,����,9.75,False,"+z3+",-2147483640|"
	        cs=cs+"Text,Text48,77.78757,44.45004,����,9.75,False,"+z2+",-2147483640|"
	        cs=cs+"Text,Text47,72.4959,44.45004,����,9.75,False,"+z1+",-2147483640|"
	        cs=cs+"Text,Text46,66.67506,44.45004,����,9.75,False,"+z0+",-2147483640|"
	        
	        cs=cs+"Text,Text45,160.3377,37.0417,����,9.75,False,"+b17+",-2147483640|"
	        cs=cs+"Text,Text43,155.046,37.0417,����,9.75,False,"+b16+",-2147483640|"
	        cs=cs+"Text,Text42,149.2251,37.0417,����,9.75,False,"+b15+",-2147483640|"
	        cs=cs+"Text,Text41,143.9335,37.0417,����,9.75,False,"+b14+",-2147483640|"
	        cs=cs+"Text,Text40,138.6418,37.0417,����,9.75,False,"+b13+",-2147483640|"
	        cs=cs+"Text,Text44,133.3501,37.0417,����,9.75,False,"+b12+",-2147483640|"
	        cs=cs+"Text,Text39,127.5293,37.0417,����,9.75,False,"+b11+",-2147483640|"
	        cs=cs+"Text,Text38,121.1793,37.0417,����,9.75,False,"+b10+",-2147483640|"
	        cs=cs+"Text,Text37,116.4168,37.0417,����,9.75,False,"+b9+",-2147483640|"
	        cs=cs+"Text,Text36,111.1251,37.0417,����,9.75,False,"+b8+",-2147483640|"
	        cs=cs+"Text,Text35,105.3043,37.0417,����,9.75,False,"+b7+",-2147483640|"
	        cs=cs+"Text,Text34,100.0126,37.0417,����,9.75,False,"+b6+",-2147483640|"
	        cs=cs+"Text,Text33,94.19176,37.0417,����,9.75,False,"+b5+",-2147483640|"
	        cs=cs+"Text,Text32,89.42925,37.0417,����,9.75,False,"+b4+",-2147483640|"
	        cs=cs+"Text,Text31,83.60841,37.0417,����,9.75,False,"+b3+",-2147483640|"
	        cs=cs+"Text,Text30,77.78757,37.0417,����,9.75,False,"+b2+",-2147483640|"
	        cs=cs+"Text,Text29,72.4959,37.0417,����,9.75,False,"+b1+",-2147483640|"
	        cs=cs+"Text,Text28,66.67506,37.0417,����,9.75,False,"+b0+",-2147483640|"
	        
			if(z0=="")
				cs=cs+"Text,Text27,16.93335,44.45004,����,9.75,False,,-2147483640|"
			else
			    cs=cs+"Text,Text27,16.93335,44.45004,����,9.75,False,��ס֤,-2147483640|"
			    
		        cs=cs+"Text,Text26,17.46252,37.0417,����,9.75,False,"+sfzmmc+",-2147483640|"
		        cs=cs+"Text,Text25,176.7418,30.16253,����,9.75,False,"+gj+",-2147483640|"
		        cs=cs+"Text,Text24,132.821,29.63336,����,9.75,False,"+csrq+",-2147483640|"
		        cs=cs+"Text,Text23,104.7751,29.63336,����,9.75,False,"+xb+",-2147483640|"
		        cs=cs+"Text,Text22,20.63752,29.63336,����,9.75,False,"+xm+",-2147483640|"
		        
		        if(gnid=='A' ||(gnid=='C'&&ls_ywyy=='B'))
		        	cs=cs+"Text,Text21,166.1585,21.43127,����,9,False,,-2147483640|"
		        else{	
				if(dabh=="--")
					cs=cs+"Text,Text21,166.1585,21.43127,����,9,False,,-2147483640|"
				else
				    cs=cs+"Text,Text21,166.1585,21.43127,����,9,False,"+dabh+",-2147483640|"
		        }
			    
	        cs=cs+"Text,Text20,95.77926,73.02507,����,9.75,False,��������,-2147483640|"
	        cs=cs+"Text,Text19,95.77926,62.9709,����,9.75,False,��������,-2147483640|"
	        cs=cs+"Text,Text18,8.466675,74.61257,����,9.75,False,�绰,-2147483640|"
	        cs=cs+"Text,Text17,8.466675,71.43757,����,9.75,False,�ƶ�,-2147483640|"
	        cs=cs+"Text,Text15,8.466675,61.38339,����,9.75,False,�̶�,-2147483640|"
	        cs=cs+"Text,Text14,8.466675,55.03339,����,9.75,False,��ַ,-2147483640|"
	        cs=cs+"Text,Text13,8.466675,50.80005,����,9.75,False,�ʼ�,-2147483640|"
	        cs=cs+"Text,Text12,54.50422,44.45004,����,9.75,False,����,-2147483640|"
	        cs=cs+"Text,Text11,54.50422,37.0417,����,9.75,False,����,-2147483640|"
	        cs=cs+"Text,Text10,8.202091,44.97921,����,9.75,False,����,-2147483640|"
	        cs=cs+"Text,Text9,8.202091,40.74587,����,9.75,False,֤��,-2147483640|"
	        cs=cs+"Text,Text8,8.202091,36.51254,����,9.75,False,���,-2147483640|"
	        cs=cs+"Text,Text7,166.1585,30.16253,����,9.75,False,����,-2147483640|"
	        cs=cs+"Text,Text6,115.8876,29.63336,����,9.75,False,��������,-2147483640|"
	        cs=cs+"Text,Text5,94.19176,29.63336,����,9.75,False,�Ա�,-2147483640|"
	        cs=cs+"Text,Text4,8.202091,29.89795,����,9.75,False,����,-2147483640|"
	        cs=cs+"Text,Text3,146.0501,20.9021,����,9,True,�������,-2147483640|"
	        cs=cs+"Text,Text2,78.05216,21.43127,����,9,True,�����ǩ��ǩ��,-2147483640|"
	        cs=cs+"Text,Text1,56.09172,8.995842,����,18,True,�� �� �� �� ʻ ֤ �� �� ��,-2147483640|"
	        cs=cs+"Line,Line44,1,1,70.64382,197.644,174.096,174.096|"
	        cs=cs+"Line,Line43,1,1,51.06463,51.06463,162.9835,174.096|"
	        cs=cs+"Line,Line36,1,1,35.4542,35.4542,162.9835,174.096|"
	        cs=cs+"Line,Line28,1,1,65.61673,65.61673,147.1085,183.8856|"
	        cs=cs+"Line,Line17,1,1,103.7168,103.7168,17.99168,35.98337|"
	        cs=cs+"Line,Line4,1,1,7.937508,197.644,35.98337,35.98337|"
	        cs=cs+"Line,Line33,1,1,75.67091,197.644,17.99168,17.99168|"
	        cs=cs+"Line,Line32,1,1,75.67091,75.67091,17.99168,28.04586|"
	        cs=cs+"Line,Line86,1,1,103.7168,103.7168,35.98337,50.0063|"
	        cs=cs+"Line,Line82,1,1,7.937508,7.937508,28.04586,183.8856|"
	        cs=cs+"Line,Line81,1,1,1.058334,197.644,79.90424,79.90424|"
	        cs=cs+"Line,Line74,1,1,35.4542,197.644,206.1106,206.1106|"
	        cs=cs+"Line,Line73,1,1,136.7897,136.7897,129.9106,146.9144|"
	        cs=cs+"Line,Line72,1,1,87.31258,87.31258,35.98337,49.74171|"
	        cs=cs+"Line,Line70,1,1,153.1939,197.644,254.0003,254.0003|"
	        cs=cs+"Line,Line69,1,1,153.1939,153.1939,214.5773,282.0461|"
	        cs=cs+"Line,Line68,1,1,1.058334,197.644,282.0461,282.0461|"
	        cs=cs+"Line,Line67,1,1,7.937508,7.937508,214.5773,282.0461|"
	        cs=cs+"Line,Line66,1,1,142.346,142.346,197.3794,214.5773|"
	        cs=cs+"Line,Line65,1,1,98.16051,98.16051,197.3794,205.9872|"
	        cs=cs+"Line,Line64,1,1,125.6772,125.6772,197.3794,214.5773|"
	        cs=cs+"Line,Line63,1,1,81.75633,81.75633,197.3794,205.9872|"
	        cs=cs+"Line,Line62,1,1,58.20839,58.20839,197.3794,214.5773|"
	        cs=cs+"Line,Line61,1,1,1.058334,197.644,214.5773,214.5773|"
	        cs=cs+"Line,Line60,1,1,153.1939,197.644,227.0127,227.0127|"
	        cs=cs+"Line,Line59,1,1,35.4542,35.4542,183.8856,214.5773|"
	        cs=cs+"Line,Line58,1,1,1.058334,197.644,197.3794,197.3794|"
	        cs=cs+"Line,Line57,1,1,114.8293,168.2752,191.0294,191.0294|"
	        cs=cs+"Line,Line48,1,1,7.937508,65.61673,155.046,155.046|"
	        cs=cs+"Line,Line49,1,1,7.937508,65.61673,162.9835,162.9835|"
	        cs=cs+"Line,Line56,1,1,70.64382,197.644,155.046,155.046|"
	        cs=cs+"Line,Line55,1,1,70.64382,197.644,162.9835,162.9835|"
	        cs=cs+"Line,Line54,1,1,70.64382,70.64382,129.9106,183.8856|"
	        cs=cs+"Line,Line53,1,1,142.8751,142.8751,121.973,129.9635|"
	        cs=cs+"Line,Line52,1,1,103.7168,103.7168,130.1751,147.0026|"
	        cs=cs+"Line,Line51,1,1,7.937508,65.61673,174.096,174.096|"
	        cs=cs+"Line,Line50,1,1,1.058334,197.644,183.8856,183.8856|"
	        cs=cs+"Line,Line47,1,1,7.937508,197.644,129.9106,129.9106|"
	        cs=cs+"Line,Line46,1,1,7.937508,197.644,147.1085,147.1085|"
	        cs=cs+"Line,Line45,1,1,51.06463,51.06463,129.9106,147.1085|"
	        cs=cs+"Line,Line42,1,1,7.937508,197.644,121.973,121.973|"
	        cs=cs+"Line,Line41,1,1,65.61673,65.61673,80.16883,113.965|"
	        cs=cs+"Line,Line40,1,1,7.937508,197.644,114.0355,114.0355|"
	        cs=cs+"Line,Line39,1,1,51.06463,51.06463,80.16883,113.965|"
	        cs=cs+"Line,Line38,1,1,114.8293,114.8293,60.06047,79.90424|"
	        cs=cs+"Line,Line37,1,1,92.86884,92.86884,60.06047,129.9106|"
	        cs=cs+"Line,Line35,1,1,7.937508,164.6768,70.11465,70.11465|"
	        cs=cs+"Line,Line11,1,1,7.937508,164.6768,60.06047,60.06047|"
	        cs=cs+"Line,Line34,1,1,142.8751,142.8751,17.99168,28.04586|"
	        cs=cs+"Line,Line31,1,1,175.6835,175.6835,35.98337,28.04586|"
	        cs=cs+"Line,Line30,1,1,197.644,197.644,17.99168,282.0461|"
	        cs=cs+"Line,Line29,1,1,164.8356,164.8356,17.99168,79.90424|"
	        cs=cs+"Line,Line27,1,1,158.7502,158.7502,35.98337,50.0063|"
	        cs=cs+"Line,Line26,1,1,153.1939,153.1939,35.98337,50.0063|"
	        cs=cs+"Line,Line25,1,1,147.6376,147.6376,35.98337,50.0063|"
	        cs=cs+"Line,Line24,1,1,142.346,142.346,35.98337,50.0063|"
	        cs=cs+"Line,Line23,1,1,136.7897,136.7897,35.98337,50.0063|"
	        cs=cs+"Line,Line22,1,1,131.2335,131.2335,28.04586,50.0063|"
	        cs=cs+"Line,Line21,1,1,125.6772,125.6772,35.98337,50.0063|"
	        cs=cs+"Line,Line20,1,1,120.3855,120.3855,35.98337,50.0063|"
	        cs=cs+"Line,Line19,1,1,114.8293,114.8293,28.04586,50.0063|"
	        cs=cs+"Line,Line18,1,1,109.273,109.273,35.98337,50.0063|"
	        cs=cs+"Line,Line16,1,1,98.16051,98.16051,35.98337,50.0063|"
	        cs=cs+"Line,Line15,1,1,92.86884,92.86884,28.04586,50.0063|"
	        cs=cs+"Line,Line14,1,1,81.75633,81.75633,35.98337,49.98866|"
	        cs=cs+"Line,Line13,1,1,76.20007,76.20007,35.98337,50.0063|"
	        cs=cs+"Line,Line12,1,1,70.64382,70.64382,35.98337,50.0063|"
	        cs=cs+"Line,Line10,1,1,70.64382,70.64382,36.51254,50.0063|"
	        cs=cs+"Line,Line9,1,1,65.61673,65.61673,35.98337,50.0063|"
	        cs=cs+"Line,Line8,1,1,51.06463,51.06463,35.98337,49.98866|"
	        cs=cs+"Line,Line7,1,1,16.66877,164.6592,43.12712,43.12712|"
	        cs=cs+"Line,Line6,1,1,7.937508,164.6768,50.0063,50.0063|"
	        cs=cs+"Line,Line5,1,1,16.66877,16.66877,28.04586,79.90424|"
	        cs=cs+"Line,Line3,1,1,7.937508,7.937508,28.04586,180.1991|"
	        cs=cs+"Line,Line2,1,1,1.058334,1.058334,28.04586,282.0461|"
	        cs=cs+"Line,Line1,1,1,1.058334,197.644,28.04586,28.04586"
	        }else{
				if(gnid=='C')//��֤
				{
					if(ls_ywyy.indexOf("C")>=0)//����
						cs=cs+"Text,Text600,143.9335,123.8251,����,9.75,False,"+cx+",-2147483640|"		
					if(ls_ywyy.indexOf("D")>=0)//����
						cs=cs+"Text,Text601,143.9335,123.8251,����,9.75,False,"+cx+",-2147483640|"					
				}
				if(gnid=='A')
				{
					if(ls_ly=='E')//�����ʻ֤
						cs=cs+"Text,Text602,173.0377,106.3626,����,9.75,False,��,-2147483640|"
					if(ls_ly=='F')//���
					    cs=cs+"Text,Text603,96.30843,106.3626,����,9.75,False,��,-2147483640|"
					if(ls_ly=='G')//����
					    cs=cs+"Text,Text604,121.7085,106.3626,����,9.75,False,��,-2147483640|"		
					if(ls_ly=='H')//̨��
						cs=cs+"Text,Text605,148.1668,106.3626,����,9.75,False,��,-2147483640|"				    
				}
				if(gnid=='T')
					cs=cs+"Text,Text606,8.466675,175.1543,����,9.75,False,��,-2147483640|"	
				if(gnid=='S')
					cs=cs+"Text,Text607,8.466675,167.2168,����,9.75,False,��,-2147483640|"
				if(gnid=='N')
					cs=cs+"Text,Text608,8.466675,157.1627,����,9.75,False,��,-2147483640|"					
				if(gnid=='G')
					cs=cs+"Text,Text609,8.466675,149.2251,����,9.75,False,��,-2147483640|"
		        
				if(gnid=='C'&&ls_ywyy=='D')
					cs=cs+"Text,Text700,46.03754,123.8251,����,9.75,False,��,-2147483640|"
				if(gnid=='C')//��֤
				{
					if(ls_ywyy.indexOf("A")>=0)//����
						cs=cs+"Text,Text610,61.38339,116.4168,����,9.75,False,��,-2147483640|"
					if(ls_ywyy.indexOf("B")>=0)//ת��
						cs=cs+"Text,Text611,38.6292,116.4168,����,9.75,False,��,-2147483640|"		
					if(ls_ywyy.indexOf("G")>=0)//���
						cs=cs+"Text,Text612,8.466675,116.4168,����,9.75,False,��,-2147483640|"	
					if(ls_ywyy.indexOf("B")>=0)//����
						cs=cs+"Text,Text613,8.466675,123.8251,����,9.75,False,��,-2147483640|"		
					if(ls_ywyy.indexOf("G")>=0)//����
						cs=cs+"Text,Text614,46.03754,123.8251,����,9.75,False,��,-2147483640|"		
					if(ls_ywyy.indexOf("E")>=0)//���
						cs=cs+"Text,Text615,8.466675,135.996,����,9.75,False,��,-2147483640|"		
					if(ls_ywyy.indexOf("F")>=0)//��ʧ��֤
						cs=cs+"Text,Text616,8.466675,149.2251,����,9.75,False,��,-2147483640|"							
				}
		        
				if(gnid=='A'&&(ls_ly=='E'||ls_ly=='F'||ls_ly=='G'||ls_ly=='H'))
				{
				    cs=cs+"Text,Text617,8.466675,106.3626,����,9.75,False,��,-2147483640|"
				    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
				}
		        
				if(gnid=='A'&&ls_ly=='D')
				{
				    cs=cs+"Text,Text618,8.466675,98.42509,����,9.75,False,��,-2147483640|"
				    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
				}
		        
				if(gnid=='B')
				{
				    cs=cs+"Text,Text619,8.466675,91.01675,����,9.75,False,��,-2147483640|"
				    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
				}
		        
				if(gnid=='A'&&(ls_ly=='A'||ls_ly=='B'))
				{
				    cs=cs+"Text,Text620,8.466675,83.07925,����,9.75,False,��,-2147483640|"
				    cs=cs+"Text,Text101,69.85007,94.19176,����,9.75,False,"+cx+",-2147483640|"
				}
				if(yb=="--")
					cs=cs+"Text,Text68,115.8876,73.02507,����,9.75,False,,-2147483640|"
				else
				    cs=cs+"Text,Text68,115.8876,73.02507,����,9.75,False,"+yb+",-2147483640|"
				if(dzyx=="--")
					cs=cs+"Text,Text67,115.8876,62.9709,����,9.75,False,,-2147483640|"
				else
				    cs=cs+"Text,Text67,115.8876,62.9709,����,9.75,False,"+dzyx+",-2147483640|"
				if(sjhm=="--")
					cs=cs+"Text,Text66,16.93335,73.02507,����,9.75,False,,-2147483640|"
				else
				    cs=cs+"Text,Text66,16.93335,73.02507,����,9.75,False,"+sjhm+",-2147483640|"
				if (lxdh=="--")
					cs=cs+"Text,Text65,16.93335,62.9709,����,9.75,False,,-2147483640|"
				else
				    cs=cs+"Text,Text65,16.93335,62.9709,����,9.75,False,"+lxdh+",-2147483640|"
		        
		        cs=cs+"Text,Text64,16.93335,53.44588,����,9.75,False,"+lxdz+",-2147483640|"
		        
		        cs=cs+"Text,Text63,160.3377,44.45004,����,9.75,False,"+z17+",-2147483640|"
		        cs=cs+"Text,Text61,155.046,44.45004,����,9.75,False,"+z16+",-2147483640|"
		        cs=cs+"Text,Text60,149.2251,44.45004,����,9.75,False,"+z15+",-2147483640|"
		        cs=cs+"Text,Text59,143.9335,44.45004,����,9.75,False,"+z14+",-2147483640|"
		        cs=cs+"Text,Text58,138.6418,44.45004,����,9.75,False,"+z13+",-2147483640|"
		        cs=cs+"Text,Text62,133.3501,44.45004,����,9.75,False,"+z12+",-2147483640|"
		        cs=cs+"Text,Text57,127.5293,44.45004,����,9.75,False,"+z11+",-2147483640|"
		        cs=cs+"Text,Text56,121.1793,44.45004,����,9.75,False,"+z10+",-2147483640|"
		        cs=cs+"Text,Text55,116.4168,44.45004,����,9.75,False,"+z9+",-2147483640|"
		        cs=cs+"Text,Text54,111.1251,44.45004,����,9.75,False,"+z8+",-2147483640|"
		        cs=cs+"Text,Text53,105.3043,44.45004,����,9.75,False,"+z7+",-2147483640|"
		        cs=cs+"Text,Text52,100.0126,44.45004,����,9.75,False,"+z6+",-2147483640|"
		        cs=cs+"Text,Text51,94.19176,44.45004,����,9.75,False,"+z5+",-2147483640|"
		        cs=cs+"Text,Text50,89.95842,44.45004,����,9.75,False,"+z4+",-2147483640|"
		        cs=cs+"Text,Text49,83.60841,44.45004,����,9.75,False,"+z3+",-2147483640|"
		        cs=cs+"Text,Text48,77.78757,44.45004,����,9.75,False,"+z2+",-2147483640|"
		        cs=cs+"Text,Text47,72.4959,44.45004,����,9.75,False,"+z1+",-2147483640|"
		        cs=cs+"Text,Text46,66.67506,44.45004,����,9.75,False,"+z0+",-2147483640|"
		        
		        cs=cs+"Text,Text45,160.3377,37.0417,����,9.75,False,"+b17+",-2147483640|"
		        cs=cs+"Text,Text43,155.046,37.0417,����,9.75,False,"+b16+",-2147483640|"
		        cs=cs+"Text,Text42,149.2251,37.0417,����,9.75,False,"+b15+",-2147483640|"
		        cs=cs+"Text,Text41,143.9335,37.0417,����,9.75,False,"+b14+",-2147483640|"
		        cs=cs+"Text,Text40,138.6418,37.0417,����,9.75,False,"+b13+",-2147483640|"
		        cs=cs+"Text,Text44,133.3501,37.0417,����,9.75,False,"+b12+",-2147483640|"
		        cs=cs+"Text,Text39,127.5293,37.0417,����,9.75,False,"+b11+",-2147483640|"
		        cs=cs+"Text,Text38,121.1793,37.0417,����,9.75,False,"+b10+",-2147483640|"
		        cs=cs+"Text,Text37,116.4168,37.0417,����,9.75,False,"+b9+",-2147483640|"
		        cs=cs+"Text,Text36,111.1251,37.0417,����,9.75,False,"+b8+",-2147483640|"
		        cs=cs+"Text,Text35,105.3043,37.0417,����,9.75,False,"+b7+",-2147483640|"
		        cs=cs+"Text,Text34,100.0126,37.0417,����,9.75,False,"+b6+",-2147483640|"
		        cs=cs+"Text,Text33,94.19176,37.0417,����,9.75,False,"+b5+",-2147483640|"
		        cs=cs+"Text,Text32,89.42925,37.0417,����,9.75,False,"+b4+",-2147483640|"
		        cs=cs+"Text,Text31,83.60841,37.0417,����,9.75,False,"+b3+",-2147483640|"
		        cs=cs+"Text,Text30,77.78757,37.0417,����,9.75,False,"+b2+",-2147483640|"
		        cs=cs+"Text,Text29,72.4959,37.0417,����,9.75,False,"+b1+",-2147483640|"
		        cs=cs+"Text,Text28,66.67506,37.0417,����,9.75,False,"+b0+",-2147483640|"
		        
				if(z0=="")
					cs=cs+"Text,Text27,16.93335,44.45004,����,9.75,False,,-2147483640|"
				else
				    cs=cs+"Text,Text27,16.93335,44.45004,����,9.75,False,��ס֤,-2147483640|"
				    
			        cs=cs+"Text,Text26,17.46252,37.0417,����,9.75,False,"+sfzmmc+",-2147483640|"
			        cs=cs+"Text,Text25,176.7418,30.16253,����,9.75,False,"+gj+",-2147483640|"
			        cs=cs+"Text,Text24,132.821,29.63336,����,9.75,False,"+csrq+",-2147483640|"
			        cs=cs+"Text,Text23,104.7751,29.63336,����,9.75,False,"+xb+",-2147483640|"
			        cs=cs+"Text,Text22,20.63752,29.63336,����,9.75,False,"+xm+",-2147483640|"
			        
			        if(gnid=='A' ||(gnid=='C'&&ls_ywyy=='B'))
			        	cs=cs+"Text,Text21,166.1585,21.43127,����,9,False,,-2147483640"
			        else{	
					if(dabh=="--")
						cs=cs+"Text,Text21,166.1585,21.43127,����,9,False,,-2147483640"
					else
					    cs=cs+"Text,Text21,166.1585,21.43127,����,9,False,"+dabh+",-2147483640"
			        }
	        }
	        drvprint.printData=cs;
            drvprint.data_print();
    	}
    	catch(err)
    	{
    	    alert(err.description);
  		}       
    }
    else if(code=="0")
    {
         msg="δ�ҵ���Ӧ����ˮ��¼��";
         alert(msg);
    }
    else if(code=="-1")
    {
         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
         msg="��ȡ���ݹ����г����쳣��"+msg;
         alert(msg);
    }    
}
//����ƾ֤��ӡ
function print_slpz(lsh)
{
    var spath="print.do?method=queryPrintSlpz&lsh="+lsh;
    send_request(spath,"printSlpz()",false); 
}
function printSlpz()
{
    var xmlDoc = _xmlHttpRequestObj.responseXML;
    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;

    var msg="";
    if(code=="1")
    {
        var lsh=xmlDoc.getElementsByTagName("lsh")[0].firstChild.data;
        var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
        if(dabh=="--")
        {
           dabh="";
        }
        var glbm=xmlDoc.getElementsByTagName("glbm")[0].firstChild.data;
        var bmmc=xmlDoc.getElementsByTagName("bmmc")[0].firstChild.data;
        var tmztgd=xmlDoc.getElementsByTagName("tmztgd")[0].firstChild.data;
        var tmzt=xmlDoc.getElementsByTagName("tmzt")[0].firstChild.data;
        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
        var sfzmmc=xmlDoc.getElementsByTagName("sfzmmc_1")[0].firstChild.data;
        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
        
        var ywlx=xmlDoc.getElementsByTagName("ywlx")[0].firstChild.data;
        var ywlx_mc=xmlDoc.getElementsByTagName("ywlx_mc")[0].firstChild.data;
        var ywyy_mc=xmlDoc.getElementsByTagName("ywyy_mc")[0].firstChild.data;
        var checktdsy=xmlDoc.getElementsByTagName("checktdsy")[0].firstChild.data;
        var clrq=xmlDoc.getElementsByTagName("clrq")[0].firstChild.data;
        var clsj=xmlDoc.getElementsByTagName("clsj")[0].firstChild.data;
        var jbr=xmlDoc.getElementsByTagName("jbr")[0].firstChild.data;
        var zjcx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
        var syrq=xmlDoc.getElementsByTagName("syrq")[0].firstChild.data;
        
        
        var ls_ts1=xmlDoc.getElementsByTagName("ls_ts1")[0].firstChild.data;
        var ls_ts2=xmlDoc.getElementsByTagName("ls_ts2")[0].firstChild.data;
        var ls_ts3=xmlDoc.getElementsByTagName("ls_ts3")[0].firstChild.data;
        var ls_ts4=xmlDoc.getElementsByTagName("ls_ts4")[0].firstChild.data;
        var ls_ts5=xmlDoc.getElementsByTagName("ls_ts5")[0].firstChild.data;
        
        if(syrq=="--"){syrq=""};
        var sfje="";
        var yqts="";
        var sqrq="";
        if(ywyy_mc!="--")
        {
        	ywlx_mc=ywlx_mc+"("+ywyy_mc+")";
        }
    	try
    	{
  			var cs = "";
  			if (glbm.substring(0,4)=="44")
  			{
    			cs ="Text,Text29,10.58334,112.1834,����,9,False,"+ls_ts5+",-2147483640|";
    			cs+="Text,Text28,10.58334,107.9501,����,9,False,"+ls_ts4+",-2147483640|";
    			cs+="Text,Text27,10.58334,103.7168,����,9,False,"+ls_ts3+",-2147483640|";
    			cs+="Text,Text26,10.58334,99.48343,����,9,False,"+ls_ts2+",-2147483640|";
    			cs+="Text,Text25,71.96674,127.0001,����,9,False,"+clrq+",-2147483640|";
    			cs+="Text,Text24,46.56671,127.0001,����,9,False,"+jbr+",-2147483640|";
    			cs+="Text,Text23,33.8667,127.0001,����,9,False,������:,-2147483640|";
    			cs+="Text,Text8,44.45004,118.5334,����,9,False,"+bmmc+",-2147483640|";
    			if (glbm.substring(0,4)=="4403")
    			{
    				cs+="Text,Text22,10.58334,33.8667,"+tmztgd+",False,"+"*"+"B"+lsh+"*"+",-2147483640|";
            	}
            	else
            	{
        			cs+="Text,Text22,10.58334,33.8667,"+tmzt+",False,"+"*"+lsh+"*"+",-2147483640|";
    			}
    			cs+="Text,Text21,16.93335,95.25009,����,9,False,"+ls_ts1+",-2147483640|";
    			cs+= "Text,Text20,40.21671,86.78342,����,9,False,"+xm+",-2147483640|";
    			cs+="Text,Text19,10.58334,86.78342,����,9,False,����/��ʻ��:,-2147483640|";
    			cs+="Text,Text18,65.61673,88.37092,����,9,False,"+ywlx_mc+",-2147483640|";
    			cs+="Text,Text17,46.56671,80.43341,����,9,False,"+sfzmhm+",-2147483640|";
    			cs+="Text,Text16,10.58334,80.43341,����,9,False,���ƺ���/��ʻ֤��:,-2147483640|";
    			cs+="Text,Text15,29.63336,74.0834,����,9,False,"+lsh+",-2147483640|";
    			cs+="Text,Text14,10.58334,74.0834,����,9,False,��ˮ��:,-2147483640|";
    			cs+="Text,Text13,35.98337,65.61673,����,14.25,False,�ݹ�ҵ������ƾ֤,-2147483640|";
    			cs+="Text,Text12,10.58334,46.56671,����,9,False,---------------------------------------------------,-2147483640|";
    			cs+="Text,Text11,48.68338,59.26672,����,9,False,"+lsh+",-2147483640|";
    			cs+="Text,Text10,48.68338,42.33337,����,9,False,"+lsh+",-2147483640|";
    			cs+="Text,Text9,10.58334,50.80005,"+tmzt+",False,*"+lsh+"*,-2147483640|";
    			cs+="Text,Text7,40.21671,27.51669,����,9,False,"+xm+",-2147483640|";
    			cs+="Text,Text6,10.58334,27.51669,����,9,False,����/��ʻ��:,-2147483640|";
    			cs+="Text,Text5,65.61673,12.43543,����,9,False,"+ywlx_mc+",-2147483640|";
    			cs+="Text,Text4,46.56671,21.16669,����,9,False,"+sfzmhm+",-2147483640|";
    			cs+="Text,Text3,10.58334,21.16669,����,9,False,���ƺ���/��ʻ֤��:,-2147483640|";
    			cs+="Text,Text2,29.63336,12.70001,����,9,False,"+lsh+",-2147483640|";
    			cs+="Text,Text1,10.58334,12.70001,����,9,False,��ˮ��:,-2147483640";
    		}
    		else if(glbm.substring(0,4)=="5101")
    		{
  				cs="Text,Text1,.5291672,-.5291672,����,14.25,False,�ɶ���ͨ����֧�ӳ�����|";
  				cs=cs+"Text,Text2,11.75835,7.40834,����,14.25,False,��������ʻ֤ҵ������ƾ֤|";
  				cs=cs+"Text,Text3,17.99168,16.93335,����,12,False,ҵ����ˮ�ţ�|";
  				cs=cs+"Text,lsh,16.93335,25.13544,"+tmzt+",False,*"+lsh+"*|";
  				cs=cs+"Text,Text4,.5291672,43.92088,����,10.5,False,ҵ�����ࣺ|";
  				cs=cs+"Text,ywzl,25.92919,43.92088,����,10.5,False,"+ywlx_mc+"|";
  				cs=cs+"Text,Text6,.5291672,51.32922,����,10.5,False,������ţ�|";
  				cs=cs+"Text,dabh,25.92919,51.32922,����,10.5,False,"+dabh+"|";
  				cs=cs+"PictureBox,Picwoman,-1.587502,15.34585|";
  				cs=cs+"Text,Text22,.5291672,58.73756,����,10.5,False,���֤�����ƣ�|";
  				cs=cs+"Text,sfzmmc,25.92919,58.73756,����,10.5,False,"+sfzmmc+"|";
  				cs=cs+"Text,Text7,.5291672,66.1459,����,10.5,False,���֤�����룺|";
  				cs=cs+"Text,sfzmhm,25.92919,66.1459,����,10.5,False,"+sfzmhm+"|";
  				cs=cs+"Text,Text8,.5291672,73.55424,����,10.5,False,������|";
  				cs=cs+"Text,xm,25.92919,73.55424,����,10.5,False,"+xm+"|";
  				cs=cs+"Text,Text21,0,80.96258,����,10.5,False,���ͣ�|";
  				cs=cs+"Text,zjcx,25.92919,80.96258,����,10.5,False,"+zjcx+"|";
  				cs=cs+"Text,Text9,0,88.37092,����,10.5,False,����ʱ�䣺|";
  				cs=cs+"Text,slsj,25.92919,88.37092,����,10.5,False,"+clsj+"|";
  				cs=cs+"Text,Text10,0,95.77926,����,10.5,False,�����ˣ�|";
  				cs=cs+"Text,jbr,25.92919,95.77926,����,10.5,False,"+jbr+"|";
  				cs=cs+"Text,jfje,25.92919,103.1876,����,10.5,False,"+sfje+"|";
  				cs=cs+"Text,Text5,0,103.1876,����,10.5,False,�ɷѽ�|";
  				cs=cs+"Text,wxts,0,110.59594,����,10.5,False,"+yqts+"";
  			
  				if (ywlx=="C"||ywlx=="H")
  				{
      				cs=cs+"|Text,xytjrq1111,0,118.00428,����,10.5,False,�������յ�����������֤������¼��������";
      				cs=cs+"|Text,xytjrq,0,125.41262,����,10.5,False,��һ�������Ϊ:"+syrq+"";
    			}
    			else if (checktdsy=="1")
    			{
    		   		cs=cs+"|Text,xytjrq,0,118.00428,����,10.5,False,��һ�������Ϊ:"+syrq+"";
      			}
      			cs=cs+"";
    	 		cs=cs+"";
         	}
         	else
       		{
       			drvprint.posX="20"
       			drvprint.posY="30"
       			cs="Text,jbr,31.75003,87.84175,����,12,False,"+jbr+",-2147483640|";
       			cs=cs+"Text,slsj,31.75003,79.37508,����,12,False,"+clsj+",-2147483640|";
       			cs=cs+"Text,xm,31.75003,70.9084,����,12,False,"+xm+",-2147483640|";
       			cs=cs+"Text,sfzmhm,31.75003,62.44173,����,12,False,"+sfzmhm+",-2147483640|";
       			cs=cs+"Text,dabh,31.75003,53.97505,����,12,False,"+dabh+",-2147483640|";
       			cs=cs+"Text,Text10,2.116669,87.84175,����,12,False,�����ˣ�,-2147483640|";
       			cs=cs+"Text,Text9,2.116669,79.37508,����,12,False,����ʱ�䣺,-2147483640|";
       			cs=cs+"Text,Text8,2.645836,70.9084,����,12,False,������,-2147483640|";
       			cs=cs+"Text,Text7,2.645836,62.44173,����,12,False,���֤�����룺,-2147483640|";
       			cs=cs+"Text,Text6,2.645836,53.97505,����,12,False,������ţ�,-2147483640|";
      	 		cs=cs+"Text,ywzl,31.75003,45.50838,����,12,False,"+ywlx_mc+",-2147483640|";
       			cs=cs+"Text,Text4,2.645836,45.50838,����,12,False,ҵ�����ࣺ,-2147483640|";
       			cs=cs+"Text,lsh,31.75003,33.33753,Arial,15,False,"+lsh+",-2147483640|";
       			cs=cs+"Text,Text3,2.645836,34.92503,����,12,False,ҵ����ˮ�ţ�,-2147483640|";
       			cs=cs+"Text,Text2,21.16669,25.40002,����,15,False,��������ʻ֤ҵ������ƾ֤,-2147483640|";
       			cs=cs+"Text,Text1,4.233337,17.46252,����,15,False,"+bmmc+",-2147483640";
    		}
    		drvprint.printData=cs;
    		drvprint.data_print();
  		}
  		catch(err)
  		{
    		alert(err.description);
  		}      
  	}
  	else if(code=="0")
  	{
         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
         alert(msg);
  	}
  	else if(code=="-1")
  	{
         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
         msg="��ȡ���ݹ����г����쳣��"+msg;
         alert(msg);
  	}
  }

  //����ִ
  function print_tjzm(lsh,dabh)
  {
      var spath="print.do?method=queryPrintTjzm&lsh="+lsh+"&dabh="+dabh;
      send_request(spath,"printTjzm()",false);       
  }
  function printTjzm()
  {
  	  var xmlDoc = _xmlHttpRequestObj.responseXML;
      var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
      var msg="";
      if(code=="1")
      {
          var tjrq=xmlDoc.getElementsByTagName("tjrq")[0].firstChild.data;
          var fzjg=xmlDoc.getElementsByTagName("aaaa")[0].firstChild.data;
          var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
          var syrq=xmlDoc.getElementsByTagName("syrq")[0].firstChild.data;
          var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;  
          var tjyymc=xmlDoc.getElementsByTagName("tjyymc")[0].firstChild.data; 
          var today=xmlDoc.getElementsByTagName("today")[0].firstChild.data;   
          
          cs = "";
          
          
          if (fzjg=="��A")
          {
        	     
        	     cs=cs+"Text,Text9,21.99572,66.99257,����,9.75,False,"+today+",-2147483640|"
        	     cs=cs+"Text,Text8,0,51.32922,����,9.75,True,�´��ύ���ڣ�"+syrq+",-2147483640|"
        	     cs=cs+"Text,Text7,0,46.03754,����,9.75,False,���������ϵͳ�С�,-2147483640|"
        	     cs=cs+"Text,Text6,0,41.27504,����,9.75,False,���ߵġ���������֤����������¼��,-2147483640|"
        	     cs=cs+"Text,Text5,0,36.00101,����,9.75,False,(���֤�����룺"+sfzmhm+"),-2147483640|"
        	     cs=cs+"Text,Text4,0,30.00378,����,9.75,False,"+tjrq+"   Ϊ   "+xm+",-2147483640|"
        	     cs=cs+"Text,Text3,8.995842,24.00655,����,9.75,True,"+tjyymc+",-2147483640|"
        	     cs=cs+"Text,Text2,8.995842,17.99168,����,9.75,False,�������յ�,-2147483640|"
        	     cs=cs+"Text,Text1,1.058334,0,����,15,False,���ա���������֤������ִ,-2147483640"
          }
          else
          { 
        	    var ls_yqts=xmlDoc.getElementsByTagName("tmpstring")[0].firstChild.data;
        	    if(ls_yqts=="--")
        	    {
        	    	cs = "";
        	    }
        	    else
        	    {
        	    	 cs="Text,Text9,6.350006,103.7168,����,14.25,False,������ʾ��|"
        	    	 yqtsArr= ls_yqts.split("����");
        	         var li_rows = 0;
        	         for (var j = 1; j < yqtsArr.length; j++)
        	         {
        	           ls_yqts ="����"+yqtsArr[j];
        	           ls_yqts = ls_yqts.replace("|","\0");
        	           var li_lines = parseInt(ls_yqts.length/24);
        	           var ls_lines = "";
        	           var li_height = 0;
        	           for (var i = 0; i <= li_lines; i++)
        	           {
        	               if (i == 0 ){
        	                   if (ls_yqts.length>=24)
        	                       ls_lines = ls_yqts.substring(0,24);
        	                   else
        	                       ls_lines = ls_yqts.substring(0);
        	                 }
        	                 else if (i != li_lines)
        	                   if (ls_yqts.length>=i*24+24)
        	                     ls_lines = ls_yqts.substring(24 + 24*(i-1),i*24+24);
        	                   else
        	                     ls_lines = ls_yqts.substring(24 + 24*(i-1));
        	                 else
        	                 ls_lines = ls_yqts.substring(24 + 24*(i-1));
        	               
        	             li_height = 103.7168 + 10.58334 + 10.58334 * li_rows;
        	             li_rows=li_rows+1;
        	             if (i==0){      
        	               var tmp1=10+j*10+i;
        	               cs+="Text,Text"+tmp1+",16.05002,"+li_height+",����,14.25,False,"+ls_lines+"|";
        	               
        	             }
        	             else
        	             {
        	            	 var tmp2=10+j*10+i
        	            	 cs+="Text,Text"+tmp2+",6.350006,"+li_height +",����,14.25,False,"+ls_lines+"|";
        	             }
        	           }
        	         }        	    	 
        	    }
                cs=cs+"Text,stzmhzTjrq,8.466675,31.75003,����,14.25,False,"+tjrq+"|"
                cs=cs+"Text,stzmhzSfzmhm,50.80005,42.33337,����,14.25,False,"+sfzmhm+"|"
                cs=cs+"Text,stzmhzHzrq,67.7334,88.90009,����,14.25,False,"+today+"|"
                cs=cs+"Text,stzmhzJsr,67.7334,31.75003,����,14.25,False,"+xm+"|"
                cs=cs+"Text,stzmhzZmdw,48.68338,21.16669,����,14.25,False,"+tjyymc+"|"
                cs=cs+"Text,stzmhzXyrq,55.03339,74.0834,����,14.25,False,"+syrq+"|"
                cs=cs+"Text,Text1,23.28336,4.233337,����,15.75,True,���ա���������֤������ִ|"
                cs=cs+"Text,Text2,19.05002,21.16669,����,14.25,False,�������յ�|"
                cs=cs+"Text,Text3,61.38339,31.75003,����,14.25,False,Ϊ|"
                cs=cs+"Text,Text4,8.466675,42.33337,����,14.25,False,�����֤�����룺|"
                cs=cs+"Text,Text5,105.8334,42.33337,����,14.25,False,��|"
                cs=cs+"Text,Text6,8.466675,52.91672,����,14.25,False,���ߵġ���������֤����������¼��������|"
                cs=cs+"Text,Text7,8.466675,63.50006,����,14.25,False,��ϵͳ�С�|"
                cs=cs+"Text,Text8,19.05002,74.0834,����,14.25,False,�´��ύ���ڣ�|"
                cs=cs+"Line,Line4,1,1,8.466675,61.38339,38.10004,38.10004|"
                cs=cs+"Line,Line3,1,1,46.56671,105.8334,48.68338,48.68338|"
                cs=cs+"Line,Line2,1,1,67.7334,107.9501,38.10004,38.10004|"
                cs=cs+"Line,Line1,1,1,50.80005,107.9501,27.51669,27.51669|"
                cs=cs+"Line,Line5,1,1,55.03339,93.13342,80.43341,80.43341"
          }
          drvprint.printData=cs
          drvprint.data_print();                
      } 
      else if(code=="0")
  	  {
         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
         alert(msg);
  	  }
  	  else if(code=="-1")
  	  {
         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
         msg="��ȡ���ݹ����г����쳣��"+msg;
         alert(msg);
  	  }
  }
    
  function printZkzmd(xmlUrl,top1,left1){
	    var xmlDoc = _xmlHttpRequestObj.responseXML;
	    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
	    var msg=  "";
	    if(code=="1"){ 
	    	
	        var hcbz10=xmlDoc.getElementsByTagName("hcbz_10")[0].firstChild.data;
	        var ywlx=xmlDoc.getElementsByTagName("ywlx")[0].firstChild.data;
	        var fzjg=xmlDoc.getElementsByTagName("fzjg")[0].firstChild.data;
	        var tmztgd=xmlDoc.getElementsByTagName("tmztgd")[0].firstChild.data;
	        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	        var yxqz=xmlDoc.getElementsByTagName("yxqz")[0].firstChild.data;
	        var yxqs=xmlDoc.getElementsByTagName("yxqs")[0].firstChild.data;
	        var zjcx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
	        var csrq=xmlDoc.getElementsByTagName("csrq")[0].firstChild.data;
	        var xb=xmlDoc.getElementsByTagName("xb")[0].firstChild.data;
	        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;   
	        var zkzmhm=xmlDoc.getElementsByTagName("zkzmhm")[0].firstChild.data;

	        
	  		drvprint.posX= left1;
	  		drvprint.posY =top1;
	  		 

	  		var cs="";
	  	    if (hcbz10 == null || hcbz10=="") {
	  		     hcbz10 = "1";
	  		}
	  	    if (hcbz10=="1" || hcbz10=="2"){
				if (hcbz10=="2"){		
				   drvprint.xmlUrl=xmlUrl;	    
				}
				if (ywlx=="B"){
					cs="Text,Text26,103.7169,40.20513,����,12,False,�����ݡ�,255|";
				}else{
					cs="";
				}
				if (fzjg.indexOf("��")>-1){    
					cs=cs+"Text,Text27,21.69588,39.52044,"+tmztgd+",16,False,"+"*"+sfzmhm+"*"+",-2147483640|";
				}
	  		 
	  	
		  		cs=cs+"Text,Text25,161.1316,209.4899,����,11.25,False,������,-2147483640|";
		  		cs=cs+"Text,Text24,92.07519,209.4899,����,11.25,False,���Եص�,-2147483640|";
		  		cs=cs+"Text,Text23,37.04174,209.4899,����,11.25,False,ʱ��,-2147483640|";
		  		cs=cs+"Text,Text22,79.63975,199.4386,����,15.75,True,ԤԼ��Ŀ������,-2147483640|";
		  		cs=cs+"Text,Text21,161.0081,152.0036,����,11.25,False,������,-2147483640|";
		  		cs=cs+"Text,Text20,92.00463,152.0036,����,11.25,False,���Եص�,-2147483640|";
		  		cs=cs+"Text,Text19,37.00646,152.0036,����,11.25,False,ʱ��,-2147483640|";
		  		cs=cs+"Text,Text18,79.49863,141.9523,����,15.75,True,ԤԼ��Ŀ������,-2147483640|";
		  		cs=cs+"Text,Text17,30.4977,125.9584,����,11.25,False,��Ч�ڽ�ֹ����:,-2147483640|";
		  		cs=cs+"Text,Text16,65.49332,125.4647,����,11.25,False,"+yxqz+",-2147483640|";
		  		cs=cs+"Text,Text15,30.4977,114.9726,����,11.25,False,��Ч����ʼ����:,-2147483640|";
		  		cs=cs+"Text,Text14,65.49332,114.9726,����,11.25,False,"+yxqs+",-2147483640|";
		  		cs=cs+"Text,Text13,34.00785,101.9764,����,11.25,False,׼�ݳ��ʹ���:,-2147483640|";
		  		cs=cs+"Text,Text12,75.00071,101.9764,����,18,True,"+zjcx+",-2147483640|";
		  		cs=cs+"Text,Text11,33.07298,83.97229,����,11.25,False,���֤������:,-2147483640|";
		  		cs=cs+"Text,Text10,63.50013,84.11337,����,11.25,False,"+sfzmhm+",-2147483640|";
		  		cs=cs+"Text,Text9,63.76471,74.06208,����,11.25,False,"+csrq+",-2147483640|";
		  		cs=cs+"Text,Text8,40.99286,73.97391,����,11.25,False,��������:,-2147483640|";
		  		cs=cs+"Text,Text7,63.50013,64.0108,����,11.25,False,"+xb+",-2147483640|";
		  		cs=cs+"Text,Text6,48.68343,63.97553,����,11.25,False,�Ա�:,-2147483640|";
		  		cs=cs+"Text,Text5,63.50013,53.97715,����,11.25,False,"+xm+",-2147483640|";
		  		cs=cs+"Text,Text4,49.00093,53.97715,����,11.25,False,����:,-2147483640|";
		  		cs=cs+"Text,Text3,150.0014,39.48214,����,12,False,"+zkzmhm+",-2147483640|";
		  		cs=cs+"Text,Text2,129.9989,39.99352,����,12,False,���No:,-2147483640|";
		  		cs=cs+"Text,Text1,57.5029,27.49114,����,21.75,True,��������ʻ����׼��֤��,-2147483640|";
		  		cs=cs+"Image,Image1,149.4628,51.84346,true,26.98755,35.97301,imageData|";
		  		cs=cs+"Line,Line22,1,1,147.6378,147.6378,208.9609,251.476|";
		  		cs=cs+"Line,Line21,1,1,55.56261,55.56261,208.9609,251.476|";
		  		cs=cs+"Line,Line20,1,1,20.10837,185.6144,251.5466,251.5466|";
		  		cs=cs+"Line,Line18,1,1,20.10837,185.6144,208.9609,208.9609|";
		  		cs=cs+"Line,Line16,1,1,20.10837,185.6144,215.5735,215.5735|";
		  		cs=cs+"Line,Line15,1,1,147.4967,147.4967,151.4922,194.0074|";
		  		cs=cs+"Line,Line19,1,1,55.49206,55.49206,151.4922,194.0074|";
		  		cs=cs+"Line,Line17,1,1,20.00254,185.5086,194.0074,194.0074|";
		  		cs=cs+"Line,Line14,1,1,20.00254,185.5086,157.9991,157.9991|";
		  		cs=cs+"Line,Line13,1,1,20.00254,185.5086,151.4922,151.4922|";
		  		cs=cs+"Line,Line12,1,1,20.10837,185.1029,136.4858,136.4858|";
		  		cs=cs+"Line,Line11,1,1,20.00254,184.997,135.9568,135.9568|";
		  		cs=cs+"Line,Line10,1,1,62.97096,115.9583,131.4602,131.4602|";
		  		cs=cs+"Line,Line9,1,1,63.00624,115.9936,120.4567,120.4567|";
		  		cs=cs+"Line,Line8,1,1,63.00624,125.9948,109.9646,109.9646|";
		  		cs=cs+"Line,Line7,1,1,18.99712,183.9916,94.9758,94.9758|";
		  		cs=cs+"Line,Line6,1,1,63.00624,125.0071,89.9678,89.9678|";
		  		cs=cs+"Line,Line5,1,1,63.50013,101.0005,79.96941,79.96941|";
		  		cs=cs+"Line,Line4,1,1,63.00624,80.99794,69.47729,69.47729|";
		  		cs=cs+"Line,Line3,1,1,63.00624,99.00729,59.4789,59.4789|";
		  		cs=cs+"Line,Line2,1,1,17.9917,183.0038,47.61134,47.61134|";
		  		cs=cs+"Line,Line1,1,1,17.9917,183.0038,46.99415,46.99415";


	  		
	  		}
	  	    else if(hcbz10=="3"|| hcbz10=="4"){

				if (hcbz10=="4"){
				drvprint.xmlUrl=xmlUrl;
				    
				}
		  		if (ywlx=="B"){
		  			cs="Text,Text13,101.0004,36.51254,����,12,False,�����ݡ�,255|";
		  		}else{
		  			cs="";
		  		}
		  		if (fzjg.indexOf("��")>=0){    
		  			cs=cs+"Text,Text27,21.69588,39.52044,"+tmztgd+",12,False,"+"*"+sfzmhm+"*"+",-2147483640|"
		  		}    
		  		cs=cs+"Text,Text12,53.99269,79.99244,����,14.25,False,"+sfzmhm+",-2147483640|"
		  		cs=cs+"Text,Text11,80.873,123.5076,����,14.25,False,"+yxqz.substring(8,10)+",-2147483640|"
		  		cs=cs+"Text,Text10,67.02507,123.5076,����,14.25,False,"+yxqz.substring(5,7)+",-2147483640|"
		  		cs=cs+"Text,Text9,49.91672,123.5076,����,14.25,False,"+yxqz.substring(0,4)+",-2147483640|"
		  		cs=cs+"Text,Text8,80.99648,112.0071,����,14.25,False,"+yxqs.substring(8,10)+",-2147483640|"
		  		cs=cs+"Text,Text7,67.00743,112.0071,����,14.25,False,"+yxqs.substring(5,7)+",-2147483640|"
		  		cs=cs+"Text,Text6,50.00491,112.0071,����,14.25,False,"+yxqs.substring(0,4)+",-2147483640|"
		  		cs=cs+"Text,Text5,64.99937,99.50107,����,18,True,"+zjcx+",-2147483640|"
		  		cs=cs+"Text,Text4,53.99269,69.99118,����,14.25,False,"+csrq+",0|"
		  		cs=cs+"Text,Text3,53.99269,60.00756,����,14.25,False,"+xb+",-2147483640|"
		  		cs=cs+"Text,Text2,53.99269,50.0063,����,14.25,False,"+xm+",-2147483640|"
		  		cs=cs+"Text,Text1,138.5007,35.50712,����,14.25,False,"+zkzmhm+",-2147483640|"
		  		cs=cs+"Image,Image1,143,49.00088,true,27.00517,36.00101,imageData"
		  	}
	  	
	  	  
	  		drvprint.printData=cs
	  		drvprint.data_print();	
	  	 }
	  	 else if(code=="0"){
	         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
	         alert(msg);
	  	 }
	  	 else if(code=="-1"){
	         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
	         msg="��ȡ���ݹ����г����쳣��"+msg;
	         alert(msg);
	  	 }   
	  }
  
  
  function printYdmfxxpz(){
	    var xmlDoc = _xmlHttpRequestObj.responseXML;
	    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
	    var msg=  "";
	    if(code=="1"){  
	        var jbr=xmlDoc.getElementsByTagName("jbr")[0].firstChild.data;
	        var km3ksy=xmlDoc.getElementsByTagName("km3ksy")[0].firstChild.data;
	        var km3ksrq=xmlDoc.getElementsByTagName("km3ksrq")[0].firstChild.data;
	        var km3kscj=xmlDoc.getElementsByTagName("km3kscj")[0].firstChild.data;
	        var km1ksy=xmlDoc.getElementsByTagName("km1ksy")[0].firstChild.data;
	        var km1ksrq=xmlDoc.getElementsByTagName("km1ksrq")[0].firstChild.data;
	        var km1kscj=xmlDoc.getElementsByTagName("km1kscj")[0].firstChild.data;        
	        var mfcs=xmlDoc.getElementsByTagName("mfcs")[0].firstChild.data;
	        var zjcx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
	        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data; 
	        var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
	        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	        var todaystr=xmlDoc.getElementsByTagName("sysd")[0].firstChild.data;
	
	        
	        var cs = "";
	        ls_year = todaystr.substring(0,4);
	        ls_month = todaystr.substring(5,7);
	        ls_day   = todaystr.substring(8,10);
	      
	                 cs = "Text,Text43,116.4168,195.7919,����_GB2312,15.75,False,"+ls_year+",-2147483640|";
	                 cs+= "Text,Text35,129.1168,195.7919,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text34,140.2293,195.7919,����_GB2312,15.75,False,"+ls_month+",-2147483640|";
	                 cs+= "Text,Text33,147.6376,195.7919,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text11,158.7502,195.7919,����_GB2312,15.75,False,"+ls_day+",-2147483640|";
	                 cs+= "Text,Text7,166.1585,195.7919,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text59,88.37092,44.45004,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text42,165.6293,157.6918,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text41,158.221,157.6918,����_GB2312,15.75,False,"+ls_day+",-2147483640|";
	                 cs+= "Text,Text40,151.871,157.6918,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text39,144.4626,157.6918,����_GB2312,15.75,False,"+ls_month+",-2147483640|";
	                 cs+= "Text,Text38,138.1126,157.6918,����_GB2312,15.75,False,��,-2147483640|";
	                 cs+= "Text,Text37,125.4126,157.6918,����_GB2312,15.75,False,"+ls_year+",-2147483640|";
	                 cs+= "Text,Text36,104.7751,157.6918,����_GB2312,15.75,False,���ڣ�,-2147483640|";
	                 cs+= "Text,Text32,130.1751,147.6376,����_GB2312,15.75,False,"+jbr+",-2147483640|";
	                 cs+= "Text,Text31,89.42925,147.6376,����_GB2312,15.75,False,������ǩ�֣�,-2147483640|";
	                 cs+= "Text,Text30,26.45836,122.7668,����_GB2312,15.75,False,�ش�֪ͨ����������Ƿַ�ֵ��,-2147483640|";
	                 cs+= "Text,Text29,102.6584,113.7709,����_GB2312,15.75,False,"+km3ksy+",-2147483640|";
	                 cs+= "Text,Text28,144.4626,113.7709,����_GB2312,15.75,False,"+km3ksrq+",-2147483640|";
	                 cs+= "Text,Text27,60.85423,113.7709,����_GB2312,15.75,False,"+km3kscj+",-2147483640|";
	                 cs+= "Text,Text26,17.99168,113.7709,����_GB2312,15.75,False,��Ŀ��,-2147483640|";
	                 cs+= "Text,Text25,102.6584,105.3043,����_GB2312,15.75,False,"+km1ksy+",-2147483640|";
	                 cs+= "Text,Text24,144.4626,105.3043,����_GB2312,15.75,False,"+km1ksrq+",-2147483640|";
	                 cs+= "Text,Text23,60.85423,105.3043,����_GB2312,15.75,False,"+km1kscj+",-2147483640|";
	                 cs+= "Text,Text22,17.99168,105.3043,����_GB2312,15.75,False,��Ŀһ,-2147483640|";
	                 cs+= "Text,Text21,102.6584,96.83759,����_GB2312,15.75,False,����Ա,-2147483640|";
	                 cs+= "Text,Text20,144.4626,96.83759,����_GB2312,15.75,False,��������,-2147483640|";
	                 cs+= "Text,Text19,60.85423,96.83759,����_GB2312,15.75,False,���Գɼ�,-2147483640|";
	                 cs+= "Text,Text18,17.99168,96.83759,����_GB2312,15.75,False,���Կ�Ŀ,-2147483640|";
	                 cs+= "Text,Text17,12.70001,85.19592,����_GB2312,15.75,False,�ԡ����ѿ��Ժϸ񣬸���Ŀ������Ϣ���£�,-2147483640|";
	                 cs+= "Text,Text16,104.7751,75.14174,����_GB2312,15.75,False,�����֣�����Ը���������п�,-2147483640|";
	                 cs+= "Text,Text15,81.49174,75.14174,����_GB2312,15.75,False,"+mfcs+",-2147483640|";
	                 cs+= "Text,Text14,13.22918,75.14174,����_GB2312,15.75,False,������Υ���Ƿִﵽ,-2147483640|";
	                 cs+= "Text,Text13,152.4001,64.5584,����_GB2312,15.75,False,���ڱ��Ƿ�,-2147483640|";
	                 cs+= "Text,Text12,163.5127,54.50422,����_GB2312,15.75,False,������,-2147483640|";
	                 cs+= "Text,Text10,136.5251,64.5584,����_GB2312,15.75,False,"+zjcx+",-2147483640|";
	                 cs+= "Text,Text9,83.60841,64.5584,����_GB2312,15.75,False,��׼�ݳ��ʹ���Ϊ,-2147483640|";
	                 cs+= "Text,Text8,55.56255,44.45004,����_GB2312,15.75,False,"+xm+",-2147483640|";
	                 cs+= "Text,Text6,38.6292,64.5584,����_GB2312,15.75,False,"+dabh+",-2147483640|";
	                 cs+= "Text,Text5,13.22918,64.5584,����_GB2312,15.75,False,���Ϊ,-2147483640|";
	                 cs+= "Text,Text4,101.0709,54.50422,����_GB2312,15.75,False,"+sfzmhm+",-2147483640|";
	                 cs+= "Text,Text3,26.45836,54.50422,����_GB2312,15.75,False,�����ֻ�������ʻ֤����Ϊ,-2147483640|";
	                 cs+= "Text,Text2,13.22918,44.45004,����_GB2312,15.75,False,��������ʻ��,-2147483640|";
	                 cs+= "Text,Text1,17.99168,26.45836,����,21.75,False,��������ʻ��Υ�����ֿ�����Ϣ����֪ͨ��,-2147483640|";
	                 cs+= "Line,Line21,1,1,157.1627,165.6293,165.1002,165.1002|Line,Line20,1,1,143.4043,151.871,165.1002,165.1002|";
	                 cs+= "Line,Line19,1,1,124.3543,138.6418,165.1002,165.1002|Line,Line16,1,1,125.4126,174.096,155.046,155.046|";
	                 cs+= "Line,Line15,1,1,179.3877,179.6523,95.25009,120.9147|Line,Line14,1,1,138.6418,138.9064,95.25009,120.9147|";
	                 cs+= "Line,Line13,1,1,96.83759,97.10218,95.25009,120.9147|Line,Line12,1,1,54.50422,54.7688,95.25009,120.9147|";
	                 cs+= "Line,Line11,1,1,15.34585,15.61043,95.25009,120.9147|Line,Line10,1,1,15.34585,179.9168,121.1793,121.1793|";
	                 cs+= "Line,Line9,1,1,15.34585,179.9168,112.7126,112.7126|Line,Line8,1,1,15.34585,179.9168,104.2459,104.2459|";
	                 cs+= "Line,Line7,1,1,15.34585,179.9168,95.77926,95.77926|Line,Line6,1,1,67.7334,105.3043,82.55008,82.55008|";
	                 cs+= "Line,Line5,1,1,130.7043,152.4001,71.96674,71.96674|Line,Line3,1,1,33.8667,82.55008,71.96674,71.96674|";
	                 cs+= "Line,Line2,1,1,99.48343,160.3377,61.91256,61.91256|Line,Line1,1,1,49.21255,88.37092,51.85838,51.85838";

	     	    drvprint.printData=cs
	            drvprint.data_print();
	  	 }
	  	 else if(code=="0"){
	         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
	         alert(msg);
	  	 }
	  	 else if(code=="-1"){
	         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
	         msg="��ȡ���ݹ����г����쳣��"+msg;
	         alert(msg);
	  	 }   
	  }

  function printZccddd(){
	    var xmlDoc = _xmlHttpRequestObj.responseXML;
	    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
	    var msg=  "";
	    if(code=="1"){  
	        var sysd=xmlDoc.getElementsByTagName("sysd")[0].firstChild.data;
	        var zxrq=xmlDoc.getElementsByTagName("zxrq")[0].firstChild.data;
	        var zrd=xmlDoc.getElementsByTagName("zrd")[0].firstChild.data;
	        var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
	        var jbr=xmlDoc.getElementsByTagName("jbr")[0].firstChild.data;
	        var zjcx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
	        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;    
	        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	        
	        var cs = "";

	        drvprint.posX="20"
	        drvprint.posY="30"
	      
	            blyear = sysd.substring(0,4);
	            blmonth = sysd.substring(5,7);
	            blday = sysd.substring(8,10);
	            zcrq = zxrq;
	            zcyear = zcrq.substring(0,4);
	            zcmonth = zcrq.substring(5,7);
	            zcday = zcrq.substring(8,10);


	            cs = "Text,Text14,107.9501,156.6335,����_GB2312,14.25,False,�����ˣ�,-2147483640|";
	            cs+= "Text,Text13,40.21671,29.63336,����,21.75,True,��������ʻ֤ת����Ϣ��¼��,-2147483640|";
	            cs+= "Text,Text12,156.6335,165.1002,����_GB2312,14.25,False,��,-2147483640|";
	            cs+= "Text,Text11,173.5668,165.1002,����_GB2312,14.25,False,��,-2147483640|";
	            cs+= "Text,Text10,139.7001,165.1002,����_GB2312,14.25,False,��,-2147483640|";
	            cs+= "Text,Text9,78.31674,65.61673,����_GB2312,14.25,False,�����������������Ϊ,-2147483640|";
	            cs+= "Text,Text8,19.05002,76.20007,����_GB2312,14.25,False,��������ʻ֤��ת��ҵ��";
	            cs+= "�û�������ʻ֤ת�����ص���Ϣ���£�,-2147483640|";
	            cs+= "Text,Text7,19.05002,86.78342,����_GB2312,14.25,False,֤�����룺,-2147483640|";
	            cs+= "Text,Text6,27.51669,99.48343,����_GB2312,14.25,False,������,-2147483640|";
	            cs+= "Text,Text5,101.6001,99.48343,����_GB2312,14.25,False,׼�ݳ��ʹ��ţ�,-2147483640|";
	            cs+= "Text,Text4,50.80005,65.61673,����_GB2312,14.25,False,��,-2147483640|";
	            cs+= "Text,Text3,67.7334,65.61673,����_GB2312,14.25,False,�գ�,-2147483640|";
	            cs+= "Text,Text2,35.98337,65.61673,����_GB2312,14.25,False,��,-2147483640|";
	            cs+= "Text,Text1,167.2168,55.03339,����_GB2312,14.25,False,��,-2147483640|";
	            cs+= "Text,cgs,29.63336,55.03339,����_GB2312,14.25,False,"+zrd+",-2147483640|";
	            cs+= "Text,blmonth,146.0501,165.1002,����_GB2312,14.25,False,"+blmonth+",-2147483640|";
	            cs+= "Text,blday,162.9835,165.1002,����_GB2312,14.25,False,"+blday+",-2147483640|";
	            cs+= "Text,blyear,124.8835,165.1002,����_GB2312,14.25,False,"+blyear+",-2147483640|";
	            cs+= "Text,zcmonth,42.33337,65.61673,����_GB2312,14.25,False,"+zcmonth+",-2147483640|";
	            cs+= "Text,zcday,57.15005,65.61673,����_GB2312,14.25,False,"+zcday+",-2147483640|";
	            cs+= "Text,dabh,133.3501,65.61673,����_GB2312,14.25,False,"+dabh+",-2147483640|";
	            cs+= "Text,zcyear,19.05002,65.61673,����_GB2312,14.25,False,"+zcyear+",-2147483640|";
	            cs+= "Text,jbr,127.0001,154.5168,����_GB2312,14.25,False,"+jbr+",-2147483640|";
	            cs+= "Text,zjcx,137.5835,97.36676,����_GB2312,14.25,False,"+zjcx+",-2147483640|";
	            cs+= "Text,xm,42.33337,97.36676,����_GB2312,14.25,False,"+xm+",-2147483640|";
	            cs+= "Text,sfzmhm,67.7334,86.78342,����_GB2312,14.25,False,"+sfzmhm+",-2147483640|";
	            cs+= "Line,Line8,1,1,124.8835,139.7001,173.5668,173.5668|";
	            cs+= "Line,Line7,1,1,162.9835,173.5668,173.5668,173.5668|";
	            cs+= "Line,Line3,1,1,146.0501,158.7502,173.5668,173.5668|";
	            cs+= "Line,Line16,1,1,133.3501,171.4502,71.96674,71.96674|";
	            cs+= "Line,Line20,1,1,19.05002,31.75003,71.96674,71.96674|";
	            cs+= "Line,Line19,1,1,57.15005,63.50006,71.96674,71.96674|";
	            cs+= "Line,Line18,1,1,42.33337,48.68338,71.96674,71.96674|";
	            cs+= "Line,Line1,1,1,27.51669,165.1002,61.38339,61.38339|";
	            cs+= "Line,Line6,1,1,127.0001,171.4502,160.8668,160.8668|";
	            cs+= "Line,Line5,1,1,137.5835,167.2168,103.7168,103.7168|";
	            cs+= "Line,Line4,1,1,42.33337,97.36676,103.7168,103.7168|";
	            cs+= "Line,Line2,1,1,52.91672,167.2168,93.13342,93.13342";
	  
	  		drvprint.printData=cs
	  		drvprint.data_print();	
	  	 }
	  	 else if(code=="0"){
	         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
	         alert(msg);
	  	 }
	  	 else if(code=="-1"){
	         msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
	         msg="��ȡ���ݹ����г����쳣��"+msg;
	         alert(msg);
	  	 }   
	  }

//ע��ƾ֤
function print_zxpz(nLsh)
{
    var spath="print.do?method=queryPrintZxpz&lsh="+nLsh;
    send_request(spath,"printZxpz()",false); 	
}  
function printZxpz()
{
	 var xmlDoc = _xmlHttpRequestObj.responseXML;
	 var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
	 var msg="";
	 if(code=="1")
	 {
	    var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
	    var zxrq=xmlDoc.getElementsByTagName("zxrq")[0].firstChild.data;
	    var zjcx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
	    var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
	    var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	    var zxyy_mc=xmlDoc.getElementsByTagName("zxyy_mc")[0].firstChild.data;
	    var zxyy_tg=xmlDoc.getElementsByTagName("zxyy_tg")[0].firstChild.data;
	    var zxsj=xmlDoc.getElementsByTagName("zxsj")[0].firstChild.data;
	    if(dabh=="--"){dabh="";}
	   
	    try
	    {
			drvprint.posX="20"
			drvprint.posY="15"
			var cs = "";  
			cs=cs+"Text,Text2,101.0709,92.07509,����,14.25,False,"+zxyy_tg+",-2147483640|";
			cs=cs+"Text,Text1,42.33337,66.67506,����,14.25,False,"+zxsj+",-2147483640|";
			cs=cs+"Text,zxpzJsr,42.86254,17.99168,����,14.25,False,"+xm+",-2147483640|";
			cs=cs+"Text,zxpzSfzmhm,42.86254,30.16253,����,14.25,False,"+sfzmhm+",-2147483640|";
			cs=cs+"Text,zxpzDabh,42.86254,42.33337,����,14.25,False,"+dabh+",-2147483640|";
			cs=cs+"Text,zxpzZjcx,42.86254,54.50422,����,14.25,False,"+zjcx+",-2147483640|";
			cs=cs+"Text,zxpzZxyy,21.69585,80.43341,����,14.25,False,"+zxyy_mc+",-2147483640|";
			cs=cs+"Text,zxpzZxrq,119.5918,176.2127,����,14.25,False,"+zxrq+",-2147483640|";
			cs=cs+"Line,Line7,1,1,100.0126,108.4793,97.89593,97.89593|";
			cs=cs+"Text,Label1,110.5959,92.60426,����,14.25,False,��涨������������ע,-2147483630|";
			cs=cs+"Line,Line6,1,1,41.80421,100.5418,72.4959,72.4959|";
			cs=cs+"Text,Label2,3.70417,67.20423,����,14.25,False,ע����ʻ֤ʱ�䣺,-2147483630|";
			cs=cs+"Text,Label3,58.20839,0,����,15.75,True,��������ʻ֤ע��֤��,-2147483630|";
			cs=cs+"Text,Label4,30.16253,19.05002,����,14.25,False,������,-2147483630|";
			cs=cs+"Text,Label5,20.63752,31.22087,����,14.25,False,��ʻ֤�ţ�,-2147483630|";
			cs=cs+"Text,Label6,5.291672,43.39171,����,14.25,False,��ʻ֤������ţ�,-2147483630|";
			cs=cs+"Text,Label7,8.995842,55.03339,����,14.25,False,׼�ݳ��ʹ��ţ�,-2147483630|";
			cs=cs+"Text,Label8,97.36676,159.2793,����,14.25,False,������������ҵ��ר���£�,-2147483630|";
			cs=cs+"Text,Label9,120.6501,81.49174,����,14.25,False,�����ϡ���������,-2147483630|";
			cs=cs+"Text,Label10,22.75419,128.0585,����,14.25,False,�ش�֤����,-2147483630|";
			cs=cs+"Line,Line1,1,1,42.86254,100.0126,23.28336,23.28336|";
			cs=cs+"Line,Line2,1,1,43.39171,100.5418,35.98337,35.98337|";
			cs=cs+"Line,Line3,1,1,42.86254,100.0126,48.15421,48.15421|";
			cs=cs+"Line,Line4,1,1,42.86254,100.0126,60.32506,60.32506|";
			cs=cs+"Text,Label11,3.70417,92.60426,����,14.25,False,ʻ֤�����ʹ�ù涨������ʮ������һ���,-2147483630|";
			cs=cs+"Line,Line5,1,1,19.57919,120.6501,85.72508,85.72508|";
			cs=cs+"Text,Label12,3.175003,103.7168,����,14.25,False,����������ʻ֤��,-2147483630|";
			cs=cs+"Text,Label13,14.81668,81.49174,����,14.25,False,��,-2147483630";
			drvprint.printData=cs;
			drvprint.data_print(); 			
	    }
  		catch(err)
  		{
  			alert(err.description);
  		}
  	}
	else if(code=="0")
	{
		msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
		alert(msg);
	}
	else if(code=="-1")
	{
		msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
		msg="��ȡ���ݹ����г����쳣��"+msg;
		alert(msg);
	}
}
function printSl_tbpz(gnid,ywlxStr,ywyyStr,xmStr,msg)
{
    var spath="print.do?method=queryPrintTbpz&gnid="+gnid+"&ywlx="+ywlxStr+"&ywyy="+ywyyStr+"&xm="+xmStr+"&msg="+msg;
    spath=encodeURI(encodeURI(spath))
    send_request(spath,"sl_tbpz()",false); 	
}
//�����˰�ƾ֤
function sl_tbpz()
{
	 var xmlDoc = _xmlHttpRequestObj.responseXML;
	 var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
	 var msg="";
	 if(code=="1")
	 {
		var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
		var ywlx_mc=xmlDoc.getElementsByTagName("ywlx_mc")[0].firstChild.data;
		var msgStr1=xmlDoc.getElementsByTagName("msgStr1")[0].firstChild.data;
		var msgStr2=xmlDoc.getElementsByTagName("msgStr2")[0].firstChild.data;
		var msgStr3=xmlDoc.getElementsByTagName("msgStr3")[0].firstChild.data;
		var year=xmlDoc.getElementsByTagName("year")[0].firstChild.data;	
		var month=xmlDoc.getElementsByTagName("month")[0].firstChild.data;
		var day=xmlDoc.getElementsByTagName("day")[0].firstChild.data;
		var hour=xmlDoc.getElementsByTagName("hour")[0].firstChild.data;
		var min=xmlDoc.getElementsByTagName("min")[0].firstChild.data;
		if(ywlx_mc=="--"){ywlx_mc="";}
		if(msgStr2=="--"){msgStr2="";}
		if(msgStr3=="--"){msgStr3="";}
		var ywlx_mc1="";
		var fydw="";//���鵥λ
		try
		{
			drvprint.posX="20"
			drvprint.posY="15"
			var cs = "";    
			cs+="Text,Text22,5.291672,107.9501,����_GB2312,15.75,False,"+msgStr3+",-2147483640|"
			cs+="Text,Text21,5.291672,98.95426,����_GB2312,15.75,False,"+msgStr2+",-2147483640|"
			cs+="Text,Text20,16.40418,89.42925,����_GB2312,15.75,False,"+msgStr1+",-2147483640|"
			cs+="Text,Text19,113.7709,17.99168,����_GB2312,12,False,��ţ�[20  ]      ��,-2147483640|"
			cs+="Text,Text18,6.350006,257.1753,����_GB2312,15.75,False,����֪ͨ��һʽ���ݣ������ˡ�����λ��ִһ�ݣ�,-2147483640|"
			cs+="Text,Text17,4.762505,235.4794,����_GB2312,15.75,False,�����ˣ�������ˣ�����ǩ�֣�         "+year+"��"+month+"��"+day+"��"+hour+"ʱ"+min+"��,-2147483640|"
			cs+="Text,Text16,103.7168,204.2585,����_GB2312,15.75,False,"+year+"��"+month+"��"+day+"��,-2147483640|"
			cs+="Text,Text15,103.7168,189.4418,����_GB2312,15.75,False,���������ع��£�,-2147483640|"
			cs+="Text,Text14,6.350006,151.3418,����_GB2312,15.75,False,����������Ժ�����������ϡ�,-2147483640|"
			cs+="Text,Text13,75.67091,139.7001,����_GB2312,15.75,False,�����������飬��������������,-2147483640|"
			cs+="Text,Text12,6.350006,139.7001,����_GB2312,15.75,False,"+fydw+",-2147483640|"
			cs+="Text,Text11,17.99168,127.5293,����_GB2312,15.75,False,�粻�����������������յ���������֮������ʮ������,-2147483640|"
			cs+="Text,Text10,16.93335,79.90424,����_GB2312,15.75,False,�������£�,-2147483640|"
			cs+="Text,Text9,4.762505,68.26257,����_GB2312,15.75,False,�������������������ؾ�����������,-2147483640|"
			cs+="Text,Text8,81.49174,56.62089,����_GB2312,15.75,False,�����룬�����Ϸ��ɡ������,-2147483640|"
			cs+="Text,Text7,4.762505,56.62089,����_GB2312,15.75,False,"+ywlx_mc1+",-2147483640|"
			cs+="Text,Text6,38.10004,45.50838,����_GB2312,15.75,False,"+ywlx_mc+",-2147483640|"
			cs+="Text,Text5,20.10835,45.50838,����_GB2312,15.75,False,�����,-2147483640|"
			cs+="Text,Text4,66.67506,32.80836,����_GB2312,15.75,False,��,-2147483640|"
			cs+="Text,Text3,4.233337,32.80836,����_GB2312,15.75,False,"+xm+",-2147483640|"
			cs+="Text,Text2,51.32922,8.995842,����,18,False,�����������������,-2147483640|"
			cs+="Text,Text1,25.92919,-.5291672,����,18,False,���˴�ӡ�ƹ������ؽ�ͨ���������ƣ�,-2147483640|"
			cs+="Line,Line5,1,1,4.233337,67.20423,39.68754,39.68754|"
			cs+="Line,Line4,1,1,6.350006,76.20007,146.0501,146.0501|"
			cs+="Line,Line3,1,1,4.762505,82.02091,63.50006,63.50006|"
			cs+="Line,Line2,1,1,38.10004,159.8085,51.85838,51.85838|"
			cs+="Line,Line1,1,1,3.70417,166.6877,255.5878,255.5878"
			drvprint.printData=cs;
			drvprint.data_print(); 
		}
	  	catch(err)
	  	{
	  		alert(err.description);
	  	}
	}
	else if(code=="0")
	{
		msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
		alert(msg);
	}
	else if(code=="-1")
	{
		msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
		msg="��ȡ���ݹ����г����쳣��"+msg;
		alert(msg);
	}		
}
function printHf_tbpz(gnid,ywlxStr,ywyyStr,xmStr,msg)
{
    var spath="print.do?method=queryPrintTbpz&gnid="+gnid+"&ywlx="+ywlxStr+"&ywyy="+ywyyStr+"&xm="+xmStr+"&msg="+msg;
    spath=encodeURI(encodeURI(spath))
    send_request(spath,"hf_tbpz()",false); 	
}
//�˷��˰�ƾ֤
function hf_tbpz()
{
	 var xmlDoc = _xmlHttpRequestObj.responseXML;
	 var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
	 var msg="";
	 if(code=="1")
	 {
		var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
		var ywlx_mc=xmlDoc.getElementsByTagName("ywlx_mc")[0].firstChild.data;
		var msgStr1=xmlDoc.getElementsByTagName("msgStr1")[0].firstChild.data;
		var msgStr2=xmlDoc.getElementsByTagName("msgStr2")[0].firstChild.data;
		var msgStr3=xmlDoc.getElementsByTagName("msgStr3")[0].firstChild.data;
		var year=xmlDoc.getElementsByTagName("year")[0].firstChild.data;	
		var month=xmlDoc.getElementsByTagName("month")[0].firstChild.data;
		var day=xmlDoc.getElementsByTagName("day")[0].firstChild.data;
		var hour=xmlDoc.getElementsByTagName("hour")[0].firstChild.data;
		var min=xmlDoc.getElementsByTagName("min")[0].firstChild.data;
		if(ywlx_mc=="--"){ywlx_mc="";}
		if(msgStr2=="--"){msgStr2="";}
		if(msgStr3=="--"){msgStr3="";}
		var ywlx_mc1="";
		var fydw="";//���鵥λ
		try
		{	
			drvprint.posX="10"
			drvprint.posY="10"
			var cs = "";  
			cs+="Text,Text8,22.22502,77.78757,����_GB2312,15.75,False,"+msgStr1+",-2147483640|"
			cs+="Text,Text21,11.11251,87.31258,����_GB2312,15.75,False,"+msgStr2+",-2147483640|"
			cs+="Text,Text22,11.11251,96.30843,����_GB2312,15.75,False,"+msgStr3+",-2147483640|"
			cs+="Text,Text20,159.2793,45.50838,����_GB2312,15.75,False,��,-2147483640|"
			cs+="Text,Text19,120.6501,17.99168,����_GB2312,12,False,��ţ�[20  ]      ��,-2147483640|"
			cs+="Text,Text18,13.22918,269.3461,����_GB2312,15.75,False,����֪ͨ��һʽ���ݣ������ˡ�����λ��ִһ�ݣ�,-2147483640|"
			cs+="Text,Text17,11.64168,247.6503,����_GB2312,15.75,False,�����ˣ�������ˣ�����ǩ�֣�         "+year+"��"+month+"��"+day+"��"+hour+"ʱ"+min+"��,-2147483640|"
			cs+="Text,Text16,110.5959,207.9627,����_GB2312,15.75,False,"+year+"��"+month+"��"+day+"��,-2147483640|"
			cs+="Text,Text15,110.5959,192.0877,����_GB2312,15.75,False,���������ع��£�,-2147483640|"
			cs+="Text,Text14,11.64168,138.6418,����_GB2312,15.75,False,����������Ժ�����������ϡ�,-2147483640|"
			cs+="Text,Text13,81.49174,127.5293,����_GB2312,15.75,False,�����������飬��������������,-2147483640|"
			cs+="Text,Text12,11.64168,127.5293,����_GB2312,15.75,False,"+fydw+",-2147483640|"
			cs+="Text,Text11,24.87086,116.4168,����_GB2312,15.75,False,�粻�����������������յ���������֮������ʮ������,-2147483640|"
			cs+="Text,Text9,11.64168,67.20423,����_GB2312,15.75,False,��ʻ֤���������£�,-2147483640|"
			cs+="Text,Text7,11.64168,56.09172,����_GB2312,15.75,False,��������ʻ֤ҵ�񣬱����ؾ�������˷�/����/���������,-2147483640|"
			cs+="Text,Text6,71.43757,45.50838,����_GB2312,15.75,False,"+ywlx_mc+",-2147483640|"
			cs+="Text,Text5,24.34169,45.50838,����_GB2312,15.75,False,����飬�������,-2147483640|"
			cs+="Text,Text4,73.55424,32.80836,����_GB2312,15.75,False,��,-2147483640|"
			cs+="Text,Text3,11.11251,32.80836,����_GB2312,15.75,False,"+xm+",-2147483640|"
			cs+="Text,Text2,29.10419,8.995842,����,18,False,����˷�/���/������������ʻ֤������,-2147483640|"
			cs+="Text,Text1,26.45836,0,����,18,False,���˴�ӡ�ƹ������ؽ�ͨ���������ƣ�,-2147483640|"
		    cs=cs+"Line,Line3,1,1,11.11251,74.61257,39.68754,39.68754|";
			cs=cs+"Line,Line4,1,1,13.22918,83.07925,133.8793,133.8793|";
			cs=cs+"Line,Line2,1,1,70.9084,158.7502,51.85838,51.85838|";
			cs=cs+"Line,Line1,1,1,10.58334,173.5668,267.2294,267.2294";	
			drvprint.printData=cs;
			drvprint.data_print(); 
		}
	  	catch(err)
	  	{
	  		alert(err.description);
	  	}
	}
	else if(code=="0")
	{
		msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
		alert(msg);
	}
	else if(code=="-1")
	{
		msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
		msg="��ȡ���ݹ����г����쳣��"+msg;
		alert(msg);
	}			
}


//��������ִ
function print_yqndtjhz(lsh)
{
	 var spath="print.do?method=queryPrintYqpz&lsh="+lsh;
	 send_request(spath,"printYqndtj()",false); 	
}
function printYqndtj()
{
    var xmlDoc = _xmlHttpRequestObj.responseXML;
    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
    var msg=  "";
    if(code=="1")
    {  
	    var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	    var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
	    var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
	    var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	    var year1=xmlDoc.getElementsByTagName("year1")[0].firstChild.data;
	    var month1=xmlDoc.getElementsByTagName("month1")[0].firstChild.data;
	    var day1=xmlDoc.getElementsByTagName("day1")[0].firstChild.data;
	    var year2=xmlDoc.getElementsByTagName("year2")[0].firstChild.data;
	    var month2=xmlDoc.getElementsByTagName("month2")[0].firstChild.data;
	    var day2=xmlDoc.getElementsByTagName("day2")[0].firstChild.data;
	    var strywyy="";
		drvprint.posX="25"
		drvprint.posY="20"
		var cs = "";   
		    cs+="Text,Text36,101.6001,31.22087,����,15.75,False,��,-2147483640|"
			cs+="Text,Text35,66.67506,62.9709,����,15.75,False,�����Ҵ���������������ʻ֤��,-2147483640|"
			cs+="Text,Text34,105.3043,140.7585,����,15.75,False,������λ���£�,-2147483640|"
			cs+="Text,Text33,104.7751,128.5876,����,15.75,False,"+year1+"��"+month1+"��"+day1+"��,-2147483640|"
			cs+="Text,Text32,87.31258,93.13342,����,15.75,False,���ύ����������֤������,-2147483640|"
			cs+="Text,Text31,76.72924,93.13342,����,15.75,False,"+day2+",-2147483640|"
			cs+="Text,Text30,69.85007,93.13342,����,15.75,False,��,-2147483640|"
			cs+="Text,Text29,59.79589,93.13342,����,15.75,False,"+month2+",-2147483640|"
			cs+="Text,Text28,50.80005,93.13342,����,15.75,False,��,-2147483640|"
			cs+="Text,Text27,34.39587,93.13342,����,15.75,False,"+year2+",-2147483640|"
			cs+="Text,Text26,0,93.13342,����,15.75,False,ֹʹ�ã�Ӧ��,-2147483640|"
			cs+="Text,Text25,135.4668,83.07925,����,15.75,False,����ͣ,-2147483640|"
			cs+="Text,Text24,128.0585,83.07925,����,15.75,False,"+day1+",-2147483640|"
			cs+="Text,Text23,121.1793,83.07925,����,15.75,False,��,-2147483640|"
			cs+="Text,Text22,112.7126,83.07925,����,15.75,False,"+month1+",-2147483640|"
			cs+="Text,Text21,106.3626,83.07925,����,15.75,False,��,-2147483640|"
			cs+="Text,Text20,90.48759,83.07925,����,15.75,False,"+year1+",-2147483640|"
			cs+="Text,Text19,78.31674,83.07925,����,15.75,False,����,-2147483640|"
			cs+="Text,Text18,23.995842,83.07925,����,15.75,False,"+dabh+",-2147483640|"
			cs+="Text,Text17,0,83.07925,����,15.75,False,��ţ�,-2147483640|"
			cs+="Text,Text16,0,73.02507,����,15.75,False,���ύ����������֤����ҵ�������ֻ�������ʻ֤�� ���� ,-2147483640|"
			cs+="Text,Text15,55.03339,62.9709,����,15.75,False,"+day1+",-2147483640|"
			cs+="Text,Text14,44.45004,62.9709,����,15.75,False,��,-2147483640|"
			cs+="Text,Text13,34.39587,62.9709,����,15.75,False,"+month1+",-2147483640|"
			cs+="Text,Text12,23.81252,62.9709,����,15.75,False,��,-2147483640|"
			cs+="Text,Text11,7.937508,62.9709,����,15.75,False,"+year1+",-2147483640|"
			cs+="Text,Text10,0,62.9709,����,15.75,False,��,-2147483640|"
			cs+="Text,Text8,39.15837,52.91672,����,15.75,False,"+strywyy+",-2147483640|"
			cs+="Text,Text9,8.466675,52.91672,����,15.75,False,������ԭ��,-2147483640|"
			cs+="Text,Text7,0,41.27504,����,15.75,False,�� ��������    �� ����������,-2147483640|"
			cs+="Text,Text6,13.75835,31.22087,����,15.75,False,"+sfzmhm+",-2147483640|"
			cs+="Text,Text5,0,31.22087,����,15.75,False,Ϊ��,-2147483640|"
			cs+="Text,Text4,91.54592,21.16669,����,15.75,False,�� �� �� ֤ �� �� ��,-2147483640|"
			cs+="Text,Text3,23.81252,21.16669,����,15.75,False,"+xm+",-2147483640|"
			cs+="Text,Text2,0,21.16669,����,15.75,False,�� ʻ ��,-2147483640|"
			cs+="Text,Text1,25.92919,.5291672,����,18,False,�����ύ����������֤������ִ,-2147483640|"
			cs+="Line,Line13,1,1,77.25841,86.25425,100.0126,100.0126|"
			cs+="Line,Line12,1,1,60.85423,69.85007,100.0126,100.0126|"
			cs+="Line,Line11,1,1,34.39587,51.32922,100.0126,100.0126|"
			cs+="Line,Line10,1,1,129.1168,134.9376,89.95842,89.95842|"
			cs+="Line,Line9,1,1,113.2418,121.1793,89.95842,89.95842|"
			cs+="Line,Line8,1,1,91.01675,106.3626,89.95842,89.95842|"
			cs+="Line,Line7,1,1,9.525009,78.84591,89.95842,89.95842|"
			cs+="Line,Line6,1,1,55.56255,66.67506,69.85007,69.85007|"
			cs+="Line,Line5,1,1,34.92503,44.45004,69.85007,69.85007|"
			cs+="Line,Line4,1,1,7.40834,23.28336,69.85007,69.85007|"
			cs+="Line,Line3,1,1,39.15837,153.4585,59.79589,59.79589|"
			cs+="Line,Line2,1,1,13.75835,109.0084,38.10004,38.10004|"
			cs+="Line,Line1,1,1,24.34169,92.07509,28.04586,28.04586"
		drvprint.printData=cs;
		drvprint.data_print(); 
    }
 	 else if(code=="0"){
        msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
        alert(msg);
 	 }
 	 else if(code=="-1"){
        msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
        msg="��ȡ���ݹ����г����쳣��"+msg;
        alert(msg);
 	 }   
}


//����������֤��ִ
function print_qmyqhz(lsh)
{
	 var spath="print.do?method=queryPrintYqpz&lsh="+lsh;
	 send_request(spath,"printYqqmhz()",false); 	
}
function printYqqmhz()
{
    var xmlDoc = _xmlHttpRequestObj.responseXML;
    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
    var msg=  "";
    if(code=="1"){   
	    var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	    var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data;
	    var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
	    var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
	    var year1=xmlDoc.getElementsByTagName("year1")[0].firstChild.data;
	    var month1=xmlDoc.getElementsByTagName("month1")[0].firstChild.data;
	    var day1=xmlDoc.getElementsByTagName("day1")[0].firstChild.data;
	    var year2=xmlDoc.getElementsByTagName("year2")[0].firstChild.data;
	    var month2=xmlDoc.getElementsByTagName("month2")[0].firstChild.data;
	    var day2=xmlDoc.getElementsByTagName("day2")[0].firstChild.data;
	    var strywyy="";
	    
		drvprint.posX="25";
		drvprint.posY="20";
		var cs = "";    
		cs+="Text,Text36,101.6001,31.22087,����,15.75,False,��,-2147483640|"
		cs+="Text,Text35,66.67506,62.9709,����,15.75,False,�����Ҵ���������������ʻ֤��,-2147483640|"
		cs+="Text,Text34,105.3043,140.7585,����,15.75,False,������λ���£�,-2147483640|"
		cs+="Text,Text33,104.7751,128.5876,����,15.75,False,"+year1+"��"+month1+"��"+day1+"��,-2147483640|"
		cs+="Text,Text32,87.31258,93.13342,����,15.75,False,�հ���������֤ҵ��,-2147483640|"
		cs+="Text,Text31,76.72924,93.13342,����,15.75,False,"+day2+",-2147483640|"
		cs+="Text,Text30,69.85007,93.13342,����,15.75,False,��,-2147483640|"
		cs+="Text,Text29,59.79589,93.13342,����,15.75,False,"+month2+",-2147483640|"
		cs+="Text,Text28,50.80005,93.13342,����,15.75,False,��,-2147483640|"
		cs+="Text,Text27,34.39587,93.13342,����,15.75,False,"+year2+",-2147483640|"
		cs+="Text,Text26,0,93.13342,����,15.75,False,ֹʹ�ã�Ӧ��,-2147483640|"
		cs+="Text,Text25,135.4668,83.07925,����,15.75,False,����ͣ,-2147483640|"
		cs+="Text,Text24,128.0585,83.07925,����,15.75,False,"+day1+",-2147483640|"
		cs+="Text,Text23,121.1793,83.07925,����,15.75,False,��,-2147483640|"
		cs+="Text,Text22,112.7126,83.07925,����,15.75,False,"+month1+",-2147483640|"
		cs+="Text,Text21,106.3626,83.07925,����,15.75,False,��,-2147483640|"
		cs+="Text,Text20,90.48759,83.07925,����,15.75,False,"+year1+",-2147483640|"
		cs+="Text,Text19,78.31674,83.07925,����,15.75,False,����,-2147483640|"
		cs+="Text,Text18,8.995842,83.07925,����,15.75,False,"+dabh+",-2147483640|"
		cs+="Text,Text17,0,83.07925,����,15.75,False,�ţ�,-2147483640|"
		cs+="Text,Text16,0,73.02507,����,15.75,False,�� �� ֤ ҵ ���� �� �� �� �� �� �� ʻ ֤ �� �� �� ��,-2147483640|"
		cs+="Text,Text15,55.03339,62.9709,����,15.75,False,"+day1+",-2147483640|"
		cs+="Text,Text14,44.45004,62.9709,����,15.75,False,��,-2147483640|"
		cs+="Text,Text13,34.39587,62.9709,����,15.75,False,"+month1+",-2147483640|"
		cs+="Text,Text12,23.81252,62.9709,����,15.75,False,��,-2147483640|"
		cs+="Text,Text11,7.937508,62.9709,����,15.75,False,"+year1+",-2147483640|"
		cs+="Text,Text10,0,62.9709,����,15.75,False,��,-2147483640|"
		cs+="Text,Text8,39.15837,52.91672,����,15.75,False,"+strywyy+",-2147483640|"
		cs+="Text,Text9,8.466675,52.91672,����,15.75,False,������ԭ��,-2147483640|"
		cs+="Text,Text7,0,41.27504,����,15.75,False,�� ��������    �� ����������,-2147483640|"
		cs+="Text,Text6,13.75835,31.22087,����,15.75,False,"+sfzmhm+",-2147483640|"
		cs+="Text,Text5,0,31.22087,����,15.75,False,Ϊ��,-2147483640|"
		cs+="Text,Text4,91.54592,21.16669,����,15.75,False,�� �� �� ֤ �� �� ��,-2147483640|"
		cs+="Text,Text3,23.81252,21.16669,����,15.75,False,"+xm+",-2147483640|"
		cs+="Text,Text2,0,21.16669,����,15.75,False,�� ʻ ��,-2147483640|"
		cs+="Text,Text1,25.92919,.5291672,����,18,False,���ڰ����������ʻ֤������֤��ִ,-2147483640|"
		cs+="Line,Line13,1,1,77.25841,86.25425,100.0126,100.0126|"
		cs+="Line,Line12,1,1,60.85423,69.85007,100.0126,100.0126|"
		cs+="Line,Line11,1,1,34.39587,51.32922,100.0126,100.0126|"
		cs+="Line,Line10,1,1,129.1168,134.9376,89.95842,89.95842|"
		cs+="Line,Line9,1,1,113.2418,121.1793,89.95842,89.95842|"
		cs+="Line,Line8,1,1,91.01675,106.3626,89.95842,89.95842|"
		cs+="Line,Line7,1,1,9.525009,78.84591,89.95842,89.95842|"
		cs+="Line,Line6,1,1,55.56255,66.67506,69.85007,69.85007|"
		cs+="Line,Line5,1,1,34.92503,44.45004,69.85007,69.85007|"
		cs+="Line,Line4,1,1,7.40834,23.28336,69.85007,69.85007|"
		cs+="Line,Line3,1,1,39.15837,153.4585,59.79589,59.79589|"
		cs+="Line,Line2,1,1,13.75835,109.0084,38.10004,38.10004|"
		cs+="Line,Line1,1,1,24.34169,92.07509,28.04586,28.04586"
		drvprint.printData=cs;
		drvprint.data_print(); 
    }
 	 else if(code=="0"){
        msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
        alert(msg);
 	 }
 	 else if(code=="-1"){
        msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
        msg="��ȡ���ݹ����г����쳣��"+msg;
        alert(msg);
 	 }   		
}


function printmfxx()
{
	
    var xmlDoc = _xmlHttpRequestObj.responseXML;
    var code = xmlDoc.getElementsByTagName("code")[0].firstChild.data;
    var msg=  "";
  
    
    if(code=="1"){  
    	
        var jbr=xmlDoc.getElementsByTagName("jbr")[0].firstChild.data;
        var km1ksy=xmlDoc.getElementsByTagName("km1ksy")[0].firstChild.data;
        var km1ksrq=xmlDoc.getElementsByTagName("km1ksrq")[0].firstChild.data;
        var km1kscj=xmlDoc.getElementsByTagName("km1kscj")[0].firstChild.data; 
        var km3ksy=xmlDoc.getElementsByTagName("km3ksy")[0].firstChild.data;
        var km3ksrq=xmlDoc.getElementsByTagName("km3ksrq")[0].firstChild.data;
        var km3kscj=xmlDoc.getElementsByTagName("km3kscj")[0].firstChild.data;
            
        var mfcs=xmlDoc.getElementsByTagName("mfcs")[0].firstChild.data;
        var zjcx=xmlDoc.getElementsByTagName("zjcx")[0].firstChild.data;
        var xm=xmlDoc.getElementsByTagName("xm")[0].firstChild.data; 
        var dabh=xmlDoc.getElementsByTagName("dabh")[0].firstChild.data;
        var sfzmhm=xmlDoc.getElementsByTagName("sfzmhm")[0].firstChild.data;
        var todaystr=xmlDoc.getElementsByTagName("sysd")[0].firstChild.data;
      
        var cs = "";
        ls_year = todaystr.substring(0,4);
        ls_month = todaystr.substring(5,7);
        ls_day   = todaystr.substring(8,10);
       
        
		cs = "Text,Text43,116.4168,195.7919,����_GB2312,15.75,False,"+ls_year+",-2147483640|";
		cs+= "Text,Text35,129.1168,195.7919,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text34,140.2293,195.7919,����_GB2312,15.75,False,"+ls_month+",-2147483640|";
		cs+= "Text,Text33,147.6376,195.7919,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text11,158.7502,195.7919,����_GB2312,15.75,False,"+ls_day+",-2147483640|";
		cs+= "Text,Text7,166.1585,195.7919,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text59,88.37092,44.45004,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text42,165.6293,157.6918,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text41,158.221,157.6918,����_GB2312,15.75,False,"+ls_day+",-2147483640|";
		cs+= "Text,Text40,151.871,157.6918,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text39,144.4626,157.6918,����_GB2312,15.75,False,"+ls_month+",-2147483640|";
		cs+= "Text,Text38,138.1126,157.6918,����_GB2312,15.75,False,��,-2147483640|";
		cs+= "Text,Text37,125.4126,157.6918,����_GB2312,15.75,False,"+ls_year+",-2147483640|";
		cs+= "Text,Text36,104.7751,157.6918,����_GB2312,15.75,False,���ڣ�,-2147483640|";
		cs+= "Text,Text32,130.1751,147.6376,����_GB2312,15.75,False,"+jbr+",-2147483640|";
		cs+= "Text,Text31,89.42925,147.6376,����_GB2312,15.75,False,������ǩ�֣�,-2147483640|";
		cs+= "Text,Text30,26.45836,122.7668,����_GB2312,15.75,False,�ش�֪ͨ����������Ƿַ�ֵ��,-2147483640|";
		cs+= "Text,Text29,102.6584,113.7709,����_GB2312,15.75,False,"+km3ksy+",-2147483640|";
		cs+= "Text,Text28,144.4626,113.7709,����_GB2312,15.75,False,"+km3ksrq+",-2147483640|";
		cs+= "Text,Text27,60.85423,113.7709,����_GB2312,15.75,False,"+km3kscj+",-2147483640|";
		cs+= "Text,Text26,17.99168,113.7709,����_GB2312,15.75,False,��Ŀ��,-2147483640|";
		cs+= "Text,Text25,102.6584,105.3043,����_GB2312,15.75,False,"+km1ksy+",-2147483640|";
		cs+= "Text,Text24,144.4626,105.3043,����_GB2312,15.75,False,"+km1ksrq+",-2147483640|";
		cs+= "Text,Text23,60.85423,105.3043,����_GB2312,15.75,False,"+km1kscj+",-2147483640|";
		cs+= "Text,Text22,17.99168,105.3043,����_GB2312,15.75,False,��Ŀһ,-2147483640|";
		cs+= "Text,Text21,102.6584,96.83759,����_GB2312,15.75,False,����Ա,-2147483640|";
		cs+= "Text,Text20,144.4626,96.83759,����_GB2312,15.75,False,��������,-2147483640|";
		cs+= "Text,Text19,60.85423,96.83759,����_GB2312,15.75,False,���Գɼ�,-2147483640|";
		cs+= "Text,Text18,17.99168,96.83759,����_GB2312,15.75,False,���Կ�Ŀ,-2147483640|";
		cs+= "Text,Text17,12.70001,85.19592,����_GB2312,15.75,False,�ԡ����ѿ��Ժϸ񣬸���Ŀ������Ϣ���£�,-2147483640|";
		cs+= "Text,Text16,104.7751,75.14174,����_GB2312,15.75,False,�����֣�����Ը���������п�,-2147483640|";
		cs+= "Text,Text15,81.49174,75.14174,����_GB2312,15.75,False,"+mfcs+",-2147483640|";
		cs+= "Text,Text14,13.22918,75.14174,����_GB2312,15.75,False,������Υ���Ƿִﵽ,-2147483640|";
		cs+= "Text,Text13,152.4001,64.5584,����_GB2312,15.75,False,���ڱ��Ƿ�,-2147483640|";
		cs+= "Text,Text12,163.5127,54.50422,����_GB2312,15.75,False,������,-2147483640|";
		cs+= "Text,Text10,136.5251,64.5584,����_GB2312,15.75,False,"+zjcx+",-2147483640|";
		cs+= "Text,Text9,83.60841,64.5584,����_GB2312,15.75,False,��׼�ݳ��ʹ���Ϊ,-2147483640|";
		cs+= "Text,Text8,55.56255,44.45004,����_GB2312,15.75,False,"+xm+",-2147483640|";
		cs+= "Text,Text6,38.6292,64.5584,����_GB2312,15.75,False,"+dabh+",-2147483640|";
		cs+= "Text,Text5,13.22918,64.5584,����_GB2312,15.75,False,���Ϊ,-2147483640|";
		cs+= "Text,Text4,101.0709,54.50422,����_GB2312,15.75,False,"+sfzmhm+",-2147483640|";
		cs+= "Text,Text3,26.45836,54.50422,����_GB2312,15.75,False,�����ֻ�������ʻ֤����Ϊ,-2147483640|";
		cs+= "Text,Text2,13.22918,44.45004,����_GB2312,15.75,False,��������ʻ��,-2147483640|";
		cs+= "Text,Text1,17.99168,26.45836,����,21.75,False,��������ʻ��Υ�����ֿ�����Ϣ����֪ͨ��,-2147483640|";
		cs+= "Line,Line21,1,1,157.1627,165.6293,165.1002,165.1002|Line,Line20,1,1,143.4043,151.871,165.1002,165.1002|";
		cs+= "Line,Line19,1,1,124.3543,138.6418,165.1002,165.1002|Line,Line16,1,1,125.4126,174.096,155.046,155.046|";
		cs+= "Line,Line15,1,1,179.3877,179.6523,95.25009,120.9147|Line,Line14,1,1,138.6418,138.9064,95.25009,120.9147|";
		cs+= "Line,Line13,1,1,96.83759,97.10218,95.25009,120.9147|Line,Line12,1,1,54.50422,54.7688,95.25009,120.9147|";
		cs+= "Line,Line11,1,1,15.34585,15.61043,95.25009,120.9147|Line,Line10,1,1,15.34585,179.9168,121.1793,121.1793|";
		cs+= "Line,Line9,1,1,15.34585,179.9168,112.7126,112.7126|Line,Line8,1,1,15.34585,179.9168,104.2459,104.2459|";
		cs+= "Line,Line7,1,1,15.34585,179.9168,95.77926,95.77926|Line,Line6,1,1,67.7334,105.3043,82.55008,82.55008|";
		cs+= "Line,Line5,1,1,130.7043,152.4001,71.96674,71.96674|Line,Line3,1,1,33.8667,82.55008,71.96674,71.96674|";
		cs+= "Line,Line2,1,1,99.48343,160.3377,61.91256,61.91256|Line,Line1,1,1,49.21255,88.37092,51.85838,51.85838";
	
		drvprint.printData=cs;
		drvprint.data_print();
    }
 	 else if(code=="0"){
        msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
        alert(msg);
 	 }
 	 else if(code=="-1"){
        msg=xmlDoc.getElementsByTagName("msg")[0].firstChild.data;
        msg="��ȡ���ݹ����г����쳣��"+msg;
        alert(msg);
 	 }   		
}

//��ӡ��֪��
function printgzd(){
	  try{
		/*
	    blyear = a.substring(0,4);
	    blmonth = a.substring(5,7);
	    blday = a.substring(8,10);
	    yqlx = document.all.ywlx.value;
	    if (yqlx == "S"){//���ڻ�֤
	      yqqz = document.all.yxqz.value;
	    }else{
	      yqqz = document.all.oldsyrq.value;
	    }
	    yqqz = DateAddMonth(yqqz, 24);
	    yqyear = yqqz.substring(0,4);
	    yqmonth = yqqz.substring(5,7);
	    yqday = yqqz.substring(8,10);
	    */
		    var blyear = "2010";
		    var blmonth = "02";
		    var blday = "03";
		    var yqlx = "S";
		    var yqqz="";
		   
		    if (yqlx == "S"){//���ڻ�֤
		      yqqz = "2011-11-12";
		    }else{
		      yqqz = "2010-03-10";
		    }
		    yqqz = "2013-11-12";
		    yqyear = "2013";
		    yqmonth = "11";
		    yqday = "12";  
		    var xm="��ΰ��";
		    var sfzmhm="429006197706285113";

	    cs = "Text,blmonth,146.0501,177.8002,����_GB2312,14.25,False,"+blmonth+",-2147483640|";
	    cs+= "Text,blday,162.9835,177.8002,����_GB2312,14.25,False,"+blday+",-2147483640|";
	    cs+= "Text,blyear,124.8835,177.8002,����_GB2312,14.25,False,"+blyear+",-2147483640|";
	    cs+= "Text,yqmonth,114.3001,95.25009,����_GB2312,14.25,False,"+yqmonth+",-2147483640|";
	    cs+= "Text,yqday,129.1168,95.25009,����_GB2312,14.25,False,"+yqday+",-2147483640|";
	    cs+= "Text,yqyear,93.13342,95.25009,����_GB2312,14.25,False,"+yqyear+",-2147483640|";
	    cs+= "Text,xm,57.15005,57.15005,����_GB2312,14.25,False,"+xm+",-2147483640|";
	    cs+= "Text,sfzmhm,112.1834,74.0834,����_GB2312,14.25,False,"+sfzmhm+",-2147483640|";
	    cs+= "Text,Text8,16.93335,105.8334,����_GB2312,14.25,False,����֤�����ύ����������֤������������,-2147483640|";
	    cs+= "Text,Text4,16.93335,95.25009,����_GB2312,14.25,False,��������ʻֹ֤ͣʹ�á�����,-2147483640|";
	    cs+= "Text,Text3,16.93335,84.66675,����_GB2312,14.25,False,�Ѱ������ڻ�֤���������ύ����������֤�����������������ڼ䣬,-2147483640|";
	    cs+= "Text,Text1,19.05002,57.15005,����_GB2312,15.75,False,��������ʻ��,-2147483640|";
	    cs+= "Text,Text2,27.51669,74.0834,����_GB2312,14.25,False,�����ֵĻ�������ʻ֤������Ϊ,-2147483640|";
	    cs+= "Label,Label7,171.4502,74.0834,����_GB2312,15.75,False,����,-2147483630|";
	    cs+= "Text,Text12,173.5668,177.8002,����_GB2312,14.25,False,��,-2147483640|";
	    cs+= "Text,Text11,156.6335,177.8002,����_GB2312,14.25,False,��,-2147483640|";
	    cs+= "Text,Text10,139.7001,177.8002,����_GB2312,14.25,False,��,-2147483640|";
	    cs+= "Line,Line8,1,1,124.8835,139.7001,186.2668,186.2668|Line,Line7,1,1,162.9835,173.5668,186.2668,186.2668|";
	    cs+= "Line,Line3,1,1,146.0501,158.7502,186.2668,186.2668|";
	    cs+= "Text,Text7,137.5835,95.25009,����_GB2312,14.25,False,��ǰ������������,-2147483640|";
	    cs+= "Text,Text6,122.7668,95.25009,����_GB2312,14.25,False,��,-2147483640|";
	    cs+= "Text,Text5,107.9501,95.25009,����_GB2312,14.25,False,��,-2147483640|";
	    cs+= "Line,Line20,1,1,91.01675,103.7168,101.6001,101.6001|Line,Line19,1,1,129.1168,135.4668,101.6001,101.6001|";
	    cs+= "Line,Line18,1,1,114.3001,120.6501,101.6001,101.6001|Line,Line1,1,1,55.03339,114.3001,63.50006,63.50006|";
	    cs+= "Label,Label3,114.3001,57.15005,����_GB2312,15.75,False,��,-2147483630|";
	    cs+= "Line,Line4,1,1,103.7168,169.3335,80.43341,80.43341|";
	    cs+= "Text,Text9,50.80005,27.51669,����,21.75,False,��������ʻ֤���ڸ�֪��,-2147483640";

	    drvprint.printData=cs
	    drvprint.data_print();
	  }catch(e){
	    alert(e.description)
	  }
	}

