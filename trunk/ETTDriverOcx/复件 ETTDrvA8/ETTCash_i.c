

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Wed Sep 14 16:13:47 2011
 */
/* Compiler settings for .\ETTCash.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTCashLib,0x62C88F93,0x09EF,0x4584,0xA3,0x8C,0x6E,0xDA,0x8F,0x31,0x1D,0xF9);


MIDL_DEFINE_GUID(IID, DIID__DETTCash,0xE7830902,0xFE6B,0x4AC0,0x8E,0x15,0xE9,0x71,0x2F,0x29,0x97,0xF4);


MIDL_DEFINE_GUID(IID, DIID__DETTCashEvents,0x1A65DFCC,0x6BD4,0x4493,0x8F,0x77,0x6B,0x6D,0x6F,0x44,0x39,0x28);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTCash,0xEC8BC46B,0x0405,0x47CA,0xB5,0x23,0x3C,0x40,0x9F,0xCE,0x78,0xE2);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



