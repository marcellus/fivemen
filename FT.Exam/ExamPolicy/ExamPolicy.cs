using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Exam
{
    [Serializable]
    public class ExamPolicy
    {
        //�ϸ���4�κ����ٲμ���
        public int SuccessTimes = 4;

        public bool IsLimit = true;
        //TODO,һЩ��Ŀ��ѡ�Ĳ���
    }
}
