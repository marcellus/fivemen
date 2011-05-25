// dllmain.h : 模块类的声明。

class CTestAddBtnModule : public CAtlDllModuleT< CTestAddBtnModule >
{
public :
	DECLARE_LIBID(LIBID_TestAddBtnLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_TESTADDBTN, "{C9BB5DEF-BBEB-4F47-B4DA-C632D820217C}")
};

extern class CTestAddBtnModule _AtlModule;
