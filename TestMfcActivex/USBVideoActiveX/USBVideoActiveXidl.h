

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:09:54 2011
 */
/* Compiler settings for .\USBVideoActiveX.idl:
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


#ifndef __USBVideoActiveXidl_h__
#define __USBVideoActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DUSBVideoActiveX_FWD_DEFINED__
#define ___DUSBVideoActiveX_FWD_DEFINED__
typedef interface _DUSBVideoActiveX _DUSBVideoActiveX;
#endif 	/* ___DUSBVideoActiveX_FWD_DEFINED__ */


#ifndef ___DUSBVideoActiveXEvents_FWD_DEFINED__
#define ___DUSBVideoActiveXEvents_FWD_DEFINED__
typedef interface _DUSBVideoActiveXEvents _DUSBVideoActiveXEvents;
#endif 	/* ___DUSBVideoActiveXEvents_FWD_DEFINED__ */


#ifndef __USBVideoActiveX_FWD_DEFINED__
#define __USBVideoActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class USBVideoActiveX USBVideoActiveX;
#else
typedef struct USBVideoActiveX USBVideoActiveX;
#endif /* __cplusplus */

#endif 	/* __USBVideoActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __USBVideoActiveXLib_LIBRARY_DEFINED__
#define __USBVideoActiveXLib_LIBRARY_DEFINED__

/* library USBVideoActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_USBVideoActiveXLib;

#ifndef ___DUSBVideoActiveX_DISPINTERFACE_DEFINED__
#define ___DUSBVideoActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DUSBVideoActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DUSBVideoActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("99D458C9-4608-4ED5-AEE7-43CB5B8210FE")
    _DUSBVideoActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DUSBVideoActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DUSBVideoActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DUSBVideoActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DUSBVideoActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DUSBVideoActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DUSBVideoActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DUSBVideoActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DUSBVideoActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DUSBVideoActiveXVtbl;

    interface _DUSBVideoActiveX
    {
        CONST_VTBL struct _DUSBVideoActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DUSBVideoActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DUSBVideoActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DUSBVideoActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DUSBVideoActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DUSBVideoActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DUSBVideoActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DUSBVideoActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DUSBVideoActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DUSBVideoActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DUSBVideoActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DUSBVideoActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DUSBVideoActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("A0A6C942-950D-40CD-BE76-1E69362D2941")
    _DUSBVideoActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DUSBVideoActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DUSBVideoActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DUSBVideoActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DUSBVideoActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DUSBVideoActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DUSBVideoActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DUSBVideoActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DUSBVideoActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DUSBVideoActiveXEventsVtbl;

    interface _DUSBVideoActiveXEvents
    {
        CONST_VTBL struct _DUSBVideoActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DUSBVideoActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DUSBVideoActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DUSBVideoActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DUSBVideoActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DUSBVideoActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DUSBVideoActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DUSBVideoActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DUSBVideoActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_USBVideoActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("1009CFDD-0FDA-4E6F-8AAC-AA3F38155221")
USBVideoActiveX;
#endif
#endif /* __USBVideoActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


