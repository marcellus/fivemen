using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    [SimpleTable("table_students")]
    [Alias("ѧԱ��")]
    public class StudentInfo:Person
    {

        [SimpleColumn(Column = "c_idcard_type")]
        public String IdCardType;

        public String ���֤������
        {
            get { return IdCardType; }
            set { IdCardType = value; }
        }

        [SimpleColumn(Column = "c_postcode")]
        [Alias("��������")]
        public String PostCode;

        public String ��������
        {
            get { return PostCode; }
            set { PostCode = value; }
        }

        [SimpleColumn(Column = "c_printed_state")]
        [Alias("��ӡ״̬")]
        public String PrintedState;

        public String ��ӡ״̬
        {
            get { return PrintedState; }
            set { PrintedState = value; }
        }

        [SimpleColumn(Column = "c_nation")]
        [Alias("����")]
        public String Nation;

        public String ����
        {
            get { return Nation; }
            set { Nation = value; }
        }

        [SimpleColumn(Column = "c_tempid")]
        [Alias("��ס֤��")]
        public String TempId;

        public String ��ס֤��
        {
            get { return TempId; }
            set { TempId = value; }
        }

        [SimpleColumn(Column = "c_reg_province")]
        [Alias("֤��ʡ��")]
        public String RegProvince;

        public String ֤��ʡ��
        {
            get { return RegProvince; }
            set { RegProvince = value; }
        }


        [SimpleColumn(Column = "c_reg_city")]
        [Alias("֤����")]
        public String RegCity;

        public String ֤����
        {
            get { return RegCity; }
            set { RegCity = value; }
        }

        [SimpleColumn(Column = "c_reg_area")]
        [Alias("֤������")]
        public String RegArea;

        public String ֤������
        {
            get { return RegArea; }
            set { RegArea = value; }
        }

        [SimpleColumn(Column = "c_reg_address")]
        [Alias("֤����ַ")]
        public String RegAddress;

        public String ֤����ַ
        {
            get { return RegAddress; }
            set { RegAddress = value; }
        }

        [SimpleColumn(Column = "c_belong_area")]
        [Alias("����Ͻ��")]
        public String BelongArea;

        public String ����Ͻ��
        {
            get { return BelongArea; }
            set { BelongArea = value; }
        }

        [SimpleColumn(Column = "c_belong_xiang")]
        [Alias("����")]
        public String BelongXiang;

        public String ����
        {
            get { return BelongXiang; }
            set { BelongXiang = value; }
        }

        [SimpleColumn(Column = "c_belong_cun")]
        [Alias("���ί")]
        public String BelongCun;

        public String ���ί
        {
            get { return BelongCun; }
            set { BelongCun = value; }
        }

        [SimpleColumn(Column = "c_conn_address")]
        [Alias("��ϵ��ַ")]
        public String ConnAddress;

        public String ��ϵ��ַ
        {
            get { return ConnAddress; }
            set { ConnAddress = value; }
        }

        [SimpleColumn(Column = "c_profile")]
        [Alias("�������")]
        public String Profile;

        public String �������
        {
            get { return Profile; }
            set { Profile = value; }
        }

        [SimpleColumn(Column = "c_learn_type")]
        [Alias("ѧϰ����")]
        public String LearnType;

        public String ѧϰ����
        {
            get { return LearnType; }
            set { LearnType = value; }
        }

        [SimpleColumn(Column = "c_old_cartype")]
        [Alias("ԭ�г���")]
        public String OldCarType;

        public String ԭ�г���
        {
            get { return OldCarType; }
            set { OldCarType = value; }
        }

        [SimpleColumn(Column = "c_new_cartype")]
        [Alias("ѧϰ����")]
        public String NewCarType;

        public String ѧϰ����
        {
            get { return NewCarType; }
            set { NewCarType = value; }
        }

        [SimpleColumn(Column = "c_new_carstyle")]
        [Alias("��������")]
        public String NewCarStyle;

        public String ��������
        {
            get { return NewCarStyle; }
            set { NewCarStyle = value; }
        }

        [SimpleColumn(Column = "c_examid")]
        [Alias("׼��֤��")]
        public String ExamId;

        public String ׼��֤��
        {
            get { return ExamId; }
            set { ExamId = value; }
        }

        [SimpleColumn(Column = "c_examdate")]
        [Alias("׼������")]
        public String ExamDate;

        public String ׼������
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }

        [SimpleColumn(Column = "date_baoming")]
        [Alias("��������")]
        public String BaoMingDate;

        public String ��������
        {
            get { return BaoMingDate; }
            set { BaoMingDate = value; }
        }

        [SimpleColumn(Column = "date_lastexam")]
        [Alias("�ϴο�������")]
        public String LastExamDate;

        public String �ϴο�������
        {
            get { return LastExamDate; }
            set { LastExamDate = value; }
        }


        [SimpleColumn(Column = "date_graduation")]
        [Alias("��ҵ����")]
        public String GraduationDate;

        public String ��ҵ����
        {
            get { return GraduationDate; }
            set { GraduationDate = value; }
        }

        [SimpleColumn(Column = "c_from")]
        [Alias("ѧ����Դ")]
        public string ComeFrom;

        public string ѧ����Դ
        {
            get { return ComeFrom; }
            set { ComeFrom = value; }
        }

        [SimpleColumn(Column = "i_coachid")]
        [Alias("����ID")]
        public string CoachId;

        public string ����ID
        {
            get { return CoachId; }
            set { CoachId = value; }
        }

        [SimpleColumn(Column = "c_coach")]
        [Alias("����")]
        public string CoachName;

        public string ����
        {
            get { return CoachName; }
            set { CoachName = value; }
        }

        [SimpleColumn(Column = "c_recommend")]
        [Alias("�Ƽ���")]
        public string Recommend;

        public string �Ƽ���
        {
            get { return Recommend; }
            set { Recommend = value; }
        }

        [SimpleColumn(Column = "c_from_route")]
        [Alias("����;��")]
        public string FromRoute;

        public string ����;��
        {
            get { return FromRoute; }
            set { FromRoute = value; }
        }

        [SimpleColumn(Column = "c_height")]
        [Alias("���")]
        public string Height;

        public string ���
        {
            get { return Height; }
            set { Height = value; }
        }

        [SimpleColumn(Column = "c_left_eye")]
        [Alias("������")]
        public string LeftEye;

        public string ������
        {
            get { return LeftEye; }
            set { LeftEye = value; }
        }


        [SimpleColumn(Column = "c_right_eye")]
        [Alias("������")]
        public string RightEye;

        public string ������
        {
            get { return RightEye; }
            set { RightEye = value; }
        }

        [SimpleColumn(Column = "c_color")]
        [Alias("��ɫ��")]
        public string Color;

        public string ��ɫ��
        {
            get { return Color; }
            set { Color = value; }
        }

        [SimpleColumn(Column = "c_listen")]
        [Alias("����")]
        public string Listen;

        public string ����
        {
            get { return Listen; }
            set { Listen = value; }
        }

        [SimpleColumn(Column = "c_top_body")]
        [Alias("��֫")]
        public string TopBody;

        public string ��֫
        {
            get { return TopBody; }
            set { TopBody = value; }
        }

        [SimpleColumn(Column = "c_left_down_body")]
        [Alias("����֫")]
        public string LeftDownBody;

        public string ����֫
        {
            get { return LeftDownBody; }
            set { LeftDownBody = value; }
        }

        [SimpleColumn(Column = "c_right_down_body")]
        [Alias("����֫")]
        public string RightDownBody;

        public string ����֫
        {
            get { return RightDownBody; }
            set { RightDownBody = value; }
        }

        [SimpleColumn(Column = "c_main_body")]
        [Alias("���ɾ���")]
        public string MainBody;

        public string ���ɾ���
        {
            get { return MainBody; }
            set { MainBody = value; }
        }


        [SimpleColumn(Column = "date_check")]
        [Alias("�������")]
        public string CheckDate;

        public string �������
        {
            get { return CheckDate; }
            set { CheckDate = value; }
        }


        [SimpleColumn(Column = "c_hospital")]
        [Alias("���ҽԺ")]
        public string Hospital;

        public string ���ҽԺ
        {
            get { return Hospital; }
            set { Hospital = value; }
        }

        [SimpleColumn(Column = "c_dimension")]
        public string Dimension;









        
    }
}
