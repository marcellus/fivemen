

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Sep 15 13:49:58 2011
 */
/* Compiler settings for .\TestAltActivex.idl:
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

MIDL_DEFINE_GUID(IID, IID_IActiveXCash,0xCE8A8E2F,0x2AF9,0x426E,0x88,0x89,0xA3,0x54,0x4B,0x3A,0x76,0xCC);


MIDL_DEFINE_GUID(IID, IID_IActiveXLed,0x9E1F7326,0xFDCD,0x43A8,0x80,0xE8,0x89,0x3B,0x38,0x15,0xEB,0xB3);


MIDL_DEFINE_GUID(IID, LIBID_TestAltActivexLib,0xA38DED42,0x4485,0x4338,0xB6,0x77,0xDA,0x08,0xA5,0x1B,0xDE,0x54);


MIDL_DEFINE_GUID(IID, DIID__IActiveXCashEvents,0xAA1BA7F4,0xECB8,0x49E2,0x9D,0x0F,0x14,0xCB,0x53,0x90,0xAD,0x84);


MIDL_DEFINE_GUID(CLSID, CLSID_ActiveXCash,0xB1AFEE5C,0x8485,0x41EE,0xA9,0x08,0x3E,0xCB,0xA5,0xBD,0x59,0xBA);


MIDL_DEFINE_GUID(IID, DIID__IActiveXLedEvents,0x75EC52EC,0x448C,0x4AFD,0xAC,0xB7,0xDA,0xD6,0xA8,0x90,0xB2,0xD3);


MIDL_DEFINE_GUID(CLSID, CLSID_ActiveXLed,0xC60846B6,0xBAC0,0x47E1,0xB3,0x91,0xEC,0x5D,0x5A,0xD7,0xBD,0x1A);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



