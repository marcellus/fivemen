

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:35:34 2011
 */
/* Compiler settings for .\ETTSelfPrinterActiveX.idl:
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


#ifndef __ETTSelfPrinterActiveXidl_h__
#define __ETTSelfPrinterActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTSelfPrinterActiveX_FWD_DEFINED__
#define ___DETTSelfPrinterActiveX_FWD_DEFINED__
typedef interface _DETTSelfPrinterActiveX _DETTSelfPrinterActiveX;
#endif 	/* ___DETTSelfPrinterActiveX_FWD_DEFINED__ */


#ifndef ___DETTSelfPrinterActiveXEvents_FWD_DEFINED__
#define ___DETTSelfPrinterActiveXEvents_FWD_DEFINED__
typedef interface _DETTSelfPrinterActiveXEvents _DETTSelfPrinterActiveXEvents;
#endif 	/* ___DETTSelfPrinterActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTSelfPrinterActiveX_FWD_DEFINED__
#define __ETTSelfPrinterActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTSelfPrinterActiveX ETTSelfPrinterActiveX;
#else
typedef struct ETTSelfPrinterActiveX ETTSelfPrinterActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTSelfPrinterActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTSelfPrinterActiveXLib_LIBRARY_DEFINED__
#define __ETTSelfPrinterActiveXLib_LIBRARY_DEFINED__

/* library ETTSelfPrinterActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTSelfPrinterActiveXLib;

#ifndef ___DETTSelfPrinterActiveX_DISPINTERFACE_DEFINED__
#define ___DETTSelfPrinterActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfPrinterActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfPrinterActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D30B98E7-F1BB-402D-8E60-6D7FAD93F628")
    _DETTSelfPrinterActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfPrinterActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfPrinterActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfPrinterActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfPrinterActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfPrinterActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfPrinterActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfPrinterActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfPrinterActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfPrinterActiveXVtbl;

    interface _DETTSelfPrinterActiveX
    {
        CONST_VTBL struct _DETTSelfPrinterActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfPrinterActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfPrinterActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfPrinterActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfPrinterActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfPrinterActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfPrinterActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfPrinterActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfPrinterActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTSelfPrinterActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTSelfPrinterActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfPrinterActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfPrinterActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("889818F0-7383-4B13-A150-6E777278ABBC")
    _DETTSelfPrinterActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfPrinterActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfPrinterActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfPrinterActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfPrinterActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfPrinterActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfPrinterActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfPrinterActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfPrinterActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfPrinterActiveXEventsVtbl;

    interface _DETTSelfPrinterActiveXEvents
    {
        CONST_VTBL struct _DETTSelfPrinterActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfPrinterActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfPrinterActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfPrinterActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfPrinterActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfPrinterActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfPrinterActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfPrinterActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfPrinterActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTSelfPrinterActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("4F193682-5451-4CD5-8340-63DD04D2FAD9")
ETTSelfPrinterActiveX;
#endif
#endif /* __ETTSelfPrinterActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


