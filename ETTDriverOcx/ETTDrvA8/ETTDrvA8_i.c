

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Nov 01 15:50:08 2012
 */
/* Compiler settings for .\ETTDrvA8.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTDrvA8Lib,0x5AEAF8AC,0x7C0F,0x4B73,0x96,0xC7,0x66,0x2B,0x59,0x04,0xC9,0xF8);


MIDL_DEFINE_GUID(IID, DIID__DETTDrvA8,0xFC198BC9,0x9B80,0x49AD,0xBD,0xF7,0xB5,0xEB,0x38,0xEC,0xBC,0xE4);


MIDL_DEFINE_GUID(IID, DIID__DETTDrvA8Events,0xE5780630,0xB504,0x44BE,0x8B,0x73,0xEA,0x3E,0x73,0xC1,0xD7,0x18);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTDrvA8,0xB64A8AD1,0x0B76,0x4D7B,0x92,0xA6,0xB8,0x85,0x19,0x25,0x40,0x91);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



