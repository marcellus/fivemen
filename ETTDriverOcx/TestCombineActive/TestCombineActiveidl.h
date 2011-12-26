

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Sep 15 10:20:34 2011
 */
/* Compiler settings for .\TestCombineActive.idl:
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


#ifndef __TestCombineActiveidl_h__
#define __TestCombineActiveidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DTestCombineActive_FWD_DEFINED__
#define ___DTestCombineActive_FWD_DEFINED__
typedef interface _DTestCombineActive _DTestCombineActive;
#endif 	/* ___DTestCombineActive_FWD_DEFINED__ */


#ifndef ___DTestCombineActiveEvents_FWD_DEFINED__
#define ___DTestCombineActiveEvents_FWD_DEFINED__
typedef interface _DTestCombineActiveEvents _DTestCombineActiveEvents;
#endif 	/* ___DTestCombineActiveEvents_FWD_DEFINED__ */


#ifndef __TestCombineActive_FWD_DEFINED__
#define __TestCombineActive_FWD_DEFINED__

#ifdef __cplusplus
typedef class TestCombineActive TestCombineActive;
#else
typedef struct TestCombineActive TestCombineActive;
#endif /* __cplusplus */

#endif 	/* __TestCombineActive_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __TestCombineActiveLib_LIBRARY_DEFINED__
#define __TestCombineActiveLib_LIBRARY_DEFINED__

/* library TestCombineActiveLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_TestCombineActiveLib;

#ifndef ___DTestCombineActive_DISPINTERFACE_DEFINED__
#define ___DTestCombineActive_DISPINTERFACE_DEFINED__

/* dispinterface _DTestCombineActive */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DTestCombineActive;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("C761E55F-DED9-41BD-B446-22365F851E1A")
    _DTestCombineActive : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DTestCombineActiveVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DTestCombineActive * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DTestCombineActive * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DTestCombineActive * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DTestCombineActive * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DTestCombineActive * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DTestCombineActive * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DTestCombineActive * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DTestCombineActiveVtbl;

    interface _DTestCombineActive
    {
        CONST_VTBL struct _DTestCombineActiveVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DTestCombineActive_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DTestCombineActive_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DTestCombineActive_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DTestCombineActive_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DTestCombineActive_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DTestCombineActive_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DTestCombineActive_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DTestCombineActive_DISPINTERFACE_DEFINED__ */


#ifndef ___DTestCombineActiveEvents_DISPINTERFACE_DEFINED__
#define ___DTestCombineActiveEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DTestCombineActiveEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DTestCombineActiveEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("1C0CB663-D6DC-4AED-B3E4-F08BE43B7B45")
    _DTestCombineActiveEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DTestCombineActiveEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DTestCombineActiveEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DTestCombineActiveEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DTestCombineActiveEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DTestCombineActiveEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DTestCombineActiveEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DTestCombineActiveEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DTestCombineActiveEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DTestCombineActiveEventsVtbl;

    interface _DTestCombineActiveEvents
    {
        CONST_VTBL struct _DTestCombineActiveEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DTestCombineActiveEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DTestCombineActiveEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DTestCombineActiveEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DTestCombineActiveEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DTestCombineActiveEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DTestCombineActiveEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DTestCombineActiveEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DTestCombineActiveEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TestCombineActive;

#ifdef __cplusplus

class DECLSPEC_UUID("8128503E-4D53-4B22-ABB3-88A28C8991A1")
TestCombineActive;
#endif
#endif /* __TestCombineActiveLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


