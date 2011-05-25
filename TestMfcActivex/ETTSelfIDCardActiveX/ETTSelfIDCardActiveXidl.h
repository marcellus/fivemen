

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:36:39 2011
 */
/* Compiler settings for .\ETTSelfIDCardActiveX.idl:
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


#ifndef __ETTSelfIDCardActiveXidl_h__
#define __ETTSelfIDCardActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTSelfIDCardActiveX_FWD_DEFINED__
#define ___DETTSelfIDCardActiveX_FWD_DEFINED__
typedef interface _DETTSelfIDCardActiveX _DETTSelfIDCardActiveX;
#endif 	/* ___DETTSelfIDCardActiveX_FWD_DEFINED__ */


#ifndef ___DETTSelfIDCardActiveXEvents_FWD_DEFINED__
#define ___DETTSelfIDCardActiveXEvents_FWD_DEFINED__
typedef interface _DETTSelfIDCardActiveXEvents _DETTSelfIDCardActiveXEvents;
#endif 	/* ___DETTSelfIDCardActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTSelfIDCardActiveX_FWD_DEFINED__
#define __ETTSelfIDCardActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTSelfIDCardActiveX ETTSelfIDCardActiveX;
#else
typedef struct ETTSelfIDCardActiveX ETTSelfIDCardActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTSelfIDCardActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTSelfIDCardActiveXLib_LIBRARY_DEFINED__
#define __ETTSelfIDCardActiveXLib_LIBRARY_DEFINED__

/* library ETTSelfIDCardActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTSelfIDCardActiveXLib;

#ifndef ___DETTSelfIDCardActiveX_DISPINTERFACE_DEFINED__
#define ___DETTSelfIDCardActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfIDCardActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfIDCardActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("BC755F0E-4F1C-46A2-8C10-97E364974865")
    _DETTSelfIDCardActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfIDCardActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfIDCardActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfIDCardActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfIDCardActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfIDCardActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfIDCardActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfIDCardActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfIDCardActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfIDCardActiveXVtbl;

    interface _DETTSelfIDCardActiveX
    {
        CONST_VTBL struct _DETTSelfIDCardActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfIDCardActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfIDCardActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfIDCardActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfIDCardActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfIDCardActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfIDCardActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfIDCardActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfIDCardActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTSelfIDCardActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTSelfIDCardActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfIDCardActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfIDCardActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("097A9E85-C96F-4B0F-B494-8D906D13E2EB")
    _DETTSelfIDCardActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfIDCardActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfIDCardActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfIDCardActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfIDCardActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfIDCardActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfIDCardActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfIDCardActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfIDCardActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfIDCardActiveXEventsVtbl;

    interface _DETTSelfIDCardActiveXEvents
    {
        CONST_VTBL struct _DETTSelfIDCardActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfIDCardActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfIDCardActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfIDCardActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfIDCardActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfIDCardActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfIDCardActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfIDCardActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfIDCardActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTSelfIDCardActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("447C4906-6678-461B-9E20-100BDE913828")
ETTSelfIDCardActiveX;
#endif
#endif /* __ETTSelfIDCardActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


