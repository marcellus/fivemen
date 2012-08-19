using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HiPiaoInterface
{
    [Serializable]
    public class MovieObject
    {
        [NonSerialized]
        public Image AdImage;

        public string AdImagePath;

        /// <summary>
        /// 影片编号
        /// </summary>
        public string Id;

        public string Name;
        /// <summary>
        /// 影片英文名
        /// </summary>
        public string OtherName;

        public string Director;

        public string ScreenWriter;

        /// <summary>
        /// 主演
        /// </summary>
        public string MainActors;

        /// <summary>
        /// 影片分类
        /// </summary>
        public string Type;

        /// <summary>
        /// 影片出品国
        /// </summary>
        public string BelongArea;

        public string Language;

        /// <summary>
        /// 影片公映时间
        /// </summary>
        public DateTime ShowDate;

        public DateTime PlayTime;

        /// <summary>
        /// 影片时长
        /// </summary>
        public int TotalMinutes;

        public int StarGrade;

        /// <summary>
        /// 影片介绍
        /// </summary>
        public string Introduction;

        public List<Image> ClassicImages = new List<Image>();
    }
}
