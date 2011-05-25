

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:11:13 2011
 */
/* Compiler settings for .\TestMfcActivex.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_TestMfcActivexLib,0x9D788FCF,0xE42C,0x4FED,0xAB,0x59,0x88,0x53,0x23,0xDA,0xEE,0x73);


MIDL_DEFINE_GUID(IID, DIID__DTestMfcActivex,0x8BB622EB,0x3854,0x4B1E,0xB9,0x75,0x1F,0x75,0xBE,0xAD,0x42,0xF5);


MIDL_DEFINE_GUID(IID, DIID__DTestMfcActivexEvents,0xD8505EB0,0x1BCD,0x4E2F,0x91,0xAD,0x11,0x5E,0xF4,0xCF,0xAE,0xF8);


MIDL_DEFINE_GUID(CLSID, CLSID_TestMfcActivex,0xE5DF618A,0xE0CC,0x4F68,0xAC,0xB2,0x15,0x5A,0x1D,0x3B,0xAF,0xCA);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



