

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:35:34 2011
 */
/* Compiler settings for .\ETTSelfUSBVideoActiveX.idl:
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


#ifndef __ETTSelfUSBVideoActiveXidl_h__
#define __ETTSelfUSBVideoActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTSelfUSBVideoActiveX_FWD_DEFINED__
#define ___DETTSelfUSBVideoActiveX_FWD_DEFINED__
typedef interface _DETTSelfUSBVideoActiveX _DETTSelfUSBVideoActiveX;
#endif 	/* ___DETTSelfUSBVideoActiveX_FWD_DEFINED__ */


#ifndef ___DETTSelfUSBVideoActiveXEvents_FWD_DEFINED__
#define ___DETTSelfUSBVideoActiveXEvents_FWD_DEFINED__
typedef interface _DETTSelfUSBVideoActiveXEvents _DETTSelfUSBVideoActiveXEvents;
#endif 	/* ___DETTSelfUSBVideoActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTSelfUSBVideoActiveX_FWD_DEFINED__
#define __ETTSelfUSBVideoActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTSelfUSBVideoActiveX ETTSelfUSBVideoActiveX;
#else
typedef struct ETTSelfUSBVideoActiveX ETTSelfUSBVideoActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTSelfUSBVideoActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTSelfUSBVideoActiveXLib_LIBRARY_DEFINED__
#define __ETTSelfUSBVideoActiveXLib_LIBRARY_DEFINED__

/* library ETTSelfUSBVideoActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTSelfUSBVideoActiveXLib;

#ifndef ___DETTSelfUSBVideoActiveX_DISPINTERFACE_DEFINED__
#define ___DETTSelfUSBVideoActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfUSBVideoActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfUSBVideoActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("922573C6-1BED-4891-B7B1-013905375763")
    _DETTSelfUSBVideoActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfUSBVideoActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfUSBVideoActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfUSBVideoActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfUSBVideoActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfUSBVideoActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfUSBVideoActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfUSBVideoActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfUSBVideoActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfUSBVideoActiveXVtbl;

    interface _DETTSelfUSBVideoActiveX
    {
        CONST_VTBL struct _DETTSelfUSBVideoActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfUSBVideoActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfUSBVideoActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfUSBVideoActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfUSBVideoActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfUSBVideoActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfUSBVideoActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfUSBVideoActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfUSBVideoActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTSelfUSBVideoActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTSelfUSBVideoActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTSelfUSBVideoActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTSelfUSBVideoActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("5055CF7F-7352-4ECF-BAF3-9183FF65281E")
    _DETTSelfUSBVideoActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTSelfUSBVideoActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTSelfUSBVideoActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTSelfUSBVideoActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTSelfUSBVideoActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTSelfUSBVideoActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTSelfUSBVideoActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTSelfUSBVideoActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTSelfUSBVideoActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTSelfUSBVideoActiveXEventsVtbl;

    interface _DETTSelfUSBVideoActiveXEvents
    {
        CONST_VTBL struct _DETTSelfUSBVideoActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTSelfUSBVideoActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTSelfUSBVideoActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTSelfUSBVideoActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTSelfUSBVideoActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTSelfUSBVideoActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTSelfUSBVideoActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTSelfUSBVideoActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTSelfUSBVideoActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTSelfUSBVideoActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("07970878-4C36-470C-ACDC-9AB36FA2084B")
ETTSelfUSBVideoActiveX;
#endif
#endif /* __ETTSelfUSBVideoActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


