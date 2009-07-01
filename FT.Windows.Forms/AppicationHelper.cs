using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using FT.Commons.Cache;
using FT.Windows.Forms.Domain;

namespace FT.Windows.Forms
{
    /// <summary>
    /// ִ�г�������
    /// </summary>
    public class AppicationHelper
    {

        public static void Start(string key, Image bg, Type panelType, string panelText)
        {
            StartLimitDays(key, bg, 100, "", false,panelType,panelText);
        }

        public static void StartLimitTimes(string key, Image bg, int limit, string phone, bool needregister)
        {
            StartLimitTimes(key, bg, limit, phone, needregister, null, null);
        }

        public static void StartLimitTimes(string key, Image bg, int limit, string phone, bool needregister, Type panelType, string panelText)
        {
            if (CheckMutex(key))
            {
                GetProgramState();
                string text = Application.ProductName + Application.ProductVersion;
                if (needregister && productState != ProgramState.Registed)
                {
                    string lastfiledate = FileHelper.ReadLastLog(Application.ProductName);
                    //��һ��ʹ��,�������װϵͳ����Ƴ�ע����Ϣ��ʹ�õ�λ��Ϣ
                    if (lastfiledate == null || lastfiledate == string.Empty)
                    {
                        StaticCacheManager.RemoveConfig<ProgramRegConfig>();
                        //StaticCacheManager.RemoveConfig<CompanyInfo>();
                        Register(bg, text,panelType,panelText);
                    }
                    else//�������װ�°汾����������
                    {
                        ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                        //��������ʹ�����ڣ�����û��ע����Ϣ��ʱ���Զ��˳�
                        if (config.RegDate == null)
                        {
                            //MessageBoxHelper.Show("ϵͳע���ļ����𻵣������°�װ���޸���ϵͳ��");
                            //Application.Exit();
                            Register(bg, text,panelType,panelText);
                        }
                        else//����д��ע����Ϣ�ˣ�Ҫ�ж��Ƿ�۸�ϵͳʱ������Ƿ񳬳�����ʱ����
                        {
                            if (config.UseCount >= limit)
                            {
                                MessageBoxHelper.Show("�������� " + limit.ToString() + "�����ƣ�����ϵ��Ʒ�����̣�" + (phone.Length > 0 ? "\r\n��ϵ�绰��" + phone : ""));
                                Application.ExitThread();
                                return;
                            }
                            else
                            {
                                if (AppicationHelper.ProductState != ProgramState.Registed)
                                text += "(" + limit + "�����ð汾��ʣ��" + (limit - config.UseCount) + "��)";
                                Run(bg, text,panelType,panelText);
                            }

                        }

                    }

                }
                else
                {
                    productState = ProgramState.Registed;
                    Run(bg, text,panelType,panelText);
                }


                //�ж��Ƿ���ʹ���ļ����ô���
                //���������ʱ��
                //����Ҫ���ӵ�Winform��text����Ϣ���ݹ�ȥ

            }
            else
            {
                //�����ò���
                MessageBoxHelper.Show("�Ѿ�������һ�������ĳ���");
            }
        }

        private static bool CheckMutex(string key)
        {
            bool result;
            //Create a new mutex using specific mutex name
            Mutex m = new Mutex(false, key, out result);
            return result;

        }

        private static ProgramState productState = ProgramState.None;

        /// <summary>
        /// ��Ʒ״̬���Ƿ���ע��
        /// </summary>
        public static ProgramState ProductState
        {
            get { return AppicationHelper.productState; }

        }

        private static void Run(Image bg, string text,Type panelType,string panelText)
        {
            Welcome welcome = new Welcome();
            welcome.ShowInTaskbar = false;
            if (bg != null)
            {
                welcome.BackgroundImage = bg;
            }
            welcome.Show();
            Form form = new FT.Windows.Forms.LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                welcome.Close();
                FT.Windows.Forms.BaseMainForm main = new FT.Windows.Forms.BaseMainForm();
                main.Text = text;
                if (bg != null)
                {
                    TabPage tb = new TabPage("��ӭ��   ");
                    tb.BackgroundImage = bg;
                    tb.BackgroundImageLayout = ImageLayout.Stretch;
                    main.GetSimpleTabControl().TabPages.Add(tb);
                }
                if (panelType != null)
                {
                    TabPage tb = new TabPage(panelText+"   ");
                    object paneltmp = ReflectHelper.CreateInstance(panelType);
                    if ((typeof(UserControl)).IsAssignableFrom(paneltmp.GetType()))
                    {
                        Control panel = (Control)paneltmp;
                        panel.Dock = DockStyle.Fill;
                        tb.Controls.Add(panel);
                    }
                    main.GetSimpleTabControl().TabPages.Add(tb);
                    if (main.GetSimpleTabControl().TabPages.Count>0)
                        main.GetSimpleTabControl().SelectedIndex = main.GetSimpleTabControl().TabPages.Count-1;
                }
                Application.Run(main);
            }
            else
            {
                welcome.Close();
            }
        }

        private static void Register(Image bg, string text, Type panelType, string panelText)
        {
            SimpleRegister register = new SimpleRegister();
            if (register.ShowDialog() == DialogResult.OK)
            {
               
                Run(bg, text,panelType,panelText);

            }
            else
            {
                Application.ExitThread();
            }
        }

        private static void GetProgramState()
        {
            //log4net.LogManager.ResetConfiguration();
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log.xml"));
            ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
            if (config.KeyCode != null && config.KeyCode.Length > 0)
            {
                productState = ProgramState.Registed;
            }
            else if (config.RightCode.Length != 0)
            {
                productState = ProgramState.Trial;
            }
            else
            {
                productState = ProgramState.None;
            }
        }

        public static void StartLimitDays(string key, Image bg, int limit, string phone, bool needregister)
        {
            StartLimitDays(key, bg, limit, phone, needregister, null, null);
        }

        public static void StartLimitDays(string key, Image bg, int limit, string phone, bool needregister, Type panelType, string panelText)
        {

            
            if (CheckMutex(key))
            {
                GetProgramState();
                string text = Application.ProductName + Application.ProductVersion;
                if (needregister&&productState!=ProgramState.Registed)
                {
                    string lastfiledate = FileHelper.ReadLastLog(Application.ProductName);
                    //��һ��ʹ��,�������װϵͳ����Ƴ�ע����Ϣ��ʹ�õ�λ��Ϣ
                    if (lastfiledate==null||lastfiledate == string.Empty)
                    {
                        StaticCacheManager.RemoveConfig<ProgramRegConfig>();
                        //StaticCacheManager.RemoveConfig<CompanyInfo>();
                        Register(bg, text,panelType,panelText);
                    }
                    else//�������װ�°汾����������
                    {
                        ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                        //��������ʹ�����ڣ�����û��ע����Ϣ��ʱ���Զ��˳�
                        if (config.RegDate == null||config.RegDate.ToString().StartsWith("0001"))
                        {
                            //MessageBoxHelper.Show("ϵͳע���ļ����𻵣������°�װ���޸���ϵͳ��");
                            //Application.Exit();
                            Register(bg, text,panelType,panelText);
                        }
                        else//����д��ע����Ϣ�ˣ�Ҫ�ж��Ƿ�۸�ϵͳʱ������Ƿ񳬳�����ʱ����
                        {
                            DateTime regdate = config.RegDate;
                            DateTime lastdate = config.LastDate;
                            DateTime now = System.DateTime.Now;
                            if (lastdate > now || regdate > now || regdate > lastdate)
                            {
                                MessageBoxHelper.Show("ϵͳʱ�䷢���仯�������°�װ��");
                                Application.ExitThread();
                                return;
                            }
                            else if (now > regdate.AddDays(limit))
                            {
                                MessageBoxHelper.Show("��������ʱ��" + limit.ToString() + "�����ƣ�����ϵ��Ʒ�����̣�" + (phone.Length > 0 ? "\r\n��ϵ�绰��" + phone : ""));
                                Application.ExitThread();
                                return;
                            }
                            else
                            {
                                TimeSpan ts = now - regdate;
                                if (AppicationHelper.ProductState != ProgramState.Registed)
                                text += "(" + limit + "�����ð汾��ʣ��" + (limit - ts.Days) + "��)";
                                Run(bg, text,panelType,panelText);
                            }

                        }

                    }

                }
                else
                {
                    productState = ProgramState.Registed;
                    Run(bg, text,panelType,panelText);
                }


                //�ж��Ƿ���ʹ���ļ����ô���
                //���������ʱ��
                //����Ҫ���ӵ�Winform��text����Ϣ���ݹ�ȥ

            }
            else
            {
                MessageBoxHelper.Show("�Ѿ�������һ�������ĳ���");
            }
        }
    }
}
