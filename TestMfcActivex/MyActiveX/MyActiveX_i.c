

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:10:39 2011
 */
/* Compiler settings for .\MyActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_MyActiveXLib,0xA5B3C774,0xD499,0x4DBF,0xBC,0x04,0x3D,0x23,0xB9,0x71,0x43,0x0F);


MIDL_DEFINE_GUID(IID, DIID__DMyActiveX,0x8CE1671B,0xAA29,0x4130,0x85,0x4B,0x61,0x3A,0x39,0xA8,0x22,0x98);


MIDL_DEFINE_GUID(IID, DIID__DMyActiveXEvents,0xABCE71F8,0xC8D6,0x4B80,0xB2,0x4C,0x00,0x73,0xD6,0x3C,0x1C,0xAE);


MIDL_DEFINE_GUID(CLSID, CLSID_MyActiveX,0x3978BB54,0xFC56,0x4784,0x9A,0x6B,0xE8,0x80,0xC8,0xE7,0x1B,0x41);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



