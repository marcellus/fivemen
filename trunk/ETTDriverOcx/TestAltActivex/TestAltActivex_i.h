

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Thu Sep 15 13:49:58 2011
 */
/* Compiler settings for .\TestAltActivex.idl:
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

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __TestAltActivex_i_h__
#define __TestAltActivex_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IActiveXCash_FWD_DEFINED__
#define __IActiveXCash_FWD_DEFINED__
typedef interface IActiveXCash IActiveXCash;
#endif 	/* __IActiveXCash_FWD_DEFINED__ */


#ifndef __IActiveXLed_FWD_DEFINED__
#define __IActiveXLed_FWD_DEFINED__
typedef interface IActiveXLed IActiveXLed;
#endif 	/* __IActiveXLed_FWD_DEFINED__ */


#ifndef ___IActiveXCashEvents_FWD_DEFINED__
#define ___IActiveXCashEvents_FWD_DEFINED__
typedef interface _IActiveXCashEvents _IActiveXCashEvents;
#endif 	/* ___IActiveXCashEvents_FWD_DEFINED__ */


#ifndef __ActiveXCash_FWD_DEFINED__
#define __ActiveXCash_FWD_DEFINED__

#ifdef __cplusplus
typedef class ActiveXCash ActiveXCash;
#else
typedef struct ActiveXCash ActiveXCash;
#endif /* __cplusplus */

#endif 	/* __ActiveXCash_FWD_DEFINED__ */


#ifndef ___IActiveXLedEvents_FWD_DEFINED__
#define ___IActiveXLedEvents_FWD_DEFINED__
typedef interface _IActiveXLedEvents _IActiveXLedEvents;
#endif 	/* ___IActiveXLedEvents_FWD_DEFINED__ */


#ifndef __ActiveXLed_FWD_DEFINED__
#define __ActiveXLed_FWD_DEFINED__

#ifdef __cplusplus
typedef class ActiveXLed ActiveXLed;
#else
typedef struct ActiveXLed ActiveXLed;
#endif /* __cplusplus */

#endif 	/* __ActiveXLed_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IActiveXCash_INTERFACE_DEFINED__
#define __IActiveXCash_INTERFACE_DEFINED__

/* interface IActiveXCash */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IActiveXCash;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("CE8A8E2F-2AF9-426E-8889-A3544B3A76CC")
    IActiveXCash : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE HelloA( 
            /* [in] */ LONG port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Hello( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IActiveXCashVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IActiveXCash * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IActiveXCash * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IActiveXCash * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IActiveXCash * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IActiveXCash * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IActiveXCash * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IActiveXCash * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *HelloA )( 
            IActiveXCash * This,
            /* [in] */ LONG port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Hello )( 
            IActiveXCash * This);
        
        END_INTERFACE
    } IActiveXCashVtbl;

    interface IActiveXCash
    {
        CONST_VTBL struct IActiveXCashVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IActiveXCash_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IActiveXCash_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IActiveXCash_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IActiveXCash_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IActiveXCash_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IActiveXCash_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IActiveXCash_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IActiveXCash_HelloA(This,port)	\
    ( (This)->lpVtbl -> HelloA(This,port) ) 

#define IActiveXCash_Hello(This)	\
    ( (This)->lpVtbl -> Hello(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IActiveXCash_INTERFACE_DEFINED__ */


#ifndef __IActiveXLed_INTERFACE_DEFINED__
#define __IActiveXLed_INTERFACE_DEFINED__

/* interface IActiveXLed */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IActiveXLed;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9E1F7326-FDCD-43A8-80E8-893B3815EBB3")
    IActiveXLed : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE HelloB( 
            SHORT port) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Hello( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IActiveXLedVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IActiveXLed * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IActiveXLed * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IActiveXLed * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IActiveXLed * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IActiveXLed * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IActiveXLed * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IActiveXLed * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *HelloB )( 
            IActiveXLed * This,
            SHORT port);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Hello )( 
            IActiveXLed * This);
        
        END_INTERFACE
    } IActiveXLedVtbl;

    interface IActiveXLed
    {
        CONST_VTBL struct IActiveXLedVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IActiveXLed_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IActiveXLed_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IActiveXLed_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IActiveXLed_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IActiveXLed_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IActiveXLed_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IActiveXLed_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IActiveXLed_HelloB(This,port)	\
    ( (This)->lpVtbl -> HelloB(This,port) ) 

#define IActiveXLed_Hello(This)	\
    ( (This)->lpVtbl -> Hello(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IActiveXLed_INTERFACE_DEFINED__ */



#ifndef __TestAltActivexLib_LIBRARY_DEFINED__
#define __TestAltActivexLib_LIBRARY_DEFINED__

/* library TestAltActivexLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_TestAltActivexLib;

#ifndef ___IActiveXCashEvents_DISPINTERFACE_DEFINED__
#define ___IActiveXCashEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IActiveXCashEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IActiveXCashEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("AA1BA7F4-ECB8-49E2-9D0F-14CB5390AD84")
    _IActiveXCashEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IActiveXCashEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IActiveXCashEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IActiveXCashEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IActiveXCashEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IActiveXCashEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IActiveXCashEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IActiveXCashEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IActiveXCashEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IActiveXCashEventsVtbl;

    interface _IActiveXCashEvents
    {
        CONST_VTBL struct _IActiveXCashEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IActiveXCashEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IActiveXCashEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IActiveXCashEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IActiveXCashEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IActiveXCashEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IActiveXCashEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IActiveXCashEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IActiveXCashEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ActiveXCash;

#ifdef __cplusplus

class DECLSPEC_UUID("B1AFEE5C-8485-41EE-A908-3ECBA5BD59BA")
ActiveXCash;
#endif

#ifndef ___IActiveXLedEvents_DISPINTERFACE_DEFINED__
#define ___IActiveXLedEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IActiveXLedEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IActiveXLedEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("75EC52EC-448C-4AFD-ACB7-DAD6A890B2D3")
    _IActiveXLedEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IActiveXLedEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IActiveXLedEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IActiveXLedEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IActiveXLedEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IActiveXLedEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IActiveXLedEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IActiveXLedEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IActiveXLedEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IActiveXLedEventsVtbl;

    interface _IActiveXLedEvents
    {
        CONST_VTBL struct _IActiveXLedEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IActiveXLedEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IActiveXLedEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IActiveXLedEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IActiveXLedEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IActiveXLedEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IActiveXLedEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IActiveXLedEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IActiveXLedEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ActiveXLed;

#ifdef __cplusplus

class DECLSPEC_UUID("C60846B6-BAC0-47E1-B391-EC5D5AD7BD1A")
ActiveXLed;
#endif
#endif /* __TestAltActivexLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


