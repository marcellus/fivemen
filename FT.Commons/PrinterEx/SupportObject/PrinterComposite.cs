using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ��ϴ�ӡ����,�ж����ж��Ƿ�ɴ�ӡ���ɿ���жϣ�table֮����ɸ߶��ж�
    /// ����ڶ�����������������
    /// </summary>
    public abstract class PrinterComposite : BaseDraw
    {

       




        /// <summary>
        /// �Ƿ�ɼ���һ��Idraw����
        /// </summary>
        /// <param name="draw">��Ҫ��ӵ���϶����еĶ���</param>
        /// <returns>�Ƿ�����,�����������׳��쳣</returns>
        protected abstract void CheckAdd(IDraw draw);

        protected List<IDraw> list = new List<IDraw>();

        public void Add(IDraw draw)
        {
            if (draw.Rectangle.Height > this.Rectangle.Height)
            {
                throw new ArgumentException("�ɴ�ӡ���Ӷ���߶ȳ���������ĸ߶ȣ�");
            }
            if (draw.Rectangle.Width > this.Rectangle.Width)
            {
                throw new ArgumentException("�ɴ�ӡ���Ӷ����ȳ���������Ŀ�ȣ�");
            }
            CheckAdd(draw);
                
            list.Add(draw);
          
        }






        protected override void DrawContent(Graphics graphics)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool IsFinish()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
