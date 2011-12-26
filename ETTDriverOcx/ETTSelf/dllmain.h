// dllmain.h : 模块类的声明。

class CETTSelfModule : public CAtlDllModuleT< CETTSelfModule >
{
public :
	DECLARE_LIBID(LIBID_ETTSelfLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ETTSELF, "{6C5A5870-2512-40D4-A2F6-86124EC66DB6}")
};

extern class CETTSelfModule _AtlModule;
