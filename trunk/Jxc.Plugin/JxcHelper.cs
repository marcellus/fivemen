using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using System.Collections;
using FT.Windows.CommonsPlugin;

namespace Jxc.Plugin
{
    public class JxcHelper
    {

        public static void BindTypeName(ComboBox cb)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            ArrayList list  = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(BaseData));
            cb.DisplayMember = "种类名称";
            cb.ValueMember = "库存数量";
            cb.DataSource = list;
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }


        public static  BaseData GetTypeData(string type)
        {
            ArrayList list=FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<BaseData>(" where c_name='" + type + "'");
            
            BaseData result = list[0] as BaseData;
            
            return result;
        }

        public static ArrayList GetFromList()
        {

            string key = "dict_货品来源";
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='货品来源'");
                StaticCacheManager.Add(key, list);
            }
            return list;
        }

       
    }
}
