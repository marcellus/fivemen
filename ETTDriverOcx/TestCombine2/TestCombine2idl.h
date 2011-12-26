

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Sep 15 11:14:25 2011
 */
/* Compiler settings for .\TestCombine2.idl:
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


#ifndef __TestCombine2idl_h__
#define __TestCombine2idl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DTestCombine2_FWD_DEFINED__
#define ___DTestCombine2_FWD_DEFINED__
typedef interface _DTestCombine2 _DTestCombine2;
#endif 	/* ___DTestCombine2_FWD_DEFINED__ */


#ifndef ___DTestCombine2Events_FWD_DEFINED__
#define ___DTestCombine2Events_FWD_DEFINED__
typedef interface _DTestCombine2Events _DTestCombine2Events;
#endif 	/* ___DTestCombine2Events_FWD_DEFINED__ */


#ifndef __TestCombine2_FWD_DEFINED__
#define __TestCombine2_FWD_DEFINED__

#ifdef __cplusplus
typedef class TestCombine2 TestCombine2;
#else
typedef struct TestCombine2 TestCombine2;
#endif /* __cplusplus */

#endif 	/* __TestCombine2_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __TestCombine2Lib_LIBRARY_DEFINED__
#define __TestCombine2Lib_LIBRARY_DEFINED__

/* library TestCombine2Lib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_TestCombine2Lib;

#ifndef ___DTestCombine2_DISPINTERFACE_DEFINED__
#define ___DTestCombine2_DISPINTERFACE_DEFINED__

/* dispinterface _DTestCombine2 */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DTestCombine2;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("7265DE52-FDE8-44C9-B6AA-ADA341AE3338")
    _DTestCombine2 : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DTestCombine2Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DTestCombine2 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DTestCombine2 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DTestCombine2 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DTestCombine2 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DTestCombine2 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DTestCombine2 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DTestCombine2 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DTestCombine2Vtbl;

    interface _DTestCombine2
    {
        CONST_VTBL struct _DTestCombine2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DTestCombine2_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DTestCombine2_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DTestCombine2_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DTestCombine2_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DTestCombine2_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DTestCombine2_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DTestCombine2_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DTestCombine2_DISPINTERFACE_DEFINED__ */


#ifndef ___DTestCombine2Events_DISPINTERFACE_DEFINED__
#define ___DTestCombine2Events_DISPINTERFACE_DEFINED__

/* dispinterface _DTestCombine2Events */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DTestCombine2Events;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("4757EEFE-940C-4C06-BA0D-B654500E39E7")
    _DTestCombine2Events : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DTestCombine2EventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DTestCombine2Events * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DTestCombine2Events * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DTestCombine2Events * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DTestCombine2Events * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DTestCombine2Events * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DTestCombine2Events * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DTestCombine2Events * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DTestCombine2EventsVtbl;

    interface _DTestCombine2Events
    {
        CONST_VTBL struct _DTestCombine2EventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DTestCombine2Events_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DTestCombine2Events_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DTestCombine2Events_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DTestCombine2Events_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DTestCombine2Events_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DTestCombine2Events_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DTestCombine2Events_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DTestCombine2Events_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TestCombine2;

#ifdef __cplusplus

class DECLSPEC_UUID("EECAE990-8734-4964-BBC5-300525E9362C")
TestCombine2;
#endif
#endif /* __TestCombine2Lib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


