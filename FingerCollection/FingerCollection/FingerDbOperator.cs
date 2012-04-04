using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL;
using System.Data;
using FT.DAL.Orm;
using FT.Commons.Cache;
using System.Windows.Forms;

namespace FingerCollection
{
    public class FingerDbOperator
    {
        
        
       /// <summary>
        /// 更新学员资料
       /// </summary>
       /// <param name="idcard"></param>
       /// <param name="lsh"></param>
       /// <param name="name"></param>
       /// <param name="pxshrq"></param>
       /// <param name="studenttype"></param>
       /// <param name="learncar"></param>
       /// <returns></returns>
        public static bool UpdateInfo(string idcard,string lsh,string name,string pxshrq,string studenttype,string learncar)
        {
            IDataAccess access = DataAccessFactory.GetDataAccess();
            string sql = "update table_local_finger_record set c_lsh='" + lsh + "',c_pxrq='" + pxshrq + "',c_name='" + name + "',c_student_type='" + studenttype + "',c_car_type='" + learncar + "' where c_idcard='" + idcard + "'  ";
            return access.ExecuteSql(sql);
        }


        public static void BindDict(ComboBox cb ,string type)
        {
            string sql="SELECT * FROM table_dict WHERE c_grouptype='"+type+"'";
            IDataAccess access = DataAccessFactory.GetDataAccess();
            DataTable dt = access.SelectDataTable(sql,"tmp");
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.DisplayMember = "c_text";
            cb.ValueMember = "c_value";
            cb.DataSource = dt;
            
        }
        /// <summary>
        /// 更新流水号
        /// </summary>
        /// <param name="idcard">身份证号码</param>
        /// <param name="lsh">流水号</param>
        public static void UpdateLsh(string idcard, string lsh)
        {
            IDataAccess access = DataAccessFactory.GetDataAccess();
            string sql = "update table_local_finger_record set c_lsh='" + lsh + "' where c_idcard='"+idcard+"'  ";
            access.ExecuteSql(sql);
        }
        /// <summary>
        /// 清空所有的要上传的指纹记录
        /// </summary>
        public static void Clear()
        {

            IDataAccess access = DataAccessFactory.GetDataAccess();
            string sql = "delete from USER_INFO_UPLOAD  ";
            access.ExecuteSql(sql);
            sql = "delete from ENROLL_TEMP_UPLOAD";
            access.ExecuteSql(sql);
            sql = "delete from  table_local_finger_record";
            access.ExecuteSql(sql);
            sql = "delete from  table_upload_finger_record";
            access.ExecuteSql(sql);
        }


        /// <summary>
        /// 新增指纹采集的姓名和身份证明号码记录
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="name"></param>
        public static void Enroll(string idcard,string name,string pxrq,string studenttype,string car)
        {
            LocalFingerRecordObject obj = new LocalFingerRecordObject();
            obj.CreateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj.IdCard = idcard;
            obj.Name = name;
            obj.UploadTime = string.Empty;
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            obj.Lsh = "";
            obj.SchoolName = config.SchoolName;
            obj.SchoolCode = config.SchoolCode;
            obj.Pxrq = pxrq;
            obj.StudentType = studenttype;
            obj.LearnCar = car;
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
        /// 清空所有亚略特指纹信息
        /// </summary>
        public static void ClearFingerAratek()
        {
            IDataAccess access = DataAccessFactory.GetDataAccess();
            string sql = string.Empty;
            //string sql = "insert into USER_INFO_UPLOAD select * from  USER_INFO where USER_ID<>'sa'";
            //access.ExecuteSql(sql);
            sql = "delete from  USER_INFO where USER_ID<>'sa'";
            access.ExecuteSql(sql);
            //sql = "insert into ENROLL_TEMP_UPLOAD select * from  ENROLL_TEMP where USER_ID<>'sa'";
            //access.ExecuteSql(sql);
            sql = "delete from  ENROLL_TEMP where USER_ID<>'sa'";
            access.ExecuteSql(sql);
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
