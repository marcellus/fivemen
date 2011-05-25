

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:35:34 2011
 */
/* Compiler settings for .\ETTSelfUSBVideoActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTSelfUSBVideoActiveXLib,0x71885BFD,0xDA30,0x4D7D,0xB0,0xAA,0x34,0xA9,0x97,0xB7,0xAB,0xB5);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfUSBVideoActiveX,0x922573C6,0x1BED,0x4891,0xB7,0xB1,0x01,0x39,0x05,0x37,0x57,0x63);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfUSBVideoActiveXEvents,0x5055CF7F,0x7352,0x4ECF,0xBA,0xF3,0x91,0x83,0xFF,0x65,0x28,0x1E);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTSelfUSBVideoActiveX,0x07970878,0x4C36,0x470C,0xAC,0xDC,0x9A,0xB3,0x6F,0xA2,0x08,0x4B);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



