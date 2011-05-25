

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:10:17 2011
 */
/* Compiler settings for .\IDCardActiveX.idl:
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


#ifndef __IDCardActiveXidl_h__
#define __IDCardActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DIDCardActiveX_FWD_DEFINED__
#define ___DIDCardActiveX_FWD_DEFINED__
typedef interface _DIDCardActiveX _DIDCardActiveX;
#endif 	/* ___DIDCardActiveX_FWD_DEFINED__ */


#ifndef ___DIDCardActiveXEvents_FWD_DEFINED__
#define ___DIDCardActiveXEvents_FWD_DEFINED__
typedef interface _DIDCardActiveXEvents _DIDCardActiveXEvents;
#endif 	/* ___DIDCardActiveXEvents_FWD_DEFINED__ */


#ifndef __IDCardActiveX_FWD_DEFINED__
#define __IDCardActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class IDCardActiveX IDCardActiveX;
#else
typedef struct IDCardActiveX IDCardActiveX;
#endif /* __cplusplus */

#endif 	/* __IDCardActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __IDCardActiveXLib_LIBRARY_DEFINED__
#define __IDCardActiveXLib_LIBRARY_DEFINED__

/* library IDCardActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_IDCardActiveXLib;

#ifndef ___DIDCardActiveX_DISPINTERFACE_DEFINED__
#define ___DIDCardActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DIDCardActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DIDCardActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("CE963D6C-DA9E-4E6F-AEAC-7F27F1248DE1")
    _DIDCardActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DIDCardActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DIDCardActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DIDCardActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DIDCardActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DIDCardActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DIDCardActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DIDCardActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DIDCardActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DIDCardActiveXVtbl;

    interface _DIDCardActiveX
    {
        CONST_VTBL struct _DIDCardActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DIDCardActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DIDCardActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DIDCardActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DIDCardActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DIDCardActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DIDCardActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DIDCardActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DIDCardActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DIDCardActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DIDCardActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DIDCardActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DIDCardActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("F356B5E6-5D6A-4691-A52C-87B523F60173")
    _DIDCardActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DIDCardActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DIDCardActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DIDCardActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DIDCardActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DIDCardActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DIDCardActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DIDCardActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DIDCardActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DIDCardActiveXEventsVtbl;

    interface _DIDCardActiveXEvents
    {
        CONST_VTBL struct _DIDCardActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DIDCardActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DIDCardActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DIDCardActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DIDCardActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DIDCardActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DIDCardActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DIDCardActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DIDCardActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_IDCardActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("FD63286F-7A4F-4C01-9605-2163C1ED1190")
IDCardActiveX;
#endif
#endif /* __IDCardActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


