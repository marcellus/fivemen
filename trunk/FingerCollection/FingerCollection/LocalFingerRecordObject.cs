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
        }
    
}
