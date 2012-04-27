using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FingerMonitor
{
    [SimpleTable("FP_STUDENT")]
    [Alias("学员表")]
    [Serializable]
    public class FpStudentObject
    {

        [SimplePK]
        [SimpleColumn(Column = "IDCARD", AllowInsert = true, ColumnType = SimpleColumnType.String)]
        private string idcard;
        [SimpleColumn(Column = "LSH")]
        private string lsh;
        [SimpleColumn(Column = "NAME")]
        private string name;
        [SimpleColumn(Column = "SEX")]
        private string sex;
        [SimpleColumn(Column = "BRITHDAY", ColumnType = SimpleColumnType.Date)]
        private DateTime brithday;
        [SimpleColumn(Column = "PHONE")]
        private string phone;
        [SimpleColumn(Column = "ADDRESS")]
        private string address;
        [SimpleColumn(Column = "DRV_SCHOOL")]
        private string drv_school;
        [SimpleColumn(Column = "DRV_TYPE")]
        private string drv_type;
        [SimpleColumn(Column = "DRV_DOCNUM")]
        private string drv_docnum;
        [SimpleColumn(Column = "REMARK")]
        private string remark;
        [SimpleColumn(Column = "CREATER")]
        private string creater;
        [SimpleColumn(Column = "CREATE_TIME", ColumnType = SimpleColumnType.Date)]
        private DateTime create_time;
        [SimpleColumn(Column = "LASTMODIFY_TIME", ColumnType = SimpleColumnType.Date)]
        private DateTime lastmodify_time;
        [SimpleColumn(Column = "LESSON_ENTER_1", ColumnType = SimpleColumnType.Date)]
        private DateTime lesson_enter_1;
        [SimpleColumn(Column = "LESSON_LEAVE_1", ColumnType = SimpleColumnType.Date)]
        private DateTime lesson_leave_1;
        [SimpleColumn(Column = "LESSON_ENTER_2", ColumnType = SimpleColumnType.Date)]
        private DateTime lesson_enter_2;
        [SimpleColumn(Column = "LESSON_LEAVE_2", ColumnType = SimpleColumnType.Date)]
        private DateTime lesson_leave_2;


        [SimpleColumn(Column = "TRAIN_ENTER_1", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_1;
        [SimpleColumn(Column = "TRAIN_LEAVE_1", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_1;
        [SimpleColumn(Column = "TRAIN_ENTER_2", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_2;
        [SimpleColumn(Column = "TRAIN_LEAVE_2", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_2;
        [SimpleColumn(Column = "TRAIN_ENTER_3", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_3;
        [SimpleColumn(Column = "TRAIN_LEAVE_3", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_3;
        [SimpleColumn(Column = "TRAIN_ENTER_4", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_4;
        [SimpleColumn(Column = "TRAIN_LEAVE_4", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_4;
        [SimpleColumn(Column = "TRAIN_ENTER_5", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_5;
        [SimpleColumn(Column = "TRAIN_LEAVE_5", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_5;
        [SimpleColumn(Column = "TRAIN_ENTER_6", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_6;
        [SimpleColumn(Column = "TRAIN_LEAVE_6", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_6;
        [SimpleColumn(Column = "TRAIN_ENTER_7", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_7;
        [SimpleColumn(Column = "TRAIN_LEAVE_7", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_7;
        [SimpleColumn(Column = "TRAIN_ENTER_8", ColumnType = SimpleColumnType.Date)]
        private DateTime train_enter_8;
        [SimpleColumn(Column = "TRAIN_LEAVE_8", ColumnType = SimpleColumnType.Date)]
        private DateTime train_leave_8;

        [SimpleColumn(Column = "TRAIN_END_DATE", ColumnType = SimpleColumnType.Date)]
        private DateTime train_end_date;

        [SimpleColumn(Column = "KM1_ENTER", ColumnType = SimpleColumnType.Date)]
        private DateTime km1_enter;
        [SimpleColumn(Column = "KM2_ENTER", ColumnType = SimpleColumnType.Date)]
        private DateTime km2_enter;
        [SimpleColumn(Column = "KM3_ENTER", ColumnType = SimpleColumnType.Date)]
        private DateTime km3_enter;
        [SimpleColumn(Column = "KM2_3IN9_ENTER", ColumnType = SimpleColumnType.Date)]
        private DateTime km2_3in9_enter;


        [SimpleColumn(Column = "STATUE", ColumnType = SimpleColumnType.Int)]
        private int statue;
        [SimpleColumn(Column = "LOCALTYPE", ColumnType = SimpleColumnType.Int)]
        private int localtype;

        [SimpleColumn(Column = "KM3_VERIFY")]
        private string km3Verify = "N";

        [SimpleColumn(Column = "FEE_STATUE")]
        private string feeStatue = "N";

        [SimpleColumn(Column = "FEE_VERIFY_DATE", ColumnType = SimpleColumnType.Date)]
        private DateTime feeVerifyDate;

        [SimpleColumn(Column = "SCHOOL_CODE")]
        private string schoolCode;

        [SimpleColumn(Column = "SCHOOL_NAME")]
        private string schoolName;

        [SimpleColumn(Column = "CAR_TYPE")]
        private string carType;

        public string IDCARD
        {
            get { return this.idcard; }
            set { this.idcard = value; }
        }

        public string LSH
        {
            get { return this.lsh; }
            set { this.lsh = value; }
        }

        public string NAME
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string SEX
        {
            get { return this.sex; }
            set { this.sex = value; }
        }


        public DateTime BRITHDAY
        {
            get { return this.brithday; }
            set { this.brithday = value; }
        }


        public string PHONE
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string ADDRESS
        {
            get { return this.address; }
            set { this.address = value; }
        }



        public string DRV_SCHOOL
        {
            get { return this.drv_school; }
            set { this.drv_school = value; }
        }


        public string DRV_TYPE
        {
            get { return this.drv_type; }
            set { this.drv_type = value; }
        }


        public string DRV_DOCNUM
        {
            get { return this.drv_docnum; }
            set { this.drv_docnum = value; }
        }

        public string REMARK
        {
            get { return this.remark; }
            set { this.remark = value; }
        }

        public string CREATER
        {
            get { return this.creater; }
            set { this.creater = value; }
        }


        public DateTime CREATE_TIME
        {
            get { return this.create_time; }
            set { this.create_time = value; }
        }


        public DateTime LASTMODIFY_TIME
        {
            get { return this.lastmodify_time; }
            set { this.lastmodify_time = value; }
        }

        public DateTime LESSON_ENTER_1
        {
            get { return this.lesson_enter_1; }
            set { this.lesson_enter_1 = value; }
        }

        public DateTime LESSON_LEAVE_1
        {
            get { return this.lesson_leave_1; }
            set { this.lesson_leave_1 = value; }
        }

        public DateTime LESSON_ENTER_2
        {
            get { return this.lesson_enter_2; }
            set { this.lesson_enter_2 = value; }
        }

        public DateTime LESSON_LEAVE_2
        {
            get { return this.lesson_leave_2; }
            set { this.lesson_leave_2 = value; }
        }






        public DateTime TRAIN_ENTER_1
        {
            get { return this.train_enter_1; }
            set { this.train_enter_1 = value; }
        }

        public DateTime TRAIN_LEAVE_1
        {
            get { return this.train_leave_1; }
            set { this.train_leave_1 = value; }
        }

        public DateTime TRAIN_ENTER_2
        {
            get { return this.train_enter_2; }
            set { this.train_enter_2 = value; }
        }

        public DateTime TRAIN_LEAVE_2
        {
            get { return this.train_leave_2; }
            set { this.train_leave_2 = value; }
        }

        public DateTime TRAIN_ENTER_3
        {
            get { return this.train_enter_3; }
            set { this.train_enter_3 = value; }
        }

        public DateTime TRAIN_LEAVE_3
        {
            get { return this.train_leave_3; }
            set { this.train_leave_3 = value; }
        }

        public DateTime TRAIN_ENTER_4
        {
            get { return this.train_enter_4; }
            set { this.train_enter_4 = value; }
        }

        public DateTime TRAIN_LEAVE_4
        {
            get { return this.train_leave_4; }
            set { this.train_leave_4 = value; }
        }

        public DateTime TRAIN_ENTER_5
        {
            get { return this.train_enter_5; }
            set { this.train_enter_5 = value; }
        }

        public DateTime TRAIN_LEAVE_5
        {
            get { return this.train_leave_5; }
            set { this.train_leave_5 = value; }
        }

        public DateTime TRAIN_ENTER_6
        {
            get { return this.train_enter_6; }
            set { this.train_enter_6 = value; }
        }

        public DateTime TRAIN_LEAVE_6
        {
            get { return this.train_leave_6; }
            set { this.train_leave_6 = value; }
        }

        public DateTime TRAIN_ENTER_7
        {
            get { return this.train_enter_7; }
            set { this.train_enter_7 = value; }
        }

        public DateTime TRAIN_LEAVE_7
        {
            get { return this.train_leave_7; }
            set { this.train_leave_7 = value; }
        }

        public DateTime TRAIN_ENTER_8
        {
            get { return this.train_enter_8; }
            set { this.train_enter_8 = value; }
        }

        public DateTime TRAIN_LEAVE_8
        {
            get { return this.train_leave_8; }
            set { this.train_leave_8 = value; }
        }

        public DateTime TRAIN_END_DATE
        {
            get { return this.train_end_date; }
            set { this.train_end_date = value; }
        }

        public DateTime KM1_ENTER
        {
            get { return this.km1_enter; }
            set { this.km1_enter = value; }
        }

        public DateTime KM2_ENTER
        {
            get { return this.km2_enter; }
            set { this.km2_enter = value; }
        }

        public DateTime KM3_ENTER
        {
            get { return this.km3_enter; }
            set { this.km3_enter = value; }
        }

        public DateTime KM2_3IN9_ENTER
        {
            get { return this.km2_3in9_enter; }
            set { this.km2_3in9_enter = value; }
        }

        public int STATUE
        {
            get { return this.statue; }
            set { this.statue = value; }
        }

        public int LOCALTYPE
        {
            get { return this.localtype; }
            set { this.localtype = value; }
        }

        public string KM3_VERIFY
        {

            get { return this.km3Verify; }
            set { this.km3Verify = value; }
        }


        public string FEE_STATUE
        {

            get { return this.feeStatue; }
            set { this.feeStatue = value; }
        }
        public string SCHOOL_CODE
        {

            get { return this.schoolCode; }
            set { this.schoolCode = value; }
        }
        public string SCHOOL_NAME
        {

            get { return this.schoolName; }
            set { this.schoolName = value; }
        }


        public DateTime FEE_VERIFY_DATE
        {
            get { return this.feeVerifyDate; }
            set { this.feeVerifyDate = value; }

        }

        public string CAR_TYPE
        {

            get { return this.carType; }
            set { this.carType = value; }
        }

    }



    [SimpleTable("table_departments")]
    [Alias("部门登记表")]
    [Serializable]
    public class DepartMent
    {
        public DepartMent()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_department")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_connector")]
        [Alias("联系人")]
        public String Connector;

        public String 联系人
        {
            get { return Connector; }
            set { Connector = value; }
        }


        [SimpleColumn(Column = "c_deptype")]
        [Alias("部门类别")]
        public String DepType;

        public String 部门类别
        {
            get { return DepType; }
            set { DepType = value; }
        }

        [SimpleColumn(Column = "c_mobile")]
        [Alias("联系电话")]
        public String Mobile;

        public String 联系电话
        {
            get { return Mobile; }
            set { Mobile = value; }
        }
        [SimpleColumn(Column = "c_phone")]
        [Alias("固定电话")]
        public String Phone;

        public String 固定电话
        {
            get { return Phone; }
            set { Phone = value; }
        }
        [SimpleColumn(Column = "c_companycode")]
        [Alias("机构证书代码")]
        public String CompanyCode;

        public String 机构证书代码
        {
            get { return CompanyCode; }
            set { CompanyCode = value; }
        }
        [SimpleColumn(Column = "c_depfullname")]
        [Alias("部门全名")]
        public String DepFullName;

        public String 部门全名
        {
            get { return DepFullName; }
            set { DepFullName = value; }
        }

        [SimpleColumn(Column = "c_depnickname")]
        [Alias("部门简称")]
        public String DepNickName;

        public String 部门简称
        {
            get { return DepNickName; }
            set { DepNickName = value; }
        }
        [SimpleColumn(Column = "c_depcode")]
        [Alias("部门代码")]
        public String DepCode;

        public String 部门代码
        {
            get { return DepCode; }
            set { DepCode = value; }
        }
        [SimpleColumn(Column = "c_parentcode")]
        [Alias("管理单位代码")]
        public String ParentCode;

        public String 管理单位代码
        {
            get { return ParentCode; }
            set { ParentCode = value; }
        }
    }

}
