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
    public class FormHelper
    {
        private static ILog log = log4net.LogManager.GetLogger("Fm.Windows.Controls.FormEx.FormHelper");

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
       /// ��һ������ֵ��������
       /// </summary>
       /// <param name="form">����</param>
       /// <param name="obj">ʵ�����</param>
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
        /// ��ȡ�ؼ���ֵ
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
        /// Ϊĳ���ؼ���ֵ
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
        /// ���ݿؼ����Ƶó���ʵ���Ӧ��������
        /// </summary>
        /// <param name="ctr">�ؼ�֧�����¶������Եļ�д
        /// Label lb
        /// TextBox txt
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>������</returns>
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
           // Console.WriteLine(ctr.Name+"ת����ؼ�������Ϊ��"+result);
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
