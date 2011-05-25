

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:34:25 2011
 */
/* Compiler settings for .\ETTPrinter.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, LIBID_ETTPrinterLib,0x89C1FE4C,0x0CCE,0x4F7F,0xA8,0xF4,0x30,0x4F,0x00,0x40,0x74,0x57);


MIDL_DEFINE_GUID(IID, DIID__DETTPrinter,0x2F34318A,0x00C9,0x4BA3,0xA1,0x3B,0xE3,0xC8,0x92,0x39,0xE8,0x15);


MIDL_DEFINE_GUID(IID, DIID__DETTPrinterEvents,0xB964845C,0xBDE0,0x46E8,0xA5,0xC1,0x07,0x1D,0x57,0x02,0x9D,0x4F);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTPrinter,0x08A5FF49,0x503B,0x4518,0x80,0x16,0x87,0xF4,0xAF,0x50,0xD7,0xA1);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



