

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:38:48 2011
 */
/* Compiler settings for .\ETTTTReaderActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTTTReaderActiveXLib,0x4FCC45AD,0xFA58,0x4530,0xBD,0xAD,0x92,0x4A,0xE9,0xB9,0x9A,0xDE);


MIDL_DEFINE_GUID(IID, DIID__DETTTTReaderActiveX,0x1E9465C2,0x56F8,0x444B,0x80,0x77,0x78,0x3C,0x42,0x61,0x47,0xB7);


MIDL_DEFINE_GUID(IID, DIID__DETTTTReaderActiveXEvents,0x865397F5,0x6B68,0x4F40,0x9F,0xE6,0xCD,0xB5,0xF0,0x6D,0xB5,0x15);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTTTReaderActiveX,0x959B27CC,0x94E2,0x416E,0x96,0x35,0xC7,0x1B,0x76,0xB0,0xA1,0x3E);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



