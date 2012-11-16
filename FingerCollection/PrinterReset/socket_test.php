<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<?php
	require_once 'CRC16Dao.php';

	// Create the socket and connect

	//组织包体
		$body="1,2,3,4,5,6,7\r1,2,3\r15910606124\t777166\t1\n";
		$bodyLength=strlen($body);
	//组织包头
		$id="0";//类型表识符	String	1字节	区别包头类型的表识符
		$head=pack('A',$id);
		
		$packageLength=14+$bodyLength+2;//数据包长度	Int	4字节	整个包长度(包头18＋包体＋长度为2的包尾CRC16校验码)
		$s=base_convert($packageLength,10,16);
		$head.=pack('H*',str_repeat('0',8-strlen($s)).$s);
		$version="01";//软件版本	String	2字节	检验版本号是否为允许同步的版本号
		$pri="05";//优先级	String	2字节	发送优先级 前台为09
		$rule='3001';//规则号	String	4字节	（对应规则文件中的data标签的name属性值，前两个字节为业务交易类型代号，在一次传输过程中唯一；后两个字节：请求报文为"01"，返回结果报文为"02"，业务级状态码报文为"03"）
		$isCompress="0";//是否压缩	String	1个字节	数据包是否压缩（0代表未压缩、1代表压缩）
		$head.=pack("A*",$version.$pri.$rule.$isCompress);
	$head.=pack('A*',$body);
	$c=new Dao_Member_Engine_CRC16Dao();
	$tail=$c->getCRC16Code($head);
	$tail=base_convert($tail&0xffff,10,16);
	$head.=pack('H*',str_repeat('0',4-strlen($tail)).$tail );//包尾

	$handle = fsockopen("10.12.23.216",2907,$errno,$errstr,10);
if(!$handle){
	$errorMessage='socket connection timeout:10 seconds';
	echo $errorMessage;
	return false;
}
echo "socket create success.<br>";
fwrite($handle,$head);//发送包
$timeout=10;
$result=stream_set_timeout($handle,$timeout);//设置读超时	

//读取回应包
$returnPage_one=fread($handle,5);
	//读取第一个字节
		$returnPage_temp=base_convert(bin2hex(substr($returnPage_one,0,1)),16,10);
		echo bin2hex(substr($returnPage_one,0,1))."<br>";
		echo $returnPage_temp."<br>";
	//读取第2、3个字节
		$returnPage_temp=base_convert(bin2hex(substr($returnPage_one,1,2)),16,10);
		echo bin2hex(substr($returnPage_one,1,2))."<br>";
		echo $returnPage_temp."<br>";
	//读取第4、5个字节
		$returnPage_temp=base_convert(bin2hex(substr($returnPage_one,3,2)),16,10);
		echo bin2hex(substr($returnPage_one,3,2))."<br>";
		echo $returnPage_temp."<br>";

//读取数据包
//包头
$DataPage_Head=fread($handle,22);
		$gpackageLength=base_convert(bin2hex(substr($DataPage_Head,1,4)),16,10);
		echo $gpackageLength."<br>";
$gpackage=$DataPage_Head;
//获得整个包
		for($remain=$gpackageLength-22,$buffer=1024,$s=''; $remain>0;$remain-=strlen($s)){
			$len=$remain>=$buffer?$buffer:$remain;
			$s=fread($handle,$len);
			$gpackage.=$s;
		}
		fclose($handle);//关闭Socket
//获得包体
$response=array_pop(unpack('A*',substr($gpackage,22,-2)));
$response=trim(strstr($response,"\r"));//去掉返回参数的序号
$response=explode("\n",$response);
		$result=array();
		foreach ($response as $i=>$row){
			$row=explode("\t",$row);
			echo "票据唯一标识:".$row[0]."<br>";
			echo "正副券标识:".$row[1]."<br>";
			echo "打印X坐标:".$row[2]."<br>";
			echo "打印Y坐标:".$row[3]."<br>";
			echo "字体大小:".$row[4]."<br>";
			echo "是否加粗:".$row[5]."<br>";
			echo "打印项内容:".$row[6]."<br>";
		}
		unset($response);
exit();	
?>