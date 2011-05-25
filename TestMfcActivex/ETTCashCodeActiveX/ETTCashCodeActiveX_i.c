

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Wed May 11 13:26:59 2011
 */
/* Compiler settings for .\ETTCashCodeActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTCashCodeActiveXLib,0x5971B212,0x780E,0x4853,0x8F,0xF4,0x3D,0x7B,0xA6,0x76,0xAC,0xC8);


MIDL_DEFINE_GUID(IID, DIID__DETTCashCodeActiveX,0xD7039AD9,0x7364,0x4E65,0xBB,0xA3,0x9C,0xE8,0xDF,0x60,0xE9,0x87);


MIDL_DEFINE_GUID(IID, DIID__DETTCashCodeActiveXEvents,0x3727E203,0xB8F8,0x40A9,0xA0,0xA5,0xE2,0x68,0x0A,0xF6,0xA1,0xC2);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTCashCodeActiveX,0x5A797850,0xBE8E,0x4939,0x8F,0x6D,0xD9,0x39,0x7B,0x96,0x37,0x65);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



