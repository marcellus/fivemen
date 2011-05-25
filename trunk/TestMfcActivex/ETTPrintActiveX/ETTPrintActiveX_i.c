

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:09:36 2011
 */
/* Compiler settings for .\ETTPrintActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTPrintActiveXLib,0x29D07778,0x0ECD,0x40A6,0xA7,0x99,0x5B,0x9A,0xCE,0xBD,0x10,0x39);


MIDL_DEFINE_GUID(IID, DIID__DETTPrintActiveX,0xA94C9160,0x7DD0,0x4C29,0xA4,0x70,0x1B,0x21,0x8E,0x38,0x8B,0x0C);


MIDL_DEFINE_GUID(IID, DIID__DETTPrintActiveXEvents,0x3F019042,0xB4D1,0x4BA1,0xAF,0x88,0x74,0xB8,0xB5,0x61,0x72,0xDF);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTPrintActiveX,0x07F2485D,0x2A40,0x44B2,0x90,0x00,0x04,0xF9,0x2E,0xB8,0xF9,0x6A);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



