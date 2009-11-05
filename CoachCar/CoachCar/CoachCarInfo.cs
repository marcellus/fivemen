using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace CoachCar
{
    [SimpleTable("table_coach_cars")]
    [Alias("�麣�и���ѵ��λ������/Ա�볡�ǼǱ�")]
    public class CoachCarInfo
    {
        [SimplePK]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }


        [SimpleColumn(Column = "c_company")]
        [Alias("��λ")]
        public string Company;

        public string ��λ
        {
            get { return Company; }
            set { Company = value; }
        }
        [SimpleColumn(Column = "c_cjh")]
        [Alias("���ܺ�")]
        public string Cjh;

        public string ���ܺ�
        {
            get { return Cjh; }
            set { Cjh = value; }
        }

        [SimpleColumn(Column = "date_reg")]
        [Alias("�볡����")]
        public String RegDate;

        public String �볡����
        {
            get { return RegDate; }
            set { RegDate = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("���֤��")]
        public string IdCard;

        public string ���֤��
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "c_coach_id")]
        [Alias("����֤��")]
        public string CoachId;

        public string ����֤��
        {
            get { return CoachId; }
            set { CoachId = value; }
        }

        [SimpleColumn(Column = "c_coach_name")]
        [Alias("����")]
        public string CoachName;

        public string ����
        {
            get { return CoachName; }
            set { CoachName = value; }
        }

        [SimpleColumn(Column = "c_car_no")]
        [Alias("��������")]
        public string CarNo;

        public string ��������
        {
            get { return CarNo; }
            set { CarNo = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("��ע")]
        public string Description;

        public string ��ע
        {
            get { return Description; }
            set { Description = value; }
        }

        [SimpleColumn(Column = "c_keyWords")]
        [Alias("�ؼ���")]
        public string KeyWords;

        public string �ؼ���
        {
            get { return KeyWords; }
            set { KeyWords = value; }
        }
    }
}
