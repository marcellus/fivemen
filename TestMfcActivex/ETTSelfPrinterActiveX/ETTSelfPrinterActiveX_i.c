

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:35:34 2011
 */
/* Compiler settings for .\ETTSelfPrinterActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTSelfPrinterActiveXLib,0xAD83D01E,0x7CCF,0x496D,0xBD,0x99,0x12,0x1A,0xA5,0xBC,0xDE,0x85);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfPrinterActiveX,0xD30B98E7,0xF1BB,0x402D,0x8E,0x60,0x6D,0x7F,0xAD,0x93,0xF6,0x28);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfPrinterActiveXEvents,0x889818F0,0x7383,0x4B13,0xA1,0x50,0x6E,0x77,0x72,0x78,0xAB,0xBC);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTSelfPrinterActiveX,0x4F193682,0x5451,0x4CD5,0x83,0x40,0x63,0xDD,0x04,0xD2,0xFA,0xD9);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



