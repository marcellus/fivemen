// TTCardReaderV2.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "TTCardReaderV2.h"
#include "M100_DLL.h"
#include <stdio.h>
#include <string.h>
#include "ChannelDataClass.h"
#include <atlstr.h>





#pragma   comment(lib,"M100_DLL.lib")   


// ���ǵ���������һ��ʾ��
TTCARDREADERV2_API int nTTCardReaderV2=0;

// ���ǵ���������һ��ʾ����
TTCARDREADERV2_API int fnTTCardReaderV2(void)
{
	return 42;
}




static HANDLE handle;

extern "C" __declspec(dllexport) int __stdcall OpenDevice(int port,char *msg)
{

	char com[7]; 
	sprintf(com,"com%d",port);
	handle=M100_CommOpen(com);
	
	if(handle==0)
	{
		char message[] = "ʧ��";
		//strcpy(msg,message);
		strcpy(msg,message);
		//memset(message,0,sizeof(message));
		return -1;
	}
	else
	{

		char message[] = "�ɹ�";
	    strcpy(msg,message);
		return 0;
	}
}


extern "C" __declspec(dllexport) int __stdcall  CloseDevice(char *msg)
{

	if(handle!=NULL)
	{
		int ret=M100_CommClose(handle);
		if(ret==0)
		{
			char message[] = "�����ѹر�";
			strcpy(msg,message);
			handle=NULL;
			return 0;
			
		}
		else
		{
			char message[] = "ʧ��";
			strcpy(msg,message);
			return -1;
			
		}
	}
	
	char message[] = "�豸���������";
	strcpy(msg,message);
	return -2;
	
}

extern "C" __declspec(dllexport) int __stdcall  GetDeviceStatus(char *msg)
{

	if(handle!=NULL)
	{
		BYTE position;
		int ret=M100_CheckCardPosition( handle, &position); 
		
		if(ret==0)
		{
			
			if(position==0x35)
			{

				char message[] = "�������޿�";
				strcpy(msg,message);
				return 0;
			}
			else if(position==0x30||position==0x31)
			{

				char message[] = "����ǰ���п�";
				strcpy(msg,message);
				return 1;
			}
			else if(position==0x33||position==0x32||position==0x36)
			{
				char message[] = "�������п�";
				strcpy(msg,message);
				return 2;
			}
			else if(position==0x34)
			{
				char message[] = "��������п�";
				strcpy(msg,message);
				return 3;
			}
		}
		else
		{
			char message[] = "������������";
			strcpy(msg,message);
			return -1;

		}
	}

	char message[] = "�豸���������";
	strcpy(msg,message);
	return -2;
	/*
	=0x30����Ƭ��ǰ�˲��п�λ�á� 
	=0x31����Ƭ��ǰ�˼п�λ�á� 
	=0x32����Ƭ�ڶ�������Ƶ��λ�á� 
	=0x33����Ƭ��IC��λ�á� 
	=0x34����Ƭ�ں�˼п�λ�á� 
	=0x35�����������޿��� 
	=0x36�������ڱ�׼λ��   
	
	*/
	/*
	�� �� ֵ��-1��������������
	0���������޿�
	1������ǰ���п�
	2���������п�
	3����������п�

	*/

}

extern "C" __declspec(dllexport) int __stdcall EnableEntry(char *msg)
{

	if(handle!=NULL)
	{
		int ret=M100_EnterCardUntime(handle,0x35);//ֻ����ſ�����
		if(ret==0)
		{
			char message[] = "�ɹ�";
				strcpy(msg,message);
			return 0;

		}
		else
		{
			char message[] = "ʧ��";
				strcpy(msg,message);
			return -1;

		}
	}

	char message[] = "�豸���������";
		strcpy(msg,message);
	return -2;
	/*
	�� �� ֵ��0 �C �ɹ�
	��0 - ʧ��
	*/

}

extern "C" __declspec(dllexport) int __stdcall DisableEntry(char *msg)
{

	if(handle!=NULL)
	{
		//BYTE *vercode;
		int ret=M100_EnterCard(handle,0x33,1);
		if(ret==0)
		{
			char message[] = "�ɹ�";
			strcpy(msg,message);
			return 0;

		}
		else
		{
			char message[] = "ʧ��";
			strcpy(msg,message);
			return -1;

		}
	}

	char message[] = "�豸���������";
		strcpy(msg,message);
	return -2;
	/*
	�� �� ֵ��0 �C �ɹ�
	��0 - ʧ��
	*/

}

extern "C" __declspec(dllexport) int __stdcall EjectCard(char *msg)
{

	if(handle!=NULL)
	{
		int ret=M100_MoveCard(handle,0x34);
		if(ret==0)
		{
			char message[] = "�ɹ�";
			strcpy(msg,message);
			return 0;

		}
		else
		{
			char message[] = "ʧ��";
			strcpy(msg,message);
			return -1;

		}
	}

	char message[] = "�豸���������";
		strcpy(msg,message);
	return -2;
	/*
	�� �� ֵ��0 �C �ɹ�
	��0 - ʧ��
	*/

}


extern "C" __declspec(dllexport) int __stdcall CaptureCard(char *msg)
{

	if(handle!=NULL)
	{
		int ret=M100_MoveCard(handle,0x35);
		if(ret==0)
		{
			char message[] = "�ɹ�";
			strcpy(msg,message);
			return 0;
		}
		else
		{
			char message[] = "ʧ��";
			strcpy(msg,message);
			return -1;

		}
	}

	char message[] = "�豸���������";
		strcpy(msg,message);
	return -2;
	/*
	�� �� ֵ��0 �C �ɹ�
	��0 - ʧ��
	*/

}

extern "C" __declspec(dllexport) int __stdcall ReadTracks(char *Track1, char *Track2, char* Track3,char *msg)
{

	if(handle!=NULL)
	{
		BYTE data[1024];
		memset(data,0,sizeof(data));
		DWORD dwLength=0;
		//M100_ReadMagcardUNDecode
		int ret=M100_ReadMagcardDecode(handle,0x36,&dwLength,data);
		if(ret==0)
		{
			int begin=0;

			if(data[0]==0x60&&data[1]>0)
			{
                memcpy(Track1,data+6,data[1]);
				begin+=data[1];
			}
			if(data[2]==0x60&&data[3]>0)
			{
				memcpy(Track2,data+6+begin,data[3]);
				begin+=data[3];
			}

			if(data[4]==0x60&&data[5]>0)
			{
				memcpy(Track3,data+6+begin,data[5]);
			}
			
			/*			CString strMsg;			CString strTemp;			for(int i=0;i<dwLength;i++)			{				strTemp.Format(_T("0x%2.2X "),(BYTE)data[i]);				strMsg += strTemp;			}
            strcpy(msg,strMsg);

			memcpy(msg,data+6,10);
			*/
			char message[] = "�ɹ�";
			strcpy(msg,message);
			return 0;
			
		}
		else
		{
			char message[] = "ʧ��";
			strcpy(msg,message);
			return ret;
		}
	}

	char message[] = "�豸���������";
	strcpy(msg,message);
	return -2;
	/*
	�� �� ֵ��0 �C �ɹ�
	��0 - ʧ��
	*/

}








 




// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� TTCardReaderV2.h
CTTCardReaderV2::CTTCardReaderV2()
{
	return;
}
