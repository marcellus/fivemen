

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:37:33 2011
 */
/* Compiler settings for .\ETTSelfHotPrinterActiveX.idl:
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


#ifndef __ETTSelfHotPrinterActiveXidl_h__
#define __ETTSelfHotPrinterActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTSelfHotPrinterActiveX_FWD_DEFINED__
#define ___DETTSelfHotPrinterActiveX_FWD_DEFINED__
typedef interface _DETTSelfHotPrinterActiveX _DETTSelfHotPrinterActiveX;
#endif 	/* ___DETTSelfHotPrinterActiveX_FWD_DEFINED__ */


#ifndef ___DETTSelfHotPrinterActiveXEvents_FWD_DEFINED__
#define ___DETTSelfHotPrinterActiveXEvents_FWD_DEFINED__
typedef interface _DETTSelfHotPrinterActiveXEvents _DETTSelfHotPrinterActiveXEvents;
#endif 	/* ___DETTSelfHotPrinterActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTSelfHotPrinterActiveX_FWD_DEFINED__
#define __ETTSelfHotPrinterActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTSelfHotPrinterActiveX ETTSelfHotPrinterActiveX;
#else
typedef struct ETTSelfHotPrinterActiveX ETTSelfHotPrinterActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTSelfHotPrinterActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTSelfHotPrinterActiveXLib_LIBRARY_DEFINED__
#define __ETTSelfHotPrinterActiveXLib_LIBRARY_DEFINED__

/* library ETTSelfHotPrinterActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTSelfHotPrinterActiveXLib;

#ifndef ___DETTSelfHotPrinterActiveX_DISPINTERFACE_DEFINED__
#define ___DETTSelfHotPrinterActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfHotPrinterActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfHotPrinterActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("4FE5156D-091B-4A4B-98A0-E9856622D7D5")
    _DETTSelfHotPrinterActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfHotPrinterActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfHotPrinterActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfHotPrinterActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfHotPrinterActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfHotPrinterActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfHotPrinterActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfHotPrinterActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfHotPrinterActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfHotPrinterActiveXVtbl;

    interface _DETTSelfHotPrinterActiveX
    {
        CONST_VTBL struct _DETTSelfHotPrinterActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfHotPrinterActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfHotPrinterActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfHotPrinterActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfHotPrinterActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfHotPrinterActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfHotPrinterActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfHotPrinterActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfHotPrinterActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTSelfHotPrinterActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTSelfHotPrinterActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfHotPrinterActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfHotPrinterActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("BBBBCF47-F600-4371-8DD3-3641C9DA182E")
    _DETTSelfHotPrinterActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfHotPrinterActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfHotPrinterActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfHotPrinterActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfHotPrinterActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfHotPrinterActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfHotPrinterActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfHotPrinterActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfHotPrinterActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfHotPrinterActiveXEventsVtbl;

    interface _DETTSelfHotPrinterActiveXEvents
    {
        CONST_VTBL struct _DETTSelfHotPrinterActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfHotPrinterActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfHotPrinterActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfHotPrinterActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfHotPrinterActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfHotPrinterActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfHotPrinterActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfHotPrinterActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfHotPrinterActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTSelfHotPrinterActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("CADA7DA3-25C6-43E6-B5C5-7A5E949A5296")
ETTSelfHotPrinterActiveX;
#endif
#endif /* __ETTSelfHotPrinterActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


