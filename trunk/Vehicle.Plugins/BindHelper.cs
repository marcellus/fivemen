using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.CommonsPlugin;
using System.Windows.Forms;

namespace Vehicle.Plugins
{
    public class BindHelper
    {
        private BindHelper()
        {
        }

        public static void BindZwpp(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "中文品牌");
        }
        public static void BindClxh(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "车辆型号");
        }

        public static void BindPzhm(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "凭证号码");
            
        }

        public static void BindCllx(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车辆类型代码");
        }

        public static void BindIdCardType(ComboBox cb)
        {
            DictManager.BindToComboxDynamic(cb, "身份证明名称代码");
        }
        public static void BindBxCompany(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "保险公司代码表");
        }

        public static void BindGzzmmc(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "购置证明名称代码");
        }

        public static void BindGcJk(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "国产/进口车辆代码");
        }

        public static void BindHpzl(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车号牌种类代码");
            if (cb.Items.Count > 1)
            {
                cb.SelectedIndex = 1;
            }
        }

        public static void BindGetFrom(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车获得方式代码");
        }

        public static void BindJkpz(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车进口凭证代码");
        }

        public static void BindLlpz(ComboBox cb)
        {
            DictManager.BindToComboxDynamic(cb, "机动车来历凭证代码");
        }
        //机动车燃料（能源）种类代码
        public static void BindRlzl(ComboBox cb)
        {
            DictManager.BindToComboxDynamic(cb, "机动车燃料（能源）种类代码");
        }

        //机动车使用性质代码
        public static void BindUseFor(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车使用性质代码");
        }

        public static void BindSyq(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车所有权代码");
            if (cb.Items.Count > 1)
            {
                cb.SelectedIndex = 1;
            }
        }
        //机动车转向形式代码
        public static void BindZxxs(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "机动车转向形式代码");
            
        }
        //居住暂住证明名称代码
        public static void BindTempIdType(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "居住暂住证明名称代码");
        }
    }
}
