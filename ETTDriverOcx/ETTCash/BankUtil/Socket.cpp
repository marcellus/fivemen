// Socket.cpp: implementation of the CSocket class.
//
/**///////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Socket.h"
#include <assert.h>

/**///////////////////////////////////////////////////////////////////////
// Construction/Destruction
/**///////////////////////////////////////////////////////////////////////
//构造
CSocket::CSocket()
{
	m_hSocket = INVALID_SOCKET;
}
//析构
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
    //创建套接字   
    m_hSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);    
    if(INVALID_SOCKET == m_hSocket)  
    {  
        WSACleanup();//释放套接字资源   
        return  FALSE;  
    }  

	return TRUE;
}

/**//**********************************************************************/
//1.创建套接字
BOOL CSocket::Create( UINT nSocketPort, int nSocketType ,LPCTSTR lpszSocketAddress )
{
	assert(m_hSocket == INVALID_SOCKET);//套接字必须首先初始化为空
	m_hSocket = socket(AF_INET,nSocketType,IPPROTO_IP);//然后再创建
	if(    m_hSocket == INVALID_SOCKET)
		return FALSE;

	sockaddr_in addr = {AF_INET,htons(nSocketPort)};
	if (!lpszSocketAddress) //如果用户不指定，则系统分配
		addr.sin_addr.s_addr = htonl(INADDR_ANY);
	else
		addr.sin_addr.s_addr = inet_addr(lpszSocketAddress);

	if (!bind(m_hSocket,(sockaddr*)&addr,sizeof(addr)))
		return TRUE;//If no error occurs, bind returns zero
	Close();

	return FALSE;
}

//2.发送（针对UDP）
int CSocket::SendTo( const void* lpBuf, int nBufLen, UINT nHostPort, LPCSTR lpszHostAddress , int nFlags)
{
	sockaddr_in addr = {AF_INET,htons(nHostPort),};
	assert(lpszHostAddress);//UDP 必须指定目的地址
	addr.sin_addr.s_addr = inet_addr(lpszHostAddress);
	return sendto(m_hSocket,(char*)lpBuf,nBufLen,nFlags,(sockaddr*)&addr,sizeof(addr));
}

//3.接收（针对UDP）
int CSocket::ReceiveFrom( void* lpBuf, int nBufLen, char *rSocketAddress, UINT& rSocketPort, int nFlags )
{
	sockaddr_in from;//必须设一个临时变量，分配内存，接收信息。
	socklen_t fromlen = sizeof(from);//然后才能计算内存长度

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

//4.接受请求(针对TCP)
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

//5.请求连接(针对TCP)
BOOL CSocket::Connect( LPCTSTR lpszHostAddress, UINT nHostPort )
{
	sockaddr_in addr = {AF_INET,htons(nHostPort)};
	addr.sin_addr.s_addr = inet_addr(lpszHostAddress);
	if (addr.sin_addr.s_addr == INADDR_NONE)//若是有限广播地址，则用本机地址之一
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

//6.得到本机套接字：IP：Port
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

//7.得到对方套接字名字：IP：Port
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