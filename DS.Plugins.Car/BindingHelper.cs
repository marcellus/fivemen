using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    /// <summary>
    /// �󶨳����Լ�����Ա�ͳ�����Ϣ��ʱ����
    /// </summary>
    public class BindingHelper
    {

        private BindingHelper()
        {
           
        }

        public static void BindCars(ComboBox cb)
        {
            BindCars(cb, false);
        }

        public static void BindCars(ComboBox cb, bool search)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
            if (search)
            {
                CarInfo car = new CarInfo();
                car.Hmhp = "--��ѡ��--";
                lists.Add(car);
            }
            if (lists.Count > 0)
            {
                
                //this.cbGroup
                cb.DataSource = lists;
                cb.DisplayMember = "�������";
                cb.ValueMember = "�������";
                cb.SelectedIndex = 0;
            }
        }

        public static void BindCoach(ComboBox cb)
        {
            BindCoach(cb, false);
        }

        public static void BindCoach(ComboBox cb, bool search)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Coach));
            if (search)
            {
                Coach coach = new Coach();
                coach.Name = "--��ѡ��--";
                coach.Id = -1;
                lists.Add(coach);
            }
            if (lists.Count > 0)
            {

                //this.cbGroup
                cb.DataSource = lists;
                cb.DisplayMember = "����";
                cb.ValueMember = "���";
                cb.SelectedIndex = 0;
            }
        }

        public static void BindOwner(ComboBox cb)
        {
            BindOwner(cb,false);
        }

        public static void BindOwner(ComboBox cb, bool search)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarOwner));
            if (search)
            {
                CarOwner owner = new CarOwner();
                owner.Name = "--��ѡ��--";
                owner.Id = -1;
                lists.Add(owner);
            }
            if (lists.Count > 0)
            {

                //this.cbGroup
                cb.DataSource = lists;
                cb.DisplayMember = "����";
                cb.ValueMember = "���";
                cb.SelectedIndex = 0;
            }
        }


    }
}
