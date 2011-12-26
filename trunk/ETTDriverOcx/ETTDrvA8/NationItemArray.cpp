#include "StdAfx.h"
#include "NationItemArray.h"

CNationItemArray::CNationItemArray(void)
{
}

CNationItemArray::~CNationItemArray(void)
{
}
UINT CNationItemArray::GetLength()
{
	return m_arrItem.GetCount();
}
UINT CNationItemArray::Add(CString strID,CString strName)
{
	CNationItem item;
	item.strID = strID;
	item.strName = strName;
	return m_arrItem.Add(item);
}
CString CNationItemArray::Get(CString strID)
{
	CString bRes = FALSE;
	//AfxMessageBox("获取民族集合的长度！");
	for(int i=0;i<m_arrItem.GetCount();i++)
	{
		//AfxMessageBox("准备遍历民族的数组集合！");
		if(m_arrItem.GetAt(i).strID == strID)
		{
			//AfxMessageBox("寻找到code的民族");
			bRes = m_arrItem.GetAt(i).strName;
			break;
		}
	}
	return bRes;
}
BOOL CNationItemArray::Get(CString strID,CNationItem &item)
{
	BOOL bRes = FALSE;
	for(int i=0;i<m_arrItem.GetCount();i++)
	{
		if(m_arrItem.GetAt(i).strID == strID)
		{
			item.strID = m_arrItem.GetAt(i).strID;
			item.strName = m_arrItem.GetAt(i).strName;
			bRes = TRUE;
			break;
		}
	}
	return bRes;
}
BOOL CNationItemArray::Get(CNationItem &item)
{
	BOOL bRes = FALSE;
	for(int i=0;i<m_arrItem.GetCount();i++)
	{
		if(m_arrItem.GetAt(i).strID == item.strID)
		{
			item.strName = m_arrItem.GetAt(i).strName;
			bRes = TRUE;
			break;
		}
	}
	return bRes;
}
BOOL CNationItemArray::SetName(CString strID,CString strName)
{
	BOOL bRes = FALSE;
	for(int i=0;i<m_arrItem.GetCount();i++)
	{
		if(m_arrItem.GetAt(i).strID == strID)
		{
			m_arrItem.GetAt(i).strName = strName;
			bRes = TRUE;
			break;
		}
	}
	return bRes;
}
BOOL CNationItemArray::Remove(CString strID)
{
	BOOL bRes = FALSE;
	for(int i=0;i<m_arrItem.GetCount();i++)
	{
		if(m_arrItem.GetAt(i).strID == strID)
		{
			m_arrItem.RemoveAt(i);
			bRes = TRUE;
			break;
		}
	}
	return bRes;
}
void CNationItemArray::RemoveAll()
{
	m_arrItem.RemoveAll();
}