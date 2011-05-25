

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:36:39 2011
 */
/* Compiler settings for .\ETTSelfIDCardActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTSelfIDCardActiveXLib,0xFD5A8311,0x18FF,0x4AF7,0x80,0x56,0xB1,0xD6,0x5A,0x41,0x1D,0xEA);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfIDCardActiveX,0xBC755F0E,0x4F1C,0x46A2,0x8C,0x10,0x97,0xE3,0x64,0x97,0x48,0x65);


MIDL_DEFINE_GUID(IID, DIID__DETTSelfIDCardActiveXEvents,0x097A9E85,0xC96F,0x4B0F,0xB4,0x94,0x8D,0x90,0x6D,0x13,0xE2,0xEB);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTSelfIDCardActiveX,0x447C4906,0x6678,0x461B,0x9E,0x20,0x10,0x0B,0xDE,0x91,0x38,0x28);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



