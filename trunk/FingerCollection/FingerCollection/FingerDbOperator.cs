using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL;
using System.Data;
using FT.DAL.Orm;

namespace FingerCollection
{
    public class FingerDbOperator
    {
        /// <summary>
        /// 新增指纹采集的姓名和身份证明号码记录
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="name"></param>
        public static void Enroll(string idcard,string name)
        {
            LocalFingerRecordObject obj = new LocalFingerRecordObject();
            obj.CreateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj.IdCard = idcard;
            obj.Name = name;
            obj.UploadTime = string.Empty;
            SimpleOrmOperator.Create(obj);
            BackFingerInfo();

            
        }

        public static bool Exists(string idcard)
        {

            IDataAccess access = DataAccessFactory.GetDataAccess();
            DataTable dt1 = access.SelectDataTable("select * from (select * from table_local_finger_record union select * from table_upload_finger_record) t where t.c_idcard='"+idcard+"'", "tmp");
            return dt1!=null&&dt1.Rows.Count>0;
        }

        public static bool DeleteUser(string idcard)
        {
            IDataAccess access = DataAccessFactory.GetDataAccess();
            string sql = "delete from USER_INFO_UPLOAD  where USER_ID='"+idcard+"'";
            access.ExecuteSql(sql);
           
            sql = "delete from ENROLL_TEMP_UPLOAD  where USER_ID='"+idcard+"'";
            access.ExecuteSql(sql);
            sql = "delete from  table_local_finger_record where c_idcard='" + idcard + "'";
            return access.ExecuteSql(sql);
        }

        /// <summary>
        /// 备份指纹记录到准备上传的表中
        /// </summary>
        public static void BackFingerInfo()
        {
            IDataAccess access=DataAccessFactory.GetDataAccess();
            DataTable dt1 = access.SelectDataTable("select * from USER_INFO where USER_ID<>'sa'", "tmp");
            DataRow dr=null;
            if(dt1!=null&&dt1.Rows.Count>0)
            {
                string sql = "insert into USER_INFO_UPLOAD select * from  USER_INFO where USER_ID<>'sa'";
                access.ExecuteSql(sql);
                sql = "delete from  USER_INFO where USER_ID<>'sa'";
                access.ExecuteSql(sql);
                sql = "insert into ENROLL_TEMP_UPLOAD select * from  ENROLL_TEMP where USER_ID<>'sa'";
                access.ExecuteSql(sql);
                sql = "delete from  ENROLL_TEMP where USER_ID<>'sa'";
                access.ExecuteSql(sql);

            }
            
        }
    }
}
