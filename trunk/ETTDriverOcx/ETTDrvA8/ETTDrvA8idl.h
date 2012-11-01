

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Nov 01 15:50:08 2012
 */
/* Compiler settings for .\ETTDrvA8.idl:
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


#ifndef __ETTDrvA8idl_h__
#define __ETTDrvA8idl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTDrvA8_FWD_DEFINED__
#define ___DETTDrvA8_FWD_DEFINED__
typedef interface _DETTDrvA8 _DETTDrvA8;
#endif 	/* ___DETTDrvA8_FWD_DEFINED__ */


#ifndef ___DETTDrvA8Events_FWD_DEFINED__
#define ___DETTDrvA8Events_FWD_DEFINED__
typedef interface _DETTDrvA8Events _DETTDrvA8Events;
#endif 	/* ___DETTDrvA8Events_FWD_DEFINED__ */


#ifndef __ETTDrvA8_FWD_DEFINED__
#define __ETTDrvA8_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTDrvA8 ETTDrvA8;
#else
typedef struct ETTDrvA8 ETTDrvA8;
#endif /* __cplusplus */

#endif 	/* __ETTDrvA8_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTDrvA8Lib_LIBRARY_DEFINED__
#define __ETTDrvA8Lib_LIBRARY_DEFINED__

/* library ETTDrvA8Lib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTDrvA8Lib;

#ifndef ___DETTDrvA8_DISPINTERFACE_DEFINED__
#define ___DETTDrvA8_DISPINTERFACE_DEFINED__

/* dispinterface _DETTDrvA8 */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTDrvA8;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("FC198BC9-9B80-49AD-BDF7-B5EB38ECBCE4")
    _DETTDrvA8 : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTDrvA8Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTDrvA8 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTDrvA8 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTDrvA8 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTDrvA8 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTDrvA8 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTDrvA8 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTDrvA8 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTDrvA8Vtbl;

    interface _DETTDrvA8
    {
        CONST_VTBL struct _DETTDrvA8Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTDrvA8_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTDrvA8_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTDrvA8_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTDrvA8_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTDrvA8_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTDrvA8_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTDrvA8_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTDrvA8_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTDrvA8Events_DISPINTERFACE_DEFINED__
#define ___DETTDrvA8Events_DISPINTERFACE_DEFINED__

/* dispinterface _DETTDrvA8Events */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTDrvA8Events;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("E5780630-B504-44BE-8B73-EA3E73C1D718")
    _DETTDrvA8Events : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTDrvA8EventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTDrvA8Events * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTDrvA8Events * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTDrvA8Events * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTDrvA8Events * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTDrvA8Events * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTDrvA8Events * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTDrvA8Events * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTDrvA8EventsVtbl;

    interface _DETTDrvA8Events
    {
        CONST_VTBL struct _DETTDrvA8EventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTDrvA8Events_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTDrvA8Events_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTDrvA8Events_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTDrvA8Events_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTDrvA8Events_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTDrvA8Events_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTDrvA8Events_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTDrvA8Events_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTDrvA8;

#ifdef __cplusplus

class DECLSPEC_UUID("B64A8AD1-0B76-4D7B-92A6-B88519254091")
ETTDrvA8;
#endif
#endif /* __ETTDrvA8Lib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


