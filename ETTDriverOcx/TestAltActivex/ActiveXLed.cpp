// ActiveXLed.cpp : CActiveXLed ��ʵ��

#include "stdafx.h"
#include "ActiveXLed.h"



// CActiveXLed


STDMETHODIMP CActiveXLed::HelloB(SHORT port)
{
	// TODO: �ڴ����ʵ�ִ���
//MessageBox("");
MessageBox(NULL,_T("HelloB�ɹ���"),_T("�Ի���"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL); 
	return S_OK;
}

STDMETHODIMP CActiveXLed::Hello(void)
{
	// TODO: �ڴ����ʵ�ִ���
MessageBox(NULL,_T("HelloLed�ɹ���"),_T("�Ի���"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL);
	return S_OK;
}
