using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace DS.Plugins.Car
{
    [SimpleTable("table_car_out")]
    [Alias("����������¼��")]
    public class CarOut
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

        [SimpleColumn(Column = "date_out")]
        [Alias("����ʱ��")]
        public string OutDate;

        public string ����ʱ��
        {
            get { return OutDate; }
            set { OutDate = value; }
        }

        [SimpleColumn(Column = "c_reason")]
        [Alias("����ԭ��")]
        public string Reason;

        public string ����ԭ��
        {
            get { return Reason; }
            set { Reason = value; }
        }
    
    }
}
