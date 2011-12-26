// CDETTSelfIDCardActiveXEvents.h : 由 Microsoft Visual C++ 创建的 ActiveX 控件包装类的声明

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CDETTSelfIDCardActiveXEvents

class CDETTSelfIDCardActiveXEvents : public COleDispatchDriver
{
public:
	CDETTSelfIDCardActiveXEvents() {}		// 调用 COleDispatchDriver 默认构造函数
	CDETTSelfIDCardActiveXEvents(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	CDETTSelfIDCardActiveXEvents(const CDETTSelfIDCardActiveXEvents& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// 属性
public:

// 操作
public:

	short ReadIDCard()
	{
		short result;
		InvokeHelper(0x10, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short LoadDll()
	{
		short result;
		InvokeHelper(0x13, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short DestroyDll()
	{
		short result;
		InvokeHelper(0x14, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	CString ReadFromFile(LPCTSTR filename)
	{
		CString result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x16, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, filename);
		return result;
	}


};
