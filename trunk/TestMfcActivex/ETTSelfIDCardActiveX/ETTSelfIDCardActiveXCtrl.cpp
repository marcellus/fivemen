// ETTSelfIDCardActiveXCtrl.cpp : CETTSelfIDCardActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTSelfIDCardActiveX.h"
#include "ETTSelfIDCardActiveXCtrl.h"
#include "ETTSelfIDCardActiveXPropPage.h"




#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfIDCardActiveXCtrl, COleControl)
BEGIN_INTERFACE_MAP(   CETTSelfIDCardActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfIDCardActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfIDCardActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfIDCardActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfIDCardActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 
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
CETTSelfIDCardActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 

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
CETTSelfIDCardActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfIDCardActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTSelfIDCardActiveXCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "IsReaded", dispidIsReaded, m_IsReaded, OnIsReadedChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Name", dispidName, m_Name, OnNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "SexCode", dispidSexCode, m_SexCode, OnSexCodeChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "SexName", dispidSexName, m_SexName, OnSexNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "IDCard", dispidIDCard, m_IDCard, OnIDCardChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "NationCode", dispidNationCode, m_NationCode, OnNationCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "NationName", dispidNationName, m_NationName, OnNationNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Birth", dispidBirth, m_Birth, OnBirthChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Address", dispidAddress, m_Address, OnAddressChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Fzjg", dispidFzjg, m_Fzjg, OnFzjgChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "StartDate", dispidStartDate, m_StartDate, OnStartDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "EndDate", dispidEndDate, m_EndDate, OnEndDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "YxqxCode", dispidYxqxCode, m_YxqxCode, OnYxqxCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "YxqxName", dispidYxqxName, m_YxqxName, OnYxqxNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "ImagePath", dispidImagePath, m_ImagePath, OnImagePathChanged, VT_UI1)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "ReadIDCard", dispidReadIDCard, ReadIDCard, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "IsUseCom", dispidIsUseCom, m_IsUseCom, OnIsUseComChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "HasLoadLib", dispidHasLoadLib, m_HasLoadLib, OnHasLoadLibChanged, VT_I2)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "ReadTick", dispidReadTick, m_ReadTick, OnReadTickChanged, VT_I2)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "ReadFromFile", dispidReadFromFile, ReadFromFile, VT_BSTR, VTS_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTSelfIDCardActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTSelfIDCardActiveXCtrl, 1)
PROPPAGEID(CETTSelfIDCardActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfIDCardActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfIDCardActiveXCtrl, "ETTSELFIDCARDACT.ETTSelfIDCardActCtrl.1",
					   0x447c4906, 0x6678, 0x461b, 0x9e, 0x20, 0x10, 0xb, 0xde, 0x91, 0x38, 0x28)



					   // 键入库 ID 和版本

					   IMPLEMENT_OLETYPELIB(CETTSelfIDCardActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



					   // 接口 ID

					   const IID BASED_CODE IID_DETTSelfIDCardActiveX =
{ 0xBC755F0E, 0x4F1C, 0x46A2, { 0x8C, 0x10, 0x97, 0xE3, 0x64, 0x97, 0x48, 0x65 } };
const IID BASED_CODE IID_DETTSelfIDCardActiveXEvents =
{ 0x97A9E85, 0xC96F, 0x4B0F, { 0xB4, 0x94, 0x8D, 0x90, 0x6D, 0x13, 0xE2, 0xEB } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTSelfIDCardActiveXOleMisc =
OLEMISC_INVISIBLEATRUNTIME |
OLEMISC_SETCLIENTSITEFIRST |
OLEMISC_INSIDEOUT |
OLEMISC_CANTLINKINSIDE |
OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfIDCardActiveXCtrl, IDS_ETTSELFIDCARDACTIVEX, _dwETTSelfIDCardActiveXOleMisc)



// CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTSelfIDCardActiveXCtrl 的系统注册表项

BOOL CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
		IDS_ETTSELFIDCARDACTIVEX,
		IDB_ETTSELFIDCARDACTIVEX,
		afxRegApartmentThreading,
		_dwETTSelfIDCardActiveXOleMisc,
		_tlid,
		_wVerMajor,
		_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrl - 构造函数

CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrl()
{
	this->InitNationArray();
	InitializeIIDs(&IID_DETTSelfIDCardActiveX, &IID_DETTSelfIDCardActiveXEvents);
	//this->InitNationArray();
	// TODO: 在此初始化控件的实例数据。
}



// CETTSelfIDCardActiveXCtrl::~CETTSelfIDCardActiveXCtrl - 析构函数

CETTSelfIDCardActiveXCtrl::~CETTSelfIDCardActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
	this->m_nationArray.RemoveAll();
}



// CETTSelfIDCardActiveXCtrl::OnDraw - 绘图函数

void CETTSelfIDCardActiveXCtrl::OnDraw(
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



// CETTSelfIDCardActiveXCtrl::DoPropExchange - 持久性支持

void CETTSelfIDCardActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTSelfIDCardActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTSelfIDCardActiveXCtrl::GetControlFlags()
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



// CETTSelfIDCardActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTSelfIDCardActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTSelfIDCardActiveXCtrl 消息处理程序

void CETTSelfIDCardActiveXCtrl::OnIsReadedChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnSexCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnSexNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnIDCardChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnNationCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnNationNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnBirthChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnAddressChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnFzjgChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnStartDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnEndDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnYxqxCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnYxqxNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnImagePathChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTSelfIDCardActiveXCtrl::ReadIDCard(void)
{


	SHORT result=0;
	AFX_MANAGE_STATE(AfxGetStaticModuleState());




	this->LoadDll();
	CString strErrorID;


	int i_ret=0;
	int i_Port=1001;

	for(;i_Port<=1016;i_Port++)
	{
		i_ret=SDT_OpenPort(i_Port);
		if(i_ret==144)
		{
			//strErrorID.Format(_T("获取SDT_OpenPort的端口成功！=%u;i_ret = %u"),i_Port,i_ret);
			//AfxMessageBox(strErrorID);
			break;
		}
	}
	//如果使用串口
	if(this->m_IsUseCom==1)
	{
		//AfxMessageBox("开始获取串口！");
		for(int i;i<=4;i++)
		{
			i_ret=SDT_OpenPort(i);
			if(i_ret==144)
			{
				//strErrorID.Format(_T("获取SDT_OpenPort的端口成功！=%u;i_ret = %u"),i,i_ret);
				//AfxMessageBox(strErrorID);
				i_Port=i;
				break;
			}
		}

	}
	if(i_ret!=144)
	{
		AfxMessageBox("二代证读卡器没有正确接入，请检查！");
		this->DestroyDll();
		return -1;
	}


	int intOpenPortRtn = 0;
	int rtnTemp = 0;
	//int  = 0;
	//int pucSN = 0;
	//int puiCHMsgLen = 0;
	//int puiPHMsgLen = 0;
	int EdziIfOpen = 1;   
	unsigned char pucIIN[256],puiCHMsgLen[256],puiPHMsgLen[256],pucSN[256];
	//AfxMessageBox("开始找卡SDT_StartFindIDCard");
	rtnTemp = SDT_StartFindIDCard(i_Port, pucIIN, EdziIfOpen);
	if (rtnTemp != 159)
	{
		rtnTemp = SDT_StartFindIDCard(i_Port, pucIIN, EdziIfOpen);  //再找卡
		if (rtnTemp != 159)
		{
			rtnTemp = SDT_ClosePort(i_Port);
			//AfxMessageBox("未放卡或者卡未放好，请重新放卡！");
			this->DestroyDll();
			// log.Debug();
			//MessageBox.Show("", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return 1;
		}
	}
	//AfxMessageBox("开始选卡SDT_SelectIDCard");
	rtnTemp = SDT_SelectIDCard(i_Port,  pucSN, EdziIfOpen);
	if (rtnTemp != 144)
	{
		rtnTemp = SDT_SelectIDCard(i_Port, pucSN, EdziIfOpen);  //再选卡
		if (rtnTemp != 144)
		{
			rtnTemp = SDT_ClosePort(i_Port);
			//AfxMessageBox("读卡失败！");
			this->DestroyDll();
			// MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return 2;
		}
	}
	//AfxMessageBox("开始删除文件！");
	try
	{
		CFile::Remove("c:\\wz.txt");
		CFile::Remove("c:\\zp.bmp");
		CFile::Remove("c:\\zp.wlt");
	}
	catch(CFileException *ex)
	{//文件不存在会出现异常

	}


	//AfxMessageBox("开始读取信息到文件中");
	rtnTemp = SDT_ReadBaseMsgToFile(i_Port, "c:\\wz.txt", puiCHMsgLen, "c:\\zp.wlt",puiPHMsgLen, EdziIfOpen);
	if (rtnTemp != 144)
	{
		//AfxMessageBox("读取卡文件信息到文件失败！");
		rtnTemp = SDT_ClosePort(i_Port);
		this->DestroyDll();
		//log.Debug("读卡数据失败！");
		// MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
		return 3;
	}

	if (this->m_IsUseCom)
		rtnTemp = GetBmp("c:\\zp.wlt", 2);
	else
		rtnTemp = GetBmp("c:\\zp.wlt", 1);

	/*
	CFile cf;
	int   iFileHandle=cf.Open("c:\\wz.txt", CFile::modeRead );
	if( !iFileHandle )
	return -1;

	// Get the size of the file and store
	// in a local variable. .
	DWORD dwSize;
	dwSize = cf.GetLength();
	strErrorID.Format(_T("获取后的数据位长度=%u;"),dwSize);
	AfxMessageBox(strErrorID);
	wchar_t sRead=new wchar_t[dwSize];
	//读指定数目
	cf.Read(sRead, dwSize);
	CString   str; 
	tmpstr.GetBuffer(1000);


	cf.Close();


	//char *unicodeStr=new char[dwSize];
	//::MultiByteToWideChar(CP_ACP, 0, sRead, -1, unicodeStr, dwSize);

	strErrorID.Format( _T("%s"), sRead ); //不加_T报错，工程是UNICODE的
	AfxMessageBox(strErrorID);

	*/

	//strErrorID.Format( _T("%s"), test ); //不加_T报错，工程是UNICODE的
	//AfxMessageBox(strErrorID);



	//strErrorID.Format(_T("ErrID = %u"),GetLastError());
	//AfxMessageBox(strErrorID);



	i_ret= SDT_ClosePort(i_Port);
	this->m_IsReaded=1;
	//strErrorID.Format(_T("SDT_ClosePort的端口=%u;i_ret = %u"),i_Port,i_ret);
	//AfxMessageBox(strErrorID);
	//strErrorID.Format(_T("ErrID = %u"),GetLastError());
	//AfxMessageBox(strErrorID);
	this->DestroyDll();
	BSTR test=this->ReadFromFile("c:\\wz.txt");
	return 0;



	/*
	for(int i_Port=1001;i_Port<=1016;i_Port++)
	{
	i_ret=InitComm(i_Port);
	i_ret;
	strErrorID.Format(_T("InitComm的端口=%u;i_ret = %u"),i_Port,i_ret);
	AfxMessageBox(strErrorID);
	strErrorID.Format(_T("ErrID = %u"),GetLastError());
	AfxMessageBox(strErrorID);
	if(i_ret==0)
	{
	strErrorID.Format(_T("InitComm的端口 = %u"),i_Port);
	AfxMessageBox(strErrorID);
	break;
	}
	}
	*/
	return result;
}

//初始化民族映射对象
void CETTSelfIDCardActiveXCtrl::InitNationArray(void)
{
	/**/
	this->m_nationArray.Add("01", "汉族");
	this->m_nationArray.Add("02", "蒙古族");
	this->m_nationArray.Add("03", "回族");
	this->m_nationArray.Add("04", "藏族");
	this->m_nationArray.Add("05", "维吾尔族");
	this->m_nationArray.Add("06", "苗族");
	this->m_nationArray.Add("07", "彝族");
	this->m_nationArray.Add("08", "壮族");
	this->m_nationArray.Add("09", "布依族");
	this->m_nationArray.Add("10", "朝鲜族");
	this->m_nationArray.Add("11", "满族");
	this->m_nationArray.Add("12", "侗族");
	this->m_nationArray.Add("13", "瑶族");
	this->m_nationArray.Add("14", "白族");
	this->m_nationArray.Add("15", "土家族");
	this->m_nationArray.Add("16", "哈尼族");
	this->m_nationArray.Add("17", "哈萨克族");
	this->m_nationArray.Add("18", "傣族");
	this->m_nationArray.Add("19", "黎族");
	this->m_nationArray.Add("20", "傈僳族");
	this->m_nationArray.Add("21", "佤族");
	this->m_nationArray.Add("22", "畲族");
	this->m_nationArray.Add("23", "高山族");
	this->m_nationArray.Add("24", "拉祜族");
	this->m_nationArray.Add("25", "水族");
	this->m_nationArray.Add("26", "东乡族");
	this->m_nationArray.Add("27", "纳西族");
	this->m_nationArray.Add("28", "景颇族");
	this->m_nationArray.Add("29", "柯尔克孜族");
	this->m_nationArray.Add("30", "土族");
	this->m_nationArray.Add("31", "达翰尔族");
	this->m_nationArray.Add("32", "仫佬族");
	this->m_nationArray.Add("33", "羌族");
	this->m_nationArray.Add("34", "布朗族");
	this->m_nationArray.Add("35", "撒拉族");
	this->m_nationArray.Add("36", "毛南族");
	this->m_nationArray.Add("37", "仡佬族");
	this->m_nationArray.Add("38", "锡伯族");
	this->m_nationArray.Add("39", "阿昌族");
	this->m_nationArray.Add("40", "普米族");
	this->m_nationArray.Add("41", "塔吉克族");
	this->m_nationArray.Add("42", "怒族");
	this->m_nationArray.Add("43", "乌孜别克族");
	this->m_nationArray.Add("44", "俄罗斯族");
	this->m_nationArray.Add("45", "鄂温克族");
	this->m_nationArray.Add("46", "德昂族");
	this->m_nationArray.Add("47", "保安族");
	this->m_nationArray.Add("48", "裕固族");
	this->m_nationArray.Add("49", "京族");
	this->m_nationArray.Add("50", "塔塔尔族");
	this->m_nationArray.Add("51", "独龙族");
	this->m_nationArray.Add("52", "鄂伦春族");
	this->m_nationArray.Add("53", "赫哲族");
	this->m_nationArray.Add("54", "门巴族");
	this->m_nationArray.Add("55", "珞巴族");
	this->m_nationArray.Add("56", "基诺族");
	this->m_nationArray.Add("57", "其它");
	this->m_nationArray.Add("98", "外国人入籍");

	// TODO: 在此添加属性处理程序代码

}


void CETTSelfIDCardActiveXCtrl::OnIsUseComChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnHasLoadLibChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}





SHORT CETTSelfIDCardActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	//AfxMessageBox("准备加载dll！");
	DLLInst1=LoadLibrary("sdtapi.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll 成功！");

	DLLInst2=LoadLibrary("WltRS.dll");
	//AfxMessageBox("LoadLibrary -WltRS.dll 成功！");
	if(DLLInst1!=NULL)
	{
		SDT_OpenPort=(int(__stdcall *)(int))GetProcAddress(DLLInst1,"SDT_OpenPort");
		SDT_ClosePort=(int(__stdcall *)(int))GetProcAddress(DLLInst1,"SDT_ClosePort");
		SDT_StartFindIDCard=(int(__stdcall *)(int,BYTE *pucIIN,int))GetProcAddress(DLLInst1,"SDT_StartFindIDCard");
		SDT_SelectIDCard=(int(__stdcall *)(int,BYTE *pucIIN,int))GetProcAddress(DLLInst1,"SDT_SelectIDCard");
		SDT_ReadBaseMsgToFile=(int(__stdcall *)(int,LPSTR filename,BYTE *puiCHMsgLen,LPSTR filename2,BYTE *puiPHMsgLen,int))GetProcAddress(DLLInst1,"SDT_ReadBaseMsgToFile");
	}
	else
	{
		AfxMessageBox("加载动态库sdtapi.dll失败！");
		exit(0);
	}
	if(DLLInst2!=NULL)
	{
		GetBmp=(int(__stdcall *)(LPSTR,int))GetProcAddress(DLLInst2,"GetBmp");
	}
	else
	{
		AfxMessageBox("加载动态库WltRS.dll失败！");
		exit(0);
	}



	return 0;
}

SHORT CETTSelfIDCardActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(DLLInst1!=NULL)
	{
		FreeLibrary(DLLInst1);
		DLLInst1=NULL;
	}
	if(DLLInst2!=NULL)
	{
		FreeLibrary(DLLInst2);
		DLLInst2=NULL;
	}


	return 0;
}

void CETTSelfIDCardActiveXCtrl::OnReadTickChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

BSTR CETTSelfIDCardActiveXCtrl::ReadFromFile(LPCTSTR filename)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	CString strTemp;
	CString strTxt;
	CFile file;
	if(file.Open(filename,CFile::modeRead|CFile::typeBinary))
	{
		WCHAR buffer[255];
		memset(buffer,0,sizeof(buffer));
		file.Read(buffer,sizeof(buffer));
		file.Close();
		CString str(buffer);
		//AfxMessageBox(str);
		CString strTemp;
		int nLength = 0;
		int tokenLength[] = {30,2,4,16,70,36,30,16,16,70};
		WCHAR bufferTemp[255];		
		for(int i=0;i<sizeof(tokenLength)/sizeof(int);i++)
		{
			memset(bufferTemp,0,sizeof(bufferTemp));
			memcpy(bufferTemp,buffer+nLength,tokenLength[i]);
			CString str(bufferTemp);
			strTemp = str;
			nLength += tokenLength[i]/sizeof(WCHAR);
			//AfxMessageBox(strTemp);
			switch(i)
			{
			case 0:
				this->m_Name=str;
				break;
			case 1:
				if(str=="1")
				{
					this->m_SexCode=1;
					this->m_SexName="男";
				}
				else if(str=="0")
				{
					this->m_SexCode=0;
					this->m_SexName="女";
				}
				break;

			case 2:
				this->m_NationCode=str;
				this->m_NationName=this->m_nationArray.Get(str);
				break;

			case 3:
				this->m_Birth=str;
				break;
			case 4:
				this->m_Address=str;
				break;
			case 5:
				this->m_IDCard=str;
				break;
			case 6:
				this->m_Fzjg=str;
				break;
			case 7:
				this->m_StartDate=str;
				break;
			case 8:
				this->m_EndDate=str;
				break;
			default:
				break;
			}

			//AfxMessageBox(strTemp);
		}
	}

	/*
	//BSTR
	CString str;

	CString strErrorID;

	char   psFirst[2]; 
	CFile cf;
	//AfxMessageBox("准备打开文件！");
	int   iFileHandle=cf.Open(filename, CFile::modeRead );
	int   iFileLength   = cf.GetLength();
	strErrorID.Format(_T("文件长度=%u;"),iFileLength);
	AfxMessageBox(strErrorID);
	//AfxMessageBox("获取了文件长度！");
	char *wstr=new char[iFileLength];      
	// wchar_t   *wstr=new   wchar_t[iFileLength+1]; 
	cf.Read(wstr,   iFileLength); 
	//AfxMessageBox("读取文件完毕！");
	cf.Close();

	strErrorID.Format(_T("文件内容=%u;"),wstr);
	AfxMessageBox(strErrorID);
	//AfxMessageBox("关闭文件完毕！");
	//WideString *a=new WideString(wstr);
	//a->toUTF8String(wstr);
	LPWSTR ttt;
	//a->ws;

	wchar_t* ws=new wchar_t;
	//WideCharToMultiByte(CP_UTF8,0,ws,-1,wstr,iFileLength,NULL,NULL);
	//int MultiByteToWideChar(UINT CodePage, DWORD dwFlags, LPCSTR lpMultiByteStr,
	//int cchMultiByte, LPWSTR lpWideCharStr, int cchWideChar); 
	// MultiByteToWideChar(CP_ACP,0,wstr,-1,ttt,iFileLength);

	int len = ::MultiByteToWideChar(CP_THREAD_ACP, 0, wstr, -1, NULL, 0);   
	strErrorID.Format(_T("长度=%u;"),len);
	AfxMessageBox(strErrorID);
	// AfxMessageBox(len);
	if (len == 0) return L"";   

	std::vector<wchar_t> unicode(len);   
	::MultiByteToWideChar(CP_THREAD_ACP, 0, wstr, -1, &unicode[0], len);   

	// return &unicode[0];  

	strErrorID.Format(_T("内容=%u;"),&unicode[0]);
	AfxMessageBox(strErrorID);

	*/


	return strTemp.AllocSysString();
}
