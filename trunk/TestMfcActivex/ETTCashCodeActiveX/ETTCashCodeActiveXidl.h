

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Wed May 11 13:26:59 2011
 */
/* Compiler settings for .\ETTCashCodeActiveX.idl:
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


#ifndef __ETTCashCodeActiveXidl_h__
#define __ETTCashCodeActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTCashCodeActiveX_FWD_DEFINED__
#define ___DETTCashCodeActiveX_FWD_DEFINED__
typedef interface _DETTCashCodeActiveX _DETTCashCodeActiveX;
#endif 	/* ___DETTCashCodeActiveX_FWD_DEFINED__ */


#ifndef ___DETTCashCodeActiveXEvents_FWD_DEFINED__
#define ___DETTCashCodeActiveXEvents_FWD_DEFINED__
typedef interface _DETTCashCodeActiveXEvents _DETTCashCodeActiveXEvents;
#endif 	/* ___DETTCashCodeActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTCashCodeActiveX_FWD_DEFINED__
#define __ETTCashCodeActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTCashCodeActiveX ETTCashCodeActiveX;
#else
typedef struct ETTCashCodeActiveX ETTCashCodeActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTCashCodeActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTCashCodeActiveXLib_LIBRARY_DEFINED__
#define __ETTCashCodeActiveXLib_LIBRARY_DEFINED__

/* library ETTCashCodeActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTCashCodeActiveXLib;

#ifndef ___DETTCashCodeActiveX_DISPINTERFACE_DEFINED__
#define ___DETTCashCodeActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTCashCodeActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTCashCodeActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D7039AD9-7364-4E65-BBA3-9CE8DF60E987")
    _DETTCashCodeActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTCashCodeActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTCashCodeActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTCashCodeActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTCashCodeActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTCashCodeActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTCashCodeActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTCashCodeActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTCashCodeActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTCashCodeActiveXVtbl;

    interface _DETTCashCodeActiveX
    {
        CONST_VTBL struct _DETTCashCodeActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTCashCodeActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTCashCodeActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTCashCodeActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTCashCodeActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTCashCodeActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTCashCodeActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTCashCodeActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTCashCodeActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTCashCodeActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTCashCodeActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTCashCodeActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTCashCodeActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("3727E203-B8F8-40A9-A0A5-E2680AF6A1C2")
    _DETTCashCodeActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTCashCodeActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTCashCodeActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTCashCodeActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTCashCodeActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTCashCodeActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTCashCodeActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTCashCodeActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTCashCodeActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTCashCodeActiveXEventsVtbl;

    interface _DETTCashCodeActiveXEvents
    {
        CONST_VTBL struct _DETTCashCodeActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTCashCodeActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTCashCodeActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTCashCodeActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTCashCodeActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTCashCodeActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTCashCodeActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTCashCodeActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTCashCodeActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTCashCodeActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("5A797850-BE8E-4939-8F6D-D9397B963765")
ETTCashCodeActiveX;
#endif
#endif /* __ETTCashCodeActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


