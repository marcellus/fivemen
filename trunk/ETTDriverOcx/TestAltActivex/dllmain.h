// dllmain.h : 模块类的声明。

class CTestAltActivexModule : public CAtlDllModuleT< CTestAltActivexModule >
{
public :
	DECLARE_LIBID(LIBID_TestAltActivexLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_TESTALTACTIVEX, "{382DE169-C3A5-46F9-B9E5-3EBFD02D21AB}")
};

extern class CTestAltActivexModule _AtlModule;
