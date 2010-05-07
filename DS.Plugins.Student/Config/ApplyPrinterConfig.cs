using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// �״�����������
    /// </summary>
    [Serializable]
    public class ApplyPrinterConfig:FT.Commons.PrinterEx.BatchPrintConfig
    {
        /// <summary>
        /// �Ƿ��ӡ��
        /// </summary>
        public bool PrintProfile;

        /// <summary>
        /// �Ƿ������ӡ��ά����,Ĭ���д�
        /// </summary>
        public bool Allow2Dimension=true;
        /// <summary>
        /// �Ƿ������ӡ������ί���������Ϊfalse��Ĭ�ϲ���
        /// </summary>
        public bool PrintXiangCun = false;


        /// <summary>
        /// �Ƿ������ӡ��ѧʱ��
        /// </summary>
        public bool PrintApplyDate = false;
        /// <summary>
        /// �Ƿ��ӡ��ʱ�������д�����Ϣ
        /// </summary>
        public bool IsBodyCheck = false;

        

        /// <summary>
        /// ��У������¶��ٺ���
        /// </summary>
        public int NameDown=0;

        /// <summary>
        /// ��У���������ٺ���
        /// </summary>
        public int NameLeft=0;

       
    }
}
