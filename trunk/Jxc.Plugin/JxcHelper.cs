using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using System.Collections;

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

       
    }
}
