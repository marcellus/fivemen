

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:37:33 2011
 */
/* Compiler settings for .\ETTSelfHotPrinterActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTSelfHotPrinterActiveXLib,0x831D9190,0x4CF1,0x401A,0x87,0x43,0x16,0x8C,0x81,0xE6,0xD2,0x4D);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfHotPrinterActiveX,0x4FE5156D,0x091B,0x4A4B,0x98,0xA0,0xE9,0x85,0x66,0x22,0xD7,0xD5);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfHotPrinterActiveXEvents,0xBBBBCF47,0xF600,0x4371,0x8D,0xD3,0x36,0x41,0xC9,0xDA,0x18,0x2E);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTSelfHotPrinterActiveX,0xCADA7DA3,0x25C6,0x43E6,0xB5,0xC5,0x7A,0x5E,0x94,0x9A,0x52,0x96);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



