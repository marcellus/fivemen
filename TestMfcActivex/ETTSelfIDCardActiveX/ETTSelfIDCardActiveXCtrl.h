#pragma once

// ETTSelfIDCardActiveXCtrl.h : CETTSelfIDCardActiveXCtrl ActiveX 控件类的声明。


// CETTSelfIDCardActiveXCtrl : 有关实现的信息，请参阅 ETTSelfIDCardActiveXCtrl.cpp。

#include <objsafe.h>//导入安全接口
#include "NationItemArray.h"
#include "termb.h"
#include "WideString.h"
#include <vector>


static HINSTANCE DLLInst1 = NULL;
static HINSTANCE DLLInst2 = NULL;

//------------------------------------------------------
//sdtapi.dll动态库函数功能定义
//------------------------------------------------------
int (__stdcall *SDT_OpenPort)(int port);
int (__stdcall *SDT_ClosePort)(int port);
int (__stdcall *SDT_StartFindIDCard)(int port,BYTE *pucIIN,int iIfOpen);
int (__stdcall *SDT_SelectIDCard)(int port,BYTE *pucIIN,int iIfOpen);
int (__stdcall *SDT_ReadBaseMsgToFile)(int port,LPSTR filename,BYTE *puiCHMsgLen,LPSTR filename2,BYTE *puiPHMsgLen,int iIfOpen);


//------------------------------------------------------
//WltRS.dll动态库函数功能定义
//------------------------------------------------------
int (__stdcall *GetBmp)(LPSTR filename,int isUsb);

class CETTSelfIDCardActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTSelfIDCardActiveXCtrl)

	//ISafeObject
	DECLARE_INTERFACE_MAP()

	BEGIN_INTERFACE_PART(ObjSafe, IObjectSafety)
		STDMETHOD_(HRESULT, GetInterfaceSafetyOptions) ( 
		/* [in] */ REFIID riid,
		/* [out] */ DWORD __RPC_FAR *pdwSupportedOptions,
		/* [out] */ DWORD __RPC_FAR *pdwEnabledOptions
		);

		STDMETHOD_(HRESULT, SetInterfaceSafetyOptions) ( 
			/* [in] */ REFIID riid,
			/* [in] */ DWORD dwOptionSetMask,
			/* [in] */ DWORD dwEnabledOptions
			);
	END_INTERFACE_PART(ObjSafe);

// 构造函数
public:
	CETTSelfIDCardActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTSelfIDCardActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTSelfIDCardActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTSelfIDCardActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTSelfIDCardActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTSelfIDCardActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidReadFromFile = 22L,
		dispidReadTick = 21,
		dispidDestroyDll = 20L,
		dispidLoadDll = 19L,
		dispidHasLoadLib = 18,
		dispidIsUseCom = 17,
		dispidReadIDCard = 16L,
		dispidImagePath = 15,
		dispidYxqxName = 14,
		dispidYxqxCode = 13,
		dispidEndDate = 12,
		dispidStartDate = 11,
		dispidFzjg = 10,
		dispidAddress = 9,
		dispidBirth = 8,
		dispidNationName = 7,
		dispidNationCode = 6,
		dispidIDCard = 5,
		dispidSexName = 4,
		dispidSexCode = 3,
		dispidName = 2,
		dispidIsReaded = 1
	};
	BSTR ReadFromFile(LPCTSTR filename);

protected:
	
	CNationItemArray m_nationArray;
	void InitNationArray(void);
	void OnIsReadedChanged(void);
	SHORT m_IsReaded;
	void OnNameChanged(void);
	CString m_Name;
	void OnSexCodeChanged(void);
	SHORT m_SexCode;
	void OnSexNameChanged(void);
	CString m_SexName;
	void OnIDCardChanged(void);
	CString m_IDCard;
	void OnNationCodeChanged(void);
	CString m_NationCode;
	void OnNationNameChanged(void);
	CString m_NationName;
	void OnBirthChanged(void);
	CString m_Birth;
	void OnAddressChanged(void);
	CString m_Address;
	void OnFzjgChanged(void);
	CString m_Fzjg;
	void OnStartDateChanged(void);
	CString m_StartDate;
	void OnEndDateChanged(void);
	CString m_EndDate;
	void OnYxqxCodeChanged(void);
	CString m_YxqxCode;
	void OnYxqxNameChanged(void);
	CString m_YxqxName;
	void OnImagePathChanged(void);
	BYTE m_ImagePath;
	SHORT ReadIDCard(void);
	void OnIsUseComChanged(void);
	SHORT m_IsUseCom;
	void OnHasLoadLibChanged(void);
	SHORT m_HasLoadLib;
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	void OnReadTickChanged(void);
	SHORT m_ReadTick;
	
};

