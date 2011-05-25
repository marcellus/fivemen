

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Fri Apr 01 00:10:47 2011
 */
/* Compiler settings for .\IdCardReaderActiveX.idl:
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


#ifndef __IdCardReaderActiveXidl_h__
#define __IdCardReaderActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DIdCardReaderActiveX_FWD_DEFINED__
#define ___DIdCardReaderActiveX_FWD_DEFINED__
typedef interface _DIdCardReaderActiveX _DIdCardReaderActiveX;
#endif 	/* ___DIdCardReaderActiveX_FWD_DEFINED__ */


#ifndef ___DIdCardReaderActiveXEvents_FWD_DEFINED__
#define ___DIdCardReaderActiveXEvents_FWD_DEFINED__
typedef interface _DIdCardReaderActiveXEvents _DIdCardReaderActiveXEvents;
#endif 	/* ___DIdCardReaderActiveXEvents_FWD_DEFINED__ */


#ifndef __IdCardReaderActiveX_FWD_DEFINED__
#define __IdCardReaderActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class IdCardReaderActiveX IdCardReaderActiveX;
#else
typedef struct IdCardReaderActiveX IdCardReaderActiveX;
#endif /* __cplusplus */

#endif 	/* __IdCardReaderActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __IdCardReaderActiveXLib_LIBRARY_DEFINED__
#define __IdCardReaderActiveXLib_LIBRARY_DEFINED__

/* library IdCardReaderActiveXLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_IdCardReaderActiveXLib;

#ifndef ___DIdCardReaderActiveX_DISPINTERFACE_DEFINED__
#define ___DIdCardReaderActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DIdCardReaderActiveX */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DIdCardReaderActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("51F544AC-51EB-4BDC-BCF9-BC57153A95BB")
    _DIdCardReaderActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DIdCardReaderActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DIdCardReaderActiveX * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DIdCardReaderActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DIdCardReaderActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DIdCardReaderActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DIdCardReaderActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DIdCardReaderActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DIdCardReaderActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DIdCardReaderActiveXVtbl;

    interface _DIdCardReaderActiveX
    {
        CONST_VTBL struct _DIdCardReaderActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DIdCardReaderActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DIdCardReaderActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DIdCardReaderActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DIdCardReaderActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DIdCardReaderActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DIdCardReaderActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DIdCardReaderActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DIdCardReaderActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DIdCardReaderActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DIdCardReaderActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DIdCardReaderActiveXEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DIdCardReaderActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("EDCD5E37-21B4-4900-83B9-6AEDD92187D4")
    _DIdCardReaderActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DIdCardReaderActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DIdCardReaderActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DIdCardReaderActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DIdCardReaderActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DIdCardReaderActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DIdCardReaderActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DIdCardReaderActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DIdCardReaderActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DIdCardReaderActiveXEventsVtbl;

    interface _DIdCardReaderActiveXEvents
    {
        CONST_VTBL struct _DIdCardReaderActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DIdCardReaderActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DIdCardReaderActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DIdCardReaderActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DIdCardReaderActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DIdCardReaderActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DIdCardReaderActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DIdCardReaderActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DIdCardReaderActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_IdCardReaderActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("D25DB37E-0478-408C-95CA-1E630A88CABF")
IdCardReaderActiveX;
#endif
#endif /* __IdCardReaderActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


