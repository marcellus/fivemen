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
    /// 执行程序启动
    /// </summary>
    public class AppicationHelper
    {

        public static void Start(string key, Image bg)
        {
            StartLimitDays(key, bg, 100, "", false);
        }
        public static void StartLimitTimes(string key, Image bg, int limit, string phone, bool needregister)
        {
            if (CheckMutex(key))
            {
                GetProgramState();
                string text = Application.ProductName + Application.ProductVersion;
                if (needregister)
                {
                    string lastfiledate = FileHelper.ReadLastLog(Application.ProductName);
                    //第一次使用,如果是重装系统后就移除注册信息和使用单位信息
                    if (lastfiledate == null || lastfiledate == string.Empty)
                    {
                        StaticCacheManager.RemoveConfig<ProgramRegConfig>();
                        //StaticCacheManager.RemoveConfig<CompanyInfo>();
                        Register(bg, text);
                    }
                    else//如果重新装新版本会启动不了
                    {
                        ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                        //如果有最后使用日期，但是没有注册信息的时候自动退出
                        if (config.RegDate == null)
                        {
                            //MessageBoxHelper.Show("系统注册文件被损坏，请重新安装或修复本系统！");
                            //Application.Exit();
                            Register(bg, text);
                        }
                        else//已填写过注册信息了，要判断是否篡改系统时间或者是否超出试用时间了
                        {
                            if (config.UseCount >= limit)
                            {
                                MessageBoxHelper.Show("超出试用 " + limit.ToString() + "次限制，请联系产品销售商！" + (phone.Length > 0 ? "\r\n联系电话：" + phone : ""));
                                Application.ExitThread();
                                return;
                            }
                            else
                            {
                                text += "(" + limit + "次试用版本，剩下" + (limit - config.UseCount) + "次)";
                                Run(bg, text);
                            }

                        }

                    }

                }
                else
                {
                    productState = ProgramState.Registed;
                    Run(bg, text);
                }


                //判断是否有使用文件配置存在
                //二如果发生时间
                //把需要附加到Winform的text的信息传递过去

            }
            else
            {
                //这里用不到
                MessageBoxHelper.Show("已经运行了一个这样的程序！");
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
        /// 产品状态，是否已注册
        /// </summary>
        public static ProgramState ProductState
        {
            get { return AppicationHelper.productState; }

        }

        private static void Run(Image bg, string text)
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
                    TabPage tb = new TabPage("欢迎您   ");
                    tb.BackgroundImage = bg;
                    tb.BackgroundImageLayout = ImageLayout.Stretch;
                    main.GetSimpleTabControl().TabPages.Add(tb);
                }
                Application.Run(main);
            }
            else
            {
                welcome.Close();
            }
        }

        private static void Register(Image bg, string text)
        {
            SimpleRegister register = new SimpleRegister();
            if (register.ShowDialog() == DialogResult.OK)
            {
               
                Run(bg, text);

            }
            else
            {
                Application.ExitThread();
            }
        }

        private static void GetProgramState()
        {
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

            
            if (CheckMutex(key))
            {
                GetProgramState();
                string text = Application.ProductName + Application.ProductVersion;
                if (needregister)
                {
                    string lastfiledate = FileHelper.ReadLastLog(Application.ProductName);
                    //第一次使用,如果是重装系统后就移除注册信息和使用单位信息
                    if (lastfiledate==null||lastfiledate == string.Empty)
                    {
                        StaticCacheManager.RemoveConfig<ProgramRegConfig>();
                        //StaticCacheManager.RemoveConfig<CompanyInfo>();
                        Register(bg, text);
                    }
                    else//如果重新装新版本会启动不了
                    {
                        ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                        //如果有最后使用日期，但是没有注册信息的时候自动退出
                        if (config.RegDate == null||config.RegDate.ToString().StartsWith("0001"))
                        {
                            //MessageBoxHelper.Show("系统注册文件被损坏，请重新安装或修复本系统！");
                            //Application.Exit();
                            Register(bg, text);
                        }
                        else//已填写过注册信息了，要判断是否篡改系统时间或者是否超出试用时间了
                        {
                            DateTime regdate = config.RegDate;
                            DateTime lastdate = config.LastDate;
                            DateTime now = System.DateTime.Now;
                            if (lastdate > now || regdate > now || regdate > lastdate)
                            {
                                MessageBoxHelper.Show("系统时间发生变化，请重新安装！");
                                Application.ExitThread();
                                return;
                            }
                            else if (now > regdate.AddDays(limit))
                            {
                                MessageBoxHelper.Show("超出试用时间" + limit.ToString() + "天限制，请联系产品销售商！" + (phone.Length > 0 ? "\r\n联系电话：" + phone : ""));
                                Application.ExitThread();
                                return;
                            }
                            else
                            {
                                TimeSpan ts = now - regdate;
                                text += "(" + limit + "天试用版本，剩下" + (limit - ts.Days) + "天)";
                                Run(bg, text);
                            }

                        }

                    }

                }
                else
                {
                    productState = ProgramState.Registed;
                    Run(bg, text);
                }


                //判断是否有使用文件配置存在
                //二如果发生时间
                //把需要附加到Winform的text的信息传递过去

            }
            else
            {
                MessageBoxHelper.Show("已经运行了一个这样的程序！");
            }
        }
    }
}
