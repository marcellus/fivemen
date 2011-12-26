#include "StdAfx.h"
#include "WideString.h"

//创建函数
WideString::WideString(char* cs)
{
	this->init(cs, CP_ACP);
}
//创建函数
WideString::WideString(char* cs, unsigned int codePage)
{
	this->init(cs, codePage);
}
//初始化操作
void WideString::init(char* cs, unsigned int codePage)
{
	int wsLength = 0;
	wsLength = MultiByteToWideChar(codePage,0,cs,-1,NULL,NULL);  //获取转换到Unicode编码后所需要的字符空间长度
	this->ws = new wchar_t[wsLength + 1];
	wsLength = MultiByteToWideChar(codePage,0,cs,-1,this->ws ,wsLength);  //转换到Unicode编码
	if(!wsLength)  //转换失败则出错退出
		return;
}
//析构函数
WideString::~WideString()
{
	if(this->ws)
	{
		delete []this->ws;
	}
}

//获取转换的UTF8字符串长度
unsigned int WideString::getUTF8StringLength()
{
	return this->getMultiBytesStringLength(CP_UTF8);
}
//转换的UTF8字符串
void WideString::toUTF8String(char* cs)
{
	this->toMultiBytesString(cs, CP_UTF8);
}
//获取转换的默认编码字符串长度
unsigned int WideString::getDefaultStringLength()
{
	return this->getMultiBytesStringLength(CP_ACP);
}
//转换的默认编码字符串
void WideString::toDefaultString(char* cs)
{
	this->toMultiBytesString(cs, CP_ACP);
}
//获取转换的MultiBytes字符串长度
unsigned int WideString::getMultiBytesStringLength(unsigned int codePage)
{
	int mbLength = 0;
	mbLength = WideCharToMultiByte(codePage,0,this->ws,-1,NULL,0,NULL,NULL);  //获取转换到MultiBytes编码后所需要的字符空间长度
	return mbLength;
}
//转换的MultiBytes字符串
void WideString::toMultiBytesString(char* cs, unsigned int codePage)
{
	int mbLength = 0;
	mbLength = WideCharToMultiByte(codePage,0,this->ws,-1,NULL,0,NULL,NULL);  //获取转换到MultiBytes编码后所需要的字符空间长度
	if( strlen(cs) < mbLength)
	{
		throw ;
	}
	mbLength = WideCharToMultiByte(codePage,0,this->ws,-1,cs,mbLength,NULL,NULL);  //转换到MultiBytes编码
	if(!mbLength)
	{
		return;
	}
}

