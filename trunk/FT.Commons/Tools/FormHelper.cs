using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using log4net;
using System.Drawing;
using System.Reflection;

namespace FT.Commons.Tools
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
    public class FormHelper:BaseHelper
    {

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
        public static void GetData(Form form, object obj)
        {
            Type type = obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitFormType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.ToString()] as Hashtable;
                if (controls != null)
                {
                    GetDataFromControl(form, controls, obj);
                }
            }
        }

        /// <summary>
        /// 从控件跟实体对应的缓存中设置数据到一个对象实体上
        /// </summary>
        /// <param name="ctr">具体的控件，一般用在form上</param>
        /// <param name="controls">缓存的hashtable</param>
        /// <param name="obj">对象实体</param>
        private static void GetDataFromControl(Control ctr, Hashtable controls,object obj)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                if (controls.Contains(ctr.Name))
                {
                    Type type=obj.GetType();
                    PropertyInfo prop;
                    FieldInfo field;
                    prop = type.GetProperty(controls[ctr.Name].ToString());
                    if (prop != null)
                    {
                        prop.SetValue(obj, GetControlValue(ctr), null);
                    }
                    else
                    {
                        field = type.GetField(controls[ctr.Name].ToString());
                        if (field != null)
                        {
                            field.SetValue(obj, GetControlValue(ctr));
                        }
                    }
                }
            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    GetDataFromControl(tmp, controls, obj);
                }
            }
        }

       /// <summary>
       /// 把一个对象赋值到窗体上
       /// </summary>
       /// <param name="form">窗体</param>
       /// <param name="obj">实体对象</param>
        public static void LoadData(Form form,object obj)
        {
            if (form==null||obj == null)
            {
                return;
            }
            Type type=obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitFormType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.GetType().FullName] as Hashtable;
                if(controls!=null)
                {
                    
                    LoadFromControl(form, controls,obj);
                    
                }
            }
        }

        private static void LoadFromControl(Control ctr, Hashtable controls,object obj)
        {
             int count=ctr.Controls.Count;
             Type type = obj.GetType();
             if (count == 0)
             {
                 if (controls.Contains(ctr.Name))
                 {
                     PropertyInfo prop;
                     FieldInfo field;
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
             else
             {
                 foreach (Control tmp in ctr.Controls)
                 {
                     LoadFromControl(tmp, controls,obj);
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
            log.Debug(ctr.Name+"转换后控件的名称为："+result);
            return result;

        }

        /// <summary>
        ///  从窗体控件获取跟某一类类型对应的实例
        /// </summary>
        /// <param name="ctr">控件，一般指窗体</param>
        /// <param name="type">类型</param>
        /// <param name="controls">缓存的hashtable</param>
        private static void InitControl(Control ctr,Type type,Hashtable controls)
        {
            int count=ctr.Controls.Count;
            if (count == 0)
            {
                string prop = ParseControlName(ctr);
                if (type.GetProperty(prop) != null || type.GetField(prop) != null)
                {
                    controls.Add(ctr.Name, prop);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    InitControl(ctr.Controls[i],type, controls);
                }
            }
        }
        /// <summary>
        /// 从窗体控件获取跟某一类类型对应的实例
        /// </summary>
        /// <param name="form">窗体实例</param>
        /// <param name="type">对象类型</param>
        private static void InitFormType(Form form, Type type)
        {
            
            string prop = string.Empty;
            Hashtable table = new Hashtable();
            Hashtable controls = new Hashtable();
            InitControl(form,type, controls);
            if (controls.Count > 0)
            {
                table.Add(type.FullName, controls);
                caches.Add(form.GetType().FullName,table);
            }
        }
    }
}
