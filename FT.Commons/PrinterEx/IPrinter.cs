using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// ��ӡ�Ľӿڶ��󣬶������Ҳһ��,compositeģʽ
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// ��ȡ��ӡ�ĵ�ǰҳ��һ������Ҳ����Էֶ�ҳ��ӡ
        /// </summary>
        /// <returns>��ǰҳ��</returns>
        int GetCurrentPage();

        /// <summary>
        /// ��ȡһ����ӡ�����ܴ�ӡ����ҳ�����������
        /// </summary>
        /// <returns></returns>
        int GetTotalPage();
       
        /// <summary>
        /// �ж��Ƿ��и����ҳ
        /// </summary>
        /// <returns>
        /// 	<c>true</c> ����и����ҳ; ����, <c>false</c>.
        /// </returns>
        bool HasMorePage();


        /// <summary>
        /// ֱ��ִ�д�ӡ
        /// </summary>
        void Print();

        
        /// <summary>
        /// ��ӡԤ��
        /// </summary>
        void Preview();

        /// <summary>
        /// ��ӡ��ʵ����ǰҳ��ͼƬ
        /// </summary>
        /// <returns>��ǰҳ���ɵ�ͼƬ</returns>
        Image Paint();
    }

    /// <summary>
    /// ��ӡʹ��īˮ�����Ҳ�����״��ȫ��
    /// </summary>
    public enum PrintInkStype
    {
        /// <summary>
        /// ʡī��Ҳ�����״�
        /// </summary>
        SaveInk,
        /// <summary>
        /// ȫ��ӡ���еװ�ģ��װ���Դ������ͼƬ��Excel������word���ĵ�
        /// </summary>
        Whole
    }
}
