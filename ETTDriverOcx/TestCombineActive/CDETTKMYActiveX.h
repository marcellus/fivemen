// CDETTKMYActiveX.h : 由 Microsoft Visual C++ 创建的 ActiveX 控件包装类的声明

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CDETTKMYActiveX

class CDETTKMYActiveX : public CWnd
{
protected:
	DECLARE_DYNCREATE(CDETTKMYActiveX)
public:
	CLSID const& GetClsid()
	{
		static CLSID const clsid
			= { 0xD6E52475, 0x390E, 0x4C62, { 0x87, 0x85, 0x32, 0xF2, 0x5A, 0x5C, 0x1B, 0xC4 } };
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

	short OpenDevice(short port)
	{
		short result;
		static BYTE parms[] = VTS_I2 ;
		InvokeHelper(0x2, DISPATCH_METHOD, VT_I2, (void*)&result, parms, port);
		return result;
	}
	short ResetDevice(short type)
	{
		short result;
		static BYTE parms[] = VTS_I2 ;
		InvokeHelper(0x3, DISPATCH_METHOD, VT_I2, (void*)&result, parms, type);
		return result;
	}
	short CloseDevice()
	{
		short result;
		InvokeHelper(0x4, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short KeyboardControl(short type)
	{
		short result;
		static BYTE parms[] = VTS_I2 ;
		InvokeHelper(0x5, DISPATCH_METHOD, VT_I2, (void*)&result, parms, type);
		return result;
	}
	short LoadDll()
	{
		short result;
		InvokeHelper(0x6, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short DestroyDll()
	{
		short result;
		InvokeHelper(0x7, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short WatchKeyPress()
	{
		short result;
		InvokeHelper(0x8, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}


};
