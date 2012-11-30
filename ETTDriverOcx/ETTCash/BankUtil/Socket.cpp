// Socket.cpp: implementation of the CSocket class.
//
/**///////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Socket.h"
#include <assert.h>

/**///////////////////////////////////////////////////////////////////////
// Construction/Destruction
/**///////////////////////////////////////////////////////////////////////
//����
CSocket::CSocket()
{
	m_hSocket = INVALID_SOCKET;
}
//����
CSocket::~CSocket()
{
	Close();
}

BOOL CSocket::InitSocket()
{
#ifdef _WIN32
	WSAData wsaData;
	int err =WSAStartup(0x0202,&wsaData);
	if ( err != 0 )                           
		return FALSE;
	if ( LOBYTE( wsaData.wVersion ) != 2 ||HIBYTE( wsaData.wVersion ) != 2 )
	{
		WSACleanup( );
		return FALSE; 
	}
#endif
    //�����׽���   
    m_hSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);    
    if(INVALID_SOCKET == m_hSocket)  
    {  
        WSACleanup();//�ͷ��׽�����Դ   
        return  FALSE;  
    }  

	return TRUE;
}

/**//**********************************************************************/
//1.�����׽���
BOOL CSocket::Create( UINT nSocketPort, int nSocketType ,LPCTSTR lpszSocketAddress )
{
	assert(m_hSocket == INVALID_SOCKET);//�׽��ֱ������ȳ�ʼ��Ϊ��
	m_hSocket = socket(AF_INET,nSocketType,IPPROTO_IP);//Ȼ���ٴ���
	if(    m_hSocket == INVALID_SOCKET)
		return FALSE;

	sockaddr_in addr = {AF_INET,htons(nSocketPort)};
	if (!lpszSocketAddress) //����û���ָ������ϵͳ����
		addr.sin_addr.s_addr = htonl(INADDR_ANY);
	else
		addr.sin_addr.s_addr = inet_addr(lpszSocketAddress);

	if (!bind(m_hSocket,(sockaddr*)&addr,sizeof(addr)))
		return TRUE;//If no error occurs, bind returns zero
	Close();

	return FALSE;
}

//2.���ͣ����UDP��
int CSocket::SendTo( const void* lpBuf, int nBufLen, UINT nHostPort, LPCSTR lpszHostAddress , int nFlags)
{
	sockaddr_in addr = {AF_INET,htons(nHostPort),};
	assert(lpszHostAddress);//UDP ����ָ��Ŀ�ĵ�ַ
	addr.sin_addr.s_addr = inet_addr(lpszHostAddress);
	return sendto(m_hSocket,(char*)lpBuf,nBufLen,nFlags,(sockaddr*)&addr,sizeof(addr));
}

//3.���գ����UDP��
int CSocket::ReceiveFrom( void* lpBuf, int nBufLen, char *rSocketAddress, UINT& rSocketPort, int nFlags )
{
	sockaddr_in from;//������һ����ʱ�����������ڴ棬������Ϣ��
	socklen_t fromlen = sizeof(from);//Ȼ����ܼ����ڴ泤��

	int nRet = recvfrom(m_hSocket,(LPSTR)lpBuf,nBufLen,nFlags,(sockaddr*)&from,&fromlen);
	if(nRet <= 0)
		return nRet;
	if(rSocketAddress)
	{
		strcpy(rSocketAddress,inet_ntoa(from.sin_addr));//out
		rSocketPort = htons(from.sin_port);//out
	}

	return nRet;
}

//4.��������(���TCP)
BOOL CSocket::Accept( CSocket& rConnectedSocket, LPSTR lpSockAddr ,UINT *nPort )
{
	sockaddr_in addr = {AF_INET};
	socklen_t nLen = sizeof(addr);
	rConnectedSocket.m_hSocket = accept(m_hSocket,(sockaddr*)&addr,&nLen);
	if(rConnectedSocket.m_hSocket == INVALID_SOCKET)
		return FALSE;
	if(lpSockAddr)
	{
		strcpy(lpSockAddr,inet_ntoa(addr.sin_addr));
		*nPort = htons(addr.sin_port);
	}
	return TRUE;    
}

//5.��������(���TCP)
BOOL CSocket::Connect( LPCTSTR lpszHostAddress, UINT nHostPort )
{
	sockaddr_in addr = {AF_INET,htons(nHostPort)};
	addr.sin_addr.s_addr = inet_addr(lpszHostAddress);
	if (addr.sin_addr.s_addr == INADDR_NONE)//�������޹㲥��ַ�����ñ�����ַ֮һ
	{
		hostent * lphost = gethostbyname(lpszHostAddress);
		if (lphost != NULL)
			addr.sin_addr.s_addr = ((LPIN_ADDR)lphost->h_addr)->s_addr;
		else
		{
			//WSAGetLastError();
			//WSASetLastError(WSAEINVAL);
			return FALSE;
		}
	}
	return !connect(m_hSocket,(sockaddr*)&addr,sizeof(addr));
}

//6.�õ������׽��֣�IP��Port
BOOL CSocket::GetSockName( char*  rSocketAddress, UINT& rSocketPort )
{
	sockaddr_in addr;
	socklen_t nLen = sizeof(addr);

	if(SOCKET_ERROR == getsockname(m_hSocket, (sockaddr*)&addr, &nLen))
		return FALSE;
	if(rSocketAddress)
	{
		strcpy(rSocketAddress,inet_ntoa(addr.sin_addr));
		rSocketPort = htons(addr.sin_port);
	}
	return TRUE;
}

//7.�õ��Է��׽������֣�IP��Port
BOOL CSocket::GetPeerName(  char* rPeerAddress, UINT& rPeerPort )
{
	sockaddr_in addr;
	socklen_t nLen = sizeof(addr);

	if(SOCKET_ERROR == getpeername(m_hSocket, (sockaddr*)&addr, &nLen))
		return FALSE;
	if(rPeerAddress)
	{
		strcpy(rPeerAddress,inet_ntoa(addr.sin_addr));
		rPeerPort = htons(addr.sin_port);
	}
	return TRUE;
}