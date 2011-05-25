
#pragma once
#include <afxtempl.h>
class CNationItemArray
{
public:
	typedef struct __Item
	{
		CString strID;
		CString strName;
	}CNationItem,*CNationItemPtr;
public:
	CNationItemArray(void);
	virtual ~CNationItemArray(void);
public:
	UINT GetLength();
	UINT Add(CString strID,CString strName);
	CString Get(CString strID);
	BOOL Get(CString strID,CNationItem &item);
	BOOL Get(CNationItem &item);
	BOOL SetName(CString strID,CString strName);
	BOOL Remove(CString strID);
	void RemoveAll();
protected:
	CArray<CNationItem,CNationItem> m_arrItem;
};
