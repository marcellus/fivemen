#pragma once

#define TRX_ST_OK	0x60	//���ſ���ȷ #define TRX_ST_SS	0x61	//SS���� #define TRX_ST_ES	0x62	//ES���� #define TRX_ST_P	0x63	//P���� #define TRX_ST_LRC	0x64	//LRC���� #define TRX_ST_EC	0x65	//�հ״ŵ� 

class ChannelDataClass
{
private:	class CDataInfo	{	public:		CDataInfo()		{		};		~CDataInfo(){};		unsigned int m_nChannel;		unsigned int m_nTRST;		unsigned int m_nLEN;		unsigned char m_arrCHData[255];	};
public:
	ChannelDataClass(void);
	~ChannelDataClass(void);
	bool SetData(unsigned char nChannelFlg, char *pData);
	unsigned int GetChannelIDS(unsigned char nChannelFlg);
	unsigned char GetChannelDataBeginFlg(unsigned int nChannel);
	bool GetChannelData(unsigned char nChannel,unsigned int& nlength,char *pData);
private:	CDataInfo m_arrData[3];
};
