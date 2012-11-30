// Socket.h: interface for the CSocket class.
//
/**///////////////////////////////////////////////////////////////////////

#if !defined(AFX_SOCKET_H__0C5B01C7_CACD_44E5_AB92_130605BBD66B__INCLUDED_)
#define AFX_SOCKET_H__0C5B01C7_CACD_44E5_AB92_130605BBD66B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifdef _WIN32
#include <WinSock2.h>
typedef int socklen_t ;
#else
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <arpa/inet.h>

#include <unistd.h>
#include <errno.h>
#include <sys/stat.h>
#include <string.h>
#include <netdb.h>
#ifndef CONST
#define CONST               const
#endif

typedef unsigned char   u_char;
typedef unsigned short  u_short;
typedef unsigned int    u_int;
typedef unsigned long   u_long;
typedef u_int           SOCKET;

typedef int                 INT;
typedef unsigned int        UINT;
typedef unsigned int        *PUINT;
typedef unsigned long       DWORD;
typedef int                 BOOL;
typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef float               FLOAT;
typedef FLOAT               *PFLOAT;
typedef BOOL            *PBOOL;
typedef BOOL             *LPBOOL;
typedef BYTE            *PBYTE;
typedef BYTE             *LPBYTE;
typedef int             *PINT;
typedef int              *LPINT;
typedef WORD            *PWORD;
typedef WORD             *LPWORD;
typedef long             *LPLONG;
typedef DWORD           *PDWORD;
typedef DWORD            *LPDWORD;
typedef void             *LPVOID;
typedef CONST void       *LPCVOID;

#ifndef _TCHAR_DEFINED
typedef char TCHAR, *PTCHAR;
typedef unsigned char TBYTE , *PTBYTE ;
#define _TCHAR_DEFINED
#endif /* !_TCHAR_DEFINED */

#ifndef VOID
#define VOID void
typedef char CHAR;
typedef short SHORT;
typedef long LONG;
#endif
typedef CHAR *PCHAR;
typedef CHAR *LPCH, *PCH;

typedef CONST CHAR *LPCCH, *PCCH;
typedef CHAR *NPSTR;
typedef CHAR *LPSTR, *PSTR;
typedef CONST CHAR *LPCSTR, *PCSTR;
typedef LPSTR LPTCH, PTCH;
typedef LPSTR PTSTR, LPTSTR;
typedef LPCSTR LPCTSTR;


#ifndef FALSE
#define FALSE               0
#endif

#ifndef TRUE
#define TRUE                1
#endif

#define INVALID_SOCKET  (SOCKET)(~0)
#define SOCKET_ERROR            (-1)
typedef struct in_addr  *LPIN_ADDR;

#define closesocket(x) close(x)


#endif

class CSocket  
{
    SOCKET m_hSocket;
    
public:
    BOOL Create( UINT nSocketPort = 0, int nSocketType = SOCK_STREAM , LPCTSTR lpszSocketAddress = NULL );
    int SendTo( const void* lpBuf, int nBufLen, UINT nHostPort, LPCSTR lpszHostAddress = NULL, int nFlags = 0 );
    int ReceiveFrom( void* lpBuf, int nBufLen, char *rSocketAddress, UINT& rSocketPort, int nFlags = 0 );
    
    BOOL Listen( int nConnectionBacklog = 5 )
    {
        return !listen(m_hSocket,nConnectionBacklog);
    }
    int Send( const void* lpBuf, int nBufLen, int nFlags = 0 )
    {
        return send(m_hSocket, (LPSTR)lpBuf, nBufLen, nFlags);
    }
    int Receive( void* lpBuf, int nBufLen, int nFlags = 0 )
    {
        return recv(m_hSocket, (LPSTR)lpBuf, nBufLen, nFlags);
    }    
    void Close( )
    {
        closesocket(m_hSocket);
    }

	BOOL InitSocket();
    BOOL GetSockName( char*  rSocketAddress, UINT& rSocketPort );
    BOOL GetPeerName(  char* rPeerAddress, UINT& rPeerPort );
    BOOL Accept( CSocket& rConnectedSocket,  LPSTR lpSockAddr = NULL,UINT *nPort = NULL);
    BOOL Connect( LPCTSTR lpszHostAddress, UINT nHostPort );
        
    CSocket();
    virtual ~CSocket();
    
};

#endif // !defined(AFX_SOCKET_H__0C5B01C7_CACD_44E5_AB92_130605BBD66B__INCLUDED_)