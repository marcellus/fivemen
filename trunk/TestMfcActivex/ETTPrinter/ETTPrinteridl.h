

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:34:25 2011
 */
/* Compiler settings for .\ETTPrinter.idl:
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


#ifndef __ETTPrinteridl_h__
#define __ETTPrinteridl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTPrinter_FWD_DEFINED__
#define ___DETTPrinter_FWD_DEFINED__
typedef interface _DETTPrinter _DETTPrinter;
#endif 	/* ___DETTPrinter_FWD_DEFINED__ */


#ifndef ___DETTPrinterEvents_FWD_DEFINED__
#define ___DETTPrinterEvents_FWD_DEFINED__
typedef interface _DETTPrinterEvents _DETTPrinterEvents;
#endif 	/* ___DETTPrinterEvents_FWD_DEFINED__ */


#ifndef __ETTPrinter_FWD_DEFINED__
#define __ETTPrinter_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTPrinter ETTPrinter;
#else
typedef struct ETTPrinter ETTPrinter;
#endif /* __cplusplus */

#endif 	/* __ETTPrinter_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTPrinterLib_LIBRARY_DEFINED__
#define __ETTPrinterLib_LIBRARY_DEFINED__

/* library ETTPrinterLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTPrinterLib;

#ifndef ___DETTPrinter_DISPINTERFACE_DEFINED__
#define ___DETTPrinter_DISPINTERFACE_DEFINED__

/* dispinterface _DETTPrinter */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTPrinter;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("2F34318A-00C9-4BA3-A13B-E3C89239E815")
    _DETTPrinter : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTPrinterVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTPrinter * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTPrinter * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTPrinter * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTPrinter * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTPrinter * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTPrinter * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTPrinter * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTPrinterVtbl;

    interface _DETTPrinter
    {
        CONST_VTBL struct _DETTPrinterVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTPrinter_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTPrinter_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTPrinter_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTPrinter_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTPrinter_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTPrinter_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTPrinter_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTPrinter_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTPrinterEvents_DISPINTERFACE_DEFINED__
#define ___DETTPrinterEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTPrinterEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTPrinterEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("B964845C-BDE0-46E8-A5C1-071D57029D4F")
    _DETTPrinterEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTPrinterEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTPrinterEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTPrinterEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTPrinterEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTPrinterEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTPrinterEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTPrinterEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTPrinterEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTPrinterEventsVtbl;

    interface _DETTPrinterEvents
    {
        CONST_VTBL struct _DETTPrinterEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTPrinterEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTPrinterEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTPrinterEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTPrinterEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTPrinterEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTPrinterEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTPrinterEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTPrinterEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTPrinter;

#ifdef __cplusplus

class DECLSPEC_UUID("08A5FF49-503B-4518-8016-87F4AF50D7A1")
ETTPrinter;
#endif
#endif /* __ETTPrinterLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


