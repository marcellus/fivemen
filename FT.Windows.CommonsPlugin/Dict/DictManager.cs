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
            BindToCombox(cb, "学生费用类型");
        }

        public static void BindComeFrom(ComboBox cb)
        {
            BindToCombox(cb, "驾驶人来源");
        }

        public static void BindNation(ComboBox cb)
        {
            BindToCombox(cb, "国籍");
            cb.Text = "中国";
            cb.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public static void BindBelongArea(ComboBox cb)
        {
            BindToCombox(cb, "本地行政区划");
        }

        public static void BindBelongAreaDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "本地行政区划");
        }

        public static void BindIdCardType(ComboBox cb)
        {
            BindToCombox(cb, "身份证明名称");
        }

        public static void BindHospital(ComboBox cb)
        {
            BindToCombox(cb, "体检医院");
        }
        public static void BindRecommend(ComboBox cb)
        {
            BindToCombox(cb, "推荐人");
            cb.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public static void BindCarState(ComboBox cb)
        {
            BindToCombox(cb, "机动车状态");
        }

        public static void BindCarColor(ComboBox cb)
        {
            BindToCombox(cb, "车身颜色代码");
        }

        public static void BindCarColorDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "车身颜色代码");
        }

        public static void BindCarFeeType(ComboBox cb)
        {
            BindToCombox(cb, "车辆费用类型");
        }

        public static void BindFromRoute(ComboBox cb)
        {
            BindToCombox(cb, "报名途径");
        }

        public static void BindCarPinPai(ComboBox cb)
        {
            BindToCombox(cb, "车辆品牌");
        }

        public static void BindCarType(ComboBox cb)
        {
            BindToCombox(cb, "准驾车型");
        }

        public static void BindCarTypeDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "准驾车型");
        }


        public static void BindCarStyle(ComboBox cb)
        {
            BindToCombox(cb, "车辆类型");
        }

        public static void BindSubjectDynamic(ComboBox cb)
        {
            BindToComboxDynamic(cb, "考试科目");
        }


        public static void BindSubject(ComboBox cb)
        {
            BindToCombox(cb, "考试科目");
        }


        
        /// <summary>
        /// 把基础数据和ComboBox进行绑定
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
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='" + group + "'");
                StaticCacheManager.Add(key, list);
            }
            cb.DisplayMember = "数据文本";
            cb.ValueMember = "数据代码";
            cb.DataSource = list;
            if(cb.Items.Count>0)
                cb.SelectedIndex = 0;
        }

        /// <summary>
        /// 把基础数据和ComboBox进行绑定
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
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='" + group + "'");
                StaticCacheManager.Add(key, list);
            }
            list = (ArrayList)list.Clone();
           // ArrayList list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='" + group + "'");
            cb.DisplayMember = "数据文本";
            cb.ValueMember = "数据代码";
            cb.DataSource = list;
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }


        /// <summary>
        /// 刷新数据字典
        /// </summary>
        /// <param name="group"></param>
        public static void RefreshDicts(string group)
        {
            ArrayList list= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='" + group + "'");
            StaticCacheManager.Add("dict_" + group, list);

        }
    }
}
