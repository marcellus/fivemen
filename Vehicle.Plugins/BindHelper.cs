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
            DictManager.BindToCombox(cb, "����Ʒ��");
        }
        public static void BindClxh(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "�����ͺ�");
        }

        public static void BindPzhm(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "ƾ֤����");
            
        }

        public static void BindCllx(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "�����������ʹ���");
        }

        public static void BindIdCardType(ComboBox cb)
        {
            DictManager.BindToComboxDynamic(cb, "���֤�����ƴ���");
        }
        public static void BindBxCompany(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "���չ�˾�����");
        }

        public static void BindGzzmmc(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "����֤�����ƴ���");
        }

        public static void BindGcJk(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "����/���ڳ�������");
        }

        public static void BindHpzl(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "�����������������");
            if (cb.Items.Count > 1)
            {
                cb.SelectedIndex = 1;
            }
        }

        public static void BindGetFrom(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "��������÷�ʽ����");
        }

        public static void BindJkpz(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "����������ƾ֤����");
        }

        public static void BindLlpz(ComboBox cb)
        {
            DictManager.BindToComboxDynamic(cb, "����������ƾ֤����");
        }
        //������ȼ�ϣ���Դ���������
        public static void BindRlzl(ComboBox cb)
        {
            DictManager.BindToComboxDynamic(cb, "������ȼ�ϣ���Դ���������");
        }

        //������ʹ�����ʴ���
        public static void BindUseFor(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "������ʹ�����ʴ���");
        }

        public static void BindSyq(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "����������Ȩ����");
            if (cb.Items.Count > 1)
            {
                cb.SelectedIndex = 1;
            }
        }
        //������ת����ʽ����
        public static void BindZxxs(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "������ת����ʽ����");
            
        }
        //��ס��ס֤�����ƴ���
        public static void BindTempIdType(ComboBox cb)
        {
            DictManager.BindToCombox(cb, "��ס��ס֤�����ƴ���");
        }
    }
}
