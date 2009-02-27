using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ʹ�ô�ӡ���֮���һЩĬ������
    /// </summary>
    public class PrintCommonSetting
    {
        /// <summary>
        /// Ĭ�ϱ߿���ʽ
        /// </summary>
        public static BordersEdgeStyle Default_Border_Style = BordersEdgeStyle.All;

        /// <summary>
        /// Ĭ�ϴ�ӡ������
        /// </summary>
        public static Pen Default_Font_Pen = new Pen(Color.Black);

        /// <summary>
        /// Ĭ�ϱ߿���ɫ����ɫ�������
        /// </summary>
        public static Pen Default_Border_Pen = new Pen(Color.Black);

        /// <summary>
        /// Ĭ��ҳ��߾�
        /// </summary>
        //public static PageMargin Default_Page_Margin = new PageMargin();

        /// <summary>
        /// ��ӡ��������ܸ���ֽ���ж�
        /// </summary>
        public static int Default_Page_Height = 3508;

        public static int Default_Page_Width = 2480;//Ĭ��ΪA4ֽ��

        /// <summary>
        /// Ĭ�����ִ�С
        /// </summary>
        public static Font Default_Text_Font=new Font("����",12);

        /// <summary>
        /// Ĭ�ϱ����С
        /// </summary>
        public static Font Default_Title_Font = new Font("����", 18);

        /// <summary>
        /// Ĭ�ϱ���б����С
        /// </summary>
        public static Font Default_Column_Header_Font = new Font("����", 14);

        /// <summary>
        /// Ĭ��footer��С
        /// </summary>
        public static Font Default_Footer_Font = new Font("����", 9);

        /// <summary>
        /// Ĭ��������ɫ��ˢ
        /// </summary>
        public static Brush Default_Text_Brush = new SolidBrush(Color.Black);

        //public static Color
        //public static PageSettings Default_PageSettings = new PageSettings();
    }
}
