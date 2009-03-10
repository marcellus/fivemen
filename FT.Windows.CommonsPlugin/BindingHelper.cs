using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace FT.Windows.CommonsPlugin
{
    public class BindingHelper
    {
        private BindingHelper()
        {
        }

        public static void BindProvince(ComboBox cb)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key = "province";
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Province));
                StaticCacheManager.Add(key, list);
               
            }
            cb.DisplayMember = "省份名称";
            cb.ValueMember = "省份代码";
            cb.DataSource = list;
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }

        public static void RefreshProvince()
        {
            string key = "province";
            ArrayList list = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Province));
            StaticCacheManager.Add(key, list);
        }

        public static void Refresh()
        {
            string key = "province";
            ArrayList list = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Province));
            StaticCacheManager.Add(key, list);
        }

        public static void BindCity(ComboBox cb,string parent)
        {
            //cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key = "city_"+parent;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<City>(" where c_father_code='"+parent+"'");
                StaticCacheManager.Add(key, list);
                
            }
            if (list.Count == 0)
            {
                cb.DataSource = null;
            }
            else
            {
                cb.DisplayMember = "市名称";
                cb.ValueMember = "市代码";
                cb.DataSource = list;
                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
            }
        }

        public static void BindArea(ComboBox cb, string parent)
        {
            //cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key = "city_" + parent;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Area>(" where c_father_code='" + parent + "'");
                StaticCacheManager.Add(key, list);
                
            }
            if (list.Count == 0)
            {
                cb.DataSource = null;
            }
            else
            {
                cb.DisplayMember = "县区名称";
                cb.ValueMember = "县区代码";
                cb.DataSource = list;
                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
            }
        }

        public static void BindXiang(ComboBox cb, string parent)
        {
            //cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key = "xiang_" + parent;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Xiang>(" where c_valid='有效' and c_blongarea='" + parent + "'");
                StaticCacheManager.Add(key, list);
                
            }
            if (list.Count == 0)
            {
                cb.DataSource = null;
            }
            else
            {
                cb.DisplayMember = "数据文本";
                cb.ValueMember = "数据代码";
                cb.DataSource = list;
                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
            }
        }

        public static void BindCun(ComboBox cb, string area,string xiang)
        {
            //cb.DropDownStyle = ComboBoxStyle.DropDownList;
            string key = "cun_" + area+"_"+xiang;
            ArrayList list = StaticCacheManager.Get(key) as ArrayList;
            if (list == null)
            {
                list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Cun>(" where c_valid='有效' and c_blongxiang='"+xiang+"' and c_blongarea='" + area + "'");
                StaticCacheManager.Add(key, list);
               
            }
            if (list.Count == 0)
            {
                cb.DataSource = null;
            }
            else
            {
                cb.DisplayMember = "数据文本";
                cb.ValueMember = "数据代码";
                cb.DataSource = list;
                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
            }
           
        }

        public static string GetDefaultCity()
        {
            string key = "defaultcity";
            string result = StaticCacheManager.Get(key) as string;
            if (result == null || result.Length == 0)
            {
                string keytmp = "dict_本地行政区划";
                ArrayList list = StaticCacheManager.Get(keytmp) as ArrayList;
                if (list == null)
                {
                    list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='本地行政区划'");
                    StaticCacheManager.Add(keytmp, list);
                }
                Dict dict = list[0] as Dict;
                ArrayList areas = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Area>(" where c_code='" + dict.Value + "'");
                if (areas.Count > 0)
                {
                    Area area = areas[0] as Area;
                    ArrayList citys = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<City>(" where c_code='" + area.FatherCode + "'");
                    if (citys.Count > 0)
                    {
                        City city = citys[0] as City;
                        result = city.Text;

                    }


                }
            }
            return result;
        }

        public static string GetDefaultProvince()
        {
            string key = "defaultprovince";
            string result = StaticCacheManager.Get(key) as string;
            if (result == null || result.Length == 0)
            {
                string keytmp = "dict_本地行政区划";
                ArrayList list = StaticCacheManager.Get(keytmp) as ArrayList;
                if (list == null)
                {
                    list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='本地行政区划'");
                    StaticCacheManager.Add(keytmp, list);
                }
                Dict dict = list[0] as Dict;
                ArrayList areas = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Area>(" where c_code='" + dict.Value + "'");
                if (areas.Count > 0)
                {
                    Area area = areas[0] as Area;
                    ArrayList provinces = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Province>(" where c_code='" + area.ProvinceCode + "'");
                    if (provinces.Count > 0)
                    {
                        Province province = provinces[0] as Province;
                        result = province.Text;

                    }


                }
            }
            return result;
        }

        public static string GetAreaPrefix()
        {
            string key = "areaprefix";
            string prefix = StaticCacheManager.Get(key) as string;
            if (prefix == null || prefix.Length==0)
            {
                prefix = GetDefaultProvince()+GetDefaultCity();
                StaticCacheManager.Add(key, prefix);

            }
            return prefix;
        }
    }
}
