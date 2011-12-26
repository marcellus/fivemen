

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Sep 23 22:59:52 2011
 */
/* Compiler settings for .\ETTUP.idl:
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


#ifndef __ETTUPidl_h__
#define __ETTUPidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTUP_FWD_DEFINED__
#define ___DETTUP_FWD_DEFINED__
typedef interface _DETTUP _DETTUP;
#endif 	/* ___DETTUP_FWD_DEFINED__ */


#ifndef ___DETTUPEvents_FWD_DEFINED__
#define ___DETTUPEvents_FWD_DEFINED__
typedef interface _DETTUPEvents _DETTUPEvents;
#endif 	/* ___DETTUPEvents_FWD_DEFINED__ */


#ifndef __ETTUP_FWD_DEFINED__
#define __ETTUP_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTUP ETTUP;
#else
typedef struct ETTUP ETTUP;
#endif /* __cplusplus */

#endif 	/* __ETTUP_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTUPLib_LIBRARY_DEFINED__
#define __ETTUPLib_LIBRARY_DEFINED__

/* library ETTUPLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTUPLib;

#ifndef ___DETTUP_DISPINTERFACE_DEFINED__
#define ___DETTUP_DISPINTERFACE_DEFINED__

/* dispinterface _DETTUP */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTUP;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("E4350F3B-8F66-4871-8A33-81515276A01D")
    _DETTUP : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTUPVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTUP * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTUP * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTUP * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTUP * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTUP * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTUP * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTUP * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTUPVtbl;

    interface _DETTUP
    {
        CONST_VTBL struct _DETTUPVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTUP_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTUP_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTUP_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTUP_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTUP_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTUP_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTUP_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTUP_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTUPEvents_DISPINTERFACE_DEFINED__
#define ___DETTUPEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTUPEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTUPEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("FDC4BAFF-5206-428D-8C0D-D89201D2EF7F")
    _DETTUPEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTUPEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTUPEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTUPEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTUPEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTUPEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTUPEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTUPEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTUPEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTUPEventsVtbl;

    interface _DETTUPEvents
    {
        CONST_VTBL struct _DETTUPEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTUPEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTUPEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTUPEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTUPEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTUPEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTUPEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTUPEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTUPEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTUP;

#ifdef __cplusplus

class DECLSPEC_UUID("DC25E28D-C0C6-4F6C-B9E5-3212146C5EBD")
ETTUP;
#endif
#endif /* __ETTUPLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


