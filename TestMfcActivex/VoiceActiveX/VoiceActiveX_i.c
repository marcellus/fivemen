

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:39:03 2011
 */
/* Compiler settings for .\VoiceActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_VoiceActiveXLib,0x66299FE8,0xDFC5,0x47AB,0xB2,0x25,0xE8,0x0D,0xA6,0x41,0x29,0x35);


MIDL_DEFINE_GUID(IID, DIID__DVoiceActiveX,0xD1742149,0x26BE,0x4081,0xAA,0x2A,0x05,0x35,0xAC,0x92,0xF9,0x71);


MIDL_DEFINE_GUID(IID, DIID__DVoiceActiveXEvents,0x4D3FD060,0x59E1,0x4CF3,0x9B,0x46,0x9F,0xFC,0xFE,0x48,0x94,0x60);


MIDL_DEFINE_GUID(CLSID, CLSID_VoiceActiveX,0x3BE2B9A6,0xA746,0x40AE,0xA5,0x4E,0x70,0x5E,0xFB,0x3C,0x98,0xE2);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



