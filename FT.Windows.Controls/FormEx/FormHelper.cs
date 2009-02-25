using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using log4net;
using System.Drawing;
using System.Reflection;

namespace Fm.Windows.Controls.FormEx
{
    /// <summary>
    /// 帮助把一个对象绑定到一个窗体上已经把窗体上的数据绑定到一个对象上
    /// 绑定使用getset的属性,不支持列表属性,暂不支持关联属性
    /// 只支持public的可访问性
    /// 自带cache，格式
    ///             实体类名 
    ///                         关联对象id,控件name-实体属性
    ///  窗体类名   实体类名    关联对象id
    ///                         关联对象id
    ///             实体类名
    /// </summary>
    public class FormHelper
    {
        private static ILog log = log4net.LogManager.GetLogger("Fm.Windows.Controls.FormEx.FormHelper");

        private static Hashtable caches = new Hashtable();

        /// <summary>
        /// 窗体对象关联的缓存
        /// </summary>
        public static Hashtable Caches
        {
            get { return FormHelper.caches; }
        }

        /// <summary>
        /// 把窗体上的数据赋值到Object对象上
        /// </summary>
        /// <param name="form">窗体对象</param>
        /// <param name="obj">对象Object</param>
        public static void GetData(Form form, Object obj)
        {
            Type type = obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.ToString()] as Hashtable;
                if (controls != null)
                {
                    PropertyInfo prop;
                    FieldInfo field;
                    foreach (Control ctr in form.Controls)
                    {
                        if (controls.Contains(ctr.Name))
                        {
                            prop=type.GetProperty(controls[ctr.Name].ToString());
                            if (prop != null)
                            {
                                prop.SetValue(obj, GetControlValue(ctr), null);
                            }
                            else
                            {
                                field = type.GetField(controls[ctr.Name].ToString());
                                if (field != null)
                                {
                                    field.SetValue(obj,GetControlValue(ctr));
                                }
                            }
                        }
                    }
                }
            }
        }

       /// <summary>
       /// 把一个对象赋值到窗体上
       /// </summary>
       /// <param name="form">窗体</param>
       /// <param name="obj">实体对象</param>
        public static void LoadData(Form form, Object obj)
        {
            Type type=obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.GetType().FullName] as Hashtable;
                if(controls!=null)
                {
                    PropertyInfo prop;
                    FieldInfo field;
                    foreach (Control ctr in form.Controls)
                    {
                        if (controls.Contains(ctr.Name)) 
                        {
                            prop = type.GetProperty(controls[ctr.Name].ToString());
                            if (prop != null)
                            {
                                SetControlValue(ctr, prop.GetValue(obj, null));
                            }
                            else
                            {
                                field = type.GetField(controls[ctr.Name].ToString());
                                if (field != null)
                                {
                                    SetControlValue(ctr, field.GetValue(obj));
                                }
                            }
                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取控件的值
        /// </summary>
        /// <param name="ctr">控件，支持 以下对象属性的简写
        /// Label lb
        /// TextBox txt
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>获取控件的值</returns>
        private static object GetControlValue(Control ctr)
        {
            object result=null;
            if (ctr is Label)
            {
                result=((Label)ctr).Text;
            }
            else if (ctr is TextBox)
            {
                result = ((TextBox)ctr).Text ;
            }
            else if (ctr is ComboBox)
            {
                result = ((ComboBox)ctr).Text;
            }
            else if (ctr is DateTimePicker)
            {
                result = ((DateTimePicker)ctr).Value ;
            }
            else if (ctr is CheckBox)
            {
                result = ((CheckBox)ctr).Checked;
            }
            else if (ctr is PictureBox)
            {
                result = ((PictureBox)ctr).Image;
            }
            return result;
        }

        /// <summary>
        /// 为某个控件赋值
        /// </summary>
        /// <param name="ctr">控件，支持 以下对象属性的简写
        /// Label lb
        /// TextBox txt
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <param name="value">具体的值</param>
        private static void SetControlValue(Control ctr, object value)
        {
            if (value == null)
            {
                return;
            }
            if (ctr is Label)
            {
                ((Label)ctr).Text = value.ToString();
            }
            else if (ctr is TextBox)
            {
                ((TextBox)ctr).Text = value.ToString();
            }
            else if (ctr is ComboBox)
            {
                ((ComboBox)ctr).Text = value.ToString();
            }
            else if (ctr is DateTimePicker)
            {
                ((DateTimePicker)ctr).Value = Convert.ToDateTime(value);
            }
            else if (ctr is CheckBox)
            {
                ((CheckBox)ctr).Checked = Convert.ToBoolean(value);
            }
            else if (ctr is PictureBox)
            {
                ((PictureBox)ctr).Image = value as Image;
            }
        }

        /// <summary>
        /// 根据控件名称得出跟实体对应的属性名
        /// </summary>
        /// <param name="ctr">控件支持以下对象属性的简写
        /// Label lb
        /// TextBox txt
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>属性名</returns>
        public static string ParseControlName(Control ctr)
        {
            string result = string.Empty;
            string name=ctr.Name;
            if (ctr is Label)
            {
                result = name.Substring(2);
            }
            else if (ctr is TextBox)
            {
                result = name.Substring(3);
            }
            else if (ctr is ComboBox)
            {
                result = name.Substring(2);
            }
            else if (ctr is DateTimePicker)
            {
                result = name.Substring(4);
            }
            else if (ctr is CheckBox)
            {
                result = name.Substring(5);
            }
            else if (ctr is PictureBox)
            {
                result = name.Substring(3);
            }
           // Console.WriteLine(ctr.Name+"转换后控件的名称为："+result);
            return result;

        }

        private static void InitType(Form form, Type type)
        {
            string prop = string.Empty;
            Hashtable table = new Hashtable();
            Hashtable controls = new Hashtable();
            foreach (Control ctr in form.Controls)
            {
                prop = ParseControlName(ctr);
                if (type.GetProperty(prop) != null)
                {
                    controls.Add(ctr.Name, prop);
                }
            }
            if (controls.Count > 0)
            {
                table.Add(type.FullName, controls);
                caches.Add(form.GetType().FullName,table);
            }
        }
    }
}
