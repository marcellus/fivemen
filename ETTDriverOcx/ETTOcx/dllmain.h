// dllmain.h : ģ�����������

class CETTOcxModule : public CAtlDllModuleT< CETTOcxModule >
{
public :
	DECLARE_LIBID(LIBID_ETTOcxLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ETTOCX, "{F51892EC-A65D-4E6A-9305-C9003A4A87ED}")
};

extern class CETTOcxModule _AtlModule;
