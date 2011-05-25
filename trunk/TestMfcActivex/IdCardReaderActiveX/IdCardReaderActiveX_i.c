

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:10:47 2011
 */
/* Compiler settings for .\IdCardReaderActiveX.idl:
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

MIDL_DEFINE_GUID(IID, LIBID_IdCardReaderActiveXLib,0x9A8805FE,0x745A,0x4C1C,0x93,0xCD,0x84,0xA2,0xFE,0x11,0x31,0x5B);


MIDL_DEFINE_GUID(IID, DIID__DIdCardReaderActiveX,0x51F544AC,0x51EB,0x4BDC,0xBC,0xF9,0xBC,0x57,0x15,0x3A,0x95,0xBB);


MIDL_DEFINE_GUID(IID, DIID__DIdCardReaderActiveXEvents,0xEDCD5E37,0x21B4,0x4900,0x83,0xB9,0x6A,0xED,0xD9,0x21,0x87,0xD4);


MIDL_DEFINE_GUID(CLSID, CLSID_IdCardReaderActiveX,0xD25DB37E,0x0478,0x408C,0x95,0xCA,0x1E,0x63,0x0A,0x88,0xCA,0xBF);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



