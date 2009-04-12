using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Cache;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public class SubjectHelper
    {
        private static string[] subjects1 = new string[] {
        "��Ŀһ","��Ŀ����׮��","��Ŀ�������أ�","��Ŀ��"
        };
        private static string[] subjects2 = new string[] {
        "��Ŀһ","��Ŀ��","��Ŀ��"
        };

        public static void BindSubject(ComboBox cb)
        {
            BindCombox(cb);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndex = 0;
        }

        public static void BindCombox(ComboBox cb)
        {
            StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
            string[] array = subjects2;
            if (config.SubjectIs4)
            {
                array = subjects1;
            }
            foreach (string str in array)
            {
                cb.Items.Add(str);
            }
            
        }
        
    }
}
