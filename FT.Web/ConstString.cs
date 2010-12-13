using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Web
{
    public class ConstString
    {
        /***************************************************************
                             Dictionary Tables 
        ***************************************************************/

        #region ��Ʒ����ģ������Ҫ�����Ͷ���
        public const int FactoryType = 200;//������Ӧ�����
        public const int DepartmentType = 201;//������������
        public const int StoreType = 300;//�������
        public const int Add = 0;//���ӵ���־����
        public const int Delete = 1;//ɾ������־����
        public const int Update = 2;//�޸ĵ���־����
        public const int OpComplete = 0;//�������
        public const int OpFailed = 1;//����ʧ��
        #endregion 

        /***************************************************************
                          The End Of Dictionary Tables 
        ***************************************************************/


        /***************************************************************
                             Page Rights
        ***************************************************************/

        #region ��Ʒ����ģ���е�Ȩ�޶���
        public const int OnlyCanSeeSelf = 200;//�鿴������Ʒ
        public const int OnlyCanSeeAll = 201;//�鿴ȫ����Ʒ
        public const int CanUpdateSelf = 202;//�޸ı�����Ʒ ������
        public const int CanUpdateAll = 203;//�޸�ȫ����Ʒ  ������
        public const int TypeManage = 204;//���͹���Ȩ��
        public const int StoreTypeManage=205;//�����Ʒ���͹���
        public const int StoreManage = 206;//������
        public const int FactoryManage = 207;//���̹���
        public const int StoreEdit = 208;//���ʹ���-�����������ɾ���޸�Ȩ��
        public const int MessageManage = 501;//���Թ���
        public const int NewsManage = 100;//���Ź���
        public const int TypeResume = 602;//��������
        public const int TypePosition = 601;//ְλ����
        public const int BackManage = 400;//��̨����
        public const int RoleManage = 401;//��ɫ����
        public const int UserManage = 402;//��Ա����
        public const int Anounct = 800;//�������
        public const int Link = 801;//���ӹ���
        public const int DBManage = 802;//���ݿ����
        public const int Project = 803;//���̹���
        public const int FileManage = 804;//fck�ϴ��ļ�����

        public const int EMail = 900;//ӵ��EMail

      

        #endregion 

        /***************************************************************
                          The End Of Page Rights 
        ***************************************************************/

        #region ����ͷ����
        public static  string[] FactoryReportHeader=new string[]{"���","����","��������","��ַ","��ϵ��","��ϵ�绰","��ע"};
        #endregion
    }
}
