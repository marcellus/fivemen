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
