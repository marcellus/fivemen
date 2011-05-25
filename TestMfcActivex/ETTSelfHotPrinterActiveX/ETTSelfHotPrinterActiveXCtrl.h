#pragma once

// ETTSelfHotPrinterActiveXCtrl.h : CETTSelfHotPrinterActiveXCtrl ActiveX 控件类的声明。


// CETTSelfHotPrinterActiveXCtrl : 有关实现的信息，请参阅 ETTSelfHotPrinterActiveXCtrl.cpp。

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

class CETTSelfHotPrinterActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTSelfHotPrinterActiveXCtrl)

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
	CETTSelfHotPrinterActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTSelfHotPrinterActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTSelfHotPrinterActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTSelfHotPrinterActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTSelfHotPrinterActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTSelfHotPrinterActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidMessage = 21,
		dispidMovePaperEx = 20L,
		dispidBlackMarkIdentifyEx = 19L,
		dispidSetBlackOffsetEx = 18L,
		dispidSetTextStyleEx = 17L,
		dispidPrintBitmapNVEx = 16L,
		dispidCutPaperEx = 15L,
		dispidPrintLineEx = 14L,
		dispidSetLeftDistanceEx = 13L,
		dispidSetRowDistanceEx = 12L,
		dispidGetDeviceStatusEx = 11L,
		dispidCloseDeviceEx = 10L,
		dispidOpenDeviceEx = 9L,
		dispidFontStyle = 8,
		dispidPrintHot = 7L,
		dispidRemoveAllString = 6L,
		dispidTestArray = 5L,
		dispidAddString = 4L,
		dispidDestroyDll = 3L,
		dispidLoadInvoiceDll = 2L,
		dispidLoadReceiptDll = 1L
	};
	CStringArray arrStr;
protected:
	SHORT LoadReceiptDll(void);
	SHORT LoadInvoiceDll(void);
	SHORT DestroyDll(void);
	void AddString(LPCTSTR data);
	void TestArray(void);
	void RemoveAllString(void);
	void PrintHot(SHORT port, SHORT distance);
	void OnFontStyleChanged(void);
	CString m_FontStyle;
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT SetRowDistanceEx(SHORT distance);
	SHORT SetLeftDistanceEx(SHORT distance);
	SHORT PrintLineEx(LPCTSTR data);
	SHORT CutPaperEx(void);
	SHORT PrintBitmapNVEx(SHORT index, SHORT size, SHORT nspace);
	SHORT SetTextStyleEx(LPCTSTR style);
	SHORT SetBlackOffsetEx(SHORT P, SHORT L, SHORT Q);
	SHORT BlackMarkIdentifyEx(void);
	SHORT MovePaperEx(SHORT distance);
	void OnMessageChanged(void);
	CString m_Message;
};

