

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Sat Sep 17 12:40:58 2011
 */
/* Compiler settings for .\ETTSelf.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __ETTSelf_i_h__
#define __ETTSelf_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IA8_FWD_DEFINED__
#define __IA8_FWD_DEFINED__
typedef interface IA8 IA8;
#endif 	/* __IA8_FWD_DEFINED__ */


#ifndef __ICashCode_FWD_DEFINED__
#define __ICashCode_FWD_DEFINED__
typedef interface ICashCode ICashCode;
#endif 	/* __ICashCode_FWD_DEFINED__ */


#ifndef __IZT598_FWD_DEFINED__
#define __IZT598_FWD_DEFINED__
typedef interface IZT598 IZT598;
#endif 	/* __IZT598_FWD_DEFINED__ */


#ifndef __IKMYKey_FWD_DEFINED__
#define __IKMYKey_FWD_DEFINED__
typedef interface IKMYKey IKMYKey;
#endif 	/* __IKMYKey_FWD_DEFINED__ */


#ifndef __ICZCard_FWD_DEFINED__
#define __ICZCard_FWD_DEFINED__
typedef interface ICZCard ICZCard;
#endif 	/* __ICZCard_FWD_DEFINED__ */


#ifndef __ITTCard_FWD_DEFINED__
#define __ITTCard_FWD_DEFINED__
typedef interface ITTCard ITTCard;
#endif 	/* __ITTCard_FWD_DEFINED__ */


#ifndef __ITYCard_FWD_DEFINED__
#define __ITYCard_FWD_DEFINED__
typedef interface ITYCard ITYCard;
#endif 	/* __ITYCard_FWD_DEFINED__ */


#ifndef __IIdCard_FWD_DEFINED__
#define __IIdCard_FWD_DEFINED__
typedef interface IIdCard IIdCard;
#endif 	/* __IIdCard_FWD_DEFINED__ */


#ifndef __ICamera_FWD_DEFINED__
#define __ICamera_FWD_DEFINED__
typedef interface ICamera ICamera;
#endif 	/* __ICamera_FWD_DEFINED__ */


#ifndef __IDrvLed_FWD_DEFINED__
#define __IDrvLed_FWD_DEFINED__
typedef interface IDrvLed IDrvLed;
#endif 	/* __IDrvLed_FWD_DEFINED__ */


#ifndef __IPrinterEx_FWD_DEFINED__
#define __IPrinterEx_FWD_DEFINED__
typedef interface IPrinterEx IPrinterEx;
#endif 	/* __IPrinterEx_FWD_DEFINED__ */


#ifndef ___IA8Events_FWD_DEFINED__
#define ___IA8Events_FWD_DEFINED__
typedef interface _IA8Events _IA8Events;
#endif 	/* ___IA8Events_FWD_DEFINED__ */


#ifndef __A8_FWD_DEFINED__
#define __A8_FWD_DEFINED__

#ifdef __cplusplus
typedef class A8 A8;
#else
typedef struct A8 A8;
#endif /* __cplusplus */

#endif 	/* __A8_FWD_DEFINED__ */


#ifndef ___ICashCodeEvents_FWD_DEFINED__
#define ___ICashCodeEvents_FWD_DEFINED__
typedef interface _ICashCodeEvents _ICashCodeEvents;
#endif 	/* ___ICashCodeEvents_FWD_DEFINED__ */


#ifndef __CashCode_FWD_DEFINED__
#define __CashCode_FWD_DEFINED__

#ifdef __cplusplus
typedef class CashCode CashCode;
#else
typedef struct CashCode CashCode;
#endif /* __cplusplus */

#endif 	/* __CashCode_FWD_DEFINED__ */


#ifndef ___IZT598Events_FWD_DEFINED__
#define ___IZT598Events_FWD_DEFINED__
typedef interface _IZT598Events _IZT598Events;
#endif 	/* ___IZT598Events_FWD_DEFINED__ */


#ifndef __ZT598_FWD_DEFINED__
#define __ZT598_FWD_DEFINED__

#ifdef __cplusplus
typedef class ZT598 ZT598;
#else
typedef struct ZT598 ZT598;
#endif /* __cplusplus */

#endif 	/* __ZT598_FWD_DEFINED__ */


#ifndef ___IKMYKeyEvents_FWD_DEFINED__
#define ___IKMYKeyEvents_FWD_DEFINED__
typedef interface _IKMYKeyEvents _IKMYKeyEvents;
#endif 	/* ___IKMYKeyEvents_FWD_DEFINED__ */


#ifndef __KMYKey_FWD_DEFINED__
#define __KMYKey_FWD_DEFINED__

#ifdef __cplusplus
typedef class KMYKey KMYKey;
#else
typedef struct KMYKey KMYKey;
#endif /* __cplusplus */

#endif 	/* __KMYKey_FWD_DEFINED__ */


#ifndef ___ICZCardEvents_FWD_DEFINED__
#define ___ICZCardEvents_FWD_DEFINED__
typedef interface _ICZCardEvents _ICZCardEvents;
#endif 	/* ___ICZCardEvents_FWD_DEFINED__ */


#ifndef __CZCard_FWD_DEFINED__
#define __CZCard_FWD_DEFINED__

#ifdef __cplusplus
typedef class CZCard CZCard;
#else
typedef struct CZCard CZCard;
#endif /* __cplusplus */

#endif 	/* __CZCard_FWD_DEFINED__ */


#ifndef ___ITTCardEvents_FWD_DEFINED__
#define ___ITTCardEvents_FWD_DEFINED__
typedef interface _ITTCardEvents _ITTCardEvents;
#endif 	/* ___ITTCardEvents_FWD_DEFINED__ */


#ifndef __TTCard_FWD_DEFINED__
#define __TTCard_FWD_DEFINED__

#ifdef __cplusplus
typedef class TTCard TTCard;
#else
typedef struct TTCard TTCard;
#endif /* __cplusplus */

#endif 	/* __TTCard_FWD_DEFINED__ */


#ifndef ___ITYCardEvents_FWD_DEFINED__
#define ___ITYCardEvents_FWD_DEFINED__
typedef interface _ITYCardEvents _ITYCardEvents;
#endif 	/* ___ITYCardEvents_FWD_DEFINED__ */


#ifndef __TYCard_FWD_DEFINED__
#define __TYCard_FWD_DEFINED__

#ifdef __cplusplus
typedef class TYCard TYCard;
#else
typedef struct TYCard TYCard;
#endif /* __cplusplus */

#endif 	/* __TYCard_FWD_DEFINED__ */


#ifndef ___IIdCardEvents_FWD_DEFINED__
#define ___IIdCardEvents_FWD_DEFINED__
typedef interface _IIdCardEvents _IIdCardEvents;
#endif 	/* ___IIdCardEvents_FWD_DEFINED__ */


#ifndef __IdCard_FWD_DEFINED__
#define __IdCard_FWD_DEFINED__

#ifdef __cplusplus
typedef class IdCard IdCard;
#else
typedef struct IdCard IdCard;
#endif /* __cplusplus */

#endif 	/* __IdCard_FWD_DEFINED__ */


#ifndef ___ICameraEvents_FWD_DEFINED__
#define ___ICameraEvents_FWD_DEFINED__
typedef interface _ICameraEvents _ICameraEvents;
#endif 	/* ___ICameraEvents_FWD_DEFINED__ */


#ifndef __Camera_FWD_DEFINED__
#define __Camera_FWD_DEFINED__

#ifdef __cplusplus
typedef class Camera Camera;
#else
typedef struct Camera Camera;
#endif /* __cplusplus */

#endif 	/* __Camera_FWD_DEFINED__ */


#ifndef ___IDrvLedEvents_FWD_DEFINED__
#define ___IDrvLedEvents_FWD_DEFINED__
typedef interface _IDrvLedEvents _IDrvLedEvents;
#endif 	/* ___IDrvLedEvents_FWD_DEFINED__ */


#ifndef __DrvLed_FWD_DEFINED__
#define __DrvLed_FWD_DEFINED__

#ifdef __cplusplus
typedef class DrvLed DrvLed;
#else
typedef struct DrvLed DrvLed;
#endif /* __cplusplus */

#endif 	/* __DrvLed_FWD_DEFINED__ */


#ifndef ___IPrinterExEvents_FWD_DEFINED__
#define ___IPrinterExEvents_FWD_DEFINED__
typedef interface _IPrinterExEvents _IPrinterExEvents;
#endif 	/* ___IPrinterExEvents_FWD_DEFINED__ */


#ifndef __PrinterEx_FWD_DEFINED__
#define __PrinterEx_FWD_DEFINED__

#ifdef __cplusplus
typedef class PrinterEx PrinterEx;
#else
typedef struct PrinterEx PrinterEx;
#endif /* __cplusplus */

#endif 	/* __PrinterEx_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IA8_INTERFACE_DEFINED__
#define __IA8_INTERFACE_DEFINED__

/* interface IA8 */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IA8;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4379E52C-77B1-4DF3-B88D-B4D1E891F11B")
    IA8 : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Message( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Message( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_IdCardImgFileName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_IdCardImgFileName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_IdCardFrontImgFileName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_IdCardFrontImgFileName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_IdCardEndImgFileName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_IdCardEndImgFileName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_IsReaded( 
            /* [retval][out] */ SHORT *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_IsReaded( 
            /* [in] */ SHORT newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_UserName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_UserName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_SexCode( 
            /* [retval][out] */ SHORT *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_SexCode( 
            /* [in] */ SHORT newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_SexName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_SexName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_NationCode( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_NationCode( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_NationName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_NationName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Birth( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Birth( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Address( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Address( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Fzjg( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Fzjg( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_StartDate( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_StartDate( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_EndDate( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_EndDate( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_YxqxCode( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_YxqxCode( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_YxqxName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_YxqxName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_IdCard( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_IdCard( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE LoadDll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OpenDeviceEx( 
            SHORT port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CloseDeviceEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE EnterCardEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE EjectCardEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DestroyDll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ReadAndScanEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDeviceStatusEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CalibrationEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE InitNationArray( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetCardStatusEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ReadAndScanDpiEx( 
            LONG dpi) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ReadRFID( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IA8Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IA8 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IA8 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IA8 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IA8 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IA8 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IA8 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IA8 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Message )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Message )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_IdCardImgFileName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_IdCardImgFileName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_IdCardFrontImgFileName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_IdCardFrontImgFileName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_IdCardEndImgFileName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_IdCardEndImgFileName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_IsReaded )( 
            IA8 * This,
            /* [retval][out] */ SHORT *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_IsReaded )( 
            IA8 * This,
            /* [in] */ SHORT newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_UserName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_UserName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_SexCode )( 
            IA8 * This,
            /* [retval][out] */ SHORT *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_SexCode )( 
            IA8 * This,
            /* [in] */ SHORT newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_SexName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_SexName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_NationCode )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_NationCode )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_NationName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_NationName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Birth )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Birth )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Address )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Address )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Fzjg )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Fzjg )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_StartDate )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_StartDate )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_EndDate )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_EndDate )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_YxqxCode )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_YxqxCode )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_YxqxName )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_YxqxName )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_IdCard )( 
            IA8 * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_IdCard )( 
            IA8 * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *LoadDll )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OpenDeviceEx )( 
            IA8 * This,
            SHORT port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CloseDeviceEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *EnterCardEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *EjectCardEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DestroyDll )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ReadAndScanEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetDeviceStatusEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CalibrationEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *InitNationArray )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetCardStatusEx )( 
            IA8 * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ReadAndScanDpiEx )( 
            IA8 * This,
            LONG dpi);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ReadRFID )( 
            IA8 * This);
        
        END_INTERFACE
    } IA8Vtbl;

    interface IA8
    {
        CONST_VTBL struct IA8Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IA8_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IA8_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IA8_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IA8_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IA8_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IA8_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IA8_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IA8_get_Message(This,pVal)	\
    ( (This)->lpVtbl -> get_Message(This,pVal) ) 

#define IA8_put_Message(This,newVal)	\
    ( (This)->lpVtbl -> put_Message(This,newVal) ) 

#define IA8_get_IdCardImgFileName(This,pVal)	\
    ( (This)->lpVtbl -> get_IdCardImgFileName(This,pVal) ) 

#define IA8_put_IdCardImgFileName(This,newVal)	\
    ( (This)->lpVtbl -> put_IdCardImgFileName(This,newVal) ) 

#define IA8_get_IdCardFrontImgFileName(This,pVal)	\
    ( (This)->lpVtbl -> get_IdCardFrontImgFileName(This,pVal) ) 

#define IA8_put_IdCardFrontImgFileName(This,newVal)	\
    ( (This)->lpVtbl -> put_IdCardFrontImgFileName(This,newVal) ) 

#define IA8_get_IdCardEndImgFileName(This,pVal)	\
    ( (This)->lpVtbl -> get_IdCardEndImgFileName(This,pVal) ) 

#define IA8_put_IdCardEndImgFileName(This,newVal)	\
    ( (This)->lpVtbl -> put_IdCardEndImgFileName(This,newVal) ) 

#define IA8_get_IsReaded(This,pVal)	\
    ( (This)->lpVtbl -> get_IsReaded(This,pVal) ) 

#define IA8_put_IsReaded(This,newVal)	\
    ( (This)->lpVtbl -> put_IsReaded(This,newVal) ) 

#define IA8_get_UserName(This,pVal)	\
    ( (This)->lpVtbl -> get_UserName(This,pVal) ) 

#define IA8_put_UserName(This,newVal)	\
    ( (This)->lpVtbl -> put_UserName(This,newVal) ) 

#define IA8_get_SexCode(This,pVal)	\
    ( (This)->lpVtbl -> get_SexCode(This,pVal) ) 

#define IA8_put_SexCode(This,newVal)	\
    ( (This)->lpVtbl -> put_SexCode(This,newVal) ) 

#define IA8_get_SexName(This,pVal)	\
    ( (This)->lpVtbl -> get_SexName(This,pVal) ) 

#define IA8_put_SexName(This,newVal)	\
    ( (This)->lpVtbl -> put_SexName(This,newVal) ) 

#define IA8_get_NationCode(This,pVal)	\
    ( (This)->lpVtbl -> get_NationCode(This,pVal) ) 

#define IA8_put_NationCode(This,newVal)	\
    ( (This)->lpVtbl -> put_NationCode(This,newVal) ) 

#define IA8_get_NationName(This,pVal)	\
    ( (This)->lpVtbl -> get_NationName(This,pVal) ) 

#define IA8_put_NationName(This,newVal)	\
    ( (This)->lpVtbl -> put_NationName(This,newVal) ) 

#define IA8_get_Birth(This,pVal)	\
    ( (This)->lpVtbl -> get_Birth(This,pVal) ) 

#define IA8_put_Birth(This,newVal)	\
    ( (This)->lpVtbl -> put_Birth(This,newVal) ) 

#define IA8_get_Address(This,pVal)	\
    ( (This)->lpVtbl -> get_Address(This,pVal) ) 

#define IA8_put_Address(This,newVal)	\
    ( (This)->lpVtbl -> put_Address(This,newVal) ) 

#define IA8_get_Fzjg(This,pVal)	\
    ( (This)->lpVtbl -> get_Fzjg(This,pVal) ) 

#define IA8_put_Fzjg(This,newVal)	\
    ( (This)->lpVtbl -> put_Fzjg(This,newVal) ) 

#define IA8_get_StartDate(This,pVal)	\
    ( (This)->lpVtbl -> get_StartDate(This,pVal) ) 

#define IA8_put_StartDate(This,newVal)	\
    ( (This)->lpVtbl -> put_StartDate(This,newVal) ) 

#define IA8_get_EndDate(This,pVal)	\
    ( (This)->lpVtbl -> get_EndDate(This,pVal) ) 

#define IA8_put_EndDate(This,newVal)	\
    ( (This)->lpVtbl -> put_EndDate(This,newVal) ) 

#define IA8_get_YxqxCode(This,pVal)	\
    ( (This)->lpVtbl -> get_YxqxCode(This,pVal) ) 

#define IA8_put_YxqxCode(This,newVal)	\
    ( (This)->lpVtbl -> put_YxqxCode(This,newVal) ) 

#define IA8_get_YxqxName(This,pVal)	\
    ( (This)->lpVtbl -> get_YxqxName(This,pVal) ) 

#define IA8_put_YxqxName(This,newVal)	\
    ( (This)->lpVtbl -> put_YxqxName(This,newVal) ) 

#define IA8_get_IdCard(This,pVal)	\
    ( (This)->lpVtbl -> get_IdCard(This,pVal) ) 

#define IA8_put_IdCard(This,newVal)	\
    ( (This)->lpVtbl -> put_IdCard(This,newVal) ) 

#define IA8_LoadDll(This)	\
    ( (This)->lpVtbl -> LoadDll(This) ) 

#define IA8_OpenDeviceEx(This,port)	\
    ( (This)->lpVtbl -> OpenDeviceEx(This,port) ) 

#define IA8_CloseDeviceEx(This)	\
    ( (This)->lpVtbl -> CloseDeviceEx(This) ) 

#define IA8_EnterCardEx(This)	\
    ( (This)->lpVtbl -> EnterCardEx(This) ) 

#define IA8_EjectCardEx(This)	\
    ( (This)->lpVtbl -> EjectCardEx(This) ) 

#define IA8_DestroyDll(This)	\
    ( (This)->lpVtbl -> DestroyDll(This) ) 

#define IA8_ReadAndScanEx(This)	\
    ( (This)->lpVtbl -> ReadAndScanEx(This) ) 

#define IA8_GetDeviceStatusEx(This)	\
    ( (This)->lpVtbl -> GetDeviceStatusEx(This) ) 

#define IA8_CalibrationEx(This)	\
    ( (This)->lpVtbl -> CalibrationEx(This) ) 

#define IA8_InitNationArray(This)	\
    ( (This)->lpVtbl -> InitNationArray(This) ) 

#define IA8_GetCardStatusEx(This)	\
    ( (This)->lpVtbl -> GetCardStatusEx(This) ) 

#define IA8_ReadAndScanDpiEx(This,dpi)	\
    ( (This)->lpVtbl -> ReadAndScanDpiEx(This,dpi) ) 

#define IA8_ReadRFID(This)	\
    ( (This)->lpVtbl -> ReadRFID(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IA8_INTERFACE_DEFINED__ */


#ifndef __ICashCode_INTERFACE_DEFINED__
#define __ICashCode_INTERFACE_DEFINED__

/* interface ICashCode */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ICashCode;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6ED256C8-E709-40DB-AB49-5365D12FC27D")
    ICashCode : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HasAcceptMoney( 
            /* [retval][out] */ SHORT *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HasAcceptMoney( 
            /* [in] */ SHORT newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Message( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Message( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE LoadDll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DestroyDll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE InitCashCode( 
            SHORT port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE InitCashCodeV2( 
            SHORT port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IdentifyExV2( 
            SHORT maxmoney) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CloseCashCode( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OpenDeviceEx( 
            SHORT port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CloseDeviceEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDeviceStatusEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE StopIdentifyEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ResetEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE StartIdentifyV2Ex( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ICashCodeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICashCode * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICashCode * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICashCode * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ICashCode * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ICashCode * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ICashCode * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICashCode * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HasAcceptMoney )( 
            ICashCode * This,
            /* [retval][out] */ SHORT *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HasAcceptMoney )( 
            ICashCode * This,
            /* [in] */ SHORT newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Message )( 
            ICashCode * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Message )( 
            ICashCode * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *LoadDll )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DestroyDll )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *InitCashCode )( 
            ICashCode * This,
            SHORT port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *InitCashCodeV2 )( 
            ICashCode * This,
            SHORT port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *IdentifyExV2 )( 
            ICashCode * This,
            SHORT maxmoney);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CloseCashCode )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OpenDeviceEx )( 
            ICashCode * This,
            SHORT port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CloseDeviceEx )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetDeviceStatusEx )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StopIdentifyEx )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ResetEx )( 
            ICashCode * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StartIdentifyV2Ex )( 
            ICashCode * This);
        
        END_INTERFACE
    } ICashCodeVtbl;

    interface ICashCode
    {
        CONST_VTBL struct ICashCodeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICashCode_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICashCode_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICashCode_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICashCode_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ICashCode_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ICashCode_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ICashCode_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define ICashCode_get_HasAcceptMoney(This,pVal)	\
    ( (This)->lpVtbl -> get_HasAcceptMoney(This,pVal) ) 

#define ICashCode_put_HasAcceptMoney(This,newVal)	\
    ( (This)->lpVtbl -> put_HasAcceptMoney(This,newVal) ) 

#define ICashCode_get_Message(This,pVal)	\
    ( (This)->lpVtbl -> get_Message(This,pVal) ) 

#define ICashCode_put_Message(This,newVal)	\
    ( (This)->lpVtbl -> put_Message(This,newVal) ) 

#define ICashCode_LoadDll(This)	\
    ( (This)->lpVtbl -> LoadDll(This) ) 

#define ICashCode_DestroyDll(This)	\
    ( (This)->lpVtbl -> DestroyDll(This) ) 

#define ICashCode_InitCashCode(This,port)	\
    ( (This)->lpVtbl -> InitCashCode(This,port) ) 

#define ICashCode_InitCashCodeV2(This,port)	\
    ( (This)->lpVtbl -> InitCashCodeV2(This,port) ) 

#define ICashCode_IdentifyExV2(This,maxmoney)	\
    ( (This)->lpVtbl -> IdentifyExV2(This,maxmoney) ) 

#define ICashCode_CloseCashCode(This)	\
    ( (This)->lpVtbl -> CloseCashCode(This) ) 

#define ICashCode_OpenDeviceEx(This,port)	\
    ( (This)->lpVtbl -> OpenDeviceEx(This,port) ) 

#define ICashCode_CloseDeviceEx(This)	\
    ( (This)->lpVtbl -> CloseDeviceEx(This) ) 

#define ICashCode_GetDeviceStatusEx(This)	\
    ( (This)->lpVtbl -> GetDeviceStatusEx(This) ) 

#define ICashCode_StopIdentifyEx(This)	\
    ( (This)->lpVtbl -> StopIdentifyEx(This) ) 

#define ICashCode_ResetEx(This)	\
    ( (This)->lpVtbl -> ResetEx(This) ) 

#define ICashCode_StartIdentifyV2Ex(This)	\
    ( (This)->lpVtbl -> StartIdentifyV2Ex(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICashCode_INTERFACE_DEFINED__ */


#ifndef __IZT598_INTERFACE_DEFINED__
#define __IZT598_INTERFACE_DEFINED__

/* interface IZT598 */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IZT598;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0B8EB349-DC10-4A51-AE10-D8650792ADBC")
    IZT598 : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IZT598Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IZT598 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IZT598 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IZT598 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IZT598 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IZT598 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IZT598 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IZT598 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IZT598Vtbl;

    interface IZT598
    {
        CONST_VTBL struct IZT598Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IZT598_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IZT598_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IZT598_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IZT598_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IZT598_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IZT598_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IZT598_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IZT598_INTERFACE_DEFINED__ */


#ifndef __IKMYKey_INTERFACE_DEFINED__
#define __IKMYKey_INTERFACE_DEFINED__

/* interface IKMYKey */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IKMYKey;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("FD032099-04DA-4EB0-8F09-CA66AE6A1FD5")
    IKMYKey : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IKMYKeyVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKMYKey * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKMYKey * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKMYKey * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKMYKey * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKMYKey * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKMYKey * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKMYKey * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IKMYKeyVtbl;

    interface IKMYKey
    {
        CONST_VTBL struct IKMYKeyVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKMYKey_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IKMYKey_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IKMYKey_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IKMYKey_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IKMYKey_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IKMYKey_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IKMYKey_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IKMYKey_INTERFACE_DEFINED__ */


#ifndef __ICZCard_INTERFACE_DEFINED__
#define __ICZCard_INTERFACE_DEFINED__

/* interface ICZCard */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ICZCard;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("69404284-C3C8-463C-BFBC-56F5C2E9FCCF")
    ICZCard : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ICZCardVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICZCard * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICZCard * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICZCard * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ICZCard * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ICZCard * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ICZCard * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICZCard * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ICZCardVtbl;

    interface ICZCard
    {
        CONST_VTBL struct ICZCardVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICZCard_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICZCard_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICZCard_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICZCard_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ICZCard_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ICZCard_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ICZCard_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICZCard_INTERFACE_DEFINED__ */


#ifndef __ITTCard_INTERFACE_DEFINED__
#define __ITTCard_INTERFACE_DEFINED__

/* interface ITTCard */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ITTCard;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDB39CC1-3E9C-46C7-B371-AF0FF107B449")
    ITTCard : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Message( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Message( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Track1( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Track1( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Track3( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Track3( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Track2( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_Track2( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE LoadDll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DestroyDll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DisableEntryEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CaptureCardEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OpenDeviceEx( 
            SHORT port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CloseDeviceEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE EjectCardEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE EnableEntryEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDeviceStatusEx( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ReadTracksEx( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITTCardVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITTCard * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITTCard * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITTCard * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITTCard * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITTCard * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITTCard * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITTCard * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Message )( 
            ITTCard * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Message )( 
            ITTCard * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Track1 )( 
            ITTCard * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Track1 )( 
            ITTCard * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Track3 )( 
            ITTCard * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Track3 )( 
            ITTCard * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Track2 )( 
            ITTCard * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_Track2 )( 
            ITTCard * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *LoadDll )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DestroyDll )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DisableEntryEx )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CaptureCardEx )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OpenDeviceEx )( 
            ITTCard * This,
            SHORT port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CloseDeviceEx )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *EjectCardEx )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *EnableEntryEx )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetDeviceStatusEx )( 
            ITTCard * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ReadTracksEx )( 
            ITTCard * This);
        
        END_INTERFACE
    } ITTCardVtbl;

    interface ITTCard
    {
        CONST_VTBL struct ITTCardVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITTCard_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ITTCard_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ITTCard_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ITTCard_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ITTCard_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ITTCard_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ITTCard_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define ITTCard_get_Message(This,pVal)	\
    ( (This)->lpVtbl -> get_Message(This,pVal) ) 

#define ITTCard_put_Message(This,newVal)	\
    ( (This)->lpVtbl -> put_Message(This,newVal) ) 

#define ITTCard_get_Track1(This,pVal)	\
    ( (This)->lpVtbl -> get_Track1(This,pVal) ) 

#define ITTCard_put_Track1(This,newVal)	\
    ( (This)->lpVtbl -> put_Track1(This,newVal) ) 

#define ITTCard_get_Track3(This,pVal)	\
    ( (This)->lpVtbl -> get_Track3(This,pVal) ) 

#define ITTCard_put_Track3(This,newVal)	\
    ( (This)->lpVtbl -> put_Track3(This,newVal) ) 

#define ITTCard_get_Track2(This,pVal)	\
    ( (This)->lpVtbl -> get_Track2(This,pVal) ) 

#define ITTCard_put_Track2(This,newVal)	\
    ( (This)->lpVtbl -> put_Track2(This,newVal) ) 

#define ITTCard_LoadDll(This)	\
    ( (This)->lpVtbl -> LoadDll(This) ) 

#define ITTCard_DestroyDll(This)	\
    ( (This)->lpVtbl -> DestroyDll(This) ) 

#define ITTCard_DisableEntryEx(This)	\
    ( (This)->lpVtbl -> DisableEntryEx(This) ) 

#define ITTCard_CaptureCardEx(This)	\
    ( (This)->lpVtbl -> CaptureCardEx(This) ) 

#define ITTCard_OpenDeviceEx(This,port)	\
    ( (This)->lpVtbl -> OpenDeviceEx(This,port) ) 

#define ITTCard_CloseDeviceEx(This)	\
    ( (This)->lpVtbl -> CloseDeviceEx(This) ) 

#define ITTCard_EjectCardEx(This)	\
    ( (This)->lpVtbl -> EjectCardEx(This) ) 

#define ITTCard_EnableEntryEx(This)	\
    ( (This)->lpVtbl -> EnableEntryEx(This) ) 

#define ITTCard_GetDeviceStatusEx(This)	\
    ( (This)->lpVtbl -> GetDeviceStatusEx(This) ) 

#define ITTCard_ReadTracksEx(This)	\
    ( (This)->lpVtbl -> ReadTracksEx(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ITTCard_INTERFACE_DEFINED__ */


#ifndef __ITYCard_INTERFACE_DEFINED__
#define __ITYCard_INTERFACE_DEFINED__

/* interface ITYCard */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ITYCard;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F79FACB1-2326-465A-9569-9BA4DC86CA73")
    ITYCard : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ITYCardVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITYCard * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITYCard * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITYCard * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITYCard * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITYCard * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITYCard * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITYCard * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ITYCardVtbl;

    interface ITYCard
    {
        CONST_VTBL struct ITYCardVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITYCard_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ITYCard_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ITYCard_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ITYCard_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ITYCard_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ITYCard_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ITYCard_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ITYCard_INTERFACE_DEFINED__ */


#ifndef __IIdCard_INTERFACE_DEFINED__
#define __IIdCard_INTERFACE_DEFINED__

/* interface IIdCard */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IIdCard;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D97E5A0D-B4E8-4F59-BB76-EA057E295123")
    IIdCard : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IIdCardVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IIdCard * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IIdCard * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IIdCard * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IIdCard * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IIdCard * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IIdCard * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IIdCard * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IIdCardVtbl;

    interface IIdCard
    {
        CONST_VTBL struct IIdCardVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IIdCard_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IIdCard_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IIdCard_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IIdCard_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IIdCard_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IIdCard_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IIdCard_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IIdCard_INTERFACE_DEFINED__ */


#ifndef __ICamera_INTERFACE_DEFINED__
#define __ICamera_INTERFACE_DEFINED__

/* interface ICamera */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ICamera;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("83CBEE6F-0D34-40D1-BA3F-EE31907F8F73")
    ICamera : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ICameraVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICamera * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICamera * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICamera * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ICamera * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ICamera * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ICamera * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICamera * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ICameraVtbl;

    interface ICamera
    {
        CONST_VTBL struct ICameraVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICamera_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICamera_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICamera_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICamera_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ICamera_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ICamera_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ICamera_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICamera_INTERFACE_DEFINED__ */


#ifndef __IDrvLed_INTERFACE_DEFINED__
#define __IDrvLed_INTERFACE_DEFINED__

/* interface IDrvLed */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IDrvLed;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9492D0E2-2D17-438C-8110-1EF62D224BBD")
    IDrvLed : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOnA8( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOffA8( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOnCard( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOffCard( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOnHotPrinter( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOffHotPrinter( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOnPort( 
            SHORT port,
            SHORT index) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOffAll( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE TurnOnLed( 
            SHORT index) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE BeepHint( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Beep( 
            SHORT freq,
            SHORT duration) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IDrvLedVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDrvLed * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDrvLed * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDrvLed * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IDrvLed * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IDrvLed * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IDrvLed * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IDrvLed * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOnA8 )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOffA8 )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOnCard )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOffCard )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOnHotPrinter )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOffHotPrinter )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOnPort )( 
            IDrvLed * This,
            SHORT port,
            SHORT index);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOffAll )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *TurnOnLed )( 
            IDrvLed * This,
            SHORT index);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *BeepHint )( 
            IDrvLed * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Beep )( 
            IDrvLed * This,
            SHORT freq,
            SHORT duration);
        
        END_INTERFACE
    } IDrvLedVtbl;

    interface IDrvLed
    {
        CONST_VTBL struct IDrvLedVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDrvLed_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IDrvLed_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IDrvLed_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IDrvLed_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IDrvLed_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IDrvLed_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IDrvLed_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IDrvLed_TurnOnA8(This)	\
    ( (This)->lpVtbl -> TurnOnA8(This) ) 

#define IDrvLed_TurnOffA8(This)	\
    ( (This)->lpVtbl -> TurnOffA8(This) ) 

#define IDrvLed_TurnOnCard(This)	\
    ( (This)->lpVtbl -> TurnOnCard(This) ) 

#define IDrvLed_TurnOffCard(This)	\
    ( (This)->lpVtbl -> TurnOffCard(This) ) 

#define IDrvLed_TurnOnHotPrinter(This)	\
    ( (This)->lpVtbl -> TurnOnHotPrinter(This) ) 

#define IDrvLed_TurnOffHotPrinter(This)	\
    ( (This)->lpVtbl -> TurnOffHotPrinter(This) ) 

#define IDrvLed_TurnOnPort(This,port,index)	\
    ( (This)->lpVtbl -> TurnOnPort(This,port,index) ) 

#define IDrvLed_TurnOffAll(This)	\
    ( (This)->lpVtbl -> TurnOffAll(This) ) 

#define IDrvLed_TurnOnLed(This,index)	\
    ( (This)->lpVtbl -> TurnOnLed(This,index) ) 

#define IDrvLed_BeepHint(This)	\
    ( (This)->lpVtbl -> BeepHint(This) ) 

#define IDrvLed_Beep(This,freq,duration)	\
    ( (This)->lpVtbl -> Beep(This,freq,duration) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDrvLed_INTERFACE_DEFINED__ */


#ifndef __IPrinterEx_INTERFACE_DEFINED__
#define __IPrinterEx_INTERFACE_DEFINED__

/* interface IPrinterEx */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IPrinterEx;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("CA7DDDD5-E61A-461F-B11E-2E410C3D19BB")
    IPrinterEx : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IPrinterExVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IPrinterEx * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IPrinterEx * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IPrinterEx * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IPrinterEx * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IPrinterEx * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IPrinterEx * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IPrinterEx * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IPrinterExVtbl;

    interface IPrinterEx
    {
        CONST_VTBL struct IPrinterExVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IPrinterEx_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IPrinterEx_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IPrinterEx_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IPrinterEx_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IPrinterEx_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IPrinterEx_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IPrinterEx_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IPrinterEx_INTERFACE_DEFINED__ */



#ifndef __ETTSelfLib_LIBRARY_DEFINED__
#define __ETTSelfLib_LIBRARY_DEFINED__

/* library ETTSelfLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_ETTSelfLib;

#ifndef ___IA8Events_DISPINTERFACE_DEFINED__
#define ___IA8Events_DISPINTERFACE_DEFINED__

/* dispinterface _IA8Events */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IA8Events;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("C09BEDDC-306B-4683-B177-A24F25B8E69C")
    _IA8Events : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IA8EventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IA8Events * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IA8Events * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IA8Events * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IA8Events * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IA8Events * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IA8Events * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IA8Events * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IA8EventsVtbl;

    interface _IA8Events
    {
        CONST_VTBL struct _IA8EventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IA8Events_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IA8Events_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IA8Events_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IA8Events_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IA8Events_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IA8Events_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IA8Events_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IA8Events_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_A8;

#ifdef __cplusplus

class DECLSPEC_UUID("D0491A67-A97A-4325-9271-83D7711BC507")
A8;
#endif

#ifndef ___ICashCodeEvents_DISPINTERFACE_DEFINED__
#define ___ICashCodeEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ICashCodeEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__ICashCodeEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("EFCF073B-A03B-4220-B4B6-8B228B6A320D")
    _ICashCodeEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ICashCodeEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ICashCodeEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ICashCodeEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ICashCodeEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ICashCodeEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ICashCodeEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ICashCodeEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ICashCodeEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ICashCodeEventsVtbl;

    interface _ICashCodeEvents
    {
        CONST_VTBL struct _ICashCodeEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ICashCodeEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ICashCodeEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ICashCodeEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ICashCodeEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ICashCodeEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ICashCodeEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ICashCodeEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ICashCodeEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_CashCode;

#ifdef __cplusplus

class DECLSPEC_UUID("9C61D5FB-30B5-4152-A052-C3EF4A9E457E")
CashCode;
#endif

#ifndef ___IZT598Events_DISPINTERFACE_DEFINED__
#define ___IZT598Events_DISPINTERFACE_DEFINED__

/* dispinterface _IZT598Events */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IZT598Events;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("A59245DA-F8BA-4BBE-986A-25FC287982C0")
    _IZT598Events : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IZT598EventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IZT598Events * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IZT598Events * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IZT598Events * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IZT598Events * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IZT598Events * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IZT598Events * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IZT598Events * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IZT598EventsVtbl;

    interface _IZT598Events
    {
        CONST_VTBL struct _IZT598EventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IZT598Events_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IZT598Events_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IZT598Events_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IZT598Events_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IZT598Events_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IZT598Events_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IZT598Events_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IZT598Events_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ZT598;

#ifdef __cplusplus

class DECLSPEC_UUID("0F5CB0AC-5AC6-4F58-AA5E-EF149C91A2A0")
ZT598;
#endif

#ifndef ___IKMYKeyEvents_DISPINTERFACE_DEFINED__
#define ___IKMYKeyEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IKMYKeyEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IKMYKeyEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("96D93528-741B-4964-98CC-EDFB6B43CC96")
    _IKMYKeyEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IKMYKeyEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IKMYKeyEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IKMYKeyEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IKMYKeyEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IKMYKeyEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IKMYKeyEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IKMYKeyEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IKMYKeyEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IKMYKeyEventsVtbl;

    interface _IKMYKeyEvents
    {
        CONST_VTBL struct _IKMYKeyEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IKMYKeyEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IKMYKeyEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IKMYKeyEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IKMYKeyEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IKMYKeyEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IKMYKeyEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IKMYKeyEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IKMYKeyEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_KMYKey;

#ifdef __cplusplus

class DECLSPEC_UUID("2412B760-3A7B-4359-8AA0-837CFE24417D")
KMYKey;
#endif

#ifndef ___ICZCardEvents_DISPINTERFACE_DEFINED__
#define ___ICZCardEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ICZCardEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__ICZCardEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("E4DE661F-9C92-497F-B57E-F47A324571E5")
    _ICZCardEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ICZCardEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ICZCardEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ICZCardEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ICZCardEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ICZCardEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ICZCardEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ICZCardEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ICZCardEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ICZCardEventsVtbl;

    interface _ICZCardEvents
    {
        CONST_VTBL struct _ICZCardEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ICZCardEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ICZCardEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ICZCardEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ICZCardEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ICZCardEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ICZCardEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ICZCardEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ICZCardEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_CZCard;

#ifdef __cplusplus

class DECLSPEC_UUID("15293E77-C285-4781-8B21-24AB44B0389F")
CZCard;
#endif

#ifndef ___ITTCardEvents_DISPINTERFACE_DEFINED__
#define ___ITTCardEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ITTCardEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__ITTCardEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("0B2883FB-4924-46A3-8D50-770EF7E52E85")
    _ITTCardEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ITTCardEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ITTCardEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ITTCardEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ITTCardEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ITTCardEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ITTCardEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ITTCardEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ITTCardEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ITTCardEventsVtbl;

    interface _ITTCardEvents
    {
        CONST_VTBL struct _ITTCardEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ITTCardEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ITTCardEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ITTCardEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ITTCardEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ITTCardEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ITTCardEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ITTCardEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ITTCardEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TTCard;

#ifdef __cplusplus

class DECLSPEC_UUID("5A0DF466-3275-40DC-81FB-47BD91FEE41B")
TTCard;
#endif

#ifndef ___ITYCardEvents_DISPINTERFACE_DEFINED__
#define ___ITYCardEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ITYCardEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__ITYCardEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("ED6A8D46-2ABE-486B-983E-C3AAC9DB0C17")
    _ITYCardEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ITYCardEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ITYCardEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ITYCardEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ITYCardEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ITYCardEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ITYCardEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ITYCardEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ITYCardEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ITYCardEventsVtbl;

    interface _ITYCardEvents
    {
        CONST_VTBL struct _ITYCardEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ITYCardEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ITYCardEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ITYCardEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ITYCardEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ITYCardEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ITYCardEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ITYCardEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ITYCardEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TYCard;

#ifdef __cplusplus

class DECLSPEC_UUID("FD483260-AA28-4745-832D-961F9949EB6A")
TYCard;
#endif

#ifndef ___IIdCardEvents_DISPINTERFACE_DEFINED__
#define ___IIdCardEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IIdCardEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IIdCardEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("6FCB0FC2-EA52-4A97-A7E1-E5A1195C8CEC")
    _IIdCardEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IIdCardEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IIdCardEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IIdCardEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IIdCardEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IIdCardEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IIdCardEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IIdCardEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IIdCardEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IIdCardEventsVtbl;

    interface _IIdCardEvents
    {
        CONST_VTBL struct _IIdCardEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IIdCardEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IIdCardEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IIdCardEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IIdCardEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IIdCardEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IIdCardEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IIdCardEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IIdCardEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_IdCard;

#ifdef __cplusplus

class DECLSPEC_UUID("23AECF79-6B11-4963-A129-71BD8061C4DF")
IdCard;
#endif

#ifndef ___ICameraEvents_DISPINTERFACE_DEFINED__
#define ___ICameraEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ICameraEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__ICameraEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("41BFAAEF-1AD9-43A9-AC45-667B4D43FADB")
    _ICameraEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ICameraEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ICameraEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ICameraEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ICameraEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ICameraEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ICameraEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ICameraEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ICameraEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ICameraEventsVtbl;

    interface _ICameraEvents
    {
        CONST_VTBL struct _ICameraEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ICameraEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ICameraEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ICameraEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ICameraEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ICameraEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ICameraEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ICameraEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ICameraEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_Camera;

#ifdef __cplusplus

class DECLSPEC_UUID("948E6CD7-A640-4454-92D2-7418C4B3C3BB")
Camera;
#endif

#ifndef ___IDrvLedEvents_DISPINTERFACE_DEFINED__
#define ___IDrvLedEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IDrvLedEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IDrvLedEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("4530BA8C-07AC-4A6E-92AF-3B1CC6A7E2C9")
    _IDrvLedEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IDrvLedEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IDrvLedEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IDrvLedEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IDrvLedEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IDrvLedEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IDrvLedEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IDrvLedEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IDrvLedEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IDrvLedEventsVtbl;

    interface _IDrvLedEvents
    {
        CONST_VTBL struct _IDrvLedEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IDrvLedEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IDrvLedEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IDrvLedEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IDrvLedEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IDrvLedEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IDrvLedEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IDrvLedEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IDrvLedEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_DrvLed;

#ifdef __cplusplus

class DECLSPEC_UUID("3547B641-F97D-4F66-BA96-3A8B8640D7DD")
DrvLed;
#endif

#ifndef ___IPrinterExEvents_DISPINTERFACE_DEFINED__
#define ___IPrinterExEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IPrinterExEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IPrinterExEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("58BA5349-FAD4-4786-8AC9-9027043228DC")
    _IPrinterExEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IPrinterExEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IPrinterExEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IPrinterExEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IPrinterExEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IPrinterExEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IPrinterExEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IPrinterExEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IPrinterExEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IPrinterExEventsVtbl;

    interface _IPrinterExEvents
    {
        CONST_VTBL struct _IPrinterExEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IPrinterExEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IPrinterExEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IPrinterExEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IPrinterExEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IPrinterExEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IPrinterExEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IPrinterExEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IPrinterExEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_PrinterEx;

#ifdef __cplusplus

class DECLSPEC_UUID("D67CB9C8-A91F-4FB1-9056-2F71B5DB5DC0")
PrinterEx;
#endif
#endif /* __ETTSelfLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


