

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:10:17 2011
 */
/* Compiler settings for .\IDCardActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_IDCardActiveXLib,0x5D8BBCC4,0x5AF8,0x4A1E,0x88,0xE5,0x21,0x3C,0xD0,0x68,0x5E,0xCC);


MIDL_DEFINE_GUID(IID, DIID__DIDCardActiveX,0xCE963D6C,0xDA9E,0x4E6F,0xAE,0xAC,0x7F,0x27,0xF1,0x24,0x8D,0xE1);


MIDL_DEFINE_GUID(IID, DIID__DIDCardActiveXEvents,0xF356B5E6,0x5D6A,0x4691,0xA5,0x2C,0x87,0xB5,0x23,0xF6,0x01,0x73);


MIDL_DEFINE_GUID(CLSID, CLSID_IDCardActiveX,0xFD63286F,0x7A4F,0x4C01,0x96,0x05,0x21,0x63,0xC1,0xED,0x11,0x90);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



