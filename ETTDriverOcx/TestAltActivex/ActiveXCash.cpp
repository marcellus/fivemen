// ActiveXCash.cpp : CActiveXCash ��ʵ��

#include "stdafx.h"
#include "ActiveXCash.h"



// CActiveXCash


STDMETHODIMP CActiveXCash::HelloA(LONG port)
{
	// TODO: �ڴ����ʵ�ִ���
//MessageBox("HelloA�ɹ���");
	MessageBox(NULL,_T("HelloA�ɹ���"),_T("�Ի���"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL); 
	return S_OK;
}

STDMETHODIMP CActiveXCash::Hello(void)
{
	// TODO: �ڴ����ʵ�ִ���
MessageBox(NULL,_T("HelloCash�ɹ���"),_T("�Ի���"),MB_YESNO|MB_ICONQUESTION|MB_DEFBUTTON1|MB_SYSTEMMODAL);
	return S_OK;
}
