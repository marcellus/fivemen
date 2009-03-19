using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace FT.Windows.CommonsPlugin
{
    public class DictManager
    {
        public static void BindStudentFee(ComboBox cb)
        {
            BindToCombox(cb, "ѧ����������");
        }

        public static void BindComeFrom(ComboBox cb)
        {
            BindToCombox(cb, "��ʻ����Դ");
        }

        public static void BindNation(ComboBox cb)
        {
            BindToCombox(cb, "����");
            cb.Text = "�й�";
            cb.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public static void BindBelongArea(ComboBox cb)
        {
            BindToCombox(cb, "������������");
        }

        public static void BindBelongAreaDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "������������");
        }

        public static void BindIdCardType(ComboBox cb)
        {
            BindToCombox(cb, "���֤������");
        }

        public static void BindHospital(ComboBox cb)
        {
            BindToCombox(cb, "���ҽԺ");
        }
        public static void BindRecommend(ComboBox cb)
        {
            BindToCombox(cb, "�Ƽ���");
            cb.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public static void BindCarState(ComboBox cb)
        {
            BindToCombox(cb, "������״̬");
        }

        public static void BindCarColor(ComboBox cb)
        {
            BindToCombox(cb, "������ɫ����");
        }

        public static void BindCarColorDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "������ɫ����");
        }

        public static void BindCarFeeType(ComboBox cb)
        {
            BindToCombox(cb, "������������");
        }

        public static void BindFromRoute(ComboBox cb)
        {
            BindToCombox(cb, "����;��");
        }

        public static void BindCarPinPai(ComboBox cb)
        {
            BindToCombox(cb, "����Ʒ��");
        }

        public static void BindCarType(ComboBox cb)
        {
            BindToCombox(cb, "׼�ݳ���");
        }

        public static void BindCarTypeDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "׼�ݳ���");
        }


        public static void BindCarStyle(ComboBox cb)
        {
            BindToCombox(cb, "��������");
        }

        public static void BindSubjectDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "���Կ�Ŀ");
        }


        public static void BindSubject(ComboBox cb)
        {
            BindToCombox(cb, "���Կ�Ŀ");
        }


        
        /// <summary>
        /// �ѻ������ݺ�ComboBox���а�
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="group"></param>
        public static void BindToCombox(ComboBox cb,string group)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key="dict_" + group;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='��Ч' and  c_grouptype='" + group + "'");
                StaticCacheManager.Add(key, list);
            }
            cb.DisplayMember = "�����ı�";
            cb.ValueMember = "���ݴ���";
            cb.DataSource = list;
            if(cb.Items.Count>0)
                cb.SelectedIndex = 0;
        }

        /// <summary>
        /// �ѻ������ݺ�ComboBox���а�
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="group"></param>
        public static void BindToComboxDynamic(ComboBox cb, string group)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key = "dict_" + group;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='��Ч' and  c_grouptype='" + group + "'");
                StaticCacheManager.Add(key, list);
            }
            list = (ArrayList)list.Clone();
           // ArrayList list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='��Ч' and  c_grouptype='" + group + "'");
            cb.DisplayMember = "�����ı�";
            cb.ValueMember = "���ݴ���";
            cb.DataSource = list;
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }


        /// <summary>
        /// ˢ�������ֵ�
        /// </summary>
        /// <param name="group"></param>
        public static void RefreshDicts(string group)
        {
            ArrayList list= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='��Ч' and  c_grouptype='" + group + "'");
            StaticCacheManager.Add("dict_" + group, list);

        }
    }
}
