

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:09:36 2011
 */
/* Compiler settings for .\ETTPrintActiveX.idl:
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


#ifndef __ETTPrintActiveXidl_h__
#define __ETTPrintActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTPrintActiveX_FWD_DEFINED__
#define ___DETTPrintActiveX_FWD_DEFINED__
typedef interface _DETTPrintActiveX _DETTPrintActiveX;
#endif 	/* ___DETTPrintActiveX_FWD_DEFINED__ */


#ifndef ___DETTPrintActiveXEvents_FWD_DEFINED__
#define ___DETTPrintActiveXEvents_FWD_DEFINED__
typedef interface _DETTPrintActiveXEvents _DETTPrintActiveXEvents;
#endif 	/* ___DETTPrintActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTPrintActiveX_FWD_DEFINED__
#define __ETTPrintActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTPrintActiveX ETTPrintActiveX;
#else
typedef struct ETTPrintActiveX ETTPrintActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTPrintActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTPrintActiveXLib_LIBRARY_DEFINED__
#define __ETTPrintActiveXLib_LIBRARY_DEFINED__

/* library ETTPrintActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTPrintActiveXLib;

#ifndef ___DETTPrintActiveX_DISPINTERFACE_DEFINED__
#define ___DETTPrintActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTPrintActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTPrintActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("A94C9160-7DD0-4C29-A470-1B218E388B0C")
    _DETTPrintActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTPrintActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTPrintActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTPrintActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTPrintActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTPrintActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTPrintActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTPrintActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTPrintActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTPrintActiveXVtbl;

    interface _DETTPrintActiveX
    {
        CONST_VTBL struct _DETTPrintActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTPrintActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTPrintActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTPrintActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTPrintActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTPrintActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTPrintActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTPrintActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTPrintActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTPrintActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTPrintActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTPrintActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTPrintActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("3F019042-B4D1-4BA1-AF88-74B8B56172DF")
    _DETTPrintActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTPrintActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTPrintActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTPrintActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTPrintActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTPrintActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTPrintActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTPrintActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTPrintActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTPrintActiveXEventsVtbl;

    interface _DETTPrintActiveXEvents
    {
        CONST_VTBL struct _DETTPrintActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTPrintActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTPrintActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTPrintActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTPrintActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTPrintActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTPrintActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTPrintActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTPrintActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTPrintActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("07F2485D-2A40-44B2-9000-04F92EB8F96A")
ETTPrintActiveX;
#endif
#endif /* __ETTPrintActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


