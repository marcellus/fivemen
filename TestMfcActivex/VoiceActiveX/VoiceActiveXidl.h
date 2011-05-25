

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Tue May 10 22:39:03 2011
 */
/* Compiler settings for .\VoiceActiveX.idl:
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


#ifndef __VoiceActiveXidl_h__
#define __VoiceActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DVoiceActiveX_FWD_DEFINED__
#define ___DVoiceActiveX_FWD_DEFINED__
typedef interface _DVoiceActiveX _DVoiceActiveX;
#endif 	/* ___DVoiceActiveX_FWD_DEFINED__ */


#ifndef ___DVoiceActiveXEvents_FWD_DEFINED__
#define ___DVoiceActiveXEvents_FWD_DEFINED__
typedef interface _DVoiceActiveXEvents _DVoiceActiveXEvents;
#endif 	/* ___DVoiceActiveXEvents_FWD_DEFINED__ */


#ifndef __VoiceActiveX_FWD_DEFINED__
#define __VoiceActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class VoiceActiveX VoiceActiveX;
#else
typedef struct VoiceActiveX VoiceActiveX;
#endif /* __cplusplus */

#endif 	/* __VoiceActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __VoiceActiveXLib_LIBRARY_DEFINED__
#define __VoiceActiveXLib_LIBRARY_DEFINED__

/* library VoiceActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_VoiceActiveXLib;

#ifndef ___DVoiceActiveX_DISPINTERFACE_DEFINED__
#define ___DVoiceActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DVoiceActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DVoiceActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D1742149-26BE-4081-AA2A-0535AC92F971")
    _DVoiceActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DVoiceActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DVoiceActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DVoiceActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DVoiceActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DVoiceActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DVoiceActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DVoiceActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DVoiceActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DVoiceActiveXVtbl;

    interface _DVoiceActiveX
    {
        CONST_VTBL struct _DVoiceActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DVoiceActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DVoiceActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DVoiceActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DVoiceActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DVoiceActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DVoiceActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DVoiceActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DVoiceActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DVoiceActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DVoiceActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DVoiceActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DVoiceActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("4D3FD060-59E1-4CF3-9B46-9FFCFE489460")
    _DVoiceActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DVoiceActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DVoiceActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DVoiceActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DVoiceActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DVoiceActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DVoiceActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DVoiceActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DVoiceActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DVoiceActiveXEventsVtbl;

    interface _DVoiceActiveXEvents
    {
        CONST_VTBL struct _DVoiceActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DVoiceActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DVoiceActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DVoiceActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DVoiceActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DVoiceActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DVoiceActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DVoiceActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DVoiceActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_VoiceActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("3BE2B9A6-A746-40AE-A54E-705EFB3C98E2")
VoiceActiveX;
#endif
#endif /* __VoiceActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


