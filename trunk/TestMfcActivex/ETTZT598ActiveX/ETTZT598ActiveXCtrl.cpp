// ETTZT598ActiveXCtrl.cpp : CETTZT598ActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTZT598ActiveX.h"
#include "ETTZT598ActiveXCtrl.h"
#include "ETTZT598ActiveXPropPage.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTZT598ActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTZT598ActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTZT598ActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTZT598ActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTZT598ActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTZT598ActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTZT598ActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTZT598ActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTZT598ActiveXCtrl,   ObjSafe) 
		return   (HRESULT)pThis-> ExternalQueryInterface(&iid,   ppvObj); 
} 

const   DWORD   dwSupportedBits   =   
INTERFACESAFE_FOR_UNTRUSTED_CALLER   | 
INTERFACESAFE_FOR_UNTRUSTED_DATA; 
const   DWORD   dwNotSupportedBits   =   ~   dwSupportedBits; 

///////////////////////////////////////////////////////////////////////////// 
//   CStopLiteCtrl::XObjSafe::GetInterfaceSafetyOptions 
//   Allows   container   to   query   what   interfaces   are   safe   for   what.   We 're 
//   optimizing   significantly   by   ignoring   which   interface   the   caller   is 
//   asking   for. 
HRESULT   STDMETHODCALLTYPE   
CETTZT598ActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTZT598ActiveXCtrl,   ObjSafe) 

		HRESULT   retval   =   ResultFromScode(S_OK); 

	//   does   interface   exist? 
	IUnknown   FAR*   punkInterface; 
	retval   =   pThis-> ExternalQueryInterface(&riid,   
		(void   *   *)&punkInterface); 
	if   (retval   !=   E_NOINTERFACE)   { //   interface   exists 
		punkInterface-> Release();   //   release   it--just   checking! 
	} 

	//   we   support   both   kinds   of   safety   and   have   always   both   set, 
	//   regardless   of   interface 
	*pdwSupportedOptions   =   *pdwEnabledOptions   =   dwSupportedBits; 

	return   retval;   //   E_NOINTERFACE   if   QI   failed 
} 

///////////////////////////////////////////////////////////////////////////// 
//   CStopLiteCtrl::XObjSafe::SetInterfaceSafetyOptions 
//   Since   we 're   always   safe,   this   is   a   no-brainer--but   we   do   check   to   make 
//   sure   the   interface   requested   exists   and   that   the   options   we 're   asked   to 
//   set   exist   and   are   set   on   (we   don 't   support   unsafe   mode). 
HRESULT   STDMETHODCALLTYPE   
CETTZT598ActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTZT598ActiveXCtrl,   ObjSafe) 

		//   does   interface   exist? 
		IUnknown   FAR*   punkInterface; 
	pThis-> ExternalQueryInterface(&riid,   (void   *   *)&punkInterface); 
	if   (punkInterface)   { //   interface   exists 
		punkInterface-> Release();   //   release   it--just   checking! 
	} 
	else   {   //   interface   doesn 't   exist 
		return   ResultFromScode(E_NOINTERFACE); 
	} 

	//   can 't   set   bits   we   don 't   support 
	if   (dwOptionSetMask   &   dwNotSupportedBits)   {   
		return   ResultFromScode(E_FAIL); 
	} 

	//   can 't   set   bits   we   do   support   to   zero 
	dwEnabledOptions   &=   dwSupportedBits; 
	//   (we   already   know   there   are   no   extra   bits   in   mask   ) 
	if   ((dwOptionSetMask   &   dwEnabledOptions)   != 
		dwOptionSetMask)   { 
			return   ResultFromScode(E_FAIL); 
	} 

	//   don 't   need   to   change   anything   since   we 're   always   safe 
	return   ResultFromScode(S_OK); 
}



// 消息映射

BEGIN_MESSAGE_MAP(CETTZT598ActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTZT598ActiveXCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTZT598ActiveXCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTZT598ActiveXCtrl, "IsInputOver", dispidIsInputOver, m_IsInputOver, OnIsInputOverChanged, VT_I2)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "PinLoadCardNoEx", dispidPinLoadCardNoEx, PinLoadCardNoEx, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "ActivWorkPinEx", dispidActivWorkPinEx, ActivWorkPinEx, VT_I2, VTS_I2 VTS_I2)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "OpenKeyVoicEx", dispidOpenKeyVoicEx, OpenKeyVoicEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "PinStartAddEx", dispidPinStartAddEx, PinStartAddEx, VT_I2, VTS_I2 VTS_I2 VTS_I2)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "PinReadPinEx", dispidPinReadPinEx, PinReadPinEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "PinReportPressedEx", dispidPinReportPressedEx, PinReportPressedEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTZT598ActiveXCtrl, "GetUserPin", dispidGetUserPin, GetUserPin, VT_I2, VTS_I2)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTZT598ActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTZT598ActiveXCtrl, 1)
	PROPPAGEID(CETTZT598ActiveXPropPage::guid)
END_PROPPAGEIDS(CETTZT598ActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTZT598ActiveXCtrl, "ETTZT598ACTIVEX.ETTZT598ActiveXCtrl.1",
	0x233b327e, 0x114d, 0x4aff, 0x8f, 0x70, 0x42, 0x7b, 0xca, 0x74, 0x7d, 0x2c)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTZT598ActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTZT598ActiveX =
		{ 0x6385D7D9, 0x75CC, 0x4D58, { 0x89, 0x87, 0x47, 0xA9, 0x6A, 0x6A, 0xCF, 0xBF } };
const IID BASED_CODE IID_DETTZT598ActiveXEvents =
		{ 0xCF16CA5E, 0xC839, 0x49D9, { 0x95, 0xE4, 0x8F, 0xF3, 0x72, 0x44, 0x5C, 0x6C } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTZT598ActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTZT598ActiveXCtrl, IDS_ETTZT598ACTIVEX, _dwETTZT598ActiveXOleMisc)



// CETTZT598ActiveXCtrl::CETTZT598ActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTZT598ActiveXCtrl 的系统注册表项

BOOL CETTZT598ActiveXCtrl::CETTZT598ActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: 验证您的控件是否符合单元模型线程处理规则。
	// 有关更多信息，请参考 MFC 技术说明 64。
	// 如果您的控件不符合单元模型规则，则
	// 必须修改如下代码，将第六个参数从
	// afxRegApartmentThreading 改为 0。

	if (bRegister)
		return AfxOleRegisterControlClass(
			AfxGetInstanceHandle(),
			m_clsid,
			m_lpszProgID,
			IDS_ETTZT598ACTIVEX,
			IDB_ETTZT598ACTIVEX,
			afxRegApartmentThreading,
			_dwETTZT598ActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTZT598ActiveXCtrl::CETTZT598ActiveXCtrl - 构造函数

CETTZT598ActiveXCtrl::CETTZT598ActiveXCtrl()
{
	InitializeIIDs(&IID_DETTZT598ActiveX, &IID_DETTZT598ActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTZT598ActiveXCtrl::~CETTZT598ActiveXCtrl - 析构函数

CETTZT598ActiveXCtrl::~CETTZT598ActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTZT598ActiveXCtrl::OnDraw - 绘图函数

void CETTZT598ActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);

	if (!IsOptimizedDraw())
	{
		// 容器不支持优化绘图。

		// TODO: 如果将任何 GDI 对象选入到设备上下文 *pdc 中，
		//		请在此处恢复先前选定的对象。
	}
}



// CETTZT598ActiveXCtrl::DoPropExchange - 持久性支持

void CETTZT598ActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTZT598ActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTZT598ActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 不用创建窗口即可激活控件。
	// TODO: 编写控件的消息处理程序时，在使用
	//		m_hWnd 成员变量之前应首先检查它的值是否
	//		非 null。
	dwFlags |= windowlessActivate;

	// 控件通过不还原设备上下文中的
	// 原始 GDI 对象，可以优化它的 OnDraw 方法。
	dwFlags |= canOptimizeDraw;
	return dwFlags;
}



// CETTZT598ActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTZT598ActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTZT598ActiveXCtrl 消息处理程序

void CETTZT598ActiveXCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTZT598ActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	// AfxMessageBox("准备加载TTCardReaderV2！");
	DLLInst=LoadLibrary("ZT_EPP_API.dll");
	//DLLInst=LoadLibrary("TTReadCard.dll");
	//AfxMessageBox("加载完成TTCardReaderV2！");
	if(DLLInst!=NULL)
	{

	
		//AfxMessageBox("开始加载ZT_EPP_API中的函数！");

ZT_EPP_OpenCom=(short(__stdcall *)(short iPort, long lBaud))GetProcAddress(DLLInst,"ZT_EPP_OpenCom");
ZT_EPP_CloseCom=(short(__stdcall *)())GetProcAddress(DLLInst,"ZT_EPP_CloseCom");
ZT_EPP_PinInitialization=(short(__stdcall *)(short iInitMode))GetProcAddress(DLLInst,"ZT_EPP_PinInitialization");
ZT_EPP_PinReadVersion=(short(__stdcall *)(char *cpVersion,char *cpSN,char *cpRechang))GetProcAddress(DLLInst,"ZT_EPP_PinReadVersion");
ZT_EPP_SetDesPara=(short(__stdcall *)(short iPara,short iFCode))GetProcAddress(DLLInst,"ZT_EPP_SetDesPara");
ZT_EPP_PinLoadMasterKey=(short(__stdcall *)(short iKMode,short iKeyNo, LPCTSTR lpKey,char *cpExChk))GetProcAddress(DLLInst,"ZT_EPP_PinLoadMasterKey");


ZT_EPP_PinLoadWorkKey=(short(__stdcall *)(short iKMode,short iMKeyNo,short iKeyNo,LPCTSTR lpKey,char *cpExChk))GetProcAddress(DLLInst,"ZT_EPP_PinLoadWorkKey");
ZT_EPP_ActivWorkPin=(short(__stdcall *)(short iMKeyNo,short iWKeyNo))GetProcAddress(DLLInst,"ZT_EPP_ActivWorkPin");
ZT_EPP_PinLoadCardNo=(short(__stdcall *)(LPCTSTR lpCardNo))GetProcAddress(DLLInst,"ZT_EPP_PinLoadCardNo");
ZT_EPP_OpenKeyVoic=(short(__stdcall *)(short iValue))GetProcAddress(DLLInst,"ZT_EPP_OpenKeyVoic");
ZT_EPP_PinStartAdd=(short(__stdcall *)(short iPinLen,short iDispMode,short iPINMode,short iPromMode,short iTimeOut))GetProcAddress(DLLInst,"ZT_EPP_PinStartAdd");
ZT_EPP_PinReportPressed=(short(__stdcall *)(char *cpKey,short iTimeOut))GetProcAddress(DLLInst,"ZT_EPP_PinReportPressed");

ZT_EPP_PinReadPin=(short(__stdcall *)(short iKMode, char *cpPinBlock))GetProcAddress(DLLInst,"ZT_EPP_PinReadPin");
ZT_EPP_PinCalMAC=(short(__stdcall *)(short iKMode, short iMacMode,LPCTSTR lpValue, char *cpExValue))GetProcAddress(DLLInst,"ZT_EPP_PinCalMAC");
ZT_EPP_PinAdd=(short(__stdcall *)(short iKMode,short iMode, LPCTSTR lpValue,char *cpExValue))GetProcAddress(DLLInst,"ZT_EPP_PinAdd");
ZT_EPP_PinUnAdd=(short(__stdcall *)(short iKMode,short iMode,LPCTSTR lpValue,char *cpExValue))GetProcAddress(DLLInst,"ZT_EPP_PinUnAdd");
ZT_EPP_SetICType=(short(__stdcall *)(short iIC,short iICType))GetProcAddress(DLLInst,"ZT_EPP_SetICType");
ZT_EPP_ICOnPower=(short(__stdcall *)(char *chOutData))GetProcAddress(DLLInst,"ZT_EPP_ICOnPower");
ZT_EPP_ICControl=(short(__stdcall *)(LPCTSTR lpValue, char *cpExValue))GetProcAddress(DLLInst,"ZT_EPP_ICControl");
this->m_Message="成功";
		
		//AfxMessageBox("加载完成ZT_EPP_API中的函数！");

	}
	else
	{
		this->m_Message="失败";
		AfxMessageBox("加载动态库ZT_EPP_API.dll失败！");
		exit(0);
	}
	return 0;
}

SHORT CETTZT598ActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(DLLInst!=NULL)
	{
		FreeLibrary(DLLInst);
		DLLInst=NULL;
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}

	return 0;
}


SHORT CETTZT598ActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	///char msg[255];
	int ret=-1;
	ret=ZT_EPP_CloseCom();
	if(ret==0)
	{
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}

	return ret;
}

SHORT CETTZT598ActiveXCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//char msg[255];
	int ret=-1;
	ret=ZT_EPP_OpenCom(port,9600);
	if(ret==0)
	{
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}

	return ret;
}

void CETTZT598ActiveXCtrl::OnIsInputOverChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTZT598ActiveXCtrl::PinLoadCardNoEx(LPCTSTR pan)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//char msg[255];
	int ret=-1;
	ret=ZT_EPP_PinLoadCardNo(pan);
	if(ret==0)
	{
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}

	return ret;
}

SHORT CETTZT598ActiveXCtrl::ActivWorkPinEx(SHORT masterKeyIndex, SHORT workKeyIndex)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	//char msg[255];
	int ret=-1;
	ret=ZT_EPP_ActivWorkPin(masterKeyIndex,workKeyIndex);
	if(ret==0)
	{
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}

	return ret;
}

SHORT CETTZT598ActiveXCtrl::OpenKeyVoicEx(SHORT param)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//char msg[255];
	int ret=-1;
	ret=ZT_EPP_OpenKeyVoic(param);
	if(ret==0)
	{
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}


	return ret;
}

SHORT CETTZT598ActiveXCtrl::PinStartAddEx(SHORT len, SHORT pinMode, SHORT timeout)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//char msg[255];
	int ret=-1;
	ret=ZT_EPP_PinStartAdd(len,1,pinMode,0,timeout);
	if(ret==0)
	{
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}


	return ret;
}

SHORT CETTZT598ActiveXCtrl::PinReadPinEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	memset(msg,0,sizeof(msg));
	int ret=-1;
	ret=ZT_EPP_PinReadPin(0,msg);
	if(ret==0)
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	else
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}


	return ret;
}

SHORT CETTZT598ActiveXCtrl::PinReportPressedEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	memset(msg,0,sizeof(msg));
	int ret=-1;
	ret=ZT_EPP_PinReportPressed(msg,100);
	if(ret==0)
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	else
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}


	return ret;
}

SHORT CETTZT598ActiveXCtrl::GetUserPin(SHORT peaMode)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	memset(msg,0,sizeof(msg));
	int ret=-1;
	ret=ZT_EPP_PinReadPin(0,msg);
	ret=ZT_EPP_PinUnAdd(peaMode, 0, msg, msg);
	if(ret==0)
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	else
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}


	return ret;
}
