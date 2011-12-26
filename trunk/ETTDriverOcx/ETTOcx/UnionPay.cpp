// UnionPay.cpp : CUnionPay µÄÊµÏÖ

#include "stdafx.h"
#include "UnionPay.h"


// CUnionPay

STDMETHODIMP CUnionPay::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] = 
	{
		&IID_IUnionPay
	};

	for (int i=0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}
	return S_FALSE;
}
