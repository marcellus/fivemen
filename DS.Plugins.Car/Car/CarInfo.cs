using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace DS.Plugins.Car
{
    [SimpleTable("table_cars")]
    public class CarInfo
    {
        [SimplePK]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_first_color")]
        public string FirstColor;

        [SimpleColumn(Column = "c_second_color")]
        public string SecondColor;

        [SimpleColumn(Column = "c_third_color")]
        public string ThirdColor;

        [SimpleColumn(Column = "c_identify")]
        [Alias("����ʶ����")]
        public string Identify;//ʶ�����

        public string ����ʶ����
        {
            get { return Identify; }
            set { Identify = value; }
        }

        [SimpleColumn(Column = "c_fdjh")]
        [Alias("��������")]
        public string Fdjh;//��������


        [SimpleColumn(Column = "c_hmhp")]
        [Alias("�������")]
        public string Hmhp;//�������

        public string �������
        {
            get { return Hmhp; }
            set { Hmhp = value; }
        }

        [SimpleColumn(Column = "c_cartype")]
        [Alias("��������")]
        public string CarType;//�������� A1 ,B1��Щ

        public string ��������
        {
            get { return CarType; }
            set { CarType = value; }
        }

        [SimpleColumn(Column = "i_ownerid")]
        public string OwnerId;//����ID

        [SimpleColumn(Column = "i_ownername")]
        [Alias("��������")]
        public string OwnerName;//��������

        public string ��������
        {
            get { return OwnerName; }
            set { OwnerName = value; }
        }

        [SimpleColumn(Column = "c_pinpai")]
        [Alias("����Ʒ��")]
        public string PinPai;//����Ʒ��

        public string ����Ʒ��
        {
            get { return PinPai; }
            set { PinPai = value; }
        }

        [SimpleColumn(Column = "c_state")]
        [Alias("����״̬")]
        public string State;//����״̬

        public string ����״̬
        {
            get { return State; }
            set { State = value; }
        }

        [SimpleColumn(Column = "date_insurancedate")]
        [Alias("����������")]
        public string InsuranceDate;//����������

        public string ����������
        {
            get { return InsuranceDate; }
            set { InsuranceDate = value; }
        }

        [SimpleColumn(Column = "date_yearcheck")]
        [Alias("���ʱ��")]
        public string YearCheckDate;//���ʱ��

        public string ���ʱ��
        {
            get { return YearCheckDate; }
            set { YearCheckDate = value; }
        }

        [SimpleColumn(Column = "date_zhuanru")]
        [Alias("ת��ʱ��")]
        public string ZrDate;//ת��ʱ��

        public string ת��ʱ��
        {
            get { return ZrDate; }
            set { ZrDate = value; }
        }

        [SimpleColumn(Column = "date_roadfee")]
        [Alias("·�ѹ�������")]
        public string RoadFeeBuyDate;//·�ѹ�������

        public string ·�ѹ�������
        {
            get { return RoadFeeBuyDate; }
            set { RoadFeeBuyDate = value; }
        }

        [SimpleColumn(Column = "date_contract")]
        [Alias("��ͬǩ��ʱ��")]
        public string ContractDate;//��ͬǩ��ʱ��

        public string ��ͬǩ��ʱ��
        {
            get { return ContractDate; }
            set { ContractDate = value; }
        }

        [SimpleColumn(Column = "c_contract_person")]
        [Alias("��ͬǩ����")]
        public string ContractPerson;//��ͬǩ����

        [SimpleColumn(Column = "c_is_teachercar")]
        [Alias("�Ƿ������")]
        public string IsTeacherCar;//�Ƿ������

        public string �Ƿ������
        {
            get { return IsTeacherCar; }
            set { IsTeacherCar = value; }
        }

        [SimpleColumn(Column = "c_is_examcar")]
        [Alias("�Ƿ��Գ�")]
        public string IsExamCar;//�Ƿ��Գ�

        public string �Ƿ��Գ�
        {
            get { return IsExamCar; }
            set { IsExamCar = value; }
        }
    }
}
