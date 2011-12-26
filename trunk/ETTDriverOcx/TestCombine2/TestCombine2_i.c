

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Sep 15 11:14:25 2011
 */
/* Compiler settings for .\TestCombine2.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_TestCombine2Lib,0xECEEA569,0xFF80,0x4618,0xA2,0x6B,0xF5,0x41,0xAF,0x0B,0x96,0x33);


MIDL_DEFINE_GUID(IID, DIID__DTestCombine2,0x7265DE52,0xFDE8,0x44C9,0xB6,0xAA,0xAD,0xA3,0x41,0xAE,0x33,0x38);


MIDL_DEFINE_GUID(IID, DIID__DTestCombine2Events,0x4757EEFE,0x940C,0x4C06,0xBA,0x0D,0xB6,0x54,0x50,0x0E,0x39,0xE7);


MIDL_DEFINE_GUID(CLSID, CLSID_TestCombine2,0xEECAE990,0x8734,0x4964,0xBB,0xC5,0x30,0x05,0x25,0xE9,0x36,0x2C);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



