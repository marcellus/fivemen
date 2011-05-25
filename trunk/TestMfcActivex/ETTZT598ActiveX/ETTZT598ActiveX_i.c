

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:36:53 2011
 */
/* Compiler settings for .\ETTZT598ActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTZT598ActiveXLib,0x7D7D0822,0xE349,0x4A21,0x8E,0xE6,0xF3,0x96,0xF2,0x83,0xEA,0x5F);


MIDL_DEFINE_GUID(IID, DIID__DETTZT598ActiveX,0x6385D7D9,0x75CC,0x4D58,0x89,0x87,0x47,0xA9,0x6A,0x6A,0xCF,0xBF);


MIDL_DEFINE_GUID(IID, DIID__DETTZT598ActiveXEvents,0xCF16CA5E,0xC839,0x49D9,0x95,0xE4,0x8F,0xF3,0x72,0x44,0x5C,0x6C);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTZT598ActiveX,0x233B327E,0x114D,0x4AFF,0x8F,0x70,0x42,0x7B,0xCA,0x74,0x7D,0x2C);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



