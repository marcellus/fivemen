using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Lottery
{
    /// <summary>
    /// 赛季
    /// </summary>
    [SimpleTable("table_season")]
    public class Season : BaseEntity
    {
        /// <summary>
        /// 赛季名称
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name=string.Empty;
    }
    /// <summary>
    /// 赛季队伍名称
    /// </summary>
    [SimpleTable("table_team")]
    public class Team : BaseEntity
    {
        /// <summary>
        /// 赛季名称
        /// </summary>
        [SimpleColumn(Column = "c_season_name")]
        public string SeasonName = string.Empty;

        /// <summary>
        /// 队伍名称
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name = string.Empty;

        /// <summary>
        /// 队伍实力，上，中，下
        /// </summary>
        [SimpleColumn(Column = "c_level")]
        public string Level = string.Empty;
    }

    /// <summary>
    /// 彩票期
    /// </summary>
    [SimpleTable("table_lottery_times")]
    public class LotteryTimes : BaseEntity
    {
        /// <summary>
        /// 第几期名称
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name = string.Empty;
    }
    /// <summary>
    /// 比赛
    /// </summary>
    [SimpleTable("table_race")]
    public class Race : BaseEntity
    {
        /// <summary>
        /// 第几期名称
        /// </summary>
        [SimpleColumn(Column = "c_times")]
        public string Times = string.Empty;

        /// <summary>
        /// 主队
        /// </summary>
        [SimpleColumn(Column = "c_first_team")]
        public string FirstTeam = string.Empty;

        /// <summary>
        /// 客队
        /// </summary>
        [SimpleColumn(Column = "c_second_team")]
        public string SecondTeam = string.Empty;

        /// <summary>
        /// 赛果
        /// </summary>
        [SimpleColumn(Column = "int_result")]
        public int Result = string.Empty;

        /// <summary>
        /// 是否冷门
        /// </summary>
        [SimpleColumn(Column = "bool_iscool")]
        public bool IsCool = false;

        
    }
    [SimpleTable("table_guessperson")]
    public class GuessPerson : BaseEntity
    {
        /// <summary>
        /// 猜测人姓名
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        public string Name = string.Empty;
    }
    /// <summary>
    /// 赛果
    /// </summary>
    [SimpleTable("table_guessresult")]
    public class GuessResult : BaseEntity
    {
        /// <summary>
        /// 第几期名称
        /// </summary>
        [SimpleColumn(Column = "c_times")]
        public string Times = string.Empty;

        /// <summary>
        /// 十四场顺序，从0开始
        /// </summary>
        [SimpleColumn(Column = "int_num")]
        public int Num = 0;

        /// <summary>
        /// 猜测人名称
        /// </summary>
        [SimpleColumn(Column = "c_person_name")]
        public string Person = string.Empty;
        /// <summary>
        /// 猜测的赛果
        /// </summary>
        [SimpleColumn(Column = "c_result")]
        public string Result = string.Empty;

        /// <summary>
        /// 是否正确
        /// </summary>
        [SimpleColumn(Column = "bool_isright")]
        public bool IsRight;


        

    }
}
