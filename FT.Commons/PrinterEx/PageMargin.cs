using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// ������ҳ������
    /// </summary>
    public class PageMargin
    {
        private int top=10;

        /// <summary>
        /// �ϱ߾�
        /// </summary>
        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        private int bottom=10;

        /// <summary>
        /// �±߾�
        /// </summary>
        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        private int left=10;

        /// <summary>
        /// ��߾�
        /// </summary>
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        private int right=10;

        /// <summary>
        /// �ұ߾�
        /// </summary>
        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        private int pindingWidth;

        /// <summary>
        /// װ���߿�ȣ��������0�Ͳ���ӡװ����
        /// </summary>
        public int PindingWidth
        {
            get { return pindingWidth; }
            set { pindingWidth = value; }
        }
        
        private int pindingLine;

        /// <summary>
        /// װ����λ�þ����С
        /// </summary>
        public int PindingLine
        {
            get { return pindingLine; }
            set { pindingLine = value; }
        }

        private Direction pindDirection=Direction.Left;

        /// <summary>
        /// װ���߷���,Ĭ�����
        /// </summary>
        public Direction PindDirection
        {
            get { return pindDirection; }
            set { pindDirection = value; }
        }

        private int height;

        /// <summary>
        /// ҳ��ĸ߶�
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

       
        private int width;

        /// <summary>
        /// ҳ��Ŀ��
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public PageMargin()
        {
        }


        /// <summary>
        /// ͨ��PrintDocument��ȡһ��PrinterMargins����
        /// </summary>
        /// <param name="printDocument"></param>
        /// <returns></returns>
        public PageMargin(PrintDocument printDocument)
        {

            left = printDocument.DefaultPageSettings.Margins.Left;
            right = printDocument.DefaultPageSettings.Margins.Right;

            top = printDocument.DefaultPageSettings.Margins.Top;
            bottom = printDocument.DefaultPageSettings.Margins.Bottom;

            width = printDocument.DefaultPageSettings.PaperSize.Width;
            height = printDocument.DefaultPageSettings.PaperSize.Height;


            //�����Ϊ��ӡ���Ŀ�������ҳ�����߼�ȥ��Ӧ�ı߾�
            width = width - left - right;
            height = height - top - bottom;
            if (width < 0 || height < 0)
            {
                throw new ArgumentException("��Ч�Ļ�ͼ��Χ�ĳ��Ȼ��߿�Ȳ���С��0��");
            }
        }
    }

    /// <summary>
    /// �����λ��
    /// </summary>
    public enum Direction
    {
        Left,Right,Top,Bottom
    }
}
