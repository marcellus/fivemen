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
        /// 把基础数据和ComboBox进行绑定
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
            cb.DisplayMember = "数据文本";
            cb.ValueMember = "数据代码";
            cb.DataSource = list;
            if(cb.Items.Count>0)
                cb.SelectedIndex = 0;
        }

        /// <summary>
        /// 刷新数据字典
        /// </summary>
        /// <param name="group"></param>
        public static void RefreshDicts(string group)
        {
            ArrayList list= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_grouptype='" + group + "'");
            StaticCacheManager.Add("dict_" + group, list);

        }
    }
}
