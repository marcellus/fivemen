// ActiveXLed.cpp : CActiveXLed 的实现

#include "stdafx.h"
#include "ActiveXLed.h"



// CActiveXLed


STDMETHODIMP CActiveXLed::HelloB(SHORT port)
{
	// TODO: 在此添加实现代码
//MessageBox("");
MessageBox(NULL,_T("HelloB成功！"),_T("对话框"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL); 
	return S_OK;
}

STDMETHODIMP CActiveXLed::Hello(void)
{
	// TODO: 在此添加实现代码
MessageBox(NULL,_T("HelloLed成功！"),_T("对话框"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL);
	return S_OK;
}
