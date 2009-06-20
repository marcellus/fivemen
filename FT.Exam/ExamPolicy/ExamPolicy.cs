using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Exam
{
    [Serializable]
    public class ExamPolicy
    {
        //合格考试4次后不让再参加了
        public int SuccessTimes = 4;

        public bool IsLimit = true;
        //TODO,一些题目挑选的策略
    }
}
