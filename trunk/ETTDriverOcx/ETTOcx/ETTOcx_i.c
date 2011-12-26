

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Wed Nov 02 13:08:31 2011
 */
/* Compiler settings for .\ETTOcx.idl:
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

MIDL_DEFINE_GUID(IID, IID_IVoiceObj,0xFE7A7E9E,0xD0F6,0x4EBD,0xAD,0xC8,0x28,0xCE,0x42,0x6F,0xBC,0x0F);


MIDL_DEFINE_GUID(IID, IID_IUnionPay,0xBC9A1E58,0x3DD2,0x4A08,0x8B,0x70,0x7E,0xEE,0x5E,0x77,0xD7,0xF0);


MIDL_DEFINE_GUID(IID, LIBID_ETTOcxLib,0x636647B2,0x2881,0x4DB4,0xB4,0xD3,0x90,0x2A,0x3F,0x7D,0xF1,0x19);


MIDL_DEFINE_GUID(IID, DIID__IVoiceObjEvents,0x8AFFD310,0x5388,0x40DD,0xA5,0xA2,0x1C,0xC4,0x96,0xB1,0x36,0xED);


MIDL_DEFINE_GUID(CLSID, CLSID_VoiceObj,0xD5B19295,0x2DDF,0x406C,0x88,0xEB,0xD6,0x44,0xAD,0x73,0xBD,0xCB);


MIDL_DEFINE_GUID(IID, DIID__IUnionPayEvents,0xD4C0F2D9,0x9D95,0x4A26,0x84,0xBD,0x34,0x0E,0x6B,0xE6,0x4F,0xB2);


MIDL_DEFINE_GUID(CLSID, CLSID_UnionPay,0xE4A6877E,0x30EA,0x4915,0xBB,0x27,0xAC,0x8D,0x70,0xFB,0x27,0xCB);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



