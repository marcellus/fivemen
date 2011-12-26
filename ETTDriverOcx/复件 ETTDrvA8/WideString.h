#pragma once

/*
* 宽字符串
*/
class WideString
{

	//wchar_t;

	//初始化
	void init(char*, unsigned int);

public:
	wchar_t* ws;
	/*
	* 构造函数，将传入的字符串转换成wchar_t;
	*/
	WideString(char*);
	/*
	* 构造函数，将传入的字符串转换成wchar_t;
	*/
	WideString(char*, unsigned int);
	/*
	* 析构函数,释放wchar_t;
	*/
	~WideString();
	/*
	* 转换成UTF-8字符串
	*/
	void toUTF8String(char*);
	/*
	* 获取UTF-8字符串长度
	*/
	unsigned int getUTF8StringLength();
	/*
	* 转换成默认编码字符串
	*/
	void toDefaultString(char*);
	/*
	* 获取默认编码字符串长度
	*/
	unsigned int getDefaultStringLength();
	/*
	* 转换成MultiBytes字符串
	*/
	void toMultiBytesString(char*, unsigned int);
	/*
	* 获取MultiBytes字符串长度
	*/
	unsigned int getMultiBytesStringLength(unsigned int);
};

