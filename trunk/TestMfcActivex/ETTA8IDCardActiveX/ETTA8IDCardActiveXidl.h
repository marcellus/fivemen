

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri May 13 15:27:33 2011
 */
/* Compiler settings for .\ETTA8IDCardActiveX.idl:
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


#ifndef __ETTA8IDCardActiveXidl_h__
#define __ETTA8IDCardActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DETTA8IDCardActiveX_FWD_DEFINED__
#define ___DETTA8IDCardActiveX_FWD_DEFINED__
typedef interface _DETTA8IDCardActiveX _DETTA8IDCardActiveX;
#endif 	/* ___DETTA8IDCardActiveX_FWD_DEFINED__ */


#ifndef ___DETTA8IDCardActiveXEvents_FWD_DEFINED__
#define ___DETTA8IDCardActiveXEvents_FWD_DEFINED__
typedef interface _DETTA8IDCardActiveXEvents _DETTA8IDCardActiveXEvents;
#endif 	/* ___DETTA8IDCardActiveXEvents_FWD_DEFINED__ */


#ifndef __ETTA8IDCardActiveX_FWD_DEFINED__
#define __ETTA8IDCardActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class ETTA8IDCardActiveX ETTA8IDCardActiveX;
#else
typedef struct ETTA8IDCardActiveX ETTA8IDCardActiveX;
#endif /* __cplusplus */

#endif 	/* __ETTA8IDCardActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __ETTA8IDCardActiveXLib_LIBRARY_DEFINED__
#define __ETTA8IDCardActiveXLib_LIBRARY_DEFINED__

/* library ETTA8IDCardActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_ETTA8IDCardActiveXLib;

#ifndef ___DETTA8IDCardActiveX_DISPINTERFACE_DEFINED__
#define ___DETTA8IDCardActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DETTA8IDCardActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTA8IDCardActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("A3041BBA-5CA8-4D06-8F7F-9F269FD07953")
    _DETTA8IDCardActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTA8IDCardActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTA8IDCardActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTA8IDCardActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTA8IDCardActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTA8IDCardActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTA8IDCardActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTA8IDCardActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTA8IDCardActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTA8IDCardActiveXVtbl;

    interface _DETTA8IDCardActiveX
    {
        CONST_VTBL struct _DETTA8IDCardActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTA8IDCardActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTA8IDCardActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTA8IDCardActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTA8IDCardActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTA8IDCardActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTA8IDCardActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTA8IDCardActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTA8IDCardActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DETTA8IDCardActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DETTA8IDCardActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DETTA8IDCardActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DETTA8IDCardActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("9458A5D9-FD14-4776-8871-31060796BB47")
    _DETTA8IDCardActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DETTA8IDCardActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DETTA8IDCardActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DETTA8IDCardActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DETTA8IDCardActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DETTA8IDCardActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DETTA8IDCardActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DETTA8IDCardActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DETTA8IDCardActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DETTA8IDCardActiveXEventsVtbl;

    interface _DETTA8IDCardActiveXEvents
    {
        CONST_VTBL struct _DETTA8IDCardActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DETTA8IDCardActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DETTA8IDCardActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DETTA8IDCardActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DETTA8IDCardActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DETTA8IDCardActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DETTA8IDCardActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DETTA8IDCardActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DETTA8IDCardActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ETTA8IDCardActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("C504828D-BB8D-4D2F-AA5C-7ED3797A8CA2")
ETTA8IDCardActiveX;
#endif
#endif /* __ETTA8IDCardActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


