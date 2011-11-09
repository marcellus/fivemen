using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FingerCollection
{
    
        [SimpleTable("table_local_finger_record")]
        [Alias("待上传的指纹记录")]
        public class LocalFingerRecordObject 
        {

            [SimplePK]
            [Alias("编号")]
            public int Id;

            public string 编号
            {
                get { return Id.ToString(); }
            }

            [SimpleColumn(Column = "c_name")]
            [Alias("姓名")]
            public String Name;

            /// <summary>
            /// 供datagridview显示使用
            /// </summary>
            public String 姓名
            {
                get { return Name; }
                set { Name = value; }
            }

            [SimpleColumn(Column = "c_idcard")]
            [Alias("身份证明号码")]
            public String IdCard;

            public String 身份证明号码
            {
                get { return IdCard; }
                set { IdCard = value; }
            }

            [SimpleColumn(Column = "c_create_time")]
            [Alias("创建时间")]
            public String CreateTime;

            public String 创建时间
            {
                get { return CreateTime; }
                set { CreateTime = value; }
            }

            [SimpleColumn(Column = "c_upload_time")]
            [Alias("上传时间")]
            public String UploadTime;

            public String 上传时间
            {
                get { return UploadTime; }
                set { UploadTime = value; }
            }

            [SimpleColumn(Column = "c_school_name")]
            [Alias("驾校名称")]
            public String SchoolName;

            public String 驾校名称
            {
                get { return SchoolName; }
                set { SchoolName = value; }
            }

            [SimpleColumn(Column = "c_school_code")]
            [Alias("驾校代码")]
            public String SchoolCode;

            public String 驾校代码
            {
                get { return SchoolCode; }
                set { SchoolCode = value; }
            }


            [SimpleColumn(Column = "c_lsh")]
            [Alias("流水号")]
            public String Lsh;

            public String 流水号
            {
                get { return Lsh; }
                set { Lsh = value; }
            }

            [SimpleColumn(Column = "c_pxrq")]
            [Alias("培训日期")]
            public String Pxrq;

            public String 培训日期
            {
                get { return Pxrq; }
                set { Pxrq = value; }
            }


            [SimpleColumn(Column = "c_student_type")]
            [Alias("学员类型")]
            public String StudentType;

            public String 学员类型
            {
                get { return StudentType; }
                set { StudentType = value; }
            }

            [SimpleColumn(Column = "c_car_type")]
            [Alias("学习车型")]
            public String LearnCar;

            public String 学习车型
            {
                get { return LearnCar; }
                set { LearnCar = value; }
            }
        }
    
}
