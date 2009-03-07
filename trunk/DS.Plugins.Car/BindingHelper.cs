using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    /// <summary>
    /// 绑定车辆以及教练员和车主信息的时候用
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
                car.Hmhp = "--请选择--";
                lists.Add(car);
            }
            if (lists.Count > 0)
            {
                
                //this.cbGroup
                cb.DataSource = lists;
                cb.DisplayMember = "号码号牌";
                cb.ValueMember = "号码号牌";
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
                coach.Name = "--请选择--";
                coach.Id = -1;
                lists.Add(coach);
            }
            if (lists.Count > 0)
            {

                //this.cbGroup
                cb.DataSource = lists;
                cb.DisplayMember = "姓名";
                cb.ValueMember = "编号";
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
                owner.Name = "--请选择--";
                owner.Id = -1;
                lists.Add(owner);
            }
            if (lists.Count > 0)
            {

                //this.cbGroup
                cb.DataSource = lists;
                cb.DisplayMember = "姓名";
                cb.ValueMember = "编号";
                cb.SelectedIndex = 0;
            }
        }


    }
}
