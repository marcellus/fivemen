using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ��ӡ�ͻ�ͼ����Ľӿ�
    /// </summary>
    public interface IDraw
    {

        /// <summary>
        /// ��ȡ�����û�������
        /// </summary>
        System.Drawing.Rectangle Rectangle
        {
            get;
            set;
        }

        /// <summary>
        /// ����
        /// </summary>
        void Draw(Graphics graphics);

        /// <summary>
        /// �Ƿ�������,����϶���ʹ��
        /// </summary>
        /// <returns>���û�л�����ϣ���ҳ����</returns>
        bool IsFinish();
    }
}
