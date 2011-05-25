#pragma once

// ETTEpsonPrinterActiveXCtrl.h : CETTEpsonPrinterActiveXCtrl ActiveX 控件类的声明。


// CETTEpsonPrinterActiveXCtrl : 有关实现的信息，请参阅 ETTEpsonPrinterActiveXCtrl.cpp。
static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//两个dll都有的函数定义热敏打印机动态库函数功能定义
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);
int (__stdcall *SetRowDistance)(int distance, char* Message);
int (__stdcall *PrintLine)(const char* print_data, char* Message);
int (__stdcall *CutPaper)(char* Message);
int (__stdcall *SetTextStyle)(const char *pszStyle, char* Message);
//------------------------------------------------------
//ReceiptPrinter.dll热敏打印机动态库函数功能定义
//------------------------------------------------------



int (__stdcall *SetLeftDistance) (int distance, char* Message);
int (__stdcall *PrintBitmapNV)(int index, int size, int nSpace, char* Message);



//------------------------------------------------------
//InvoicePrinter.dll发票打印机动态库函数功能定义
//------------------------------------------------------



int (__stdcall *SetBlackOffset)(int P, int L, int Q, char *Message);
int (__stdcall *BlackMarkIdentify)(char *Message);
int (__stdcall *MovePaper)(int Distance, char* Message);
#include <objsafe.h>//导入安全接口
#include "QPrint.h"
//#include <QPrint.h>

class CETTEpsonPrinterActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTEpsonPrinterActiveXCtrl)

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
	CETTEpsonPrinterActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTEpsonPrinterActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTEpsonPrinterActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTEpsonPrinterActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTEpsonPrinterActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTEpsonPrinterActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidPort = 8,
		dispidPrinterPort = 7L,
		dispidPrinterName = 6,
		dispidTestMethod = 5L,
		dispidRemoveAllString = 4L,
		dispidAddString = 3L,
		dispidDestroyDll = 2L,
		dispidLoadDll = 1L
	};
	CQPrint *m_CQPrint;
	CStringArray arrStr;
protected:
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	void AddString(LPCTSTR data);
	void RemoveAllString(void);
	void TestMethod(void);
	void OnPrinterNameChanged(void);
	CString m_PrinterName;
	SHORT PrinterPort(void);
	void OnPortChanged(void);
	SHORT m_Port;
};

