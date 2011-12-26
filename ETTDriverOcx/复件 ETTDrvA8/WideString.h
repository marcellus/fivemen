#pragma once

/*
* ���ַ���
*/
class WideString
{

	//wchar_t;

	//��ʼ��
	void init(char*, unsigned int);

public:
	wchar_t* ws;
	/*
	* ���캯������������ַ���ת����wchar_t;
	*/
	WideString(char*);
	/*
	* ���캯������������ַ���ת����wchar_t;
	*/
	WideString(char*, unsigned int);
	/*
	* ��������,�ͷ�wchar_t;
	*/
	~WideString();
	/*
	* ת����UTF-8�ַ���
	*/
	void toUTF8String(char*);
	/*
	* ��ȡUTF-8�ַ�������
	*/
	unsigned int getUTF8StringLength();
	/*
	* ת����Ĭ�ϱ����ַ���
	*/
	void toDefaultString(char*);
	/*
	* ��ȡĬ�ϱ����ַ�������
	*/
	unsigned int getDefaultStringLength();
	/*
	* ת����MultiBytes�ַ���
	*/
	void toMultiBytesString(char*, unsigned int);
	/*
	* ��ȡMultiBytes�ַ�������
	*/
	unsigned int getMultiBytesStringLength(unsigned int);
};

