// ActiveXCash.cpp : CActiveXCash 的实现

#include "stdafx.h"
#include "ActiveXCash.h"



// CActiveXCash


STDMETHODIMP CActiveXCash::HelloA(LONG port)
{
	// TODO: 在此添加实现代码
//MessageBox("HelloA成功！");
	MessageBox(NULL,_T("HelloA成功！"),_T("对话框"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL); 
	return S_OK;
}

STDMETHODIMP CActiveXCash::Hello(void)
{
	// TODO: 在此添加实现代码
MessageBox(NULL,_T("HelloCash成功！"),_T("对话框"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL);
	return S_OK;
}
