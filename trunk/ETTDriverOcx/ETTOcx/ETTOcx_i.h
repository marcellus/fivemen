

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Wed Nov 02 13:08:31 2011
 */
/* Compiler settings for .\ETTOcx.idl:
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

#ifndef __ETTOcx_i_h__
#define __ETTOcx_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IVoiceObj_FWD_DEFINED__
#define __IVoiceObj_FWD_DEFINED__
typedef interface IVoiceObj IVoiceObj;
#endif 	/* __IVoiceObj_FWD_DEFINED__ */


#ifndef __IUnionPay_FWD_DEFINED__
#define __IUnionPay_FWD_DEFINED__
typedef interface IUnionPay IUnionPay;
#endif 	/* __IUnionPay_FWD_DEFINED__ */


#ifndef ___IVoiceObjEvents_FWD_DEFINED__
#define ___IVoiceObjEvents_FWD_DEFINED__
typedef interface _IVoiceObjEvents _IVoiceObjEvents;
#endif 	/* ___IVoiceObjEvents_FWD_DEFINED__ */


#ifndef __VoiceObj_FWD_DEFINED__
#define __VoiceObj_FWD_DEFINED__

#ifdef __cplusplus
typedef class VoiceObj VoiceObj;
#else
typedef struct VoiceObj VoiceObj;
#endif /* __cplusplus */

#endif 	/* __VoiceObj_FWD_DEFINED__ */


#ifndef ___IUnionPayEvents_FWD_DEFINED__
#define ___IUnionPayEvents_FWD_DEFINED__
typedef interface _IUnionPayEvents _IUnionPayEvents;
#endif 	/* ___IUnionPayEvents_FWD_DEFINED__ */


#ifndef __UnionPay_FWD_DEFINED__
#define __UnionPay_FWD_DEFINED__

#ifdef __cplusplus
typedef class UnionPay UnionPay;
#else
typedef struct UnionPay UnionPay;
#endif /* __cplusplus */

#endif 	/* __UnionPay_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IVoiceObj_INTERFACE_DEFINED__
#define __IVoiceObj_INTERFACE_DEFINED__

/* interface IVoiceObj */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IVoiceObj;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("FE7A7E9E-D0F6-4EBD-ADC8-28CE426FBC0F")
    IVoiceObj : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE PlayVoice( 
            BSTR filename) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IVoiceObjVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IVoiceObj * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IVoiceObj * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IVoiceObj * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IVoiceObj * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IVoiceObj * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IVoiceObj * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IVoiceObj * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *PlayVoice )( 
            IVoiceObj * This,
            BSTR filename);
        
        END_INTERFACE
    } IVoiceObjVtbl;

    interface IVoiceObj
    {
        CONST_VTBL struct IVoiceObjVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVoiceObj_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVoiceObj_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVoiceObj_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVoiceObj_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IVoiceObj_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IVoiceObj_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IVoiceObj_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IVoiceObj_PlayVoice(This,filename)	\
    ( (This)->lpVtbl -> PlayVoice(This,filename) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVoiceObj_INTERFACE_DEFINED__ */


#ifndef __IUnionPay_INTERFACE_DEFINED__
#define __IUnionPay_INTERFACE_DEFINED__

/* interface IUnionPay */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IUnionPay;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BC9A1E58-3DD2-4A08-8B70-7EEE5E77D7F0")
    IUnionPay : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IUnionPayVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IUnionPay * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IUnionPay * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IUnionPay * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IUnionPay * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IUnionPay * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IUnionPay * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IUnionPay * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IUnionPayVtbl;

    interface IUnionPay
    {
        CONST_VTBL struct IUnionPayVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IUnionPay_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IUnionPay_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IUnionPay_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IUnionPay_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IUnionPay_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IUnionPay_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IUnionPay_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IUnionPay_INTERFACE_DEFINED__ */



#ifndef __ETTOcxLib_LIBRARY_DEFINED__
#define __ETTOcxLib_LIBRARY_DEFINED__

/* library ETTOcxLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_ETTOcxLib;

#ifndef ___IVoiceObjEvents_DISPINTERFACE_DEFINED__
#define ___IVoiceObjEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IVoiceObjEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IVoiceObjEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("8AFFD310-5388-40DD-A5A2-1CC496B136ED")
    _IVoiceObjEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IVoiceObjEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IVoiceObjEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IVoiceObjEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IVoiceObjEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IVoiceObjEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IVoiceObjEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IVoiceObjEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IVoiceObjEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IVoiceObjEventsVtbl;

    interface _IVoiceObjEvents
    {
        CONST_VTBL struct _IVoiceObjEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IVoiceObjEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IVoiceObjEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IVoiceObjEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IVoiceObjEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IVoiceObjEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IVoiceObjEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IVoiceObjEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IVoiceObjEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_VoiceObj;

#ifdef __cplusplus

class DECLSPEC_UUID("D5B19295-2DDF-406C-88EB-D644AD73BDCB")
VoiceObj;
#endif

#ifndef ___IUnionPayEvents_DISPINTERFACE_DEFINED__
#define ___IUnionPayEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IUnionPayEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IUnionPayEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D4C0F2D9-9D95-4A26-84BD-340E6BE64FB2")
    _IUnionPayEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IUnionPayEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IUnionPayEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IUnionPayEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IUnionPayEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IUnionPayEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IUnionPayEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IUnionPayEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IUnionPayEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IUnionPayEventsVtbl;

    interface _IUnionPayEvents
    {
        CONST_VTBL struct _IUnionPayEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IUnionPayEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IUnionPayEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IUnionPayEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IUnionPayEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IUnionPayEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IUnionPayEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IUnionPayEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IUnionPayEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_UnionPay;

#ifdef __cplusplus

class DECLSPEC_UUID("E4A6877E-30EA-4915-BB27-AC8D70FB27CB")
UnionPay;
#endif
#endif /* __ETTOcxLib_LIBRARY_DEFINED__ */

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


