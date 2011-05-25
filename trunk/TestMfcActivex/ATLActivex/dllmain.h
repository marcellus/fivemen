// dllmain.h : 模块类的声明。

class CATLActivexModule : public CAtlDllModuleT< CATLActivexModule >
{
public :
	DECLARE_LIBID(LIBID_ATLActivexLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLACTIVEX, "{683F8334-5234-4F5B-8A83-DFEF1A2C2468}")
};

extern class CATLActivexModule _AtlModule;
