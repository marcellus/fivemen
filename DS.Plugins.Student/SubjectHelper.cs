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
        "科目一","科目二（桩）","科目二（场地）","科目三"
        };
        private static string[] subjects2 = new string[] {
        "科目一","科目二","科目三"
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
