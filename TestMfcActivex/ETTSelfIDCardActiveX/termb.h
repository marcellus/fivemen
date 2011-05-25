#include <windows.h>
#include <stdio.h>
#include <time.h>

int pass_port=1;
HANDLE hDevice;
bool bIFDReady=0;
DWORD Read_Time=3000;
DWORD Auth_Time=3000;

#define OK 1
#define CreatComE -1
#define SetComE -2
#define SendE -3
#define OverInit -4
#define PhotoE -5
#define OverClose -6
#define ReceiveE -7
#define HandE -8
#define NO_Operation -11

#define TERMB_API __declspec(dllexport)

extern TERMB_API int PASCAL InitComm(int port);
extern TERMB_API int PASCAL CloseComm();
extern TERMB_API int PASCAL Authenticate();
extern TERMB_API int PASCAL Read_Content(int active);