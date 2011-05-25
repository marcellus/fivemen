

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri May 13 15:27:33 2011
 */
/* Compiler settings for .\ETTA8IDCardActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_ETTA8IDCardActiveXLib,0x62CCCF45,0x8C94,0x4650,0xA0,0xB2,0xB4,0x81,0x5F,0x49,0x1E,0x07);


MIDL_DEFINE_GUID(IID, DIID__DETTA8IDCardActiveX,0xA3041BBA,0x5CA8,0x4D06,0x8F,0x7F,0x9F,0x26,0x9F,0xD0,0x79,0x53);


MIDL_DEFINE_GUID(IID, DIID__DETTA8IDCardActiveXEvents,0x9458A5D9,0xFD14,0x4776,0x88,0x71,0x31,0x06,0x07,0x96,0xBB,0x47);


MIDL_DEFINE_GUID(CLSID, CLSID_ETTA8IDCardActiveX,0xC504828D,0xBB8D,0x4D2F,0xAA,0x5C,0x7E,0xD3,0x79,0x7A,0x8C,0xA2);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



