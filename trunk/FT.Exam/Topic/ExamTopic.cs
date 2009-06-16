using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Exam
{
    /// <summary>
    /// 考试题库
    /// </summary>
    [SimpleTable("table_exam_topic")]
    [Alias("考试题库")]
    public class ExamTopic
    {
        /// <summary>
        /// 题目范围
        /// </summary>
        [SimpleColumn(Column = "c_range")]
        [Alias("题目范围")]
        public string Range;

        public string 题目范围
        {
            get { return Range; }
            set { Range = value; }
        }
        /// <summary>
        /// 考生答案,临时存放用来错题回顾用
        /// </summary>
        [SimpleColumn(Column = "c_range",AllowInsert=false,AllowSelect=false,AllowUpdate=false)]
        public string UserAnswer;

        public string 考生答案
        {
            get { return UserAnswer; }
            set { UserAnswer = value; }
        }

        /// <summary>
        /// 分值，默认两分
        /// </summary>
        [SimpleColumn(Column = "i_score")]
        [Alias("分值")]
        public int Score=2;

        public int 分值
        {
            get { return Score; }
            set { Score = value; }
        }

        [SimplePK]
        [Alias("编号")]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }

        }
        /// <summary>
        /// 题目内容
        /// </summary>
        [SimpleColumn(Column = "c_topictext")]
        [Alias("题目内容")]
        public string TopicText;

        public string 题目内容
        {
            get { return TopicText; }
            set { TopicText = value; }
        }

        /// <summary>
        /// 题目类型
        /// </summary>
        [SimpleColumn(Column = "c_topictype")]
        [Alias("题目类型")]
        public string TopicType;

        public string 题目类型
        {
            get { return TopicType; }
            set { TopicType = value; }
        }

        /// <summary>
        /// 图片路径
        /// </summary>
        [SimpleColumn(Column = "c_picpath")]
        [Alias("图片路径")]
        public string PicPath;

        public string 图片路径
        {
            get { return PicPath; }
            set { PicPath = value; }
        }

        /// <summary>
        /// 答案A
        /// </summary>
        [SimpleColumn(Column = "c_answer_a")]
        [Alias("答案A")]
        public string AnswerA;

        public string 答案A
        {
            get { return AnswerA; }
            set { AnswerA = value; }
        }
        /// <summary>
        /// 答案B
        /// </summary>
        [SimpleColumn(Column = "c_answer_b")]
        [Alias("答案B")]
        public string AnswerB;

        public string 答案B
        {
            get { return AnswerB; }
            set { AnswerB = value; }
        }
        /// <summary>
        /// 答案C
        /// </summary>
        [SimpleColumn(Column = "c_answer_c")]
        [Alias("答案C")]
        public string AnswerC;

        public string 答案C
        {
            get { return AnswerC; }
            set { AnswerC = value; }
        }
        /// <summary>
        /// 答案D
        /// </summary>
        [SimpleColumn(Column = "c_answer_d")]
        [Alias("答案D")]
        public string AnswerD;

        public string 答案D
        {
            get { return AnswerD; }
            set { AnswerD = value; }
        }
        /// <summary>
        /// 答案
        /// </summary>
        [SimpleColumn(Column = "c_answer")]
        [Alias("答案")]
        public string Answer;

        public string 答案
        {
            get { return Answer; }
            set { Answer = value; }
        }
    }
}
