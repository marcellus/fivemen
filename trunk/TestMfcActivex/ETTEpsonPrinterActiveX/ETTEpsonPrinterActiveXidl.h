

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue Apr 26 15:14:07 2011
 */
/* Compiler settings for .\ETTEpsonPrinterActiveX.idl:
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


#ifndef __ETTEpsonPrinterActiveXidl_h__
#define __ETTEpsonPrinterActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTEpsonPrinterActiveX_FWD_DEFINED__
#define ___DETTEpsonPrinterActiveX_FWD_DEFINED__
typedef interface _DETTEpsonPrinterActiveX _DETTEpsonPrinterActiveX;
#endif 	/* ___DETTEpsonPrinterActiveX_FWD_DEFINED__ */


#ifndef ___DETTEpsonPrinterActiveXEvents_FWD_DEFINED__
#define ___DETTEpsonPrinterActiveXEvents_FWD_DEFINED__
typedef interface _DETTEpsonPrinterActiveXEvents _DETTEpsonPrinterActiveXEvents;
#endif 	/* ___DETTEpsonPrinterActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTEpsonPrinterActiveX_FWD_DEFINED__
#define __ETTEpsonPrinterActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTEpsonPrinterActiveX ETTEpsonPrinterActiveX;
#else
typedef struct ETTEpsonPrinterActiveX ETTEpsonPrinterActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTEpsonPrinterActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTEpsonPrinterActiveXLib_LIBRARY_DEFINED__
#define __ETTEpsonPrinterActiveXLib_LIBRARY_DEFINED__

/* library ETTEpsonPrinterActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTEpsonPrinterActiveXLib;

#ifndef ___DETTEpsonPrinterActiveX_DISPINTERFACE_DEFINED__
#define ___DETTEpsonPrinterActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTEpsonPrinterActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTEpsonPrinterActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("0B6C5706-C674-4856-A342-845A5E1FE55A")
    _DETTEpsonPrinterActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTEpsonPrinterActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTEpsonPrinterActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTEpsonPrinterActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTEpsonPrinterActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTEpsonPrinterActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTEpsonPrinterActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTEpsonPrinterActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTEpsonPrinterActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTEpsonPrinterActiveXVtbl;

    interface _DETTEpsonPrinterActiveX
    {
        CONST_VTBL struct _DETTEpsonPrinterActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTEpsonPrinterActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTEpsonPrinterActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTEpsonPrinterActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTEpsonPrinterActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTEpsonPrinterActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTEpsonPrinterActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTEpsonPrinterActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTEpsonPrinterActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTEpsonPrinterActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTEpsonPrinterActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTEpsonPrinterActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTEpsonPrinterActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("7BD881A4-9BCF-4F89-8BCF-095D160F2801")
    _DETTEpsonPrinterActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTEpsonPrinterActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTEpsonPrinterActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTEpsonPrinterActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTEpsonPrinterActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTEpsonPrinterActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTEpsonPrinterActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTEpsonPrinterActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTEpsonPrinterActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTEpsonPrinterActiveXEventsVtbl;

    interface _DETTEpsonPrinterActiveXEvents
    {
        CONST_VTBL struct _DETTEpsonPrinterActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTEpsonPrinterActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTEpsonPrinterActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTEpsonPrinterActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTEpsonPrinterActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTEpsonPrinterActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTEpsonPrinterActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTEpsonPrinterActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTEpsonPrinterActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTEpsonPrinterActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("55F3EC13-28AB-469E-98DE-82E862703FC0")
ETTEpsonPrinterActiveX;
#endif
#endif /* __ETTEpsonPrinterActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


