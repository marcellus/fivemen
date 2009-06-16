using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Exam
{
    /// <summary>
    /// �������
    /// </summary>
    [SimpleTable("table_exam_topic")]
    [Alias("�������")]
    public class ExamTopic
    {
        /// <summary>
        /// ��Ŀ��Χ
        /// </summary>
        [SimpleColumn(Column = "c_range")]
        [Alias("��Ŀ��Χ")]
        public string Range;

        public string ��Ŀ��Χ
        {
            get { return Range; }
            set { Range = value; }
        }
        /// <summary>
        /// ������,��ʱ�����������ع���
        /// </summary>
        [SimpleColumn(Column = "c_range",AllowInsert=false,AllowSelect=false,AllowUpdate=false)]
        public string UserAnswer;

        public string ������
        {
            get { return UserAnswer; }
            set { UserAnswer = value; }
        }

        /// <summary>
        /// ��ֵ��Ĭ������
        /// </summary>
        [SimpleColumn(Column = "i_score")]
        [Alias("��ֵ")]
        public int Score=2;

        public int ��ֵ
        {
            get { return Score; }
            set { Score = value; }
        }

        [SimplePK]
        [Alias("���")]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }

        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [SimpleColumn(Column = "c_topictext")]
        [Alias("��Ŀ����")]
        public string TopicText;

        public string ��Ŀ����
        {
            get { return TopicText; }
            set { TopicText = value; }
        }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [SimpleColumn(Column = "c_topictype")]
        [Alias("��Ŀ����")]
        public string TopicType;

        public string ��Ŀ����
        {
            get { return TopicType; }
            set { TopicType = value; }
        }

        /// <summary>
        /// ͼƬ·��
        /// </summary>
        [SimpleColumn(Column = "c_picpath")]
        [Alias("ͼƬ·��")]
        public string PicPath;

        public string ͼƬ·��
        {
            get { return PicPath; }
            set { PicPath = value; }
        }

        /// <summary>
        /// ��A
        /// </summary>
        [SimpleColumn(Column = "c_answer_a")]
        [Alias("��A")]
        public string AnswerA;

        public string ��A
        {
            get { return AnswerA; }
            set { AnswerA = value; }
        }
        /// <summary>
        /// ��B
        /// </summary>
        [SimpleColumn(Column = "c_answer_b")]
        [Alias("��B")]
        public string AnswerB;

        public string ��B
        {
            get { return AnswerB; }
            set { AnswerB = value; }
        }
        /// <summary>
        /// ��C
        /// </summary>
        [SimpleColumn(Column = "c_answer_c")]
        [Alias("��C")]
        public string AnswerC;

        public string ��C
        {
            get { return AnswerC; }
            set { AnswerC = value; }
        }
        /// <summary>
        /// ��D
        /// </summary>
        [SimpleColumn(Column = "c_answer_d")]
        [Alias("��D")]
        public string AnswerD;

        public string ��D
        {
            get { return AnswerD; }
            set { AnswerD = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        [SimpleColumn(Column = "c_answer")]
        [Alias("��")]
        public string Answer;

        public string ��
        {
            get { return Answer; }
            set { Answer = value; }
        }
    }
}
