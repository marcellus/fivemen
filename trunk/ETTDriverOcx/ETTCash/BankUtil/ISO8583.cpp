#include "StdAfx.h"
#include "ISO8583.h"
#include "math.h"
#include "assert.h"
#include "convert.h"

ISO8583Field Tbl8583[128] = 
{
	///* FLD 01 */ {0,"BIT MAP,DataType", 8, 0, 0, 2, NULL,0}, 
	/* FLD 01 */ {0,"BIT MAP,EXTENDED", 8, 0, 0, 2, NULL,0}, 
	/* FLD 02 */ {0,"PRIMARY ACCOUNT NUMBER", 22, 0, 2, 3, NULL,0}, 
	/* FLD 03 */ {0,"PROCESSING CODE", 6, 0, 0, 3, NULL,0}, 
	/* FLD 04 */ {0,"AMOUNT, TRANSACTION", 12, 0, 0, 3, NULL,0}, 
	/* FLD 05 */ {0,"NO USE", 12, 0, 0, 0, NULL,0}, 
	/* FLD 06 */ {0,"NO USE", 12, 0, 0, 0, NULL,0}, 
	/* FLD 07 */ {0,"TRANSACTION DATE AND TIME", 10, 0, 0, 0, NULL,0}, 
	/* FLD 08 */ {0,"NO USE", 8, 0, 0, 0, NULL,0}, 
	/* FLD 09 */ {0,"NO USE", 8, 0, 0, 0, NULL,0}, 
	/* FLD 10 */ {0,"NO USE", 8, 0, 0, 0, NULL,0}, 
	/* FLD 11 */ {0,"SYSTEM TRACE AUDIT NUMBER", 6, 0, 0, 3, NULL,0}, 
	/* FLD 12 */ {0,"TIME, LOCAL TRANSACTION", 6, 0, 0, 3, NULL,0}, 
	/* FLD 13 */ {0,"DATE, LOCAL TRANSACTION", 4, 0, 0, 3, NULL,0}, 
	/* FLD 14 */ {0,"DATE, EXPIRATION", 4, 0, 0, 3, NULL,0}, 
	/* FLD 15 */ {0,"DATE, SETTLEMENT", 4, 0, 0, 3, NULL,0}, 
	/* FLD 16 */ {0,"NO USE", 4, 0, 0, 0, NULL,0}, 
	/* FLD 17 */ {0,"DATE, CAPTURE", 4, 0, 0, 0, NULL,0}, 
	/* FLD 18 */ {0,"MERCHANT'S TYPE", 4, 0, 0, 0, NULL,0}, 
	/* FLD 19 */ {0,"NO USE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 20 */ {0,"NO USE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 21 */ {0,"NO USE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 22 */ {0,"POINT OF SERVICE ENTRY MODE", 3, 0, 0, 3, NULL,0}, 
	/* FLD 23 */ {0,"NO USE", 3, 0, 0, 3, NULL,0}, 
	/* FLD 24 */ {0,"NO USE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 25 */ {0,"POINT OF SERVICE CONDITION CODE", 2, 0, 0, 3, NULL,0}, 
	/* FLD 26 */ {0,"NO USE", 2, 0, 0, 3, NULL,0}, 
	/* FLD 27 */ {0,"NO USE", 1, 0, 0, 0, NULL,0}, 
	/* FLD 28 */ {0,"field27", 6, 0, 0, 0, NULL,0}, 
	/* FLD 29 */ {0,"NO USE", 8, 0, 1, 0, NULL,0}, 
	/* FLD 30 */ {0,"NO USE", 8, 0, 1, 0, NULL,0}, 
	/* FLD 31 */ {0,"NO USE", 8, 0, 1, 0, NULL,0}, 
	/* FLD 32 */ {0,"ACQUIRER INSTITUTION ID. CODE", 11, 0, 2, 3, NULL,0}, 
	/* FLD 33 */ {0,"FORWARDING INSTITUTION ID. CODE", 11, 0, 2, 0, NULL,0}, 
	/* FLD 34 */ {0,"NO USE", 28, 0, 2, 0, NULL,0}, 
	/* FLD 35 */ {0,"TRACK 2 DATA", 37, 0, 2, 3, NULL,0}, 
	/* FLD 36 */ {0,"TRACK 3 DATA",104, 0, 3, 3, NULL,0}, 
	/* FLD 37 */ {0,"RETRIEVAL REFERENCE NUMBER", 12, 0, 0, 0, NULL,0}, 
	/* FLD 38 */ {0,"AUTH. IDENTIFICATION RESPONSE", 6, 0, 0, 0, NULL,0}, 
	/* FLD 39 */ {0,"RESPONSE CODE", 2, 0, 0, 0, NULL,0}, 
	/* FLD 40 */ {0,"NO USE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 41 */ {0,"CARD ACCEPTOR TERMINAL ID.", 8, 0, 0, 0, NULL,0}, 
	/* FLD 42 */ {0,"CARD ACCEPTOR IDENTIFICATION CODE", 15, 0, 0, 0, NULL,0}, 
	/* FLD 43 */ {0,"CARD ACCEPTOR NAME LOCATION", 40, 0, 0, 0, NULL,0}, 
	/* FLD 44 */ {0,"ADDITIONAL RESPONSE DATA", 25, 0, 2, 0, NULL,0}, 
	/* FLD 45 */ {0,"NO USE", 76, 0, 2, 0, NULL,0}, 
	/* FLD 46 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 47 */ {0,"field47", 999, 0, 3, 0, NULL,0}, 
	/* FLD 48 */ {0,"ADDITIONAL DATA --- PRIVATE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 49 */ {0,"CURRENCY CODE,TRANSACTION", 3, 0, 0, 0, NULL,0}, 
	/* FLD 50 */ {0,"CURRENCY CODE,SETTLEMENT", 3, 0, 0, 0, NULL,0}, 
	/* FLD 51 */ {0,"NO USE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 52 */ {0,"PERSONAL IDENTIFICATION NUMBER DATA", 8, 0, 0, 2, NULL,0}, 
	/* FLD 53 */ {0,"SECURITY RELATED CONTROL INformATION", 16, 0, 0, 3, NULL,0}, 
	/* FLD 54 */ {0,"ADDITIONAL AMOUNTS",120, 0, 3, 0, NULL,0}, 
	/* FLD 55 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 56 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 57 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 58 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 59 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 60 */ {0,"NO USE", 999, 0, 3, 3, NULL,0}, 
	/* FLD 61 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 62 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 63 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 64 */ {0,"MESSAGE AUTHENTICATION CODE FIELD", 8, 0, 0, 2, NULL,0}, 
	/* FLD 65 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 66 */ {0,"NO USE", 1, 0, 0, 0, NULL,0}, 
	/* FLD 67 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 68 */ {0,"NO USE", 999, 0, 3, 0, NULL,0},
	/* FLD 69 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 70 */ {0,"SYSTEM MANAGEMENT INformATION CODE", 3, 0, 0, 0, NULL,0}, 
	/* FLD 71 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 72 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 73 */ {0,"NO USE", 6, 0, 0, 0, NULL,0}, 
	/* FLD 74 */ {0,"NUMBER OF CREDITS", 10, 0, 0, 0, NULL,0}, 
	/* FLD 75 */ {0,"REVERSAL NUMBER OF CREDITS", 10, 0, 0, 0, NULL,0}, 
	/* FLD 76 */ {0,"NUMBER OF DEBITS", 10, 0, 0, 0, NULL,0}, 
	/* FLD 77 */ {0,"REVERSAL NUMBER OF DEBITS", 10, 0, 0, 0, NULL,0}, 
	/* FLD 78 */ {0,"NUMBER OF TRANSFER", 10, 0, 0, 0, NULL,0}, 
	/* FLD 79 */ {0,"REVERSAL NUMBER OF TRANSFER", 10, 0, 0, 0, NULL,0}, 
	/* FLD 80 */ {0,"NUMBER OF INQUIRS", 10, 0, 0, 0, NULL,0}, 
	/* FLD 81 */ {0,"AUTHORIZATION NUMBER", 10, 0, 0, 0, NULL,0}, 
	/* FLD 82 */ {0,"NO USE", 12, 0, 0, 0, NULL,0}, 
	/* FLD 83 */ {0,"CREDITS,TRANSCATION FEEAMOUNT", 12, 0, 0, 0, NULL,0}, 
	/* FLD 84 */ {0,"NO USE", 12, 0, 0, 0, NULL,0}, 
	/* FLD 85 */ {0,"DEBITS,TRANSCATION FEEAMOUNT", 12, 0, 0, 0, NULL,0}, 
	/* FLD 86 */ {0,"AMOUNT OF CREDITS", 16, 0, 0, 0, NULL,0}, 
	/* FLD 87 */ {0,"REVERSAL AMOUNT OF CREDITS", 16, 0, 0, 0, NULL,0}, 
	/* FLD 88 */ {0,"AMOUNT OF DEBITS", 16, 0, 0, 0, NULL,0}, 
	/* FLD 89 */ {0,"REVERSAL AMOUNT OF DEBITS", 16, 0, 0, 0, NULL,0}, 
	/* FLD 90 */ {0,"ORIGINAL DATA ELEMENTS", 42, 0, 0, 0, NULL,0}, 
	/* FLD 91 */ {0,"FILE UPDATE CODE", 1, 0, 0, 0, NULL,0}, 
	/* FLD 92 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 93 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 94 */ {0,"SERVICE INDICATOR", 7, 0, 0, 0, NULL,0}, 
	/* FLD 95 */ {0,"REPLACEMENT AMOUNTS", 42, 0, 0, 0, NULL,0}, 
	/* FLD 96 */ {0,"NO USE", 8, 0, 0, 0, NULL,0}, 
	/* FLD 97 */ {0,"AMOUNT OF NET SETTLEMENT", 16, 0, 0, 0, NULL,0}, 
	/* FLD 98 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 99 */ {0,"SETTLEMENT INSTITUTION ID", 11, 0, 2, 0, NULL,0}, 
	/* FLD 100 */ {0,"RECVEING INSTITUTION ID", 11, 0, 2, 0, NULL,0}, 
	/* FLD 101 */ {0,"FILENAME", 17, 0, 2, 0, NULL,0}, 
	/* FLD 102 */ {0,"ACCOUNT IDENTIFICATION1", 28, 0, 2, 0, NULL,0}, 
	/* FLD 103 */ {0,"ACCOUNT IDENTIFICATION2", 28, 0, 2, 0, NULL,0}, 
	/* FLD 104 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 105 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 106 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 107 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 108 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 109 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 110 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 111 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 112 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 113 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 114 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 115 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 116 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 117 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 118 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 119 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 120 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 121 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 122 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 123 */ {0,"NEW PIN DATA", 8, 0, 3, 2, NULL,0}, 
	/* FLD 124 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 125 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 126 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 127 */ {0,"NO USE", 999, 0, 3, 0, NULL,0}, 
	/* FLD 128 */ {0,"MESSAGE AUTHENTICATION CODE FIELD", 8, 0, 0, 2, NULL,0}, 
}; 

/* Set bit in specified position */
void CISO8583::setBit(BYTE *pBytes, int nPos)
{
	if (nPos % 8 == 0)
		pBytes[nPos / 8 - 1] |= 0x01;
	else
		pBytes[(unsigned int)floor(nPos / 8.0)] |= (0x80 >> (nPos % 8 - 1));

	if (nPos > 64)
		setBit(pBytes, 1);
}

bool CISO8583::testBit(const BYTE *pBytes, int nPos)
{
	unsigned int nOffset;
	BYTE nMask;
	nOffset = nPos % 8 == 0 ? nPos / 8 - 1 : (unsigned int)floor(nPos / 8.0);
	nMask = nPos % 8 == 0 ? 0x01 : (0x80 >> (nPos % 8 - 1));

	return (pBytes[nOffset] & nMask) == nMask;
}

int CISO8583::GetMessageLength()
{
	int len = 0;
	map<int, ISO8583FieldData>::iterator it = m_fields.begin();
	while (it != m_fields.end()) 
	{
		if (Tbl8583[it->first -1].variable_flag == 0) 
		{
			if(Tbl8583[it->first -1].datatype == 3)//BCD
			{
				int nLen = (it->second.len + 1) / 2;
				len += nLen;
			}
			else
			{
				len += it->second.len;
			}
		}
		else  
		{
			if(Tbl8583[it->first -1].datatype == 3)//BCD
			{
				int nLen = (it->second.len + 1)/2;
				len += (nLen + Tbl8583[it->first - 1].variable_flag -1 );
			}
			else
			{
				len += (it->second.len + Tbl8583[it->first - 1].variable_flag - 1);
			}
		}

		it++;
	}
 
	return len + 8;
}

CIso8583Package::CIso8583Package()
{
}

CIso8583Package::~CIso8583Package()
{
	map<int, ISO8583FieldData>::iterator it = m_fields.begin();
	while (it != m_fields.end()) {
		delete it->second.data;
		it++;
	}
}
int CIso8583Package::GetData(BYTE *pOutBuf,int nBufLen,BYTE *pAddtionData,int nAddtionLen,bool flag)
{
	int nDataLen = GetMessageLength();
	if(flag )
	{
		memset(cMacBuff,0,1024);
		GetSendBuffer(cMacBuff,nDataLen);
	}
	else
	{
		map<int, ISO8583FieldData>::iterator it = m_fields.find(64);
		if (it != m_fields.end())
		{
			int nFieldLen = it->second.len;
			if (nBufLen < it->second.len)
				return -1;
			memcpy(cMacBuff + nDataLen - 8, it->second.data, nFieldLen);
		}
	}

	int nOutLen = 0;
	BYTE pTemp[1024];
	memset(pTemp,0,1024);
	AddPackageHeader(cMacBuff,nDataLen,(const char *)pAddtionData,nAddtionLen,pTemp,nOutLen);
	nDataLen = nDataLen + nAddtionLen;
	memcpy(pOutBuf,pTemp,nDataLen);

	return nDataLen;
}
void CIso8583Package::AddPackageHeader(BYTE *pInData,int nInLen,const char *pData,int nLen,BYTE *pOutData,int &nOutLen)
{
	//_snprintf((char *)pOutData,nLen,pData);
	memcpy(pOutData,pData,nLen);

	memcpy(pOutData + nLen,pInData,nInLen);
	nOutLen = nInLen + nLen;
}
int CIso8583Package::GetSendBuffer(BYTE *pOutBuf, int nBufLen)
{
	int offset = 8; //TPDU(5) + Header(6) + Type(2) + Bitmap(8)
	if (NULL == pOutBuf || nBufLen < GetMessageLength())
		return -1;

	memset((void *)(pOutBuf + 8), 0, 8);//bitmap
	map<int, ISO8583FieldData>::iterator it = m_fields.begin();
	while (it != m_fields.end()) {
		setBit(pOutBuf/* + 8*/, it->first);
		if( it->first == 35 ) setBit(pOutBuf,64);
		if (Tbl8583[it->first -1].variable_flag == 0) {
			if(Tbl8583[it->first -1].datatype == 3)//BCD
			{
				unsigned char cDataValue[128];
				memset(cDataValue,0,sizeof(cDataValue));
				AscToHex(cDataValue,it->second.data,it->second.len);
				int nLen = (it->second.len + 1) / 2;
				memcpy(pOutBuf + offset,cDataValue,nLen);
				offset += nLen;
			}
			else
			{
				memcpy(pOutBuf + offset, it->second.data, it->second.len);
				offset += it->second.len;
			}
		}
		else if (Tbl8583[it->first -1].variable_flag == 2) {
			if(Tbl8583[it->first -1].datatype == 3)//BCD
			{
				unsigned char cDataLen[2];
				memset(cDataLen,0,sizeof(cDataLen));
				BinToBcd(cDataLen,it->second.len,1);
				memcpy(pOutBuf + offset,cDataLen,1);
				unsigned char cDataValue[128];
				memset(cDataValue,0,sizeof(cDataValue));
				AscToHex(cDataValue,it->second.data,it->second.len);
				int nLen = (it->second.len + 1)/2;
				memcpy(pOutBuf + offset + 1, cDataValue,nLen);
				offset = offset + nLen + 1;
			}
			else
			{
				_snprintf((char *)(pOutBuf + offset), 2, "%02d", it->second.len);
				memcpy(pOutBuf + offset + 2, it->second.data, it->second.len);
				offset = offset + it->second.len + 2;
			}
		}
		else if (Tbl8583[it->first -1].variable_flag == 3) 
		{
			if(Tbl8583[it->first -1].datatype == 3)//BCD
			{
				unsigned char cDataLen[3];
				memset(cDataLen,0,sizeof(cDataLen));
				BinToBcd(cDataLen,it->second.len,2);//Ç°²¹0
				memcpy(pOutBuf + offset,cDataLen,2);
				unsigned char cDataValue[128];
				memset(cDataValue,0,sizeof(cDataValue));
				AscToHex(cDataValue,it->second.data,it->second.len);
				int nLen = (it->second.len + 1)/2;
				memcpy(pOutBuf + offset + 2,cDataValue,nLen);
				offset = offset + nLen + 2;
			}
			else
			{
				unsigned char cDataLen[3];
				memset(cDataLen,0,sizeof(cDataLen));
				BinToBcd(cDataLen,it->second.len,2);//Ç°²¹0
				memcpy(pOutBuf + offset,cDataLen,2);

				memcpy(pOutBuf + offset + 2, it->second.data, it->second.len);
				offset = offset + it->second.len + 2;
			}
		}

		it++;
	}

	return offset;
}

const BYTE *CIso8583Package::SetFieldData(int nField, int nFieldLen, BYTE *pFieldBuf)
{
	if (nField > 128 || nField < 0)
		throw "field should between 1 and 128";

	map<int, ISO8583FieldData>::iterator it = m_fields.find(nField);
	/* delete the specified field if it exists */
	if (it != m_fields.end()) {
		delete it->second.data;
		m_fields.erase(it);
	}

	/* clear the specified field and return if pFieldBuf is NULL */
	if (NULL == pFieldBuf) 
		return NULL;

	/* copy data */
	ISO8583FieldData field;
	field.len = nFieldLen;
	field.data = new BYTE[field.len];
	if (NULL == field.data)
		return NULL;

	memcpy(field.data, pFieldBuf, field.len);
	/* add field */
	m_fields[nField] = field;
	return field.data;
}


CIso8583Parse::CIso8583Parse()
{
}

CIso8583Parse::~CIso8583Parse()
{
	m_fields.clear();
}

bool CIso8583Parse::ReadMessage(const BYTE *pMessage,bool flag)
{
	try {
		return parseFields(pMessage,flag);
	}
	catch(...) 
	{
		return false;
	}
}

bool CIso8583Parse::parseFields(const BYTE *pMessage,bool flag)
{
	bool extensionMode = testBit(pMessage, 1);
	DWORD dwOffset = 15 + 8;
	BYTE len[4];
	/* Test bit pos 2 - 128 or 2 - 64 */
	int iBitCount = extensionMode == true ? 128 : 64;
	for (int i = 2; i <= iBitCount; i++) {
		if (!testBit(pMessage + 15, i)) continue;

		/* find data position and length for each field */
		ISO8583FieldData field;

		if (Tbl8583[i - 1].variable_flag == 0) 
		{
			if(Tbl8583[i - 1].datatype == 3)//BCD
			{
				field.len = (Tbl8583[i-1].length + 1) / 2;
				field.data = new BYTE[field.len];
				memcpy(field.data,(void *)(pMessage + dwOffset),field.len);
				dwOffset += field.len;
			}
			else
			{
				field.len = Tbl8583[i - 1].length;
				field.data = (BYTE *)pMessage + dwOffset;
				dwOffset += field.len;
			}
		}
		else if (Tbl8583[i - 1].variable_flag == 2)
		{
			memset(len, 0, sizeof(len));
			memcpy((void *)len, (void *)(pMessage + dwOffset), Tbl8583[i - 1].variable_flag -1);
			unsigned char cDataLen[3]={'\0'};
			BcdToAsc(cDataLen,len,2);
			if(Tbl8583[i - 1].datatype == 3)//BCD
			{
				field.len = (atol((char *)cDataLen) + 1) / 2;
				field.data = new BYTE[field.len];
				memcpy(field.data,(void *)(pMessage + dwOffset + Tbl8583[i - 1].variable_flag - 1),field.len);
				dwOffset = dwOffset + field.len + Tbl8583[i - 1].variable_flag - 1;
			}
			else
			{
				field.len = atol((char *)cDataLen);
				field.data = (BYTE *)(pMessage + dwOffset + Tbl8583[i - 1].variable_flag - 1);
				dwOffset = dwOffset + field.len + Tbl8583[i - 1].variable_flag - 1;
			}
		}
		else if (Tbl8583[i - 1].variable_flag == 3)
		{
			memset(len, 0, sizeof(len));
			memcpy((void *)len, (void *)(pMessage + dwOffset), Tbl8583[i - 1].variable_flag -1);
			unsigned char cDataLen[5]={'\0'};
			BcdToAsc(cDataLen,len,4);
			if(Tbl8583[i - 1].datatype == 3)//BCD
			{
				field.len = (atol((char *)cDataLen) + 1) / 2;
				field.data = new BYTE[field.len];
				memcpy(field.data,(void *)(pMessage + dwOffset + Tbl8583[i - 1].variable_flag - 1),field.len);
				dwOffset = dwOffset + field.len + Tbl8583[i - 1].variable_flag - 1;
			}
			else
			{
				field.len = atol((char *)cDataLen);
				field.data = (BYTE *)(pMessage + dwOffset + Tbl8583[i - 1].variable_flag - 1);
				dwOffset = dwOffset + field.len + Tbl8583[i - 1].variable_flag - 1;

			}
		}

		m_fields[i] = field;
	}

	return true;
}

int CIso8583Parse::GetFields(int *fields, int count)
{
	int fcount = (int)(m_fields.size() > count ? count : m_fields.size());
	map<int, ISO8583FieldData>::iterator it = m_fields.begin();
	for (int i = 0; i < fcount; i++) {
		fields[i] = it->first;
		it++;
	}

	return fcount;
}

int CIso8583Parse::FieldsCount()
{
	return (int)m_fields.size();
}

bool CIso8583Parse::FieldExist(int nField)
{
	return m_fields.find(nField) != m_fields.end();
}

int CIso8583Parse::FieldsExist(int *fields, int nCount)
{
	for (int i = 0; i < nCount; i++) {
		if (!FieldExist(fields[i]))
			return fields[i];
	}

	return 0;
}

int  CIso8583Parse::FieldLength(int nField)
{
	if (nField > 128) return -1;
	map<int, ISO8583FieldData>::iterator it = m_fields.find(nField);
	if (it == m_fields.end())
		return -1;
	if( it->first == 48)
		return 51 - Tbl8583[nField - 1].variable_flag;
	/* substract the LLL or LL length */
	return it->second.len - Tbl8583[nField - 1].variable_flag;
}

/* Get Field's data, not include the LL or LLL length value if it is varlength field */
int CIso8583Parse::ReadField(int nField, BYTE *pOutBuf, int nBufLen)
{
	map<int, ISO8583FieldData>::iterator it = m_fields.find(nField);
	if (it == m_fields.end())
		return -1;

	int nFieldLen = it->second.len;// - Tbl8583[nField - 1].variable_flag;
	if (nBufLen < it->second.len)
		return -1;

	//if(nField == 48)
	//	nFieldLen = 51 - Tbl8583[nField -1].variable_flag;

	memcpy(pOutBuf, it->second.data, nFieldLen);
	return nFieldLen;
}
