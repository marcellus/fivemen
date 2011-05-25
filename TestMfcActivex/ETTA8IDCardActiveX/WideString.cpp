#include "StdAfx.h"
#include "WideString.h"

//��������
WideString::WideString(char* cs)
{
	this->init(cs, CP_ACP);
}
//��������
WideString::WideString(char* cs, unsigned int codePage)
{
	this->init(cs, codePage);
}
//��ʼ������
void WideString::init(char* cs, unsigned int codePage)
{
	int wsLength = 0;
	wsLength = MultiByteToWideChar(codePage,0,cs,-1,NULL,NULL);  //��ȡת����Unicode���������Ҫ���ַ��ռ䳤��
	this->ws = new wchar_t[wsLength + 1];
	wsLength = MultiByteToWideChar(codePage,0,cs,-1,this->ws ,wsLength);  //ת����Unicode����
	if(!wsLength)  //ת��ʧ��������˳�
		return;
}
//��������
WideString::~WideString()
{
	if(this->ws)
	{
		delete []this->ws;
	}
}

//��ȡת����UTF8�ַ�������
unsigned int WideString::getUTF8StringLength()
{
	return this->getMultiBytesStringLength(CP_UTF8);
}
//ת����UTF8�ַ���
void WideString::toUTF8String(char* cs)
{
	this->toMultiBytesString(cs, CP_UTF8);
}
//��ȡת����Ĭ�ϱ����ַ�������
unsigned int WideString::getDefaultStringLength()
{
	return this->getMultiBytesStringLength(CP_ACP);
}
//ת����Ĭ�ϱ����ַ���
void WideString::toDefaultString(char* cs)
{
	this->toMultiBytesString(cs, CP_ACP);
}
//��ȡת����MultiBytes�ַ�������
unsigned int WideString::getMultiBytesStringLength(unsigned int codePage)
{
	int mbLength = 0;
	mbLength = WideCharToMultiByte(codePage,0,this->ws,-1,NULL,0,NULL,NULL);  //��ȡת����MultiBytes���������Ҫ���ַ��ռ䳤��
	return mbLength;
}
//ת����MultiBytes�ַ���
void WideString::toMultiBytesString(char* cs, unsigned int codePage)
{
	int mbLength = 0;
	mbLength = WideCharToMultiByte(codePage,0,this->ws,-1,NULL,0,NULL,NULL);  //��ȡת����MultiBytes���������Ҫ���ַ��ռ䳤��
	if( strlen(cs) < mbLength)
	{
		throw ;
	}
	mbLength = WideCharToMultiByte(codePage,0,this->ws,-1,cs,mbLength,NULL,NULL);  //ת����MultiBytes����
	if(!mbLength)
	{
		return;
	}
}

