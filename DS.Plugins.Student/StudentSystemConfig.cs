using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    [Serializable]
    public class StudentSystemConfig
    {
        public int RegToSubject1 = 14;

        public int Subject1ReExam = 20;//科目一补考时间

        public int Subject1To20Days = 20;//科目一到科目二的时间间隔

        public int Subject20To21Days = 2;//桩考到场地考试的时间间隔

        public int Subject20ReExam = 2;//科目二(桩)补考时间

        public int Subject21ReExam = 20;//科目二(场地)补考时间

        public int Subject21To3Days = 10;

        public int Subject3ReExam = 20;//科目三补考时间

        public bool SubjectIs4 = false;


    }
}
