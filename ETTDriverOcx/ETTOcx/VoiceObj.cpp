// VoiceObj.cpp : CVoiceObj 的实现

#include "stdafx.h"
#include "VoiceObj.h"


// CVoiceObj

STDMETHODIMP CVoiceObj::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] = 
	{
		&IID_IVoiceObj
	};

	for (int i=0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}
	return S_FALSE;
}

STDMETHODIMP CVoiceObj::PlayVoice(BSTR filename)
{
	// TODO: 在此添加实现代码
	PlaySound(filename, NULL, SND_FILENAME | SND_ASYNC);
	//PlaySound(_T("e:\\1.wav"), NULL, SND_FILENAME | SND_ASYNC);

	return S_OK;
}
