using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace FT.Windows.CommonsPlugin.Entity
{
    public class DictManager
    {
        /// <summary>
        /// �ѻ������ݺ�ComboBox���а�
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="group"></param>
        public static void BindToCombox(ComboBox cb,string group)
        {
            string key="dict_" + group;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_grouptype='" + group + "'");
                StaticCacheManager.Add(key, list);
            }
            cb.DisplayMember = "�����ı�";
            cb.ValueMember = "���ݴ���";
            cb.DataSource = list;
            if(cb.Items.Count>0)
                cb.SelectedIndex = 0;
        }

        /// <summary>
        /// ˢ�������ֵ�
        /// </summary>
        /// <param name="group"></param>
        public static void RefreshDicts(string group)
        {
            ArrayList list= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_grouptype='" + group + "'");
            StaticCacheManager.Add("dict_" + group, list);

        }
    }
}
