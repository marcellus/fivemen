

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue Oct 16 03:38:26 2012
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


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __ETTCashidl_h__
#define __ETTCashidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTCash_FWD_DEFINED__
#define ___DETTCash_FWD_DEFINED__
typedef interface _DETTCash _DETTCash;
#endif 	/* ___DETTCash_FWD_DEFINED__ */


#ifndef ___DETTCashEvents_FWD_DEFINED__
#define ___DETTCashEvents_FWD_DEFINED__
typedef interface _DETTCashEvents _DETTCashEvents;
#endif 	/* ___DETTCashEvents_FWD_DEFINED__ */


#ifndef __ETTCash_FWD_DEFINED__
#define __ETTCash_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTCash ETTCash;
#else
typedef struct ETTCash ETTCash;
#endif /* __cplusplus */

#endif 	/* __ETTCash_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTCashLib_LIBRARY_DEFINED__
#define __ETTCashLib_LIBRARY_DEFINED__

/* library ETTCashLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTCashLib;

#ifndef ___DETTCash_DISPINTERFACE_DEFINED__
#define ___DETTCash_DISPINTERFACE_DEFINED__

/* dispinterface _DETTCash */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTCash;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("E7830902-FE6B-4AC0-8E15-E9712F2997F4")
    _DETTCash : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTCashVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTCash * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTCash * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTCash * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTCash * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTCash * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTCash * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTCash * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTCashVtbl;

    interface _DETTCash
    {
        CONST_VTBL struct _DETTCashVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTCash_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTCash_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTCash_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTCash_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTCash_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTCash_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTCash_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTCash_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTCashEvents_DISPINTERFACE_DEFINED__
#define ___DETTCashEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTCashEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTCashEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("1A65DFCC-6BD4-4493-8F77-6B6D6F443928")
    _DETTCashEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTCashEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTCashEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTCashEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTCashEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTCashEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTCashEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTCashEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTCashEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTCashEventsVtbl;

    interface _DETTCashEvents
    {
        CONST_VTBL struct _DETTCashEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTCashEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTCashEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTCashEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTCashEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTCashEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTCashEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTCashEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTCashEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTCash;

#ifdef __cplusplus

class DECLSPEC_UUID("EC8BC46B-0405-47CA-B523-3C409FCE78E2")
ETTCash;
#endif
#endif /* __ETTCashLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


