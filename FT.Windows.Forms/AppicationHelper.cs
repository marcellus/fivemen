using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;
using System.Threading;

namespace FT.Windows.Forms
{
    /// <summary>
    /// 执行程序启动
    /// </summary>
    public class AppicationHelper
    {
        public static void StartLimitTimes(string key, int limit, bool needregister)
        {
        }

        private static bool CheckMutex(string key)
        {
            bool result;
            //Create a new mutex using specific mutex name
            Mutex m = new Mutex(false, key, out result);
            return result;

        }

        public static void StartLimitDays(string key, int limit, bool needregister)
        {
           

            if (CheckMutex(key))
            {
                //ProgramState state = RegisterHelper.ValidateProgram();
                //if (state == ProgramState.Registed)
                //{
                //    Start(state);
                //    return;

                //}
                //else if (state == ProgramState.Trial)
                //{
                //    if (RegisterHelper.ValidateDate(Constant.RegisterKey, Constant.ExpireDays))
                //    {
                //        Start(state);
                //        return;
                //    }

                //}

                //SimpleRegister register = new SimpleRegister();
                //if (DialogResult.OK == register.ShowDialog())
                //{
                //    string keycode = RegisterHelper.GetKeyCode(Constant.RegisterKey);
                //    if (keycode == string.Empty)
                //        state = ProgramState.Trial;
                //    else
                //        state = ProgramState.Registed;
                //    Start(state);

                //}
                // Application.ExitThread();

            }
            else
            {
                MessageBoxHelper.Show("已经运行了一个这样的程序！");
            }
        }
    }
}
