#pragma once

// ������������� Microsoft Visual C++ ������ IDispatch ��װ��

// ע��: ��Ҫ�޸Ĵ��ļ������ݡ����������
//  Microsoft Visual C++ �������ɣ������޸Ľ������ǡ�

/////////////////////////////////////////////////////////////////////////////
// CEttselfidcardactctrl1 ��װ��

class CEttselfidcardactctrl1 : public CWnd
{
protected:
	DECLARE_DYNCREATE(CEttselfidcardactctrl1)
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

// ����
public:


// ����
public:

// _DETTSelfIDCardActiveX

// Functions
//


// Properties
//



};
