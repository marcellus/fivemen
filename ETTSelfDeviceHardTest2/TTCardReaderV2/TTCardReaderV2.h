// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� TTCARDREADERV2_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// TTCARDREADERV2_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef TTCARDREADERV2_EXPORTS
#define TTCARDREADERV2_API __declspec(dllexport)
#else
#define TTCARDREADERV2_API __declspec(dllimport)
#endif

// �����Ǵ� TTCardReaderV2.dll ������
class TTCARDREADERV2_API CTTCardReaderV2 {
public:
	CTTCardReaderV2(void);
	// TODO: �ڴ�������ķ�����
};

extern TTCARDREADERV2_API int nTTCardReaderV2;

TTCARDREADERV2_API int fnTTCardReaderV2(void);


