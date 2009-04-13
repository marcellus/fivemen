using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    [Serializable]
    public class StudentSystemConfig
    {
        public int RegToSubject1 = 14;

        public int Subject1ReExam = 20;//��Ŀһ����ʱ��

        public int Subject1To20Days = 20;//��Ŀһ����Ŀ����ʱ����

        public int Subject20To21Days = 2;//׮�������ؿ��Ե�ʱ����

        public int Subject20ReExam = 2;//��Ŀ��(׮)����ʱ��

        public int Subject21ReExam = 20;//��Ŀ��(����)����ʱ��

        public int Subject21To3Days = 10;

        public int Subject3ReExam = 20;//��Ŀ������ʱ��

        public bool SubjectIs4 = false;


    }
}
