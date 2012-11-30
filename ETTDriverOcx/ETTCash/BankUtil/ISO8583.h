#ifndef __ISO_8583_H__
#define __ISO_8583_H__

#include <map>
using namespace std;

typedef struct
{
	int		bit_flag; /*域数据类型0 -- string, 1 -- int, 2 -- binary*/
	char    *data_name;    /*域名*/
	int     length;        /*数据域长度*/
	int     length_in_byte;    /*实际长度（如果是变长）*/
	int     variable_flag;    /*是否变长标志0：否 2：2位变长, 3：3位变长*/
	int     datatype;        /*0 -- string, 1 -- int, 2 -- binary, 3 -- bcd(特殊设置)*/
	char    *data;    /*存放具体值*/
	int        attribute;    /*保留*/
} ISO8583Field; 

typedef struct {
	int len;
	BYTE *data;
} ISO8583FieldData;

class CISO8583
{
public:
	int GetMessageLength();

	void setBit(BYTE *pBytes, int nPos);
	bool testBit(const BYTE *pBytes, int nPos);
	map<int, ISO8583FieldData> m_fields;
};

class CIso8583Package : public CISO8583
{
public:
	CIso8583Package();
	~CIso8583Package();

	int GetSendBuffer(BYTE *pOutBuf, int nBufLen);
	int	GetData(BYTE *pOutBuf,int nBufLen,BYTE *pAddtionData,int nAddtionLen,bool flag);

	const BYTE *SetFieldData(int nField, int nFieldLen, BYTE *pFieldBuf);
	void AddPackageHeader(BYTE *pInData,int nInLen,const char *pData,int nLen,BYTE *pOutData,int &nOutLen);
private:
	BYTE cMacBuff[1024];
};

class CIso8583Parse : public CISO8583
{
public:
	CIso8583Parse();
	~CIso8583Parse();
	bool ReadMessage(const BYTE *pMessage,bool flag);
	int     GetFields(int *fields, int count);
	bool FieldExist(int nField);
	int FieldsExist(int *fields, int nCount);
	int     FieldsCount();
	int  FieldLength(int nField);
	int  ReadField(int nField, BYTE *pOutBuf, int nBufLen);

protected:
	bool parseFields(const BYTE *pMessage,bool flag);
};
#endif
