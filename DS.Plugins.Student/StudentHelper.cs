using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Print;
using FT.Windows.Forms;
using FT.Commons.Cache;
using FT.Commons.Tools;

namespace DS.Plugins.Student
{
    public class StudentHelper
    {
        private StudentHelper()
        {
        }

        

        #region ���ɱ䶯
        /// <summary>
        ///��ӡ��ά����ĵڶ�������ı���
        /// </summary>
        /// <param name="str">�ַ��������֤+׼�ݳ���+�������</param>
        /// <returns>������8λ�ַ���</returns>
        public static string Encode(string str)
        {
            //LogFactoryWrapper.Debug("��ά��������ַ�Ϊ��" + str);
            string ls_ret = string.Empty, ls_sum = string.Empty, ls_outstr = string.Empty, ls_str = string.Empty, ls_temp = string.Empty;
            long ll_asc = 0, ll_len = 0, ll_sum = 0;
            ll_len = str.Length;
            for (int i = 1; i <= ll_len; i++)
            {
                ll_asc = (long)str[i - 1];//?ȡascii�룿
                ll_asc = ll_asc * 17 * i;
                ll_asc = ll_asc % 100L;//ȡ��������λ
                ls_str = string.Format("{0:00}", ll_asc);
                //ls_str = string.Format("{0:F2}", ll_asc);
                ll_sum = ll_sum + ll_asc;
                ls_outstr = ls_outstr + ls_str;
            }
            ll_sum = (ll_sum * 37L) % 1000L;
            ls_sum = string.Format("{0:000}", ll_sum);
            ll_len = ls_outstr.Length;
            if (ll_len > 5)
                ls_outstr = ls_outstr.Substring(0, 5);
            ll_len = ls_outstr.Length / 2;
            if (ll_len % 2 != 0)
                ll_len = ll_len + 1;
            ls_temp = ls_sum;
            for (int i = 1; i <= ll_len; i++)
            {
                ls_str = ls_outstr.Substring((i - 1) * 2, 2);
                ll_asc = long.Parse(ls_str) + long.Parse(ls_sum);
                ll_asc = ll_asc % 100;
                ls_temp = ls_temp + string.Format("{0:00}", ll_asc);
            }

            ls_outstr = ls_temp;

            if (ls_outstr.Length < 8)
            {
                ll_len = 8 - ls_outstr.Length;
                ls_str = string.Empty;
                for (int i = 1; i <= (int)ll_len; i++)
                {
                    ll_asc = ll_sum * i * 13 * ls_outstr.Length;
                    ll_asc = ll_asc % 100;
                    ls_str = ls_str + ll_asc;
                    if (ls_str.Length > ll_len)
                    {
                        ls_str = ls_str.Substring(0, (int)ll_len);
                        break;
                    }
                }
                ls_outstr = ls_outstr + ls_str;
            }

            ls_outstr = string.Format("{0:X}", long.Parse(ls_outstr));
            // g_nvo_app.uf_longtohex(long(ls_outstr))   //ת��16������

            if (ls_outstr.Length < 8)
                //ls_outstr = ls_outstr.Length>4?ls_sum.Substring(ls_sum.Length - 7 + ls_outstr.Length - 1):ls_sum + ls_outstr;
                ls_outstr = ls_outstr.Length > 4 ? ls_sum.Substring(ls_sum.Length - 7 + ls_outstr.Length - 1) + ls_outstr : ls_sum + ls_outstr;


            return ls_outstr;

        }
        /* �ڶ�λ���ּ��ܣ�ʹ�����֤�����룬ѧϰ������ɣ��������ţ�
         
         public function string wf_encode (string arg_input);string ls_ret, ls_sum, ls_outstr, ls_str, ls_temp
integer i
long   ll_asc, ll_len, ll_sum

ll_len = len(arg_input)
ll_sum = 0

for i = 1 to ll_len
   ll_asc = asc(mid(arg_input, i, 1)) //ȡAscii��
   ll_asc = ll_asc * 17 * i
   ll_asc = mod(ll_asc, 100)  //ȡ���ֵĺ��λ
   ls_str = string(ll_asc, '00')
   ll_sum = ll_sum + ll_asc
   ls_outstr = ls_outstr + ls_str
next

ll_sum = mod(ll_sum * 37, 1000) //ȡ���ֺ���λ
ls_sum = string(ll_sum, '000')

ll_len = len(ls_outstr)
if ll_len > 5 then
    ls_outstr = mid(ls_outstr, 1, 5);
end if
ll_len = len(ls_outstr) / 2
if mod(ll_len , 2) <> 0 then
    ll_len = ll_len + 1
end if
ls_temp = ls_sum
for i = 1 to ll_len
    ls_str = mid(ls_outstr, (i - 1)*2 + 1, 2)
    ll_asc = long(ls_str) + long(ls_sum)
    ll_asc = mod(ll_asc, 100)
    ls_temp = ls_temp + trim(string(ll_asc, '00'))
next

ls_outstr = ls_temp

if len(ls_outstr) < 8 then
   ll_len = 8 - len(ls_outstr)
   ls_str = ''
   for i = 1 to ll_len
      ll_asc = ll_sum * i * 13 * len(ls_outstr)
      ll_asc = mod(ll_asc, 100)
      ls_str = ls_str + string(ll_asc)
      if len(ls_str) > ll_len then
        ls_str = mid(ls_str, 1, ll_len)
        exit
      end if
   next
   ls_outstr = ls_outstr + ls_str
end if

ls_outstr = g_nvo_app.uf_longtohex(long(ls_outstr))   //ת��16������

if len(ls_outstr) < 8 then
	ls_outstr = right(ls_sum, 8 - len(ls_outstr)) + ls_outstr
end if

return ls_outstr
end function
         */

        private readonly static string QRSep = "&";

        public static void AppendString(StringBuilder sb, string app)
        {
            sb.Append(QRSep);
            sb.Append(app);
        }

        public static void Print(StudentInfo student,Keys key)
        {
            BaseStudentPrinter printer = null;
            if (key == Keys.F1)
            {
                printer = new AllPrinter(student);
            }
            else if (key == Keys.F2)
            {
                printer = new F2Printer(student);
            }
            else if (key == Keys.F3)
            {
                printer = new F3Printer(student);
            }
            else if (key == Keys.F4)
            {
                printer = new F4Printer(student);

            }
            else if (key == Keys.F5)
            {
                printer = new F5Printer(student);
                //printer = new F5Printer(this.student);
            }
            else if (key == Keys.F6)
            {
                SetPrinted(student);
                printer = new ApplyPrinter(student);
            }
            else if (key == Keys.F7)
            {
                SetPrinted(student);
                printer = new ApplyExcelPrinter(student);
                ApplyExcelPrinter tmp = printer as ApplyExcelPrinter;
                tmp.PrintExcel(false);
                return;
            }
            else if (key == Keys.F8)
            {
                printer = new F8Printer(student);
            }
            else if (key == Keys.F9)
            {
                printer = new F9Printer(student);
            }
            if (printer != null)
            {
                CommonPrinter commonPrinter = new CommonPrinter(printer);
                //commonPrinter.ShowPreviewPrinter();
                GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
                if (printSetting.PrintModel == "ֱ�Ӵ�")
                {
                    commonPrinter.Print();
                }
                else if (printSetting.PrintModel == "ѡ���ӡ��")
                {
                    commonPrinter.ShowPreviewPrinter();
                }
                else
                {
                    commonPrinter.Preview();
                }
            }
            
        }

        /// <summary>
        /// ��ѧһ��ѧԱ
        /// </summary>
        /// <param name="student"></param>
        public static void Quit(StudentInfo student)
        {
            if (student.State == "�ϸ��ҵ")
            {
                MessageBoxHelper.Show("�ϸ��ҵ��ѧ���޷���ѧ��");
                return;
            }
            if (student.State == "��ѧ")
            {
                MessageBoxHelper.Show("��ѧԱ����ѧ��");
                return;
            }
            student.State = "��ѧ";
            if (FT.DAL.Orm.SimpleOrmOperator.Update(student))
            {
                MessageBoxHelper.Show("��ѧ�ɹ���");
            }
        }

        /// <summary>
        /// ���ô�ӡ״̬ 
        /// </summary>
        /// <param name="student"></param>
        public static void SetPrinted(StudentInfo student)
        {
            student.PrintedState = "�Ѵ�ӡ";
            FT.DAL.Orm.SimpleOrmOperator.Update(student);
        }






        /// <summary>
        /// �������֤�����ƺͺ�����ת����Ҫ����ĺ���
        /// </summary>
        /// <param name="type">֤�����ƴ���</param>
        /// <param name="idcard">֤������</param>
        /// <returns></returns>
        public static string TransIdCard(string type, string idcard)
        {
            string result = idcard;
            if (type == "A" && idcard.Length == 15)
            {
                result = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
            }
            else if (type != string.Empty && type != "A")
            {
                result = type + idcard;
            }
            return result;
        }
        #endregion

        #region һЩ�����¼�
        public static void F7_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F7);
            form.ShowInTaskbar = false;
            form.Text = "ֱ�Ӵ��������ʻ֤�����";
            form.ShowDialog();
        }
        public static void F6_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F6);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻ֤�����";
            form.ShowDialog();
        }
        public static void F5_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F5);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��Ŀ�����Գɼ���";
            form.ShowDialog();
        }
        public static void F4_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F4);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻԱ��ѵѧԱ�ǼǱ�";
            form.ShowDialog();
        }
        public static void F3_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F3);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻ����������֤��";
            form.ShowDialog();
        }

        public static void F2_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F2);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻ��ѵ��¼";
            form.ShowDialog();
        }

        public static void subject1_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀһ");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        public static void subject20_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ����׮��");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        public static void subject21_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ�������أ�");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        public static void subject2_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ��");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }
        public static void subject3_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ��");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }
        #endregion
    }
}
