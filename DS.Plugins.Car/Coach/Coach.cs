using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Car
{
    [SimpleTable("table_coach")]
    [Alias("������Ϣ��")]
    public class Coach : Person
    {
        [SimpleColumn(Column = "c_hmhp")]
        [Alias("�������")]
        public string Hmhp;//�������

        public string �������
        {
            get { return Hmhp; }
            set { Hmhp = value; }
        }

        [SimpleColumn(Column = "c_coachid")]
        [Alias("����֤��")]
        public string CoachId;//����֤��

        public string ����֤��
        {
            get { return CoachId; }
            set { CoachId = value; }
        }

        [SimpleColumn(Column = "c_driverid")]
        [Alias("��ʻ֤���")]
        public string DriverId;//��ʻ֤���

        public string ��ʻ֤���
        {
            get { return DriverId; }
            set { DriverId = value; }
        }

        [SimpleColumn(Column = "c_cartype")]
        [Alias("׼�̳���")]
        public string CarType;//����֤��

        public string ׼�̳���
        {
            get { return CarType; }
            set { CarType = value; }
        }


    }
}
