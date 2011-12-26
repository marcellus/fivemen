

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Sep 15 10:20:34 2011
 */
/* Compiler settings for .\TestCombineActive.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_TestCombineActiveLib,0x0A351C60,0xBA5F,0x4CD4,0x9C,0x80,0x60,0x10,0x81,0xEE,0x58,0x7C);


MIDL_DEFINE_GUID(IID, DIID__DTestCombineActive,0xC761E55F,0xDED9,0x41BD,0xB4,0x46,0x22,0x36,0x5F,0x85,0x1E,0x1A);


MIDL_DEFINE_GUID(IID, DIID__DTestCombineActiveEvents,0x1C0CB663,0xD6DC,0x4AED,0xB3,0xE4,0xF0,0x8B,0xE4,0x3B,0x7B,0x45);


MIDL_DEFINE_GUID(CLSID, CLSID_TestCombineActive,0x8128503E,0x4D53,0x4B22,0xAB,0xB3,0x88,0xA2,0x8C,0x89,0x91,0xA1);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



