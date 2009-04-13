using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    [SimpleTable("table_students")]
    [Alias("学员表")]
    public class StudentInfo:Person
    {

        [SimpleColumn(Column = "c_idcard_type")]
        public String IdCardType;

        public String 身份证明名称
        {
            get { return IdCardType; }
            set { IdCardType = value; }
        }

        [SimpleColumn(Column = "c_postcode")]
        [Alias("邮政编码")]
        public String PostCode;

        public String 邮政编码
        {
            get { return PostCode; }
            set { PostCode = value; }
        }

        [SimpleColumn(Column = "c_printed_state")]
        [Alias("打印状态")]
        public String PrintedState;

        public String 打印状态
        {
            get { return PrintedState; }
            set { PrintedState = value; }
        }

        [SimpleColumn(Column = "c_nation")]
        [Alias("国籍")]
        public String Nation;

        public String 国籍
        {
            get { return Nation; }
            set { Nation = value; }
        }

        [SimpleColumn(Column = "c_tempid")]
        [Alias("暂住证号")]
        public String TempId;

        public String 暂住证号
        {
            get { return TempId; }
            set { TempId = value; }
        }

        [SimpleColumn(Column = "c_reg_province")]
        [Alias("证件省份")]
        public String RegProvince;

        public String 证件省份
        {
            get { return RegProvince; }
            set { RegProvince = value; }
        }


        [SimpleColumn(Column = "c_reg_city")]
        [Alias("证件市")]
        public String RegCity;

        public String 证件市
        {
            get { return RegCity; }
            set { RegCity = value; }
        }

        [SimpleColumn(Column = "c_reg_area")]
        [Alias("证件县区")]
        public String RegArea;

        public String 证件县区
        {
            get { return RegArea; }
            set { RegArea = value; }
        }

        [SimpleColumn(Column = "c_reg_address")]
        [Alias("证件地址")]
        public String RegAddress;

        public String 证件地址
        {
            get { return RegAddress; }
            set { RegAddress = value; }
        }

        [SimpleColumn(Column = "c_belong_area")]
        [Alias("所属辖区")]
        public String BelongArea;

        public String 所属辖区
        {
            get { return BelongArea; }
            set { BelongArea = value; }
        }

        [SimpleColumn(Column = "c_belong_xiang")]
        [Alias("乡镇")]
        public String BelongXiang;

        public String 乡镇
        {
            get { return BelongXiang; }
            set { BelongXiang = value; }
        }

        [SimpleColumn(Column = "c_belong_cun")]
        [Alias("村居委")]
        public String BelongCun;

        public String 村居委
        {
            get { return BelongCun; }
            set { BelongCun = value; }
        }

        [SimpleColumn(Column = "c_conn_address")]
        [Alias("联系地址")]
        public String ConnAddress;

        public String 联系地址
        {
            get { return ConnAddress; }
            set { ConnAddress = value; }
        }

        [SimpleColumn(Column = "c_profile")]
        [Alias("档案编号")]
        public String Profile;

        public String 档案编号
        {
            get { return Profile; }
            set { Profile = value; }
        }

        [SimpleColumn(Column = "c_learn_type")]
        [Alias("学习类型")]
        public String LearnType;

        public String 学习类型
        {
            get { return LearnType; }
            set { LearnType = value; }
        }

        [SimpleColumn(Column = "c_old_cartype")]
        [Alias("原有车型")]
        public String OldCarType;

        public String 原有车型
        {
            get { return OldCarType; }
            set { OldCarType = value; }
        }

        [SimpleColumn(Column = "c_new_cartype")]
        [Alias("学习车型")]
        public String NewCarType;

        public String 学习车型
        {
            get { return NewCarType; }
            set { NewCarType = value; }
        }

        [SimpleColumn(Column = "c_new_carstyle")]
        [Alias("车辆类型")]
        public String NewCarStyle;

        public String 车辆类型
        {
            get { return NewCarStyle; }
            set { NewCarStyle = value; }
        }

        [SimpleColumn(Column = "c_examid")]
        [Alias("准考证号")]
        public String ExamId;

        public String 准考证号
        {
            get { return ExamId; }
            set { ExamId = value; }
        }

        [SimpleColumn(Column = "c_examdate")]
        [Alias("准考日期")]
        public String ExamDate;

        public String 准考日期
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }

        [SimpleColumn(Column = "date_baoming")]
        [Alias("报名日期")]
        public String BaoMingDate;

        public String 报名日期
        {
            get { return BaoMingDate; }
            set { BaoMingDate = value; }
        }

        [SimpleColumn(Column = "date_lastexam")]
        [Alias("上次考试日期")]
        public String LastExamDate;

        public String 上次考试日期
        {
            get { return LastExamDate; }
            set { LastExamDate = value; }
        }


        [SimpleColumn(Column = "date_graduation")]
        [Alias("结业日期")]
        public String GraduationDate;

        public String 结业日期
        {
            get { return GraduationDate; }
            set { GraduationDate = value; }
        }

        [SimpleColumn(Column = "c_from")]
        [Alias("学生来源")]
        public string ComeFrom;

        public string 学生来源
        {
            get { return ComeFrom; }
            set { ComeFrom = value; }
        }

        [SimpleColumn(Column = "i_coachid")]
        [Alias("教练ID")]
        public string CoachId;

        public string 教练ID
        {
            get { return CoachId; }
            set { CoachId = value; }
        }

        [SimpleColumn(Column = "c_coach")]
        [Alias("教练")]
        public string CoachName;

        public string 教练
        {
            get { return CoachName; }
            set { CoachName = value; }
        }

        [SimpleColumn(Column = "c_recommend")]
        [Alias("推荐人")]
        public string Recommend;

        public string 推荐人
        {
            get { return Recommend; }
            set { Recommend = value; }
        }

        [SimpleColumn(Column = "c_from_route")]
        [Alias("报名途径")]
        public string FromRoute;

        public string 报名途径
        {
            get { return FromRoute; }
            set { FromRoute = value; }
        }

        [SimpleColumn(Column = "c_height")]
        [Alias("身高")]
        public string Height;

        public string 身高
        {
            get { return Height; }
            set { Height = value; }
        }

        [SimpleColumn(Column = "c_left_eye")]
        [Alias("左视力")]
        public string LeftEye;

        public string 左视力
        {
            get { return LeftEye; }
            set { LeftEye = value; }
        }


        [SimpleColumn(Column = "c_right_eye")]
        [Alias("右视力")]
        public string RightEye;

        public string 右视力
        {
            get { return RightEye; }
            set { RightEye = value; }
        }

        [SimpleColumn(Column = "c_color")]
        [Alias("辨色力")]
        public string Color;

        public string 辨色力
        {
            get { return Color; }
            set { Color = value; }
        }

        [SimpleColumn(Column = "c_listen")]
        [Alias("听力")]
        public string Listen;

        public string 听力
        {
            get { return Listen; }
            set { Listen = value; }
        }

        [SimpleColumn(Column = "c_top_body")]
        [Alias("上肢")]
        public string TopBody;

        public string 上肢
        {
            get { return TopBody; }
            set { TopBody = value; }
        }

        [SimpleColumn(Column = "c_left_down_body")]
        [Alias("左下肢")]
        public string LeftDownBody;

        public string 左下肢
        {
            get { return LeftDownBody; }
            set { LeftDownBody = value; }
        }

        [SimpleColumn(Column = "c_right_down_body")]
        [Alias("右下肢")]
        public string RightDownBody;

        public string 右下肢
        {
            get { return RightDownBody; }
            set { RightDownBody = value; }
        }

        [SimpleColumn(Column = "c_main_body")]
        [Alias("躯干颈部")]
        public string MainBody;

        public string 躯干颈部
        {
            get { return MainBody; }
            set { MainBody = value; }
        }


        [SimpleColumn(Column = "date_check")]
        [Alias("体检日期")]
        public string CheckDate;

        public string 体检日期
        {
            get { return CheckDate; }
            set { CheckDate = value; }
        }


        [SimpleColumn(Column = "c_hospital")]
        [Alias("体检医院")]
        public string Hospital;

        public string 体检医院
        {
            get { return Hospital; }
            set { Hospital = value; }
        }

        [SimpleColumn(Column = "c_dimension")]
        public string Dimension;









        
    }
}
