using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;


namespace DS.Plugins.Car
{
    [SimpleTable("table_car_fee")]
    public class CarFee
    {
        [SimplePK]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_hmhp")]
        [Alias("�������")]
        public string Hmhp;//�������

        public string �������
        {
            get { return Hmhp; }
            set { Hmhp = value; }
        }

        [SimpleColumn(Column = "date_fee")]
        [Alias("����ʱ��")]
        public string FeeDate;

        public string ����ʱ��
        {
            get { return FeeDate; }
            set { FeeDate = value; }
        }

        [SimpleColumn(Column = "i_fee")]
        [Alias("���ý��")]
        public string Fee;

        public string ���ý��
        {
            get { return Fee; }
            set { Fee = value; }
        }

        [SimpleColumn(Column = "c_feetype")]
        [Alias("�������")]
        public string FeeType;

        public string �������
        {
            get { return FeeType; }
            set { FeeType = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("��ע")]
        public String Description;

        public String ��ע
        {
            get { return Description; }
            set { Description = value; }
        }

    }
}
