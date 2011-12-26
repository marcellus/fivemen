// CDETTSelfIDCardActiveX.h : 由 Microsoft Visual C++ 创建的 ActiveX 控件包装类的声明

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CDETTSelfIDCardActiveX

class CDETTSelfIDCardActiveX : public CWnd
{
protected:
	DECLARE_DYNCREATE(CDETTSelfIDCardActiveX)
public:
	CLSID const& GetClsid()
	{
		static CLSID const clsid
			= { 0x447C4906, 0x6678, 0x461B, { 0x9E, 0x20, 0x10, 0xB, 0xDE, 0x91, 0x38, 0x28 } };
		return clsid;
	}
	virtual BOOL Create(LPCTSTR lpszClassName, LPCTSTR lpszWindowName, DWORD dwStyle,
						const RECT& rect, CWnd* pParentWnd, UINT nID, 
						CCreateContext* pContext = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID); 
	}

    BOOL Create(LPCTSTR lpszWindowName, DWORD dwStyle, const RECT& rect, CWnd* pParentWnd, 
				UINT nID, CFile* pPersist = NULL, BOOL bStorage = FALSE,
				BSTR bstrLicKey = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID,
		pPersist, bStorage, bstrLicKey); 
	}

// 属性
public:

// 操作
public:



};
