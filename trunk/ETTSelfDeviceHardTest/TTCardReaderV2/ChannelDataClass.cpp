#include "StdAfx.h"
#include "ChannelDataClass.h"

ChannelDataClass::ChannelDataClass(void)
{
}

ChannelDataClass::~ChannelDataClass(void)
{
	memset(this->m_arrData,0,sizeof(CDataInfo)*3);
}
unsigned int ChannelDataClass::GetChannelIDS(unsigned char nChannelFlg)
{
	unsigned int nRes = 0;
	switch(nChannelFlg)
	{
	case 0x30:
		nRes = 1;
		break;
	case 0x31:
		nRes = 2;
		break;
	case 0x32:
		nRes = 3;
		break;
	case 0x33:
		nRes = 21;
		break;
	case 0x34:
		nRes = 31;
		break;
	case 0x35:
		nRes = 32;
		break;
	case 0x36:
		nRes = 321;
		break;
	}
	return nRes;
}

bool ChannelDataClass::GetChannelData(unsigned char nChannel,unsigned int& nlength, char *pData)
{
	bool bRes = false;
	for(int i=0;i<3;i++)
	{
		if(m_arrData[i].m_nChannel == nChannel && m_arrData[i].m_nChannel != 0)
		{
			nlength = m_arrData[i].m_nLEN;
			memcpy(pData,m_arrData[i].m_arrCHData,m_arrData[i].m_nLEN);
			bRes = true;
			break;
		}
	}
	return bRes;
}


unsigned char ChannelDataClass::GetChannelDataBeginFlg(unsigned int nChannel)
{
	unsigned char nRes = 0x00;

	switch(nChannel)
	{
	case 1:
		nRes=0xFA;
		break;
	case 2:
		nRes=0xFB;
		
		break;
	case 3:
		nRes=0xFC;
		
		break;

		/*
		case 1:{
				//nRes = 0xFA;//一轨数据起始字符。 
				break;}
			
		case 2:
			{
				//nRes = 0xFB;//二轨数据起始字符。 
				break;

			}
			
		case 3:
			{
				//nRes = 0xFC;//三轨数据起始字符。 
				break;
			}
			*/
				
		default:
			break;

	}

	return nRes;
}
/**/


bool ChannelDataClass::SetData(unsigned char nChannelFlg, char *pData)
{
	unsigned int nChannelIDs = GetChannelIDS(nChannelFlg);
	if(nChannelIDs == 0)
		return false;
	char *pCopy = pData;
	while(nChannelIDs > 0)
	{
		m_arrData[nChannelIDs%10].m_nChannel = nChannelIDs%10;
		m_arrData[nChannelIDs%10].m_nTRST = *pCopy++;
		m_arrData[nChannelIDs%10].m_nLEN = *pCopy++;
		nChannelIDs = nChannelIDs/10;
	}
	for(int i=0;i<3;i++)
	{
		if(m_arrData[i].m_nChannel != 0 && m_arrData[i].m_nLEN > 0)
		{
			//unsigned char nBeginFlg = GetChannelDataBeginFlg(m_arrData[i].m_nChannel);
			//if(nBeginFlg == 0x00)
				//return false;
			//while(*pCopy++ != nBeginFlg);
			memcpy(m_arrData[i].m_arrCHData,pCopy,m_arrData[i].m_nLEN);
			pCopy += m_arrData[i].m_nLEN;
		}
		else
		{

			continue;
		}
	}
	return true;

}
