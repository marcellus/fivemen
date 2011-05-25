// TTCardReader.cpp : 定义 DLL 的初始化例程。
//

#include "stdafx.h"
#include "M100_DLL.h"
#include <stdio.h>
#include "TestClass.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#pragma   comment(lib,"M100_DLL.lib")   


static HANDLE handle;

int OpenDevice(int port)
{
   
   char com[7]; 
   sprintf(com,"com%d",port);
   handle=M100_CommOpen(com);
   return handle==0?0:-1;
}
