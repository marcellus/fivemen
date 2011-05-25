#pragma once

// ETTSelfPrinterActiveXCtrl.h : CETTSelfPrinterActiveXCtrl ActiveX 控件类的声明。


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


// CETTSelfPrinterActiveXCtrl : 有关实现的信息，请参阅 ETTSelfPrinterActiveXCtrl.cpp。
#include <objsafe.h>//导入安全接口
#include "qprint.h"

class CETTSelfPrinterActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTSelfPrinterActiveXCtrl)
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
	CETTSelfPrinterActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTSelfPrinterActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTSelfPrinterActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTSelfPrinterActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTSelfPrinterActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTSelfPrinterActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidShowArray = 11L,
		dispidTest = 10L,
		dispidAddString = 9L,
		dispidClearAll = 8L,
		dispidPrintLineEx2 = 7L,
		dispidCutPaperEx = 6L,
		
		dispidSetRowDistanceEx = 4L,
		dispidCloseDeviceEx = 3L,
		dispidOpenDeviceEx = 2L,
		dispidDestroyDll = 16L,
		dispidLoadInvoiceDll = 15L,
		dispidLoadReceiptDll = 14L,
		dispidMyTestMessage = 1,
		dispidPrinterName = 13,
		dispidYyrq = 12,
		dispidKsrq = 11,
		dispidJszh = 10,
		dispidHint = 9,
		dispidFee = 8,
		dispidSlrq = 7,
		dispidHmhp = 6,
		dispidOwner = 5,
		dispidYWLX = 4,
		dispidLSH = 3,
		dispidGLBM = 2,
		dispidCarPrint = 1L
	};
	SHORT CarPrint(void);
	CQPrint *m_CQPrint;
	CStringArray arrStr;

protected:
	
	void OnGLBMChanged(void);
	CString m_GLBM;
	void OnLSHChanged(void);
	CString m_LSH;
	void OnYWLXChanged(void);
	CString m_YWLX;
	void OnOwnerChanged(void);
	CString m_Owner;
	void OnHmhpChanged(void);
	CString m_Hmhp;
	void OnSlrqChanged(void);
	CString m_Slrq;
	void OnFeeChanged(void);
	CString m_Fee;
	void OnHintChanged(void);
	CString m_Hint;
	void OnJszhChanged(void);
	CString m_Jszh;
	void OnKsrqChanged(void);
	CString m_Ksrq;
	void OnYyrqChanged(void);
	CString m_Yyrq;
	void OnPrinterNameChanged(void);
	CString m_PrinterName;
	void OnMyTestMessageChanged(void);
	CString m_MyTestMessage;
	SHORT LoadReceiptDll(void);
	SHORT LoadInvoiceDll(void);
	SHORT DestroyDll(void);

	SHORT OpenDeviceEx(int port);
	SHORT CloseDeviceEx(void);
	SHORT SetRowDistanceEx(int distance);

	SHORT CutPaperEx(void);
	SHORT PrintLineEx2(BSTR* data);
	SHORT ClearAll(void);
	SHORT AddString(BSTR data);
	SHORT Test(void);
	void ShowArray(void);
};

