using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Lottery
{
    /// <summary>
    /// ����
    /// </summary>
    [SimpleTable("table_season")]
    public class Season : BaseEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name=string.Empty;
    }
    /// <summary>
    /// ������������
    /// </summary>
    [SimpleTable("table_team")]
    public class Team : BaseEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [SimpleColumn(Column = "c_season_name")]
        public string SeasonName = string.Empty;

        /// <summary>
        /// ��������
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name = string.Empty;

        /// <summary>
        /// ����ʵ�����ϣ��У���
        /// </summary>
        [SimpleColumn(Column = "c_level")]
        public string Level = string.Empty;
    }

    /// <summary>
    /// ��Ʊ��
    /// </summary>
    [SimpleTable("table_lottery_times")]
    public class LotteryTimes : BaseEntity
    {
        /// <summary>
        /// �ڼ�������
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name = string.Empty;
    }
    /// <summary>
    /// ����
    /// </summary>
    [SimpleTable("table_race")]
    public class Race : BaseEntity
    {
        /// <summary>
        /// �ڼ�������
        /// </summary>
        [SimpleColumn(Column = "c_times")]
        public string Times = string.Empty;

        /// <summary>
        /// ����
        /// </summary>
        [SimpleColumn(Column = "c_first_team")]
        public string FirstTeam = string.Empty;

        /// <summary>
        /// �Ͷ�
        /// </summary>
        [SimpleColumn(Column = "c_second_team")]
        public string SecondTeam = string.Empty;

        /// <summary>
        /// ����
        /// </summary>
        [SimpleColumn(Column = "int_result")]
        public int Result = string.Empty;

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        [SimpleColumn(Column = "bool_iscool")]
        public bool IsCool = false;

        
    }
    [SimpleTable("table_guessperson")]
    public class GuessPerson : BaseEntity
    {
        /// <summary>
        /// �²�������
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name = string.Empty;
    }
    /// <summary>
    /// ����
    /// </summary>
    [SimpleTable("table_guessresult")]
    public class GuessResult : BaseEntity
    {
        /// <summary>
        /// �ڼ�������
        /// </summary>
        [SimpleColumn(Column = "c_times")]
        public string Times = string.Empty;

        /// <summary>
        /// ʮ�ĳ�˳�򣬴�0��ʼ
        /// </summary>
        [SimpleColumn(Column = "int_num")]
        public int Num = 0;

        /// <summary>
        /// �²�������
        /// </summary>
        [SimpleColumn(Column = "c_person_name")]
        public string Person = string.Empty;
        /// <summary>
        /// �²������
        /// </summary>
        [SimpleColumn(Column = "c_result")]
        public string Result = string.Empty;

        /// <summary>
        /// �Ƿ���ȷ
        /// </summary>
        [SimpleColumn(Column = "bool_isright")]
        public bool IsRight;


        

    }
}
