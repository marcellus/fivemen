

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue Apr 26 15:14:07 2011
 */
/* Compiler settings for .\ETTEpsonPrinterActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTEpsonPrinterActiveXLib,0x67A95709,0xA323,0x46F2,0x9C,0x64,0x72,0xAA,0xBC,0xD7,0x59,0x3F);


MIDL_DEFINE_GUID(IID, DIID__DETTEpsonPrinterActiveX,0x0B6C5706,0xC674,0x4856,0xA3,0x42,0x84,0x5A,0x5E,0x1F,0xE5,0x5A);


MIDL_DEFINE_GUID(IID, DIID__DETTEpsonPrinterActiveXEvents,0x7BD881A4,0x9BCF,0x4F89,0x8B,0xCF,0x09,0x5D,0x16,0x0F,0x28,0x01);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTEpsonPrinterActiveX,0x55F3EC13,0x28AB,0x469E,0x98,0xDE,0x82,0xE8,0x62,0x70,0x3F,0xC0);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



