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
    public class FormHelper:BaseHelper
    {
        /// <summary>
        /// ��ʼ�����пؼ���ϵͳ������ʽ
        /// </summary>
        /// <param name="frm">����</param>
        public static void InitHabitToForm(Form frm)
        {
            frm.Font = new Font("����", 11f);
            InitHabitToControl(frm);
            
            
        }

        private static void InitHabitToControl(Control ctr)
        {
            //ctr.Font = new Font("����", 11f);
            if (ctr.Controls.Count == 0)
            {
                
                ctr.KeyDown += new KeyEventHandler(EnterToTab);
            }
            foreach (Control tmp in ctr.Controls)
            {
                InitHabitToControl(tmp);
            }
        }

        public static void EnterToTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
        }

        private static Hashtable caches = new Hashtable();

        /// <summary>
        /// �����������Ļ���
        /// </summary>
        public static Hashtable Caches
        {
            get { return FormHelper.caches; }
        }

        /// <summary>
        /// �Ѵ����ϵ����ݸ�ֵ��Object������
        /// </summary>
        /// <param name="form">�������</param>
        /// <param name="obj">����Object</param>
        public static void GetDataFromForm(Form form, object obj)
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
        public static void SetDataToObject(object obj, string name,object data)
        {
            Type type = obj.GetType();
            PropertyInfo prop;
            FieldInfo field;
            prop = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (prop != null)
            {
                prop.SetValue(obj, ParsePropertyInfo(prop,data ), null);
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
        private static void GetDataFromControl(Control ctr, Hashtable controls,object obj)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                if (controls.Contains(ctr.Name))
                {
                    SetDataToObject(obj, controls[ctr.Name].ToString(), GetControlValue(ctr));
                    
                    
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
        public static void SetDataToForm(Form form,object obj)
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
            if (field.FieldType == typeof(string))
            {
                return data.ToString();
            }
            if (field.FieldType == typeof(DateTime))
            {
                return Convert.ToDateTime(data.ToString());
            }
            if (field.FieldType == typeof(Boolean))
            {
                string tmp=data.ToString();
                if ( tmp== "��" )
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
        public static object GetObjectValue(object obj,string name)
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
        private static void SetDataToControl(Control ctr, Hashtable controls,object obj)
        {
             int count=ctr.Controls.Count;
             
             if (count == 0)
             {
                 if (controls.Contains(ctr.Name))
                 {
                     object objtmp = GetObjectValue(obj, controls[ctr.Name].ToString());
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
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>��ȡ�ؼ���ֵ</returns>
        private static object GetControlValue(Control ctr)
        {
            object result=null;
            if (ctr is Label)
            {
                result=((Label)ctr).Text.ToString();
            }
            else if (ctr is TextBox)
            {
                result = ((TextBox)ctr).Text.ToString();
            }
            else if (ctr is MaskedTextBox)
            {
                result = ((MaskedTextBox)ctr).Text.ToString();
            }
            
            else if (ctr is ComboBox)
            {
                if (ctr.Name.EndsWith("Value"))
                {
                    object cbtmp=((ComboBox)ctr).SelectedValue;
                    if (cbtmp != null)
                        result = cbtmp.ToString();
                    else
                        result = string.Empty;
                }
                else
                {
                    result = ((ComboBox)ctr).Text.ToString();
                }
            }
            else if (ctr is DateTimePicker)
            {
                DateTimePicker dtp=(DateTimePicker)ctr;
                if (dtp.Format == DateTimePickerFormat.Custom)
                {
                    result = dtp.Value.ToString(dtp.CustomFormat);
                }
                else
                {
                    result = dtp.Value.ToString("yyyy-MM-dd");
                }
            }
            else if (ctr is CheckBox)
            {
                result = ((CheckBox)ctr).Checked?"��":"��";
            }
            else if (ctr is PictureBox)
            {
                result = ((PictureBox)ctr).Image;
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

            else if (ctr is MaskedTextBox)
            {
                ((MaskedTextBox)ctr).Text = value.ToString();
            }
            
            
            else if (ctr is ComboBox)
            {
                if (ctr.Name.EndsWith("Value"))
                {
                    ((ComboBox)ctr).SelectedValue = value.ToString();

                }
                else
                {
                    ((ComboBox)ctr).Text = value.ToString();
                }
            }
            else if (ctr is DateTimePicker)
            {
                ((DateTimePicker)ctr).Value = Convert.ToDateTime(value);
            }
            else if (ctr is CheckBox)
            {
                ((CheckBox)ctr).Checked = (value.ToString()=="��"||value.ToString().ToLower()=="true"?true:false);
            }
            else if (ctr is PictureBox)
            {
                ((PictureBox)ctr).Image = value as Image;
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
            string name=ctr.Name;
            //num�ؼ� ����һ�� û�����ֵ�textbox
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
            else if (ctr is MaskedTextBox)
            {
                result = name.Substring(4);
            }
            
            else if (ctr is ComboBox)
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
            log.Debug(ctr.Name+"ת����ؼ�������Ϊ��"+result);
            return result;

        }

        /// <summary>
        ///  �Ӵ���ؼ���ȡ��ĳһ�����Ͷ�Ӧ��ʵ��
        /// </summary>
        /// <param name="ctr">�ؼ���һ��ָ����</param>
        /// <param name="type">����</param>
        /// <param name="controls">�����hashtable</param>
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
        /// �Ӵ���ؼ���ȡ��ĳһ�����Ͷ�Ӧ��ʵ��
        /// </summary>
        /// <param name="form">����ʵ��</param>
        /// <param name="type">��������</param>
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
