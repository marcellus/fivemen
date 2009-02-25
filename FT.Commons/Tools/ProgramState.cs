using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 程序的状态，注册，试用，还是还没有输入授权码
    /// </summary>
    public enum ProgramState
    {
        /// <summary>
        /// 已注册
        /// </summary>
        Registed,
        /// <summary>
        /// 试用
        /// </summary>
        Trial,
        /// <summary>
        /// 还没有输入授权码
        /// </summary>
        None
    }
}
