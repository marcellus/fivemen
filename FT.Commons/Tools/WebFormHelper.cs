using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.ObjectModel;
using log4net;
using System.Drawing;
using System.Reflection;

namespace FT.Commons.Tools
{
    /// <summary>
    /// ������һ������󶨵�һ���������Ѿ��Ѵ����ϵ����ݰ󶨵�һ��������
    /// ��ʹ��getset������,��֧���б�����,�ݲ�֧�ֹ�������
    /// ֻ֧��public�Ŀɷ�����
    /// �Դ�cache����ʽ
    ///             ʵ������ 
    ///                         ��������id,�ؼ�name-ʵ������
    ///  ��������   ʵ������    ��������id
    ///                         ��������id
    ///             ʵ������
    /// </summary>
    public class WebFormHelper : BaseHelper
    {

        public static void WriteScript(Page page,string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "script_tmp", script); 
        }

        public static void Alert(Page page,string msg)
        {
            WriteScript(page,"<script>alert('"+msg+"');</script>"); 
        }

        public static void Confirm(Page page,string msg)
        {
            WriteScript(page, "<script>confirm('" + msg + "');</script>"); 
        }

        private static Hashtable caches = new Hashtable();

        /// <summary>
        /// �����������Ļ���
        /// </summary>
        public static Hashtable Caches
        {
            get { return WebFormHelper.caches; }
        }

        /// <summary>
        /// �Ѵ����ϵ����ݸ�ֵ��Object������
        /// </summary>
        /// <param name="form">�������</param>
        /// <param name="obj">����Object</param>
        public static void GetDataFromForm(Page form, object obj)
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
        /// �Ѳ���data���õ�object��name���Ի����ֶ���
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public static void SetDataToObject(object obj, string name, object data)
        {
            Type type = obj.GetType();
            PropertyInfo prop;
            FieldInfo field;
            prop = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (prop != null)
            {
                prop.SetValue(obj, ParsePropertyInfo(prop, data), null);
            }
            else
            {
                field = type.GetField(name, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                if (field != null)
                {
                    //field.SetValueDirect

                    field.SetValue(obj, ParseFieldInfo(field, data));
                }
            }
        }

        /// <summary>
        /// �ӿؼ���ʵ���Ӧ�Ļ������������ݵ�һ������ʵ����
        /// </summary>
        /// <param name="ctr">����Ŀؼ���һ������form��</param>
        /// <param name="controls">�����hashtable</param>
        /// <param name="obj">����ʵ��</param>
        private static void GetDataFromControl(Control ctr, Hashtable controls, object obj)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                if (ctr.ID!=null&&controls.Contains(ctr.ID))
                {
                    SetDataToObject(obj, controls[ctr.ID].ToString(), GetControlValue(ctr));


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
        /// ��һ������ֵ��������
        /// </summary>
        /// <param name="form">����</param>
        /// <param name="obj">ʵ�����</param>
        public static void SetDataToForm(Page form, object obj)
        {
            if (form == null || obj == null)
            {
                return;
            }
            Type type = obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitFormType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.GetType().FullName] as Hashtable;
                if (controls != null)
                {

                    SetDataToControl(form, controls, obj);

                }
            }
        }


        /// <summary>
        /// ����PropertyInfo������dataת���ɺ��ʵ����Ͷ���
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static object ParsePropertyInfo(PropertyInfo prop, object data)
        {
            if (prop.PropertyType == typeof(Int32))
            {
                try
                {
                    return Convert.ToInt32(data.ToString());
                }
                catch
                {
                    return -1;
                }
            }
            if (prop.PropertyType == typeof(string))
            {
                return data.ToString();
            }
            if (prop.PropertyType == typeof(DateTime))
            {
                return Convert.ToDateTime(data.ToString());
            }
            if (prop.PropertyType == typeof(Boolean))
            {
                string tmp = data.ToString();
                if (tmp == "��")
                {
                    return true;
                }
                else if (tmp == "��")
                {
                    return false;
                }
                return Convert.ToBoolean(tmp);
            }
            return null;
        }



        /// <summary>
        /// ����FieldInfo������dataת���ɺ��ʵ����Ͷ���
        /// </summary>
        /// <param name="field">FieldInfo</param>
        /// <param name="data">����</param>
        /// <returns>���ʵ����Ͷ���</returns>
        private static object ParseFieldInfo(FieldInfo field, object data)
        {
#if DEBUG
            string tt=field.Name;
#endif
            if (field.FieldType == typeof(Int32))
            {
                try
                {
                    return Convert.ToInt32(data.ToString());
                }
                catch
                {
                    return -1;
                }
            }
            if (field.FieldType == typeof(double))
            {
                try
                {
                    return Convert.ToDouble(data.ToString());
                }
                catch
                {
                    return 0.0D;
                }
            }
            if (field.FieldType == typeof(decimal))
            {
                try
                {
                    return Convert.ToDecimal(data.ToString());
                }
                catch
                {
                    return 0.0M;
                }
            }
            if (field.FieldType == typeof(string))
            {
                return data.ToString();
            }
            if (field.FieldType == typeof(DateTime))
            {
                if (data.ToString().Length == 0)
                {
                    return null;
                }
                return Convert.ToDateTime(data.ToString());
            }
            if (field.FieldType == typeof(Boolean))
            {
                string tmp = data.ToString();
                if (tmp == "��")
                {
                    return true;
                }
                else if (tmp == "��")
                {
                    return false;
                }
                return Convert.ToBoolean(tmp);
            }
            return null;
        }
        /// <summary>
        /// ��ȡ��������Ϊname�����Ի����ֶ�ֵ���������ԣ�����û����ȡ�ֶ�
        /// �ֶ�û���򷵻ؿ�
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetObjectValue(object obj, string name)
        {
            PropertyInfo prop;
            FieldInfo field;
            Type type = obj.GetType();
            prop = type.GetProperty(name);
            if (prop != null)
            {
                return prop.GetValue(obj, null);
            }
            else
            {
                field = type.GetField(name);
                if (field != null)
                {
                    return field.GetValue(obj);
                }
            }
            return null;
        }

        /// <summary>
        /// ��object����ȫ����ֵ��control��ȥ
        /// </summary>
        /// <param name="ctr"></param>
        /// <param name="controls"></param>
        /// <param name="obj"></param>
        private static void SetDataToControl(Control ctr, Hashtable controls, object obj)
        {
            int count = ctr.Controls.Count;

            if (ctr!=null&&ctr.ID!=null&&count == 0)
            {
                if (controls.Contains(ctr.ID))
                {
                    object objtmp = GetObjectValue(obj, controls[ctr.ID].ToString());
                    if (objtmp != null)
                    {
                        SetControlValue(ctr, objtmp);
                    }

                }

            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    SetDataToControl(tmp, controls, obj);
                }
            }
        }

        /// <summary>
        /// ��ȡ�ؼ���ֵ,���ؾ���ؼ���ֵ
        /// </summary>
        /// <param name="ctr">�ؼ���֧�� ���¶������Եļ�д
        /// Label lb
        /// TextBox txt
        /// ComboBox Dropdownlist cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>��ȡ�ؼ���ֵ</returns>
        private static object GetControlValue(Control ctr)
        {
            object result = null;
            if (ctr is Label)
            {
                result = ((Label)ctr).Text.ToString();
            }
            else if (ctr is TextBox)
            {
                result = ((TextBox)ctr).Text.ToString();
            }

            else if (ctr is DropDownList)
            {
                if (ctr.ID.EndsWith("Value"))
                {
                    object cbtmp = ((DropDownList)ctr).SelectedValue;
                    if (cbtmp != null)
                        result = cbtmp.ToString();
                    else
                        result = string.Empty;
                }
                else
                {
                    result = ((DropDownList)ctr).Text.ToString();
                }
            }
            
            else if (ctr is CheckBox)
            {
                result = ((CheckBox)ctr).Checked ? "��" : "��";
            }
            else if (ctr is RadioButtonList)
            {
                result = ((RadioButtonList)ctr).Text;
            }
            
            return result;
        }

        /// <summary>
        /// Ϊĳ���ؼ���ֵ,�Զ�����valueֵת����ֵ���ؼ�
        /// </summary>
        /// <param name="ctr">�ؼ���֧�� ���¶������Եļ�д
        /// Label lb
        /// TextBox txt
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <param name="value">�����ֵ</param>
        private static void SetControlValue(Control ctr, object value)
        {
            /*
            if (value is double)
            {
                value = string.Format("{0:N2}", value);
            }
             * */
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

           

            else if (ctr is DropDownList)
            {
                if (ctr.ID.EndsWith("Value"))
                {
                    ((DropDownList)ctr).SelectedValue = value.ToString();

                }
                else
                {
                    ((DropDownList)ctr).Text = value.ToString();
                }
            }
          
            else if (ctr is CheckBox)
            {
                ((CheckBox)ctr).Checked = (value.ToString() == "��" || value.ToString().ToLower() == "true" ? true : false);
            }
            else if (ctr is RadioButtonList)
            {
                ((RadioButtonList)ctr).Text = value.ToString();
            }
            
        }

        /// <summary>
        /// ���ݿؼ����Ƶó���ʵ���Ӧ��������
        /// </summary>
        /// <param name="ctr">�ؼ�֧�����¶������Եļ�д
        /// Label lb
        /// TextBox txt
        /// MaskedBox mtxt
        /// ComboBox cb
        /// LinkLabel lb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>������</returns>
        public static string ParseControlName(Control ctr)
        {
            string result = string.Empty;
            string name = ctr.ID;
            //num�ؼ� ����һ�� û�����ֵ�textbox
            if(name==null)
            {

                return string.Empty;
            }
            if (name.Length == 0)
            {
                return string.Empty;
            }
            if (ctr is Label)
            {
                result = name.Substring(2);
            }
            else if (ctr is TextBox)
            {
                result = name.Substring(3);
            }
            

            else if (ctr is DropDownList)
            {
                if (name.EndsWith("Value"))
                {
                    ///����Ƿ���ȷ
                    result = name.Substring(2, name.Length - 7);
                }
                else
                {
                    result = name.Substring(2);
                }
            }
            
            else if (ctr is CheckBox)
            {
                result = name.Substring(5);
            }
            else if (ctr is RadioButtonList)
            {
                result = name.Substring(3);
            }
            
            log.Debug(ctr.ID + "ת����ؼ�������Ϊ��" + result);
            return result;

        }

        /// <summary>
        ///  �Ӵ���ؼ���ȡ��ĳһ�����Ͷ�Ӧ��ʵ��
        /// </summary>
        /// <param name="ctr">�ؼ���һ��ָ����</param>
        /// <param name="type">����</param>
        /// <param name="controls">�����hashtable</param>
        private static void InitControl(Control ctr, Type type, Hashtable controls)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                string prop = ParseControlName(ctr);
                if (prop.Length>0&&(type.GetProperty(prop) != null || type.GetField(prop) != null))
                {
                    controls.Add(ctr.ID, prop);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    InitControl(ctr.Controls[i], type, controls);
                }
            }
        }
        /// <summary>
        /// �Ӵ���ؼ���ȡ��ĳһ�����Ͷ�Ӧ��ʵ��
        /// </summary>
        /// <param name="form">����ʵ��</param>
        /// <param name="type">��������</param>
        private static void InitFormType(Page form, Type type)
        {

            string prop = string.Empty;
            Hashtable table = new Hashtable();
            Hashtable controls = new Hashtable();
            InitControl(form, type, controls);
            if (controls.Count > 0)
            {
                table.Add(type.FullName, controls);
                caches.Add(form.GetType().FullName, table);
            }
        }
    }
}
