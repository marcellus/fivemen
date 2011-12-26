// CDETTSelfIDCardActiveXEvents.h : �� Microsoft Visual C++ ������ ActiveX �ؼ���װ�������

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CDETTSelfIDCardActiveXEvents

class CDETTSelfIDCardActiveXEvents : public COleDispatchDriver
{
public:
	CDETTSelfIDCardActiveXEvents() {}		// ���� COleDispatchDriver Ĭ�Ϲ��캯��
	CDETTSelfIDCardActiveXEvents(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	CDETTSelfIDCardActiveXEvents(const CDETTSelfIDCardActiveXEvents& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// ����
public:

// ����
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
