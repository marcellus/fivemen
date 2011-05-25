

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:11:13 2011
 */
/* Compiler settings for .\TestMfcActivex.idl:
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


#ifndef __TestMfcActivexidl_h__
#define __TestMfcActivexidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DTestMfcActivex_FWD_DEFINED__
#define ___DTestMfcActivex_FWD_DEFINED__
typedef interface _DTestMfcActivex _DTestMfcActivex;
#endif 	/* ___DTestMfcActivex_FWD_DEFINED__ */


#ifndef ___DTestMfcActivexEvents_FWD_DEFINED__
#define ___DTestMfcActivexEvents_FWD_DEFINED__
typedef interface _DTestMfcActivexEvents _DTestMfcActivexEvents;
#endif 	/* ___DTestMfcActivexEvents_FWD_DEFINED__ */


#ifndef __TestMfcActivex_FWD_DEFINED__
#define __TestMfcActivex_FWD_DEFINED__

#ifdef __cplusplus
typedef class TestMfcActivex TestMfcActivex;
#else
typedef struct TestMfcActivex TestMfcActivex;
#endif /* __cplusplus */

#endif 	/* __TestMfcActivex_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __TestMfcActivexLib_LIBRARY_DEFINED__
#define __TestMfcActivexLib_LIBRARY_DEFINED__

/* library TestMfcActivexLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_TestMfcActivexLib;

#ifndef ___DTestMfcActivex_DISPINTERFACE_DEFINED__
#define ___DTestMfcActivex_DISPINTERFACE_DEFINED__

/* dispinterface _DTestMfcActivex */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DTestMfcActivex;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("8BB622EB-3854-4B1E-B975-1F75BEAD42F5")
    _DTestMfcActivex : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DTestMfcActivexVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DTestMfcActivex * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DTestMfcActivex * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DTestMfcActivex * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DTestMfcActivex * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DTestMfcActivex * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DTestMfcActivex * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DTestMfcActivex * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DTestMfcActivexVtbl;

    interface _DTestMfcActivex
    {
        CONST_VTBL struct _DTestMfcActivexVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DTestMfcActivex_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DTestMfcActivex_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DTestMfcActivex_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DTestMfcActivex_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DTestMfcActivex_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DTestMfcActivex_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DTestMfcActivex_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DTestMfcActivex_DISPINTERFACE_DEFINED__ */


#ifndef ___DTestMfcActivexEvents_DISPINTERFACE_DEFINED__
#define ___DTestMfcActivexEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DTestMfcActivexEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DTestMfcActivexEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D8505EB0-1BCD-4E2F-91AD-115EF4CFAEF8")
    _DTestMfcActivexEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DTestMfcActivexEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DTestMfcActivexEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DTestMfcActivexEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DTestMfcActivexEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DTestMfcActivexEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DTestMfcActivexEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DTestMfcActivexEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DTestMfcActivexEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DTestMfcActivexEventsVtbl;

    interface _DTestMfcActivexEvents
    {
        CONST_VTBL struct _DTestMfcActivexEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DTestMfcActivexEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DTestMfcActivexEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DTestMfcActivexEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DTestMfcActivexEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DTestMfcActivexEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DTestMfcActivexEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DTestMfcActivexEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DTestMfcActivexEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TestMfcActivex;

#ifdef __cplusplus

class DECLSPEC_UUID("E5DF618A-E0CC-4F68-ACB2-155A1D3BAFCA")
TestMfcActivex;
#endif
#endif /* __TestMfcActivexLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


